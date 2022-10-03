using System.Collections.Generic;
using UnityEngine;

public class ResourceCachePool : MonoBehaviour {

    [System.Serializable]
    public class Cache {
        public Object asset;
        public string bundleName;
        public string assetPath;

        public Cache(Object asset, string assetPath, string bundleName) {
            this.asset = asset;
            this.assetPath = assetPath;
            this.bundleName = bundleName;
        }
    }

    public ResourceConfig resourceConfig;
    public Dictionary<string, OrderMap<string, Cache>> cacheDict = new Dictionary<string, OrderMap<string, Cache>>();

    public void init(ResourceConfig resourceConfig) {
        this.resourceConfig = resourceConfig;
        foreach(KeyValuePair<string, int> pair in resourceConfig.cacheGroup) {
            cacheDict.Add(pair.Key, new OrderMap<string, Cache>(pair.Value + 1));
        }
    }

    public void OnLoadResource(Object res, string path, string group, string bundleName) {
        if(res == null) {
            return;
        }
        if(group != null && !IsCached(path, group)) {
            AddCache(res, path, group, bundleName);
        }
    }

    public Cache GetCache(string path, string group) {
        OrderMap<string, Cache> map;
        if(group != null && cacheDict.TryGetValue(group, out map)) {
            return map.Get(path);
        }
        return null;
    }

    public bool IsCached(string path, string group) {
        OrderMap<string, Cache> map;
        if (group != null && cacheDict.TryGetValue(group, out map)) {
            return map.Contains(path);
        }
        return false;
    }

    private void AddCache(Object res, string path, string group, string bundleName) {
        if(group == null || res == null) {
            return;
        }

        OrderMap<string, Cache> map;
        if (cacheDict.TryGetValue(group, out map)) {
            map.Add(path, new Cache(res, path, bundleName));
            if(bundleName != null) {
                HotfixManager.Instance.AddRefCounter(bundleName, true, 1);
            }

            int limit = resourceConfig.GetCacheGroupLimit(group);
            if(map.Count > limit) {
                Cache cache = map.GetAt(0);
                map.RemoveFirst();
                if(cache.bundleName != null) {
                    HotfixManager.Instance.AddRefCounter(cache.bundleName, true, -1);
                    HotfixManager.Instance.Unload(cache.bundleName, false);
                }
            }
        }
    }

    public void Clear() {
        foreach (KeyValuePair<string, OrderMap<string, Cache>> pair in cacheDict) {
            OrderMap<string, Cache> map = pair.Value;
            foreach (string key in map.Keys()) {
                Cache cache = map.Get(key);
                if (cache.bundleName != null) {
                    HotfixManager.Instance.AddRefCounter(cache.bundleName, true, -1);
                }
            }
        }
        cacheDict.Clear();
    }

    //private bool RemoveCache(string path, string group) {
    //    OrderMap<string, Object> map;
    //    if (cacheDict.TryGetValue(group, out map)) {
    //        return map.Remove(path);
    //    }
    //    return false;
    //}
    
}
