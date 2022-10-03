using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class HttpManager : MonoBehaviour {

    public const string CONTENT_TYPE = "Content-type";
    public const string USER_AGENT = "User-Agent";
    public const string JSON_TYPE = "application/json; charset='utf-8'";

    public const string ACCEPT_ENCODING = "Accept-Encoding";
    public const string GZIP = "gzip";
    public const string AGENT = "FGame";

    public const string EMPTY = "";
    public const string ERROR_NOT_REACHABLE = "client_error.not_reachable";
    public const string ERROR_INVALID_URL = "client_error.invalid_url";

    [XLua.CSharpCallLua]
    public delegate void Callback(string result, long code, string error);

    public static HttpManager instance = null;
    public static HttpManager GetInstance() {
        if(instance == null) {
            GameObject obj = new GameObject("HttpManager");
            DontDestroyOnLoad(obj);
            instance = obj.AddComponent<HttpManager>();
        }
        return instance;
    }

    private IHttpHandler httpHandler;

    private void Awake() {
        httpHandler = new BestHttpHandler(this);
        //httpHandler = new UnityHttpHandler(this);
    }

    private void OnDestroy() {
        instance = null;
    }

    public void Post(string url, string data, Callback callback) {
        httpHandler.Post(url, data, callback);
    }

    public void Get(string url, Callback callback) {
        httpHandler.Get(url, callback);
    }

    public void CancelAllRequest() {
        httpHandler.CancelAllRequest();
    }

    public void Dispose() {
        Destroy(gameObject);
    }
    

}
