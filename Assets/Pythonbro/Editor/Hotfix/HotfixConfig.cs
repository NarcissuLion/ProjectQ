using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HotfixConfig : ScriptableObject {

    [Tooltip("打包列表\n以下目录会按目录结构打AssetBundle包")]
    public List<DefaultAsset> buildList = new List<DefaultAsset>();

    [Tooltip("单独打包列表\n以下目录中的所有文件会按文件单独打AssetBundle包，目录必须是Build List的子集")]
    public List<DefaultAsset> singleBuildList = new List<DefaultAsset>();

    [Tooltip("除了Build List以外，需额外删除的可热更资源列表")]
    public List<DefaultAsset> extraDeleteList = new List<DefaultAsset>();

    public bool InSingleBuildList(string dirPath) {
        dirPath = HotfixUtil.NormalizePath(dirPath);

        foreach(DefaultAsset pathAsset in singleBuildList) {
            string path = AssetDatabase.GetAssetPath(pathAsset);
            if (dirPath.StartsWith(HotfixUtil.NormalizePath(path))) {
                return true;    // 全部子文件
            }
            //if(HotfixUtil.NormalizePath(path) == dirPath) {
            //    return true;  // 一级子文件
            //}
        }
        return false;
    }

}
