using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 多值Map，一个key对应多个value
/// </summary>
/// <typeparam name="K"></typeparam>
/// <typeparam name="V"></typeparam>
[System.Serializable]
public class MultiMap<K, V> {

    private Dictionary<K, List<V>> dict = new Dictionary<K, List<V>>();
    private Map<K, Indexer> indexers = new Map<K, Indexer>();

    public void Add(K key, V value) {
        if (dict.ContainsKey(key) == false) {
            dict.Add(key, new List<V>());
        }
        List<V> list;
        if (dict.TryGetValue(key, out list)) {
            list.Add(value);
        }
        else {
            throw new System.Exception("MutilMap.Add");
        }
    }

    public K[] Keys() {
        if (dict.Count == 0) {
            return new K[0];
        }
        K[] keys = new K[dict.Count];
        dict.Keys.CopyTo(keys, 0);
        System.Array.Sort(keys);
        return keys;
    }

    /// <summary>
    /// 得到指定key的值索引器
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Indexer GetValueIndexer(K key) {
        return indexers.Get(key, true, this, key);
    }

    public List<V> Values() {
        Dictionary<K, List<V>>.ValueCollection values = dict.Values;
        List<V> result = new List<V>();
        foreach (List<V> list in values) {
            result.AddRange(list);
        }
        return result;
    }

    public List<V> GetAll(K key, bool getClone = false) {
        List<V> list;
        if (dict.TryGetValue(key, out list)) {
            if (getClone) {
                return new List<V>(list);
            }
            else {
                return list;
            }
        }
        return new List<V>(0);
    }

    public V Get(K key, int index) {
        List<V> list = GetAll(key);
        if (index < list.Count) {
            return list[index];
        }
        return default(V);
    }

    public V GetFirst(K key) {
        List<V> list = GetAll(key);
        if (list.Count > 0) {
            return list[0];
        }
        return default(V);
    }

    public V GetLast(K key) {
        List<V> list = GetAll(key);
        if (list.Count > 0) {
            return list[list.Count - 1];
        }
        return default(V);
    }

    public int Size(K key) {
        return GetAll(key).Count;
    }

    public bool ContainsValue(K key, V value) {
        List<V> list = GetAll(key);
        return list.Contains(value);
    }

    public V RemoveFirst(K key) {
        List<V> list = GetAll(key);
        if (list.Count > 0) {
            V value = list[0];
            list.RemoveAt(0);
            return value;
        }
        return default(V);
    }

    public V RemoveLast(K key) {
        List<V> list = GetAll(key);
        if (list.Count > 0) {
            int last = list.Count - 1;
            V value = list[last];
            list.RemoveAt(last);
            return value;
        }
        return default(V);
    }

    public bool Remove(K key, V value) {
        List<V> list = GetAll(key);
        return list.Remove(value);
    }

    public List<V> RemoveAll(K key) {
        List<V> list;
        if (dict.TryGetValue(key, out list)) {
            dict.Remove(key);
            return list;
        }
        indexers.Remove(key);
        return new List<V>(0);
    }

    public void Clear() {
        dict.Clear();
        indexers.Clear();
    }

    /// <summary>
    /// 索引器
    /// 对指定的key进行顺序循环遍历
    /// </summary>
    [System.Serializable]
    public class Indexer {

        private int index = 0;

        private MultiMap<K, V> multiMap;
        private K key;

        public Indexer(MultiMap<K, V> multiMap, K key) {
            this.multiMap = multiMap;
            this.key = key;
        }

        public V GetNext() {
            if (index == multiMap.Size(key)) {
                index = 0;
            }
            if (index < multiMap.Size(key)) {
                index++;
                return multiMap.Get(key, index - 1);
            }
            return default(V);
        }

        public void Reset() {
            index = 0;
        }

    }


}

