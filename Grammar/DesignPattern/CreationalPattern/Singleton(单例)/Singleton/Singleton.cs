/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Singleton
 * 类 名 称 ：Singleton 
 * 命名空间 ：Singleton
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 9:14:48
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 单例模式泛型抽象类
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;
using System.Diagnostics;
using System.Reflection;

namespace Singleton
{
    /// <summary>
    /// Static factory class for implementing the singleton pattern on Types
    /// which contain a private, parameter-less constructor.
    /// </summary>
    /// <typeparam name="T">The underlying singleton type.</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static readonly Lazy<T> _instance;

        /// <summary>
        /// Default static constructor initializes Lazy constructor.
        /// </summary>
        static Singleton()
        {
            _instance = new Lazy<T>(() =>
            {
                try
                {
                    // Binding flags include private constructors.
                    var constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                    return (T)constructor.Invoke(null);
                }
                catch (Exception exception)
                {
                    Debug.WriteLine("build " + typeof(T) + " failed:" + exception);
                    throw new SingletonConstructorException(exception);
                }
            });
        }

        /// <summary>
        /// Get the singleton instance for the class.
        /// </summary>
        public static T Instance { get { return _instance.Value; } }

        /// <summary>
        /// Get the singleton instance for the class.
        /// </summary>
        /// <returns></returns>
        public static T GetInstance() { return Instance; }
    }

    class SingletonConstructorException : Exception
    {
        public Exception Exception { get; set; }
        public SingletonConstructorException(Exception ex)
        {
            this.Exception = ex;
        }
    }
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
