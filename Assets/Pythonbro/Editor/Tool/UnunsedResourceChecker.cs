using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class UnunsedResourceChecker : EditorWindow {

    public static void ShowWindow() {
        UnunsedResourceChecker window = GetWindow<UnunsedResourceChecker>(false);
        window.titleContent = new GUIContent("未使用资源检查");
        window.Show();
    }


    public struct Result {
        public string guid;
        public string path;
        public string size;
    }

    private Vector2 pos = Vector2.zero;

    private List<DefaultAsset> usedDirectories;
    private List<DefaultAsset> checkDirectories;
    private int maxLevel = 4;
    private List<Result> checkResult;
    
    void OnEnable() {
        // 从配置文件读取
        UnunsedResourceCheckConfig config = LoadConfig();
        usedDirectories = new List<DefaultAsset>();
        checkDirectories = new List<DefaultAsset>();
        maxLevel = config.checkLevel;
        foreach (DefaultAsset asset in config.usedDirectories) {
            if (asset != null) {
                usedDirectories.Add(asset);
            }
        }
        foreach (DefaultAsset asset in config.checkDirectories) {
            if (asset != null) {
                checkDirectories.Add(asset);
            }
        }
    }

    void OnDestroy() {
        EditorUtility.ClearProgressBar();
    }

    void OnGUI() {
        GUILayout.Space(20);

        EditorGUILayout.LabelField("确定已使用的N个目录（可包含预设、材质球、动画控制器等，它们会引用其他资源）");
        DrawDirectories(usedDirectories);
        GUILayout.Space(20);

        EditorGUILayout.LabelField("需要检查是否被使用的N个目录（可包含任意文件）");
        DrawDirectories(checkDirectories);
        GUILayout.Space(20);

        EditorGUILayout.LabelField("递归检查深度，比如预设->材质球->贴图、预设->动画控制器->动画clip->贴图");
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(40);
        maxLevel = EditorGUILayout.IntField(maxLevel, GUILayout.Width(100));
        EditorGUILayout.EndHorizontal();

        GUI.enabled = usedDirectories.Count > 0 && checkDirectories.Count > 0;
        if (GUILayout.Button("开始检查", GUILayout.Width(100), GUILayout.Height(30))) {
            StartCheck();
        }
        GUI.enabled = true;
        GUILayout.Space(20);

        // 绘制检查结果
        if (checkResult == null) {
            EditorGUILayout.LabelField("未使用资源: 未检查");
        }
        else {
            EditorGUILayout.LabelField("未使用资源: " + checkResult.Count);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(40);
            if (checkResult == null) {
                EditorGUILayout.LabelField("未检查");
            }
            else if (checkResult.Count == 0) {
                EditorGUILayout.LabelField("无结果");
            }
            else {
                pos = EditorGUILayout.BeginScrollView(pos);
                EditorGUIUtility.labelWidth = 40;
                foreach (Result result in checkResult) {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.TextField("GUID:", result.guid, GUILayout.Width(280));
                    if (GUILayout.Button("定位", GUILayout.Width(60))) {
                        Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(result.path);
                    }
                    EditorGUILayout.TextField(result.path);
                    EditorGUILayout.TextField(result.size, GUILayout.Width(60));
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(5);
                }
                EditorGUILayout.EndScrollView();
            }
            GUILayout.Space(40);
            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(20);
    }

    // 绘制文件夹列表
    private void DrawDirectories(List<DefaultAsset> directories) {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(40);

        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("+", GUILayout.Width(30))) {
            directories.Add(null);
        }
        for (int i = 0; i < directories.Count; i++) {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("X", GUILayout.Width(30))) {
                directories.RemoveAt(i);
            }
            else {
                directories[i] = EditorGUILayout.ObjectField(directories[i], typeof(DefaultAsset), false, GUILayout.Width(200)) as DefaultAsset;
                EditorGUILayout.LabelField(directories[i] == null ? "" : AssetDatabase.GetAssetPath(directories[i]));
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3);
        }
        EditorGUILayout.EndVertical();

        GUILayout.Space(40);
        EditorGUILayout.EndHorizontal();
    }

    // 确定已使用的N个目录（可包含预设、材质球、动画控制器等，它们会引用其他资源）
    // 需要检查是否被使用的N个目录（可包含任意文件）
    private void StartCheck() {
        checkResult = new List<Result>();
        pos = Vector2.zero;

        // 保存到配置文件里
        UnunsedResourceCheckConfig config = LoadConfig();
        config.usedDirectories.Clear();
        config.checkDirectories.Clear();
        config.checkLevel = maxLevel;
        foreach (DefaultAsset asset in usedDirectories) {
            if (asset != null) {
                config.usedDirectories.Add(asset);
            }
        }
        foreach (DefaultAsset asset in checkDirectories) {
            if (asset != null) {
                config.checkDirectories.Add(asset);
            }
        }
        EditorUtility.SetDirty(config);
        AssetDatabase.SaveAssets();

        // 建立资源索引
        HashSet<string> usedGuidIndex = BuildUsedGuidIndex(config);
        if(usedGuidIndex == null) {
            return; // 点了取消
        }

        // 检查被使用到的资源
        HashSet<string> finalUsedGuids = new HashSet<string>();
        // 因为资源可能分为多级引用，所以取到结果后累加，再循环检查多次
        
        for(int level = 0; level < maxLevel; level++) {
            List<string> realUsedGuids = CheckResourceRef(config, usedGuidIndex, level, maxLevel);
            if (realUsedGuids == null) {
                return; // 点了取消
            }

            for (int i = 0; i < realUsedGuids.Count; i++) {
                bool added = finalUsedGuids.Add(realUsedGuids[i]);

                // 从被使用的资源中，找到它使用的其他资源，累加到usedResGuids
                if (level < maxLevel - 1 && added) {
                    string path = AssetDatabase.GUIDToAssetPath(realUsedGuids[i]);
                    if (EditorUtility.DisplayCancelableProgressBar(string.Format("累加结果 - 第{0}/{1}层", level + 1, maxLevel), path, (float)i / realUsedGuids.Count)) {
                        EditorUtility.ClearProgressBar();
                        return;
                    }
                    // 找到path对应的资源，使用到的其他资源GUID
                    FindGuids(path, usedGuidIndex);
                }
            }
        }
        System.GC.Collect();

        // 根据被使用的GUID和全部资源的GUID，得出哪些没有被使用
        List<string> finalUnusedRes = GetFinalUnusedRes(config, finalUsedGuids);
        if (finalUnusedRes == null) {
            return; // 点了取消
        }

        // 整理结果用于显示
        int unusedCount = finalUnusedRes.Count;
        for(int i = 0; i < unusedCount; i++) {
            if (EditorUtility.DisplayCancelableProgressBar("整理结果", string.Format("{0}/{1}", i + 1, unusedCount), (float)i / unusedCount)) {
                EditorUtility.ClearProgressBar();
                return;
            }
            string guid = finalUnusedRes[i];
            string path = AssetDatabase.GUIDToAssetPath(guid);
            FileInfo fileInfo = new FileInfo(path);
            string size = fileInfo.Exists ? GetFileSize(fileInfo.Length) : "";

            checkResult.Add(new Result() {
                guid = guid,
                path = path,
                size = size
            });
        }
        checkResult.Sort((a, b) => {
            if(a.path == null) {
                return 1;
            }
            return a.path.CompareTo(b.path);
        });
        System.GC.Collect();

        EditorUtility.ClearProgressBar();
    }

    // 建立已使用资源GUID索引
    private static HashSet<string> BuildUsedGuidIndex(UnunsedResourceCheckConfig config) {
        HashSet<string> usedGuids = new HashSet<string>();

        int usedCount = config.usedDirectories.Count;
        for (int i = 0; i < usedCount; i++) {
            DefaultAsset asset = config.usedDirectories[i];
            string path = AssetDatabase.GetAssetPath(asset);
            if (!Directory.Exists(path)) {
                continue;
            }

            // 遍历文件，建立资源索引
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(name => !name.EndsWith(".meta"));
            int fileCount = files.Count();
            int fileIndex = 0;

            foreach (string file in files) {
                fileIndex++;
                if (EditorUtility.DisplayCancelableProgressBar(string.Format("建立索引({0}/{1})", i + 1, usedCount), path, (float)fileIndex / fileCount)) {
                    EditorUtility.ClearProgressBar();
                    return null;
                }
                // 找到被使用的所有GUID
                FindGuids(file, usedGuids);
            }
            System.GC.Collect();
        }
        return usedGuids;
    }

    // 检查资源使用状态
    private static List<string> CheckResourceRef(UnunsedResourceCheckConfig config, HashSet<string> usedGuids, int level, int maxLevel) {
        List<string> checkResult = new List<string>();

        int checkCount = config.checkDirectories.Count;
        for (int i = 0; i < checkCount; i++) {
            DefaultAsset asset = config.checkDirectories[i];
            string path = AssetDatabase.GetAssetPath(asset);
            if (!Directory.Exists(path)) {
                continue;
            }

            // 遍历文件，检查引用
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(name => !name.EndsWith(".meta"));
            int fileCount = files.Count();
            int fileIndex = 0;

            foreach (string file in files) {
                fileIndex++;
                if (EditorUtility.DisplayCancelableProgressBar(string.Format("检查引用({0}/{1}) - 第{2}/{3}层", i + 1, checkCount, level + 1, maxLevel), path, (float)fileIndex / fileCount)) {
                    EditorUtility.ClearProgressBar();
                    return null;
                }

                // 检查此guid是否被使用
                string guid = AssetDatabase.AssetPathToGUID(file);
                if(guid != null && usedGuids.Contains(guid)) {
                    checkResult.Add(guid);
                }
            }
            System.GC.Collect();
        }
        return checkResult;
    }

    // 得到最终没有被使用的资源
    private static List<string> GetFinalUnusedRes(UnunsedResourceCheckConfig config, HashSet<string> finalUsedGuids) {
        List<string> unusedGuids = new List<string>();

        int checkCount = config.checkDirectories.Count;
        for (int i = 0; i < checkCount; i++) {
            DefaultAsset asset = config.checkDirectories[i];
            string path = AssetDatabase.GetAssetPath(asset);
            if (!Directory.Exists(path)) {
                continue;
            }

            // 遍历文件
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(name => !name.EndsWith(".meta"));
            int fileCount = files.Count();
            int fileIndex = 0;

            foreach (string file in files) {
                fileIndex++;
                if (EditorUtility.DisplayCancelableProgressBar(string.Format("最终结果({0}/{1})", i + 1, checkCount), path, (float)fileIndex / fileCount)) {
                    EditorUtility.ClearProgressBar();
                    return null;
                }

                // 检查此guid是否被使用
                string guid = AssetDatabase.AssetPathToGUID(file);
                if(guid != null && !finalUsedGuids.Contains(guid)) {
                    unusedGuids.Add(guid);
                }
                
            }
            System.GC.Collect();
        }
        return unusedGuids;
    }

    // 找到file中使用到的所有guid，放入guids中
    private static void FindGuids(string file, HashSet<string> guids) {
        if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".tga") || file.EndsWith(".json") || file.EndsWith(".txt")) {
            return; // 有些文件不需要检查
        }

        using (StreamReader reader = new StreamReader(file)) {
            string line = null;
            while ((line = reader.ReadLine()) != null){
                int index = line.IndexOf("guid: ");
                if (index != -1) {
                    string guid = line.Substring(index + 6, 32);
                    guids.Add(guid);
                }
            }
        }
    }

    public static UnunsedResourceCheckConfig LoadConfig() {
        UnunsedResourceCheckConfig config = AssetDatabase.LoadAssetAtPath<UnunsedResourceCheckConfig>("Assets/UnunsedResourceCheckConfig.asset");
        if (config == null) {
            config = CreateInstance<UnunsedResourceCheckConfig>();
            AssetDatabase.CreateAsset(config, "Assets/UnunsedResourceCheckConfig.asset");
        }
        return config;
    }

    private static string GetFileSize(double size) {
        if (size < 1024) {
            return size + "B";
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}KB", size);
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}MB", size);
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}GB", size);
        }
        size /= 1024;
        return string.Format("{0:F2}TB", size);
    }

}

