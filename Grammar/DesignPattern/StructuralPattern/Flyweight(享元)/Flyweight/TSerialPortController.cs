/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Flyweight
 * 类 名 称 ：TSerialPortController 
 * 命名空间 ：Flyweight
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 15:17:34
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 
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

namespace Flyweight
{
    /// <summary>
    /// TSerialPortController
    /// </summary>
    public class TSerialPortController
    {
        public TSerialPortController()
        {

        }

        public TSerialPortController(TSerialPortModel serialPortModel)
        {
            //this._Port.PortName = serialPortModel.PortName;
            //this._Port.BaudRate = serialPortModel.BaudRate;
            //this._Port.DataBits = serialPortModel.DataBit;
            //this._Port.StopBits = serialPortModel.StopBit;
            //this._Port.DataReceived += new SerialDataReceivedEventHandler(Sub_DataReceivedEventHandler);
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
