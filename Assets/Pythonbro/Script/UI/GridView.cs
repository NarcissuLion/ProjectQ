using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class GridView : MonoBehaviour {

    [XLua.CSharpCallLua]
    public delegate GameObject OnCreateItem();
    [XLua.CSharpCallLua]
    public delegate void OnUpdateItem(GameObject item, int index);

    public OnCreateItem onCreateItem;
    public OnUpdateItem onUpdateItem;

    public RectOffset padding;
    public Vector2 cellSize = new Vector2(100, 100);
    public Vector2 spacing = new Vector2(10, 10);

    public GridLayoutGroup.Corner startCorner = GridLayoutGroup.Corner.UpperLeft;
    public GridLayoutGroup.Axis startAxis = GridLayoutGroup.Axis.Horizontal;
    //public TextAnchor childAlignment = TextAnchor.UpperCenter;
    public GridLayoutGroup.Constraint constraint = GridLayoutGroup.Constraint.Flexible;
    public int constraintCount = 2;

    private ScrollRect scrollRect;
    private int capacity;
    private Grid contentGridSize;
    private Grid viewGridSize;
    private Vector2 contentSize;

    private Dictionary<int, GameObject> items = new Dictionary<int, GameObject>();
    private List<GameObject> itemCache = new List<GameObject>();

    private HashSet<int> visibleIndexList = new HashSet<int>();
    private HashSet<int> becomeInvisibleIndexList = new HashSet<int>();
    private HashSet<int> becomeVisibleIndexList = new HashSet<int>();
    private HashSet<int> currentVisibleIndexList = new HashSet<int>();
    private string prefabName = null;

    private void Awake() {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    private void Start() {
        ////Test
        //int n = 0;
        //onCreateItem = () => {
        //    GameObject obj = GameUtil.CreatePrefab("Item");
        //    CommonUtil.SetText(obj, "Text1", "创建" + (n++));
        //    return obj;
        //};

        //onUpdateItem = (item, index) => {
        //    CommonUtil.SetText(item, "Text2", index.ToString());
        //};

        //Init(30);
    }

    public void Init(int capacity) {
        ClearAll();
        InitGrid(capacity);

        SetupContent(true); // 设置content的布局、大小、坐标

        OnScroll(scrollRect.normalizedPosition);
    }

    public void Reload(int capacity) {
        ClearAll();
        InitGrid(capacity);

        SetupContent(false); // 设置content的布局、大小、坐标

        OnScroll(scrollRect.normalizedPosition);
    }

    public void ReloadAndReset(int capacity) {
        ClearAll();
        scrollRect.normalizedPosition = GetZeroPos();
        InitGrid(capacity);

        SetupContent(false); // 设置content的布局、大小、坐标

        OnScroll(scrollRect.normalizedPosition);
    }

    private void InitGrid(int capacity) {
        this.capacity = capacity;
        Vector2 viewSize = GetViewportSize();

        contentGridSize = CalculateGridSize(viewSize);    // 计算数据总共站多少行多少列
        viewGridSize = CalculateViewportSize(viewSize, contentGridSize);// 计算可视区域最大包含多少行多少列
        CalculateContentSize(); // 计算content实际大小

        //Debug.Log("viewSize: " + viewSize);
        //Debug.Log("contentGridSize: " + contentGridSize);
        //Debug.Log("viewGridSize: " + viewGridSize);
    }

    public void ClearAll() {
        becomeVisibleIndexList.Clear();
        becomeInvisibleIndexList.Clear();
        currentVisibleIndexList.Clear();
        capacity = 0;

        foreach (GameObject item in items.Values) {
            itemCache.Add(item);
            item.SetActive(false);
        }
        items.Clear();
        visibleIndexList.Clear();
    }

    public void Dispose() {
        capacity = 0;

        foreach (GameObject item in items.Values) {
            Destroy(item);
        }
        foreach (GameObject item in itemCache) {
            Destroy(item);
        }

        items.Clear();
        itemCache.Clear();
        visibleIndexList.Clear();
    }

    public void LayoutInEditor() {
        if (!Application.isEditor) {
            return;
        }
        scrollRect = GetComponent<ScrollRect>();
        capacity = scrollRect.content.childCount;
        Vector2 viewSize = GetViewportSize();
        contentGridSize = CalculateGridSize(viewSize);    // 计算数据总共站多少行多少列

        SetupContent(true);

        RectTransform content = scrollRect.content;
        for(int i = 0; i < content.childCount; i++) {
            RectTransform item = content.GetChild(i) as RectTransform;
            SetAnchorByStartCorner(item);
            item.sizeDelta = cellSize;
            item.anchoredPosition = GetItemPosition(i);
        }
    }

    private void OnScroll(Vector2 pos) {
        if (capacity == 0) {
            return;
        }

        // 得到可见起点坐标
        float x = 0, y = 0;
        Vector2 anchor = scrollRect.content.anchoredPosition;
        if (startCorner == GridLayoutGroup.Corner.LowerLeft) {
            if(anchor.x > 0) {
                anchor.x = 0;
            }
            if (anchor.y > 0) {
                anchor.y = 0;
            }
            x = Mathf.Abs(anchor.x) + padding.left;
            y = Mathf.Abs(anchor.y) + padding.bottom;
        }
        else if (startCorner == GridLayoutGroup.Corner.LowerRight) {
            if (anchor.x < 0) {
                anchor.x = 0;
            }
            if (anchor.y > 0) {
                anchor.y = 0;
            }
            x = Mathf.Abs(anchor.x) + padding.right;
            y = Mathf.Abs(anchor.y) + padding.bottom;
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperLeft) {
            if (anchor.x > 0) {
                anchor.x = 0;
            }
            if(anchor.y < 0) {
                anchor.y = 0;
            }
            x = Mathf.Abs(anchor.x) + padding.left;
            y = Mathf.Abs(anchor.y) + padding.top;
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperRight) {
            if (anchor.x < 0) {
                anchor.x = 0;
            }
            if (anchor.y < 0) {
                anchor.y = 0;
            }
            x = Mathf.Abs(anchor.x) + padding.right;
            y = Mathf.Abs(anchor.y) + padding.top;
        }

        // 得到可见索引范围
        //int startRow = Mathf.FloorToInt(Mathf.Sign(anchor.y) * y / (cellSize.y + spacing.y));
        //int startCol = Mathf.FloorToInt(Mathf.Sign(anchor.x) * x / (cellSize.x + spacing.x));

        //startRow = Mathf.Clamp(startRow, 0, contentGridSize.row);
        //startCol = Mathf.Clamp(startCol, 0, contentGridSize.col);

        int startRow = Mathf.FloorToInt(y / (cellSize.y + spacing.y));
        int startCol = Mathf.FloorToInt(x / (cellSize.x + spacing.x));
        //Debug.Log(anchor.x);
        //int startIndex;
        //if (startAxis == GridLayoutGroup.Axis.Horizontal) {
        //    startIndex = startRow * contentGridSize.col + startCol;
        //}
        //else {
        //    startIndex = startCol * contentGridSize.row + startRow;
        //}

        //Debug.LogFormat("Start position: {0}, {1}", x, y);
        //Debug.LogFormat("startIndex: {0}", startIndex);

        // 和之前的可见索引范围比较，得出哪些是增加的，哪些是减少的
        // 得到becomeVisibleIndexList, becomeInvisibleIndexList
        LiuJinNouKenWoKuLaEi(startRow, startCol);

        //TODO

        // 回收变为不可见的
        foreach (int index in becomeInvisibleIndexList) {
            GameObject item = GetItem(index);
            if (item != null) {
                items.Remove(index);
                item.SetActive(false);
                itemCache.Add(item);
            }
            else {
                Debug.LogError("This shouldn't happen!");
            }
        }


        // 变为可见的，创建或者从回收池中取item，显示出来
        foreach (int index in becomeVisibleIndexList) {
            RectTransform item = null;

            int cacheCount = itemCache.Count;
            if (cacheCount > 0) {
                //GameObject obj = itemCache[cacheCount - 1];
                //itemCache.RemoveAt(cacheCount - 1);
                GameObject obj = GetFromCache(index);
                obj.SetActive(true);
                item = obj.transform as RectTransform;
            }
            else {
                GameObject obj = onCreateItem.Invoke();
                prefabName = obj.name;
                item = obj.transform as RectTransform;
                item.SetParent(scrollRect.content, false);
                SetAnchorByStartCorner(item);
                item.sizeDelta = cellSize;
            }

            items.Add(index, item.gameObject);
            item.anchoredPosition = GetItemPosition(index);
            UpdateItemName(item.gameObject, index);
            onUpdateItem.Invoke(item.gameObject, index);
        }
    }

    private Vector2 GetZeroPos() {
        if (startCorner == GridLayoutGroup.Corner.LowerLeft) {
            return new Vector2(0, 0);
        }
        else if (startCorner == GridLayoutGroup.Corner.LowerRight) {
            return new Vector2(1, 0);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperLeft) {
            return new Vector2(0, 1);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperRight) {
            return new Vector2(1, 1);
        }
        return new Vector2(0, 0);
    }

    // 从缓存中取item，尝试取相同index的
    private GameObject GetFromCache(int index) {
        if(itemCache.Count == 0) {
            return null;
        }
        string curName = prefabName + index;
        int cacheIndex = 0;
        for(int i = 0; i < itemCache.Count; i++) {
            if (itemCache[i].name == curName) {
                cacheIndex = i;
                break;
            }
        }

        GameObject obj = itemCache[cacheIndex];
        itemCache.RemoveAt(cacheIndex);
        return obj;
    }

    private void UpdateItemName(GameObject obj, int index) {
        obj.name = prefabName + index;
    }

    public GameObject GetItem(int index) {
        GameObject item;
        if (items.TryGetValue(index, out item)) {
            return item;
        }
        return null;
    }

    private void LiuJinNouKenWoKuLaEi(int startRow, int startCol) {
        becomeVisibleIndexList.Clear();
        becomeInvisibleIndexList.Clear();
        currentVisibleIndexList.Clear();

        int extraRow = 0, extraCol = 0;
        //if (startAxis == GridLayoutGroup.Axis.Horizontal) {
        //    extraRow = 1;
        //}
        //else {
        //    extraCol = 1;
        //}
        extraRow = 1;
        extraCol = 1;
        //Debug.LogFormat("startRow: {0}, startCol: {1}", startRow, startCol);

        for (int x = -extraCol; x < viewGridSize.col + extraCol; x++) {
            int col = Mathf.Clamp(startCol + x, 0, contentGridSize.col - 1);

            for (int y = -extraRow; y < viewGridSize.row + extraRow; y++) {
                int row = Mathf.Clamp(startRow + y, 0, contentGridSize.row - 1);

                int index;
                if (startAxis == GridLayoutGroup.Axis.Horizontal) {
                    index = row * viewGridSize.col + col;
                }
                else {
                    index = col * viewGridSize.row + row;
                }
                if(index >= capacity) {
                    continue;
                }

                currentVisibleIndexList.Add(index);

                if (!visibleIndexList.Contains(index)) {
                    becomeVisibleIndexList.Add(index);
                }
            }
        }

        foreach (int index in visibleIndexList) {
            if (!currentVisibleIndexList.Contains(index)) {
                becomeInvisibleIndexList.Add(index);
            }
        }

        HashSet<int> temp = visibleIndexList;
        visibleIndexList = currentVisibleIndexList;
        currentVisibleIndexList = temp;

        //PrintSet("becomeVisibleIndexList", becomeVisibleIndexList);
        //PrintSet("becomeInvisibleIndexList", becomeInvisibleIndexList);
        //PrintSet("visibleIndexList", visibleIndexList);
    }

    //StringBuilder sb = new StringBuilder();
    //private void PrintSet(string name, HashSet<int> set) {
    //    if (set.Count == 0) {
    //        return;
    //    }

    //    sb.Append(name).Append(": ");
    //    foreach (int index in set) {
    //        sb.Append(index).Append(", ");
    //    }
    //    Debug.Log(sb.ToString());
    //    sb.Remove(0, sb.Length);
    //}

    // 计算总共多少行多少列
    private Grid CalculateGridSize(Vector2 viewSize) {
        int rowCount, colCount;

        if (constraint == GridLayoutGroup.Constraint.FixedColumnCount) {
            colCount = constraintCount;
            rowCount = Mathf.CeilToInt((float)capacity / colCount);
        }
        else if (constraint == GridLayoutGroup.Constraint.FixedRowCount) {
            rowCount = constraintCount;
            colCount = Mathf.CeilToInt((float)capacity / rowCount);
        }
        else {
            if (startAxis == GridLayoutGroup.Axis.Horizontal) {
                colCount = Mathf.FloorToInt((viewSize.x - padding.horizontal + spacing.x) / (cellSize.x + spacing.x));
                rowCount = Mathf.CeilToInt((float)capacity / colCount);
            }
            else {
                rowCount = Mathf.FloorToInt((viewSize.y - padding.vertical + spacing.y) / (cellSize.y + spacing.y));
                colCount = Mathf.CeilToInt((float)capacity / rowCount);
            }
        }

        return new Grid(rowCount, colCount);
    }

    private Grid CalculateViewportSize(Vector2 viewSize, Grid contentGridSize) {
        int rowCount = Mathf.CeilToInt((viewSize.y + spacing.y) / (cellSize.y + spacing.y));
        int colCount = Mathf.CeilToInt((viewSize.x + spacing.x) / (cellSize.x + spacing.x));

        return new Grid(Mathf.Min(rowCount, contentGridSize.row), Mathf.Min(colCount, contentGridSize.col));
    }

    // 计算content的大小
    private void CalculateContentSize() {
        float x = (contentGridSize.col - 1) * spacing.x + contentGridSize.col * cellSize.x + padding.horizontal;
        float y = (contentGridSize.row - 1) * spacing.y + contentGridSize.row * cellSize.y + padding.vertical;

        contentSize = new Vector2(x, y);
    }


    // 设置content的大小和布局
    private void SetupContent(bool setPosition) {
        SetAnchorByStartCorner(scrollRect.content);
        scrollRect.content.sizeDelta = contentSize;
        if (setPosition) {
            scrollRect.content.anchoredPosition = Vector2.zero;
        }
    }

    private void SetAnchorByStartCorner(RectTransform transform) {
        if (startCorner == GridLayoutGroup.Corner.LowerLeft) {
            transform.anchorMin = new Vector2(0, 0);
            transform.anchorMax = new Vector2(0, 0);
            transform.pivot = new Vector2(0, 0);
        }
        else if (startCorner == GridLayoutGroup.Corner.LowerRight) {
            transform.anchorMin = new Vector2(1, 0);
            transform.anchorMax = new Vector2(1, 0);
            transform.pivot = new Vector2(1, 0);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperLeft) {
            transform.anchorMin = new Vector2(0, 1);
            transform.anchorMax = new Vector2(0, 1);
            transform.pivot = new Vector2(0, 1);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperRight) {
            transform.anchorMin = new Vector2(1, 1);
            transform.anchorMax = new Vector2(1, 1);
            transform.pivot = new Vector2(1, 1);
        }
    }

    // 得到viewport的大小
    private Vector2 GetViewportSize() {
        return (scrollRect.transform as RectTransform).rect.size;
        //Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(scrollRect.viewport);
        //return bounds.size;
    }

    private Vector2 GetItemPosition(int index) {
        int row, col;
        if (startAxis == GridLayoutGroup.Axis.Horizontal) {
            row = Mathf.FloorToInt(index / contentGridSize.col);
            col = index % contentGridSize.col;
        }
        else {
            col = Mathf.FloorToInt(index / contentGridSize.row);
            row = index % contentGridSize.row;
        }
        //Debug.Log(index + " : " + row+","+col);

        if (startCorner == GridLayoutGroup.Corner.LowerLeft) {
            float x = padding.left + col * (cellSize.x + spacing.x);
            float y = padding.bottom + row * (cellSize.y + spacing.y);
            return new Vector2(x, y);
        }
        else if (startCorner == GridLayoutGroup.Corner.LowerRight) {
            float x = padding.right + col * (cellSize.x + spacing.x);
            float y = padding.bottom + row * (cellSize.y + spacing.y);
            return new Vector2(-x, y);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperLeft) {
            float x = padding.left + col * (cellSize.x + spacing.x);
            float y = padding.top + row * (cellSize.y + spacing.y);
            return new Vector2(x, -y);
        }
        else if (startCorner == GridLayoutGroup.Corner.UpperRight) {
            float x = padding.right + col * (cellSize.x + spacing.x);
            float y = padding.top + row * (cellSize.y + spacing.y);
            return new Vector2(-x, -y);
        }
        return Vector2.zero;
    }


    private Vector2 GetGridPos(int row, int col) {
        return Vector2.zero;
    }



    private struct Grid {
        public int row;
        public int col;
        public Grid(int row, int col) {
            this.row = row;
            this.col = col;
        }

        public override string ToString() {
            return string.Format("({0},{1})", row, col);
        }
    }

}
