using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Circuit.Common.Helpers
{
    public class DataRowHelper
    {
        /// <summary>
        /// 获取DataRow的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValue<T>(DataRow dataRow, string columnName, T defaultValue)
        {
            try
            {
                object aValue = dataRow[columnName];
                if (aValue == DBNull.Value)
                {
                    return defaultValue;
                }

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)aValue;
                }
                else if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(int?))
                {
                    return (T)(object)int.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(float))
                {
                    return (T)(object)float.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(bool))
                {
                    return (T)(object)bool.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)DateTime.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(DateTime?))
                {
                    return (T)(object)DateTime.Parse(aValue.ToString());
                }
                else if (typeof(T) == typeof(TimeSpan))
                {
                    return (T)(object)TimeSpan.Parse(aValue.ToString());
                }
                return (T)(object)aValue;
            }
            catch (FormatException)
            {
                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取DataRow的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T GetValue<T>(DataRow dataRow, string columnName)
        {
            return GetValue<T>(dataRow, columnName, default(T));
        }

        /// <summary>
        /// 获取DataRow的值
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetValue(DataRow dataRow, string columnName)
        {
            return GetValue<string>(dataRow, columnName);
        }
    }
}
