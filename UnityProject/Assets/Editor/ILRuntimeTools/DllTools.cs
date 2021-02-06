using ILRuntime.Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditorInternal;
using UnityEngine;

public class DllTools
{
    class DllTextAssets
    {
        public string name;
        public string[] references;
        public string[] excludePlatforms;
        public string[] includePlatforms;
        public bool allowUnsafeCode = true;
        public bool overrideReferences = false;
        public string[] precompiledReferences;
        public bool autoReferenced = true;
        public string[] defineConstraints;
        public string[] versionDefines;
    }

    //static string ThirdPartyDll = "Assets/Script/ThirdParty/Unity.ThirdParty.asmdef";
    static string Main = "Assets/Script/Main/Unity.Main.asmdef";
    static string Hotfix = "Assets/Script/Hotfix/Unity.Hotfix.asmdef";

    static string mainDllName = "main";
    static string hotfixDllName = "hotfix";

    //[MenuItem("Assets/删除dll")]
    public static void DeleteDll()
    {
        EditorApplication.LockReloadAssemblies();
        string tPath = Application.dataPath.Replace("Assets", $"{Main}");
        if (File.Exists(tPath))
        {
            Debug.Log("已删除Main.dll");
            File.Delete(tPath);
        }

        string mPath = Application.dataPath.Replace("Assets", $"{Hotfix}");
        if (File.Exists(mPath))
        {
            Debug.Log("已删除Hotfix.dll");
            File.Delete(mPath);
        }
        PlayerBuildSetting(false);
        EditorApplication.UnlockReloadAssemblies();
        CompilationPipeline.RequestScriptCompilation();
    }

    //[MenuItem("Assets/创建dll")]
    public static void CreateDll()
    {
        AssetDatabase.Refresh();
        EditorApplication.LockReloadAssemblies();
        DllTextAssets mainAssemblyDefinition = new DllTextAssets()
        {
            name = mainDllName,
            allowUnsafeCode = true,
            overrideReferences = false,
            autoReferenced = true,
            references = new string[] { "spine-unity" , "TextAnimation" }
        };
        string mainDllPath = Application.dataPath.Replace("Assets", $"{Main}");
        if (File.Exists(mainDllPath))
        {
            Debug.Log($"已包含{Main},现在进行删除...");
            File.Delete(mainDllPath);
        }
        Debug.Log($"重新创建 {Main} ...");
        using (StreamWriter sw = new StreamWriter(mainDllPath))
        {
            sw.Write(JsonUtility.ToJson(mainAssemblyDefinition));
        }


        DllTextAssets hotfixAssemblyDefinition = new DllTextAssets()
        {
            name = hotfixDllName,
            allowUnsafeCode = true,
            overrideReferences = false,
            autoReferenced = true,
            //, "Unity.Timeline"
            references = new string[] { mainDllName, "spine-unity", "TextAnimation" },
            includePlatforms = new string[1] { "Editor" }
        };
        string hotfixDllPath = Application.dataPath.Replace("Assets", $"{Hotfix}");
        if (File.Exists(Hotfix))
        {
            Debug.Log($"已包含{Hotfix},现在进行删除...");
            File.Delete(Hotfix);
        }
        Debug.Log($"重新创建 {Hotfix} ...");
        using (StreamWriter sw = new StreamWriter(Hotfix))
        {
            sw.Write(JsonUtility.ToJson(hotfixAssemblyDefinition));
        }
        AssetDatabase.Refresh();

        PlayerBuildSetting(true);
        EditorApplication.UnlockReloadAssemblies();

        CompilationPipeline.RequestScriptCompilation();
        CompilationPipeline.compilationFinished += (obj) => { CreateDllConfig(); };
    }

    public static void PlayerBuildSetting(bool hotfixMode)
    {
        string[] defs;
        PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone,out defs);

