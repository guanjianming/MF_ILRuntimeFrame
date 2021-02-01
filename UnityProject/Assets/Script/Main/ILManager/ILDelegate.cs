using ILRuntime.Runtime.Intepreter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ILDelegate
{
    public static void RegisterDelegate(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
    {
        //委托的注册和转换


        RegistAction<System.IAsyncResult>(appdomain);
        RegistAction<Sprite>(appdomain);
        RegistAction<Vector2>(appdomain);
        RegistAction<Vector3>(appdomain);
        RegistAction<object>(appdomain);
        RegistAction<Google.Protobuf.IMessage>(appdomain);
        RegistAction<System.EventArgs>(appdomain);
        RegistAction<GameObject>(appdomain);
        RegistAction<Adapt_IMessage.Adaptor>(appdomain);
        RegistAction<byte[]>(appdomain);
        RegistAction<int, byte[]>(appdomain);
        RegistAction<string, string>(appdomain);
        RegistAction<UnityEngine.Networking.UnityWebRequest>(appdomain);
        RegistAction<GameObject, UnityEngine.EventSystems.PointerEventData>(appdomain);
        RegistUnityDelegate<bool>(appdomain);
        RegistUnityDelegate<int>(appdomain);
        RegistUnityDelegate<float>(appdomain);
        RegistUnityDelegate<string>(appdomain);
        RegistUnityDelegate<Color>(appdomain);
        RegistUnityDelegate<Color32>(appdomain);
        RegistUnityDelegate<Vector2>(appdomain);
        RegistUnityDelegate<Vector3>(appdomain);
        RegistUnityDelegate<UnityEngine.EventSystems.BaseEventData>(appdomain);
        Comparison<byte>(appdomain);
        Predicate<byte>(appdomain);

        //基本转换器
        appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((action) =>
        {
            return new UnityEngine.Events.UnityAction(() => { ((System.Action)action)(); });
        });
        appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.TweenCallback>((action) =>
        {
            return new DG.Tweening.TweenCallback(() => { ((System.Action)action)(); });
        });


        //-----------------------如果想直接根据编辑器提示 然后复制代码进来 也是可以的,直接写在下面-----------------------------------//

        appdomain.DelegateManager.RegisterFunctionDelegate<global::Adapt_IMessage.Adaptor, global::Adapt_IMessage.Adaptor, System.Boolean>();

        appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>>>((act) =>
        {
            return new System.Comparison<System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>>((x, y) =>
            {
                return ((Func<System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>, System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>, System.Int32>)act)(x, y);
            });
        });
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Video.VideoPlayer>();
        appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Video.VideoPlayer.EventHandler>((act) =>
        {
            return new UnityEngine.Video.VideoPlayer.EventHandler((source) =>
            {
                ((Action<UnityEngine.Video.VideoPlayer>)act)(source);
            });
        });
        appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>, System.Collections.Generic.KeyValuePair<global::Adapt_IMessage.Adaptor, UnityEngine.GameObject>, System.Int32>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.TextAsset>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AudioClip, System.String>();

        appdomain.DelegateManager.RegisterFunctionDelegate<ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Boolean>();
        appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ILRuntime.Runtime.Intepreter.ILTypeInstance>>((act) =>
        {
            return new System.Predicate<ILRuntime.Runtime.Intepreter.ILTypeInstance>((obj) =>
            {
                return ((Func<ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Boolean>)act)(obj);
            });
        });

        appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.Core.DOSetter<UnityEngine.Vector2>>((act) =>
        {
            return new DG.Tweening.Core.DOSetter<UnityEngine.Vector2>((pNewValue) =>
            {
                ((Action<UnityEngine.Vector2>)act)(pNewValue);
            });
        });
        appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.Core.DOGetter<UnityEngine.Vector2>>((act) =>
        {
            return new DG.Tweening.Core.DOGetter<UnityEngine.Vector2>(() =>
            {
                return ((Func<UnityEngine.Vector2>)act)();
            });
        });




        appdomain.DelegateManager.RegisterDelegateConvertor<DG.Tweening.Core.DOSetter<System.Single>>((act) =>
        {
            return new DG.Tweening.Core.DOSetter<System.Single>((pNewValue) =>
            {
                ((Action<System.Single>)act)(pNewValue);
            });
        });
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Transform, System.Int32>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.U2D.SpriteAtlas>();
        appdomain.DelegateManager.RegisterMethodDelegate<Texture, Material>();
        appdomain.DelegateManager.RegisterMethodDelegate<Texture2D, Material, string>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Material, UnityEngine.Transform, System.Int32>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Object, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Sprite, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.U2D.SpriteAtlas, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AudioClip, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.TextAsset, UnityEngine.Transform>();
        appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Transform>();

        RegistAction<string, bool>(appdomain);
        RegistAction<System.Single, System.Boolean>(appdomain);
        appdomain.DelegateManager.RegisterFunctionDelegate<global::Adapt_IMessage.Adaptor, System.Boolean>();

        appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
        appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Int32>>((act) =>
        {
            return new System.Comparison<System.Int32>((x, y) =>
            {
                return ((Func<System.Int32, System.Int32, System.Int32>)act)(x, y);
            });
        });

        appdomain.DelegateManager.RegisterMethodDelegate<List<object>>();
        //appdomain.DelegateManager.RegisterMethodDelegate<AChannel, System.Net.Sockets.SocketError>();
        appdomain.DelegateManager.RegisterMethodDelegate<byte[], int, int>();
        //appdomain.DelegateManager.RegisterMethodDelegate<IResponse>();
        //appdomain.DelegateManager.RegisterMethodDelegate<Session, object>();
        //appdomain.DelegateManager.RegisterMethodDelegate<Session, ushort, MemoryStream>();
        //appdomain.DelegateManager.RegisterMethodDelegate<Session>();
        appdomain.DelegateManager.RegisterMethodDelegate<ILTypeInstance>();

        //Action 带有一个参数 但是没有返回值的 注册
        appdomain.DelegateManager.RegisterMethodDelegate<string>();

        //Func 带有返回值 并且带有参数的
        appdomain.DelegateManager.RegisterFunctionDelegate<int, string, string>();
        appdomain.DelegateManager.RegisterFunctionDelegate<string, string>();

        //delegate 转换
        appdomain.DelegateManager.RegisterDelegateConvertor<UnityAction<string>>
        ((act) =>
        {
            return new UnityAction<string>((arg0) =>
            {
                ((Action<string>)act)(arg0);
            });
        });

        appdomain.DelegateManager.RegisterMethodDelegate<string, string, LogType>();
        //打印用的委托转换器
        appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Application.LogCallback>((action) =>
        {
            return new UnityEngine.Application.LogCallback((s1, s2, t) => { ((System.Action<string, string, LogType>)action)(s1, s2, t); });
        });

        appdomain.DelegateManager.RegisterDelegateConvertor<System.AsyncCallback>((act) =>
        {
            return new System.AsyncCallback((ar) =>
            {
                ((Action<System.IAsyncResult>)act)(ar);
            });
        });

        appdomain.DelegateManager.RegisterFunctionDelegate<global::Adapt_IMessage.Adaptor, global::Adapt_IMessage.Adaptor, System.Int32>();

        appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<global::Adapt_IMessage.Adaptor>>((act) =>
        {
            return new System.Comparison<global::Adapt_IMessage.Adaptor>((x, y) =>
            {
                return ((Func<global::Adapt_IMessage.Adaptor, global::Adapt_IMessage.Adaptor, System.Int32>)act)(x, y);
            });
        });

        appdomain.DelegateManager.RegisterFunctionDelegate<ILRuntime.Runtime.Intepreter.ILTypeInstance, ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Int32>();
        appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ILRuntime.Runtime.Intepreter.ILTypeInstance>>((act) =>
        {
            return new System.Comparison<ILRuntime.Runtime.Intepreter.ILTypeInstance>((x, y) =>
            {
                return ((Func<ILRuntime.Runtime.Intepreter.ILTypeInstance, ILRuntime.Runtime.Intepreter.ILTypeInstance, System.Int32>)act)(x, y);
            });
        });


    }


    #region 带参数的委托注册 同时添加转换器

    static void RegistAction<T>(ILRuntime.Runtime.Enviorment.AppDomain app)
    {
        //注册需要用到的委托类型
        app.DelegateManager.RegisterMethodDelegate<T>();
        //委托转换器
        app.DelegateManager.RegisterDelegateConvertor<System.Action<T>>((action) =>
        {
            return new System.Action<T>((s) => { ((System.Action<T>)action)(s); });
        });
        //注册用到的带返回值委托类型
        app.DelegateManager.RegisterFunctionDelegate<T>();
    }
    static void RegistAction<T1, T2>(ILRuntime.Runtime.Enviorment.AppDomain app)
    {
        //注册需要用到的委托类型
        app.DelegateManager.RegisterMethodDelegate<T1, T2>();
        //委托转换器
        app.DelegateManager.RegisterDelegateConvertor<System.Action<T1, T2>>((action) =>
        {
            return new System.Action<T1, T2>((s1, s2) => { ((System.Action<T1, T2>)action)(s1, s2); });
        });
    }

    static void RegistUnityDelegate<T>(ILRuntime.Runtime.Enviorment.AppDomain app)
    {
        //注册需要用到的委托类型
        app.DelegateManager.RegisterMethodDelegate<T>();
        //委托转换器
        app.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<T>>((action) =>
        {
            return new UnityEngine.Events.UnityAction<T>((s) => { ((System.Action<T>)action)(s); });
        });
    }


    static void Comparison<T>(ILRuntime.Runtime.Enviorment.AppDomain app)
    {
        app.DelegateManager.RegisterFunctionDelegate<T, T, int>();
        app.DelegateManager.RegisterDelegateConvertor<System.Comparison<T>>((action) =>
        {
            return new System.Comparison<T>((x, y) => { return ((System.Func<T, T, int>)action)(x, y); });
        });
    }

    static void Predicate<T>(ILRuntime.Runtime.Enviorment.AppDomain app)
    {
        app.DelegateManager.RegisterFunctionDelegate<T, bool>();
        app.DelegateManager.RegisterDelegateConvertor<System.Predicate<T>>((action) =>
        {
            return new System.Predicate<T>((x) => { return ((System.Func<T, bool>)action)(x); });
        });
    }
    #endregion

}
