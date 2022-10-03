using UnityEngine;

/// <summary>
/// 计时器组件
/// </summary>
public class RealtimeTimer : MonoBehaviour {

    /// <summary>
    /// 计时完成时回调
    /// </summary>
    public delegate void OnComplete();
    public OnComplete onComplete;

    /// <summary>
    /// 计时间隔回调
    /// </summary>
    public delegate void OnTick(double fromSeconds, double toSeconds);
    public OnTick onTick;

    /// <summary>
    /// 每帧回调
    /// </summary>
    public delegate void OnUpdate(double fromSeconds, double toSeconds);
    public OnUpdate onUpdate;

    public string key;                  // 标记信息，可选
    public float tickInterval = 1.0f;   // tick调用间隔
    public bool useFixedUpdate = false; // 是否使用fixedUpdate
    public double fromSeconds = 0;       // 开始秒数
    public double toSeconds = 0;         // 结束秒数
    public bool autoStart = false;
    public float offset = 1;            // 偏移

    private bool timing = false;
    private float timestamp = 0;
    private float timer = 0;

    protected virtual void Awake() {
        
    }

    protected virtual void Start() {
        if (autoStart) {
            StartTiming(fromSeconds, toSeconds);
        }
    }

    protected virtual void Update() {
        if (timing && !useFixedUpdate) {
            Timing();
        }
    }

    protected virtual void FixedUpdate() {
        if (timing && useFixedUpdate) {
            Timing();
        }
    }

    protected virtual void OnDestroy() {
        onComplete = null;
        onTick = null;
        onUpdate = null;
    }

    protected virtual void Timing() {
        float delta = Time.realtimeSinceStartup - timestamp;
        timer += delta;
        timestamp = Time.realtimeSinceStartup;

        //if(fromSeconds > toSeconds) {
        //    fromSeconds -= delta;
        //}
        //else {
        //    fromSeconds += delta;
        //}
        fromSeconds = MoveTowards(fromSeconds, toSeconds, delta);

        TimingBeforeComplete();

        if (timer >= tickInterval) {
            timer -= tickInterval;
            Tick();
        }

        if (fromSeconds == toSeconds) {
            timing = false;
            Complete();
        }
    }

    protected double MoveTowards(double current, double target, double maxDelta) {
        if (current > target) {
            current -= maxDelta;
            if (current < target) {
                current = target;
            }
        }
        else if (current < target) {
            current += maxDelta;
            if (current > target) {
                current = target;
            }
        }
        return current;
    }

    protected virtual void TimingBeforeComplete() {
        if (onUpdate != null) {
            onUpdate.Invoke(fromSeconds, toSeconds);
        }
    }

    protected virtual void Complete() {
        if (onComplete != null) {
            onComplete.Invoke();
        }
    }

    protected virtual void Tick() {
        if (onTick != null) {
            onTick.Invoke(fromSeconds, toSeconds);
        }
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    /// <param name="fromSeconds"></param>
    /// <param name="toSeconds"></param>
    public virtual void StartTiming(double fromSeconds, double toSeconds) {
        this.fromSeconds = fromSeconds;
        this.toSeconds = toSeconds;
        timing = true;
        timestamp = Time.realtimeSinceStartup;
        timer = 0;
        Tick();
    }

    /// <summary>
    /// 结束计时
    /// </summary>
    public void StopTiming() {
        timing = false;
    }

}
