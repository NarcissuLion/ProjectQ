using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class LuaEncodeTool {

    public static string platform = string.Empty;
    public static string luaJIT = "LuaJIT-2.0.2";

    static List<string> paths = new List<string>();
    static List<string> files = new List<string>();

    public static void EncodeLuaFile(BuildTarget target) {
        string luaPath = Application.dataPath + "/StreamingAssets/Lua";
        string outPath = Application.dataPath + "/StreamingAssets/LuaEncode";

        if (Directory.Exists(outPath)) {
            Directory.Delete(outPath, true);
        }

        DirectoryInfo dir = new DirectoryInfo(luaPath);
        EncodeLuaDirectory(target, dir, luaPath, outPath);
    }

    public static void EncodeLuaFileAndReplace(BuildTarget target) {
        string luaPath = Application.dataPath + "/StreamingAssets/Lua";

        DirectoryInfo dir = new DirectoryInfo(luaPath);
        EncodeLuaDirectory(target, dir, luaPath, luaPath);

        EditorUtility.ClearProgressBar();
    }

    public static void EncodeLuaDirectory(BuildTarget target, DirectoryInfo dir, string luaPath, string outPath) {
        FileInfo[] files = dir.GetFiles();
        DirectoryInfo[] subDirs = dir.GetDirectories();

        int totalCount = files.Length;
        for(int i = 0; i < totalCount; i ++) {
            FileInfo file = files[i];
            if (file.Name.EndsWith(".lua")) {
                UpdateProgress(i + 1, totalCount, file.Name);

                string output = outPath + file.FullName.Substring(luaPath.Length);
                EncodeLuaFile(target, file.FullName, output, true);

                //if(luaPath != outPath) {
                //    EncodeLuaFile(file.FullName, output, true);
                //} else {
                //    string origin = file.FullName.Substring(0, file.FullName.LastIndexOf(".")) + "_origin.lua";
                //    file.MoveTo(origin);
                //    EncodeLuaFile(origin, output, true);
                //    File.Delete(origin);
                //}

            }
            else if (!file.Name.EndsWith(".meta")) {
                //Util.Log("Invalid lua file: " + file.FullName);
            }
        }

        foreach (DirectoryInfo subDir in subDirs) {
            EncodeLuaDirectory(target, subDir, luaPath, outPath);
        }
    }


    /// <summary>
    /// 数据目录
    /// </summary>
    static string AppDataPath {
        get { return Application.dataPath.ToLower(); }
    }

    /// <summary>
    /// 遍历目录及其子目录
    /// </summary>
    static void Recursive(string path) {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names) {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta"))
                continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs) {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir);
        }
    }

    static void UpdateProgress(int progress, int progressMax, string desc) {
        string title = "Encoding lua ...[" + progress + " - " + progressMax + "]";
        float value = (float)progress / (float)progressMax;
        EditorUtility.DisplayProgressBar(title, desc, value);
    }

    static void EncodeLuaFile(BuildTarget target, string srcFile, string outFile, bool isWin) {
        srcFile = srcFile.Replace('\\', '/');
        outFile = outFile.Replace('\\', '/');

        if (!srcFile.ToLower().EndsWith(".lua")) {
            File.Copy(srcFile, outFile, true);
            return;
        }

        string outDir = outFile.Substring(0, outFile.LastIndexOf("/"));

        if (!Directory.Exists(outDir)) {
            Directory.CreateDirectory(outDir);
        }

        string luaexe = string.Empty;
        string args = string.Empty;
        string exedir = string.Empty;
        string currDir = Directory.GetCurrentDirectory();

        if (Application.platform == RuntimePlatform.WindowsEditor && target == BuildTarget.Android) {
            luaexe = "luajit.exe";
            args = "-b " + srcFile + " " + outFile;
            exedir = AppDataPath.Replace("assets", "") + "LuaEncoder/" + luaJIT + "/";
        }
        else {
            return;
        }
        //else if (Application.platform == RuntimePlatform.OSXEditor)
        //{
        //    luaexe = "./luac";
        //    args = "-o " + outFile + " " + srcFile;
        //    exedir = AppDataPath.Replace("assets", "") + "LuaEncoder/LuaJIT-2.0.2/";
        //}
        Directory.SetCurrentDirectory(exedir);
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = luaexe;
        info.Arguments = args;
        info.WindowStyle = ProcessWindowStyle.Hidden;
        info.UseShellExecute = isWin;
        info.ErrorDialog = true;
        //Util.Log(info.FileName + " " + info.Arguments);

        Process pro = Process.Start(info);
        pro.WaitForExit();
        pro.Close();
        Directory.SetCurrentDirectory(currDir);
    }

}

