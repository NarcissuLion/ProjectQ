using System.Text;
using System.Threading.Tasks;
using UnityEditor;

public class GameEditor
{
    [MenuItem("工具菜单/创建、刷新图标预设", false, 100)]
    public static void RefreshIconPrefab()
    {
        IconPrefabTool.GenerateIconPrefab();
        //图标预设创建后，刷新索引
        PrefabPathJsonCreator.BuildIndex();
    }
}
