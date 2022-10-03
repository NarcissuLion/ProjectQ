using System;
using System.Collections.Generic;

public class HotfixList {

    public class File {
        public string md5;
        public long size;
        public int version;

        public File() {

        }

        public File(string md5, long size, int version) {
            this.md5 = md5;
            this.size = size;
            this.version = version;
        }
    }

    public string version;
    public long totalSize;
    public int fileCount;
    public Dictionary<string, File> list = new Dictionary<string, File>();

    public void AddFile(string name, string md5, long size, int version) {
        if (list.ContainsKey(name)) {
            UnityEngine.Debug.LogErrorFormat("Duplicate file: ", name);
            return;
        }
        list.Add(name, new File(md5, size, version));
    }

    public File GetFile(string name) {
        File file;
        if(list.TryGetValue(name, out file)) {
            return file;
        }
        return null;
    }

    public void AddOrReplaceFile(string name, string md5, long size, int version) {
        if (list.ContainsKey(name)) {
            list.Remove(name);
        }
        list.Add(name, new File(md5, size, version));
    }

    public bool RemoveFile(string name) {
        return list.Remove(name);
    }

}
