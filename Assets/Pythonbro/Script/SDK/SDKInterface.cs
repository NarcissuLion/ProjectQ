using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SDKInterface {

    public delegate void LoginHandler(string data);
    public delegate void LogoutHandler();
    public delegate void PayHandler(string data);
    public delegate void ShareHandler();

    public LoginHandler onLogin;
    public LogoutHandler onLogout;
    public PayHandler onPay;
    public ShareHandler onShare;

    private static SDKInterface _instance;

    public static SDKInterface Instance {
        get {
            if (_instance == null) {
#if UNITY_EDITOR || UNITY_STANDLONE
                _instance = new SDKDefault();
#elif UNITY_ANDROID
                _instance = new SDKAndroid();
#elif UNITY_IOS
                _instance = new SDKIOS();
#endif
            }

            return _instance;
        }
    }

    //初始化
    public virtual void Init() { Debug.Log("Not supported"); }

    //登录
    public virtual void Login() { Debug.Log("Not supported"); }

    //自定义登录，用于腾讯应用宝，QQ登录，customData="QQ";微信登录，customData="WX"
    public virtual void LoginCustom(string customData) { Debug.Log("Not supported"); }

    //切换帐号
    public virtual void SwitchLogin() { Debug.Log("Not supported"); }

    //登出
    public virtual bool Logout() { Debug.Log("Not supported"); return false; }


    //是否已登录
    public virtual bool IsLogin() { Debug.Log("Not supported"); return false; }
    //调用SDK的退出确认框, 游戏先判断是否支持弹窗，再调用
    public virtual void SDKExit() { Debug.Log("Not supported"); }

    //调用SDK支付界面
    public virtual void Pay(string productId, string extension) { Debug.Log("Not supported"); }

    //显示个人中心
    public virtual bool ShowAccountCenter() { return false; }

    //上传游戏数据
    public virtual void SubmitGameData(string data) { Debug.Log("Not supported"); }

    // 是否支持登录
    public virtual bool IsSupportLogin() { return false; }

    // 是否支持支付
    public virtual bool IsSupportPay() { return false; }

    // 是否支持统计
    public virtual bool IsSupportStat() { return false; }

    //SDK是否支持退出确认框
    public virtual bool IsSupportExit() { return false; }

    //SDK是否支持用户中心
    public virtual bool IsSupportAccountCenter() { return false; }

    //SDK是否支持登出
    public virtual bool IsSupportLogout() { return false; }

    //获取手机网络信息
    public virtual string GetNetworkOperatorName() { return null; }

    //获取MAC地址
    public virtual string GetMacAddr() { return null; }

    //是否SDK环境（）
    public virtual bool IsSDKEnv() { return false; }

    //获取渠道ID
    public virtual int GetChannelID() { return 0; }

    //分享接口  参数：{"content":"分享内容","title":"分享标题","url":"分享链接","imageUrl":"分享的图片链接","picPath":"分享本地图片路径","shareType":"分享类型例如：facebook/twitter"}
    public virtual void Share(string data) { Debug.Log("Not supported"); }

    //显示排行榜
    public virtual void ShowLeaderboard(string lbid) { Debug.Log("Not supported"); }

    //提交排行榜分数（排行榜id , 分数）
    public virtual void PostScore(string lbid ,int scores) { Debug.Log("Not supported"); }
}
