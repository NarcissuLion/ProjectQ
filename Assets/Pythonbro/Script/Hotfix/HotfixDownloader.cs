using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using BestHTTP;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

/// <summary>
/// 热更新下载器
/// </summary>
public class HotfixDownloader : MonoBehaviour {

    public const int OPERATION_NONE = 0;            // 无操作
    public const int OPERATION_UNLOAD_AND_REENTER = 1; // 卸载游戏资源，并重新进入游戏

    public delegate void OnProgress(int index, int downloadedCount, int totalCount, long downloaded, long totalSize, long curSpeed);
    public delegate void OnFinished(bool success);

    public static HotfixDownloader CreateInstance() {
        GameObject obj = new GameObject("HotfixDownloader");
        return obj.AddComponent<HotfixDownloader>();
    }

    public int maxDownloadThread = 3;               // 最大现在线程数
    public int retryCount = 1;                      // 失败重试次数
    public bool validateMD5 = true;                 // 下载是否校验md5
    public int streamFragmentSize = 1024 * 512;     // 下载分片大小（Byte）
    public bool downloadToTemp = true;              // 是否先现在到临时目录
    public int completeOperation = OPERATION_NONE;  // 下载完成后要执行的操作

    public OnProgress onProgress;       // 下载进度
    public OnFinished onFinished;       // 下载完成

    private HotfixDownloadList downloadList;

    private bool downloading = false;
    private int curThreadCount = 0;
    private List<DownloadThread> threadList = new List<DownloadThread>();
    private List<DownloadThread> activeThreadList = new List<DownloadThread>();
    private SpeedMonitor speedMonitor = new SpeedMonitor();

    private long totalDownloaded = 0;       // 已下载总大小
    private int totalDownloadedCount = 0;   // 已下载文件数

    private long totalSize = 0;     // 总大小
    private int totalCount = 0;     // 总文件数

    // 初始化下载列表
    public void Init(string downloadListJson) {
        downloadList = JsonUtil.ParseJsonObject<HotfixDownloadList>(downloadListJson);

        totalSize = downloadList.totalSize;
        totalCount = downloadList.list.Count;

        foreach (HotfixDownloadList.File file in downloadList.list) {
            DownloadThread thread = new DownloadThread(file, file.GetSavePath(downloadToTemp), streamFragmentSize, OnThreadProgress, OnThreadFinished);
            threadList.Add(thread);
        }
    }

    // 开始下载
    public void StartDownload() {
        downloading = true;
        speedMonitor.Start();
    }

    // 放弃下载
    public void Abort() {
        downloading = false;
        onProgress = null;
        onFinished = null;
        speedMonitor.Stop();
        foreach (DownloadThread thread in activeThreadList) {
            thread.Abort();
        }
    }

    private void Update() {
        if (!downloading) {
            return;
        }
        speedMonitor.OnUpdate(Time.deltaTime);

        // 线程控制
        if (curThreadCount < maxDownloadThread && threadList.Count > 0) {
            DownloadThread thread = threadList[0];
            threadList.RemoveAt(0);
            activeThreadList.Add(thread);

            curThreadCount++;
            thread.Start();
        }
    }

    private void OnDestroy() {
        Abort();
    }

    // 线程完成
    private void OnThreadFinished(DownloadThread thread, bool success) {
        curThreadCount--;
        activeThreadList.Remove(thread);

        // 校验
        if (success && validateMD5) {
            string md5 = CommonUtil.GetMD5FromFile(thread.file.GetSavePath(downloadToTemp));
            success = string.Equals(md5, thread.file.md5);
            if (!success) {
                Debug.LogErrorFormat("Wrong md5, local:{0}, remote:{1}, url:{2}", md5, thread.file.md5, thread.file.url);
            }
        }

        if (success) {
            // 下载成功
            totalDownloadedCount++;
        }
        else if (thread.retry < retryCount) {
            // 重试
            Debug.LogFormat("Retry: {0}", thread.file.url);
            thread.retry++;
            thread.Reset();
            threadList.Insert(0, thread);
        }

        // 队列中是否全部完成
        if (curThreadCount == 0 && threadList.Count == 0) {
            downloading = false;
            speedMonitor.Stop();

            HandleFinish();
        }
    }

    // 完成时处理
    private void HandleFinish() {
        // 下载是否全部成功
        bool success = totalDownloadedCount == totalCount;

        if (success) {
            // 写入list.json
            string path = GameUtil.GetUpdatePath("list.json");
            File.WriteAllText(path, downloadList.listJson, Encoding.UTF8);

            // 从临时目录移出
            if (downloadToTemp) {
                success = MoveTempFiles(GameUtil.GetUpdatePath("temp"));
            }
        }


        if (onFinished != null) {
            onFinished.Invoke(success);
        }

        DestroyImmediate(gameObject);
        onFinished = null;
        onProgress = null;

        if (success) {
            if (completeOperation == OPERATION_UNLOAD_AND_REENTER) {
                HotfixUtil.ReloadGame();
            }
        }
    }

