/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Flyweight
 * 类 名 称 ：TSerialPortModel 
 * 命名空间 ：Flyweight
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 15:17:51
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
using System.IO;
using System.IO.Ports;
using System.Linq;

namespace Flyweight
{
    /// <summary>
    /// TSerialPortModel
    /// </summary>
    public class TSerialPortModel
    {


        public TSerialPortModel()
        {
            this.PortName = "COM1";
            this.BaudRate = 2400;
            this.Parity = Parity.Even;
            this.DataBit = 1;
            this.StopBit = StopBits.One;
            this.BaseStream = Stream.Null;
        }

        /// <summary>
        /// 串口名称
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 奇偶校验位
        /// </summary>
        public Parity Parity { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBit { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBit { get; set; }

        /// <summary>
        /// 流控制
        /// </summary>
        public Stream BaseStream { get; set; }

        public int COMID
        {
            get
            {
                int id = Convert.ToInt32(PortName.Last());
                return id;
            }
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
