using System;
using System.Collections.Generic;

public class HotfixDownloadList {

    public class File {
        public int index;
        public string url;
        public string md5;
        public string path;
        public long size;

        public string GetSavePath(bool isTempPath) {
            if (isTempPath) {
                return GameUtil.GetUpdatePath("temp/" + path);
            } else {
                return GameUtil.GetUpdatePath(path);
            }
        }
    }

    public long totalSize;
    public List<File> list = new List<File>();
    public string listJson;


}
