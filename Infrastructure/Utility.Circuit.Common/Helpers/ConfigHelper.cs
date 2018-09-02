using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace Utility.Circuit.Common.Helpers
{
    public class ConfigHelper
    {
        public static string GetAppSettingValue(string key)
        {
            string sVaule = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                sVaule = ConfigurationManager.AppSettings[key];
            }
            return sVaule;
        }

        public static T GetAppSettingValue<T>(string key)
        {
            return GetAppSettingValue<T>(key, default(T));
        }

        public static T GetAppSettingValue<T>(string key, T defaultValue)
        {
            try
            {
                string sVaule = GetAppSettingValue(key);
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)sVaule;
                }
                else if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(sVaule);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.Parse(sVaule);
                }
                else if (typeof(T) == typeof(float))
                {
                    return (T)(object)float.Parse(sVaule);
                }
                else if (typeof(T) == typeof(bool))
                {
                    return (T)(object)bool.Parse(sVaule);
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)DateTime.Parse(sVaule);
                }
                return (T)(object)sVaule;
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
    }
}
