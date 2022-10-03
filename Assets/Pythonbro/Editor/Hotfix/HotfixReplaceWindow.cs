using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

public class HotfixReplaceWindow : EditorWindow {

    public static void ShowWindow() {
        HotfixReplaceWindow window = GetWindow<HotfixReplaceWindow>("热更替换");
        window.Show();
    }

    string[] regionOptions = {
        "CN",
    };
    string region = null;
    int regionIndex = 0;

    string[] platformOptions = {
        "Android",
        "iOS",
    };
    string platform = null;
    int platformIndex = 0;

    string[] versionOptions = { "选择版本..." };
    string version = null;
    int versionIndex = 0;

    string output = "";
    Vector2 outputPos = Vector2.zero;

    private void OnEnable() {
        region = regionOptions[regionIndex];
        platform = platformOptions[platformIndex];
        OnEndChange();
    }

    void OnGUI() {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox("自动替换[Project]/AssetBundles/[Platform]/[Region]下的package和versions目录， package.zip不管", MessageType.Info);
        GUILayout.Space(10);

        EditorGUI.BeginChangeCheck();
        regionIndex = EditorGUILayout.Popup("区域", regionIndex, regionOptions, GUILayout.Width(300));
        region = regionOptions[regionIndex];

        platformIndex = EditorGUILayout.Popup("平台", platformIndex, platformOptions, GUILayout.Width(300));
        platform = platformOptions[platformIndex];
        if (EditorGUI.EndChangeCheck()) {
            OnEndChange();
        }

        versionIndex = EditorGUILayout.Popup("版本", versionIndex, versionOptions, GUILayout.Width(300));
        version = versionIndex != 0 ? versionOptions[versionIndex] : null;
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUI.enabled = version != null;
        if (GUILayout.Button("替换StreamingAssets文件...", GUILayout.Width(200))) {
            string path = Application.streamingAssetsPath;
            path = EditorUtility.OpenFilePanel("选择文件", path, null);
            OnChooseFile(path);
        }
        GUI.enabled = true;
        if (GUILayout.Button("打开位置", GUILayout.MaxWidth(200))) {
            System.Diagnostics.Process.Start("explorer.exe", "/open," + GetRootPath());
        }
        if (GUILayout.Button("清除日志", GUILayout.MaxWidth(200))) {
            output = "";
            GUI.FocusControl(null);
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        outputPos = EditorGUILayout.BeginScrollView(outputPos);
        output = EditorGUILayout.TextArea(output, GUILayout.ExpandHeight(true));
        EditorGUILayout.EndScrollView();

        GUILayout.Space(20);
    }

    void OnEndChange() {
        string vertionPath = GetRootPath() + "/versions";
        if (!Directory.Exists(vertionPath)) {
            return;
        }

        string[] dirs = Directory.GetDirectories(vertionPath);
        versionOptions = new string[dirs.Length + 1];
        versionOptions[0] = "选择版本...";
        versionIndex = 0;

        for (int i = 0; i < dirs.Length; i++) {
            string name = Path.GetFileName(dirs[i]);
            versionOptions[i + 1] = name;
        }
    }

    string GetRootPath() {
        return new DirectoryInfo(Application.dataPath + "/../AssetBundles/" + platform + "/" + region).FullName;
    }

    void OnChooseFile(string path) {
        if (string.IsNullOrEmpty(path)) {
            return;
        }

        //string hashText = File.ReadAllText(versionPath + "/hash.json", Encoding.UTF8);
        //HotfixHashList hotfixHash = JsonUtil.ParseJsonObject<HotfixHashList>(hashText);

        string versionPath = GetRootPath() + "/versions/" + version;
        string packagePath = GetRootPath() + string.Format("/package/{0}/{1}", version, platform);

        if (!Directory.Exists(versionPath)) {
            EditorUtility.DisplayDialog("Error", "版本不存在", "OK");
            return;
        }
        if (!Directory.Exists(packagePath)) {
            EditorUtility.DisplayDialog("Error", "package目录不存在", "OK");
            return;
        }

        // 替换list.json
        string listText = File.ReadAllText(versionPath + "/list.json", Encoding.UTF8);
        HotfixList hotfixList = JsonUtil.ParseJsonObject<HotfixList>(listText);

        string name = path.Substring(Application.streamingAssetsPath.Length + 1).Replace("\\", "/");
        string md5 = CommonUtil.GetMD5FromFile(path);
        long size = new FileInfo(path).Length;

        HotfixList.File file = hotfixList.GetFile(name);
        if(file != null) {
            PrintLine("更改 {0}\n\tmd5: {1} → {2}, size: {3} → {4}, version: {5} → {6}", name, file.md5, md5, file.size, size, file.version, file.version);
            file.md5 = md5;
            file.size = size;
        }
        else {
            PrintLine("添加 {0}\n\tmd5: {1}, size: {2}, version: {3}", name, md5, size, 0);
            hotfixList.AddFile(name, md5, size, 0);
        }
        File.WriteAllText(versionPath + "/list.json", JsonUtil.ToJsonString(hotfixList, true), Encoding.UTF8);

        // 替换package文件
        string srcPath = path;
        string destPath = packagePath + "/" + name;
        FileUtil.ReplaceFile(srcPath, destPath);
    }

    void PrintLine(string msg, params object[] args) {
        output += string.Format(msg, args) + "\n";
    }

}
