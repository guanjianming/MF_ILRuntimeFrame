using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[System.Reflection.Obfuscation(Exclude = true)]
public static class ILRuntimeCLRBinding
{
    //[MenuItem("Tools/ILRuntime/Generate CLR Binding Code")]
    static void GenerateCLRBinding()
    {
        List<Type> types = new List<Type>();
        types.Add(typeof(int));
        types.Add(typeof(float));
        types.Add(typeof(long));
        types.Add(typeof(object));
        types.Add(typeof(string));
        types.Add(typeof(Array));
        types.Add(typeof(Vector2));
        types.Add(typeof(Vector3));
        types.Add(typeof(Quaternion));
        types.Add(typeof(GameObject));
        types.Add(typeof(UnityEngine.Object));
        types.Add(typeof(Transform));
        types.Add(typeof(RectTransform));
        types.Add(typeof(Time));
        types.Add(typeof(Debug));
        //所有DLL内的类型的真实C#类型都是ILTypeInstance
        types.Add(typeof(List<ILRuntime.Runtime.Intepreter.ILTypeInstance>));

        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(types, "Assets/Script/Modle/ILBinding");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/ILRuntime/生成CLR绑定代码(自动分析)")]
    public static void GenerateCLRBindingByAnalysis()
    {
        //GenerateCLRBinding();

        //用新的分析热更dll调用引用来生成绑定代码
        ILRuntime.Runtime.Enviorment.AppDomain appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();

        string path = Application.dataPath.Replace("Assets", "/Library/ScriptAssemblies/hotfix.dll");
        if (!File.Exists(path))
        {
            Debug.LogError("需要先创建dll(描述文件) 然后编译完后再来生成!");

            //需要先创建dll 然后编译完后再来生成
            //DllTools.CreateDll();
        }

        using (FileStream fs = new FileStream("Assets/../Library/ScriptAssemblies/hotfix.dll", FileMode.Open, FileAccess.Read))
        {
            appdomain.LoadAssembly(fs);

            ILAdaptor.RegisterAdaptor(appdomain);//跨域继承适配器的注册
            ILDelegate.RegisterDelegate(appdomain);//委托适配器

            LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appdomain); //LitJson重定向


            ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(appdomain, "Assets/Script/Main/ILBinding");
            AssetDatabase.Refresh();
        }
    }
}
