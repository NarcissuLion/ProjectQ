using UnityEngine;
using System.Collections.Generic;

public class AssetCounter {

    private Dictionary<string, int> dict = new Dictionary<string, int>();
    private MultiMap<string, ChangeListener> listeners = new MultiMap<string, ChangeListener>();

    public int Add(string key, int count = 1) {
        int result = 0;
        if (dict.TryGetValue(key, out result)) {
            dict.Remove(key);
        }
        result = Mathf.Max(0, result + count);
        dict.Add(key, result);
        OnChange(key, result);
        return result;
    }

    public int Get(string key) {
        int result = 0;
        dict.TryGetValue(key, out result);
        return result;
    }

    public int Clear(string key) {
        int result = 0;
        if (dict.TryGetValue(key, out result)) {
            dict.Remove(key);
        }
        OnChange(key, result);
        return result;
    }

    public void ClearAll() {
        foreach (string key in dict.Keys) {
            OnChange(key, 0);
        }
        dict.Clear();
    }

    private void OnChange(string key, int count) {
#if UNITY_EDITOR
        foreach (ChangeListener listener in listeners.GetAll(key)) {
            if (listener != null) {
                listener.OnChange(key, count);
            }
        }
#endif
    }

    public void AddListener(string key, ChangeListener listener) {
#if UNITY_EDITOR
        listeners.Add(key, listener);
#endif
    }

    public void RemoveListener(string key, ChangeListener listener) {
#if UNITY_EDITOR
        listeners.Remove(key, listener);
#endif
    }

    public void ClearListener(string key) {
#if UNITY_EDITOR
        listeners.RemoveAll(key);
#endif
    }

    public void ClearAllListener() {
#if UNITY_EDITOR
        listeners.Clear();
#endif
    }

    public interface ChangeListener {

        void OnChange(string key, int count);

    }

}
