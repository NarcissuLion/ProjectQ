using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SocialPlatforms;

public class SDKAndroid : SDKInterface {

    #if UNITY_ANDROID
    //public delegate void GPDelegate(bool success, string uname, string re);

    //static GPDelegate authenticatingCallback = null;

    public override void Init()
    {
        //PlayGamesPlatform.Activate();
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="cb">回调 （是否成功，玩家名字，错误原因）</param>
    public override void Login()//GPDelegate cb = null
    {
        //authenticatingCallback = cb;
        Social.localUser.Authenticate((bool success, string re) =>
        {
            if (success)
            {
                Debug.Log("Authentication success : " + Social.localUser.userName);
            }
            else
            {
                Debug.Log("Authentication failed");
            }
            //if (cb != null) cb(success, Social.localUser.userName, re);
        });
    }

    public override bool IsLogin() {
        return Social.localUser.authenticated;
    }

    /// <summary>
    /// 显示排行榜
    /// </summary>
    /// <param name="lbid">排行榜id，传空字符串则显示全部排行榜</param>
    public override void ShowLeaderboard(string lbid = "")
    {
        if (!IsLogin())
        {
            Debug.Log("没有登录");
            return;
        }
        if (lbid == "")
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            //PlayGamesPlatform.Instance.ShowLeaderboardUI(lbid);
        }
    }

    /// <summary>
    /// 上传分数
    /// </summary>
    /// <param name="scores">分数.</param>
    /// <param name="lbid">排行榜id.</param>
    public override void PostScore(string lbid, int scores)
    {
        if (!IsLogin())
        {
            Debug.Log("没有登录");
            return;
        }

        Social.ReportScore(scores, lbid, (bool success) =>
        {
            // handle success or failure
            Debug.Log("post score : " + success);
        });
    }

    public override void Pay(string productId, string extension)
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.pythonbro.clientframe.GoogleSDK");
        AndroidJavaObject jo = jc.CallStatic<AndroidJavaObject>("getInstance");

        AndroidJavaClass ujc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject mainActivity = ujc.GetStatic<AndroidJavaObject>("currentActivity");

        jo.Call("Init", mainActivity);
        jo.Call("Pay", productId, extension);
    }

    #endif
}