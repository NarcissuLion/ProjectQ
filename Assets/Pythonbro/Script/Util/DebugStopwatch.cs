using System.Diagnostics;
using System.Collections.Generic;

/// <summary>
/// 调试用的计时器，打印同一个label的Start和Stop之间的毫秒数，仅在Development Build开启时有效
/// </summary>
public class DebugStopwatch {

    public static bool enabled = true;

    private static Dictionary<string, Stopwatch> dict = new Dictionary<string, Stopwatch>();

    public static void Start(string label) {
        if (enabled) {
            Stopwatch stopwatch;
            if (dict.ContainsKey(label)) {
                if (dict.TryGetValue(label, out stopwatch)) {
                    stopwatch.Stop();
                }
                dict.Remove(label);
            }
            stopwatch = new Stopwatch();
            stopwatch.Start();
            dict.Add(label, stopwatch);
        }
    }

    public static void Stop(string label) {
        if (enabled) {
            Stopwatch stopwatch;
            if (dict.TryGetValue(label, out stopwatch)) {
                stopwatch.Stop();
                double ms = stopwatch.Elapsed.TotalMilliseconds;
                if (ms < 1000) {
                    UnityEngine.Debug.LogFormat("[Timespan] {0:000.000}ms, {1}", ms, label);
                }
                else {
                    UnityEngine.Debug.LogFormat("[Timespan] {0:.000}s, {1}", ms / 1000, label);
                }
                dict.Remove(label);
            }
            else {
                UnityEngine.Debug.Log(label + " is missing.");
            }
        }
    }

    public static float GetStopElapsed(string label) {
        if (enabled) {
            Stopwatch stopwatch;
            if (dict.TryGetValue(label, out stopwatch)) {
                stopwatch.Stop();
                double ms = stopwatch.Elapsed.TotalMilliseconds;
                dict.Remove(label);
                return (float)ms;
            }
            else {
                UnityEngine.Debug.Log(label + " is missing.");
            }
        }
        return 0;
    }

    public static void ClearAll() {
        foreach (Stopwatch stopwatch in dict.Values) {
            stopwatch.Stop();
        }
        dict.Clear();
    }

}