    // 线程下载过程
    private void OnThreadProgress(DownloadThread thread, long delta, long downloaded, long downloadLength) {
        totalDownloaded += delta;
        speedMonitor.AddSize(delta);

        if (onProgress != null) {
            onProgress.Invoke(thread.file.index, totalDownloadedCount + 1, totalCount, totalDownloaded, totalSize, speedMonitor.CurrentSpeed);
        }
    }

    private bool MoveTempFiles(string tempPath) {
        string updatePath = GameUtil.GetUpdatePath("");
        if (!Directory.Exists(updatePath)) {
            Directory.CreateDirectory(updatePath);
        }

        try {
            string[] files = Directory.GetFiles(tempPath, "*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++) {
                string file = files[i];

                string filePath = file.Substring(tempPath.Length + 1);
                string targetFile = Path.Combine(updatePath, filePath);

                if (File.Exists(targetFile)) {
                    File.Delete(targetFile);
                }
                else {
                    FileInfo targetInfo = new FileInfo(targetFile);
                    if (!targetInfo.Directory.Exists) {
                        targetInfo.Directory.Create();
                    }
                }
                File.Move(file, targetFile);
            }

        }
        catch (System.Exception e) {
            Debug.LogException(e);
            return false;
        }
        return true;
    }


    /// <summary>
    /// 下载线程
    /// </summary>
    private class DownloadThread {

        public delegate void OnThreadFinished(DownloadThread thread, bool success);
        public delegate void OnThreadProgress(DownloadThread thread, long delta, long downloaded, long downloadLength);

        public HotfixDownloadList.File file;
        public int retry;

        private int streamFragmentSize;
        private OnThreadProgress onThreadProgress;
        private OnThreadFinished onThreadFinished;

        private HTTPRequest request;
        private long lastDownloaded;

        private string savePath;
        private string url;

        public DownloadThread(HotfixDownloadList.File file, string savePath, int streamFragmentSize, OnThreadProgress onThreadProgress, OnThreadFinished onThreadFinished) {
            this.file = file;
            this.savePath = savePath;

            this.streamFragmentSize = streamFragmentSize;
            this.onThreadProgress = onThreadProgress;
            this.onThreadFinished = onThreadFinished;

            url = file.url;
        }

        public void Start() {
            if (File.Exists(savePath)) {
                File.Delete(savePath);
            } else {
                string dir = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                }
            }

            System.Uri uri = new System.Uri(file.url);
            request = new HTTPRequest(uri, HTTPMethods.Get, OnFinished);
            request.OnProgress += OnProgress;

            request.AddHeader(HttpManager.ACCEPT_ENCODING, HttpManager.GZIP);
            request.AddHeader(HttpManager.USER_AGENT, HttpManager.AGENT);

            request.ConnectTimeout = System.TimeSpan.FromSeconds(10);
            request.Timeout = System.TimeSpan.FromSeconds(20);

            request.IsKeepAlive = true;
            request.DisableRetry = true;
            request.DisableCache = true;

            request.UseStreaming = true;
            request.StreamFragmentSize = streamFragmentSize;

            lastDownloaded = 0;

            request.Send();
        }

        public void Abort() {
            onThreadProgress = null;
            onThreadFinished = null;

            if (request != null) {
                request.Abort();
                request.Dispose();
            }
        }

        private void OnProgress(HTTPRequest originalRequest, long downloaded, long downloadLength) {
            long delta = downloaded - lastDownloaded;
            lastDownloaded = downloaded;

            if (onThreadProgress != null) {
                onThreadProgress.Invoke(this, delta, downloaded, downloadLength);
            }
        }

        public void Reset() {
            request = null;
            lastDownloaded = 0;
        }

        private void OnFinished(HTTPRequest originalRequest, HTTPResponse response) {
            if(originalRequest.State == HTTPRequestStates.Aborted || onThreadFinished == null) {
                return;
            }

            if(originalRequest.State == HTTPRequestStates.Error 
                || originalRequest.State == HTTPRequestStates.ConnectionTimedOut
                || originalRequest.State == HTTPRequestStates.TimedOut) {

                Debug.LogErrorFormat("request state:{0}, url:{1}", originalRequest.State, originalRequest.Uri);
                onThreadFinished.Invoke(this, false);
                return;
            }

            if (response == null || !response.IsSuccess) {
                Debug.LogErrorFormat("response status:{0}, url:{1}", response == null ? 0 : response.StatusCode, originalRequest.Uri);
                onThreadFinished.Invoke(this, false);
                return;
            }
            
            List<byte[]> fragments = response.GetStreamedFragments();
            if (fragments != null) {
                using (FileStream fs = new FileStream(savePath, FileMode.Append)) {
                    foreach (byte[] data in fragments) {
                        fs.Write(data, 0, data.Length);
                    }
                }
            }

            if (response.IsStreamingFinished) {
                onThreadFinished.Invoke(this, true);
            }
        }

    }

}
