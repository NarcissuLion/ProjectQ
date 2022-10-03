using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using UnityEngine;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;

public static class HotfixUtil {

    public struct DecompressOption {
        public bool needDecompress;
        public bool deleteOld;
        public DecompressOption(bool needDecompress, bool deleteOld) {
            this.needDecompress = needDecompress;
            this.deleteOld = deleteOld;
        }
    }

    public static string PACKAGE_FILE_ZIP = "package.zip";
    public static string PACKAGE_FILE_MAX = "package.max";
    public static string HOTFIX_MARK_FILE = "app_version.txt";
    public static int compressLevel = 0;    // 压缩质量 0 - 9， 0：仅存储，9最高压缩率

    // 得到manifest文件中的hash
    public static string GetManifestHash(string filePath) {
        using (FileStream stream = File.OpenRead(filePath)) {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            bool foundHash = false;
            string line;
            while ((line = reader.ReadLine()) != null) {
                if (!foundHash) {
                    if (line.Trim() == "AssetFileHash:") {
                        foundHash = true;
                    }
                }
                else {
                    if (line.Trim().StartsWith("Hash: ")) {
                        return line.Trim().Substring("Hash: ".Length);
                    }
                }
            }
        }
        return null;
    }

    // AssetBundle文件路径 -> AssetBundle名
    public static string BundleFilePathToBundleName(string assetBundleRoot, string filePath) {
        string path = filePath.Substring(assetBundleRoot.Length);
        path = NormalizePath(path);

        if (path.StartsWith("/")) {
            path = path.Substring(1);
        }
        if (path.EndsWith(".manifest")) {
            path = path.Substring(0, path.Length - ".manifest".Length);
        }
        return path;
    }

    // 文件路径 -> 资源路径
    public static string FilePathToAssetPath(string path) {
        string dataPath = Application.dataPath;
        if (path.StartsWith(dataPath)) {
            return "Assets/" + path.Substring(dataPath.Length);
        }
        else if (path.StartsWith("Assets/")) {
            return path;
        }
        return "Assets/" + path;
    }

    //  资源路径 ->文件路径
    public static string AssetPathToFilePath(string assetPath) {
        string dataPath = Application.dataPath;
        if (assetPath.StartsWith("Assets/")) {
            return dataPath + assetPath.Substring("Assets".Length);
        }
        return Path.Combine(dataPath, assetPath);
    }

    // 标准化路径字符串
    public static string NormalizePath(string path) {
        return path.Replace("\\", "/");
    }

    // 比较两个点分隔版本字符串，返回大于1、等于0、小于-1
    public static string CompareVersion(string a, string b) {
        string[] aa = a.Split('.');
        string[] bb = b.Split('.');

        for (int i = 0; i < Mathf.Max(aa.Length, bb.Length); i++) {
            int va = i < aa.Length ? int.Parse(aa[i]) : 0;
            int vb = i < bb.Length ? int.Parse(bb[i]) : 0;

            if (va != vb) {
                return va.CompareTo(vb).ToString();
            }
        }
        return "0";
    }

    // 1.2.30 -> 001002030
    public static string VersionToDirName(string version) {
        string[] vers = version.Split('.');
        string name = "";
        for (int i = 0; i < vers.Length; i++) {
            name += vers[i].PadLeft(3, '0');
        }
        return name;
    }

    // 001002030 -> 1.2.30
    public static string DirNameToVersion(string versionName) {
        List<int> list = new List<int>();
        for (int i = 0; i < versionName.Length; i += 3) {
            string str = versionName.Substring(i, 3);
            list.Add(int.Parse(str));
        }
        return CommonUtil.Join(list, ".");
    }

    // 准备目录
    public static void PrepareDir(string dir, bool clear = false) {
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
        else if (clear) {
            Directory.Delete(dir, true);
            Directory.CreateDirectory(dir);
        }
    }

    // 准备文件的目录
    public static void PrepareFileDir(string file, bool clear = false) {
        string dir = Path.GetDirectoryName(file);
        PrepareDir(dir, clear);
    }

