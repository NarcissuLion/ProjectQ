using System;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

public class JsonUtil {

    public static T ParseJsonObject<T>(string json) {
        if (string.IsNullOrEmpty(json)) {
            return default(T);
        }
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static JObject ParseJsonObject(string json) {
        if (string.IsNullOrEmpty(json)) {
            return null;
        }
        try {
            return JObject.Parse(json);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
        return null;
    }

    public static JArray ParseJsonArray(string json) {
        try {
            return JArray.Parse(json);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
        return null;
    }

    public static string ToJsonString(object obj, bool prettyPrint = false) {
        return JsonConvert.SerializeObject(obj, prettyPrint ? Formatting.Indented : Formatting.None);
    }

    public static string ToString(JContainer json, bool prettyPrint = false) {
        if (json == null) {
            return null;
        }
        return json.ToString(prettyPrint ? Formatting.Indented : Formatting.None);
    }

    public static T GetValue<T>(JObject json, string key, bool byPath = false) {
        if(json != null) {
            JToken token = byPath ? json.SelectToken(key) : json.GetValue(key);
            if (token != null) {
                return token.Value<T>();
            }
        }
        return default(T);
    }

    public static JObject GetJsonObject(JObject json, string key, bool byPath = false) {
        if (json != null) {
            JToken token = byPath ? json.SelectToken(key) : json.GetValue(key);
            if (token != null) {
                return token.Value<JObject>();
            }
        }
        return null;
    }

    public static JArray GetJsonArray(JObject json, string key, bool byPath = false) {
        if (json != null) {
            JToken token = byPath ? json.SelectToken(key) : json.GetValue(key);
            if (token != null) {
                try {
                    return token.Value<JArray>();
                }
                catch (Exception e) {
                    // 兼容狗屎lua，lua区分不开 {} 和 []
                    Debug.Log(e.ToString());
                    return new JArray();
                }
            }
        }
        return null;
    }

    public static string GetString(JToken json, string key, string defaultValue = null) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<string>();
            }
        }
        return defaultValue;
    }

    public static int GetInt(JToken json, string key, int defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<int>();
            }
        }
        return defaultValue;
    }

    public static float GetFloat(JToken json, string key, float defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<float>();
            }
        }
        return defaultValue;
    }

    public static double GetDouble(JToken json, string key, double defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<double>();
            }
        }
        return defaultValue;
    }

    public static long GetLong(JToken json, string key, long defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<long>();
            }
        }
        return defaultValue;
    }

    public static bool GetBool(JToken json, string key, bool defaultValue = false) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<bool>();
            }
        }
        return defaultValue;
    }


    public static string GetString(JObject json, string key, string defaultValue = null) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<string>();
            }
        }
        return defaultValue;
    }

    public static int GetInt(JObject json, string key, int defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<int>();
            }
        }
        return defaultValue;
    }

    public static float GetFloat(JObject json, string key, float defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<float>();
            }
        }
        return defaultValue;
    }

    public static double GetDouble(JObject json, string key, double defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<double>();
            }
        }
        return defaultValue;
    }

    public static long GetLong(JObject json, string key, long defaultValue = 0) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<long>();
            }
        }
        return defaultValue;
    }

    public static bool GetBool(JObject json, string key, bool defaultValue = false) {
        if (json != null) {
            JToken token = json.SelectToken(key);
            if (token != null) {
                return token.Value<bool>();
            }
        }
        return defaultValue;
    }



}
