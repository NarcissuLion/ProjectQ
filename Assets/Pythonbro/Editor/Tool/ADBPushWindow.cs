using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections;

public class ADBPushWindow : EditorWindow {

    public static void ShowWindow() {
        ADBPushWindow window = GetWindow<ADBPushWindow>(false);
        window.titleContent = new GUIContent("ADB Push");
        window.Show();
    }


    string dataPath = "storage/emulated/0/android/data/";
    string packageName = "com.pythonbro.fgame";
    string updatePath = "files/update";
    string deviceId = "";
    string selectPath = "";

    string[] packageOptions = {
            "选择包名...",
            "com.pythonbro.fgame",
            "com.hnaly.gtzy.aly"
        };

    //string pushPath = "/storage/emulated/0/android/data/com.pythonera.topgunkrts/files/update";
    string output = "";
    bool clearProgressBar = false;
    bool showProgressBar = false;

    double timestamp = 0;
    float progress = 0;
    string info = "";
    Vector2 outputPos = Vector2.zero;

    void OnEnable() {
        string _dataPath = CommonUtil.GetLocalData("editor_adb_data_path", null);
        if (!string.IsNullOrEmpty(_dataPath)) {
            dataPath = _dataPath;
        }
        string _pkgName = CommonUtil.GetLocalData("editor_adb_package_name", null);
        if (!string.IsNullOrEmpty(_pkgName)) {
            packageName = _pkgName;
        }
        string _deviceId = CommonUtil.GetLocalData("editor_adb_deviceId", null);
        if (!string.IsNullOrEmpty(_deviceId)) {
            deviceId = _deviceId;
        }
    }

    private void OnDestroy() {
        EditorUtility.ClearProgressBar();
    }

    void OnGUI() {
        GUILayout.Space(15);
        //pushPath = EditorGUILayout.TextField("Push Path", pushPath);

        deviceId = EditorGUILayout.TextField("Device ID (Optional)", deviceId);
        dataPath = EditorGUILayout.TextField("Data Path", dataPath);

        EditorGUILayout.BeginHorizontal();
        packageName = EditorGUILayout.TextField("Package Name", packageName);
        int pkgIndex = EditorGUILayout.Popup(0, packageOptions, GUILayout.Width(100));
        if (pkgIndex != 0) {
            packageName = packageOptions[pkgIndex];
        }
        EditorGUILayout.EndHorizontal();

        updatePath = EditorGUILayout.TextField("Update Path", updatePath);


        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("ADB push 文件", GUILayout.Height(30))) {
            selectPath = EditorUtility.OpenFilePanel("选择文件", GetLastPath(), null);
            SetUpdatePathBySelect(selectPath);
            GUI.FocusControl(null);
        }
        if (GUILayout.Button("ADB push 文件夹", GUILayout.Height(30))) {
            selectPath = EditorUtility.OpenFolderPanel("选择文件夹", GetLastPath(), null);
            SetUpdatePathBySelect(selectPath);
            GUI.FocusControl(null);
        }
        if (GUILayout.Button("ADB shell mkdir -p", GUILayout.Height(30))) {
            //ADB mkdir \"PushPath\"
            Mkdir();
        }
        if (GUILayout.Button("ADB shell rm -r", GUILayout.Height(30))) {
            //ADB shell rm -r \"PushPath\"
            DeletePushPath();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        selectPath = EditorGUILayout.TextField("Select Path", selectPath);
        if (GUILayout.Button("GO", GUILayout.Height(30))) {
            Push(selectPath);
        }

        outputPos = EditorGUILayout.BeginScrollView(outputPos);
        output = EditorGUILayout.TextArea(output, GUILayout.ExpandHeight(true));
        EditorGUILayout.EndScrollView();
    }

    void SetUpdatePathBySelect(string selectPath) {
        if (!string.IsNullOrEmpty(selectPath)) {
            selectPath = selectPath.Replace("\\", "/");
            string streamingAssetsPath = Application.streamingAssetsPath.Replace("\\", "/");
            if (selectPath.StartsWith(streamingAssetsPath)) {
                updatePath = "files/update" + selectPath.Substring(streamingAssetsPath.Length);
            }
        }
    }

    string GetLastPath() {
        string path = CommonUtil.GetLocalData("editor_adb_push_path", null);
        if (!string.IsNullOrEmpty(path)) {
            return Path.GetDirectoryName(path);
        }
        return new DirectoryInfo(Application.dataPath + "/../").FullName;
    }

