using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

public static class HotfixEditor {

    public const string MAIN_CONFIG = "Assets/HotfixConfig.asset";

    public static readonly string TITLE_GEN_LIST = "生成变更列表";
    public static readonly string TITLE_COPY = "复制文件";
    public static readonly string TITLE_SET_BUNDLE_NAME = "设置AssetBundleName";
    public static readonly string TITLE_CLEAR_BUNDLE_NAME = "清空AssetBundleName";

    [MenuItem("热更新/Test", false, 0)]
    public static void Test() {
        
    }

    //[MenuItem("热更新/解压FGame\\AssetBundles\\package.max", false, 0)]
    //public static void DecompressMax() {
    //    string path = new DirectoryInfo(Application.dataPath).Parent.FullName;
    //    string srcPath = path + "/AssetBundles/package.max";
    //    string outPath = path + "/AssetBundles/package";

    //    long totalSize = 0;
    //    long downloaded = 0;

    //    if (Directory.Exists(outPath)) {
    //        Directory.Delete(outPath, true);
    //    }

    //    HotfixUtil.DecompressMax(srcPath, outPath, 4096000, 3, (_totalSize) => {
    //        totalSize = _totalSize;
    //    }, (delta) => {
    //        downloaded += delta;
    //        if (downloaded < totalSize) {
    //            EditorUtility.DisplayProgressBar("解压缩", CommonUtil.GetFileSize(downloaded) + " / " + CommonUtil.GetFileSize(totalSize), (float)downloaded / totalSize);
    //        }
    //        else {
    //            EditorUtility.ClearProgressBar();
    //        }
    //    });
    //}

    [MenuItem("热更新/热更新窗口", false, 100)]
    public static void ShowHotfixWindow() {
        HotfixWindow.ShowWindow();
    }

    [MenuItem("热更新/创建HotfixConfig", false, 100)]
    public static void CreateConfig() {
        HotfixConfig config = LoadConfig();
        Selection.activeObject = config;
    }

    [MenuItem("热更新/热更新文件替换", false, 100)]
    public static void ShowHotfixReplaceWindow() {
        HotfixReplaceWindow.ShowWindow();
    }

    [MenuItem("热更新/打开热更新目录", false, 100)]
    public static void ShowHotfixDirectory() {
        if (Application.platform == RuntimePlatform.WindowsEditor) {
            System.Diagnostics.Process.Start("explorer.exe", "/open," + Application.persistentDataPath.Replace("/", "\\") + "\\update");
        }
    }

    [MenuItem("热更新/打开版本配置文件 version.json", false, 100)]
    public static void OpenVersionConfigFile() {
        string path = Application.streamingAssetsPath + "/SysConfig/version.json";
        System.Diagnostics.Process.Start("explorer.exe", "/open," + path.Replace("/", "\\"));
    }

