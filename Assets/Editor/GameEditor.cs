using System.Text;
using System.Threading.Tasks;
using UnityEditor;

public class GameEditor
{
    [MenuItem("���߲˵�/������ˢ��ͼ��Ԥ��", false, 100)]
    public static void RefreshIconPrefab()
    {
        IconPrefabTool.GenerateIconPrefab();
        //ͼ��Ԥ�贴����ˢ������
        PrefabPathJsonCreator.BuildIndex();
    }
}
