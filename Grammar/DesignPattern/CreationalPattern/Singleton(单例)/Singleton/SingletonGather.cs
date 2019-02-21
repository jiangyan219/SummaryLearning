/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Singleton
 * 类 名 称 ：SingletonGather 
 * 命名空间 ：Singleton
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 9:14:07
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 单例模式汇总整理
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    #region 饿汉式
    /// <summary>
    /// 饿汉式单例
    /// 优点：
    /// 1.类加载时就创建实例
    /// 2.不存在多个线程创建多个实例的问题
    /// 缺点
    /// 1.即便这个单例没有被用到也会被创建，由于类一加载就创建实例，内存也就被浪费了
    /// 使用场景：
    /// 这种实现方式适合单例占用内存比较小，在初始化的时候就会被用到的情况。
    /// 但是单例占用的内存比较大，或单例只是在某种特定场景下才会用到，使用饿汉模式就不合适了。
    /// 这个时候就需要用到懒汉模式进行延迟加载了。
    /// </summary>
    public class SingletonHunger
    {
        private static SingletonHunger _instance = new SingletonHunger();
        private SingletonHunger() { }
        public static SingletonHunger GetInstance()
        {
            return _instance;
        }

    }

    #endregion 饿汉式

    #region 懒汉式
    /// <summary>
    /// 懒汉式单例
    /// 1.懒汉模式中的单例是在需要的时候才去创建的，如果单例已经创建，再次调用获取接口将不再重新创建对象，而是直接返回之前的对象
    /// 2.如果单例使用的次数少，并且创建单例消耗的资源较多，那么就需要实现单例按需创建，这个时候懒汉模式就是一种不错的选择。
    /// 3.但是这里的单例模式并没有考虑线程安全问题，在多个线程可能会并发调用他的GetInstance()方法时，会导致创建多个实例
    /// </summary>
    public class SingletonIdler
    {
        private static SingletonIdler _instance = null;
        private SingletonIdler() { }
        public static SingletonIdler GetInstance()
        {
            if (_instance==null)
            {
                _instance = new SingletonIdler();
            }
            return _instance;
        }
    }

    #endregion

    #region 懒汉式+双重校验锁
    /// <summary>
    /// 双重校验锁单例
    /// </summary>
    public class SingletonLock
    {
        private static SingletonLock _instance = null;

        private readonly static object _lock = new object();

        private SingletonLock() { }

        public static SingletonLock GetInstance()
        {
            if (_instance==null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonLock();
                    }
                }
            }
            return _instance;
        }


    }

    #endregion

    #region 静态内部私有类
    /// <summary>
    /// 静态内部私有类单例
    /// 1.这种方式同样利用了类加载机制来保证只创建一个instance实例。
    /// 2.它与饿汉式式一样，也是利用了类加载机制，因此不存在多线程并发的问题。
    /// 3.不一样的是，它是在类的里面去创建对象实例，这样的话只要应用中不使用内部类，内存就不会加载这个单例类，也就不会创建单例对象，
    ///   从而实现懒汉式的延迟加载。
    /// 4.这种方式可以同时保证延迟加载和线程安全。
    /// 5.之所以线程安全，是因为SingletonHolder是静态的，静态内部类只会被实例化一次，
    ///   也就是说不管多少线程，大家拿到的是同一个实例，不会再去进行多次实例化，从而达到线程安全的目的。
    /// 6.由于没有加锁，所以并发性特别高，线程还安全。
    /// 7.避免了线程不安全，延迟加载，效率高。
    /// 8.大家如果在设计中要用单例，用内部静态类最为合适。
    /// </summary>
    public class SingletonStatic
    {
        /// <summary>
        /// 静态内部类
        /// </summary>
        private static class SingletonHolder
        {
            private static SingletonStatic _Instance = new SingletonStatic();
            /// <summary>
            /// 静态内部类里的外部单例属性变量
            /// </summary>
            public static SingletonStatic Instance
            {
                get { return _Instance; }
                set { _Instance = value; }
            }
        }

        private SingletonStatic() { }

        public static SingletonStatic GetInstance()
        {
            return SingletonHolder.Instance;
        }

    }

    #endregion
}

/*----------------------------------------------------------------
 * 备    注 ：
 * 
 * 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/
