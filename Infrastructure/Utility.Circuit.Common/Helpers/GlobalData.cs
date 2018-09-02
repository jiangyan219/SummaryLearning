using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Circuit.Common.Helpers
{
    public class GlobalData
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnStr
        {
            get
            {
                return ConfigHelper.GetAppSettingValue<string>("DBConnStr");
            }
        }

        /// <summary>
        /// 电路配置xml
        /// </summary>
        public static string CircuitXml = @AppDomain.CurrentDomain.BaseDirectory.ToString() + "Circuit.Xml";

        /// <summary>
        /// 参数配置xml
        /// </summary>
        public static string ParamConfigXml = @AppDomain.CurrentDomain.BaseDirectory.ToString() + "ParamConfig.Xml";

        /// <summary>
        /// 是否开启编辑
        /// </summary>
        public static bool IsEditOpen { get; set; }

    }
}
