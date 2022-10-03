using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class SVNTool {

    public struct Change {
        public string method;
        public string path;
        //public int version;

        //public override bool Equals(object obj) {
        //    if(obj is Change) {
        //        Change change = (Change)obj;
        //        return path == change.path;
        //    }
        //    return false;
        //}

        //public override int GetHashCode() {
        //    return path == null ? base.GetHashCode() : path.GetHashCode();
        //}
    }

    public static string GetDirVersion(string dir) {
        //if (Application.platform != RuntimePlatform.WindowsEditor) {
        //    UnityEngine.Debug.LogError("SVNTool.GetDirVersion() 目前仅支持Windows.");
        //    return null;
        //}

        // windows Mac通用
        dir = dir.Replace("\\", "/");
        if (dir.EndsWith("/")) {
            dir = dir.Remove(dir.Length - 1);
        }
        
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.FileName = "svn";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.WorkingDirectory = dir;

        //process.StartInfo.Arguments = string.Format("/c svn info {0} | findstr \"{1}\"", dir, "Name: Rev:");
        process.StartInfo.Arguments = "info";

        string curName = null;
        string result = null;
        //Debug.Log(targets);

        process.Start();
        process.BeginOutputReadLine();
        process.OutputDataReceived += (sender, e) => {
            if (e.Data == null) {
                return;
            }
            if (e.Data.StartsWith("Name: ")) {
                curName = e.Data.Substring("Name: ".Length).Trim();
            }
            if (e.Data.StartsWith("Last Changed Rev: ")) {
                string path = dir + "/" + curName;
                string version = e.Data.Substring("Last Changed Rev: ".Length).Trim();
                result = version;
            }
        };
        process.WaitForExit();
        process.Close();

        return result;
    }

    public static List<Change> LoadSvnChange(int version) {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        //process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.FileName = "svn";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.WorkingDirectory = Application.dataPath;
        process.StartInfo.Arguments = string.Format("log -r {0} -v", version);

        List<Change> changeList = new List<Change>();

        process.Start();
        process.BeginOutputReadLine();
        process.OutputDataReceived += (sender, e) => {
            if (e.Data == null) {
                return;
            }
            if (e.Data.StartsWith("   ")) {
                string[] array = e.Data.Trim().Split(new char[] { ' ' }, 2);
                Change change = new Change() {
                    method = array[0],
                    path = array[1],
                    //version = version
                };
                changeList.Add(change);
            }
            
        };
        process.WaitForExit();
        process.Close();

        return changeList;
    }

}
