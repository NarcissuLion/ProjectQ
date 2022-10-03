using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 协程队列
/// </summary>
public class CoroutineQueue : MonoBehaviour {

    // 协程结构体
    private class RoutineInfo {
        public string id;
        public IEnumerator routine;

        public RoutineInfo(string id, IEnumerator routine) {
            this.id = id;
            this.routine = routine;
        }
    }

    private static CoroutineQueue instance = null;

    // 安全尝试移除一个协程
    public static void TryRemove(string id) {
        if(instance != null) {
            instance.Remove(id);
        }
    }

    // 得到当前实例，没有则实例化一个，并且不会随场景销毁
    public static CoroutineQueue GetCurrent() {
        if (instance == null) {
            GameObject obj = new GameObject("CoroutineQueue");
            DontDestroyOnLoad(obj);
            instance = obj.AddComponent<CoroutineQueue>();
        }
        return instance;
    }

    public System.Action onComplete;    // 完成时回调
    public int routineCount;    // 调试用

    private List<RoutineInfo> routineList = new List<RoutineInfo>();
    private Coroutine queueCoroutine;

    private float limitTimer = 0;   // 限制单个协程最大执行时间

    private void Update() {
        if (Application.isEditor) {
            routineCount = routineList.Count;
        }

        if (queueCoroutine != null) {
            if (limitTimer > 1f) {
                limitTimer = 0;
                Debug.LogError("Restart CoroutineQueue");

                // 放弃当前协程
                StopCoroutine(queueCoroutine);
                queueCoroutine = null;

                // 继续开始后面的协程
                StartOrJoin();
            }
            else {
                limitTimer = limitTimer + Time.deltaTime;
            }
        }
    }

    private void OnDestroy() {
        instance = null;
    }

    // 添加一个协程到队列，id需唯一
    public void Add(string id, IEnumerator routine) {
        routineList.Add(new RoutineInfo(id, routine));
    }

    // 尝试移除一个未执行的协程，返回是否移除成功
    public bool Remove(string id) {
        for(int i = 0; i < routineList.Count; i++) {
            if(routineList[i].id == id) {
                routineList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // 如果未开始则开始队列
    public void StartOrJoin() {
        if(queueCoroutine != null) {
            return;
        }
        if (routineList.Count == 0) {
            Complete();
            return;
        }

        queueCoroutine = StartCoroutine(Queue());
    }

    // 队列
    private IEnumerator Queue() {
        // 执行队列中的协程
        while(routineList.Count > 0) {
            RoutineInfo routineInfo = routineList[0];
            routineList.RemoveAt(0);
            limitTimer = 0;
            yield return routineInfo.routine;
            limitTimer = 0;
        }
        // 完成回调
        Complete();
        queueCoroutine = null;
        //DestroyImmediate(gameObject);
    }

    private void Complete() {
        if (onComplete != null) {
            try {
                onComplete.Invoke();
            }
            catch (System.Exception e) {
                Debug.LogException(e);
            }
        }
        onComplete = null;
    }

}
