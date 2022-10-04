#region 模块信息
// **********************************************************************
// Copyright (C) 2017 The company name
//
// 文件名(File Name):             PrefabJsonCreator.cs
// 作者(Author):                  tom
// 创建时间(CreateTime):           2017/4/11 9:55:46
// 修改者列表(modifier):
// 模块描述(Module description):   把所有prefab的路径生成对应名称的json
// **********************************************************************
#endregion
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;


public class PrefabPathJsonCreator : UnityEditor.AssetModificationProcessor
{

    [MenuItem(EditorConst.LABEL_EDITOR_RES + "/Build Res Index")]
    public static void BuildIndex()
    {
        //CreatePrefabsPathJson();
        CreateSpritePrefabsPathJson();
    }
    //public static void CreatePrefabsPathJson()
    //{
    //    JsonData jsonData = new JsonData();

    //    string objPath = ResHelper.ASSETS_PATH + "/Prefabs";

    //    DirectoryInfo dir = new DirectoryInfo(objPath);
    //    FileInfo[] files = dir.GetFiles("*.prefab", SearchOption.AllDirectories);
    //    int fileCount = files.Length;
    //    for (int i = 0; i < fileCount; i++)
    //    {
    //        FileInfo item = files[i];
    //        string fullName = item.FullName.Replace("\\", "/");
    //        string resourcePath = fullName.Substring(fullName.LastIndexOf("Prefabs/"));
    //        resourcePath = resourcePath.Remove(resourcePath.LastIndexOf("."));

    //        if (EditorUtility.DisplayCancelableProgressBar((i + 1) + "/" + fileCount, resourcePath, (float)(i + 1) / fileCount))
    //        {
    //            EditorUtility.ClearProgressBar();
    //            return;
    //        }

    //        string name = Path.GetFileNameWithoutExtension(item.Name);
    //        if (jsonData.ContainsKey(name))
    //        {
    //            Debug.LogErrorFormat("Duplicate name [{0}] and [{1}]", jsonData[name], resourcePath);
    //        }
    //        jsonData[name] = resourcePath;
    //    }


    //    string jsonStorePath = ResHelper.ASSETS_PATH + "/" + SysDefine.SYS_PATH_UIFormConfigJson + ".json";

    //    if (File.Exists(jsonStorePath))
    //    {
    //        File.Delete(jsonStorePath);
    //    }

    //    JsonUtil.WriteJson(jsonStorePath, jsonData);

    //    //刷新editor
    //    AssetDatabase.Refresh();

    //    EditorUtility.ClearProgressBar();
    //}

    public static void CreateSpritePrefabsPathJson()
    {
        JsonData jsonData = new JsonData();

        string objPath = ResPathes.PREFAB_FOLDER_PATH + "/SpriteAssets";

        if (!Directory.Exists(objPath))
        {
            Debug.LogError(objPath + " Not Exist!!");
            return;
        }   
           

        DirectoryInfo dir = new DirectoryInfo(objPath);
        FileInfo[] files = dir.GetFiles("*.prefab", SearchOption.AllDirectories);   
        int fileCount = files.Length;
        for (int i = 0; i < fileCount; i++)
        {
            FileInfo item = files[i];
            string fullName = item.FullName.Replace("\\", "/");
            string resourcePath = fullName.Substring(fullName.LastIndexOf("Prefab/"));
            resourcePath = resourcePath.Remove(resourcePath.LastIndexOf("."));

            if (EditorUtility.DisplayCancelableProgressBar((i + 1) + "/" + fileCount, resourcePath, (float)(i + 1) / fileCount))
            {
                EditorUtility.ClearProgressBar();
                return;
            }

            string name = Path.GetFileNameWithoutExtension(item.Name);
            if (jsonData.Keys.Contains(name))
            {
                Debug.LogErrorFormat("Duplicate name [{0}] and [{1}]", jsonData[name], resourcePath);
            }
            jsonData[name] = resourcePath;
        }


        string jsonStorePath = ResPathes.ASSETS_PATH + "/" + ResPathes.SPRITE_INDEX_PATH + ".json";

        if (File.Exists(jsonStorePath))
        {
            File.Delete(jsonStorePath);
        }

        JsonUtil.WriteJson(jsonStorePath, jsonData);

        //刷新editor
        AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
    }

    //public static void CreateSpriteIndex()
    //{
    //    //-----获取json文件数据------
    //    JsonData jsonData = new JsonData();

    //    List<string> includeExt = new List<string> { ".png", ".jpeg", ".jpg" };
    //    string[] objPath = { ResHelper.ATLAS_PATH, ResHelper.RAW_IMG_PATH };
    //    foreach (var path in objPath)
    //    {
    //        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
    //        int fileCount = files.Length;
    //        for (int i = 0; i < fileCount; i++)
    //        {
    //            string fn = files[i];
    //            if (!includeExt.Contains(Path.GetExtension(fn)))
    //            {
    //                continue;
    //            }
    //            string fullName = fn.Replace("\\", "/");
    //            string resourcePath = fullName.Substring(fullName.LastIndexOf(ResHelper.ASSETS_PATH) + ResHelper.ASSETS_PATH.Length + 1);
    //            resourcePath = resourcePath.Remove(resourcePath.LastIndexOf("."));

    //            if (EditorUtility.DisplayCancelableProgressBar((i + 1) + "/" + fileCount, resourcePath, (float)(i + 1) / fileCount))
    //            {
    //                EditorUtility.ClearProgressBar();
    //                return;
    //            }

    //            string name = Path.GetFileNameWithoutExtension(fn);
    //            if (jsonData.ContainsKey(name))
    //            {
    //                Debug.LogErrorFormat("Duplicate name [{0}]: [{1}] [{2}]", name, jsonData[name], resourcePath);
    //            }
    //            jsonData[name] = resourcePath;
    //        }

    //    }


    //    //-----创建json文件-----

    //    string jsonStorePath = ResHelper.ASSETS_PATH + "/" + SysDefine.SYS_PATH_SpriteConfigJson + ".json";

    //    if (File.Exists(jsonStorePath))
    //    {
    //        File.Delete(jsonStorePath);
    //    }

    //    JsonUtil.WriteJson(jsonStorePath, jsonData);

    //    //刷新editor
    //    AssetDatabase.Refresh();

    //    EditorUtility.ClearProgressBar();
    //}
}
