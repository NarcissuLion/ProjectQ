using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

/// <summary>
/// 解析Prefab的Yaml文本
/// </summary>
public class PrefabYaml {

    public class Node {
        public string fileID;
        public string type;
        public JObject values;

        public Node(string fileID) {
            this.fileID = fileID;
        }
    }

    public string version;
    public string tag;
    public Dictionary<string, Node> nodes = new Dictionary<string, Node>();

    /// <summary>
    /// 得到node在prefab中完整路径
    /// </summary>
    /// <param name="fileID"></param>
    /// <returns></returns>
    public string GetPath(string fileID) {
        if(nodes.TryGetValue(fileID, out Node node)) {
            List<Node> transforms = GetNodesByType("RectTransform", "Transform");
            List<Node> gameObjects = GetNodesByType("GameObject");

            Node gameObject, transform;
            if (node.type == "GameObject") {
                gameObject = node;
                transform = GetTransform(fileID, transforms, gameObjects);
            }
            else if (node.type == "RectTransform" || node.type == "RectTransform") {
                gameObject = GetGameObject(fileID, gameObjects);
                transform = node;
            }
            else {
                gameObject = GetGameObject(fileID, gameObjects);
                transform = GetTransform(fileID, transforms, gameObjects);
            }

            string path = gameObject.values["m_Name"].Value<string>();
            while((transform = FindParentTransform(transform.fileID, transforms)) != null){
                Node parentGameObject = GetGameObject(transform.fileID, gameObjects);
                path = parentGameObject.values["m_Name"].Value<string>() + "/" + path;
            }

            return path;
        }
        return null;
    }

    /// <summary>
    /// 得到fileID所属的GameObjectNode
    /// </summary>
    /// <param name="fileID"></param>
    /// <param name="gameObjects"></param>
    /// <returns></returns>
    public Node GetGameObject(string fileID, List<Node> gameObjects = null) {
        if (nodes.TryGetValue(fileID, out Node node)) {
            if (node.type == "GameObject") {
                return node;
            }
            else {
                if (gameObjects == null) {
                    gameObjects = GetNodesByType("GameObject");
                }
                foreach (Node gameObject in gameObjects) {
                    JArray components = (JArray)gameObject.values["m_Component"];
                    if (components != null) {
                        foreach (JToken component in components) {
                            if (component.SelectToken("component.fileID").Value<string>() == fileID) {
                                return gameObject;
                            }
                        }
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 得到fileID所属的TransformNode
    /// </summary>
    /// <param name="fileID"></param>
    /// <param name="transforms"></param>
    /// <param name="gameObjects"></param>
    /// <returns></returns>
    public Node GetTransform(string fileID, List<Node> transforms = null, List<Node> gameObjects = null) {
        if (nodes.TryGetValue(fileID, out Node node)) {
            if (node.type == "Transform") {
                return node;
            }
            else {
                if (transforms == null) {
                    transforms = GetNodesByType("RectTransform", "Transform");
                }

                Node gameObject = null;
                if(node.type == "GameObject") {
                    gameObject = node;
                }
                else {
                    gameObject = GetGameObject(fileID, gameObjects);
                }

                foreach (Node transform in transforms) {
                    if(transform.values.SelectToken("m_GameObject.fileID").Value<string>() == gameObject.fileID) {
                        return transform;
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 得到fileID所属Node的父TransformNode
    /// </summary>
    /// <param name="fileID"></param>
    /// <param name="transformNodes"></param>
    /// <returns></returns>
    public Node FindParentTransform(string fileID, List<Node> transformNodes = null) {
        if(transformNodes == null) {
            transformNodes = GetNodesByType("RectTransform", "Transform");
        }
        Node transform = GetTransform(fileID, transformNodes);

        foreach(Node node in transformNodes) {
            JArray children = (JArray)node.values["m_Children"];
            if(children != null) {
                foreach (JToken child in children) {
                    if(child.SelectToken("fileID").Value<string>() == transform.fileID) {
                        return node;
                    }
                }
            }
        }
        return null;
    }

    public List<Node> GetNodesByType(params string[] types) {
        List<Node> list = new List<Node>();
        HashSet<string> typeSet = new HashSet<string>(types);

        foreach(Node node in nodes.Values) {
            if(typeSet.Contains(node.type)) {
                list.Add(node);
            }
        }
        return list;
    }

    public static PrefabYaml Parse(string filePath) {
        PrefabYaml yaml = new PrefabYaml();

        using (FileStream stream = File.OpenRead(filePath)) {
            StreamReader reader = new StreamReader(stream, true);

            yaml.version = reader.ReadLine();
            yaml.tag = reader.ReadLine();

            string line = null;
            StringBuilder builder = new StringBuilder();
            Node lastNode = null;

            while ((line = reader.ReadLine()) != null) {
                if (line.StartsWith("--- !u!")) {
                    if (builder.Length > 0) {
                        ParseNode(builder.ToString(), lastNode);
                        lastNode = null;
                    }
                    builder.Clear();

                    Node node = new Node(ParseNodeFileID(line));
                    yaml.nodes.Add(node.fileID, node);
                    lastNode = node;
                }
                else {
                    builder.AppendLine(line);
                }
            }
            if (builder.Length > 0) {
                ParseNode(builder.ToString(), lastNode);
                lastNode = null;
            }
        }

        return yaml;
    }

    private static void ParseNode(string input, Node node) {
        var deserializer = new DeserializerBuilder().Build();
        var yamlObject = deserializer.Deserialize(new StringReader(input));

        var serializer = new SerializerBuilder()
            .JsonCompatible()
            .Build();

        var json = serializer.Serialize(yamlObject);
        JObject jObject = JObject.Parse(json);
        node.type = GetFirstKey(jObject);
        node.values = (JObject)jObject[node.type];
    }

    private static string ParseNodeFileID(string line) {
        return line.Substring(line.IndexOf("&") + 1);
    }

    private static string ParseNodeName(string line) {
        return line.Substring(0, line.Length - 1);
    }

    private static string GetFirstKey(JObject json) {
        foreach (KeyValuePair<string, JToken> pair in json) {
            return pair.Key;
        }
        return null;
    }

}
