using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.IO;

public class Tool : Editor
{
    [MenuItem("Assets/Convert Navmesh to Json")]
    private static void ConvertNavMeshToJson()
    {
        Debug.Log("you want to convert " + Selection.activeObject.name);
        using (Process p = new Process())
        {
            p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            string convertMediaPath = Application.dataPath + "/convert/convert_obj_three.py";
            string convertFold = Application.dataPath + "/ExportNavMesh/";
            string convertFileName = Selection.activeObject.name + ".obj";
            string convertPath = convertFold + convertFileName;
            string beConvertFileName = Selection.activeObject.name + ".json";
            string beConvertFilePath = convertFold + beConvertFileName;
            convertMediaPath.Replace("/", "\\");
            convertPath.Replace("/", "\\");
            beConvertFilePath.Replace("/", "\\");
            //string cmdstring = " python convert_obj_three.py - i xx.obj - o xx.json";
            string cmdstring1 = "python " + convertMediaPath + " -i " + convertPath + " -o " + beConvertFilePath;
            Debug.Log(cmdstring1);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
            p.Start();
            p.StandardInput.WriteLine(cmdstring1);
            p.StandardInput.AutoFlush = true;
            p.StandardInput.Close();
            p.WaitForExit();
            p.Close();

        }
    }
}
