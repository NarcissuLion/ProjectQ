using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour {

    public string format = "{0:F2} FPS";
    public Text textFPS;

    /// <summary>
    /// 每次刷新计算的时间      帧/秒
    /// </summary>
    public float updateInterval = 0.5f;

    /// <summary>
    /// 最后间隔结束时间
    /// </summary>
    private double lastInterval;
    private int frames = 0;
    private float curFPS = 0;

    private void Awake() {
        if (textFPS == null) {
            textFPS = GetComponent<Text>();
        }
    }

    void Start() {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void Update() {
        if (textFPS == null) {
            return;
        }

        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval) {
            curFPS = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;

            textFPS.text = string.Format(format, curFPS);
        }
    }

}