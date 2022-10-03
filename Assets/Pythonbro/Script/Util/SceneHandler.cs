using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    private static Dictionary<string, SceneHandler> instances = new Dictionary<string, SceneHandler>();

    public static string CurrentSceneName {
        get; private set;
    }

    public static SceneHandler Current {
        get {
            SceneHandler handler = null;
            if (CurrentSceneName != null) {
                instances.TryGetValue(CurrentSceneName, out handler);
            }
            return handler;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnRuntimeMethodLoad() {
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    private static void ActiveSceneChanged(Scene from, Scene to) {
        if (to.name == "Login" || to.name == "Main") {
            CurrentSceneName = to.name;
            CreateInstance(to.name);
        }
    }


    public static void CreateInstance(string sceneName) {
        if (instances.ContainsKey(sceneName)) {
            return;
        }

        SceneHandler handler = new GameObject("SceneHandler " + sceneName).AddComponent<SceneHandler>();
        handler.sceneName = sceneName;
        instances[sceneName] = handler;
    }


    public string sceneName;

    private void OnDestroy() {
        instances.Remove(sceneName);
    }

    
}
