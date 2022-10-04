#region 模块信息
// **********************************************************************
// Copyright (C) 2017 The company name
//
// 文件名(File Name):             AutoSetSpriteProperties.cs
// 作者(Author):                  Tom
// 创建时间(CreateTime):           Tuesday, 09 May 2017
// 修改者列表(modifier):
// 模块描述(Module description):   自动设定导入图片的属性
// **********************************************************************
#endregion

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class AutoSetSpriteProperties : AssetPostprocessor
{

    void OnPreprocessTexture()
    {
        SetAtlasImporterSettings();
        SetRawImporterSettings();
    }

    private void SetAtlasImporterSettings()
    {
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
            Debug.Log(dirName);
            if (!dirName.Contains("GameAssets\\Image") && !dirName.Contains("GameAssets\\SpriteAssets"))
                return;

        TextureImporter textureImporter = (TextureImporter)assetImporter;
    }

    private void SetAtlasimportersettings()
    {
        string dirname = System.IO.Path.GetDirectoryName(assetPath);
        Debug.Log(dirname);
        if (!dirname.Contains("gameassets\\image") && !dirname.Contains("gameassets\\spriteassets"))
            return;

        TextureImporter textureimporter = (TextureImporter)assetImporter;
        if (!string.IsNullOrEmpty(textureimporter.spritePackingTag))
            return;

        textureimporter.textureType = TextureImporterType.Sprite;

        string folderstr = System.IO.Path.GetDirectoryName(dirname);
        textureimporter.spritePackingTag = folderstr;
        textureimporter.spriteImportMode = SpriteImportMode.Single;
        textureimporter.wrapMode = TextureWrapMode.Clamp;
        textureimporter.spritePixelsPerUnit= 100;
        textureimporter.mipmapEnabled= false;
        textureimporter.alphaIsTransparency= true;

        TextureImporterSettings texturesettings = new TextureImporterSettings();
        textureimporter.ReadTextureSettings(texturesettings);
        texturesettings.spriteMeshType = SpriteMeshType.FullRect;
        textureimporter.SetTextureSettings(texturesettings);

        GetAtlasImporterSettings(textureimporter);
    }

    private void GetAtlasImporterSettings(TextureImporter textureImporter)
    {

        //android
        TextureImporterPlatformSettings android_settings = new TextureImporterPlatformSettings();
        android_settings.overridden = true;
        android_settings.allowsAlphaSplitting = true;
        android_settings.maxTextureSize = 2048;
        android_settings.format = TextureImporterFormat.ETC2_RGBA8;
        android_settings.name = "Android";
        android_settings.textureCompression = TextureImporterCompression.Compressed;

        textureImporter.SetPlatformTextureSettings(android_settings);

        //ios
        TextureImporterPlatformSettings ios_settings = new TextureImporterPlatformSettings();
        ios_settings.overridden = true;
        ios_settings.allowsAlphaSplitting = true;
        ios_settings.maxTextureSize = 2048;
        ios_settings.format = TextureImporterFormat.ASTC_4x4;
        ios_settings.name = "iPhone";
        ios_settings.textureCompression = TextureImporterCompression.Compressed;

        textureImporter.SetPlatformTextureSettings(ios_settings);
    }

    private void SetRawImporterSettings()
    {
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
        if (!dirName.Equals("Raw"))
            return;

        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter.textureType == TextureImporterType.Sprite)
            return;

        textureImporter.textureType = TextureImporterType.Sprite;
        
        textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.wrapMode = TextureWrapMode.Clamp;
        textureImporter.spritePixelsPerUnit = 100;
        textureImporter.mipmapEnabled = false;
        textureImporter.alphaIsTransparency = true;

        TextureImporterSettings textureSettings = new TextureImporterSettings();
        textureImporter.ReadTextureSettings(textureSettings);
        textureSettings.spriteMeshType = SpriteMeshType.FullRect;
        textureImporter.SetTextureSettings(textureSettings);

        GetRawImporterSettings(textureImporter);
    }

    private void GetRawImporterSettings(TextureImporter textureImporter)
    {

        //android
        TextureImporterPlatformSettings android_settings = new TextureImporterPlatformSettings();
        android_settings.overridden = true;
        android_settings.allowsAlphaSplitting = true;
        android_settings.maxTextureSize = 2048;
        android_settings.format = TextureImporterFormat.ETC2_RGBA8;
        android_settings.name = "Android";
        android_settings.textureCompression = TextureImporterCompression.Compressed;

        textureImporter.SetPlatformTextureSettings(android_settings);

        //ios
        TextureImporterPlatformSettings ios_settings = new TextureImporterPlatformSettings();
        ios_settings.overridden = true;
        ios_settings.allowsAlphaSplitting = true;
        ios_settings.maxTextureSize = 2048;
        ios_settings.format = TextureImporterFormat.ASTC_4x4;
        ios_settings.name = "iPhone";
        ios_settings.textureCompression = TextureImporterCompression.Compressed;

        textureImporter.SetPlatformTextureSettings(ios_settings);
    }

    // private void AutoDetectSpriteToPrefab()
    // {
    //     AssetDatabase.Refresh();
    //     string spriteDir = Application.dataPath +"/Resources/ImagePrefabs";
    // 	//  assetImporter;
    // 	Debug.Log("!!!! = " + assetPath);
    // 	int subIndex = assetPath.LastIndexOf("/");
    // 	string fileName = assetPath.Substring(subIndex + 1);
    // 	string rawName = fileName.Remove(fileName.IndexOf("."));

    // 	bool isFindedPrefab = false;
    // 	DirectoryInfo imagePrefabsDirInfo = new DirectoryInfo (Application.dataPath +"/Resources/ImagePrefabs");
    // 	foreach (FileInfo prefabFile in imagePrefabsDirInfo.GetFiles("*.prefab",SearchOption.AllDirectories)) {

    // 		string prefabName = prefabFile.Name.Remove(prefabFile.Name.IndexOf("."));
    // 		// string allPath = prefabFile.FullName;
    // 		// string aaaPath = allPath.Substring(allPath.IndexOf("Assets"));

    // 		if(prefabName == rawName)
    // 		{
    // 			//Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
    // 			Debug.LogWarning("The prefab is already exist :" + prefabFile.Name);
    // 			isFindedPrefab = true;
    // 			break;
    // 		}
    // 	}

    // 	if(!isFindedPrefab)
    // 	{
    // 		// string inAssetPath = assetPath.Substring(assetPath.IndexOf("/") + 1);
    // 		Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
    // 		SpriteToPrefab.CreatePrefabFromSprite(sprite, assetPath);
    // 	}

    // }
}
