# MF_ILRuntimeFrame

请关注:http://www.unity3d.xin/ 后续将推出本框架的详细教程
	
Help：
	作者QQ:2529331994
	QQ群：150501217
	


框架解决的问题:

    1.将代码热更脱离Assetbundle资源热更,独立的部分更适用于各种不同的框架。
    2.加快项目的逻辑更新,bug修复.(后期修bug,多数情况下并不用动到资源,只需要更新脚本代码,无需重走资源打包发布流程,大大提升效率)
    3.提供热更模式和正常开发模式的快速切换接口,可以让队友像平常一样去开发.
    4.不依赖市面上的任何AB框架,完全兼容市面上各种不同的AB框架.
    5.重点:希望通过它,帮助你学习、了解ILRuntime真正在项目中的应用.


框架设计介绍:
	
	1.Create hotfixdll接口
		将热更部分的代码 编译成dll
    		生成dll配置(MD5)
    
	2.更新对比接口
		本地跟服务器的dll进行版本对比
		
	3.下载热更dll
		下载dll本身的文件
		下载版本记录文件
		
	4.加载热更dll
		加载dll
		实例化:AppDomain
		初始化:
		注册跨域继承适配器
		注册委托适配器
		LitJson重定向
		调用性能优化(CLR绑定功能)
			热更调用主工程的接口 进行静态绑定 减少调用时候产生的GC
				为什么会产生GC呢?
					在热更的代码里调用Unity主工程的方法
					ILRuntime会通过反射对目标方法进行调用
					这个过程会因为装箱，拆箱等操作，产生大量的GC Alloc和额外开销 
		调用热更接口Hotfix.HotfixCodeManager.Main 进入热更逻辑
		
	5.ILMonoBehaviour
		用于监听组件的生命周期,实际是桥接(调用)热更的逻辑
		Awake
		Start
		Enable
		Update
		LateUpdate
		.......
		
	6.添加其他常用的库
		DOTween
		LitJson
		Spine
		Google.Protobuf
		TextAnimation
		可以根据上面的方式,自行添加依赖的库...
		