    [MenuItem("热更新/JIT编码Lua文件夹并另存为LuaEncode", false, 200)]
    public static void JITLuaFileMenu() {
        LuaEncodeTool.EncodeLuaFile(BuildTarget.Android);

        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    [MenuItem("热更新/JIT编码Lua文件夹并覆盖替换", false, 200)]
    public static void JITLuaFileAndReplace() {
        string luaPath = Application.dataPath + "/StreamingAssets/Lua";

        DirectoryInfo dir = new DirectoryInfo(luaPath);
        LuaEncodeTool.EncodeLuaDirectory(BuildTarget.Android, dir, luaPath, luaPath);

        EditorUtility.ClearProgressBar();
    }

    [MenuItem("热更新/删除JIT编码的LuaEncode文件夹 ", false, 200)]
    public static void ClearJITLuaFile() {
        string outPath = Application.dataPath + "/StreamingAssets/LuaEncode";
        if (Directory.Exists(outPath)) {
            Directory.Delete(outPath, true);
            AssetDatabase.Refresh();
        }
    }

    [MenuItem("热更新/加密Lua和配置文件", false, 300)]
    public static void EncryptLuaConfig() {
        EncryptDir(Application.streamingAssetsPath + "/Lua");
        EncryptDir(Application.streamingAssetsPath + "/Config");
        EncryptDir(Application.streamingAssetsPath + "/SysConfig");
        CreateEncryptMark(Application.streamingAssetsPath);
    }

    [MenuItem("热更新/解密Lua和配置文件", false, 300)]
    public static void DecryptLuaConfig() {
        DecryptDir(Application.streamingAssetsPath + "/Lua");
        DecryptDir(Application.streamingAssetsPath + "/Config");
        DecryptDir(Application.streamingAssetsPath + "/SysConfig");
        RemoveEncryptMark(Application.streamingAssetsPath);
    }

    [MenuItem("热更新/仅删除加密标记文件", false, 300)]
    public static void RemoveEncryptMarkFile() {
        RemoveEncryptMark(Application.streamingAssetsPath);
    }

    [MenuItem("热更新/删除可热更新的资源", false, 400)]
    public static void DeleteHotfixResourceMenu() {
        DeleteHotfixResource();
    }

    [MenuItem("热更新/移除可热更新的资源", false, 400)]
    public static void RemoveHotfixResourceMenu() {
        RemoveHotfixResource();
    }

    [MenuItem("热更新/还原可热更新的资源", false, 400)]
    public static void RevertHotfixResourceMenu() {
        RevertHotfixResource();
    }

    [MenuItem("热更新/Android打包 (更新Assetbundle)", false, 500)]
    public static void Pack_Android_AssetBundle() {
        Package(BuildTarget.Android, true, false, false, false);
    }

    [MenuItem("热更新/Android打包 (Zip + 更新Assetbundle)", false, 500)]
    public static void Pack_Android_Zip_AssetBundle() {
        Package(BuildTarget.Android, true, true, false, false);
    }

    [MenuItem("热更新/Android打包 (Max + 更新Assetbundle)", false, 500)]
    public static void Pack_Android_Max_AssetBundle() {
        Package(BuildTarget.Android, true, false, true, false);
    }

    [MenuItem("热更新/Android打包 (Zip)", false, 500)]
    public static void Pack_Android_Zip() {
        Package(BuildTarget.Android, false, true, false, false);
    }

    [MenuItem("热更新/Android打包 (Max)", false, 500)]
    public static void Pack_Android_Max() {
        Package(BuildTarget.Android, false, false, true, false);
    }

    [MenuItem("热更新/Android打包 (Zip + Obb + 更新Assetbundle)", false, 500)]
    public static void Pack_Android_Zip_Obb_AssetBundle() {
        Package(BuildTarget.Android, true, true, false, true);
    }

    [MenuItem("热更新/Android打包 (Zip + Obb)", false, 500)]
    public static void Pack_Android_Zip_Obb() {
        Package(BuildTarget.Android, false, true, false, true);
    }

    [MenuItem("热更新/iOS打包 (更新Assetbundle)", false, 600)]
    public static void Pack_IOS_AssetBundle() {
        Package(BuildTarget.iOS, true, false, false, false);
    }

    [MenuItem("热更新/iOS打包 (Zip + 更新Assetbundle)", false, 600)]
    public static void Pack_IOS_Zip_AssetBundle() {
        Package(BuildTarget.iOS, true, true, false, false);
    }

    [MenuItem("热更新/iOS打包 (Max + 更新Assetbundle)", false, 600)]
    public static void Pack_IOS_Max_AssetBundle() {
        Package(BuildTarget.iOS, true, false, true, false);
    }

    [MenuItem("热更新/iOS打包 (Zip)", false, 600)]
    public static void Pack_IOS_Zip() {
        Package(BuildTarget.iOS, false, true, false, false);
    }

    [MenuItem("热更新/iOS打包 (Max)", false, 600)]
    public static void Pack_IOS_Max() {
        Package(BuildTarget.iOS, false, false, true, false);
    }

    [MenuItem("热更新/Android拷贝资源包到项目中", false, 700)]
    public static void CopyAssetbundleToProject_Android() {
        CopyAssetbundleToProject(BuildTarget.Android);
    }

    [MenuItem("热更新/iOS拷贝资源包到项目中", false, 700)]
    public static void CopyAssetbundleToProject_IOS() {
        CopyAssetbundleToProject(BuildTarget.iOS);
    }

    public static void ClearBeforeBuild() {
        RemoveEncryptMarkFile();
    }

    // 打包
    // 输出目录 OutputPath = Project/AssetBundles/{Platform}/{Region}/
    // 当前打包输出 OutputPath/package_{platform}.zip
    // 历史打包目录 OutputPath/package/{version}/
    // 历史版本目录 OutputPath/versions/{version}/
    public static void Package(BuildTarget target, bool rebuildAssetBundle, bool createZip, bool createMax, bool createObb) {
        try {
            BetterStreamingAssets.Initialize();
            GameUtil.CheckEncryptState();
            HotfixPackageContext context = new HotfixPackageContext(target, null);
            HotfixConfig config = LoadConfig();
            CreateSvnFile();

            bool needRebuild = NeedRebuildAssetBundle(context, rebuildAssetBundle);
            if (needRebuild) {
                Dictionary<string, string> nameDict = new Dictionary<string, string>();

                List<AssetBundleBuild> buildMap = SetAssetBundleNames(nameDict, config);      // 给需要打包的资源设置AssetBundle名
                AssetBundleManifest manifest = BuildAssetBundle(buildMap, context, target);  // 打包
                //ClearAssetBundleNames(nameDict, config);    // 清空打包前设置的AssetBundle名

                if (manifest == null) {
                    throw new System.Exception("打包失败");
                }
            }

            // 准备相关目录
            HotfixUtil.PrepareDir(context.GetPackagePath(context.Version), true);
            HotfixUtil.PrepareDir(context.GetVersionPath(context.Version), true);

            // 将资源复制到package目录下
            CopyFilesToPackage(context);

            // 生成资源包Hash列表hash.json，放到version目录下
            CreateBundleHashList(context, config);

            // 根据上个版本（如果存在），生成变更列表list.json
            CreateChangeList(context);

            // 打包zip
            if (createZip) {
                CreateZip(context);
            }

            // 打包max
            if (createMax) {
                CreateMax(context);
            }

            // 打包obb
            if (createObb) {
                CreateObb(context);
            }

            // 调试信息
            HotfixList list1 = LoadChangeList(context, context.PreVersion);
            HotfixList list2 = LoadChangeList(context, context.Version);
            string compareResult = CompareListJson(list1, list2);
            File.WriteAllText(Path.Combine(context.OutputPath, "different.txt"), compareResult, Encoding.UTF8);
            // versions里放一个
            string versionPath = context.GetVersionPath(context.Version);
            File.WriteAllText(Path.Combine(versionPath, "different.txt"), compareResult, Encoding.UTF8);
            
            Debug.LogFormat("打包完成: {0}", context.OutputPath);
        }
        catch (System.Exception e) {
            EditorUtility.ClearProgressBar();
            Debug.LogException(e);
        }
    }

    // 生成svn版本文件
    private static void CreateSvnFile() {
        string version = SVNTool.GetDirVersion(Application.dataPath);
        File.WriteAllText(Application.streamingAssetsPath + "/svn.txt", version);
    }

    private static bool NeedRebuildAssetBundle(HotfixPackageContext context, bool rebuildAssetBundle) {
        // 构建目录
        string buildPath = context.BuildPath;

        // 如果设置不重新打Bundle，那么查找是否存在之前版本的Bundle，有则使用，没有则重新打包
        if (!rebuildAssetBundle) {
            bool hasOldBuild = File.Exists(buildPath + "/assetbundle.manifest");
            if (hasOldBuild) {
                return false;
            }
        }

        return true;
    }

    // 编译AssetBundle
    private static AssetBundleManifest BuildAssetBundle(List<AssetBundleBuild> buildMap, HotfixPackageContext context, BuildTarget target) {
        // 构建目录
        string buildPath = context.BuildPath;

        // 清空构建目录
        HotfixUtil.PrepareDir(buildPath, true);

        // 开始构建
        BuildAssetBundleOptions options = BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression;
        //AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(buildPath, options, target);
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(buildPath, buildMap.ToArray(), options, target);
        return manifest;
    }

    // 删除可热更新的资源
    public static void DeleteHotfixResource() {
        HotfixConfig config = LoadConfig();
        foreach (DefaultAsset pathAsset in config.buildList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            AssetDatabase.DeleteAsset(path);
        }
        foreach (DefaultAsset pathAsset in config.extraDeleteList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            AssetDatabase.DeleteAsset(path);
        }
        AssetDatabase.Refresh();
    }

    // 移动可热更资源到备份目录
    public static void RemoveHotfixResource() {
        string backupPath = new DirectoryInfo(Application.dataPath + "/../HotfixBackup").FullName;
        if (Directory.Exists(backupPath)) {
            Directory.Delete(backupPath, true);
        }
        Directory.CreateDirectory(backupPath);

        StringBuilder buffer = new StringBuilder();

        HotfixConfig config = LoadConfig();
        foreach (DefaultAsset pathAsset in config.buildList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            string srcDir = HotfixUtil.AssetPathToFilePath(path);
            string destDir = Path.Combine(backupPath, path);

            DirectoryInfo parentDir = Directory.GetParent(destDir);
            if (!parentDir.Exists) {
                parentDir.Create();
            }
            Directory.Move(srcDir, destDir);
            buffer.Append(srcDir).Append(" => ").Append(destDir).Append("\r\n");
        }

        foreach (DefaultAsset pathAsset in config.extraDeleteList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            string srcDir = HotfixUtil.AssetPathToFilePath(path);
            string destDir = Path.Combine(backupPath, path);

            DirectoryInfo parentDir = Directory.GetParent(destDir);
            if (!parentDir.Exists) {
                parentDir.Create();
            }
            Directory.Move(srcDir, destDir);
            buffer.Append(srcDir).Append(" => ").Append(destDir).Append("\r\n");
        }

        File.WriteAllText(backupPath + "/list.txt", buffer.ToString());
        AssetDatabase.Refresh();
    }

    // 从备份目录还原可热更资源
    public static void RevertHotfixResource() {
        string backupPath = new DirectoryInfo(Application.dataPath + "/../HotfixBackup").FullName;
        if (!Directory.Exists(backupPath)) {
            return;
        }

        string[] lines = File.ReadAllLines(backupPath + "/list.txt");
        foreach (string line in lines) {
            if (string.IsNullOrEmpty(line)) {
                continue;
            }
            string[] array = line.Split(new string[] { " => " }, System.StringSplitOptions.None);
            string srcDir = array[1];
            string destDir = array[0];

            Directory.Move(srcDir, destDir);
        }

        Directory.Delete(backupPath, true);
        AssetDatabase.Refresh();
    }


    // 设置所有AssetBundle的名称
    public static void SetAssetBundleNames() {
        Dictionary<string, string> nameDict = new Dictionary<string, string>();
        List<AssetBundleBuild> buildMap = SetAssetBundleNames(nameDict, LoadConfig());
        Debug.Log("AssetBundle count: " + buildMap.Count);
    }

    // 设置AssetBundle名称
    private static List<AssetBundleBuild> SetAssetBundleNames(Dictionary<string, string> nameDict, HotfixConfig config) {
        List<AssetBundleBuild> buildMap = new List<AssetBundleBuild>();
        EditorUtility.DisplayProgressBar(TITLE_SET_BUNDLE_NAME, "检查资源目录", 0);

        // 得到所有AssetBundle名称和资源path的对应缓存
        foreach (DefaultAsset pathAsset in config.buildList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            SetDirAssetBundleName(path, nameDict, config);
        }

        // 统一设置AssetBundle名
        int index = 0;
        int count = nameDict.Count;
        foreach (KeyValuePair<string, string> pair in nameDict) {
            //AssetImporter import = AssetImporter.GetAtPath(pair.Key);
            //import.assetBundleName = pair.Value;

            AssetBundleBuild build = new AssetBundleBuild();
            build.assetNames = new string[] { pair.Key };
            build.assetBundleName = pair.Value;
            buildMap.Add(build);

            index++;
            EditorUtility.DisplayProgressBar(TITLE_SET_BUNDLE_NAME, pair.Key, (float)index / count);
        }

        EditorUtility.ClearProgressBar();
        return buildMap;
    }

    // 清空所有AssetBundle的名称
    public static void ClearAssetBundleNames() {
        ClearAssetBundleNames(null, LoadConfig());
    }

    public static void ClearAssetBundleNames(Dictionary<string, string> nameDict, HotfixConfig config) {
        if (nameDict == null) {
            EditorUtility.DisplayProgressBar(TITLE_CLEAR_BUNDLE_NAME, "", 0);
            foreach (DefaultAsset pathAsset in config.buildList) {
                string path = AssetDatabase.GetAssetPath(pathAsset);
                ClearDirAssetBundleName(path, config);
            }
        }
        else {
            int index = 0;
            int count = nameDict.Count;
            foreach (KeyValuePair<string, string> pair in nameDict) {
                AssetImporter import = AssetImporter.GetAtPath(pair.Key);
                import.assetBundleName = null;

                index++;
                EditorUtility.DisplayProgressBar(TITLE_CLEAR_BUNDLE_NAME, pair.Key, (float)index / count);
            }
        }

        EditorUtility.ClearProgressBar();
    }

    // 将更新资源复制到package目录下
    public static void CopyFilesToPackage(HotfixPackageContext context) {
        string packagePath = context.GetPackagePath(context.Version);

        // 复制AssetBundle
        CopyDirFiles(context.BuildPath, packagePath + "/assetbundle", ".manifest");

        // 复制StreamingAssets
        CopyDirFiles(Application.streamingAssetsPath + "/Config", packagePath + "/Config", ".meta");
        CopyDirFiles(Application.streamingAssetsPath + "/Lua", packagePath + "/Lua", ".meta");
        CopyDirFiles(Application.streamingAssetsPath + "/SysConfig", packagePath + "/SysConfig", ".meta");
        CopyDirFiles(Application.streamingAssetsPath + "/Res", packagePath + "/Res", ".meta");

        if (File.Exists(Application.streamingAssetsPath + "/encrypt.txt")) {
            CopyFile(Application.streamingAssetsPath + "/encrypt.txt", packagePath + "/encrypt.txt");
        }
        if (File.Exists(Application.streamingAssetsPath + "/svn.txt")) {
            CopyFile(Application.streamingAssetsPath + "/svn.txt", packagePath + "/svn.txt");
        }
    }

    // 根据构建目录生成文件hash清单 hash.json
    public static void CreateBundleHashList(HotfixPackageContext context, HotfixConfig config) {
        string assetBundleRoot = context.BuildPath;
        HotfixHashList hashList = CreateBundleHashList(context.Version, assetBundleRoot, config);

        // 保存json文件
        string json = JsonUtil.ToJsonString(hashList, true);
        string versionPath = context.GetVersionPath(context.Version);
        string packagePath = context.GetPackagePath(context.Version);

        // versions里放一个
        File.WriteAllText(Path.Combine(versionPath, "hash.json"), json, Encoding.UTF8);
        // package里放一个
        File.WriteAllText(Path.Combine(packagePath, "assetbundle/hash.json"), json, Encoding.UTF8);
    }

    // 根据上个版本（如果存在），生成变更列表list.json
    public static void CreateChangeList(HotfixPackageContext context) {
        HotfixHashList preHashList = LoadHashList(context, context.PreVersion);
        HotfixHashList curHashList = LoadHashList(context, context.Version);

        HotfixList preChangeList = LoadChangeList(context, context.PreVersion);
        HotfixList curChangeList = new HotfixList();
        curChangeList.version = context.Version;

        string packagePath = context.GetPackagePath(context.Version);
        string[] files = Directory.GetFiles(packagePath, "*.*", SearchOption.AllDirectories);
        int count = files.Length;

        long totalSize = 0;

        // 比较每个文件是否有变化，记录每个文件的信息
        for (int i = 0; i < count; i++) {
            string file = HotfixUtil.NormalizePath(files[i]);
            string name = file.Substring(packagePath.Length + 1);
            if (name == "list.json" || name == "SysConfig/version.json") {
                continue;
            }
            EditorUtility.DisplayProgressBar(TITLE_GEN_LIST, name, (float)i / count);

            string md5 = CommonUtil.GetMD5FromFile(file);
            long size = new FileInfo(file).Length;
            totalSize += size;
            bool different;

            // 是否AssetBundle文件
            if (name.StartsWith("assetbundle/") && name != "assetbundle/hash.json") {
                string bundleName = name.Substring("assetbundle/".Length);
                different = HotfixUtil.IsBundleDifferent(bundleName, preHashList, curHashList, preChangeList, md5);
            }
            else {
                different = HotfixUtil.IsFileDifferent(name, md5, preChangeList);
            }

            int version = HotfixUtil.GetCurFileVersion(name, preChangeList, different);
            curChangeList.AddFile(name, md5, size, version);
        }
        curChangeList.totalSize = totalSize;
        curChangeList.fileCount = curChangeList.list.Count;

        // 如果是混淆打包，要同步主包的version
        string syncListPath = Path.Combine(context.OutputPath, "list_sync.json");
        if (File.Exists(syncListPath)) {
            Debug.Log("Sync list.json");

            string text = File.ReadAllText(syncListPath, Encoding.UTF8);
            HotfixList syncList = JsonUtil.ParseJsonObject<HotfixList>(text);
            SyncListVersion(syncList, curChangeList);
        }

        // 保存json文件
        string json = JsonUtil.ToJsonString(curChangeList, true);
        string versionPath = context.GetVersionPath(context.Version);

        // versions里放一个
        File.WriteAllText(Path.Combine(versionPath, "list.json"), json, Encoding.UTF8);
        // package里放一个
        File.WriteAllText(Path.Combine(packagePath, "list.json"), json, Encoding.UTF8);
        // 工程里放一个，之后打安装包需要
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "list.json"), json, Encoding.UTF8);

