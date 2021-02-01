using UnityEngine;
using System.Collections.Generic;
using ILRuntime.Other;
using System;
using System.Collections;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;


public class IEnumerableAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(IEnumerable);
        }
    }

    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor);
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);
    }
    //Coroutine生成的类实现了IEnumerator<System.Object>, IEnumerator, IDisposable,所以都要实现，这个可以通过reflector之类的IL反编译软件得知
    internal class Adaptor : IEnumerable, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        IMethod mToString;
        bool mToStringGot;
        bool isToStringInvoking = false;

        public Adaptor()
        {

        }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance { get { return instance; } }

        public override string ToString()
        {
            if (!mToStringGot)
            {
                mToString = instance.Type.GetMethod("ToString");
                mToStringGot = true;
            }
            if (mToString != null)
            {
               return  appdomain.Invoke(mToString, instance) as string;
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