    void Push(string path) {
        if (string.IsNullOrEmpty(path)) {
            return;
        }
        if (string.IsNullOrEmpty(dataPath) || string.IsNullOrEmpty(packageName) || string.IsNullOrEmpty(updatePath)) {
            output = "路径或推送路径为空";
            EditorUtility.DisplayDialog("Are you kidding me?", "推送路径没填全", "Sorry");
            return;
        }
        GUI.FocusControl(null);
        CommonUtil.SetLocalData("editor_adb_data_path", dataPath);
        CommonUtil.SetLocalData("editor_adb_package_name", packageName);
        CommonUtil.SetLocalData("editor_adb_push_path", path);
        CommonUtil.SetLocalData("editor_adb_deviceId", deviceId);
        ClearOutput();

        EditorApplication.update += PushUpdate;
        EditorUtility.DisplayProgressBar("Push", "", 0);

        ThreadPool.QueueUserWorkItem((o) => {
            _Push(path);
        });
    }

    void PushUpdate() {
        if (showProgressBar) {
            if (EditorApplication.timeSinceStartup - timestamp >= 0.05f) {
                timestamp = EditorApplication.timeSinceStartup;
                EditorUtility.DisplayProgressBar("Push", info, progress / 100);
            }
        }
        if (clearProgressBar) {
            EditorUtility.ClearProgressBar();
            clearProgressBar = false;
            EditorApplication.update -= PushUpdate;
        }
    }

    string GetPushPath() {
        string pushPath = string.Join("/", new string[] { dataPath, packageName, updatePath });
        return pushPath.Replace("\\", "/").Replace("//", "/");
    }

    void ClearOutput() {
        output = "";
    }

    void AppendOutput(string line, bool overrideLastLine = false) {
        if (overrideLastLine) {
            int index = output.LastIndexOf("\n");
            if (index != -1) {
                output = output.Substring(0, index);
            }
        }
        if (output.Length > 0) {
            output = output + "\n";
        }
        output = output + line;
    }


    void _Push(string path) {
        ClearOutput();
        string cmd = "adb ";
        if (!string.IsNullOrEmpty(deviceId)) {
            cmd += "-s \"" + deviceId + "\" ";
        }
        cmd += "push \"" + path + "\" \"" + GetPushPath() + "\"";
        AppendOutput(cmd);

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.Arguments = "/c " + cmd;

        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();

        process.OutputDataReceived += (sender, e) => {
            if (e.Data.StartsWith("[")) {
                string _progress = CommonUtil.SubStringFromTo(e.Data, "[", "%]");
                float.TryParse(_progress, out progress);
                info = CommonUtil.SubStringFromLastTo(e.Data, "/", null);
                showProgressBar = true;
                AppendOutput(e.Data, true);
            }
            else if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
            //Repaint();
        };
        process.ErrorDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
        };

        process.WaitForExit();
        process.Close();

        showProgressBar = false;
        clearProgressBar = true;
        AppendOutput("\nDone.");
    }

    void DeletePushPath() {
        GUI.FocusControl(null);
        ClearOutput();
        string cmd = "adb ";
        if (!string.IsNullOrEmpty(deviceId)) {
            cmd += "-s \"" + deviceId + "\" ";
        }
        cmd += "shell rm -r \"" + GetPushPath() + "\"";
        AppendOutput(cmd);

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.Arguments = "/c " + cmd;

        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();

        process.OutputDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
        };
        process.ErrorDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
        };

        process.WaitForExit();
        process.Close();
        AppendOutput("\nDone.");
    }

    void Mkdir() {
        GUI.FocusControl(null);
        ClearOutput();
        string cmd = "adb ";
        if (!string.IsNullOrEmpty(deviceId)) {
            cmd += "-s \"" + deviceId + "\" ";
        }

        string filePath = updatePath;
        if (filePath.Contains(".")) {
            filePath = CommonUtil.SubStringFromTo(filePath, null, ".");
        }
        string pushPath = string.Join("/", new string[] { dataPath, packageName, filePath });
        pushPath = pushPath.Replace("\\", "/").Replace("//", "/");


        cmd += "shell mkdir -p \"" + pushPath + "\"";
        AppendOutput(cmd);

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.Arguments = "/c " + cmd;

        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();

        process.OutputDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
        };
        process.ErrorDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                AppendOutput(e.Data);
            }
        };

        process.WaitForExit();
        process.Close();
        AppendOutput("\nDone.");
    }

}