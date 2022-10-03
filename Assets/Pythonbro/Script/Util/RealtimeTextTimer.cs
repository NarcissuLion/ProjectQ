using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

/// <summary>
/// 文本计时器，使用方法：将此组件添加到Text/TextMesh对象即可
/// </summary>
public class RealtimeTextTimer : RealtimeTimer {

    // 属性对应的索引位置
    private const int D = 0;
    private const int H = 1;
    private const int M = 2;
    private const int S = 3;
    private const int h = 4;
    private const int m = 5;
    private const int s = 6;
    private const int ms = 7;

    private readonly static string[] PATTERN_INDEX = new string[8];
    static RealtimeTextTimer() {
        PATTERN_INDEX[D] = "{D}";    // 总天数
        PATTERN_INDEX[H] = "{H}";    // 总小时数
        PATTERN_INDEX[M] = "{M}";    // 总分钟数
        PATTERN_INDEX[S] = "{S}";    // 总秒数
        PATTERN_INDEX[h] = "{h}";    // 小时
        PATTERN_INDEX[m] = "{m}";    // 分钟
        PATTERN_INDEX[s] = "{s}";    // 秒
        PATTERN_INDEX[ms] = "{ms}";  // 毫秒
    }
    // 生成实际格式模板的正则表达式
    private readonly static Regex REPLACE_REGEX = new Regex(@"{[^}]*}");

    public string beyondDayFormat = null; // 超过一天的字符串格式
    public string format = "{H:D2}:{m:D2}:{s:D2}";  // 字符串格式
    public bool updatePerSecond = true;
    public bool floor = false;

    private bool countdown = false;
    private Text textComp;
    private TextMesh textMeshComp;
    private long[] values = new long[PATTERN_INDEX.Length];
    private string realFormat = null;
    private string realBeyondDayFormat = null;

    private long lastSeconds = 0;
    private string lastFormat = null;
    private string lastBeyondDayFormat = null;

    protected override void Awake() {
        base.Awake();
        textComp = GetComponent<Text>();
        if (textComp == null) {
            textMeshComp = GetComponent<TextMesh>();
        }
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Timing() {
        base.Timing();

        if (updatePerSecond) {
            if (floor) {
                if (lastSeconds != Floor(fromSeconds)) {
                    lastSeconds = Floor(fromSeconds);
                    UpdateText();
                }
            }
            else {
                if(lastSeconds != Ceil(fromSeconds)) {
                    lastSeconds = Ceil(fromSeconds);
                    UpdateText();
                }
            }
        }
        else {
            UpdateText();
        }
    }

    protected override void Tick() {
        base.Tick();
    }

    public void UpdateText() {
        if (textComp == null && textMeshComp == null) {
            return;
        }

        int milliseconds = (int)(fromSeconds * 1000) % 1000;
        values[ms] = milliseconds;  // 毫秒

        long seconds = countdown ? Ceil(fromSeconds) : Floor(fromSeconds);
        //int seconds = (int)fromSeconds;

        values[S] = seconds;    // 总秒数

        long minute = seconds / 60;
        seconds %= 60;
        values[M] = minute;     // 总分钟数
        values[s] = seconds;    // 秒

        long hour = minute / 60;
        minute %= 60;
        values[H] = hour;       // 总小时数
        values[m] = minute;     // 分钟

        long day = hour / 24;
        hour %= 24;
        values[D] = day;        // 总天数
        values[h] = hour;       // 小时

        if (realFormat == null || lastFormat != format || lastBeyondDayFormat != beyondDayFormat) {
            GenerateRealFormat();
            lastFormat = format;
            lastBeyondDayFormat = beyondDayFormat;
        }

        string text = null;
        if (!string.IsNullOrEmpty(realBeyondDayFormat) && day >= 1) {
            text = string.Format(realBeyondDayFormat, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7])
                + string.Format(realFormat, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
        }
        else {
            text = string.Format(realFormat, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
        }

        SetText(text);
    }

    private long Ceil(double n) {
        long result = (long)n;
        if(result < n) {
            result++;
        }
        return result;
    }

    private long Floor(double n) {
        long result = (long)n;
        return result;
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    /// <param name="fromSeconds"></param>
    /// <param name="toSeconds"></param>
    public override void StartTiming(double fromSeconds, double toSeconds) {
        base.StartTiming(fromSeconds, toSeconds);

        countdown = toSeconds < fromSeconds;
        UpdateText();
    }

    protected override void TimingBeforeComplete() {
        base.TimingBeforeComplete();
    }

    public void SetText(string text) {
        if (textComp != null) {
            textComp.text = text;
        }
        else if (textMeshComp != null) {
            textMeshComp.text = text;
        }
    }

    public void GenerateRealFormat() {
        // 生成实际格式化模板
        realFormat = REPLACE_REGEX.Replace(format, (match) => {
            string value = match.Value;
            string[] values = value.Substring(1, value.Length - 2).Split(':');

            int index = GetPatternIndex("{" + values[0] + "}");
            if(index == -1) {
                return value;
            }
            values[0] = index.ToString();
            return "{" + string.Join(":", values) + "}";
        });

        if (string.IsNullOrEmpty(beyondDayFormat)) {
            realBeyondDayFormat = string.Empty;
        }
        else {
            realBeyondDayFormat = REPLACE_REGEX.Replace(beyondDayFormat, (match) => {
                string value = match.Value;
                string[] values = value.Substring(1, value.Length - 2).Split(':');

                int index = GetPatternIndex("{" + values[0] + "}");
                if (index == -1) {
                    return value;
                }
                values[0] = index.ToString();
                return "{" + string.Join(":", values) + "}";
            });
        }
        //Debug.Log(realFormat);
    }

    private int GetPatternIndex(string pattern) {
        for (int i = 0; i < PATTERN_INDEX.Length; i++) {
            if(PATTERN_INDEX[i] == pattern) {
                return i;
            }
        }
        return -1;
    }

}