using System;
using System.Collections.Generic;

public class HotfixHashList {

    public string version;
    public List<string> singleBundle = new List<string>();
    public Dictionary<string, string> hash = new Dictionary<string, string>();

    public void AddHash(string bundleName, string hash) {
        if (!this.hash.ContainsKey(bundleName)) {
            this.hash.Add(bundleName, hash);
        }
    }

    public string GetHash(string bundleName) {
        string hash;
        if(this.hash.TryGetValue(bundleName, out hash)) {
            return hash;
        }
        return null;
    }

    public void AddOrReplaceHash(string bundleName, string hash) {
        if (this.hash.ContainsKey(bundleName)) {
            this.hash.Remove(bundleName);
        }
        this.hash.Add(bundleName, hash);
    }

    public bool RemoveHash(string bundleName) {
        return hash.Remove(bundleName);
    }

    public bool Contains(string bundleName) {
        return hash.ContainsKey(bundleName);
    }

    public void AddSingleBundle(string assetDirPath) {
        singleBundle.Add(assetDirPath);
    }

    public bool IsSingleBundle(string assetDirPath) {
        foreach (string path in singleBundle) {
            if (assetDirPath.Contains(path)) {
                return true;    // 所有文件的情况
            }
        }
        return false;
        //return singleBundle.Contains(assetDirPath);   // 一级文件夹的情况
    }

}
