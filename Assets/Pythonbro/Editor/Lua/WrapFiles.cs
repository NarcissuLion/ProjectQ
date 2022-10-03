using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public static class WrapFiles {

    [LuaCallCSharp]
    public static List<System.Type> WrapList = new List<System.Type>() {

        typeof(Application),
        typeof(Screen),
        typeof(SystemInfo),
        typeof(SleepTimeout),

        typeof(GameObject),
        typeof(Transform),
        typeof(RectTransform),

        typeof(Text),
        typeof(Image),
        typeof(RawImage),
        typeof(ScrollRect),
        typeof(Sprite),
        typeof(Texture),
        typeof(Material),
        typeof(MeshRenderer),

        typeof(CommonUtil),
        typeof(GameUtil),
        typeof(ResourcesLoader),
        typeof(CoroutineHelper),
        typeof(DebugStopwatch),
        typeof(HttpManager),
        typeof(GridView),
        typeof(HotfixDownloader),
        typeof(HotfixManager),
        typeof(HotfixUtil),
        typeof(SceneHandler),
        typeof(LuaDebugger),
        typeof(ConfigManager),
        typeof(TextConfig),

        typeof(SDKInterface),
        typeof(SDKDefault),
        typeof(SDKAndroid),
        typeof(SDKIOS),

        // DOTween
        typeof(DG.Tweening.ShortcutExtensions),
        typeof(DG.Tweening.ShortcutExtensions46),
        typeof(DG.Tweening.Tweener),
        typeof(DG.Tweening.Ease),


    };

    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
        new List<string>(){"UnityEngine.UI.Text", "OnRebuildRequested"},
        new List<string>(){"UnityEngine.Texture", "imageContentsHash"},
    };

}
