using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.Video;

/// <summary>
/// 和游戏逻辑有关的工具类
/// </summary>
public static class GameUtil {

    public delegate void OnLoadResource(Object res);
    public delegate void OnLoadScene(GameObject root);
    public delegate void OnLoadText(string content);

    public static string EncryptKey = "Pythonbro";
    public static byte[] EncryptKeyBytes = Encoding.UTF8.GetBytes(EncryptKey);
    public static bool PersistantEncrypted = false;
    public static bool StreamingEncrypted = false;

    // 特殊字符正则表达式
    public static string RegexNonWordPattern = @"[A-Za-z0-9~!@#\$%\^&\*\(\)\+=\|\\\}\]\{\[:;<,>\?\/""]+";
    public static string RegexSpecialPattern = @"[~!@#\$%\^&\*\(\)\+=\|\\\}\]\{\[:;<,>\?\/""]+";
    private static Regex RegexNonWord = new Regex(RegexNonWordPattern, RegexOptions.Multiline);
    private static Regex RegexSpecial = new Regex(RegexSpecialPattern);

    public static void ReloadRegexPatterns() {
        RegexNonWord = new Regex(RegexNonWordPattern, RegexOptions.Multiline);
        RegexSpecial = new Regex(RegexSpecialPattern);
    }

    public static void SetEncryptKey(string key) {
        EncryptKey = key;
        EncryptKeyBytes = Encoding.UTF8.GetBytes(EncryptKey);
    }

    public static void CheckEncryptState() {
        PersistantEncrypted = ResourcesLoader.ExistsFromPersistentData("update/encrypt.txt");
        StreamingEncrypted = ResourcesLoader.ExistsFromStreamingAssets("encrypt.txt");
        Debug.LogFormat("PersistantEncrypted: {0}, StreamingEncrypted: {1}", PersistantEncrypted, StreamingEncrypted);
    }

    // 实例化一个预设，创建在当前的Login/Main场景中，无论场景是否active
    public static GameObject CreatePrefab(string path) {
        SceneHandler handler = SceneHandler.Current;
        if (handler != null) {
            return CreatePrefabToParent(path, handler, null);
        }

        return CreatePrefabInActiveScene(path);
    }

    // 实例化一个预设，创建在当前激活的场景中
    public static GameObject CreatePrefabInActiveScene(string path) {
        GameObject gameObject = HotfixManager.Instance.CreatePrefab(path);
        if (gameObject != null) {
            RemoveCloneSuffix(gameObject);
            return gameObject;
        }
        Debug.LogErrorFormat("Can't load prefab \"{0}\"", path);
        return null;
    }

    // 实例化一个预设，在切换场景时不会被删除，特点是不属于任何一个场景，没有父物体
    public static GameObject CreatePrefabDontDestroyOnLoad(string path) {
        GameObject gameObject = CreatePrefabInActiveScene(path);
        if (gameObject != null) {
            Object.DontDestroyOnLoad(gameObject);
        }
        return gameObject;
    }

    // 实例化一个预设到一个父物体下
    public static GameObject CreatePrefabToParent(string path, Object parent, string parentPath) {
        GameObject gameObject = HotfixManager.Instance.CreatePrefab(path);

        if (gameObject != null) {
            RemoveCloneSuffix(gameObject);
            CommonUtil.SetParentByPath(gameObject, null, parent, parentPath, false);
            return gameObject;
        }

        //GameObject prefab = LoadPrefab(path);
        //if (prefab != null) {
        //    GameObject gameObject = null;
        //    if (parent != null) {
        //        Transform parentTransform = CommonUtil.GetChild(parent, parentPath);
        //        gameObject = Object.Instantiate(prefab, parentTransform, false);
        //    }
        //    else {
        //        gameObject = Object.Instantiate(prefab);
        //    }
        //    RemoveCloneSuffix(gameObject);
        //    return gameObject;
        //}

        Debug.LogErrorFormat("Can't load prefab \"{0}\"", path);
        return null;
    }

    /// <summary>
    /// 异步实例化一个预设到一个父物体下
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <param name="parentPath"></param>
    /// <param name="callback"></param>
    public static void CreatePrefabToParentAsync(string path, Object parent, string parentPath, OnLoadResource callback) {
        CoroutineHelper coroutineHelper = CoroutineHelper.GetInstance(parent);
        coroutineHelper.ExcuteTask(() => {
            GameObject gameObject = CreatePrefabToParent(path, parent, parentPath);

            if (callback != null) {
                callback.Invoke(gameObject);
            }
        });
    }

