using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

public class HotfixWindow : EditorWindow {

    public static void ShowWindow() {
        HotfixWindow window = GetWindow<HotfixWindow>("热更新窗口");
        window.Show();
    }

    private GUILayoutOption btnHeight = GUILayout.Height(30);
    private GUILayoutOption btnWidth = GUILayout.Width(200);

    private const string info = "打包规则：\n"
        + "\t设置N个打包根目录\n"
        + "\t每个根目录向下递归遍历，为每一个包含子文件的目录设置AssetBundle名\n"
        + "\t打包后清空AssetBundle名";

    private void OnGUI() {
        if (EditorApplication.isCompiling) {
            return;
        }

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Test1", btnHeight, btnWidth)) {
            Test1();
        }
        if (GUILayout.Button("检查更新包依赖", btnHeight, btnWidth)) {
            CheckDependencies();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("设置AssetBundle名", btnHeight, btnWidth)) {
            HotfixEditor.SetAssetBundleNames();
        }
        if (GUILayout.Button("清空AssetBundle名", btnHeight, btnWidth)) {
            HotfixEditor.ClearAssetBundleNames();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("加密Lua和配置文件", btnHeight, btnWidth)) {
            HotfixEditor.EncryptLuaConfig();
        }
        if (GUILayout.Button("解密Lua和配置文件", btnHeight, btnWidth)) {
            HotfixEditor.DecryptLuaConfig();
        }
        GUILayout.EndHorizontal();

        // Android
        GUILayout.Space(20);
        GUILayout.Label("Android 打包");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("更新AssetBundle + Zip", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, true, true, false, false);
        }
        if (GUILayout.Button("更新AssetBundle + Max", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, true, false, true, false);
        }
        if (GUILayout.Button("更新AssetBundle", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, true, false, false, false);
        }
        if (GUILayout.Button("Zip", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, false, true, false, false);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Max", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, false, false, true, false);
        }
        if (GUILayout.Button("更新AssetBundle + Zip + Obb", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, true, true, false, true);
        }
        if (GUILayout.Button("Zip + Obb", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, false, true, false, true);
        }
        if (GUILayout.Button("啥也不干", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.Android, false, false, false, false);
        }
        GUILayout.EndHorizontal();

        // iOS
        GUILayout.Space(20);
        GUILayout.Label("iOS 打包");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("更新AssetBundle + Zip", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, true, true, false, false);
        }
        if (GUILayout.Button("更新AssetBundle + Max", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, true, false, true, false);
        }
        if (GUILayout.Button("更新AssetBundle", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, true, false, false, false);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Zip", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, false, true, false, false);
        }
        if (GUILayout.Button("Max", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, false, false, true, false);
        }
        if (GUILayout.Button("啥也不干", btnHeight, btnWidth)) {
            HotfixEditor.Package(BuildTarget.iOS, false, false, false, false);
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(info, MessageType.Info);

        GUILayout.Space(10);
    }

    void Test1() {
        //HotfixConfig config = HotfixEditor.LoadConfig();
        //DefaultAsset obj = config.buildList[0];

        //string path = AssetDatabase.GetAssetPath(obj);
        //AssetImporter import = AssetImporter.GetAtPath(path);
        //import.assetBundleName = path;

        //HotfixPackageContext context = new HotfixPackageContext(BuildTarget.Android, null);
        //Debug.Log(context.Version);
        //Debug.Log(context.GetVersionPath(context.Version));

        EditorUtility.DisplayDialog("Title", "瞎点啥玩意儿", "OK");
    }

    public static void CheckDependencies() {
        string rootPath = Application.dataPath + "/../AssetBundles/Android/assetbundle";
        string prefabPath = Application.dataPath + "/../AssetBundles/Android/assetbundle/assets/game/resources/prefab";


        List<string> commonList = new List<string>();
        commonList.Add("assets/game/gameassets/icon");
        commonList.Add("assets/game/gameassets/ui/common");
        commonList.Add("assets/game/gameassets/effect");
        commonList.Add("assets/game/resources/font");
        commonList.Add("assets/game/resources/shader");
        commonList.Add("assets/game/resources/material");

        AssetBundle mainAssetBundle = AssetBundle.LoadFromFile(rootPath + "/assetbundle");
        AssetBundleManifest manifest = mainAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        string prefixPath = Application.dataPath + "/../AssetBundles/Android/assetbundle";
        int prefixLength = new FileInfo(prefixPath).FullName.Length;

        string outputFile = Application.dataPath + "/../AssetBundles/Dependencies.txt";
        if (File.Exists(outputFile)) {
            File.Delete(outputFile);
        }
        Stream outputStream = File.OpenWrite(outputFile);
        StreamWriter outputWriter = new StreamWriter(outputStream, Encoding.UTF8);

        outputWriter.WriteLine("xxx_module, 是xxx文件夹的意思");
        outputWriter.WriteLine("");

        outputWriter.WriteLine("以下公用资源不算在内:");
        foreach (string common in commonList) {
            outputWriter.WriteLine("    " + common);
        }
        outputWriter.WriteLine("");

        string[] files = Directory.GetFiles(prefabPath, "*.*", SearchOption.AllDirectories);
        int count = files.Length;

        for (int i = 0; i < count; i++) {
            string file = files[i];
            EditorUtility.DisplayProgressBar(string.Format("处理中 ({0}/{1})", i + 1, count), file, (float)i / count);
            if (file.EndsWith(".manifest") || file.EndsWith("assetbundle")) {
                continue;
            }

            string bundleName = file.Substring(prefixPath.Length + 1).Replace("\\", "/");
            string[] dependencies = manifest.GetAllDependencies(bundleName);
            string[] directDependencies = manifest.GetDirectDependencies(bundleName);

            List<string> list = new List<string>();
            List<string> directList = new List<string>();

            foreach (string path in directDependencies) {
                bool isCommon = false;
                foreach (string common in commonList) {
                    if (path.StartsWith(common)) {
                        isCommon = true;
                        break;
                    }
                }
                if (!isCommon) {
                    directList.Add(path);
                }
            }

            foreach (string path in dependencies) {
                if (directList.Contains(path)) {
                    continue;
                }
                bool isCommon = false;
                foreach (string common in commonList) {
                    if (path.StartsWith(common)) {
                        isCommon = true;
                        break;
                    }
                }
                if (!isCommon) {
                    list.Add(path);
                }
            }


            if (list.Count > 0 || directList.Count > 0) {
                string bundlePath = file.Substring(prefixPath.Length + 1).Replace("\\", "/");
                outputWriter.WriteLine(bundlePath);

                if (directList.Count > 0) {
                    outputWriter.WriteLine("    " + directList.Count + " 个直接依赖");
                    foreach (string line in directList) {
                        outputWriter.WriteLine("        " + line);
                    }
                }
                if (list.Count > 0) {
                    outputWriter.WriteLine("    " + list.Count + " 个间接依赖");
                    foreach (string line in list) {
                        outputWriter.WriteLine("        " + line);
                    }
                }

                outputWriter.WriteLine("");
            }
        }

        AssetBundle.UnloadAllAssetBundles(true);
        outputWriter.Close();
        EditorUtility.ClearProgressBar();
        Debug.Log("输出到: " + new FileInfo(outputFile).FullName);
    }

}
