using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XLua;

public class LuaClient : MonoBehaviour {

    [CSharpCallLua]
    public delegate void OnSceneLoad(int sceneIndex, string sceneName);
    [CSharpCallLua]
    public delegate void OnSceneLoaded(string sceneName);
    [CSharpCallLua]
    public delegate void OnSceneUnload(int sceneIndex, string sceneName);
    [CSharpCallLua]
    public delegate void OnClickEscape();
    [CSharpCallLua]
    public delegate void OnClick(Vector3 pos);
    [CSharpCallLua]
    public delegate void OnOnApplicationPause(bool pause);
    [CSharpCallLua]
    public delegate void OnOnApplicationFocus(bool focus);

    public static LuaClient Instance { get; private set; }

    public static LuaEnv luaEnv { get; private set; }

    private static OnSceneLoad onSceneLoad;
    private static OnSceneLoaded onSceneLoaded;
    private static OnSceneUnload onSceneUnload;
    private static OnClickEscape onClickEscape;
    private static OnClick onClick;
    private static OnOnApplicationPause onApplicationPause;
    private static OnOnApplicationFocus onApplicationFocus;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Init();
    }

    private void OnDestroy() {
        if (luaEnv != null) {
            SceneUnload();
        }
        Instance = null;
    }

    public void Init() {
        if (luaEnv == null) {
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(LuaLoader);

            luaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
            //luaEnv.AddBuildin("lpeg", XLua.LuaDLL.Lua.LoadLpeg);
            //luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProfobuf);
            //luaEnv.AddBuildin("ffi", XLua.LuaDLL.Lua.LoadFFI);

            luaEnv.DoString("require 'Main'");

            onSceneLoad = luaEnv.Global.Get<OnSceneLoad>("OnSceneLoad");
            onSceneLoaded = luaEnv.Global.Get<OnSceneLoaded>("OnSceneLoaded");
            onSceneUnload = luaEnv.Global.Get<OnSceneUnload>("OnSceneUnload");
            onClickEscape = luaEnv.Global.Get<OnClickEscape>("OnClickEscape");
            onClick = luaEnv.Global.Get<OnClick>("OnClick");
            onApplicationPause = luaEnv.Global.Get<OnOnApplicationPause>("OnApplicationPause");
            onApplicationFocus = luaEnv.Global.Get<OnOnApplicationFocus>("OnApplicationFocus");

            luaEnv.DoString("Main()");

            Debug.Log("Lua initialized");
        }

        SceneLoad();
    }

    private void Update() {
        if (luaEnv == null) {
            return;
        }
        luaEnv.Tick();

        //点击返回
        if (onClickEscape != null && Input.GetKeyUp(KeyCode.Escape)) {
            onClickEscape.Invoke();
        }

        if (onClick != null && Input.GetMouseButtonUp(0)) {
            onClick.Invoke(Input.mousePosition);
        }
    }

    public void Dispose() {
        if (luaEnv != null) {
            onSceneLoad = null;
            onSceneLoaded = null;
            onSceneUnload = null;
            onClickEscape = null;
            onClick = null;
            onApplicationPause = null;
            onApplicationFocus = null;

            List<System.WeakReference> list = new List<System.WeakReference>(luaEnv.translator.delegate_bridges.Values);
            foreach (var reference in list) {
                DelegateBridge bridge = reference.Target as DelegateBridge;
                bridge.Dispose();
            }
            luaEnv.translator.delegate_bridges.Clear();

            //luaEnv.DoString("(require 'xlua.util').print_func_ref_by_csharp()");

            luaEnv.Dispose();
            luaEnv = null;
        }
        DestroyImmediate(gameObject);
    }

    public void SceneLoad() {
        if(onSceneLoad != null) {
            Scene scene = SceneManager.GetActiveScene();
            onSceneLoad.Invoke(scene.buildIndex, scene.name);
        }
    }

    public void SceneUnload() {
        if (onSceneUnload != null) {
            Scene scene = SceneManager.GetActiveScene();
            onSceneUnload.Invoke(scene.buildIndex, scene.name);
        }
    }

    public void OnApplicationPause(bool pause) {
        if (onApplicationPause != null) {
            Scene scene = SceneManager.GetActiveScene();
            onApplicationPause.Invoke(pause);
        }
    }

    public void OnApplicationFocus(bool focus) {
        if (onApplicationFocus != null) {
            Scene scene = SceneManager.GetActiveScene();
            onApplicationFocus.Invoke(focus);
        }
    }

    private string LuaPath(string name) {
        string lowerName = name.ToLower();
        if (lowerName.EndsWith(".lua")) {
            int index = name.LastIndexOf('.');
            name = name.Substring(0, index);
        }
        name = name.Replace('.', '/');
        return string.Concat("Lua/", name, ".lua");
    }

    private byte[] LuaLoader(ref string name) {
        string path = LuaPath(name);
        return GameUtil.LoadDecryptBytes(path);
    }

}
