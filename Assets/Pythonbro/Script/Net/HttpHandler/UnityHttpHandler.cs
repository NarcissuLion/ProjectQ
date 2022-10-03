using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class UnityHttpHandler : IHttpHandler {

    private HttpManager httpManager;

    public UnityHttpHandler(HttpManager httpManager) {
        this.httpManager = httpManager;
    }

    public void Post(string url, string data, HttpManager.Callback callback) {
        UnityWebRequest request = UnityWebRequest.Post(url, data);
        httpManager.StartCoroutine(Send(request, callback));
    }

    public void Get(string url, HttpManager.Callback callback) {
        UnityWebRequest request = UnityWebRequest.Get(url);
        httpManager.StartCoroutine(Send(request, callback));
    }

    public void CancelAllRequest() {
        httpManager.StopAllCoroutines();
    }

    public IEnumerator Send(UnityWebRequest request, HttpManager.Callback callback) {
        AsyncOperation async = request.SendWebRequest();
        yield return async;

        long responseCode = request.responseCode;
        //Debug.LogError(request.error + ":" + responseCode);

        if (request.result == UnityWebRequest.Result.ConnectionError) {
            // 网络IO错误
            callback.Invoke(null, responseCode, request.error);
            yield break;
        }

        if (request.result == UnityWebRequest.Result.ProtocolError) {
            // 响应Code错误
            callback.Invoke(null, responseCode, request.error);
            yield break;
        }

        string text = request.downloadHandler.text;
        request.Dispose();

        callback.Invoke(text, responseCode, null);
    }

}
