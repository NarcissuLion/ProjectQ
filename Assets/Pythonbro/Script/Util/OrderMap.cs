using System.Collections.Generic;

[System.Serializable]
public class OrderMap<K,V> {

    private List<K> keys;
    private Dictionary<K, V> dict;

    public OrderMap() {
        keys = new List<K>();
        dict = new Dictionary<K, V>();
    }

    public OrderMap(int capcity) {
        keys = new List<K>(capcity);
        dict = new Dictionary<K, V>(capcity);
    }

    public void Add(K key, V value) {
        keys.Add(key);
        dict.Add(key, value);
    }

    public bool Contains(K key) {
        return dict.ContainsKey(key);
    }

    public List<K> Keys() {
        return keys;
    }

    public bool Remove(K key) {
        keys.Remove(key);
        return dict.Remove(key);
    }

    public bool RemoveFirst() {
        if(Count == 0) {
            return false;
        }
        K key = keys[0];
        keys.RemoveAt(0);
        return dict.Remove(key);
    }

    public V GetAt(int index) {
        K key = keys[index];
        return dict[key];
    }

    public V Get(K key) {
        V value;
        if(dict.TryGetValue(key, out value)) {
            return value;
        }
        return default(V);
    }

    public bool TryGet(K key, out V value) {
        return dict.TryGetValue(key, out value);
    }

    public int Count {
        get {
            return keys.Count;
        }
    }

}
