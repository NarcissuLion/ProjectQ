using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于UnityEngine.UI.Text的颜色渐变
/// </summary>
[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect {

    public Color32 topColor = Color.white;
    public Color32 bottomColor = Color.black;

    public override void ModifyMesh(VertexHelper vh) {
        if (!isActiveAndEnabled) {
            return;
        }

        int count = vh.currentVertCount;
        UIVertex vertex = new UIVertex();

        for (int i = 0; i < count / 4; i++) {
            for (int j = 0; j < 4; j++) {
                int index = i * 4 + j;

                vh.PopulateUIVertex(ref vertex, index);

                if (j < 2) {
                    vertex.color = topColor;
                }
                else {
                    vertex.color = bottomColor;
                }
                vh.SetUIVertex(vertex, index);
            }
        }


    }

}