    // 根据hash比较两个版本的bundle文件是否有变化
    public static bool IsBundleDifferent(string bundleName, HotfixHashList preHashList, HotfixHashList curHashList, HotfixList preChangeList, string md5) {
        if(preHashList == null) {
            return true;
        }

        string preHash = preHashList.GetHash(bundleName);
        string curHash = curHashList.GetHash(bundleName);
        bool hashChanged = !string.Equals(preHash, curHash);

        bool md5Changed = false;
        HotfixList.File preFile = preChangeList.GetFile("assetbundle/" + bundleName);
        if(preFile == null) {
            md5Changed = true;
        }
        else {
            md5Changed = !md5.Equals(preFile.md5);
        }

        if (!md5Changed) {
            return false;   //md5没变，就铁定没变
        }
        if (!hashChanged) {
            return false;   //hash没变，就铁定没变
        }

        return true;
    }

    // 比较两个普通文件是否有变化
    public static bool IsFileDifferent(string name, string md5, HotfixList preList) {
        if(preList == null) {
            return true;
        }
        HotfixList.File file = preList.GetFile(name);
        if(file == null) {
            return true;
        }

        return !string.Equals(md5, file.md5);
    }

    // 根据上一个版本的变更列表，得到当前版本文件的版本号
    public static int GetCurFileVersion(string name, HotfixList preList, bool different) {
        if(preList == null) {
            return 0;
        }
        HotfixList.File file = preList.GetFile(name);
        if (file == null) {
            return 0;
        }

        return different ? file.version + 1 : file.version;
    }

    // 压缩
    public static void CompressZip(string root, string outputFile, bool containsRoot) {
        if (File.Exists(outputFile)) {
            File.Delete(outputFile);
        }

        using (ZipOutputStream stream = new ZipOutputStream(File.Create(outputFile))) {
            stream.SetLevel(compressLevel);

            Compress(root, root, stream, containsRoot);

            stream.Finish();
            stream.Close();
        }
    }