        EditorUtility.ClearProgressBar();
    }

    // zip打包
    public static void CreateZip(HotfixPackageContext context) {
        EditorUtility.DisplayProgressBar("Zip打包", "", 0);
        string packageRootPath = context.GetPackageRootPath(context.Version);

        string fileName = string.Format("package_{0}.zip", context.TargetLowerName);
        string outputPath = Path.Combine(context.OutputPath, fileName);

        HotfixUtil.CompressZip(packageRootPath, outputPath, true);
        EditorUtility.ClearProgressBar();
    }

    // max打包
    public static void CreateMax(HotfixPackageContext context) {
        EditorUtility.DisplayProgressBar("max打包", "", 0);
        string packageRootPath = context.GetPackageRootPath(context.Version);

        string fileName = string.Format("package_{0}.max", context.TargetLowerName);
        string outputPath = Path.Combine(context.OutputPath, fileName);

        HotfixUtil.CompressMax(packageRootPath, outputPath, true);
        EditorUtility.ClearProgressBar();
    }

    // obb打包
    public static void CreateObb(HotfixPackageContext context) {
        EditorUtility.DisplayProgressBar("Obb打包", "", 0);
        EditorUtility.ClearProgressBar();
    }

    public static HotfixConfig LoadConfig() {
        HotfixConfig config = AssetDatabase.LoadAssetAtPath<HotfixConfig>(MAIN_CONFIG);
        if (config == null) {
            config = ScriptableObject.CreateInstance<HotfixConfig>();
            AssetDatabase.CreateAsset(config, MAIN_CONFIG);
        }
        return config;
    }

    public static void SaveConfig(HotfixConfig config) {
        EditorUtility.SetDirty(config);
        AssetDatabase.SaveAssets();
    }

    // 递归得到目录的AssetBundle名，存入nameDict
    public static void SetDirAssetBundleName(string path, Dictionary<string, string> nameDict, HotfixConfig config) {
        string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);

        // 除去.meta文件以外是否包含普通文件
        bool hasFile = false;
        foreach (string file in files) {
            if (!file.EndsWith(".meta")) {
                hasFile = true;
                break;
            }
        }

        // 包含文件，设置AssetBundle名，格式为以"assets/"开头，以"_module"结尾的小写路径名
        if (hasFile) {
            nameDict.Add(path, HotfixUtil.NormalizePath(path).ToLower() + "_module");

            // 是否单独打包
            if (config.InSingleBuildList(path)) {
                foreach (string file in files) {
                    if (file.EndsWith(".meta")) {
                        continue;
                    }
                    nameDict.Add(file, HotfixUtil.NormalizePath(file).ToLower());
                }
            }
        }

        // 递归子目录
        string[] dirs = Directory.GetDirectories(path);
        foreach (string dir in dirs) {
            SetDirAssetBundleName(dir, nameDict, config);
        }
    }

    // 递归清空目里的AssetBundle名
    public static void ClearDirAssetBundleName(string path, HotfixConfig config) {
        AssetImporter import = AssetImporter.GetAtPath(path);
        import.assetBundleName = null;

        // 是否单独打包
        if (config.InSingleBuildList(path)) {
            string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string file in files) {
                if (file.EndsWith(".meta")) {
                    continue;
                }
                AssetImporter fileImport = AssetImporter.GetAtPath(file);
                fileImport.assetBundleName = null;
            }
        }

        // 递归子目录
        string[] dirs = Directory.GetDirectories(path);
        foreach (string dir in dirs) {
            ClearDirAssetBundleName(dir, config);
        }
    }

    // 加载指定版本目录的Hash列表hash.json
    public static HotfixHashList LoadHashList(HotfixPackageContext context, string version) {
        if (version == null) {
            return null;
        }
        string versionPath = context.GetVersionPath(version);
        string filePath = File.ReadAllText(versionPath + "/hash.json", Encoding.UTF8);
        return JsonUtil.ParseJsonObject<HotfixHashList>(filePath);
    }

    // 加载指定目录的变更列表list.json
    public static HotfixList LoadChangeList(HotfixPackageContext context, string version) {
        if (version == null) {
            return null;
        }
        string versionPath = context.GetVersionPath(version);
        if (!File.Exists(versionPath + "/list.json")) {
            return null;
        }
        string text = File.ReadAllText(versionPath + "/list.json", Encoding.UTF8);
        return JsonUtil.ParseJsonObject<HotfixList>(text);
    }

    // 生成hash清单 hash.json
    public static HotfixHashList CreateBundleHashList(string version, string assetBundleRoot, HotfixConfig config) {
        HotfixHashList hashList = new HotfixHashList();
        hashList.version = version;

        string[] files = Directory.GetFiles(assetBundleRoot, "*.manifest", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++) {
            string file = files[i];
            string hash = HotfixUtil.GetManifestHash(file);

            if (hash != null) {
                string bundleName = HotfixUtil.BundleFilePathToBundleName(assetBundleRoot, file);
                hashList.AddHash(bundleName, hash);
            }
            else if (file.EndsWith("assetbundle.manifest")) {
                // 主索引没有hash，可以直接用md5
                string bundleName = HotfixUtil.BundleFilePathToBundleName(assetBundleRoot, file);
                hashList.AddHash(bundleName, CommonUtil.GetMD5FromFile(file));
            }
            else {
                Debug.LogErrorFormat("Manifest hash not found: ", file);
            }
        }

        foreach (DefaultAsset asset in config.singleBuildList) {
            string path = AssetDatabase.GetAssetPath(asset);
            hashList.AddSingleBundle(path.ToLower());
        }

        return hashList;
    }

    // 复制目录中的文件，包含目录本身
    public static void CopyDirFiles(string sourceDir, string destDir, params string[] excludeNames) {
        string[] files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
        int count = files.Length;

        for (int i = 0; i < count; i++) {
            string file = files[i];

            bool exclude = false;
            foreach (string excludeName in excludeNames) {
                if (file.EndsWith(excludeName)) {
                    exclude = true;
                    break;
                }
            }
            if (exclude) {
                continue;
            }

            string name = file.Substring(sourceDir.Length);
            string dest = destDir + name;
            EditorUtility.DisplayProgressBar(TITLE_COPY, name, (float)i / count);

            HotfixUtil.PrepareDir(Path.GetDirectoryName(dest));
            File.Copy(file, dest);
        }

        EditorUtility.ClearProgressBar();
    }

    public static void CopyFile(string srcFile, string destFile) {
        HotfixUtil.PrepareDir(Path.GetDirectoryName(destFile));
        File.Copy(srcFile, destFile);
    }

    // 对比两个list.json的不同
    public static string CompareListJson(HotfixList list1, HotfixList list2) {
        if (list1 == null || list2 == null) {
            return "";
        }

        StringBuilder buff = new StringBuilder();
        long totalSize = 0;

        foreach (KeyValuePair<string, HotfixList.File> pair in list2.list) {
            HotfixList.File file2 = pair.Value;
            HotfixList.File file1 = list1.GetFile(pair.Key);

            if (file1 == null) {
                buff.Append("New file: " + pair.Key).Append("\r\n");
                totalSize += file2.size;
            }
            else {
                if (file2.version != file1.version) {
                    buff.AppendFormat("Version change, {0}->{1}: {2}", file1.version, file2.version, pair.Key).Append("\r\n");
                    totalSize += file2.size;
                }
            }
        }

        string versions = list1.version + "->" + list2.version + "\r\n";
        string sizeDesc = string.Format("变更总大小：{0}\r\n", CommonUtil.GetFileSize(totalSize));

        return versions + sizeDesc + buff.ToString();
    }

    // 加密目录中的文件
    public static void EncryptDir(string rootDir) {
        EditorUtility.DisplayProgressBar("加密", rootDir, 0);

        string[] files = Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories);
        int count = files.Length;

        for (int i = 0; i < count; i++) {
            string file = files[i];
            if (file.EndsWith(".meta")) {
                continue;
            }
            EditorUtility.DisplayProgressBar("加密", file, (float)i / count);

            byte[] bytes = File.ReadAllBytes(file);
            try {
                bytes = TEAHelper.Encrypt(bytes, GameUtil.EncryptKeyBytes);
                File.WriteAllBytes(file, bytes);
            }
            catch (System.Exception e) {
                EditorUtility.ClearProgressBar();
                throw e;
            }
        }
        EditorUtility.ClearProgressBar();
    }

    public static void CreateEncryptMark(string rootDir) {
        File.WriteAllText(rootDir + "/encrypt.txt", "encrypt");
    }

    public static void RemoveEncryptMark(string rootDir) {
        if (File.Exists(rootDir + "/encrypt.txt")) {
            File.Delete(rootDir + "/encrypt.txt");
        }
    }

    // 解密目录中的文件
    public static void DecryptDir(string rootDir) {
        EditorUtility.DisplayProgressBar("解密", rootDir, 0);

        string[] files = Directory.GetFiles(rootDir, "*", SearchOption.AllDirectories);
        int count = files.Length;

        for (int i = 0; i < count; i++) {
            string file = files[i];
            if (file.EndsWith(".meta")) {
                continue;
            }
            EditorUtility.DisplayProgressBar("解密", file, (float)i / count);

            byte[] bytes = File.ReadAllBytes(file);
            try {
                bytes = TEAHelper.Decrypt(bytes, GameUtil.EncryptKeyBytes);
                File.WriteAllBytes(file, bytes);
            }
            catch (System.Exception e) {
                EditorUtility.ClearProgressBar();
                throw e;
            }
        }

        EditorUtility.ClearProgressBar();
    }

    public static void CopyAssetbundleToProject(BuildTarget target) {
        BetterStreamingAssets.Initialize();
        HotfixPackageContext context = new HotfixPackageContext(target, null);

        string packagePath = context.GetPackagePath(context.Version);
        if (!Directory.Exists(packagePath)) {
            throw new System.IO.DirectoryNotFoundException(string.Format("'{0}' not found", packagePath));
        }

        string[] dirs = Directory.GetDirectories(packagePath, "*", SearchOption.TopDirectoryOnly);
        for(int i = 0; i < dirs.Length; i++) {
            string dir = dirs[i];
            string outputPath = Application.streamingAssetsPath + Path.DirectorySeparatorChar + Path.GetFileName(dir);

            if (Directory.Exists(outputPath)) {
                EditorUtility.DisplayProgressBar("删除已存在文件夹", Path.GetFileName(dir), (float)i / dirs.Length);
                Directory.Delete(outputPath, true);
            }
            EditorUtility.DisplayProgressBar("拷贝文件夹", Path.GetFileName(dir), (float)i / dirs.Length);
            FileUtil.CopyFileOrDirectory(dir, outputPath);
        }

        string[] files = Directory.GetFiles(packagePath, "*", SearchOption.TopDirectoryOnly);
        for (int i = 0; i < files.Length; i++) {
            string file = files[i];
            EditorUtility.DisplayProgressBar("拷贝文件", Path.GetFileName(file), (float)i / files.Length);

            string outputPath = Application.streamingAssetsPath + Path.DirectorySeparatorChar + Path.GetFileName(file);

            if (File.Exists(outputPath)) {
                File.Delete(outputPath);
            }
            FileUtil.CopyFileOrDirectory(file, outputPath);
        }

        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 同步2个list.json里的version字段
    /// </summary>
    public static void SyncListVersion(HotfixList srcList, HotfixList destList) {
        foreach(KeyValuePair<string, HotfixList.File> pair in srcList.list) {
            HotfixList.File destFile;
            if (destList.list.TryGetValue(pair.Key, out destFile)) {
                destFile.version = pair.Value.version;
            }
        }
    }

}
