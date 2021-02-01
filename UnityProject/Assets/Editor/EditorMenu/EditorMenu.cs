using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorMenu : Editor
{

    [MenuItem("Assets/Hotfix/CreateDll")]
    public static void CreateDll() {
        DllTools.CreateDll();
    }

    [MenuItem("Assets/Hotfix/DeleteDll")]
    public static void DeleteDll()
    {
        DllTools.DeleteDll();
    }

    [MenuItem("Assets/Hotfix/CopyDllToPersistentDataPath")]
    public static void CopyDllToPersistentDataPath() {
        DllTools.CopyDllToPersistentDataPath();
    }

}
