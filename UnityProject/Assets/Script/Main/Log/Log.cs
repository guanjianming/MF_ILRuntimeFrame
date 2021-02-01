using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Log
{
    public static bool isOutFile = false;
    public StringBuilder message;
    public void Info(string str)
    {
        Debug.Log($"<color=#19C310>{str}</color>");
        if (isOutFile)
        {
            message.AppendLine($"Info:{DateTime.Now} {str}");
        }
    }


    public void Error(string str)
    {
        Debug.LogError(str);
        if (isOutFile)
        {
            message.AppendLine($"Error:{DateTime.Now} {str}");
        }
    }


    public void Warning(string str)
    {
        Debug.LogWarning(str);
        if (isOutFile)
        {
            message.AppendLine($"Warning:{DateTime.Now} {str}");
        }
    }

    public void WriteFile(string path) {
        File.WriteAllText(Path.Combine(Application.persistentDataPath, path), message.ToString());
    }

    //http服务器接收
    //public void SendLog() { 
    
    //}
}
