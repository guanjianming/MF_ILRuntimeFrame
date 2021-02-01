using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ILMonoBehaviour_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(global::ILMonoBehaviour);

            field = type.GetField("OnUpdate", flag);
            app.RegisterCLRFieldGetter(field, get_OnUpdate_0);
            app.RegisterCLRFieldSetter(field, set_OnUpdate_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnUpdate_0, AssignFromStack_OnUpdate_0);
            field = type.GetField("OnLateUpdate", flag);
            app.RegisterCLRFieldGetter(field, get_OnLateUpdate_1);
            app.RegisterCLRFieldSetter(field, set_OnLateUpdate_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnLateUpdate_1, AssignFromStack_OnLateUpdate_1);


        }



        static object get_OnUpdate_0(ref object o)
        {
            return ((global::ILMonoBehaviour)o).OnUpdate;
        }

        static StackObject* CopyToStack_OnUpdate_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::ILMonoBehaviour)o).OnUpdate;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnUpdate_0(ref object o, object v)
        {
            ((global::ILMonoBehaviour)o).OnUpdate = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnUpdate_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnUpdate = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::ILMonoBehaviour)o).OnUpdate = @OnUpdate;
            return ptr_of_this_method;
        }

        static object get_OnLateUpdate_1(ref object o)
        {
            return ((global::ILMonoBehaviour)o).OnLateUpdate;
        }

        static StackObject* CopyToStack_OnLateUpdate_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((global::ILMonoBehaviour)o).OnLateUpdate;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnLateUpdate_1(ref object o, object v)
        {
            ((global::ILMonoBehaviour)o).OnLateUpdate = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnLateUpdate_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnLateUpdate = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ((global::ILMonoBehaviour)o).OnLateUpdate = @OnLateUpdate;
            return ptr_of_this_method;
        }



    }
}
