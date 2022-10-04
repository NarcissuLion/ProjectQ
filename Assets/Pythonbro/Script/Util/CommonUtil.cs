using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using UnityEngine.Video;

/// <summary>
/// 一般工具类
/// </summary>
public static class CommonUtil {

    public delegate void AsyncResult(bool success);
    public delegate void OnToggleChange(bool isOn);
    public delegate void OnInputFieldChange(string value);
    public delegate void OnDropdownChange(int value);

    //public static readonly string ASSEMBLY_UNITY = "UnityEngine";
    //public static readonly string ASSEMBLY_CSHARP = "Assembly-CSharp";

    /// <summary>
    /// 查找子节点，path为空则返回parent自身
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Transform GetChild(Object parent, string path) {
        if (parent == null) {
            return null;
        }
        bool isSelf = string.IsNullOrEmpty(path);
        if (parent is Transform) {
            return isSelf ? (Transform)parent : ((Transform)parent).Find(path);
        }
        else if (parent is GameObject) {
            return isSelf ? ((GameObject)parent).transform : ((GameObject)parent).transform.Find(path);
        }
        else if (parent is Component) {
            return isSelf ? ((Component)parent).transform : ((Component)parent).transform.Find(path);
        }
        return null;
    }

    public static bool HasChild(Object parent, string path) {
        return GetChild(parent, path) != null;
    }

    public static Transform GetTransform(Object parent, string path) {
        return GetChild(parent, path);
    }

    public static GameObject GetGameObject(Object parent, string path) {
        if(parent == null) {
            return null;
        }
        bool isSelf = string.IsNullOrEmpty(path);
        if(isSelf) {
            if (parent is GameObject) {
                return parent as GameObject;
            }
            else if (parent is Transform) {
                return (parent as Transform).gameObject;
            }
            else if (parent is Component) {
                return (parent as Component).gameObject;
            }
        }
        Transform transform = GetChild(parent, path);
        return transform == null ? null : transform.gameObject;
    }

    /// <summary>
    /// 得到子控件，path为空则返回自身控件
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Component GetComponent(Object parent, string path, string type) {
        Transform transform = GetChild(parent, path);
        return transform != null ? transform.GetComponent(type) : null;
    }

    /// <summary>
    /// 得到第(index + 1)个子节点，index从0开始
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Transform GetChildAt(Object parent, string path, int index) {
        Transform transform = GetTransform(parent, path);
        if(transform != null && transform.childCount > index) {
            return transform.GetChild(index);
        }
        return null;
    }

    /// <summary>
    /// 得到指定程序集下的一个类型描述
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="typeAssembly"></param>
    /// <param name="version"></param>
    /// <param name="culture"></param>
    /// <param name="publicKeyToken"></param>
    /// <returns></returns>
    public static string GetAssemblyQualifiedName(string typeName, string typeAssembly, string version = "0.0.0.0", string culture = "neutral", string publicKeyToken = "null") {
        return string.Format("{0}, {1}, Version={2}, Culture={3}, PublicKeyToken={4}", typeName, typeAssembly, version, culture, publicKeyToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeName">类型全名，例如UnityEngine.Material</param>
    /// <returns></returns>
    public static System.Type GetTypeByName(string typeName) {
        System.Type type = System.Type.GetType(typeName, false);
        if (type != null) {
            return type;
        }

        if (typeName == "UnityEngine.Material") {
            return typeof(Material);
        }
        else if (typeName == "UnityEngine.Texture2D") {
            return typeof(Texture2D);
        }
        else if (typeName == "UnityEngine.Sprite") {
            return typeof(Sprite);
        }
        else if (typeName == "UnityEngine.Renderer") {
            return typeof(Renderer);
        }
        else if (typeName == "UnityEngine.UI.Image") {
            return typeof(Image);
        }
        else if (typeName == "UnityEngine.UI.RawImage") {
            return typeof(RawImage);
        }
        else if (typeName == "UnityEngine.UI.Text") {
            return typeof(Text);
        }
        else if (typeName == "UnityEngine.Transform") {
            return typeof(Transform);
        }
        else if (typeName == "UnityEngine.AudioClip")
        {
            return typeof(AudioClip);
        }
        //Debug.LogErrorFormat("Type not found: {0}", typeName);
        return null;
    }

    public static Component GetComponentInChildren(Object parent, string path, string type) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            System.Type componentType = GetTypeByName(type);
            return transform.GetComponentInChildren(componentType, true);
        }
        return null;
    }

    /// <summary>
    /// 得到所有指定类型的子控件
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="type">控件类型FullName</param>
    /// <param name="assembly">UnityEngine或者Assembly-CSharp</param>
    /// <param name="includeInactive">是否包含未激活的</param>
    /// <returns></returns>
    public static Component[] GetComponentsInChildren(Object parent, string path, string type, bool includeInactive) {
        Transform child = GetChild(parent, path);
        if (child != null) {
            //string assemblyQualifiedName = GetAssemblyQualifiedName(type, assembly);
            //System.Type componentType = System.Type.GetType(assemblyQualifiedName, false);
            System.Type componentType = GetTypeByName(type);
            if (componentType != null) {
                return child.GetComponentsInChildren(componentType, includeInactive);
            }
            else {
                Debug.LogErrorFormat("Invalid component, type: {0}", type);
            }
        }
        return new Component[0];
    }

    /// <summary>
    /// 同上，注意泛型方法不会导出到lua
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T GetComponent<T>(Object parent, string path) where T : Component {
        if(string.IsNullOrEmpty(path) && parent is T) {
            return parent as T;
        }
        if(string.IsNullOrEmpty(path) && parent is T) {
            return parent as T;
        }
        Transform transform = GetChild(parent, path);
        return transform != null ? transform.GetComponent<T>() : null;
    }

    /// <summary>
    /// 同上，注意泛型方法不会导出到lua
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="autoAdd">目标上没有T组件时是否自动添加一个</param>
    /// <returns></returns>
    public static T GetComponent<T>(Object parent, string path, bool autoAdd) where T : Component {
        GameObject gameObject = GetGameObject(parent, path);
        if(gameObject != null) {
            T com = gameObject.GetComponent<T>();
            if(com == null && autoAdd) {
                com = gameObject.AddComponent<T>();
            }
            return com;
        }
        return null;
    }

    public static Component AddComponent(Object parent, string path, string type, bool allowMultiple) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            try {
                //string assemblyQualifiedName = GetAssemblyQualifiedName(type, assembly);
                //System.Type componentType = System.Type.GetType(assemblyQualifiedName, false);
                System.Type componentType = GetTypeByName(type);

                if (componentType != null) {
                    if (allowMultiple) {
                        return transform.gameObject.AddComponent(componentType);
                    }
                    Component com = transform.GetComponent(componentType);
                    return com != null ? com : transform.gameObject.AddComponent(componentType);
                }
                else {
                    Debug.LogErrorFormat("Invalid component, type: {0}", type);
                }
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
        return null;
    }

    private static Transform GetTransform(Object obj) {
        if (obj != null) {
            if (obj is GameObject) {
                return (obj as GameObject).transform;
            }
            else if (obj is Transform) {
                return obj as Transform;
            }
            else if (obj is Component) {
                return (obj as Component).transform;
            }
        }
        return null;
    }

    private static GameObject GetGameObject(Object obj) {
        if (obj != null) {
            if (obj is GameObject) {
                return obj as GameObject;
            }
            else if (obj is Transform) {
                return (obj as Transform).gameObject;
            }
            else if (obj is Component) {
                return (obj as Component).gameObject;
            }
        }
        return null;
    }