        List<string> newDefs = defs.ToList();
        string[] logic = new string[] { "ILRuntime", "DISABLE_ILRUNTIME_DEBUG" };
        //AndroidArchitecture aac = AndroidArchitecture.None;
        if (hotfixMode)
        {
            for (int i = 0; i < logic.Length; i++)
            {
                if (!newDefs.Contains(logic[i]))
                {
                    newDefs.Add(logic[i]);
                }
            }
           
            //aac = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;
        }
        else
        {

            for (int i = 0; i < logic.Length; i++)
            {
                if (newDefs.Contains(logic[i]))
                {
                    newDefs.Remove(logic[i]);
                }
            }
            //aac = AndroidArchitecture.ARMv7;
        }
        
#if UNITY_STANDALONE_WIN
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, newDefs.ToArray());
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_4_6);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
#elif UNITY_ANDROID
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,  newDefs.ToArray());
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_4_6);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android,hotfixMode? ScriptingImplementation.IL2CPP: ScriptingImplementation.Mono2x);
        //PlayerSettings.Android.targetArchitectures = aac;
#elif UNITY_STANDALONE_OSX || UNITY_IPHONE
       PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, newDefs.ToArray());
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.iOS, ApiCompatibilityLevel.NET_4_6);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
#endif
        PlayerSettings.allowUnsafeCode = true;

        //这个....根据自己项目需求裁剪....
        PlayerSettings.stripEngineCode = false;

        AssetDatabase.SaveAssets();

    }




    //生成dll版本配置
    public static void CreateDllConfig(string dllOutPath="")
    {
        //读取
        string dllRoot = Application.dataPath + "/../Library/ScriptAssemblies/";

        string hotfixdll = Path.Combine(dllRoot, hotfixDllName+".dll");
        string hotfixPdb = Path.Combine(dllRoot, hotfixDllName+".pdb");

        if (string.IsNullOrEmpty(dllOutPath))
        {
            dllOutPath = Application.dataPath + "/../Dll/";
        }
       
        if (Directory.Exists(dllOutPath))
        {
            Directory.Delete(dllOutPath,true);
        }
        Directory.CreateDirectory(dllOutPath);
        File.Copy(hotfixdll, Path.Combine(dllOutPath, hotfixDllName+ ".dll"));
        File.Copy(hotfixPdb, Path.Combine(dllOutPath, hotfixDllName+ ".pdb"));

        DllVersion dllVersion = new DllVersion();
        ReadDllInfo(dllVersion, Path.Combine(dllOutPath, hotfixDllName + ".dll"));
        ReadDllInfo(dllVersion, Path.Combine(dllOutPath, hotfixDllName + ".pdb"));

       string json= LitJson.JsonMapper.ToJson(dllVersion);
        Debug.Log(json);
        File.WriteAllText(Path.Combine(dllOutPath,"dllVersion.txt"),json);
    }

    public static void ReadDllInfo(DllVersion dllVersion, string path)
    {
        string md5 = MD5Helper.FileMD5(path);
        FileInfo fileInfo = new FileInfo(path);
        long size = fileInfo.Length;
        dllVersion.dllFile.Add(Path.GetFileName(path), new DllConfig() { md5 = md5, size = size });
    }


    //将dll复制到沙盒目录 方便于PC进行测试
    public static void CopyDllToPersistentDataPath() {
        CreateDllConfig(Path.Combine(Application.persistentDataPath, "Dll")) ;
        Application.OpenURL(Path.Combine(Application.persistentDataPath, "Dll"));
    }


    //[MenuItem("Tools/List Player Assemblies in Console")]
    public static void PrintAssemblyNames()
    {
        UnityEngine.Debug.Log("== Player Assemblies ==");
        Assembly[] playerAssemblies =
            CompilationPipeline.GetAssemblies(AssembliesType.Player);

        foreach (var assembly in playerAssemblies)
        {
            UnityEngine.Debug.Log(assembly.name);
        }
    }


}
