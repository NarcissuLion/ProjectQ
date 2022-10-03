using UnityEngine;

/// <summary>
/// 下载速度监视器
/// </summary>
class SpeedMonitor {

    public delegate void OnTick(long speed);

    public float interval = 1f;     // 速度更新的时间间隔
    public OnTick onTick;           // 速度更新时的回调

    private float timer = 0;
    private long deltaDownloadSize = 0;
    private long downloadSpeed = 0;
    private bool started = false;

    public void Start() {
        started = interval > 0;
    }

    public void Stop() {
        started = false;
    }

    // 得到当前速度
    public long CurrentSpeed
    {
        get { return downloadSpeed; }
    }

    // 帧调用
    public void OnUpdate(float deltaTime) {
        if (!started) {
            return;
        }

        timer += deltaTime;
        if (timer >= interval) {
            timer = 0;
            downloadSpeed = (long)(deltaDownloadSize / interval);
            deltaDownloadSize = 0;

            if (onTick != null) {
                onTick.Invoke(downloadSpeed);
            }
        }
    }

    public void AddSize(long deltaSize) {
        deltaDownloadSize += deltaSize;
    }
    
}

