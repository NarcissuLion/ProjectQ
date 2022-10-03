using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


public class TextConfig {

    private static Regex unicodeRegex = new Regex(@"\\u([0-9a-f]{4})");
    private static MatchEvaluator unicodeMatch = x => Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)).ToString();

    //private Map<string, string> config = new Map<string, string>();
    private Dictionary<string, string> config = new Dictionary<string, string>();

    public TextConfig() {

    }

    public void Load(string path) {
#if UNITY_EDITOR
        if (!Application.isPlaying) {
            BetterStreamingAssets.Initialize();
        }
#endif
        LoadByPath(path);
    }

    public void LoadByPath(string path) {
        byte[] bytes = GameUtil.LoadDecryptBytes(path);
        if (bytes == null || bytes.Length == 0) {
            Debug.LogError("Text config load fail: " + path);
            return;
        }

        //DebugStopwatch.Start("Parse text");
        using (MemoryStream stream = new MemoryStream(bytes)) {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string line = null;
            while ((line = reader.ReadLine()) != null) {
                //string[] array = line.Split(new char[] { '=' }, 2);
                int eqIndex = line.IndexOf("=");
                if (eqIndex <= 0) {
                    continue;
                }

                string key = line.Substring(0, eqIndex);
                string value = line.Substring(eqIndex + 1);

                // 将\n改成真的回车
                value = value.Replace("\\n", "\n");

                if (value == null || value.Length == 0) {
                    continue;
                }

                if (!config.ContainsKey(key)) {
                    config.Add(key, value);
                }
                else {
                    Debug.LogErrorFormat("Text key already exist: {0}", key);
                }
            }
            reader.Close();
        }
        //DebugStopwatch.Stop("Parse text");
        //Debug.Log("Text count: " + config.Size());
    }

    public void Clear() {
        config.Clear();
    }

    public string Get(string key) {
        string value;
        if (config.TryGetValue(key, out value)) {
            return value;
        }
        return null;
    }

    public static string UnicodeToWord(string source) {
        return unicodeRegex.Replace(source, unicodeMatch);
    }

}

