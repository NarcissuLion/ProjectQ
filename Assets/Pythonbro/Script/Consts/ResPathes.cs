using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPathes
{
    public static string ASSETS_FOLDER = "GameAssets";
    public static string PREFAB_FOLDER = "Prefab";
  

    public const string SPRITE_INDEX_PATH = "TextAssets/Index/SpriteIndexPathJson";
    public static string ASSETS_PATH
    {
        get { return Application.dataPath + "/" + ASSETS_FOLDER; }
    } 
    
    public static string PREFAB_FOLDER_PATH
    {
        get { return RESOURCE_PATH  + "/Prefab"; }
    }
        
    public static string RESOURCE_PATH
    {
        get { return Application.dataPath + "/Res"; }
    }


}