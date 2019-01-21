/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Clone
 * 类 名 称 ：CloneExtends 
 * 命名空间 ：Clone
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2018/12/13 10:57:28
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 对象深度克隆的学习
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2018. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Clone
{
    /// <summary>
    /// 对象克隆扩展类
    /// </summary>
    public static class CloneExtends
    {
        #region 浅克隆
        /// <summary>
        /// 对象浅克隆;无法克隆对象中的引用类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T CloneObject<T>(this T t) where T : class
        {
            T model = System.Activator.CreateInstance<T>();                     //实例化一个T类型对象
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();     //获取T对象的所有公共属性
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //判断值是否为空，如果空赋值为null见else
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                    NullableConverter nullableConverter = new NullableConverter(propertyInfo.PropertyType);
                    //将convertsionType转换为nullable对的基础基元类型
                    propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(t), nullableConverter.UnderlyingType), null);
                }
                else
                {
                    propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(t), propertyInfo.PropertyType), null);
                }
            }
            return model;
        }        

        /// <summary>
        /// 对象列表浅克隆
        /// 这个方法实际上只能完成对List的浅克隆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static IList<T> CloneList<T>(this IList<T> tList) where T : class
        {
            IList<T> listNew = new List<T>();
            foreach (var item in tList)
            {
                T model = System.Activator.CreateInstance<T>();                     //实例化一个T类型对象
                PropertyInfo[] propertyInfos = model.GetType().GetProperties();     //获取T对象的所有公共属性
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    //判断值是否为空，如果空赋值为null见else
                    if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                        NullableConverter nullableConverter = new NullableConverter(propertyInfo.PropertyType);
                        //将convertsionType转换为nullable对的基础基元类型
                        propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(item), nullableConverter.UnderlyingType), null);
                    }
                    else
                    {
                        propertyInfo.SetValue(model, Convert.ChangeType(propertyInfo.GetValue(item), propertyInfo.PropertyType), null);
                    }
                }
                listNew.Add(model);
            }
            return listNew;
        }

        #endregion

        #region 深克隆

        /// <summary>
        /// 对象深度克隆;同时克隆对象中的引用类型;对象必须被序列化过才行；
        /// 同时支持对List的深度克隆，也是必须序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T DeepCloneObject<T>(this T t) where T : class
        {
            T model = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, t);
                memoryStream.Position = 0;
                model = (T)binaryFormatter.Deserialize(memoryStream);
            }
            return model;
        }

        #endregion

        /// <summary>
        /// 获取对象的改变状态list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentobj">当前对象</param>
        /// <param name="originalObj">改变前的对象</param>
        /// <returns></returns>
        public static List<EntityStateModel> GetChanges<T>(this T currentobj, T originalObj)
        {
            List<EntityStateModel> result = new List<EntityStateModel>();
            Type t = currentobj.GetType();

            var properties = t.GetProperties();

            object originalValueObj = null;
            object currentValueObj = null;
            string originalValue = string.Empty;
            string currentValue = string.Empty;

            foreach (var item in properties)
            {
                if (item.PropertyType.IsPublic && item.CanRead && item.CanWrite)
                {
                    if (item.PropertyType.IsValueType || item.PropertyType.Name == typeof(string).Name)
                    {
                        currentValueObj = item.GetValue(currentobj, null);
                        originalValueObj = item.GetValue(originalObj, null);
                        currentValue = currentValueObj == null ? string.Empty : currentValueObj.ToString();
                        originalValue = originalValueObj == null ? string.Empty : originalValueObj.ToString();

                        if (currentValue != originalValue)
                        {
                            result.Add(new EntityStateModel() { Name = item.Name, CurrentValue = currentValue, OriginalValue = originalValue });
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            return result;
        }
    }

}

/*----------------------------------------------------------------
 * 备    注 ：
 * 
 * 
 * 
*******************************************************************
 * Copyright @ JiangYan 2018. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/
