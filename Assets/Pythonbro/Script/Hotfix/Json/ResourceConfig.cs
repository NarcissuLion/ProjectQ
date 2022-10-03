using System.Collections.Generic;
using UnityEngine;

public class ResourceConfig {

    public List<string> common = new List<string>();
    public Dictionary<string, int> cacheGroup = new Dictionary<string, int>();
    public Dictionary<string, List<string>> cachePool = new Dictionary<string, List<string>>();

    // bundle是否配置成公用资源
    public bool IsCommon(string bundleName) {
        if(common == null) {
            return false;
        }

        bundleName = bundleName.Substring(HotfixManager.GAME_PREFIX.Length);
        foreach (string path in common) {
            if (bundleName.StartsWith(path, System.StringComparison.OrdinalIgnoreCase)) {
                return true;
            }
        }
        return false;
    }

    public string GetCacheGroup(string assetPath) {
        if(cacheGroup == null) {
            return null;
        }

        foreach(KeyValuePair<string, List<string>> pair in cachePool) {
            foreach (string path in pair.Value) {
                if (assetPath.StartsWith(path, System.StringComparison.OrdinalIgnoreCase)) {
                    return pair.Key;
                }
            }
        }
        return null;
    }

    public int GetCacheGroupLimit(string groupName) {
        int value = 0;
        if (cacheGroup.TryGetValue(groupName, out value)) {
            return value;
        }
        return 0;
    }

}
