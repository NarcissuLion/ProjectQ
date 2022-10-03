using UnityEngine;
using System;
using System.Collections;
using System.Text;

using BestHTTP;

public class BestHttpHandler : IHttpHandler {

    private HttpManager httpManager;
    public int timeoutSec = 20;
    public bool isKeepAlive = false;
    public bool enableRetry = false;

    public BestHttpHandler(HttpManager httpManager) {
        this.httpManager = httpManager;
    }

    public void Post(string url, string postData, HttpManager.Callback callback) {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            callback(HttpManager.EMPTY, 0, HttpManager.ERROR_NOT_REACHABLE);
            return;
        }
        if (string.IsNullOrEmpty(url)) {
            callback(HttpManager.EMPTY, 0, HttpManager.ERROR_INVALID_URL);
            return;
        }
        HTTPRequest request = NewRequest(url, HTTPMethods.Post, callback);

        request.AddHeader(HttpManager.ACCEPT_ENCODING, HttpManager.GZIP);
        request.AddHeader(HttpManager.CONTENT_TYPE, HttpManager.JSON_TYPE);
        request.AddHeader(HttpManager.USER_AGENT, HttpManager.AGENT);
        request.RawData = Encoding.UTF8.GetBytes(postData);
        request.ConnectTimeout = TimeSpan.FromSeconds(timeoutSec);
        request.Timeout = TimeSpan.FromSeconds(timeoutSec);
        request.IsKeepAlive = isKeepAlive;
        request.DisableRetry = !enableRetry;
        //request.UseAlternateSSL = UseAlternateSSL(url);

        request.Send();
    }

    public void Get(string url, HttpManager.Callback callback) {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            callback(HttpManager.EMPTY, 0, HttpManager.ERROR_NOT_REACHABLE);
            return;
        }

        if (string.IsNullOrEmpty(url)) {
            callback(HttpManager.EMPTY, 0, HttpManager.ERROR_INVALID_URL);
            return;
        }
        HTTPRequest request = NewRequest(url, HTTPMethods.Get, callback);

        request.AddHeader(HttpManager.ACCEPT_ENCODING, HttpManager.GZIP);
        request.AddHeader(HttpManager.USER_AGENT, HttpManager.AGENT);
        request.ConnectTimeout = TimeSpan.FromSeconds(timeoutSec);
        request.Timeout = TimeSpan.FromSeconds(timeoutSec);
        request.IsKeepAlive = isKeepAlive;
        request.DisableRetry = !enableRetry;
        //request.UseAlternateSSL = UseAlternateSSL(url);

        request.Send();
    }

    public void CancelAllRequest() {
        // TODO
    }

    private HTTPRequest NewRequest(string url, HTTPMethods method, HttpManager.Callback callback) {
        return new HTTPRequest(new Uri(url), method, true, true, (_request, _response) => {
            switch (_request.State) {
                case HTTPRequestStates.Finished:
                    if (_response.IsSuccess) {
                        OnSuccess(_response, callback);
                    }
                    else {
                        OnResponseError(_request, _response, callback);
                    }
                    break;
                case HTTPRequestStates.Error:
                    OnRequestError(_request, _response, callback);
                    break;
                case HTTPRequestStates.Aborted:
                    OnRequestError(_request, _response, callback);
                    break;
                case HTTPRequestStates.ConnectionTimedOut:
                    OnRequestError(_request, _response, callback);
                    break;
                case HTTPRequestStates.TimedOut:
                    OnRequestError(_request, _response, callback);
                    break;
            }
        });
    }

    private void OnSuccess(HTTPResponse response, HttpManager.Callback callback) {
        callback(response.DataAsText, response.StatusCode, null);
    }

    private void OnRequestError(HTTPRequest request, HTTPResponse response, HttpManager.Callback callback) {
        callback(null, response == null ? 0 : response.StatusCode, "error." + request.State);

        if (request.Exception != null) {
            Debug.Log(request.Exception);
            Debug.Log(request.CurrentUri);
        }
        request.Dispose();
    }

    private void OnResponseError(HTTPRequest request, HTTPResponse response, HttpManager.Callback callback) {
        callback(null, response.StatusCode, "error." + response.StatusCode);

        if (request.Exception != null) {
            Debug.Log(request.Exception);
            Debug.Log(request.CurrentUri);
        }
        request.Dispose();
        response.Dispose();
    }

}
