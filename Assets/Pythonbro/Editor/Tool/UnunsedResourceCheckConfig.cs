using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class UnunsedResourceCheckConfig : ScriptableObject {

    [Tooltip("递归检查深度，比如预设->材质球->贴图、预设->动画控制器->动画clip->贴图")]
    public int checkLevel = 4;

    [Tooltip("确定已使用的N个目录（可包含预设、材质球、动画控制器等，它们会引用其他资源）")]
    public List<DefaultAsset> usedDirectories = new List<DefaultAsset>();

    [Tooltip("需要检查是否被使用的N个目录（可包含任意文件）")]
    public List<DefaultAsset> checkDirectories = new List<DefaultAsset>();

}