    /// <summary>
    /// 删除一个子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    public static void DestroyChild(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            Object.Destroy(transform.gameObject);
        }
    }

    /// <summary>
    /// 立即删除一个子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    public static void DestroyChildImmediate(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            Object.DestroyImmediate(transform.gameObject, true);
        }
    }

    /// <summary>
    /// 删除所有子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    public static void DestroyChildren(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (transform.childCount > 0) {
                for (int i = transform.childCount - 1; i >= 0; i--) {
                    Object.Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }

    /// <summary>
    /// 立即删除所有子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    public static void DestroyChildrenImmediate(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (transform.childCount > 0) {
                for (int i = transform.childCount - 1; i >= 0; i--) {
                    Object.DestroyImmediate(transform.GetChild(i).gameObject, true);
                }
            }
        }
    }

    /// <summary>
    /// 删除超过指定数量的子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="limit"></param>
    /// <param name="updown">从上向下</param>
    public static void DestroyLimitChildren(Object parent, string path, int limit, bool updown) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (updown) {
                for (int i = transform.childCount - limit; i > 0; i--) {
                    if (i > 0) {
                        Object.Destroy(transform.GetChild(i - 1).gameObject);
                    }
                }
            }
            else {
                for (int i = transform.childCount; i > limit; i--) {
                    Object.Destroy(transform.GetChild(i - 1).gameObject);
                }
            }
        }
    }

    public static void SetRendererShadow(Object parent, string path, bool cast, bool receive, bool withChildren) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (!withChildren) {
                Renderer renderer = transform.GetComponent<Renderer>();
                if (renderer != null) {
                    renderer.shadowCastingMode = cast ? ShadowCastingMode.On : ShadowCastingMode.Off;
                    renderer.receiveShadows = receive;
                }
            }
            else {
                Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers) {
                    renderer.shadowCastingMode = cast ? ShadowCastingMode.On : ShadowCastingMode.Off;
                    renderer.receiveShadows = receive;
                }
            }
        }
    }

    public static void ForceLayout(Object parent, string path) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform);
        }
    }

    public static void RepairLayout(Object parent, string path)
    {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null)
        {
            transform.localPosition += Vector3.up;
            transform.localPosition -= Vector3.up;                
        }
    }

    public static void SetParent(Object child, Object parent, bool worldPosStays) {
        Transform c = GetTransform(child);
        Transform p = GetTransform(parent);
        if (c != null) {
            c.SetParent(p, worldPosStays);
        }
    }

    public static void SetParentByPath(Object childRoot, string childPath, Object parentRoot, string parentPath, bool worldPosStays) {
        Transform child = GetChild(childRoot, childPath);
        Transform parent = GetChild(parentRoot, parentPath);
        if (child != null) {
            child.SetParent(parent, worldPosStays);
        }
    }

    public static void SetAsLastSibling(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.SetAsLastSibling();
        }
    }

    public static void SetAsFirstSibling(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.SetAsFirstSibling();
        }
    }

    public static void SetSiblingIndex(Object parent, string path, int index) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.SetSiblingIndex(index);
        }
    }

    public static int GetSiblingIndex(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            return transform.GetSiblingIndex();
        }
        return -1;
    }

    public static void SetActive(Object parent, string path, bool active) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.gameObject.SetActive(active);
        }
    }

    public static void ToggleActive(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.gameObject.SetActive(!transform.gameObject.activeSelf);
        }
    }

    public static void SetChildrenActive(Object parent, string path, bool active) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(active);
            }
        }
    }

    public static void SetGrayStyle(Object parent, string path, bool isGray, bool withChildren) {
        Transform transform = GetChild(parent, path);
        if(transform != null) {
            //Material material = isGray ? Resources.Load<Material>("Material/UI-Grayscale") : null;
            Material material = isGray ? GameUtil.LoadPrefabMaterial("Prefab/UI/Common/Other/UI-Grayscale") : null;

            if (withChildren) {
                Image[] images = transform.GetComponentsInChildren<Image>(true);
                foreach (Image image in images) {
                    image.material = material;
                }
                Text[] texts = transform.GetComponentsInChildren<Text>(true);
                foreach (Text test in texts) {
                    test.material = material;
                }
            } else {
                Image image = transform.GetComponent<Image>();
                if(image != null) {
                    image.material = material;
                }
                Text text = transform.GetComponent<Text>();
                if (text != null) {
                    text.material = material;
                }
            }
        }
    }

    private static void SetComponentEnabled(Component com, bool enabled) {
        if (com is Behaviour) {
            (com as Behaviour).enabled = enabled;
        }
        else if (com is Renderer) {
            (com as Renderer).enabled = enabled;
        }
        else if (com is Collider) {
            (com as Collider).enabled = enabled;
        }
        else {
            Debug.LogError("Unknown component type");
        }
    }

    public static void SetComponentEnabled(Object parent, string path, string type, bool enabled) {
        Component com = GetComponent(parent, path, type);
        if(com != null) {
            SetComponentEnabled(com, enabled);
        }
    }

    public static void SetChildrenComponentsEnabled(Object parent, string path, string type, bool enabled) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            try {
                //string assemblyQualifiedName = GetAssemblyQualifiedName(type, assembly);
                //System.Type componentType = System.Type.GetType(assemblyQualifiedName, false);
                System.Type componentType = GetTypeByName(type);

                if (componentType != null) {
                    Component[] coms = transform.GetComponentsInChildren(componentType);
                    foreach(Component com in coms) {
                        SetComponentEnabled(com, enabled);
                    }
                }
                else {
                    Debug.LogErrorFormat("Invalid component, type: {0}", type);
                }
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
    }

    public static void SetButtonEnabled(Object parent, string path, bool enabled) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            com.enabled = enabled;
        }
    }

    public static void SetImageEnabled(Object parent, string path, bool enabled) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            com.enabled = enabled;
        }
    }

    public static void SetRawImageEnabled(Object parent, string path, bool enabled) {
        RawImage com = GetComponent<RawImage>(parent, path);
        if (com != null) {
            com.enabled = enabled;
        }
    }

    public static void SetTextEnabled(Object parent, string path, bool enabled) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.enabled = enabled;
        }
    }

    public static void SetAnimatorEnabled(Object parent, string path, bool enabled) {
        Animator com = GetComponent<Animator>(parent, path);
        if (com != null) {
            com.enabled = enabled;
        }
    }

    public static void AddButtonClick(Object parent, string path, UnityAction action) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            //Animator animator = GetComponent<Animator>(com, null, true);
            //animator.runtimeAnimatorController = GameUtil.LoadPrefabAnimatorController("Prefab/UI/Common/Other/ButtonAnimation/ButtonAnimation");

            com.onClick.RemoveAllListeners();
            com.onClick.AddListener(() => {
                action.Invoke();
                //if (ConfigManager.ButtonInterval <= 0) {
                //    action.Invoke();
                //}
                //else {
                //    // 防止连点
                //    if (ContinuousEventBlocker.Trigger("ButtonClick" + com.GetInstanceID(), 100)) {
                //        action.Invoke();
                //    }
                //}
            });
        }
    }

    public static void RemoveButtonClick(Object parent, string path) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            com.onClick.RemoveAllListeners();
        }
    }

    public static void AddButtonClickWithoutRemove(Object parent, string path, UnityAction action) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            com.onClick.AddListener(action);
        }
    }

    public static void InvokeButtonClick(Object parent, string path) {
        Button com = GetComponent<Button>(parent, path);
        if(com != null) {
            com.onClick.Invoke();
        }
    }

    public static void AddToggleClick(Object parent, string path, OnToggleChange onChange) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.onValueChanged.AddListener((isOn)=> {
                if (onChange != null) {
                    onChange.Invoke(isOn);
                }
            });
        }
    }

    public static void SetToggleValue(Object parent, string path, bool isOn) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.isOn = isOn;
        }
    }

    public static bool GetToggleValue(Object parent, string path) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            return com.isOn;
        }
        return false;
    }

    public static void SetToggleGroupByPath(Object parent, string path, Object groupParent, string groupPath) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.group = GetComponent<ToggleGroup>(groupParent, groupPath);
        }
    }

    public static void SetToggleGroup(Object parent, string path, Object group) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.group = GetComponent<ToggleGroup>(group, null);
        }
    }

    public static void SetToggleGraphicByPath(Object parent, string path, Object graphicParent, string graphicPath) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.graphic = GetComponent<Graphic>(graphicParent, graphicPath);
        }
    }

    public static void SetToggleGraphic(Object parent, string path, Object graphic) {
        Toggle com = GetComponent<Toggle>(parent, path);
        if (com != null) {
            com.graphic = GetComponent<Graphic>(graphic, null);
        }
    }

    public static void AddDropdownOptions(Object parent, string path, string options, bool clear) {
        Dropdown dropdown = GetComponent<Dropdown>(parent, path);
        if (dropdown != null) {
            if (clear) {
                dropdown.ClearOptions();
            }
            try {
                List<string> list = JsonUtil.ParseJsonObject<List<string>>(options);
                dropdown.AddOptions(list);
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
    }

    public static void AddDropdownOnChange(Object parent, string path, OnDropdownChange onChange) {
        Dropdown dropdown = GetComponent<Dropdown>(parent, path);
        if (dropdown != null) {
            dropdown.onValueChanged.AddListener((value) => {
                if (onChange != null) {
                    onChange.Invoke(value);
                }
            });
        }
    }

    public static int GetDropdownValue(Object parent, string path) {
        Dropdown dropdown = GetComponent<Dropdown>(parent, path);
        if (dropdown != null) {
            return dropdown.value;
        }
        return -1;
    }

    public static void SetDropdownInteractable(Object parent, string path, bool interactable) {
        Dropdown dropdown = GetComponent<Dropdown>(parent, path);
        if (dropdown != null) {
            dropdown.interactable = interactable;
        }
    }

    public static void AddInputFieldOnChange(Object parent, string path, OnInputFieldChange onChange) {
        InputField com = GetComponent<InputField>(parent, path);
        if(com != null) {
            com.onValueChanged.AddListener((value) => {
                if (onChange != null) {
                    onChange.Invoke(value);
                }
            });
        }
    }

    public static string GetText(Object parent, string path) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            return com.text;
        }
        return null;
    }

    public static Color GetTextColor(Object parent, string path) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            return com.color;
        }
        return default(Color);
    }

    public static void SetText(Object parent, string path, string text) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.text = text;
        }
    }

    public static void SetTextFont(Object parent, string path, Font font) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.font = font;
        }
    }

    public static void SetTextFontSize(Object parent, string path, int fontSize) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.fontSize = fontSize;
        }
    }

    public static void SetTextColor(Object parent, string path, Color color) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.color = color;
        }
    }

    public static void SetTextAndColor(Object parent, string path, string text, Color color) {
        Text com = GetComponent<Text>(parent, path);
        if (com != null) {
            com.text = text;
            com.color = color;
        }
    }

    //public static void SetTextQuality(Object parent, string path, int quality) {
    //    QualityText com = GetComponent<QualityText>(parent, path);
    //    if (com != null) {
    //        com.quality = quality;
    //    }
    //}

    //public static void SetTextAndQuality(Object parent, string path, string text, int quality) {
    //    QualityText com = GetComponent<QualityText>(parent, path);
    //    if (com != null) {
    //        com.quality = quality;
    //        com.GetComponent<Text>().text = text;
    //    }
    //    else {
    //        SetText(parent, path, text);
    //    }
    //}

    public static void SetTextMesh(Object parent, string path, string text) {
        TextMesh com = GetComponent<TextMesh>(parent, path);
        if (com != null) {
            com.text = text;
        }
    }

    public static string GetTextMesh(Object parent, string path) {
        TextMesh com = GetComponent<TextMesh>(parent, path);
        if (com != null) {
            return com.text;
        }
        return null;
    }

    public static void SetTextMeshColor(Object parent, string path, Color color) {
        TextMesh com = GetComponent<TextMesh>(parent, path);
        if (com != null) {
            com.color = color;
        }
    }

    public static Color GetTextMeshColor(Object parent, string path) {
        TextMesh com = GetComponent<TextMesh>(parent, path);
        if (com != null) {
            return com.color;
        }
        return default(Color);
    }

    public static void SetImage(Object parent, string path, Sprite sprite) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            com.sprite = sprite;
            FitImageAspect(com, null);
        }
    }

    //public static void SetImageByPrefab(Object parent, string path, string imagePrefabPath) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.SetImage(imagePrefabPath);
    //    }
    //}

    //public static void SetImageByPrefabAsync(Object parent, string path, string imagePrefabPath) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.SetImageAsync(imagePrefabPath);
    //    }
    //}

    //public static void ClearAsyncImage(Object parent, string path) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.ClearImage();
    //    }
    //}

    public static Sprite GetImage(Object parent, string path) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            return com.sprite;
        }
        return null;
    }

    public static void SetImageColor(Object parent, string path, Color color) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            com.color = color;
        }
    }

    public static void SetImageAutoEnable(Object parent, string path, Sprite sprite) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            com.sprite = sprite;
            com.enabled = sprite != null;
            if (sprite != null) {
                FitImageAspect(com, null);
            }
        }
    }

    public static void SetRawImage(Object parent, string path, Texture texture) {
        RawImage com = GetComponent<RawImage>(parent, path);
        if (com != null) {
            com.texture = texture;
        }
    }

    //public static void SetRawImageByPrefab(Object parent, string path, string imagePrefabPath) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.SetRawImage(imagePrefabPath);
    //    }
    //}

    //public static void SetRawImageByPrefabAsync(Object parent, string path, string imagePrefabPath) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.SetRawImageAsync(imagePrefabPath);
    //    }
    //}

    //public static void ClearAsyncRawImage(Object parent, string path) {
    //    ImageHelper imageHelper = GetComponent<ImageHelper>(parent, path, true);
    //    if (imageHelper != null) {
    //        imageHelper.ClearRawImage();
    //    }
    //}

    public static Texture GetRawImage(Object parent, string path) {
        RawImage com = GetComponent<RawImage>(parent, path);
        if (com != null) {
            return com.texture;
        }
        return null;
    }

    public static void SetRawImageColor(Object parent, string path, Color color) {
        RawImage com = GetComponent<RawImage>(parent, path);
        if (com != null) {
            com.color = color;
        }
    }

    public static void SetRawImageAutoEnable(Object parent, string path, Texture texture) {
        RawImage com = GetComponent<RawImage>(parent, path);
        if (com != null) {
            com.texture = texture;
            com.enabled = texture != null;
        }
    }

    public static void SetSprite(Object parent, string path, Sprite sprite) {
        SpriteRenderer com = GetComponent<SpriteRenderer>(parent, path);
        if (com != null) {
            com.sprite = sprite;
        }
    }

    public static Sprite GetSprite(Object parent, string path) {
        SpriteRenderer com = GetComponent<SpriteRenderer>(parent, path);
        if (com != null) {
            return com.sprite;
        }
        return null;
    }

    public static void SetSpriteColor(Object parent, string path, Color color) {
        SpriteRenderer com = GetComponent<SpriteRenderer>(parent, path);
        if (com != null) {
            com.color = color;
        }
    }

    public static Color GetSpriteColor(Object parent, string path) {
        SpriteRenderer com = GetComponent<SpriteRenderer>(parent, path);
        if (com != null) {
            return com.color;
        }
        return default(Color);
    }

    public static void FitImageAspect(Object parent, string path) {
        ImageAspectRatioFitter com = GetComponent<ImageAspectRatioFitter>(parent, path);
        if (com != null) {
            com.Fit();
        }
    }

    public static void SetImageFillAmount(Object parent, string path, float fillAmount) {
        Image com = GetComponent<Image>(parent, path);
        if (com != null) {
            com.fillAmount = fillAmount;
        }
    }

    public static void SetAudioClip(Object parent, string path, AudioClip clip) {
        AudioSource com = GetComponent<AudioSource>(parent, path);
        if (com != null) {
            com.clip = clip;
        }
    }

    public static void SetBtnInteractable(Object parent, string path, bool interactable) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            com.interactable = interactable;
        }
    }

    public static void ToggleBtnInteractable(Object parent, string path) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            com.interactable = !com.interactable;
        }
    }

    public static void SetButtonTargetGraphic(Object parent, string path, Object target, string targetPath) {
        Button com = GetComponent<Button>(parent, path);
        if (com != null) {
            Transform targetTransform = GetChild(target, targetPath);
            if(targetTransform != null) {
                Graphic graphic = targetTransform.GetComponent<Graphic>();
                if(graphic == null) {
                    graphic = targetTransform.GetComponentInChildren<Graphic>();
                }
                com.targetGraphic = graphic;
            }
        }
    }

    public static void SetScrollbarPosition(Object parent, string path, float value) {
        Scrollbar com = GetComponent<Scrollbar>(parent, path);
        if (com != null) {
            com.value = value;
        }
    }

    public static void SetInputFieldText(Object parent, string path, string text) {
        InputField com = GetComponent<InputField>(parent, path);
        if (com != null) {
            com.text = text;
        }
    }

    public static string GetInputFieldText(Object parent, string path) {
        InputField com = GetComponent<InputField>(parent, path);
        if (com != null) {
            return com.text;
        }
        return null;
    }

    public static void SetInputFieldContentType(Object parent, string path, string type) {
        InputField com = GetComponent<InputField>(parent, path);
        if (com != null) {
            try {
                com.contentType = (InputField.ContentType)System.Enum.Parse(typeof(InputField.ContentType), type, true);
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
    }

    public static bool ToggleInputFieldPasswordType(Object parent, string path) {
        InputField com = GetComponent<InputField>(parent, path);
        if (com != null) {
            com.contentType = com.contentType == InputField.ContentType.Password ? InputField.ContentType.Standard : InputField.ContentType.Password;
            com.ForceLabelUpdate();
            return com.contentType == InputField.ContentType.Standard;
        }
        return false;
    }

    public static void ForceRebuildLayoutImmediate(Object parent, string path) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform);
        }
    }

    public static bool IsActiveSelf(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        return transform != null ? transform.gameObject.activeSelf : false;
    }

    public static void SetIgnoreLayout(Object parent, string path, bool ignore) {
        LayoutElement com = GetComponent<LayoutElement>(parent, path);
        if (com != null) {
            com.ignoreLayout = ignore;
        }
    }

    public static void SetLayoutPadding(Object parent, string path, int left, int right, int top, int bottom) {
        LayoutGroup com = GetComponent<LayoutGroup>(parent, path);
        if (com != null) {
            com.padding = new RectOffset(left, right, top, bottom);
        }
    }

    /// <summary>
    /// 通过LayoutElement重置对象的RectTransform，用于重置被自动布局组件改变了RectTransform值的情况
    /// </summary>
    /// <param name="obj"></param>
    public static void ResetRectTransformByLayout(Object parent, string path) {
        LayoutElement layout = GetComponent<LayoutElement>(parent, path);
        if (layout != null) {
            RectTransform transform = layout.transform as RectTransform;
            transform.anchorMin = new Vector2(0.5f, 0.5f);
            transform.anchorMax = new Vector2(0.5f, 0.5f);
            transform.pivot = new Vector2(0.5f, 0.5f);
            transform.anchoredPosition = Vector2.zero;
            transform.sizeDelta = new Vector2(layout.preferredWidth, layout.preferredHeight);
        }
    }

    /// <summary>
    /// Transform归零
    /// </summary>
    /// <param name="obj"></param>
    public static void ZeroTransform(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
    }

    /// <summary>
    /// RectTransform归零
    /// </summary>
    /// <param name="obj"></param>
    public static void ZeroRectTransform(Object parent, string path) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            transform.anchoredPosition = Vector2.zero;
            transform.anchorMin = new Vector2(0.5f, 0.5f);
            transform.anchorMax = new Vector2(0.5f, 0.5f);
            transform.pivot = new Vector2(0.5f, 0.5f);
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
    }

    public static void ZeroRectTransformAnchorPivot(Object parent, string path) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            Vector3 pos = transform.localPosition;
            transform.anchorMin = new Vector2(0.5f, 0.5f);
            transform.anchorMax = new Vector2(0.5f, 0.5f);
            transform.pivot = new Vector2(0.5f, 0.5f);
            transform.localPosition = pos;
        }
    }

    public static void StretchRectTransform(Object parent, string path) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            transform.anchoredPosition = Vector2.zero;
            transform.pivot = new Vector2(0.5f, 0.5f);
            transform.anchorMin = new Vector2(0, 0);
            transform.anchorMax = new Vector2(1, 1);
            transform.offsetMin = new Vector2(0, 0);
            transform.offsetMax = new Vector2(0, 0);
        }
    }

    public static Material GetRendererMateiral(Object parent, string path) {
        Renderer renderer = GetComponent<Renderer>(parent, path);
        if (renderer != null) {
            return renderer.material;
        }
        return null;
    }

    public static void SetRendererMaterial(Object parent, string path, Material material) {
        Renderer renderer = GetComponent<Renderer>(parent, path);
        if (renderer != null) {
            renderer.material = material;
        }
    }

    public static void PlayParticle(Object parent, string path, bool withChildren) {
        ParticleSystem ps = GetComponent<ParticleSystem>(parent, path);
        if (ps != null) {
            ps.Play(withChildren);
        }
    }

    public static void StopParticle(Object parent, string path, bool withChildren) {
        ParticleSystem ps = GetComponent<ParticleSystem>(parent, path);
        if (ps != null) {
            ps.Stop(withChildren, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    public static void StopAndClearParticle(Object parent, string path, bool withChildren) {
        ParticleSystem ps = GetComponent<ParticleSystem>(parent, path);
        if (ps != null) {
            ps.Stop(withChildren, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    public static void SetParticlePlay(Object parent, string path, bool isPlay, bool withChildren) {
        ParticleSystem ps = GetComponent<ParticleSystem>(parent, path);
        if (ps != null) {
            if (isPlay) {
                ps.Play(withChildren);
            }
            else {
                ps.Stop(withChildren);
            }
        }
    }

    public static void PauseParticles(Object parent, string path, bool isPause) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            ParticleSystem[] particles = transform.GetComponentsInChildren<ParticleSystem>(true);
            foreach (ParticleSystem ps in particles) {
                ParticleSystem.MainModule main = ps.main;
                main.simulationSpeed = isPause ? 0 : 1;
            }
        }
    }

    public static void SetParticleStartColor(Object parent, string path, Color startColor) {
        ParticleSystem ps = GetComponent<ParticleSystem>(parent, path);
        if (ps != null) {
            ParticleSystem.MainModule main = ps.main;
            main.startColor = startColor;
        }
    }

    public static void SetCameraColor(Object parent, string path, Color color) {
        Camera camera = GetComponent<Camera>(parent, path);
        if (camera != null) {
            camera.backgroundColor = color;
        }
    }

    public static bool IsOverlapsViewport(RectTransform transform, RectTransform viewport, Camera uiCamera, bool isScreenOverlay) {
        Vector2 point = transform.position;
        if (!isScreenOverlay) {
            point = RectTransformUtility.WorldToScreenPoint(uiCamera, transform.position);
        }
        return RectTransformUtility.RectangleContainsScreenPoint(viewport, point, uiCamera);
    }


    #region DOTween
    private static Ease GetDOEase(string ease) {
        try {
            if (!string.IsNullOrEmpty(ease)) {
                return (Ease)System.Enum.Parse(typeof(Ease), ease, true);
            }
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
        return Ease.OutQuad;
    }

    private static RotateMode GetRotateMode(string rotateMode) {
        try {
            if (!string.IsNullOrEmpty(rotateMode)) {
                return (RotateMode)System.Enum.Parse(typeof(RotateMode), rotateMode, true);
            }
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
        return RotateMode.Fast;
    }

    public static void DOKill(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.DOKill();
        }
    }

    public static void DOPlay(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.DOPlay();
        }
    }

    public static void DOTweenAnimationPlay(Object parent, string path) {
        DOTweenAnimation animation = GetComponent<DOTweenAnimation>(parent, path);
        if (animation != null) {
            animation.DOPlay();
        }
    }

    public static void DOShake(Object parent, string path, float duration, float strength, int vibrato) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.DOShakePosition(duration, Vector3.one * strength, vibrato);
        }
    }
    public static void DOShakeAnchorPos(Object parent, string path, float duration, float strength, int vibrato) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            transform.DOShakeAnchorPos(duration, Vector3.one * strength, vibrato);
        }
    }

    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="angles"></param>
    /// <param name="duration"></param>
    /// <param name="ease">过渡类型，默认OutQuad</param>
    /// <param name="rotateMode">旋转类型，默认Fast</param>
    public static void DOLocalRotate(Object parent, string path, Vector3 angles, float duration, string ease, string rotateMode) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                transform.localEulerAngles = angles;
            }
            else {
                transform.DOLocalRotate(angles, duration, GetRotateMode(rotateMode)).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOScale(Object parent, string path, Vector3 scale, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                transform.localScale = scale;
            }
            else {
                transform.DOScale(scale, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOScaleX(Object parent, string path, float x, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 scale = transform.localScale;
                scale.x = x;
                transform.localScale = scale;
            }
            else {
                transform.DOScaleX(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOScaleY(Object parent, string path, float y, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 scale = transform.localScale;
                scale.y = y;
                transform.localScale = scale;
            }
            else {
                transform.DOScaleY(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOScaleZ(Object parent, string path, float z, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 scale = transform.localScale;
                scale.z = z;
                transform.localScale = scale;
            }
            else {
                transform.DOScaleZ(z, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPos(Object parent, string path, Vector2 position, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                transform.anchoredPosition = position;
            }
            else {
                transform.DOAnchorPos(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPosX(Object parent, string path, float x, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                Vector2 position = transform.anchoredPosition;
                position.x = x;
                transform.anchoredPosition = position;
            }
            else {
                transform.DOAnchorPosX(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPosY(Object parent, string path, float y, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                Vector2 position = transform.anchoredPosition;
                position.y = y;
                transform.anchoredPosition = position;
            }
            else {
                transform.DOAnchorPosY(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPos3D(Object parent, string path, Vector3 position, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                transform.anchoredPosition3D = position;
            }
            else {
                transform.DOAnchorPos3D(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPosX3D(Object parent, string path, float x, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.anchoredPosition3D;
                position.x = x;
                transform.anchoredPosition3D = position;
            }
            else {
                Vector3 position = transform.anchoredPosition3D;
                position.x = x;
                transform.DOAnchorPos3D(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPosY3D(Object parent, string path, float y, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.anchoredPosition3D;
                position.y = y;
                transform.anchoredPosition3D = position;
            }
            else {
                Vector3 position = transform.anchoredPosition3D;
                position.y = y;
                transform.DOAnchorPos3D(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchorPosZ3D(Object parent, string path, float z, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.anchoredPosition3D;
                position.z = z;
                transform.anchoredPosition3D = position;
            }
            else {
                Vector3 position = transform.anchoredPosition3D;
                position.z = z;
                transform.DOAnchorPos3D(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOSizeDelta(Object parent, string path, Vector2 size, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            if (duration == 0) {
                transform.sizeDelta = size;
            }
            else {
                transform.DOSizeDelta(size, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOSizeDeltaX(Object parent, string path, float x, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            Vector2 size = transform.sizeDelta;
            size.x = x;
            if (duration == 0) {
                transform.sizeDelta = size;
            }
            else {
                transform.DOSizeDelta(size, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOSizeDeltaY(Object parent, string path, float y, float duration, string ease) {
        RectTransform transform = GetChild(parent, path) as RectTransform;
        if (transform != null) {
            Vector2 size = transform.sizeDelta;
            size.y = y;
            if (duration == 0) {
                transform.sizeDelta = size;
            }
            else {
                transform.DOSizeDelta(size, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOLocalMove(Object parent, string path, Vector3 position, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                transform.localPosition = position;
            }
            else {
                transform.DOLocalMove(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOLocalMoveX(Object parent, string path, float x, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.localPosition;
                position.x = x;
                transform.localPosition = position;
            }
            else {
                transform.DOLocalMoveX(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOLocalMoveY(Object parent, string path, float y, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.localPosition;
                position.y = y;
                transform.localPosition = position;
            }
            else {
                transform.DOLocalMoveY(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOLocalMoveZ(Object parent, string path, float z, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.localPosition;
                position.z = z;
                transform.localPosition = position;
            }
            else {
                transform.DOLocalMoveZ(z, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOMove(Object parent, string path, Vector3 position, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                transform.position = position;
            }
            else {
                transform.DOMove(position, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOMoveX(Object parent, string path, float x, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.position;
                position.x = x;
                transform.position = position;
            }
            else {
                transform.DOMoveX(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOMoveY(Object parent, string path, float y, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.position;
                position.y = y;
                transform.position = position;
            }
            else {
                transform.DOMoveY(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOMoveZ(Object parent, string path, float z, float duration, string ease) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            if (duration == 0) {
                Vector3 position = transform.position;
                position.z = z;
                transform.position = position;
            }
            else {
                transform.DOMoveZ(z, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DORotate(Object parent, string path, Vector3 angle, float duration, string ease, System.Action<Vector3> callBack)
    {
        Transform transform = GetChild(parent, path);
        if (transform != null)
        {
            if (duration == 0)
            {
                transform.eulerAngles = angle;
            }
            else
            {
                transform.DORotate(angle, duration,RotateMode.FastBeyond360).SetEase(GetDOEase(ease)).OnUpdate(() => callBack(transform.localEulerAngles));
            }
        }
    }

    public static void DOFillAmount(Object parent, string path, float to, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if (duration == 0) {
                image.fillAmount = to;
            }
            else {
                image.DOFillAmount(to, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOFillAmountFromTo(Object parent, string path, float from, float to, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if (duration == 0) {
                image.fillAmount = to;
            }
            else {
                image.fillAmount = from;
                image.DOFillAmount(to, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoImageFade(Object parent, string path, float alpha, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if (duration == 0) {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
            else {
                image.DOFade(alpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoImageFadeFromTo(Object parent, string path, float fromAlpha, float toAlpha, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if (duration == 0) {
                Color color = image.color;
                color.a = toAlpha;
                image.color = color;
            }
            else {
                Color color = image.color;
                color.a = fromAlpha;
                image.color = color;
                image.DOFade(toAlpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOImageFillAmount(Object parent, string path, float value, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if(duration == 0) {
                image.fillAmount = value;
            } else {
                image.DOFillAmount(value, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOImageFillAmountFromTo(Object parent, string path, float from, float to, float duration, string ease) {
        Image image = GetComponent<Image>(parent, path);
        if (image != null) {
            if (duration == 0) {
                image.fillAmount = to;
            }
            else {
                image.fillAmount = from;
                image.DOFillAmount(to, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    // 可以超过1或低于0的方式变化ImageFillAmount
    // onClamp 到达边界时的回调
    public static void DOImageFillAmountBeyondClamp(Object parent, string path, float from, float to, float duration, string easeType, UnityAction onClamp) {
        Image image = GetComponent<Image>(parent, path);
        if(image == null) {
            return;
        }
        Ease ease = GetDOEase(easeType);
        image.fillAmount = from;
        if (to >= 0 && to <= 1) {
            image.DOFillAmount(to, duration).SetEase(ease);
            return;
        }

        Sequence seq = DOTween.Sequence();
        float delta = Mathf.Abs(to - image.fillAmount);
        bool first = true;

        if (to > 1) {
            while (to > 1) {
                float d = duration / delta;
                if (first) {
                    d *= (1 - image.fillAmount);
                }
                seq.Append(image.DOFillAmount(1, d).SetEase(ease));
                seq.AppendCallback(() => {
                    image.fillAmount = 0;
                    if (onClamp != null) {
                        onClamp.Invoke();
                    }
                });
                seq.AppendInterval(0.1f);

                to -= 1;
                first = false;
            }
            seq.Append(image.DOFillAmount(to, duration * to/ delta).SetEase(ease));
        }
        else {
            while (to < 0) {
                float d = duration / delta;
                if (first) {
                    d *= image.fillAmount;
                }
                seq.Append(image.DOFillAmount(0, d).SetEase(ease));
                seq.AppendCallback(() => {
                    image.fillAmount = 1;
                    if (onClamp != null) {
                        onClamp.Invoke();
                    }
                });
                seq.AppendInterval(0.1f);

                to += 1;
                first = false;
            }
            seq.Append(image.DOFillAmount(to, duration * (1 - to) / delta).SetEase(ease));
        }
    }

    public static void DoRawImageFade(Object parent, string path, float alpha, float duration, string ease) {
        RawImage image = GetComponent<RawImage>(parent, path);
        if (image != null) {
            if (duration == 0) {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
            else {
                image.DOFade(alpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoRawImageFadeFromTo(Object parent, string path, float fromAlpha, float toAlpha, float duration, string ease) {
        RawImage image = GetComponent<RawImage>(parent, path);
        if (image != null) {
            if (duration == 0) {
                Color color = image.color;
                color.a = toAlpha;
                image.color = color;
            }
            else {
                Color color = image.color;
                color.a = fromAlpha;
                image.color = color;
                image.DOFade(toAlpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoTextFade(Object parent, string path, float alpha, float duration, string ease) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            if (duration == 0) {
                Color color = text.color;
                color.a = alpha;
                text.color = color;
            }
            else {
                text.DOFade(alpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoTextFadeFromTo(Object parent, string path, float fromAlpha, float toAlpha, float duration, string ease) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            if (duration == 0) {
                Color color = text.color;
                color.a = toAlpha;
                text.color = color;
            }
            else {
                Color color = text.color;
                color.a = fromAlpha;
                text.color = color;
                text.DOFade(toAlpha, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    /// <summary>
    /// 将ScrollRect滚动到指定百分比
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="index">从0开始</param>
    /// <param name="totalCount"></param>
    /// <param name="duration"></param>
    /// <param name="ease"></param>
    public static void DoScrollRectPercentX(Object parent, string path, int index, int totalCount, float duration, string ease) {
        ScrollRect scrollRect = GetComponent<ScrollRect>(parent, path);
        if (scrollRect != null) {
            Vector2 size = scrollRect.content.rect.size;
            Vector2 viewSize = scrollRect.viewport.rect.size;

            float x = 1;
            if (totalCount > 0) {
                x = Mathf.Clamp01((index * size.x / totalCount) / (size.x - viewSize.x));
            }

            if (duration == 0) {
                Vector2 pos = scrollRect.normalizedPosition;
                pos.x = x;
                scrollRect.normalizedPosition = pos;
            }
            else {
                scrollRect.DOHorizontalNormalizedPos(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    /// <summary>
    /// 将ScrollRect滚动到指定百分比
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="index">从0开始</param>
    /// <param name="totalCount"></param>
    /// <param name="duration"></param>
    /// <param name="ease"></param>
    public static void DoScrollRectPercentY(Object parent, string path, int index, int totalCount, float duration, string ease) {
        ScrollRect scrollRect = GetComponent<ScrollRect>(parent, path);
        if (scrollRect != null) {
            Vector2 size = scrollRect.content.rect.size;
            Vector2 viewSize = scrollRect.viewport.rect.size;

            float y = 1;
            if (totalCount > 0) {
                y = Mathf.Clamp01(1 - (index * size.y / totalCount) / (size.y - viewSize.y));
            }

            if (duration == 0) {
                Vector2 pos = scrollRect.normalizedPosition;
                pos.y = y;
                scrollRect.normalizedPosition = pos;
            }
            else {
                scrollRect.DOVerticalNormalizedPos(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoScrollRectPosX(Object parent, string path, float x, float duration, string ease) {
        ScrollRect scrollRect = GetComponent<ScrollRect>(parent, path);
        if (scrollRect != null) {
            if (duration == 0) {
                Vector2 pos = scrollRect.normalizedPosition;
                pos.x = x;
                scrollRect.normalizedPosition = pos;
            }
            else {
                scrollRect.DOHorizontalNormalizedPos(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DoScrollRectPosY(Object parent, string path, float y, float duration, string ease) {
        ScrollRect scrollRect = GetComponent<ScrollRect>(parent, path);
        if (scrollRect != null) {
            if (duration == 0) {
                Vector2 pos = scrollRect.normalizedPosition;
                pos.y = y;
                scrollRect.normalizedPosition = pos;
            }
            else {
                scrollRect.DOVerticalNormalizedPos(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOPath(Object parent, string path, float duration, params Vector3[] pos) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.DOPath(pos, duration, PathType.Linear, PathMode.Sidescroller2D);
        }
    }

    public static void DoMaterialFloat(Material material, float value, string property, float duration, string ease) {
        material.DOKill();
        material.DOFloat(value, property, duration).SetEase(GetDOEase(ease));
    }

    public static void DOTargetTransform(Object obj, Object target, bool position, bool rotation, bool scale, float duration, string easeType) {
        Transform src = GetTransform(obj);
        Transform dest = GetTransform(target);
        
        if(src == null || dest == null) {
            return;
        }
        Ease ease = GetDOEase(easeType);
        if (position) {
            src.DOMove(dest.position, duration).SetEase(ease);
        }
        if (rotation) {
            src.DORotate(dest.eulerAngles, duration, RotateMode.FastBeyond360).SetEase(ease);
        }
        if (scale) {
            src.DOScale(dest.localScale, duration).SetEase(ease);
        }
    }

    
    #endregion

    public static string NewGuid() {
        return System.Guid.NewGuid().ToString();
    }

    public static string GetActiveSceneName() {
        return SceneManager.GetActiveScene().name;
    }

    public static int GetActiveSceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadSceneByIndex(int index) {
        SceneManager.LoadScene(index);
    }

    public static void LoadSceneByName(string name) {
        SceneManager.LoadScene(name);
    }

    public static void SetSkybox(Material material, float ambientIntensity) {
        RenderSettings.skybox = material;
        RenderSettings.ambientIntensity = ambientIntensity;
    }

    public static void SetAmbientLight(string colorText) {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorText, out color)) {
            RenderSettings.ambientLight = color;
        }
    }

    public static void SetAmbientSkyColor(string colorText) {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorText, out color)) {
            RenderSettings.ambientSkyColor = color;
        }
    }

    public static void SetAmbientEquatorColor(string colorText) {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorText, out color)) {
            RenderSettings.ambientEquatorColor = color;
        }
    }

    public static void SetAmbientGroundColor(string colorText) {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorText, out color)) {
            RenderSettings.ambientGroundColor = color;
        }
    }

    public static void SetFogColor(string colorText) {
        Color color;
        if (ColorUtility.TryParseHtmlString(colorText, out color)) {
            RenderSettings.fogColor = color;
        }
    }

    public static void SetFogMod(string mode) {
        try {
            FogMode fogMode = (FogMode)System.Enum.Parse(typeof(FogMode), mode, true);
            RenderSettings.fogMode = fogMode;
        }
        catch (System.Exception e) {
            Debug.LogException(e);
        }
    }

    public static void SetFogDistance(float start, float end) {
        RenderSettings.fogStartDistance = start;
        RenderSettings.fogEndDistance = end;
    }

    public static void UpdateEnvironmentGI() {
        DynamicGI.UpdateEnvironment();
    }

    public static void SetChildrenRendererSortingOrder(Object parent, string path, string layerName, int sortingOrder) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            Renderer[] renderers = transform.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers) {
                renderer.sortingLayerName = layerName;
                renderer.sortingOrder = sortingOrder;
            }
        }
    }

    /// <summary>
    /// 设置物体、或者包含子物体的layer
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="layerName"></param>
    /// <param name="withChildren"></param>
    public static void SetLayer(Object parent, string path, string layerName, bool withChildren) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            int layer = LayerMask.NameToLayer(layerName);
            if (withChildren) {
                Transform[] coms = transform.GetComponentsInChildren<Transform>(true);
                foreach (Transform com in coms) {
                    com.gameObject.layer = layer;
                }
            }
            else {
                transform.gameObject.layer = layer;
            }
        }
    }

    /// <summary>
    /// 向上寻找Canvas
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Canvas LookUpCanvas(Object parent, string path) {
        if(parent != null && parent is Canvas) {
            return parent as Canvas;
        }
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            return transform.GetComponentInParent<Canvas>();
        }
        return null;
    }

    public static string GetMD5FromFile(string fileName) {
        try {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            StringBuilder buffer = new StringBuilder();
            using (FileStream stream = File.OpenRead(fileName)) {
                byte[] retVal = md5.ComputeHash(stream);

                for (int i = 0; i < retVal.Length; i++) {
                    buffer.Append(retVal[i].ToString("x2"));
                }
            }
            return buffer.ToString();
        }
        catch (System.Exception ex) {
            throw new System.Exception("GetMD5FromFile() fail: " + ex.Message);
        }
    }

    public static string GetMD5FromData(byte[] rawData) {
        try {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(rawData);

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++) {
                buffer.Append(retVal[i].ToString("x2"));
            }
            return buffer.ToString();
        }
        catch (System.Exception ex) {
            throw new System.Exception("GetMD5FromFile() fail: " + ex.Message);
        }
    }

    public static string GetMD5FromStr(string str)
    {
        try
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                buffer.Append(retVal[i].ToString("x2"));
            }
            return buffer.ToString();
        }
        catch (System.Exception ex)
        {
            throw new System.Exception("GetMD5FromFile() fail: " + ex.Message);
        }
    }

    public static int GetSleepTimeout() {
        return Screen.sleepTimeout;
    }

    public static void SetSleepTimeout(int timeout) {
        Screen.sleepTimeout = timeout;
    }


    public static string XmlToJson(string xml, bool prettyPrint) {
        JArray json = XmlToJsonData(xml);
        if (json != null) {
            return json.ToString(prettyPrint ? Newtonsoft.Json.Formatting.Indented: Newtonsoft.Json.Formatting.None);
        }
        return null;
    }

    public static JArray XmlToJsonData(string xml) {
        try {
            XmlDocument document = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            using (TextReader tr = new StringReader(xml)) {
                XmlReader reader = XmlReader.Create(tr, settings);
                document.Load(reader);
            }

            JArray json = new JArray();
            foreach (XmlNode node in document.DocumentElement.ChildNodes) {
                json.Add(XmlNodeToJson(node));
            }
            return json;
        }
        catch (System.Exception e) {
            Debug.LogException(e);
            Debug.Log(xml);
        }
        return null;
    }

    private static JObject XmlNodeToJson(XmlNode node) {
        JObject json = new JObject();
        json["name"] = node.Name;
        if (node.Value != null) {
            json["value"] = node.Value;
        }

        if (node.Attributes.Count > 0) {
            JObject attributes = new JObject();
            foreach (XmlAttribute attr in node.Attributes) {
                attributes[attr.Name] = attr.Value;
            }
            json["attributes"] = attributes;
        }

        if (node.ChildNodes.Count > 0) {
            JArray children = new JArray();
            foreach (XmlNode child in node.ChildNodes) {
                children.Add(XmlNodeToJson(child));
            }
            json["children"] = children;
        }

        return json;
    }

    public static void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static string GetFileSize(double size) {
        if (size < 1024) {
            return size + "B";
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}KB", size);
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}MB", size);
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}GB", size);
        }
        size /= 1024;
        if (size < 1024) {
            return string.Format("{0:F2}TB", size);
        }
        size /= 1024;
        return string.Format("{0:F2}PB", size);
    }

    /// <summary>
    /// 截取字符串，从指定的开始、结束字符之间截取，结果不包括开始和结束字符，开始、结束字符可为空
    /// </summary>
    /// <param name="str"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static string SubStringFromTo(string str, string from, string to) {
        if (string.IsNullOrEmpty(str)) {
            return str;
        }
        if (from != null && str.IndexOf(from) >= 0) {
            str = str.Substring(str.IndexOf(from) + from.Length);
        }
        if (to != null && str.IndexOf(to) >= 0) {
            str = str.Substring(0, str.IndexOf(to));
        }
        return str;
    }

    /// <summary>
    /// 截取字符串，从最后一个指定的开始、结束字符之间截取，结果不包括开始和结束字符，开始、结束字符可为空
    /// </summary>
    /// <param name="str"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static string SubStringFromLastTo(string str, string from, string to) {
        if (string.IsNullOrEmpty(str)) {
            return str;
        }
        if (from != null && str.LastIndexOf(from) >= 0) {
            str = str.Substring(str.LastIndexOf(from) + from.Length);
        }
        if (to != null && str.IndexOf(to) >= 0) {
            str = str.Substring(0, str.IndexOf(to));
        }
        return str;
    }

    public static bool Contains(string text, string str) {
        return text.Contains(str);
    }

    public static string FormatText(string text, params object[] args) {
        try {
            return string.Format(text, args);
        }
        catch (System.Exception e) {
            Debug.LogErrorFormat("Text:\"{0}\", params count:{1}\n{2}", text, args.Length, e);
        }
        return text;
    }

    public static void WriteToUTF8(string path, string target)
    {
        UTF8Encoding end = new UTF8Encoding(false);
        using (StreamWriter sw = new StreamWriter(path, false, end))
        {
            sw.Write(target);
        }
    }

    /// <summary>
    /// Trim both side
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Trim(string text) {
        return text == null ? null : text.Trim();
    }

    public static string ReplaceStr(string str, string oldStr, string newStr) {
        if (str != null) {
            return str.Replace(oldStr, newStr);
        }
        return null;
    }

    // 把空格替换成不能换行的空格
    public static string ReplaceNonBreakingSpaces(string str) {
        if (str != null) {
            return str.Replace(' ', '\u00A0');
        }
        return null;
    }

    // 转义富文本，往<后面加个看不见的空格
    public static string EscapeRichText(string str) {
        if (str != null) {
            return str.Replace("<", "<" + '\u200B');
        }
        return null;
    }

    public static Vector2 GetTextPrefferdSize(Object parent, string path) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            return new Vector2(text.preferredWidth, text.preferredHeight);
        }
        return Vector2.zero;
    }

    public static void SetTextPrefferdWidth(Object parent, string path) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            RectTransform transform = text.transform as RectTransform;
            Vector2 sizeDelta = transform.sizeDelta;
            sizeDelta.x = text.preferredWidth;
            transform.sizeDelta = sizeDelta;
        }
    }

    public static void SetTextPrefferdHeight(Object parent, string path) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            RectTransform transform = text.transform as RectTransform;
            Vector2 sizeDelta = transform.sizeDelta;
            sizeDelta.y = text.preferredHeight;
            transform.sizeDelta = sizeDelta;
        }
    }

    public static void SetTextPrefferdSize(Object parent, string path) {
        Text text = GetComponent<Text>(parent, path);
        if (text != null) {
            RectTransform transform = text.transform as RectTransform;
            transform.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
        }
    }

    public static void InvokeAction(System.Action action) {
        if (action != null) {
            action.Invoke();
        }
    }

    // 设置材质的一个属性
    public static void SetMaterialProperty(Material material, string key, object value) {
        if (material == null) {
            return;
        }
        //Application.isPlaying
        if (value is Texture) {
            material.SetTexture(key, value as Texture);
        }
        else if (value is float) {
            material.SetFloat(key, (float)value);
        }
        else if (value is int) {
            material.SetInt(key, (int)value);
        }
        else if (value is Color) {
            material.SetColor(key, (Color)value);
        }
        else if (value is Vector4) {
            material.SetVector(key, (Vector4)value);
        }
        else if (value is Matrix4x4) {
            material.SetMatrix(key, (Matrix4x4)value);
        }
        else if (value is ComputeBuffer) {
            material.SetBuffer(key, (ComputeBuffer)value);
        }
        else {
            Debug.LogError("Invalid value type: " + value.GetType());
        }
    }

    public static void SetMeshMaterial(Object parent, string path, Material material) {
        MeshRenderer renderer = GetComponent<MeshRenderer>(parent, path);
        if (renderer != null) {
            renderer.material = material;
        }
    }

    public static Material GetMeshSharedMaterial(Object parent, string path) {
        MeshRenderer renderer = GetComponent<MeshRenderer>(parent, path);
        if (renderer != null) {
            return renderer.sharedMaterial;
        }
        return null;
    }

    // 得到指定动画的时间长度
    public static float GetAnimationLength(Object parent, string path, int index) {
        Animator animator = GetComponent<Animator>(parent, path);
        if (animator != null) {
            RuntimeAnimatorController controller = animator.runtimeAnimatorController;
            if (controller != null) {
                AnimationClip[] clips = controller.animationClips;
                if(index < clips.Length) {
                    return clips[index].length;
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// 从指定百分比开始播放动画
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="normalizedTime"></param>
    public static void PlayAnimatorFrom(Object parent, string path, float normalizedTime) {
        Animator animator = GetComponent<Animator>(parent, path);

        if (animator != null) {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(-1);
            animator.Play(info.fullPathHash, -1, normalizedTime);
        }
    }

    public static void SetAnimatorTrigger(Object parent, string path, string trigger) {
        Animator animator = GetComponent<Animator>(parent, path);
        if (animator != null) {
            animator.SetTrigger(trigger);
        }
    }

    public static void SetAnimatorBool(Object parent, string path, string name, bool value) {
        Animator animator = GetComponent<Animator>(parent, path);
        if (animator != null) {
            animator.SetBool(name, value);
        }
    }

    public static void SetAnimatorInt(Object parent, string path, string name, int value) {
        Animator animator = GetComponent<Animator>(parent, path);
        if (animator != null) {
            animator.SetInteger(name, value);
        }
    }

    public static void SetAnimatorFloat(Object parent, string path, string name, float value) {
        Animator animator = GetComponent<Animator>(parent, path);
        if (animator != null) {
            animator.SetFloat(name, value);
        }
    }

    public static void SetPlayableAsset(Object parent, string path, PlayableAsset asset) {
        PlayableDirector director = GetComponent<PlayableDirector>(parent, path);
        if (director != null) {
            director.playableAsset = asset;
        }
    }

    public static void PlayPlayableAsset(Object parent, string path, PlayableAsset asset) {
        PlayableDirector director = GetComponent<PlayableDirector>(parent, path);
        if (director != null) {
            director.Play(asset);
        }
    }

    public static int GetNowMilliseconds() {
        return System.DateTime.Now.Millisecond;
    }

    public static bool IsNullOrEmpty(string str) {
        return string.IsNullOrEmpty(str);
    }

    public static bool IsAndroid() {
        return Application.platform == RuntimePlatform.Android;
    }

    public static bool IsIPhone() {
        return Application.platform == RuntimePlatform.IPhonePlayer;
    }

    public static bool IsIOS() {
        return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
    }

    public static string GetPlatformName() {
        return Application.platform.ToString();
    }

    public static void SetLocalData(string key, string data) {
        PlayerPrefs.SetString(key, data);
    }

    public static string GetLocalData(string key, string defaultValue) {
        if (PlayerPrefs.HasKey(key)) {
            return PlayerPrefs.GetString(key, defaultValue);
        }
        return defaultValue;
    }

    public static void SetLocalDataInt(string key, int data) {
        PlayerPrefs.SetInt(key, data);
    }

    public static int GetLocalDataInt(string key, int defaultValue) {
        if (PlayerPrefs.HasKey(key)) {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
        return defaultValue;
    }

    public static void SetLocalDataFloat(string key, float data) {
        PlayerPrefs.SetFloat(key, data);
    }

    public static float GetLocalDataFloat(string key, float defaultValue) {
        if (PlayerPrefs.HasKey(key)) {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }
        return defaultValue;
    }

    public static void SetLocalDataBool(string key, bool data) {
        PlayerPrefs.SetString(key, data.ToString().ToLower());
    }

    public static bool GetLocalDataBool(string key, bool defaultValue) {
        if (PlayerPrefs.HasKey(key)) {
            string str = PlayerPrefs.GetString(key);
            bool result = false;
            if (bool.TryParse(str, out result)) {
                return result;
            }
        }
        return defaultValue;
    }

    public static string GetTimeStamp() {
        return System.DateTime.Now.ToString("HH:mm:ss");
    }

    public static string GetDateStamp() {
        return System.DateTime.Now.ToString("yyyy-MM-dd");
    }

    public static string GetDateTimeStamp() {
        return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static void WriteFile(string path, string content, bool append) {
        if (append) {
            File.AppendAllText(path, content, Encoding.UTF8);
        }
        else {
            File.WriteAllText(path, content, Encoding.UTF8);
        }
    }

    public static string ReadFile(string path) {
        return File.ReadAllText(path, Encoding.UTF8);
    }

    public static float GetUIWidth(Object parent, string path)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        return transform != null ? transform.rect.width : 0;
    }

    public static float GetUIHeight(UnityEngine.Object parent, string path)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        return transform != null ? transform.rect.height : 0;
    }

    public static Vector2 GetUISize(UnityEngine.Object parent, string path)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        return transform != null ? transform.rect.size : Vector2.zero;
    }

    public static void SetUIWidth(Object parent, string path, float width)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null)
        {
            Vector2 size = transform.sizeDelta;
            size.x = width;
            transform.sizeDelta = size;
        }
    }

    public static void SetUIHeight(UnityEngine.Object parent, string path, float height)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null)
        {
            Vector2 size = transform.sizeDelta;
            size.y = height;
            transform.sizeDelta = size;
        }
    }

    public static void SetUISize(Object parent, string path, float x, float y) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            Vector2 size = transform.sizeDelta;
            size.x = x;
            size.y = y;
            transform.sizeDelta = size;
        }
    }

    public static void SetUISizeX(Object parent, string path, float x) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            Vector2 size = transform.sizeDelta;
            size.x = x;
            transform.sizeDelta = size;
        }
    }

    public static void SetUISizeY(Object parent, string path, float y) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            Vector2 size = transform.sizeDelta;
            size.y = y;
            transform.sizeDelta = size;
        }
    }

    public static void SetVideoRenderTexture(Object parent, string path, RenderTexture texture) {
        VideoPlayer player = GetComponent<VideoPlayer>(parent, path);
        if (player != null) {
            player.targetTexture = texture;
        }
    }

    public static void DOAnchoredX(Object parent, string path, float x, float duration, string ease)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null)
        {
            transform.DOKill();
            if (duration == 0)
            {
                SetAnchoredPositionX(transform, null, x);
            }
            else
            {
                transform.DOAnchorPosX(x, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOAnchoredY(Object parent, string path, float y, float duration, string ease)
    {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null)
        {
            transform.DOKill();
            if (duration == 0)
            {
                SetAnchoredPositionY(transform, null, y);
            }
            else
            {
                transform.DOAnchorPosY(y, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void SetPosition(Object parent, string path, Vector3 position) {
        Transform transform = GetChild(parent, path);
        if(transform != null) {
            transform.position = position;
        }
    }

    public static void SetPositionXY(Object parent, string path, float x, float y) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    public static void SetAnchoredPositionX(Object parent, string path, float x) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            Vector2 anchoredPosition = transform.anchoredPosition;
            anchoredPosition.x = x;
            transform.anchoredPosition = anchoredPosition;
        }
    }

    public static void SetAnchoredPositionY(Object parent, string path, float y) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            Vector2 anchoredPosition = transform.anchoredPosition;
            anchoredPosition.y = y;
            transform.anchoredPosition = anchoredPosition;
        }
    }

    public static void SetAnchoredPosition(Object parent, string path, Vector2 pos) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform != null) {
            transform.anchoredPosition = pos;
        }
    }

    public static void SetlLocalScale(Object parent, string path, Vector3 scale) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.localScale = scale;
        }
    }

    public static void SetEulerAngles(Object parent, string path, Vector3 angles) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.eulerAngles = angles;
        }
    }

    public static void SetLocalEulerAngles(Object parent, string path, Vector3 angles) {
        Transform transform = GetChild(parent, path);
        if (transform != null) {
            transform.localEulerAngles = angles;
        }
    }

    public static bool Approximately(float a, float b, float maxDelta) {
        return Mathf.Abs(a - b) <= Mathf.Abs(maxDelta);
    }

    public static float[] ColorHexToRGBA(string hex) {
        float r = 1, g = 1, b = 1, a = 1;
        char[] chars = hex.StartsWith("#") ? hex.ToCharArray(1, hex.Length - 1) : hex.ToCharArray();
        if (chars.Length == 3 || chars.Length == 4) {
            r = System.Convert.ToInt32(chars[0].ToString(), 16) / 15f;
            g = System.Convert.ToInt32(chars[1].ToString(), 16) / 15f;
            b = System.Convert.ToInt32(chars[2].ToString(), 16) / 15f;
            if (chars.Length == 4) {
                a = System.Convert.ToInt32(chars[3].ToString(), 16) / 15f;
            }
        }
        if (chars.Length == 6 || chars.Length == 8) {
            r = System.Convert.ToInt32(chars[0].ToString() + chars[1].ToString(), 16) / 255f;
            g = System.Convert.ToInt32(chars[2].ToString() + chars[3].ToString(), 16) / 255f;
            b = System.Convert.ToInt32(chars[4].ToString() + chars[5].ToString(), 16) / 255f;
            if (chars.Length == 4) {
                a = System.Convert.ToInt32(chars[6].ToString() + chars[7].ToString(), 16) / 255f;
            }
        }
        return new float[4] { r, g, b, a };
    }

    public static string ColorRGBAToHex(float r, float g, float b, float a) {
        StringBuilder sb = new StringBuilder(9);
        sb.Append("#");
        float[] array = new float[4] { r, g, b, a };
        for (int i = 0; i < 4; i++) {
            string s = System.Convert.ToString((int)(array[i] * 255), 16);
            if (s.Length == 1) {
                sb.Append(0);
            }
            sb.Append(s);
        }
        return sb.ToString();
    }

    public static float Vect2Distance(Vector2 a, Vector2 b) {
        return Vector2.Distance(a, b);
    }

    public static float Vect3Distance(Vector3 a, Vector3 b) {
        return Vector3.Distance(a, b);
    }

    public static string Join(IEnumerable list, string seperator) {
        StringBuilder buff = new StringBuilder();
        int index = 0;
        
        foreach(object value in list) {
            if(index > 0) {
                buff.Append(seperator);
            }
            buff.Append(value);
            index++;
        }
        return buff.ToString();
    }

    public static void DOOrthoSize(Object parent, string path, float size, float duration, string ease)
    {
        Transform transform = GetChild(parent, path);
        Camera camera = transform.GetComponent<Camera>();
        if (camera != null)
        {
            if (duration == 0)
            {
                camera.orthographicSize = size;
            }
            else
            {
                camera.DOOrthoSize(size, duration).SetEase(GetDOEase(ease));
            }
        }
    }

    public static void DOTweenTo(float num, float duration, string ease, System.Action<float> callBack)
    {
        float number = 0;
        Tween t = DOTween.To(() => number, x => number = x, num, duration);
        t.SetEase(GetDOEase(ease));
        t.OnUpdate(() => callBack(number));
    }

    public static void DOAnchorAndPivot(Object parent, string path, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, float duration, string ease) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform == null) {
            return;
        }
        if (duration == 0) {
            transform.anchorMin = anchorMin;
            transform.anchorMax = anchorMax;
            transform.pivot = pivot;
        }
        else {
            Ease easeType = GetDOEase(ease);
            transform.DOAnchorMin(anchorMin, duration).SetEase(easeType);
            transform.DOAnchorMax(anchorMax, duration).SetEase(easeType);
            transform.DOPivot(pivot, duration).SetEase(easeType);
        }
    }

    public static void DOAnchor(Object parent, string path, Vector2 anchorMin, Vector2 anchorMax, float duration, string ease) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform == null) {
            return;
        }
        if (duration == 0) {
            transform.anchorMin = anchorMin;
            transform.anchorMax = anchorMax;
        }
        else {
            Ease easeType = GetDOEase(ease);
            transform.DOAnchorMin(anchorMin, duration).SetEase(easeType);
            transform.DOAnchorMax(anchorMax, duration).SetEase(easeType);
        }
    }

    public static void DOPivot(Object parent, string path, Vector2 pivot, float duration, string ease) {
        RectTransform transform = GetComponent<RectTransform>(parent, path);
        if (transform == null) {
            return;
        }
        if (duration == 0) {
            transform.pivot = pivot;
        }
        else {
            Ease easeType = GetDOEase(ease);
            transform.DOPivot(pivot, duration).SetEase(easeType);
        }
    }

    public static void ClearRaycastTarget(Object parent, string path) {
        Transform transform = GetChild(parent, path);
        if(transform != null) {
            Image[] images = transform.GetComponentsInChildren<Image>(true);
            RawImage[] rawImages = transform.GetComponentsInChildren<RawImage>(true);
            Text[] texts = transform.GetComponentsInChildren<Text>(true);

            foreach (Image image in images) {
                image.raycastTarget = false;
            }
            foreach (RawImage image in rawImages) {
                image.raycastTarget = false;
            }
            foreach (Text text in texts) {
                text.raycastTarget = false;
            }
        }
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <param name="name"></param>
    public static void PlayAnimator(Object parent, string path, string name)
    {
        Transform transform = GetChild(parent, path);
        if (transform != null)
        {
            Animator ani = transform.GetComponent<Animator>();
            ani.Play(name);
        }       
    }

    //public static void aa(Object rootParent, string rootPath, Object childParent, string childPath) {
    //    Transform root = CommonUtil.GetChild(rootParent, rootPath);
    //    Transform child = CommonUtil.GetChild(childParent, childPath);
    //    Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, child);
    //    bounds.center
    //}

    public static void SetGridLayoutGroupChildAlignment(Object parent, string path, string childAlignment)
    {
        GridLayoutGroup com = GetComponent<GridLayoutGroup>(parent, path);
        if (com != null)
        {
            com.childAlignment = GetTextAnchor(childAlignment);
        }
    }

    private static TextAnchor GetTextAnchor(string ease)
    {
        try
        {
            if (!string.IsNullOrEmpty(ease))
            {
                return (TextAnchor)System.Enum.Parse(typeof(TextAnchor), ease, true);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        return TextAnchor.UpperLeft;
    }
}
