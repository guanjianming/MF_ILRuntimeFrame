using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HotfixStart());
    }

    IEnumerator HotfixStart() {
        ILManager iL = this.gameObject.AddComponent<ILManager>();
        iL.Init();
        yield return StartCoroutine( iL.GetServerDllVersion());
        iL.CheckIsUpdate();
        yield return StartCoroutine(iL.DownloadTasks());
        yield return StartCoroutine(iL.LoadHotfixDll());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
