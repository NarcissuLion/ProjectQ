using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class IconPrefabTool
{

    private static string ICON_PATH = "Assets/GameAssets/SpriteAssets";
    private static string PREFAB_PATH = "Assets/Res/Prefab/SpriteAssets";

    public static void GenerateIconPrefab()
    {
        List<string> prefabList = GetPrefabList();

        string[] dirs = Directory.GetDirectories(ICON_PATH, "*", SearchOption.TopDirectoryOnly);

        int totalDir = dirs.Length;
        Debug.Log(totalDir);
        for (int d = 0; d < totalDir; d++)
        {
            string dir = dirs[d];
            string[] files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);

            int total = files.Length;
            for (int i = 0; i < total; i++)
            {
                string file = files[i];
                if (file.EndsWith(".meta"))
                {
                    continue;
                }
                if (file.EndsWith(".spriteatlas"))
                {
                    continue;
                }

                if (EditorUtility.DisplayCancelableProgressBar((d + 1) + "/" + totalDir, file, (float)i / total))
                {
                    EditorUtility.ClearProgressBar();
                    return;
                }

                RefreshIcon(file, prefabList);
            }
        }

        // 删除不存在的
        foreach (string prefabPath in prefabList)
        {
            AssetDatabase.DeleteAsset(prefabPath);
        }

        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    private static List<string> GetPrefabList()
    {
        List<string> list = new List<string>();

        string[] files = Directory.GetFiles(PREFAB_PATH, "*.prefab", SearchOption.AllDirectories);

        for (int i = 0; i < files.Length; i++)
        {
            string file = files[i];
            string fileName = Path.GetFileNameWithoutExtension(file);
            string dirName = Path.GetDirectoryName(file);
            string dir = dirName.Substring(PREFAB_PATH.Length);

            list.Add(file.Replace("\\", "/"));
        }
        return list;
    }

    private static void RefreshIcon(string file, List<string> prefabList)
    {
        string fileName = Path.GetFileNameWithoutExtension(file);
        string dirName = Path.GetDirectoryName(file);
        string dir = dirName.Substring(ICON_PATH.Length);

        if (!Directory.Exists(PREFAB_PATH + dir))
        {
            Directory.CreateDirectory(PREFAB_PATH + dir);
        }
        string prefabPath = PREFAB_PATH + dir + "/" + fileName + ".prefab";
        prefabList.Remove(prefabPath.Replace("\\", "/"));

        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(file);
        Texture2D texture = null;
        if (sprite == null)
        {
            texture = AssetDatabase.LoadAssetAtPath<Texture2D>(file);
            if (texture == null)
            {
                Debug.LogErrorFormat("\"{0}\" is not a image", file);
                return;
            }
        }

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        bool prefabExist = prefab != null;

        if (prefab == null)
        {
            prefab = new GameObject(fileName);
        }

        if (sprite != null)
        {
            DestroyComponent<RawImage>(prefab);
            Image image = GetComponent<Image>(prefab);
            image.sprite = sprite;
            image.SetNativeSize();
        }
        else
        {
            DestroyComponent<Image>(prefab);
            RawImage rawImage = GetComponent<RawImage>(prefab);
            rawImage.texture = texture;
            rawImage.SetNativeSize();
        }

        if (!prefabExist)
        {
            PrefabUtility.SaveAsPrefabAsset(prefab,prefabPath);
            Object.DestroyImmediate(prefab, true);
        }
        else
        {
            EditorUtility.SetDirty(prefab);
        }
    }

    private static void DestroyComponent<T>(GameObject obj) where T : Component
    {
        Component com = obj.GetComponent<T>();
        if (com != null)
        {
            Object.DestroyImmediate(com, true);
        }
    }

    private static T GetComponent<T>(GameObject obj) where T : Component
    {
        Component com = obj.GetComponent<T>();
        if (com == null)
        {
            com = obj.AddComponent<T>();
        }
        return com as T;
    }

}
