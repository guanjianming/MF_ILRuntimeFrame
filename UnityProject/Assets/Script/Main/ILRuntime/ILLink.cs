using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 针对IOS平台的代码剔除做预防操作
/// </summary>
public class ILLink : MonoBehaviour
{

    private void Start()
    {
        Instantiate<GameObject>(gameObject, transform);
        Instantiate<GameObject>(gameObject, transform, true);
        Instantiate<GameObject>(gameObject, transform.position, transform.rotation);

        GameObject o = gameObject.gameObject;

        Bind<bool>();
        Bind<byte>();
        Bind<sbyte>();
        Bind<char>();
        Bind<short>();
        Bind<ushort>();
        Bind<float>();
        Bind<int>();
        Bind<uint>();
        Bind<double>();
        Bind<long>();
        Bind<ulong>();
        Bind<Vector2>();
        Bind<Vector3>();
        Bind<Vector4>();
        Bind<Vector2Int>();
        Bind<Vector3Int>();
        Bind<Quaternion>();
        Bind<GameObject>();
        Bind<Transform>();
        Bind<RectTransform>();
        Bind<Sprite>();
    }

    void Bind<T>()
    {
        BindGeneric<T, bool>();
        BindGeneric<T, byte>();
        BindGeneric<T, sbyte>();
        BindGeneric<T, char>();
        BindGeneric<T, short>();
        BindGeneric<T, ushort>();
        BindGeneric<T, int>();
        BindGeneric<T, uint>();
        BindGeneric<T, float>();
        BindGeneric<T, double>();
        BindGeneric<T, long>();
        BindGeneric<T, ulong>();
        BindGeneric<T, string>();
        BindGeneric<T, Vector2>();
        BindGeneric<T, Vector3>();
        BindGeneric<T, Vector4>();
        BindGeneric<T, Vector2Int>();
        BindGeneric<T, Vector3Int>();
        BindGeneric<T, Quaternion>();
        BindGeneric<T, GameObject>();
        BindGeneric<T, Transform>();
        BindGeneric<T, RectTransform>();
        BindGeneric<T, Sprite>();

        BindGeneric<bool, T>();
        BindGeneric<byte, T>();
        BindGeneric<sbyte, T>();
        BindGeneric<char, T>();
        BindGeneric<short, T>();
        BindGeneric<ushort, T>();
        BindGeneric<int, T>();
        BindGeneric<uint, T>();
        BindGeneric<float, T>();
        BindGeneric<double, T>();
        BindGeneric<long, T>();
        BindGeneric<ulong, T>();
        BindGeneric<string, T>();
        BindGeneric<Vector2, T>();
        BindGeneric<Vector3, T>();
        BindGeneric<Vector4, T>();
        BindGeneric<Vector2Int, T>();
        BindGeneric<Vector3Int, T>();
        BindGeneric<Quaternion, T>();
        BindGeneric<GameObject, T>();
        BindGeneric<Transform, T>();
        BindGeneric<RectTransform, T>();
        BindGeneric<Sprite, T>();
    }

    void BindGeneric<T1, T2>()
    {
        new Dictionary<T2, T1>();
        new Dictionary<T1, T2>();
        BindList<T1>();
        BindList<T2>();
        BindQueue<T1>();
        BindQueue<T2>();
        BindStack<T1>();
        BindStack<T2>();
    }

    void BindList<T>()
    {
        new List<T>();
        new Google.Protobuf.Collections.RepeatedField<T>();
    }

    void BindStack<T>()
    {
        new Stack<T>();
    }

    void BindQueue<T>()
    {
        new Queue<T>();
    }
}
