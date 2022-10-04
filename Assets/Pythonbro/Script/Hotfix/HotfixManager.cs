using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

/// <summary>
/// 热更管理器
/// 负责资源加载、释放
/// </summary>
public class HotfixManager : MonoBehaviour
{

    public static readonly string RESOURCE_PREFIX = "assets/res/";
    public static readonly string GAME_PREFIX = "assets/game/";

    private static HotfixManager instance;

    public static void DestroyInstance()
    {
        if (instance != null)
        {
            instance.Destroy();
            instance = null;
            DestroyImmediate(GameObject.Find("HotfixManager"));
        }
    }

    public static HotfixManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("HotfixManager");
                DontDestroyOnLoad(obj);

                instance = obj.AddComponent<HotfixManager>();
                instance.Initialized = false;
                instance.Init();
            }
            return instance;
        }
    }

    private Dictionary<string, AssetBundle> bundleCache = new Dictionary<string, AssetBundle>();

    private HotfixHashList persistentHashList;  // persistentDataPath下的AssetBundle索引
    private HotfixHashList streamingAssetHashList;  // streamingAssetPath下的AssetBundle索引
    private ResourceConfig resourceConfig;

    private AssetBundle mainAssetBundle;    // 当前的mainAssetBundle
    private AssetBundleManifest manifest;

    private Dictionary<string, bool> commonBundleIndex;
    private AsyncOperation unloadOperation;
    public ResourceCachePool resourceCachePool;

    public bool Initialized { get; private set; }
    private bool usingPersistentPath = true;

    private void Awake()
    {
        resourceCachePool = gameObject.AddComponent<ResourceCachePool>();
#if UNITY_EDITOR
        usingPersistentPath = false;
#endif
    }

    // 初始化
    public void Init()
    {
        if (Initialized)
        {
            return;
        }
        Initialized = true;
        string resourceConfigJson = GameUtil.LoadDecryptText("SysConfig/resource.json");
        Debug.Log(resourceConfigJson);
        resourceConfig = JsonUtil.ParseJsonObject<ResourceConfig>(resourceConfigJson);
        commonBundleIndex = new Dictionary<string, bool>();

        // 优先本地存储目录
        string persistentHashJson = ResourcesLoader.LoadTextFromPersistentData("update/assetbundle/hash.json");
        persistentHashList = JsonUtil.ParseJsonObject<HotfixHashList>(persistentHashJson);
        if (persistentHashList != null)
        {
            Debug.Log("[HotfixManager] PersistentPath hotfix found");

            string bundlePath = Application.persistentDataPath + "/update/assetbundle/assetbundle";
            mainAssetBundle = AssetBundle.LoadFromFile(bundlePath);

            if (mainAssetBundle != null)
            {
                manifest = mainAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            }
        }

#if !UNITY_ANDROID
        // 其次StreamingAssetPath
        string streamingHashJson = ResourcesLoader.LoadTextFromStreamingAssets("assetbundle/hash.json");
        streamingAssetHashList = JsonUtil.ParseJsonObject<HotfixHashList>(streamingHashJson);
        if (streamingAssetHashList != null)
        {
            Debug.Log("[HotfixManager] StreamingAssetPath hotfix found");

            if (mainAssetBundle == null)
            {
                string bundlePath = Application.streamingAssetsPath + "/assetbundle/assetbundle";
                mainAssetBundle = AssetBundle.LoadFromFile(bundlePath);

                if (mainAssetBundle != null)
                {
                    manifest = mainAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                }
            }
        }
#endif

        if (persistentHashList == null && streamingAssetHashList == null)
        {
            Debug.Log("[HotfixManager] Hotfix not found");
        }

        resourceCachePool.init(resourceConfig);
    }

    // 销毁，释放资源
    public void Destroy()
    {
        Destroy(gameObject);
    }

    // 立即销毁，释放资源
    public void DestroyImmediate()
    {
        DestroyImmediate(gameObject);
    }

    public AssetBundleManifest GetManifest()
    {
        return manifest;
    }

    private void OnDestroy()
    {
        instance = null;
        Initialized = false;

        persistentHashList = null;
        streamingAssetHashList = null;
        commonBundleIndex = null;

        UnloadAll();

        manifest = null;
        if (mainAssetBundle != null)
        {
            mainAssetBundle.Unload(true);
            mainAssetBundle = null;
        }
    }

    public string GetCacheGroup(string assetPath)
    {
        return resourceConfig.GetCacheGroup(assetPath);
    }

    // 加载资源，并立刻释放Bundle，不释放资源
    public T LoadResource<T>(string path) where T : Object
    {
        string group = resourceConfig.GetCacheGroup(path);
        ResourceCachePool.Cache cache = resourceCachePool.GetCache(path, group);
        if (cache != null)
        {
            Debug.Log("LoadResource:" + path);
            return cache.asset as T;
        }

        AssetBundle bundle = LoadBundleByAssetPath(path);
        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);
            T asset = bundle.LoadAsset<T>(assetName);
            resourceCachePool.OnLoadResource(asset, path, group, bundle.name);
            Unload(bundle.name, false);    // 立刻释放
            return asset;
        }
        else
        {
            T asset = ResourcesLoader.Load<T>(path);
            resourceCachePool.OnLoadResource(asset, path, group, null);
            return asset;
        }
    }

    // 加载资源，并立刻释放Bundle，不释放资源
    public Object LoadResource(string path, System.Type type)
    {
        string group = resourceConfig.GetCacheGroup(path);
        ResourceCachePool.Cache cache = resourceCachePool.GetCache(path, group);
        if (cache != null)
        {
            return cache.asset;
        }

        AssetBundle bundle = LoadBundleByAssetPath(path);
        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);
            Object asset = bundle.LoadAsset(assetName, type);
            resourceCachePool.OnLoadResource(asset, path, group, assetName);

            Unload(bundle.name, false);    // 立刻释放
            return asset;
        }
        else
        {
            Object asset = ResourcesLoader.Load(path, type);
            resourceCachePool.OnLoadResource(asset, path, group, null);
            return asset;
        }
    }

    // 使用队列机制异步加载资源，加载队列全执行完，再一次性卸载bundle
    // 返回队列id，可通过CoroutineQueue.TryRemove(id)尝试取消队列
    public string LoadResourceAsyncQueue(string path, System.Type type, System.Action<Object, string> callback)
    {
        CoroutineQueue queue = CoroutineQueue.GetCurrent();
        queue.onComplete = UnloadQueuedBundles;

        string id = System.Guid.NewGuid().ToString();
        queue.Add(id, LoadResourceAsync(path, type, (res) => {
            SafeInvoke(callback, res, id);
        }));
        queue.StartOrJoin();
        return id;
    }

    // 使用队列机制异步加载资源，加载队列全执行完，再一次性卸载bundle
    // 返回队列id，可通过CoroutineQueue.TryRemove(id)尝试取消队列
    public string LoadResourceAsyncQueue<T>(string path, System.Action<T, string> callback) where T : Object
    {
        CoroutineQueue queue = CoroutineQueue.GetCurrent();
        queue.onComplete = UnloadQueuedBundles;

        string id = System.Guid.NewGuid().ToString();
        queue.Add(id, LoadResourceAsync<T>(path, (res) => {
            SafeInvoke(callback, res, id);
        }));
        queue.StartOrJoin();
        return id;
    }

    // 加载资源，并立刻释放Bundle，不释放资源
    private IEnumerator LoadResourceAsync<T>(string path, System.Action<T> callback) where T : Object
    {
        string group = resourceConfig.GetCacheGroup(path);
        ResourceCachePool.Cache cache = resourceCachePool.GetCache(path, group);
        if (cache != null)
        {
            SafeInvoke(callback, cache.asset as T);
            yield break;
        }

        AssetBundle bundle = null;

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            bundle = GetBundleCache(bundleName);
            if (bundle == null)
            {
                yield return LoadBundleByNameAsync(bundleName, true, (_bundle) => {
                    bundle = _bundle;
                });
            }
        }

        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);
            T asset = bundle.LoadAsset<T>(assetName);
            resourceCachePool.OnLoadResource(asset, path, group, bundleName);

            if (!IsCommonBundle(bundle.name))
            {
                UnloadBundleInQueue(bundle);    // 立刻释放
            }
            SafeInvoke(callback, asset);
        }
        else
        {
            Object asset = ResourcesLoader.Load<T>(path);
            yield return true;
            resourceCachePool.OnLoadResource(asset, path, group, null);
            SafeInvoke(callback, asset as T);
        }
    }

    // 异步加载资源，并立刻释放Bundle，不释放资源
    private IEnumerator LoadResourceAsync(string path, System.Type type, System.Action<Object> callback)
    {
        string group = resourceConfig.GetCacheGroup(path);
        ResourceCachePool.Cache cache = resourceCachePool.GetCache(path, group);
        if (cache != null)
        {
            SafeInvoke(callback, cache.asset);
            yield break;
        }

        AssetBundle bundle = null;

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            bundle = GetBundleCache(bundleName);
            if (bundle == null)
            {
                yield return LoadBundleByNameAsync(bundleName, true, (_bundle) => {
                    bundle = _bundle;
                });
            }
        }

        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);
            Object asset = bundle.LoadAsset(assetName, type);
            resourceCachePool.OnLoadResource(asset, path, group, bundleName);

            if (!IsCommonBundle(bundle.name))
            {
                UnloadBundleInQueue(bundle);    // 立刻释放
            }
            SafeInvoke(callback, asset);
        }
        else
        {
            Object asset = ResourcesLoader.Load(path, type);
            yield return true;
            resourceCachePool.OnLoadResource(asset, path, group, null);
            SafeInvoke(callback, asset);
        }
    }

    // 尝试加载场景bundle，如果加载成功，则返回bundle，否则返回null
    public AssetBundle BeforeLoadScene(string sceneName)
    {
        string bundleName = "assets/game/scene/" + sceneName.ToLower() + "_module";
        return LoadBundleByName(bundleName, true);
    }

    // 在通过bundle加载的场景激活后，创建一个AssetBundleHelper，用于销毁场景后自动回收bundle
    public void AfterLoadScene(AssetBundle sceneBundle, Scene scene)
    {
        if (sceneBundle != null)
        {
            AssetBundleHelper helper = new GameObject("SceneBundleHelper").AddComponent<AssetBundleHelper>();
            helper.Init(scene.path, sceneBundle.name);
        }
    }

    // 加载预设(LoadBundle + LoadAsset 或 Resources.Load)，不实例化，增加引用计数
    // 如果是AssetBundle则同时返回BundleName
    public IEnumerator LoadPrefabAsync(string path, bool addCounter, System.Action<GameObject, string> callback)
    {
        string group = resourceConfig.GetCacheGroup(path);
        ResourceCachePool.Cache cache = resourceCachePool.GetCache(path, group);
        if (cache != null)
        {
            SafeInvoke(callback, cache.asset as GameObject, cache.bundleName);
            yield break;
        }

        AssetBundle bundle = null;

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            bundle = GetBundleCache(bundleName);
            if (bundle == null)
            {
                yield return LoadBundleByNameAsync(bundleName, true, (_bundle) => {
                    bundle = _bundle;
                });
            }
        }

        if (bundle != null && usingPersistentPath)
        {
            if (addCounter)
            {
                AddRefCounter(bundle.name, true, 1);
            }

            string assetName = Path.GetFileName(path);
            GameObject prefab = bundle.LoadAsset<GameObject>(assetName);
            resourceCachePool.OnLoadResource(prefab, path, group, bundleName);

            SafeInvoke(callback, prefab, bundle.name);
        }
        else
        {
            GameObject prefab = ResourcesLoader.Load<GameObject>(path);
            resourceCachePool.OnLoadResource(prefab, path, group, null);
            SafeInvoke(callback, prefab, null);
        }
    }

    // 添加bundle和依赖的引用计数
    public void AddRefCounter(string bundleName, bool withDependency, int count)
    {
        if (string.IsNullOrEmpty(bundleName))
        {
            return;
        }
        AssetBundleHelper.AssetCounter.Add(bundleName, count);

        if (withDependency)
        {
            string[] dependencies = GetAllDependencies(bundleName);
            for (int i = 0; i < dependencies.Length; i++)
            {
                string dependencyBundle = dependencies[i];
                AssetBundleHelper.AssetCounter.Add(dependencyBundle, count);
            }
        }
    }

    // 实例化预设，不释放Bundle，而是增加引用计数器，由计数器释放
    public GameObject CreatePrefab(string path)
    {
        AssetBundle bundle = LoadBundleByAssetPath(path);

        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);

            GameObject prefab = bundle.LoadAsset<GameObject>(assetName);
            if (prefab == null)
            {
                return null;
            }
            GameObject obj = Instantiate(prefab);

            // AssetBundleHelper控制计数器
            AssetBundleHelper helper = obj.AddComponent<AssetBundleHelper>();
            helper.Init(path, bundle.name);

            return obj;
        }
        else
        {
            GameObject prefab = ResourcesLoader.Load<GameObject>(path);
            if (prefab == null)
            {
                return null;
            }
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

    // 实例化预设，不释放Bundle，而是增加引用计数器，由计数器释放
    public IEnumerator CreatePrefabAsync(string path, System.Action<GameObject> callback)
    {
        AssetBundle bundle = null;

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            bundle = GetBundleCache(bundleName);
            if (bundle == null)
            {
                yield return LoadBundleByNameAsync(bundleName, true, (_bundle) => {
                    bundle = _bundle;
                });
            }
        }

        if (bundle != null && usingPersistentPath)
        {
            string assetName = Path.GetFileName(path);
            GameObject prefab = bundle.LoadAsset<GameObject>(assetName);

            if (prefab == null)
            {
                SafeInvoke(callback, null);
                yield break;
            }

            GameObject obj = Instantiate(prefab);

            // AssetBundleHelper控制计数器
            AssetBundleHelper helper = obj.AddComponent<AssetBundleHelper>();
            helper.Init(path, bundle.name);

            SafeInvoke(callback, obj);
        }
        else
        {
            Object asset = ResourcesLoader.Load<GameObject>(path);
            yield return true;

            GameObject prefab = asset as GameObject;
            if (prefab == null)
            {
                SafeInvoke(callback, null);
                yield break;
            }
            GameObject obj = Instantiate(prefab);
            SafeInvoke(callback, obj);
        }
    }

    // 指定AssetBundle是否是公用的
    public bool IsCommonBundle(string bundleName)
    {
        bool isCommon = false;
        if (commonBundleIndex.TryGetValue(bundleName, out isCommon))
        {
            return isCommon;
        }
        return false;
    }

    public string[] GetAllDependencies(string bundleName)
    {
        if (manifest != null)
        {
            return manifest.GetAllDependencies(bundleName);
        }
        return new string[0];
    }

    // 卸载指定AssetBundle
    public void Unload(string bundleName, bool unloadAllLoadedObjects)
    {
        if (!Initialized || IsCommonBundle(bundleName))
        {
            return;
        }

        int refCount = AssetBundleHelper.AssetCounter.Get(bundleName);
        if (refCount > 0)
        {
            return;
        }

        AssetBundle bundle;
        if (bundleCache.TryGetValue(bundleName, out bundle))
        {
            bundleCache.Remove(bundleName);
            bundle.Unload(unloadAllLoadedObjects);

            //if (!unloadAllLoadedObjects) {
            //    UnloadUnusedAssets(false);
            //}
        }
        //else {
        //    Debug.LogFormat("Unload bundle not in cache: {0}", bundleName);
        //}
    }

    // 卸载全部AssetBundle
    public void UnloadAll()
    {
        //foreach (AssetBundle bundle in bundleCache.Values) {
        //    if (bundle != null) {
        //        bundle.Unload(true);
        //    }
        //}
        resourceCachePool.Clear();
        bundleCache.Clear();
        AssetBundle.UnloadAllAssetBundles(true);
        mainAssetBundle = null;
        UnloadUnusedAssets(true);
    }

    // 根据资源路径加载AssetBundle
    // path 肯定是一个Resources下的路径
    private AssetBundle LoadBundleByAssetPath(string path)
    {
        if (persistentHashList == null && streamingAssetHashList == null)
        {
            return null;
        }

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            AssetBundle bundle = LoadBundleByName(bundleName, true);
            return bundle;
        }
        return null;
    }

    // 异步根据资源路径加载AssetBundle
    private IEnumerator LoadBundleByAssetPathAsync(string path, System.Action<AssetBundle> callback)
    {
        if (persistentHashList == null && streamingAssetHashList == null)
        {
            SafeInvoke(callback, null);
            yield break;
        }

        string bundleName = GetBundleByAssetPath(path);
        if (bundleName != null)
        {
            yield return LoadBundleByNameAsync(bundleName, true, callback);
        }
        else
        {
            SafeInvoke(callback, null);
        }
    }

    // 根据资源路径，获得bundle名
    public string GetBundleByAssetPath(string path)
    {
        if (persistentHashList == null && streamingAssetHashList == null)
        {
            return null;
        }

        string bundleName = null;
        try
        {
            string dir = Path.GetDirectoryName(path).ToLower();

            //是否单独打包的
            if (persistentHashList != null && persistentHashList.IsSingleBundle(RESOURCE_PREFIX + dir))
            {
                bundleName = RESOURCE_PREFIX + dir + "/" + Path.GetFileName(path).ToLower() + ".prefab";
            }
            else if (streamingAssetHashList != null && streamingAssetHashList.IsSingleBundle(RESOURCE_PREFIX + dir))
            {
                bundleName = RESOURCE_PREFIX + dir + "/" + Path.GetFileName(path).ToLower() + ".prefab";
            }
            else
            {
                bundleName = RESOURCE_PREFIX + dir + "_module";
            }
            bundleName = bundleName.Replace("\\", "/");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString() + "\n" + path);
        }
        return bundleName;
    }

    // 加载AssetBundle
    private AssetBundle LoadBundleByName(string bundleName, bool loadDependency)
    {
        // 先从缓存找
        AssetBundle bundle = GetBundleCache(bundleName);
        if (bundle != null)
        {
            return bundle;
        }

        // 从本地存储找
        string bundlePath = "assetbundle/" + bundleName;
        if (persistentHashList != null && persistentHashList.Contains(bundleName))
        {
            string persistentBundle = Application.persistentDataPath + "/update/" + bundlePath;
            bundle = LoadAssetBundle(persistentBundle);

            if (bundle != null)
            {
                if (loadDependency)
                {
                    LoadDependencies(bundle);
                }
                return bundle;
            }
        }

        if (streamingAssetHashList != null && streamingAssetHashList.Contains(bundleName))
        {
            string streamingBundle = Application.streamingAssetsPath + "/" + bundlePath;
            bundle = LoadAssetBundle(streamingBundle);

            if (bundle != null)
            {
                if (loadDependency)
                {
                    LoadDependencies(bundle);
                }
                return bundle;
            }
        }

        Debug.LogFormat("AssetBundle load fail: {0}", bundleName);
        return null;
    }

    // 异步加载AssetBundle
    private IEnumerator LoadBundleByNameAsync(string bundleName, bool loadDependency, System.Action<AssetBundle> callback)
    {
        // 先从缓存找
        AssetBundle bundle = GetBundleCache(bundleName);
        if (bundle != null)
        {
            SafeInvoke(callback, bundle);
            yield break;
        }

        // 从本地存储找
        string bundlePath = "assetbundle/" + bundleName;
        if (persistentHashList != null && persistentHashList.Contains(bundleName))
        {
            string persistentBundle = Application.persistentDataPath + "/update/" + bundlePath;
            yield return LoadAssetBundleAsync(persistentBundle, (_bundle) => {
                bundle = _bundle;
            });

            if (bundle != null)
            {
                if (loadDependency)
                {
                    yield return LoadDependenciesAsync(bundle);
                }

                SafeInvoke(callback, bundle);
                yield break;
            }
        }

        if (streamingAssetHashList != null && streamingAssetHashList.Contains(bundleName))
        {
            string streamingBundle = Application.streamingAssetsPath + "/" + bundlePath;
            yield return LoadAssetBundleAsync(streamingBundle, (_bundle) => {
                bundle = _bundle;
            });

            if (bundle != null)
            {
                if (loadDependency)
                {
                    yield return LoadDependenciesAsync(bundle);
                }

                SafeInvoke(callback, bundle);
                yield break;
            }
        }

        SafeInvoke(callback, null);
    }

    // 加载指定AssetBundle
    private AssetBundle LoadAssetBundle(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        AssetBundle bundle = AssetBundle.LoadFromFile(path);
        if (bundle != null)
        {
            ReloadShader(bundle);
            SetCommonBundleIndex(bundle);
            AddBundleCache(bundle);
        }
        return bundle;
    }

    // 异步加载指定AssetBundle
    private IEnumerator LoadAssetBundleAsync(string path, System.Action<AssetBundle> callback)
    {
        if (!File.Exists(path))
        {
            SafeInvoke(callback, null);
            yield break;
        }

        AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(path);
        yield return req;

        AssetBundle bundle = req.assetBundle;
        if (bundle != null)
        {
            ReloadShader(bundle);
            SetCommonBundleIndex(bundle);
            AddBundleCache(bundle);
        }
        SafeInvoke(callback, bundle);
    }

    private void ReloadShader(AssetBundle bundle)
    {
#if UNITY_EDITOR
        if (bundle == null || bundle.isStreamedSceneAssetBundle)
        {
            return;
        }
        Material[] materials = bundle.LoadAllAssets<Material>();
        foreach (Material m in materials)
        {
            string shaderName = m.shader.name;

            Shader newShader = Shader.Find(shaderName);
            if (newShader != null)
            {
                m.shader = newShader;
            }
        }
#endif
    }

    // 加载所有的依赖
    private void LoadDependencies(AssetBundle bundle)
    {
        bool isCommon = resourceConfig.IsCommon(bundle.name);
        foreach (string name in manifest.GetAllDependencies(bundle.name))
        {
            AssetBundle dependentBundle = LoadBundleByName(name, false);
            // 公用bundle的依赖bundle也是公用
            if (isCommon && dependentBundle != null)
            {
                commonBundleIndex[dependentBundle.name] = isCommon;
            }
        }
    }

    // 异步加载所有的依赖
    private IEnumerator LoadDependenciesAsync(AssetBundle bundle)
    {
        bool isCommon = resourceConfig.IsCommon(bundle.name);
        foreach (string name in manifest.GetAllDependencies(bundle.name))
        {
            yield return LoadBundleByNameAsync(name, false, (dependentBundle) => {
                // 公用bundle的依赖bundle也是公用
                if (isCommon && dependentBundle != null)
                {
                    commonBundleIndex[dependentBundle.name] = isCommon;
                }
            });
        }
    }

    private void AddBundleCache(AssetBundle bundle)
    {
        if (!bundleCache.ContainsKey(bundle.name))
        {
            bundleCache.Add(bundle.name, bundle);
        }
    }

    // 从缓存加查找AssetBundle
    private AssetBundle GetBundleCache(string bundleName)
    {
        if (bundleName != null)
        {
            AssetBundle bundle;
            if (bundleCache.TryGetValue(bundleName, out bundle))
            {
                return bundle;
            }
        }
        return null;
    }

    private void UnloadQueuedBundles()
    {
        foreach (string bundleName in unloadQueue)
        {
            Unload(bundleName, false);
        }
    }

    private HashSet<string> unloadQueue = new HashSet<string>();

    private void UnloadBundleInQueue(AssetBundle bundle)
    {
        if (!unloadQueue.Contains(bundle.name))
        {
            unloadQueue.Add(bundle.name);
        }
    }

    // 设置公用bundle索引
    private void SetCommonBundleIndex(AssetBundle bundle)
    {
        if (bundle != null)
        {
            bool isCommon = resourceConfig.IsCommon(bundle.name);
            if (isCommon)
            {
                commonBundleIndex[bundle.name] = isCommon;
            }
        }
    }

    private void SafeInvoke<T>(System.Action<T> callback, T t)
    {
        if (callback != null)
        {
            callback.Invoke(t);
        }
    }

    private void SafeInvoke<T1, T2>(System.Action<T1, T2> callback, T1 t1, T2 t2)
    {
        if (callback != null)
        {
            callback.Invoke(t1, t2);
        }
    }


    public void UnloadUnusedAssets(bool forceUnload)
    {
        if (unloadOperation != null && !forceUnload)
        {
            return;
        }

        unloadOperation = Resources.UnloadUnusedAssets();
        unloadOperation.completed += (ap) => {
            unloadOperation = null;
        };
    }

}
