using UnityEngine;
using UnityEngine.U2D;
using UnityEditor;
using System.IO;

public static class EditorContextMenu {


    [MenuItem("Assets/工具/Test", false, 100)]
    public static void Test() {

    }

    [MenuItem("Assets/工具/查看GUID", false, 100)]
    public static void CheckGUID() {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!string.IsNullOrEmpty(path)) {
            Debug.Log("GUID: " + AssetDatabase.AssetPathToGUID(path));
        }
        else {
            Debug.Log("找不到GUID");
        }
    }


    [MenuItem("Assets/工具/删除图片透明边框", false, 200)]
    public static void DeleteTransparentBorder() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.DeleteTransparentBorder(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture);
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片扩大到4的倍数", false, 300)]
    public static void StretchTextureToMultipleBy4() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.StretchTextureToMultipleBy4(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture);
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片扩大到2的N次方", false, 400)]
    public static void StretchNextTextureToPowerOf2() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.StretchTextureToPowerOf2(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture, "Next");
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片缩放到最接近2的N次方", false, 400)]
    public static void StretchClosestTextureToPowerOf2() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.StretchTextureToPowerOf2(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture, "Closest");
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片增加(透明)像素到4的倍数", false, 500)]
    public static void FillTextureAlphaToMultipleBy4() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        Color color = new Color(1, 1, 1, 0);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.FillTextureToMultipleBy4(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture, color);
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片增加(黑色)像素到4的倍数", false, 500)]
    public static void FillTextureBlackToMultipleBy4() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        Color color = new Color(0, 0, 0, 1);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.FillTextureToMultipleBy4(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture, color);
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/图片增加(白色)像素到4的倍数", false, 500)]
    public static void FillTextureWhiteToMultipleBy4() {
        Texture2D[] textures = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        Color color = new Color(1, 1, 1, 1);
        for (int i = 0; i < textures.Length; i++) {
            Texture2D texture = textures[i];
            CommonEditorTool.FillTextureToMultipleBy4(string.Format("{0} ({1}/{2})", texture.name, i + 1, textures.Length), texture, color);
        }
        EditorUtility.ClearProgressBar();
    }


    [MenuItem("Assets/工具/取消Mipmap", false, 600)]
    public static void ClearMipmap() {
        CommonEditorTool.ClearMipmap();
    }

    [MenuItem("Assets/工具/清空图集标签", false, 600)]
    public static void ClearPackingTag() {
        CommonEditorTool.ClearPackingTag();
    }

    [MenuItem("Assets/工具/加密文本文件", false, 600)]
    public static void EncryptFile() {
        DefaultAsset[] assets = Selection.GetFiltered<DefaultAsset>(SelectionMode.DeepAssets);
        int count = assets.Length;
        for (int i = 0; i < count; i++) {
            string path = AssetDatabase.GetAssetPath(assets[i]);
            EditorUtility.DisplayProgressBar("加密", path, (float)i / count);

            byte[] bytes = File.ReadAllBytes(path);
            try {
                bytes = TEAHelper.Encrypt(bytes, GameUtil.EncryptKeyBytes);
                File.WriteAllBytes(path, bytes);
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Assets/工具/解密文本文件", false, 600)]
    public static void DecryptFile() {
        DefaultAsset[] assets = Selection.GetFiltered<DefaultAsset>(SelectionMode.DeepAssets);
        int count = assets.Length;
        for (int i = 0; i < count; i++) {
            string path = AssetDatabase.GetAssetPath(assets[i]);
            EditorUtility.DisplayProgressBar("解密", path, (float)i / count);

            byte[] bytes = File.ReadAllBytes(path);
            try {
                bytes = TEAHelper.Decrypt(bytes, GameUtil.EncryptKeyBytes);
                File.WriteAllBytes(path, bytes);
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
        EditorUtility.ClearProgressBar();
    }


}