    /// <summary>
    /// 加载一个预设.
    /// 注意：仅仅加载，并不实例化，返回值是预设体.
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns>预设</returns>
    public static GameObject LoadPrefab(string path) {
        //MainDebug.Instance.BeforeLoadResource(path);

        //GameObject prefab = Resources.Load<GameObject>(path);
        GameObject prefab = HotfixManager.Instance.LoadResource<GameObject>(path);

        //MainDebug.Instance.AfterLoadResource(path);
        return prefab;
    }

    /// <summary>
    /// 加载一个预设.
    /// 注意：仅仅加载，并不实例化，返回值是预设体.
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="callback">预设</param>
    public static void LoadPrefabAsync(string path, OnLoadResource callback) {
        CoroutineHelper.Instance.ExcuteTask(()=> {
            GameObject prefab = HotfixManager.Instance.LoadResource<GameObject>(path);

            if (callback != null) {
                callback.Invoke(prefab);
            }
        });
    }

    /// <summary>
    /// 加载一项资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns>资源对象</returns>
    public static Object LoadResource(string path) {
        //MainDebug.Instance.BeforeLoadResource(path);

        //Object res = Resources.Load(path);
        Object res = HotfixManager.Instance.LoadResource<Object>(path);

        //MainDebug.Instance.AfterLoadResource(path);
        return res;
    }