    // 压缩
    private static void Compress(string root, string sourceDir, ZipOutputStream stream, bool containsRoot) {
        string[] fileEntries = Directory.GetFileSystemEntries(sourceDir);

        foreach (string fileEntry in fileEntries) {
            if (Directory.Exists(fileEntry)) {
                Compress(root, fileEntry, stream, containsRoot);  //递归压缩子文件夹
            }
            else {
                using (FileStream fs = File.OpenRead(fileEntry)) {
                    byte[] buffer = new byte[4 * 1024];

                    string rootName = Path.GetFileName(root);
                    string path = null;
                    if (containsRoot) {
                        path = fileEntry.Substring(root.Length - rootName.Length);
                    }
                    else {
                        path = fileEntry.Substring(root.Length + 1);
                    }

                    path = NormalizePath(path);

                    ZipEntry entry = new ZipEntry(path);
                    entry.DateTime = System.DateTime.Now;
                    stream.PutNextEntry(entry);

                    int sourceBytes;
                    do {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        stream.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
            }
        }
    }

    /// <summary>
    /// 得到zip文件中的文件数量
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="fileLevel">从第几层开始计算，默认从1开始</param>
    /// <returns></returns>
    public static int GetZipFileCount(string filePath, int fileLevel = 1) {
        int count = 0;
        using (ZipFile zip = new ZipFile(filePath)) {
            foreach (ZipEntry entry in zip) {
                if (entry.IsFile) {
                    string[] paths = entry.Name.Split(new char[] { '/', '\\' }, fileLevel, System.StringSplitOptions.RemoveEmptyEntries);
                    if (paths.Length == fileLevel) {
                        count += 1;
                    }
                }
            }
        }
        return count;
    }

    /// <summary>
    /// 得到zip文件流中的文件数量
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileLevel">从第几层开始计算，默认从1开始</param>
    /// <returns></returns>
    public static int GetZipStreamFileCount(Stream stream, int fileLevel = 1) {
        int count = 0;
        using (ZipFile zip = new ZipFile(stream)) {
            foreach (ZipEntry entry in zip) {
                if (entry.IsFile) {
                    string[] paths = entry.Name.Split(new char[] { '/', '\\' }, fileLevel, System.StringSplitOptions.RemoveEmptyEntries);
                    if(paths.Length == fileLevel) {
                        count += 1;
                    }
                }
            }
        }
        return count;
    }

    // Max压缩
    public static void CompressMax(string root, string outputFile, bool containsRoot) {
        if (File.Exists(outputFile)) {
            File.Delete(outputFile);
        }

        int bufferSize = 1024 * 1024 * 4;
        using (FileStream stream = File.Create(outputFile, bufferSize)) {
            stream.Write(new byte[4], 0, 4);
            CompressMaxEntry(root, root, stream, containsRoot);
        }

        long totalLength = new FileInfo(outputFile).Length;
        Debug.Log("Total length: " + totalLength);
        using (FileStream stream = File.Open(outputFile, FileMode.Open, FileAccess.Write, FileShare.None)) {
            byte[] totalBytes = LengthToBytes((int)totalLength);
            stream.Write(totalBytes, 0, 4);
        }

        Debug.Log("Done");
    }

    private static void CompressMaxEntry(string root, string entry, FileStream stream, bool containsRoot) {
        string[] fileEntries = Directory.GetFileSystemEntries(entry);

        foreach (string fileEntry in fileEntries) {
            if (Directory.Exists(fileEntry)) {
                CompressMaxEntry(root, fileEntry, stream, containsRoot);  //递归压缩子文件夹
            }
            else {
                string rootName = Path.GetFileName(root);
                string path = null;
                if (containsRoot) {
                    path = fileEntry.Substring(root.Length - rootName.Length);
                }
                else {
                    path = fileEntry.Substring(root.Length + 1);
                }
                path = path.Replace("\\", "/");

                byte[] pathBytes = Encoding.UTF8.GetBytes(path);

                int pathLength = pathBytes.Length;
                long fileLength = new FileInfo(fileEntry).Length;

                byte[] pathLengthBytes = LengthToBytes(pathLength);
                byte[] fileLengthBytes = LengthToBytes((int)fileLength);

                stream.Write(pathLengthBytes, 0, pathLengthBytes.Length);
                stream.Write(fileLengthBytes, 0, fileLengthBytes.Length);
                stream.Write(pathBytes, 0, pathBytes.Length);

                using (FileStream fs = File.OpenRead(fileEntry)) {
                    byte[] buffer = new byte[1024 * 4];
                    int sourceBytes;
                    do {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        stream.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
            }
        }
        stream.Flush();
    }

    public static void DecompressMax(string srcPath, string outputPath, int bufferSize, int fileLevel, System.Action<long> onStart, System.Action<long> onProgress) {
        using (FileStream srcStream = File.OpenRead(srcPath)) {
            DecompressMax(srcStream, outputPath, bufferSize, fileLevel, onStart, onProgress);
        }
    }

    public static void DecompressMax(Stream srcStream, string outputPath, int bufferSize, int fileLevel, System.Action<long> onStart, System.Action<long> onProgress) {
        byte[] buffer = new byte[bufferSize];
        int length = 0;
        char[] splitChars = new char[] { '/', '\\' };

        length = srcStream.Read(buffer, 0, 4);
        if (length <= 0) {
            return;
        }
        long totalSize = BytesToLength(buffer);
        Debug.Log("Total size: " + totalSize);

        Invoke(onStart, totalSize);
        Invoke(onProgress, length);

        while (true) {
            length = srcStream.Read(buffer, 0, 4);
            if(length <= 0) {
                break;
            }
            Invoke(onProgress, length);
            int pathLength = (int)BytesToLength(buffer);

            length = srcStream.Read(buffer, 0, 4);
            Invoke(onProgress, length);
            if (length <= 0) {
                break;
            }
            long fileLength = BytesToLength(buffer);

            length = srcStream.Read(buffer, 0, pathLength);
            Invoke(onProgress, length);
            if (length <= 0) {
                break;
            }
            string path = Encoding.UTF8.GetString(buffer, 0, pathLength);

            string[] paths = path.Split(splitChars, fileLevel, System.StringSplitOptions.RemoveEmptyEntries);
            if (paths.Length < fileLevel) {
                srcStream.Position += fileLength;
                continue;
            }
            path = Path.Combine(outputPath, paths[fileLevel - 1]);

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists) {
                fileInfo.Directory.Create();
            }

            using (FileStream outStream = File.OpenWrite(fileInfo.FullName)) {
                while (fileLength > 0) {
                    int readLength = (int)Min(buffer.Length, fileLength);
                    length = srcStream.Read(buffer, 0, readLength);
                    Invoke(onProgress, length);
                    if (length <= 0) {
                        return;
                    }
                    fileLength -= readLength;

                    outStream.Write(buffer, 0, readLength);
                }
            }
        }
    }

    public static void Invoke<T>(System.Action<T> action, T t) {
        if(action != null) {
            action.Invoke(t);
        }
    }

    public static long Min(long a, long b) {
        return a > b ? b : a;
    }

    public static int BytesToLength(byte[] b) {
        return b[3] & 0xFF |
            (b[2] & 0xFF) << 8 |
            (b[1] & 0xFF) << 16 |
            (b[0] & 0xFF) << 24;
    }

    public static byte[] LengthToBytes(int a) {
        return new byte[] {
            (byte) ((a >> 24) & 0xFF),
            (byte) ((a >> 16) & 0xFF),
            (byte) ((a >> 8) & 0xFF),
            (byte) (a & 0xFF)
        };
    }

    // 得到备份名
    public static string GetBackupName() {
        string path = GetBackupPath();
        return path == null ? null : Path.GetFileName(path);
    }

    // 得到备份路径
    public static string GetBackupPath() {
        string backDir = Path.Combine(Application.persistentDataPath, "update_backup");
        if (!Directory.Exists(backDir)) {
            return null;
        }

        string[] dirs = Directory.GetDirectories(backDir);
        if (dirs.Length == 0) {
            return null;
        }

        return dirs[0];
    }

    // 备份当前热更
    public static string BackupCurHotfix() {
        string curHotfix = Path.Combine(Application.persistentDataPath, "update");
        if (!Directory.Exists(curHotfix)) {
            return "No Hotfix";
        }

        try {
            string backDir = Path.Combine(Application.persistentDataPath, "update_backup");
            if (Directory.Exists(backDir)) {
                Directory.Delete(backDir, true);
            }
            Directory.CreateDirectory(backDir);

            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string backRoot = Path.Combine(backDir, "backup_" + timestamp);

            Copy(curHotfix, backRoot);

            return null;
        }
        catch (System.Exception e) {
            Debug.LogException(e);
            return e.ToString();
        }
    }

    // 复制目录
    private static void Copy(string srcRoot, string destRoot) {
        string[] files = Directory.GetFiles(srcRoot, "*", SearchOption.AllDirectories);
        int total = files.Length;
        for (int i = 0; i < total; i++) {
            string src = files[i];
            string dest = destRoot + src.Substring(srcRoot.Length);

            string destDir = Path.GetDirectoryName(dest);

            if (!Directory.Exists(destDir)) {
                Directory.CreateDirectory(destDir);
            }
            File.Copy(src, dest);
        }
    }

    // 还原热更新备份
    public static string RevertHotfixBackup() {
        string backRoot = GetBackupPath();
        if (backRoot == null || !Directory.Exists(backRoot)) {
            return "No Backup";
        }

        try {
            string curHotfix = Path.Combine(Application.persistentDataPath, "update");
            if (Directory.Exists(curHotfix)) {
                Directory.Delete(curHotfix, true);
            }
            Directory.CreateDirectory(curHotfix);

            Copy(backRoot, curHotfix);

            return null;
        }
        catch (System.Exception e) {
            Debug.LogException(e);
            return e.ToString();
        }
    }

    public static void DeleteHotfix() {
        if (Directory.Exists(Application.persistentDataPath + "/update")) {
            Directory.Delete(Application.persistentDataPath + "/update", true);
        }
        if(File.Exists(Application.persistentDataPath + "/svn.txt")) {
            File.Delete(Application.persistentDataPath + "/svn.txt");
        }
    }

    // Lua端调用重新进入游戏
    public static void ReloadGameFromLua() {
        CoroutineHelper.Instance.WaitForEndOfFrame(() => {
            ReloadGame();
        });
    }

    // 重新进入游戏
    public static void ReloadGame() {
        // 用主摄像机遮黑屏幕，防闪
        Camera.main.depth = 100;

        // 卸载Lua、AssetBundle、配置缓存
        GameUtil.UnloadGame();

        //GameUtil.LoadSceneByName("Login");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    /// <summary>
    /// 是否需要解压缩热更资源
    /// </summary>
    /// <returns></returns>
    public static DecompressOption NeedDecompressResource() {
        // 安装包内是否存在资源包
        bool existsZip = ResourcesLoader.ExistsFromStreamingAssets(PACKAGE_FILE_ZIP);
        bool existsMax = ResourcesLoader.ExistsFromStreamingAssets(PACKAGE_FILE_MAX);

        // 热更目录是否已存在完整解压的资源
        string hotfixMarkFile = "update/" + HOTFIX_MARK_FILE;
        bool existsHotfix = ResourcesLoader.ExistsFromPersistentData(hotfixMarkFile);
        bool sameVersion = false;

        if (existsHotfix) {
            // 得到安装包资源版本
            JObject packageConfig = ConfigManager.LoadBuiltinSysConfig("version.json");
            string packageApp = JsonUtil.GetString(packageConfig, "app");

            // 得到热更目录资源版本
            string version = ResourcesLoader.LoadTextFromPersistentData(hotfixMarkFile);
            if (version != null) {
                sameVersion = packageApp == version.Trim();
            }
            Debug.LogFormat("Hotfix exists: {0}, package.zip: {1}, package.max: {2}, package ver: {3}, hotfix ver: {4}", existsHotfix, existsZip, existsMax, packageApp, version);
        }
        else {
            Debug.LogFormat("Hotfix exists: {0}, package.zip: {1}, package.max: {2}", existsHotfix, existsZip, existsMax);
        }

        string appSvn = ResourcesLoader.LoadTextFromStreamingAssets("svn.txt");
        string resSvn = ResourcesLoader.LoadTextFromPersistentData("svn.txt");

        // 没有资源包，不解压缩
        if (!existsZip && !existsMax) {
            return new DecompressOption(false, false);
        }
        // 没有资源，解压缩
        if (!existsHotfix) {
            if (CommonUtil.IsIOS()) {
                return new DecompressOption(false, false);  //IOS资源在包内
            }
            else {
                return new DecompressOption(true, false);
            }
        }
        // 资源包svn版本与app的svn版本不同，删除旧的，再解压缩
        if(appSvn != resSvn) {
            Debug.LogFormat("App svn:{0}, res svn:{1}", appSvn, resSvn);
            if (CommonUtil.IsIOS()) {
                return new DecompressOption(false, true); //IOS资源在包内，直接删旧的
            }
            else {
                return new DecompressOption(true, true);
            }
        }
        // 已经有相同版本资源，不解压缩
        if(sameVersion) {
            return new DecompressOption(false, false);
        }
        // 有不同版本资源，删了旧版，然后解压缩
        if (CommonUtil.IsIOS()) {
            return new DecompressOption(false, true); //IOS资源在包内，直接删旧的
        }
        else {
            return new DecompressOption(true, true);
        }
    }

    // 创建一个标记完整解压热更资源的标记文件
    public static void CreateCompleteHotfixMarkFile(string dir) {
        string hotfixMarkFile = Path.Combine(dir, HOTFIX_MARK_FILE);
        // 得到安装包资源版本
        JObject packageConfig = ConfigManager.LoadBuiltinSysConfig("version.json");
        string packageRes = JsonUtil.GetString(packageConfig, "app");

        File.WriteAllText(hotfixMarkFile, packageRes, Encoding.UTF8);
    }

}
