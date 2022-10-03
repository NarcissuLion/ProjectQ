using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json.Linq;

/// <summary>
/// 热更新打包上下文
/// </summary>
public class HotfixPackageContext {

    public BuildTarget BuildTarget { get; private set; }    // 目标平台
    public string BuildPath { get; private set; }           // 编译AssetBundle路径
    public string OutputPath { get; private set; }          // 打包输出路径
    public string Version { get; private set; }         // 当前版本
    public string PreVersion { get; private set; }      // 上一个版本

    // preVersion 手动指定要比较的前一版本，为null则自动指定
    public HotfixPackageContext(BuildTarget buildTarget, string preVersion) {
        BuildTarget = buildTarget;

        string region = "CN";
        string projectPath = HotfixUtil.NormalizePath(new DirectoryInfo(Application.dataPath).Parent.FullName);

        BuildPath = string.Format("{0}/AssetBundles/{1}/assetbundle", projectPath, buildTarget);
        OutputPath = string.Format("{0}/AssetBundles/{1}/{2}", projectPath, buildTarget, region);

        // 得到当前资源版本号
        Version = GetCurVersion();
        if(Version == null) {
            throw new System.Exception("Cur version not found");
        }

        // 验证preVersion是否存在
        if (preVersion != null) {
            string preVersionPath = GetVersionPath(preVersion);
            if (Directory.Exists(preVersionPath)) {
                PreVersion = preVersion;
            }
            else {
                PreVersion = FindPreVersion();
                Debug.LogErrorFormat("PreVersion '{0}' not found.", preVersion);
            }
        } else {
            PreVersion = FindPreVersion();
        }

        Debug.LogFormat("Output path: {0}", OutputPath);
        Debug.LogFormat("CurVersion: {0}, PreVersion: {1}", Version, PreVersion);
    }

    private string GetCurVersion() {
        //byte[] bytes = File.ReadAllBytes(Application.streamingAssetsPath + "/SysConfig/version.json");
        //bytes = GameUtil.DecryptBytes(bytes);
        //string text = Encoding.UTF8.GetString(bytes);
        //JObject json = JsonUtil.ParseJsonObject(text);

        JObject json = ConfigManager.LoadBuiltinSysConfig("version.json");

        return JsonUtil.GetString(json, "res");
    }

    // 找到和当前版本不同的最大的一个版本
    private string FindPreVersion() {
        string versionRoot = string.Format("{0}/versions", OutputPath);
        if (!Directory.Exists(versionRoot)) {
            return null;
        }
        string[] files = Directory.GetDirectories(versionRoot);
        if(files.Length == 0) {
            return null;
        }
        
        System.Array.Sort(files);
        string curVersionName = HotfixUtil.VersionToDirName(Version);

        for (int i = files.Length - 1; i >= 0; i--) {
            string path = files[i];
            if (!path.EndsWith(curVersionName)) {
                string versionName = Path.GetFileName(path);
                return HotfixUtil.DirNameToVersion(versionName);
            }
        }

        return null;
    }

    public string GetVersionPath(string version) {
        return string.Format("{0}/versions/{1}", OutputPath, HotfixUtil.VersionToDirName(version));
    }

    public string GetPackagePath(string version) {
        return string.Format("{0}/package/{1}/{2}", OutputPath, HotfixUtil.VersionToDirName(version), TargetLowerName);
    }

    public string GetPackageRootPath(string version) {
        return string.Format("{0}/package/{1}", OutputPath, HotfixUtil.VersionToDirName(version));
    }

    public string TargetName
    {
        get { return BuildTarget.ToString(); }
    }

    public string TargetLowerName
    {
        get { return BuildTarget.ToString().ToLower(); }
    }

}
