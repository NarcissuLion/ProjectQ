//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using LuaInterface;
//using Newtonsoft.Json.Linq;

// 已废弃 主界面调用的是Script/Lua里的LuaClient
//public class LuaClient : MonoBehaviour {

//    // Lua文件加载器
//    public static byte[] Loader(string name) {
//        //Debug.LogFormat("Load lua file : {0}", name);
//        string path = Util.LuaPath(name);
//        return GameUtil.LoadDecryptBytes(path);
//    }

//    private static LuaScriptMgr luaMgr = null;

//    private Vector3 lastMousePos;

//    public void Init() {
//        if (luaMgr == null) {
//            try {
//                luaMgr = new LuaScriptMgr();
//                luaMgr.Start();
//            }
//            catch (System.Exception e) {
//                Debug.LogException(e);
//            }
//        }

//        //string text = ResourcesLoader.LoadTextFromStreamingAssets("Lua/test.lua");
//        //Debug.Log(text);
//        //luaMgr.DoString(text);
//        //luaMgr.DoString("print('luaMgr.DoString() in LuaClient.cs')");

//        OnSceneLoad();
//    }

//    void Awake () {
//        //Init();
//    }

//    void Start() {

//    }

//	void Update () {
//        //点击返回
//        if (Input.GetKeyUp(KeyCode.Escape)) {
//            CallLuaFunction("OnClickEscape", true);
//        }

//        if (Input.GetMouseButtonUp(0)) {
//            CallLuaFunction("OnClick", true, Input.mousePosition);
//        }
//        //if (Input.GetMouseButtonDown(0)) {
//        //    lastMousePos = Input.mousePosition;
//        //}
//        //if (Input.GetMouseButtonUp(0) && Vector3.Distance(lastMousePos, Input.mousePosition) < 50f ) {
//        //    CallLuaFunction("OnClick", true, Input.mousePosition);
//        //}

//        if (luaMgr != null) {
//            luaMgr.Update();
//        }
//    }

//    void LateUpdate() {
//        if (luaMgr != null) {
//            luaMgr.LateUpate();
//        }
//    }

//    void FixedUpdate() {
//        if (luaMgr != null) {
//            luaMgr.FixedUpdate();
//        }
//    }

//    void OnDestroy() {
//        OnSceneUnload();
//    }

//    void OnApplicationPause(bool pauseStatus) {
//        CallLuaFunction("OnApplicationPause", true, pauseStatus);
//    }

//    void OnApplicationFocus(bool focus) {
//        CallLuaFunction("OnApplicationFocus", true, focus);
//    }

//    void OnApplicationQuit() {
//        if (Application.isEditor && luaMgr != null) {
//            //否则可能导致编辑器模式 LuaScriptException: not enough memory
//            luaMgr.Destroy();
//            luaMgr = null;
//            System.GC.Collect();
//        }
//    }

//    public void OnSceneLoad() {
//        Scene scene = SceneManager.GetActiveScene();
//        CallLuaFunction("OnSceneLoad", true, scene.buildIndex, scene.name);
//    }

//    public void OnSceneUnload() {
//        Scene scene = SceneManager.GetActiveScene();
//        CallLuaFunction("OnSceneUnload", true, scene.buildIndex, scene.name);
//    }


//    public static LuaScriptMgr LuaScriptMgr
//    {
//        get { return luaMgr; }
//    }

//    public static void DestroyLuaManager() {
//        if (luaMgr != null) {
//            luaMgr.Destroy();
//            luaMgr = null;
//        }
//    }

//    /// <summary>
//    /// 安全调用lua方法
//    /// </summary>
//    /// <param name="name">lua方法名</param>
//    /// <param name="cacheFunction">是否缓存LuaFunction实例</param>
//    /// <param name="args">lua方法参数</param>
//    /// <returns></returns>
//    public static object[] CallLuaFunction(string name, bool cacheFunction, params object[] args) {
//        if (luaMgr != null) {
//            if (cacheFunction) {
//                LuaFunction function = luaMgr.GetLuaFunction(name); //会缓存LuaFunction
//                if (function != null) {
//                    return function.Call(args);
//                }
//            } else {
//                return luaMgr.CallLuaFunction(name, args);  //不缓存LuaFunction
//            }
//        }
//        return null;
//    }

//    public static string Traceback(int fromLine) {
//        if (LuaScriptMgr.traceback != null) {
//            object[] result = LuaScriptMgr.traceback.Call();
//            if (result != null && result.Length > 0 && result[0] != null) {
//                string log = result[0].ToString();
//                if (fromLine > 0) {
//                    string[] lines = log.Split(new char[] { '\n' }, fromLine);
//                    return lines[lines.Length - 1];
//                }
//                else {
//                    return log;
//                }
//            }
//        }
//        return null;
//    }

//}
