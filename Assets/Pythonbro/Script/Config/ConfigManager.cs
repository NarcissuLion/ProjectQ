using UnityEngine;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

public static class ConfigManager {

    public static string ConfigPath = "Config/";
    public static string SysConfigPath = "SysConfig/";
    public static string TextConfigPath = "Config/text.txt";
    public static string Region = "CN";
    public static int ButtonInterval = 300;

    private static Dictionary<string, JObject> configs = new Dictionary<string, JObject>(); // 配置缓存
    private static Dictionary<string, bool> loadResult = new Dictionary<string, bool>();    // 加载缓存结果，避免加载失败的会一直尝试加载
    private static TextConfig textConfig = null;    // 文本配置

    public static void Init() {
        JObject gameConfig = LoadSysConfig("game.json");
        if (gameConfig == null) {
            Debug.LogError("game.json load error");
            return;
        }
        Region = JsonUtil.GetString(gameConfig, "region");
        ButtonInterval = JsonUtil.GetInt(gameConfig, "button_interval");
    }

    public static JObject GetConfig(string name) {
        return GetConfig(ConfigPath, name);
    }

    public static JObject GetSysConfig(string name) {
        return GetConfig(SysConfigPath, name);
    }

    private static JObject GetConfig(string root, string name) {
        bool loaded = loadResult.ContainsKey(name);
        if (loaded) {
            //bool loadSuccess = GetLoadResult(loadResult, name);
            JObject config;
            if (configs.TryGetValue(name, out config)) {
                return config;
            }
        }
        return LoadConfig(root, name);
    }

    public static JObject LoadConfig(string name) {
        return LoadConfig(ConfigPath, name);
    }

    public static JObject LoadSysConfig(string name) {
        return LoadConfig(SysConfigPath, name);
    }

    private static JObject LoadConfig(string root, string name) {
        string text = GameUtil.LoadDecryptText(root + name);
        if (text != null) {
            JObject config = null;
            try {
                config = JObject.Parse(text);
            }
            catch (System.Exception e) {
                Debug.LogErrorFormat("Invalid json format: {0}\n{1}", text, e);
            }

            if (config != null) {
                configs.Add(name, config);
                loadResult.Add(name, true);
                return config;
            }
        }
        Debug.LogErrorFormat("Load config fail, root: {0}, name: {1}", root, name);
        loadResult.Add(name, false);
        return null;
    }

    public static TextConfig GetTextConfig() {
        if (textConfig == null) {
            LoadTextConfig(TextConfigPath);
        }
        return textConfig;
    }

    public static void LoadTextConfig(string path) {
        if (textConfig == null) {
            textConfig = new TextConfig();
        }
        else {
            textConfig.Clear();
        }
        textConfig.Load(path);
    }

    public static void Clear() {
        configs.Clear();
        loadResult.Clear();
        if (textConfig != null) {
            textConfig.Clear();
            textConfig = null;
        }
    }

    public static JObject LoadBuiltinSysConfig(string fileName) {
        string path = SysConfigPath + fileName;

        byte[] bytes = ResourcesLoader.LoadBytesFromStreamingAssets(path);
        if (bytes != null) {
            if (GameUtil.StreamingEncrypted) {
                try {
                    bytes = TEAHelper.Decrypt(bytes, GameUtil.EncryptKeyBytes);
                }
                catch (System.Exception e) {
                    Debug.LogErrorFormat("内容没有被加密，无法解密: {0}\n{1}", path, e);
                }
            }
            string text = Encoding.UTF8.GetString(bytes);
            try {
                return JsonUtil.ParseJsonObject(text);
            }
            catch (System.Exception e) {
                Debug.LogErrorFormat("Invalid json format: {0}\n{1}", text, e);
            }
        }
        return null;
    }

    private static bool GetLoadResult(Dictionary<string, bool> loadResult, string name) {
        bool result = false;
        loadResult.TryGetValue(name, out result);
        return result;
    }

}
