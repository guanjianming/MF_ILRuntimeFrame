using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILConfig 
{
   
}


public class DllVersion
{
    public Dictionary<string, DllConfig> dllFile = new Dictionary<string, DllConfig>();
}

public class DllConfig
{
    public string md5;
    public long size;
}