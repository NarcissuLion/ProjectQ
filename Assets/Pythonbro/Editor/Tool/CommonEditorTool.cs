using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class CommonEditorTool {

    public static void OpenPersistentPath() {
        if (Application.platform == RuntimePlatform.WindowsEditor) {
            System.Diagnostics.Process.Start("explorer.exe", "/open," + Application.persistentDataPath.Replace("/", "\\"));
        }
    }

    public static void ClearPersistentPath() {
        if (Directory.Exists(Application.persistentDataPath)) {
            Directory.Delete(Application.persistentDataPath, true);
        }
    }

    public static void ClearPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    public static void ToggleUIRaycastGizmos() {
        GameObject obj = GameObject.Find("DebugUIRaycast");
        if (obj == null) {
            obj = new GameObject("DebugUIRaycast", new System.Type[] { typeof(DebugUIRaycast) });
            obj.hideFlags = HideFlags.DontSave;
        }
        else {
            Object.DestroyImmediate(obj);
        }
    }

    public static void ClearRaycastTarget() {
        foreach (GameObject obj in Selection.gameObjects) {
            Image[] images = obj.GetComponentsInChildren<Image>(true);
            foreach (Image image in images) {
                if (image.GetComponent<Button>() == null
                    && image.GetComponent<InputField>() == null
                    && image.GetComponent<ScrollRect>() == null
                    && image.GetComponent<Mask>() == null) {
                    image.raycastTarget = false;
                }
            }

            Text[] texts = obj.GetComponentsInChildren<Text>(true);
            foreach (Text text in texts) {
                text.raycastTarget = false;
            }

            RawImage[] rawImages = obj.GetComponentsInChildren<RawImage>(true);
            foreach (RawImage rawImage in rawImages) {
                rawImage.raycastTarget = false;
            }
            EditorUtility.SetDirty(obj);
        }
    }

    public static void ClearRendererShadow() {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) {
            return;
        }
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer renderer in renderers) {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.receiveShadows = false;
        }
    }

    public static void ClearMaterialSavedProperties() {
        EditorUtility.DisplayProgressBar("处理中", "查找中", 0);
        Material[] materials = Selection.GetFiltered<Material>(SelectionMode.DeepAssets);
        int count = materials.Length;

        for (int i = 0; i < count; i++) {
            Material material = materials[i];
            EditorUtility.DisplayProgressBar("处理中", material.name, (float)i / count);
            ClearMaterialSavedProperties(material);
        }
        AssetDatabase.Refresh();
        EditorUtility.ClearProgressBar();
    }

    public static void ClearMaterialSavedProperties(Material material) {
        SerializedObject obj = new SerializedObject(material);

        ProcessProperties(material, obj, "m_SavedProperties.m_TexEnvs");
        ProcessProperties(material, obj, "m_SavedProperties.m_Floats");
        ProcessProperties(material, obj, "m_SavedProperties.m_Colors");
        EditorUtility.SetDirty(material);
        System.GC.Collect();
    }

    private static void ProcessProperties(Material material, SerializedObject obj, string path) {
        var properties = obj.FindProperty(path);
        if (properties != null && properties.isArray) {
            for (int i = properties.arraySize - 1; i >= 0; i--) {
                string propName = properties.GetArrayElementAtIndex(i).FindPropertyRelative("first").stringValue;
                bool exist = material.HasProperty(propName);

                if (!exist) {
                    properties.DeleteArrayElementAtIndex(i);
                    obj.ApplyModifiedProperties();
                }
            }
        }
    }

    public static void ResetScale() {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) {
            return;
        }
        Transform[] transforms = obj.GetComponentsInChildren<Transform>(true);
        foreach (Transform transform in transforms) {
            transform.localScale = Vector3.one;
        }
    }

    public static void ClearMipmap() {
        Object[] objs = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        int textureCount = objs.Length;

        for (int i = 0; i < textureCount; i++) {
            Texture texture = objs[i] as Texture;
            string assetPath = AssetDatabase.GetAssetPath(texture);

            if (EditorUtility.DisplayCancelableProgressBar("处理(" + i + "/" + textureCount + ")", assetPath, (float)i / textureCount)) {
                break;
            }

            TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            textureImporter.mipmapEnabled = false;
            textureImporter.SaveAndReimport();
        }
        EditorUtility.ClearProgressBar();
    }

    public static void Image2RawImage() {
        GameObject[] objs = Selection.gameObjects;

        foreach (GameObject obj in objs) {
            Image image = obj.GetComponent<Image>();
            if (image != null) {
                Sprite sprite = image.sprite;
                bool raycastTarget = image.raycastTarget;
                Color color = image.color;

                Object.DestroyImmediate(image, true);
                RawImage rawImage = obj.AddComponent<RawImage>();

                rawImage.texture = sprite.texture;
                rawImage.raycastTarget = raycastTarget;
                rawImage.color = color;
            }
        }
    }

    public static void RoundRectTransform() {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) {
            return;
        }

        RectTransform[] transforms = obj.GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform transform in transforms) {
            transform.offsetMin = Round(transform.offsetMin);
            transform.offsetMax = Round(transform.offsetMax);
            transform.localScale = Round(transform.localScale);
        }
    }

    public static void RenameChildrenByNumber() {
        GameObject obj = Selection.activeGameObject;
        if (obj == null) {
            return;
        }
        Transform transform = Selection.activeGameObject.transform;
        int start = 1;
        string prefix = "";

        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (i == 0) {
                string name = child.name;
                if (name.EndsWith("0") || name.EndsWith("1")) {
                    start = int.Parse(name.Substring(name.Length - 1));
                    prefix = name.Substring(0, name.Length - 1);
                }
                else {
                    start = 1;
                    prefix = name;
                }
            }

            child.name = prefix + (start + i);
        }
    }

    public static void SelectSameNameNode() {
        GameObject[] objs = Selection.gameObjects;
        List<Object> list = new List<Object>();

        foreach (GameObject obj in objs) {
            if (obj.transform.parent == null || obj.transform.parent.parent == null) {
                continue;
            }

            Transform root = obj.transform.parent.parent;
            for (int i = 0; i < root.childCount; i++) {
                Transform child = root.GetChild(i).Find(obj.name);
                if (child != null) {
                    list.Add(child.gameObject);
                }
            }
        }

        Selection.objects = list.ToArray();
    }

    public static void ClearPackingTag() {
        EditorUtility.DisplayProgressBar("清除图集", "查找贴图", 0);
        Texture2D[] objs = Selection.GetFiltered<Texture2D>(SelectionMode.DeepAssets);
        int count = objs.Length;

        for (int i = 0; i < count; i++) {
            string path = AssetDatabase.GetAssetPath(objs[i]);
            EditorUtility.DisplayProgressBar("清除图集", path, (float)i / count);
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (string.IsNullOrEmpty(importer.spritePackingTag)) {
                continue;
            }
            importer.spritePackingTag = null;
            AssetDatabase.ImportAsset(path);
        }
        EditorUtility.ClearProgressBar();
    }

    public static void ImportLuaConfig() {
        ImportLuaConfig("local files = {", Application.streamingAssetsPath + "/Config");
        ImportLuaConfig("local sysFiles = {", Application.streamingAssetsPath + "/SysConfig");
    }

    private static void ImportLuaConfig(string startLine, string configPath) {
        string luaPath = Application.streamingAssetsPath + "/Lua/Config/ConfigManager.lua";
        string lua = File.ReadAllText(luaPath, Encoding.UTF8);

        int n1 = lua.IndexOf(startLine) + startLine.Length;
        int n2 = lua.IndexOf("}", n1);
        string start = lua.Substring(0, n1);
        //string middle = lua.Substring(n1, n2 - n1);
        string end = lua.Substring(n2);

        StringBuilder middle = new StringBuilder();

        string[] files = Directory.GetFiles(configPath, "*.json");
        int length = files.Length;
        for (int i = 0; i < length; i++) {
            string file = files[i];
            string name = Path.GetFileNameWithoutExtension(file);

            middle.Append("\r\n");
            middle.Append("\t\"" + name + "\"");
            if (i < length - 1) {
                middle.Append(",");
            }
            else {
                middle.Append("\r\n");
            }
        }

        File.WriteAllText(luaPath, start + middle.ToString() + end);
    }

    public static bool ResizeTexture(string title, Texture2D texture, string path, int width, int height) {
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

        TextureImporterCompression compression = importer.textureCompression;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.isReadable = true;
        importer.SaveAndReimport();

        bool success = TextureScale.Bilinear(texture, width, height);
        if (success) {
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }

        importer.textureCompression = compression;
        importer.isReadable = false;
        importer.SaveAndReimport();
        return success;
    }

    public static void FillTextureToMultipleBy4(string title, Texture2D texture, Color color) {
        string path = AssetDatabase.GetAssetPath(texture);

        int originW = texture.width;
        int originH = texture.height;

        int width = GetMultipleBy4(texture.width);
        int height = GetMultipleBy4(texture.height);

        if (width == originW && height == originH) {
            return;
        }

        int deltaW = width - originW;
        int deltaH = height - originH;

        Texture2D newTexture = new Texture2D(width, height);

        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

        TextureImporterCompression compression = importer.textureCompression;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.isReadable = true;
        importer.SaveAndReimport();

        int widthFrom = deltaW / 2;
        int widthTo = widthFrom + originW;
        int heightFrom = deltaH / 2;
        int heightTo = heightFrom + originH;

        int i = 0;
        for (int w = 0; w < width; w++) {
            for (int h = 0; h < height; h++) {
                i++;

                if (w >= widthFrom && w < widthTo && h >= heightFrom && h < heightTo) {
                    newTexture.SetPixel(w, h, texture.GetPixel(w - widthFrom, h - heightFrom));
                }
                else {
                    newTexture.SetPixel(w, h, color);
                }
                if (i % 64 == 0) {
                    EditorUtility.DisplayProgressBar(title, w + "," + h, (float)i / (width * height));
                }
            }
        }
        //EditorUtility.ClearProgressBar();

        byte[] bytes = newTexture.EncodeToPNG();
        Object.DestroyImmediate(newTexture);
        File.WriteAllBytes(path, bytes);

        importer.textureCompression = compression;
        importer.isReadable = false;
        importer.SaveAndReimport();
    }

    public static int GetMultipleBy4(int number) {
        int delta = number % 4;
        if (delta != 0) {
            return number + (4 - delta);
        }
        return number;
    }

    public static bool IsMultipleBy4(int number) {
        return number % 4 == 0;
    }

    public static int GetPowerOf2(int number, string method) {
        if (method == "Next") {
            return Mathf.NextPowerOfTwo(number);
        }
        else {
            return Mathf.ClosestPowerOfTwo(number);
        }
    }

    public static void StretchTextureToMultipleBy4(string title, Texture2D texture) {
        int originW = texture.width;
        int originH = texture.height;

        int width = GetMultipleBy4(texture.width);
        int height = GetMultipleBy4(texture.height);

        if (width == originW && height == originH) {
            return;
        }
        string path = AssetDatabase.GetAssetPath(texture);
        ResizeTexture(title, texture, path, width, height);
    }

    public static void StretchTextureToPowerOf2(string title, Texture2D texture, string method) {
        int originW = texture.width;
        int originH = texture.height;

        //// 已经是压缩格式的不能再改变
        //if(IsMultipleBy4(originW) && IsMultipleBy4(originH)) {
        //    return;
        //}

        int width = GetPowerOf2(texture.width, method);
        int height = GetPowerOf2(texture.height, method);

        if (width == originW && height == originH) {
            return;
        }
        string path = AssetDatabase.GetAssetPath(texture);
        ResizeTexture(title, texture, path, width, height);
    }

    public static void DeleteTransparentBorder(string title, Texture2D texture) {
        string path = AssetDatabase.GetAssetPath(texture);

        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

        TextureImporterCompression compression = importer.textureCompression;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.isReadable = true;
        importer.SaveAndReimport();

        int left = GetLeftTransparentCount(texture);
        int right = GetRightTransparentCount(texture);
        int bottom = GetBottomTransparentCount(texture);
        int top = GetTopTransparentCount(texture);
        //Debug.LogFormat("{0}, {1}, {2}, {3}", left, right, bottom, top);

        if (left > 0 || right > 0 || bottom > 0 || top > 0) {
            int width = texture.width - left - right;
            int height = texture.height - bottom - top;
            Texture2D newTexture = new Texture2D(width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Color color = texture.GetPixel(x + left, y + bottom);
                    newTexture.SetPixel(x, y, color);
                }
            }

            byte[] bytes = newTexture.EncodeToPNG();
            Object.DestroyImmediate(newTexture);
            File.WriteAllBytes(path, bytes);
        }

        importer.textureCompression = compression;
        importer.isReadable = false;
        importer.SaveAndReimport();
    }

    private static int GetLeftTransparentCount(Texture2D texture) {
        int count = 0;
        for (int x = 0; x < texture.width; x++) {
            for (int y = 0; y < texture.height; y++) {
                Color color = texture.GetPixel(x, y);
                if (color.a != 0) {
                    return count;
                }
            }
            count++;
        }
        return count;
    }

    private static int GetRightTransparentCount(Texture2D texture) {
        int count = 0;
        for (int x = texture.width - 1; x >= 0; x--) {
            for (int y = 0; y < texture.height; y++) {
                Color color = texture.GetPixel(x, y);
                if (color.a != 0) {
                    return count;
                }
            }
            count++;
        }
        return count;
    }

    private static int GetBottomTransparentCount(Texture2D texture) {
        int count = 0;
        for (int y = 0; y < texture.height; y++) {
            for (int x = 0; x < texture.width; x++) {
                Color color = texture.GetPixel(x, y);
                if (color.a != 0) {
                    return count;
                }
            }
            count++;
        }
        return count;
    }

    private static int GetTopTransparentCount(Texture2D texture) {
        int count = -1;
        for (int y = texture.height - 1; y >= 0; y--) {
            for (int x = 0; x < texture.width; x++) {
                Color color = texture.GetPixel(x, y);
                if (color.a != 0) {
                    return count;
                }
            }
            count++;
        }
        return count;
    }

    public static string AbsolutePathToAssetPath(string path) {
        if (path.StartsWith("Assets")) {
            return path;
        }
        path = "Assets" + path.Substring(Application.dataPath.Length);
        return path.Replace("\\", "/");
    }

    public static string AssetPathToAbsolutePath(string path) {
        if (!path.StartsWith("Assets")) {
            return path;
        }
        path = Application.dataPath + path.Substring("Assets".Length);
        return path.Replace("\\", "/");
    }

    // Object -> GUID
    public static string FindGUID(Object obj) {
        if (obj == null) {
            return null;
        }
        string path = AssetDatabase.GetAssetPath(obj);
        return AssetDatabase.AssetPathToGUID(path);
    }

    // GUID -> Object
    public static Object FindObject(string guid) {
        if (string.IsNullOrEmpty(guid)) {
            return null;
        }
        string path = AssetDatabase.GUIDToAssetPath(guid);
        if (string.IsNullOrEmpty(path)) {
            return null;
        }
        return AssetDatabase.LoadAssetAtPath<Object>(path);
    }

    public static Vector2 Round(Vector2 vec) {
        vec.x = Mathf.Round(vec.x * 10) * 0.1f;
        vec.y = Mathf.Round(vec.y * 10) * 0.1f;
        return vec;
    }

    public static Vector3 Round(Vector3 vec) {
        vec.x = Mathf.Round(vec.x * 10) * 0.1f;
        vec.y = Mathf.Round(vec.y * 10) * 0.1f;
        vec.z = Mathf.Round(vec.z * 10) * 0.1f;
        return vec;
    }

    public static string[] GetSelectFiles(string searchPattern) {
        if (Selection.activeObject == null) {
            return null;
        }
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (File.Exists(path)) {
            return new string[] { path };
        }
        else {
            string dir = Path.GetDirectoryName(path);
            return Directory.GetFiles(dir, searchPattern, SearchOption.AllDirectories);
        }
    }

}
