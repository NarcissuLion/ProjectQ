using UnityEngine;
using System.Collections;

public static class LuaDebugger {

    public static void LogLua(object obj, string traceback, params object[] args) {
        if (obj == null) {
            Debug.Log("Null\n" + traceback);
        }
        else {
            if (args.Length == 0) {
                Debug.Log(obj + "\n" + traceback);
            }
            else {
                Debug.LogFormat(obj + "\n" + traceback, args);
            }
        }
    }

    public static void LogLuaError(object obj, string traceback, params object[] args) {
        if (obj == null) {
            Debug.LogError("Null\n" + traceback);
        }
        else {
            if (args.Length == 0) {
                Debug.LogError(obj + "\n" + traceback);
            }
            else {
                Debug.LogErrorFormat(obj + "\n" + traceback, args);
            }
        }
    }

    public static void Log(string str, params object[] args) {
        if (args.Length == 0) {
            Debug.Log(str);
        }
        else {
            Debug.LogFormat(str, args);
        }
    }

    public static void LogWarning(string str, params object[] args) {
        if (args.Length == 0) {
            Debug.LogWarning(str);
        }
        else {
            Debug.LogWarningFormat(str, args);
        }
    }

    public static void LogError(string str, params object[] args) {
        if (args.Length == 0) {
            Debug.LogError(str);
        }
        else {
            Debug.LogErrorFormat(str, args);
        }
    }

}
