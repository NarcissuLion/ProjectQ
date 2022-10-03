using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 由AssetBundle加载的资源，实例化和销毁时在这里更新引用计数
/// </summary>
public class AssetBundleHelper : MonoBehaviour, AssetCounter.ChangeListener {

    public string assetPath;
    public string bundleName;
    public int refCount;

    private string[] dependencies = new string[0];

    public void Init(string assetPath, string bundleName) {
        this.assetPath = assetPath;
        this.bundleName = bundleName;

        // 查找引用
        dependencies = HotfixManager.Instance.GetAllDependencies(bundleName);

        // 预设的引用计数 + 1
        AssetCounter.AddListener(bundleName, this); // 用于编辑器下显示refCount
        AssetCounter.Add(bundleName, 1);

        // 依赖的资源的引用计数 + 1
        for (int i = 0; i < dependencies.Length; i++) {
            string dependencyBundle = dependencies[i];
            AssetCounter.Add(dependencyBundle, 1);
        }
    }

    void OnDestroy() {
        // 引用计数-1，没有引用了旧卸载AssetBundle
        AssetCounter.RemoveListener(bundleName, this);
        AssetCounter.Add(bundleName, -1);

        HotfixManager.Instance.Unload(bundleName, false);

        for (int i = 0; i < dependencies.Length; i++) {
            string dependencyBundle = dependencies[i];
            if (AssetCounter.Add(dependencyBundle, -1) == 0) {
                HotfixManager.Instance.Unload(dependencyBundle, false);
            }
        }
        //Resources.UnloadUnusedAssets();
    }

    public void OnChange(string key, int count) {
        refCount = count;
    }

    //保存当前预设实例引用了哪些资源包，当前预设实例完全不用时unload所有引用的资源包

    #region Static
    private static AssetCounter assetCounter = new AssetCounter();
    public static AssetCounter AssetCounter
    {
        get {
            return assetCounter;
        }
    }

    /// <summary>
    /// 预设和依赖资源包的引用计数+1
    /// </summary>
    /// <param name="assetHelper"></param>
    private static void OnAssetInstantiate(AssetBundleHelper assetHelper) {
        AssetCounter.AddListener(assetHelper.bundleName, assetHelper);
        AssetCounter.Add(assetHelper.bundleName, 1);

        for (int i = 0; i < assetHelper.dependencies.Length; i++) {
            string dependencyBundle = assetHelper.dependencies[i];
            AssetCounter.Add(dependencyBundle, 1);
        }
    }

    #endregion


}