    /// <summary>
    /// 加载一项指定类型资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="systemTypeName">资源类型全名，例如UnityEngine.Material</param>
    /// <returns>资源对象</returns>
    public static Object LoadResourceByType(string path, string systemTypeName) {
        try {
            System.Type type = CommonUtil.GetTypeByName(systemTypeName);
            if (type != null) {
                //return Resources.Load(path, type);
                return HotfixManager.Instance.LoadResource(path, type);
            }
            else {
                Debug.LogErrorFormat("Invalid resource type, type: {0}", type);
            }
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
        return null;
    }

    // 从热更目录或包内目录读取bytes
    public static byte[] LoadBytes(string path) {
        byte[] bytes = ResourcesLoader.LoadBytesFromPersistentData("update/" + path);
        if (bytes == null) {
            bytes = ResourcesLoader.LoadBytesFromStreamingAssets(path);
        }
        return bytes;
    }

    // 从热更目录或包内目录读取string
    public static string LoadText(string path) {
        string text = ResourcesLoader.LoadTextFromPersistentData("update/" + path);
        if (text == null) {
            text = ResourcesLoader.LoadTextFromStreamingAssets(path);
        }
        return text;
    }

    // 从热更目录或包内目录读取bytes，编辑器下streaming下不解密
    public static byte[] LoadDecryptBytes(string path) {
        // PersistentData
        byte[] bytes = ResourcesLoader.LoadBytesFromPersistentData("update/" + path);
        if(bytes != null) {
            if (PersistantEncrypted) {
                try {
                    bytes = TEAHelper.Decrypt(bytes, EncryptKeyBytes);
                }
                catch (System.Exception e) {
                    Debug.LogException(e);
                    Debug.LogErrorFormat("内容没有被加密，无法解密: {0}", path);
                }
            }
            return bytes;
        }

        // StreamingAssets
        bytes = ResourcesLoader.LoadBytesFromStreamingAssets(path);
        if (StreamingEncrypted) {
            try {
                bytes = TEAHelper.Decrypt(bytes, EncryptKeyBytes);
            }
            catch (System.Exception e) {
                Debug.LogException(e);
                Debug.LogErrorFormat("内容没有被加密，无法解密: {0}", path);
            }
        }
        return bytes;
    }

    // 从热更目录或包内目录读取string，如果是从热更目录读取则自动解密
    public static string LoadDecryptText(string path) {
        byte[] bytes = LoadDecryptBytes(path);
        if(bytes != null) {
            return Encoding.UTF8.GetString(bytes);
        }
        return null;
    }

    public static string LoadDecryptTextAndTrim(string path) {
        string result = LoadDecryptText(path);
        return result != null ? result.Trim() : null;
    }

    public static byte[] EncryptBytes(byte[] bytes) {
        try {
            bytes = TEAHelper.Encrypt(bytes, EncryptKeyBytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
        return bytes;
    }

    public static string EncryptText(string text) {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        try {
            bytes = TEAHelper.Encrypt(bytes, EncryptKeyBytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
        return Encoding.UTF8.GetString(bytes);
    }

    public static string EncryptTextAndTrim(string text) {
        string result = EncryptText(text);
        return result != null ? result.Trim() : null;
    }

    public static byte[] DecryptBytes(byte[] bytes) {
        try {
            bytes = TEAHelper.Decrypt(bytes, EncryptKeyBytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
            Debug.LogError("内容没有被加密，无法解密");
        }
        return bytes;
    }

    public static string DecryptText(string text) {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        try {
            bytes = TEAHelper.Decrypt(bytes, EncryptKeyBytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
            Debug.LogError("内容没有被加密，无法解密");
        }
        return Encoding.UTF8.GetString(bytes);
    }

    public static void EncryptPersistentFile(string path) {
        string filePath = Path.Combine(Application.persistentDataPath, path);
        byte[] bytes = File.ReadAllBytes(filePath);
        try {
            bytes = TEAHelper.Encrypt(bytes, EncryptKeyBytes);
            File.WriteAllBytes(filePath, bytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
    }

    public static void DecryptPersistentFile(string path) {
        string filePath = Path.Combine(Application.persistentDataPath, path);
        byte[] bytes = File.ReadAllBytes(filePath);
        try {
            bytes = TEAHelper.Decrypt(bytes, EncryptKeyBytes);
            File.WriteAllBytes(filePath, bytes);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
    }

    // 从本地存储目录读取文件
    public static string LoadPersistentData(string path) {
        return ResourcesLoader.LoadTextFromPersistentData(path);
    }

    // 向本地存储目录保存文件
    public static void SavePersistentData(string path, string data) {
        string filePath = Path.Combine(Application.persistentDataPath, path);

        FileInfo file = new FileInfo(filePath);
        try {
            if (!file.Directory.Exists) {
                file.Directory.Create();
            }
            File.WriteAllText(filePath, data, Encoding.UTF8);
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
    }


    // 删除本地存储目录文件
    public static void DeletePersistentData(string path) {
        string filePath = Path.Combine(Application.persistentDataPath, path);

        try {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
    }

    // 使用加载界面加载指定名称的场景
    public static void LoadSceneByName(string sceneName) {
        Debug.Log(sceneName);
        //// 使用加载界面
        //LoadingScreen loadingScreen = LoadingScreen.Create(LoadingScreen.PREFAB_PATH);

        //// 加载场景任务
        //JObject loadScene = new JObject();
        //loadScene.Add("type", LoadingScreen.TASK_LOAD_SCENE);
        //loadScene.Add("name", sceneName);
        //loadingScreen.AddTask(loadScene.ToString());

        //// 初始化lua任务
        //JObject initLua = new JObject();
        //initLua.Add("type", LoadingScreen.TASK_INIT_LUA);
        //loadingScreen.AddTask(initLua.ToString());

        //// 开始加载
        //loadingScreen.StartLoading();
    }

    // 格式化json
    public static string GetPrettyJson(string json) {
        return JsonUtil.ToString(JsonUtil.ParseJsonObject(json), true);
    }

    public static string GetOSName() {
        if (Application.isEditor) {
            return "editor";
        }
        else if (Application.platform == RuntimePlatform.Android) {
            return "android";
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer) {
            return "ios";
        }
        else {
            return Application.platform.ToString();
        }
    }

    // 加载图集中的图片
    public static Sprite LoadAtlasSprite(string atlasPath, string name) {
        SpriteAtlas atlas = LoadResource(atlasPath) as SpriteAtlas;
        if (atlas != null) {
            return atlas.GetSprite(name);
        }
        else {
            Debug.LogErrorFormat("Atlas not found: {0}", atlasPath);
        }
        return null;
    }


    // 给摄像机创建一个RenderTexture并返回
    public static RenderTexture SetupCameraRenderTexture(Object parent, string cameraPath) {
        Camera camera = CommonUtil.GetComponent<Camera>(parent, cameraPath);
        if(camera != null) {
            RenderTexture texture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
            camera.targetTexture = texture;
            return texture;
        }
        return null;
    }

    // 创建一个RenderTexture
    public static RenderTexture CreateRenderTexture(int width, int height, int depth) {
        return new RenderTexture(width, height, depth, RenderTextureFormat.ARGB32);
    }

    // 加载预设上的Sprite，并不创建预设实例
    public static Sprite LoadPrefabSprite(string path) {
        GameObject prefab = LoadPrefab(path);
        if (prefab == null) {
            return null;
        }
        Image image = prefab.GetComponent<Image>();
        if (image != null) {
            return image.sprite;
        }
        return null;
    }

    // 加载预设上的Texture，并不创建预设实例
    public static Texture LoadPrefabTexture(string path) {
        GameObject prefab = LoadPrefab(path);
        if (prefab == null) {
            return null;
        }
        RawImage image = prefab.GetComponent<RawImage>();
        if (image != null) {
            return image.texture;
        }
        return null;
    }

    // Material，并不创建预设实例
    public static Material LoadPrefabMaterial(string path) {
        GameObject prefab = LoadPrefab(path);
        if (prefab == null) {
            return null;
        }
        Renderer renderer = prefab.GetComponent<Renderer>();
        if (renderer != null) {
            return renderer.sharedMaterial;
        }
        return null;
    }

    // Material，并不创建预设实例
    public static RuntimeAnimatorController LoadPrefabAnimatorController(string path) {
        GameObject prefab = LoadPrefab(path);
        if (prefab == null) {
            return null;
        }
        Animator animator = prefab.GetComponent<Animator>();
        if (animator != null) {
            return animator.runtimeAnimatorController;
        }
        return null;
    }

    /// <summary>
    /// 设置普通摄像机的属性
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    public static void SetupNormalCamera(Object parent, string path) {
        Camera camera = CommonUtil.GetComponent<Camera>(parent, path);
        if (camera != null) {
            if (camera.tag == "MainCamera") {
                camera.tag = null;
            }
            camera.allowHDR = false;
            camera.allowMSAA = false;
            camera.depth = 0;

            AudioListener audioListener = camera.GetComponent<AudioListener>();
            if (audioListener != null) {
                Object.Destroy(audioListener);
            }

            FlareLayer flareLayer = camera.GetComponent<FlareLayer>();
            if (flareLayer != null) {
                Object.Destroy(flareLayer);
            }
        }
    }

    public static RealtimeTimer AddTimer(Object parent, string path, float seconds, RealtimeTimer.OnComplete callback) {
        GameObject host = CommonUtil.GetGameObject(parent, path);
        if(host == null) {
            return null;
        }

        RealtimeTimer timer = host.AddComponent<RealtimeTimer>();
        timer.onComplete = callback;
        timer.StartTiming(seconds, 0);
        return timer;
    }

    /// <summary>
    /// 得到文本长度，数字、字母和符号长度为1，单个字符长度可指定
    /// ver > 1.1.0
    /// </summary>
    /// <param name="text"></param>
    /// <param name="wordLength"></param>
    /// <returns></returns>
    public static int GetTextLength(string text, int wordLength) {
        int length = 0;
        string words = RegexNonWord.Replace(text, (match) => {
            length += match.Length;
            return string.Empty;
        });
        return length += words.Length * wordLength;
    }

    /// <summary>
    /// 是否有特殊字符
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool HasSpecialCharacters(string text) {
        return text == null ? false : RegexSpecial.Match(text).Success;
    }

    /// <summary>
    /// 移除特殊字符
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string RemoveSpecialCharacters(string text) {
        return text == null ? text : RegexSpecial.Replace(text, string.Empty);
    }

    /// <summary>
    /// 是否包含屏蔽字
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool HasSensitiveWord(string text) {
        return false;
        //return SensitiveWord.HasWords(text);
    }

    /// <summary>
    /// 移除屏蔽字
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string RemoveSensitiveWord(string text) {
        return text;
        //return SensitiveWord.ReplaceWords(text);
    }

    public static string GetUpdatePath(string path) {
        return Path.Combine(Application.persistentDataPath + "/update", path);
    }

    public static void RemoveCloneSuffix(GameObject gameObject) {
        if (gameObject != null && gameObject.name.Contains("(Clone)")) {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
    }

    // 异步加载附加场景，返回第一个根节点
    public static void LoadSceneAdditiveAsync(string name, OnLoadScene onComplete) {
        AssetBundle sceneBundle = HotfixManager.Instance.BeforeLoadScene(name);
        AsyncOperation async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        if (async == null) {    // Error
            if (onComplete != null) {
                onComplete.Invoke(null);
            }
            return;
        }

        async.completed += (_async) => {
            if (onComplete != null) {
                Scene scene = SceneManager.GetSceneByName(name);
                SceneManager.SetActiveScene(scene);
                DynamicGI.UpdateEnvironment();
                HotfixManager.Instance.AfterLoadScene(sceneBundle, scene);

                GameObject[] roots = scene.GetRootGameObjects();
                onComplete.Invoke(roots.Length > 0 ? roots[0] : null);
            }
        };
    }

    // 加载附加场景，返回第一个根节点
    public static GameObject LoadSceneAdditive(string name) {
        AssetBundle sceneBundle = HotfixManager.Instance.BeforeLoadScene(name);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);

        Scene scene = SceneManager.GetSceneByName(name);
        SceneManager.SetActiveScene(scene);
        DynamicGI.UpdateEnvironment();
        HotfixManager.Instance.AfterLoadScene(sceneBundle, scene);

        GameObject[] roots = scene.GetRootGameObjects();
        return roots.Length > 0 ? roots[0] : null;
    }

    // 异步卸载场景
    public static void UnloadScene(string name, UnityAction onComplete) {
        AsyncOperation async = SceneManager.UnloadSceneAsync(name);
        if (async == null) { // Error
            if (onComplete != null) {
                onComplete.Invoke();
            }
            return;
        }

        async.completed += (_async) => {
            if (onComplete != null) {
                onComplete.Invoke();
            }
            // TODO 如果存在Assetbundle则卸载
        };
    }

    // 设置当前激活的scene
    public static bool SetActiveScene(string name) {
        Scene scene = SceneManager.GetSceneByName(name);
        if(scene != null && scene.IsValid()) {
            bool result = SceneManager.SetActiveScene(scene);
            DynamicGI.UpdateEnvironment();
            return result;
        }
        else {
            Debug.LogErrorFormat("Invalid scene: {0}", name);
        }
        return false;
    }

    // 得到当前激活的scene的第N个根GameObject
    public static GameObject GetActiveSceneRoot(int index) {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.rootCount > index) {
            return scene.GetRootGameObjects()[index];
        }
        return null;
    }

    public static Camera GetCanvasCamera(Object parent, string path) {
        Canvas canvas = CommonUtil.LookUpCanvas(parent, path);
        if (canvas != null) {
            bool isScreenOverlay = canvas.renderMode == RenderMode.ScreenSpaceOverlay;
            if (isScreenOverlay) {
                return GameObject.Find("Default UI Camera").GetComponent<Camera>();
            }
            else {
                return canvas.worldCamera;
            }
        }
        return Camera.main;
    }

    public static Vector3 GetUIScreenPosition(Object parent, string path) {
        Transform transform = CommonUtil.GetChild(parent, path);
        if(transform != null) {
            Canvas canvas = CommonUtil.LookUpCanvas(parent, path);
            bool isScreenOverlay = canvas.renderMode == RenderMode.ScreenSpaceOverlay;

            if (isScreenOverlay) {
                return transform.position;
            }
            else {
                Camera camera = GetCanvasCamera(canvas, null);
                return camera.WorldToScreenPoint(transform.position);
            }
        }
        return Vector3.zero;
    }

    public static bool IsDebugBuild() {
        return Debug.isDebugBuild;
    }

    public static bool IsDebugBuildOrEditor() {
        return Debug.isDebugBuild || Application.isEditor;
    }

    public static void PlayVideo(Object parent, string path, string videoPath, UnityAction onFinish) {
        VideoPlayer videoPlayer = CommonUtil.GetComponent<VideoPlayer>(parent, path);
        if (videoPlayer == null) {
            Debug.LogError("VideoPlayer not found");
            return;
        }

        videoPlayer.source = VideoSource.Url;
        videoPlayer.loopPointReached += (player) => {
            if (onFinish != null) {
                onFinish.Invoke();
            }
        };

        if (ResourcesLoader.ExistsFromPersistentData("update/" + videoPath)) {
            videoPlayer.url = Application.persistentDataPath + "/update/" + videoPath;
            videoPlayer.Play();
        }
        else if (ResourcesLoader.ExistsFromStreamingAssets(videoPath)) {
            videoPlayer.url = Application.streamingAssetsPath + "/" + videoPath;
            videoPlayer.Play();
        }
        else {
            Debug.LogErrorFormat("Video not found: {0}", videoPath);
            if (onFinish != null) {
                onFinish.Invoke();
            }
        }
    }

    public static void QuitGame() {
        if (Application.isEditor) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else {
            Application.Quit();
        }
    }

    public static void UnloadGame() {
        if (LuaClient.Instance != null) {
            LuaClient.Instance.Dispose();
        }
        HotfixManager.DestroyInstance();
    }

}
