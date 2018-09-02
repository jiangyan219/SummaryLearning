using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Utility.Circuit.Model
{
    /// <summary>
    /// 类：串口信息
    /// </summary>
    public class TSerialPortModel
    {


        public TSerialPortModel()
        {
            this.PortName = "COM1";
            this.BaudRate =2400;
            this.Parity = Parity.Even;
            this.DataBit = 8;
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





    }
}
