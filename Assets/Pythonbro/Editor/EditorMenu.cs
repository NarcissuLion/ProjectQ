using UnityEngine;
using UnityEngine.U2D;
using UnityEditor;
using System.IO;

public static class EditorMenu {

    public const string MENU = "工具";

    [MenuItem(MENU + "/测试", false, 0)]
    public static void Test() {

    }

    [MenuItem(MENU + "/打开本地缓存(PersistentPath)", false, 100)]
    public static void OpenPersistentPath() {
        CommonEditorTool.OpenPersistentPath();
    }

    [MenuItem(MENU + "/删除本地缓存(PersistentPath)", false, 100)]
    public static void ClearPersistentPath() {
        CommonEditorTool.ClearPersistentPath();
    }

    [MenuItem(MENU + "/删除存储数据(PlayerPrefs)", false, 100)]
    public static void ClearPlayerPrefs() {
        CommonEditorTool.ClearPlayerPrefs();
    }

    [MenuItem(MENU + "/开关UIRaycast辅助线", false, 200)]
    public static void ToggleUIRaycastGizmos() {
        CommonEditorTool.ToggleUIRaycastGizmos();
    }

    [MenuItem(MENU + "/批量取消UIRaycastTarget", false, 200)]
    public static void ClearRaycastTarget() {
        CommonEditorTool.ClearRaycastTarget();
    }

    [MenuItem(MENU + "/清理Material中缓存的变量", false, 300)]
    public static void ClearMaterialSavedProperties() {
        CommonEditorTool.ClearMaterialSavedProperties();
    }

    [MenuItem(MENU + "/重置Scale为1", false, 300)]
    public static void ResetScale() {
        CommonEditorTool.ResetScale();
    }

    [MenuItem(MENU + "/Image转换为RawImage", false, 300)]
    public static void Image2RawImage() {
        CommonEditorTool.Image2RawImage();
    }

    [MenuItem(MENU + "/批量舍入RectTransform值", false, 300)]
    public static void RoundRectTransform() {
        CommonEditorTool.RoundRectTransform();
    }

    [MenuItem(MENU + "/批量设置子节点名称为\"名称+序号\"", false, 300)]
    public static void RenameChildrenByNumber() {
        CommonEditorTool.RenameChildrenByNumber();
    }

    [MenuItem(MENU + "/自动选中同层级的同名节点", false, 300)]
    public static void SelectSameNameNode() {
        CommonEditorTool.SelectSameNameNode();
    }

    [MenuItem(MENU + "/ADB工具", false, 400)]
    public static void OpenADBPushWindow() {
        ADBPushWindow.ShowWindow();
    }

    [MenuItem(MENU + "/未使用资源检查工具", false, 400)]
    public static void OpenUnunsedResourceChecker() {
        UnunsedResourceChecker.ShowWindow();
    }

    [MenuItem(MENU + "/强制关闭进度条", false, 9900)]
    public static void ClearProgressBar() {
        EditorUtility.ClearProgressBar();
    }

    [MenuItem(MENU + "/强制卸载所有AssetBundles", false, 9900)]
    public static void UnloadAllAssetBundles() {
        AssetBundle.UnloadAllAssetBundles(true);
    }

}
