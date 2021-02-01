using Google.Protobuf;
using System;
using System.ComponentModel;
using System.IO;

public static class ProtobufHelper
{
    public static byte[] ToBytes(object message)
    {
        return ((Google.Protobuf.IMessage)message).ToByteArray();
    }

    public static void ToStream(object message, MemoryStream stream)
    {
        ((Google.Protobuf.IMessage)message).WriteTo(stream);
    }

    /// <summary>
    /// 将一个数据流转化为一个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="mes"></param>
    /// <param name="data"></param>
    public static void ToMessage(Google.Protobuf.IMessage mes, byte[] mesData)
    {
        Google.Protobuf.MessageExtensions.MergeFrom(mes, mesData);
        //if (GameManager.showNetLog == true)
        //{
        //UnityEngine.Debug.Log($"<color=green>{JsonHelper.ToJson(mes)}</color>");
        //}
    }

    public static T FromBytes<T>(byte[] bytes) where T : Google.Protobuf.IMessage
    {
        object message = Activator.CreateInstance(typeof(T));
        ((Google.Protobuf.IMessage)message).MergeFrom(bytes);//, 0, bytes.Length);
        ISupportInitialize iSupportInitialize = message as ISupportInitialize;
        if (iSupportInitialize == null)
        {
            return (T)message;
        }
        iSupportInitialize.EndInit();
        return (T)message;
    }
}
