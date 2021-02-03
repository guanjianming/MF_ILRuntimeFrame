using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix
{
    public class HotfixApplication
    {
        //热更代码的入口
        public static void Main() {
            Debug.Log("这是热更入口!");
            HotfixTest hotfixTest = new HotfixTest();
            hotfixTest.Init();
        }
    }

    public class HotfixTest
    {
        public void Init() {
            GameObject go = new GameObject();
            go.name = "hotfixTest";
            ILMonoBehaviour iLMonoBehaviour= go.AddComponent<ILMonoBehaviour>();
            iLMonoBehaviour.OnUpdate += OnUpdate;
            iLMonoBehaviour.OnLateUpdate += OnLateUpdate;
        }

        private void OnLateUpdate()
        {
            Debug.Log("OnLateUpdate");
        }

        private void OnUpdate()
        {
            Debug.Log("OnUpdate");
        }
    }
}
