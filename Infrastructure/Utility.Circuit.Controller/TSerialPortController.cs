using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Utility.Circuit.Model;

namespace Utility.Circuit.Controller
{
    /// <summary>
    /// 串口操作控制类
    /// </summary>
    public class TSerialPortController
    {
        private SerialPort port = new SerialPort();
        //DispatcherTimer autoSendTick = new DispatcherTimer();//定时发送

        public TSerialPortController(TSerialPortModel serialPortModel)
        {
            this.port.PortName = serialPortModel.PortName;
            this.port.BaudRate = serialPortModel.BaudRate;
            this.port.DataBits = serialPortModel.DataBit;
            this.port.StopBits = serialPortModel.StopBit;

        }

        /// <summary>
        /// 获取串口
        /// </summary>
        /// <returns></returns>
        public static string[] GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            try
            {

                if ((ports == null) || (ports.Length == 0)) //判断有没有串口 
                {
                    ports = null;
                }

            }
            catch
            {

            }

            return ports;


        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool Open()//TSerialPort com
        {
            try
            {
                //  port = new SerialPort(com.PortName, com.BaudRate, com.Parity, com.DataBits, com.StopBits);

                port.Open();

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool Close()//TSerialPort com
        {

            try
            {
                // port = new SerialPort(com.PortName, com.BaudRate, com.Parity, com.DataBits, com.StopBits);

                port.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }


        public static bool Sending = false;//正在发送数据状态字

        /// <summary>
        /// 发送模式 true:16H; false:字符模式
        /// </summary>
        public bool? SendSetMode;//发送模式

        /// <summary>
        /// 是否新行
        /// </summary>
        public bool? IsNewLine;

        /// <summary>
        /// 发送数据
        /// </summary>
        public class SendStr//发送数据线程传递参数的结构体格式
        {

            //private static bool flag = true;
            private string Str = string.Empty;

            /// <summary>
            /// 发送数据
            /// </summary>
            public string SendSetData//;//发送的数据
            {
                get
                {
                    if (IsNewLine == true)
                    {
                        return Str + "\r\n";
                    }
                    else
                    {
                        return Str;
                    }

                }

                set
                {
                    Str = value;
                }

            }

            /// <summary>
            /// 发送模式 true:16H; false:字符模式
            /// </summary>
            public bool? SendSetMode;//发送模式

            /// <summary>
            /// 是否新行
            /// </summary>
            public bool? IsNewLine;



        }

        private SendStr SendSet = new SendStr();//发送数据线程传递参数的结构体

        private static Thread _ComSend;//发送数据线程

        private void ComSend(Object obj)//发送数据 独立线程方法 发送数据时UI可以响应
        {

            lock (this)//由于send()中的if (Sending == true) return，所以这里不会产生阻塞，如果没有那句，多次启动该线程，会在此处排队
            {
                Sending = true;//正在发生状态字
                byte[] sendBuffer = null;//发送数据缓冲区
                string sendData = SendSet.SendSetData;//复制发送数据，以免发送过程中数据被手动改变
                if (SendSet.SendSetMode == true)//16进制发送
                {
                    try //尝试将发送的数据转为16进制Hex
                    {
                        sendData = sendData.Replace(" ", "");//去除16进制数据中所有空格
                        sendData = sendData.Replace("\r", "");//去除16进制数据中所有换行
                        sendData = sendData.Replace("\n", "");//去除16进制数据中所有换行
                        if (sendData.Length == 1)//数据长度为1的时候，在数据前补0
                        {
                            sendData = "0" + sendData;
                        }
                        else if (sendData.Length % 2 != 0)//数据长度为奇数位时，去除最后一位数据
                        {
                            sendData = sendData.Remove(sendData.Length - 1, 1);
                        }

                        List<string> sendData16 = new List<string>();//将发送的数据，2个合为1个，然后放在该缓存里 如：123456→12,34,56
                        for (int i = 0; i < sendData.Length; i += 2)
                        {
                            sendData16.Add(sendData.Substring(i, 2));
                        }
                        sendBuffer = new byte[sendData16.Count];//sendBuffer的长度设置为：发送的数据2合1后的字节数
                        for (int i = 0; i < sendData16.Count; i++)
                        {
                            sendBuffer[i] = (byte)(Convert.ToInt32(sendData16[i], 16));//发送数据改为16进制
                        }
                    }
                    catch //无法转为16进制时，出现异常
                    {
                        //UIAction(() =>
                        //{
                        //    autoSendCheck.IsChecked = false;//自动发送改为未选中
                        //    autoSendTick.Stop();//关闭自动发送
                        //    MessageBox.Show("请输入正确的16进制数据");
                        //});

                        Sending = false;//关闭正在发送状态
                        _ComSend.Abort();//终止本线程
                        return;//输入的16进制数据错误，无法发送，提示后返回  
                    }

                }
                else //ASCII码文本发送
                {
                    sendBuffer = System.Text.Encoding.Default.GetBytes(sendData);//转码
                }



                try//尝试发送数据
                {//如果发送字节数大于1000，则每1000字节发送一次
                    int sendTimes = (sendBuffer.Length / 1000);//发送次数
                    for (int i = 0; i < sendTimes; i++)//每次发生1000Bytes
                    {
                        port.Write(sendBuffer, i * 1000, 1000);//发送sendBuffer中从第i * 1000字节开始的1000Bytes

                    }
                    if (sendBuffer.Length % 1000 != 0)//发送字节小于1000Bytes或上面发送剩余的数据
                    {
                        port.Write(sendBuffer, sendTimes * 1000, sendBuffer.Length % 1000);

                    }


                }
                catch//如果无法发送，产生异常
                {

                }

                //sendScrol.ScrollToBottom();//发送数据区滚动到底部
                Sending = false;//关闭正在发送状态
                _ComSend.Abort();//终止本线程
            }

        }       

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendSet"></param>
        public void Send(SendStr sendSet)//发送数据，分为多线程方式和单线程方式
        {

            if (Sending == true) return;//如果当前正在发送，则取消本次发送，本句注释后，可能阻塞在ComSend的lock处
            _ComSend = new Thread(new ParameterizedThreadStart(ComSend)); //new发送线程
            SendSet.SendSetData = sendSet.SendSetData;//发送数据线程传递参数的结构体--发送的数据
            SendSet.SendSetMode = sendSet.SendSetMode;//发送数据线程传递参数的结构体--发送方式
            _ComSend.Start(SendSet);//发送线程启动

        }

    }
}
