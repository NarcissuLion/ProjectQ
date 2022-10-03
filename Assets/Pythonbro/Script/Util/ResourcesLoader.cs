using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// 资源加载工具类
/// </summary>
public static class ResourcesLoader  {

    public const string ANDROID_STREAMIMG_PROTOCAL = @"jar:file://"; //Android下StreamingAssetPath需添加的协议

    public static string realStreamingAssetsPath
    {
        get {
            if(Application.platform == RuntimePlatform.Android) {
                return ANDROID_STREAMIMG_PROTOCAL + Application.dataPath + "!/assets";
            }
            return Application.streamingAssetsPath;
        }
    }

    public static bool ExistsFromStreamingAssets(string path) {
        //string fullPath = realStreamingAssetsPath + "/" + path;
        //return Exists(fullPath);
        return BetterStreamingAssets.FileExists(path);
    }

    public static bool ExistsFromPersistentData(string path) {
        string fullPath = Application.persistentDataPath + "/" + path;
        //return Exists(fullPath);
        return File.Exists(fullPath);
    }

    public static byte[] LoadBytesFromStreamingAssets(string path) {
        //string fullPath = realStreamingAssetsPath + "/" + path;
        //return LoadBytes(fullPath);
        return BetterStreamingAssets.FileExists(path) ? BetterStreamingAssets.ReadAllBytes(path) : null;
    }

    public static byte[] LoadBytesFromPersistentData(string path) {
        string fullPath = Application.persistentDataPath + "/" + path;
        //return LoadBytes(fullPath);
        return File.Exists(fullPath) ? File.ReadAllBytes(fullPath) : null;
    }

    public static byte[] LoadBytesFromResource(string path) {
        if (path.Contains(".")) {
            path = path.Substring(0, path.LastIndexOf("."));
        }
        TextAsset asset = Resources.Load<TextAsset>(path);
        if (asset != null) {
            return asset.bytes;
        }
        return null;
    }

    public static string LoadTextFromStreamingAssets(string path) {
        //string fullPath = Path.Combine(realStreamingAssetsPath, path);
        //return LoadText(fullPath);
        return BetterStreamingAssets.FileExists(path) ? BetterStreamingAssets.ReadAllText(path) : null;
    }

    public static string LoadTextFromPersistentData(string path) {
        string fullPath = Path.Combine(Application.persistentDataPath, path);
        //return LoadText(fullPath);
        return File.Exists(fullPath) ? File.ReadAllText(fullPath, Encoding.UTF8) : null;
    }

    public static string LoadTextFromResource(string path) {
        if (path.Contains(".")) {
            path = path.Substring(0, path.LastIndexOf("."));
        }
        TextAsset asset = Resources.Load<TextAsset>(path);
        if(asset != null) {
            return asset.text;
        }
        return null;
    }

    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static byte[] LoadBytes(string path) {
        byte[] bytes = null;
        if (path.StartsWith(ANDROID_STREAMIMG_PROTOCAL)) {
#if UNITY_2017 || UNITY_2018
            UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(path);
            AsyncOperation async = request.SendWebRequest();
            while (!async.isDone) {
                continue;
            }
            if (request.isHttpError || request.isNetworkError) {
                Debug.Log(request.error);
            }
            else {
                bytes = request.downloadHandler.data;
            }
#else
            WWW www = new WWW(path);
            while (!www.isDone) {
                continue;
            }
            if (www.error != null) {
                Debug.Log(www.error);
            }
            else {
                bytes = www.bytes;
            }
            www.Dispose();
#endif
        }
        else {
            if (File.Exists(path)) {
                bytes = File.ReadAllBytes(path);
            }
        }
        return bytes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static string LoadText(string path) {
        string text = null;
        if (path.StartsWith(ANDROID_STREAMIMG_PROTOCAL)) {
#if UNITY_2017 || UNITY_2018
            UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(path);
            AsyncOperation async = request.SendWebRequest();
            while (!async.isDone) {
                continue;
            }
            if (request.isHttpError || request.isNetworkError) {
                Debug.Log(request.error);
            }
            else {
                text = request.downloadHandler.text;
            }
#else
            WWW www = new WWW(path);
            while (!www.isDone) {
                continue;
            }
            if (www.error != null) {
                Debug.Log(www.error);
            }
            else {
                text = www.text;
            }
            www.Dispose();
#endif
        }
        else {
            if (File.Exists(path)) {
                text = File.ReadAllText(path, Encoding.UTF8);
            }
        }
        return CommonUtil.Trim(text);
    }

    private static bool Exists(string path) {
        if (path.StartsWith(ANDROID_STREAMIMG_PROTOCAL)) {
#if UNITY_2017 || UNITY_2018
            UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(path);
            AsyncOperation async = request.SendWebRequest();
            while (!async.isDone) {
                continue;
            }
            if (request.isHttpError || request.isNetworkError) {
                request.Dispose();
                return false;
            }
            request.Dispose();
            return true;
#else
            WWW www = new WWW(path);
            while (!www.isDone) {
                continue;
            }
            if (string.IsNullOrEmpty(www.error)) {
                www.Dispose();
                return true;
            }
            else {
                www.Dispose();
                return false;
            }
#endif
        }
        else {
            return File.Exists(path);
        }
    }
    */

}
