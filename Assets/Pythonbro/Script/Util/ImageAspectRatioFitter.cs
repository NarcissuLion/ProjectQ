using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 图片长宽比适配器
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class ImageAspectRatioFitter : MonoBehaviour {

    [System.Serializable]
    public enum AspectMode {
        None,           // 不变
        ByWidth,        // 宽度控制高度
        ByHeight,       // 高度控制宽度
        OriginSize,     // 设置为原始大小
        ImportSize      // 设置为导入大小
    }

    public AspectMode aspectMode = AspectMode.OriginSize;

    private Image image;
    private new RectTransform transform;

    void Awake() {
        image = GetComponent<Image>();
        transform = GetComponent<RectTransform>();
        Fit();
    }

    public void Fit() {
        if (aspectMode == AspectMode.None || image == null || image.sprite == null) {
            return;
        }
        Vector2 importSize = image.sprite.rect.size;
        Vector2 size = transform.rect.size;
        Vector2 sizeDelta = transform.sizeDelta;

        if (aspectMode == AspectMode.ByWidth) {
            sizeDelta.y = size.x / (importSize.x / importSize.y);
        }
        else if (aspectMode == AspectMode.ByHeight) {
            sizeDelta.x = size.y * (importSize.x / importSize.y);
        }
        else if (aspectMode == AspectMode.OriginSize) {
            image.SetNativeSize();
            return;
        }
        else if (aspectMode == AspectMode.ImportSize) {
            sizeDelta = importSize;
        }
        transform.sizeDelta = sizeDelta;
    }

}

