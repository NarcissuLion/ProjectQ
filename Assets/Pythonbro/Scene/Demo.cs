using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Demo : MonoBehaviour {


    void Awake() {
        BetterStreamingAssets.Initialize();
    }

//    IEnumerator Start() {
//        yield return true;

////#if UNITY_ANDROID
//        AndroidJavaClass jc = new AndroidJavaClass("com.pythonbro.clientframe.JavaTest");
//        string result = jc.CallStatic<string>("test", 999);
//        Debug.Log("Result: " + result);
////#endif
//    }

    void Start() {
//#if UNITY_ANDROID
//        AndroidJavaClass jc = new AndroidJavaClass("com.pythonbro.clientframe.JavaTest");
//        string result = jc.CallStatic<string>("test", 999);
//        Debug.Log("Result: " + result);
//#endif
        AndroidJavaClass ujc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject mainActivity = ujc.GetStatic<AndroidJavaObject>("currentActivity");
        //AndroidJavaClass jc = new AndroidJavaClass("com.pythonbro.clientframe.ShareTest");
        Debug.Log("---------------------");

        //jc.CallStatic("share", mainActivity);
        //        Debug.Log("Result: " + result);
    }

}
