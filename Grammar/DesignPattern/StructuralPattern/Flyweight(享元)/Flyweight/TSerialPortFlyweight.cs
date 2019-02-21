/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Flyweight
 * 类 名 称 ：TSerialPortFlyweight 
 * 命名空间 ：Flyweight
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 15:20:22
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 串口享元模式
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Flyweight
{
    /// <summary>
    /// 享元模式
    /// 享元=工厂+静态字典
    /// 当且仅当创建不重复的对象
    /// </summary>
    public class TSerialPortFlyweight
    {
        private static Dictionary<int, TSerialPortController> _FlyweightFactoryDictionary = new Dictionary<int, TSerialPortController>();

        private static readonly object _lock = new object();

        public static TSerialPortController Initalize(TSerialPortModel portModel)
        {
            if (!_FlyweightFactoryDictionary.ContainsKey(portModel.COMID))
            {
                lock (_lock)
                {
                    if (!_FlyweightFactoryDictionary.ContainsKey(portModel.COMID))
                    {
                        TSerialPortController portController = new TSerialPortController(portModel);
                        _FlyweightFactoryDictionary.Add(portModel.COMID, portController);
                    }
                }
            }
            return _FlyweightFactoryDictionary[portModel.COMID];

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
