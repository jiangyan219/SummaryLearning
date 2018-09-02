using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows;
using Utility.Circuit.Controller;
using Utility.Circuit.Model;

namespace AE240_Simulator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// 这个类包含主视图可以绑定到的属性。
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// 使用MVVMinpc这段添加的可绑定属性的问题。
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// 您还可以将混合使用与工具支持的数据绑定。
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
             
        private TSerialPortController port = null;
        private TSerialPortModel portInfo = new TSerialPortModel();

        public string comName { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// 初始化一个MainViewModel新实例
        /// </summary>
        public MainViewModel()//string[] comportList
        {           
            
            Initealize();
            btnOpenPort_Click();
            btnClosePort_Click();
        }

        

        #region 界面信息

        #region 下拉框信息

        public List<string> COMS { get; set; }

        public List<string> BaudRates { get; set; }
        public List<string> StopBits { get; set; }
        public List<string> DataBits { get; set; }
        public List<string> Paritys { get; set; }
        public List<string> BaseStreams { get; set; }



        #endregion

        #region 串口信息

        public string _BaudRate;

        /// <summary>
        /// 串口名称
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate
        {
            get { return _BaudRate; }
            set
            {
                _BaudRate = value;
                RaisePropertyChanged("BaudRate");
            }

        }

        /// <summary>
        /// 奇偶校验位
        /// </summary>
        public string Parity { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public string DataBit { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBit { get; set; }

        /// <summary>
        /// 流控制
        /// </summary>
        public string BaseStream { get; set; }

        #endregion

        public string strTest = "姜彦123";
        public string SendString
        {
            get { return strTest; }
            set
            {
                strTest = value;
                RaisePropertyChanged("SendString");//绑定的返回响应  就是改变值之后  界面响应到此次改变 姜彦 20180110
            }

        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initealize()
        {

            COMS = new List<string>();
            GetPorts();
            LoadViewInfo();            
            port = new TSerialPortController(portInfo);
            SerialPortInitealize();
            SendString = "绑定测试";
            
        }

        /// <summary>
        /// 加载串口信息
        /// </summary>
        private void SerialPortInitealize()
        {
            portInfo.PortName = PortName;
            portInfo.BaudRate = Convert.ToInt32(BaudRate);
            portInfo.DataBit = Convert.ToInt32(DataBit);
            portInfo.StopBit = (StopBits)Convert.ToDouble(StopBit);//设置当前停止位  SelectedValue   

        }

        /// <summary>
        /// 加载界面信息
        /// </summary>
        private void LoadViewInfo()
        {
            BaudRates = new List<string>();
            BaudRates.Add("110");
            BaudRates.Add("300");
            BaudRates.Add("600");
            BaudRates.Add("1200");
            BaudRates.Add("2400");
            BaudRates.Add("4800");
            BaudRates.Add("9600");
            BaudRates.Add("14400");
            BaudRates.Add("19200");
            BaudRates.Add("38400");
            BaudRates.Add("56000");
            BaudRates.Add("57600");
            BaudRates.Add("115200");

            StopBits = new List<string>();
            StopBits.Add("5");
            StopBits.Add("6");
            StopBits.Add("7");
            StopBits.Add("8");

            DataBits = new List<string>();
            DataBits.Add("1");
            DataBits.Add("1.5");
            DataBits.Add("2");


            Paritys = new List<string>();
            Paritys.Add("NONE");
            Paritys.Add("ODD");
            Paritys.Add("EVEN");
            Paritys.Add("MARK");
            Paritys.Add("SPACE");

            BaseStreams = new List<string>();
            BaseStreams.Add("NONE");
        }

        /// <summary>
        /// 获取机器串口list
        /// </summary>
        public void GetPorts()
        {
            string[] slist = TSerialPortController.GetPorts();
            foreach (string name in slist)
            {
                // comslist.Add(new COM(name));
                COMS.Add(name);
            }

        }

        #endregion      

        #region 传递命令
        public RelayCommand OpenCommand { get; set; }

        public RelayCommand CloseCommand { get; set; }


        #endregion

        #region 事件
        private void btnOpenPort_Click()
        {
            //  OpenCOMCommand =new RelayCommand(()=> { port.Open(); });
            OpenCommand = new RelayCommand(() => { MessageBox.Show(Parity); BaudRate = "2400"; });
           // OpenCommand = new RelayCommand(() => { MessageBox.Show(PortName+BaudRate+StopBit+DataBit + Parity+BaseStream); });
           // OpenCommand = new RelayCommand(() => { port.Open(); });
        }
        public int n = 0;
        public void btnClosePort_Click()
        {
            //  OpenCOMCommand =new RelayCommand(()=> { port.Open(); });
            // CloseCommand = new RelayCommand(() => { MessageBox.Show(Parity); });

            // OpenCommand = new RelayCommand(() => { port.Close(); });

            // TSerialPortController.SendStr sendStr = new TSerialPortController.SendStr();
            // sendStr.SendSetMode = true;
            // sendStr.SendSetData = "01 02 03 04";
            //// OpenCommand = new RelayCommand(() => { MessageBox.Show(sendStr.SendSetData); });
            // OpenCommand = new RelayCommand(() => { SendString = sendStr.SendSetData; });
            // ////  OpenCommand = new RelayCommand(() => { port.Send(sendStr); });

            CloseCommand = new RelayCommand(() => { SendString = "姜彦测试"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); });

            n++;
        }


        #endregion


        #region


        private RelayCommand _OpenCOM;

        /// <summary>
        /// 启动服务
        /// </summary>
        public RelayCommand OpenCOM
        {
            get { return _OpenCOM ?? new RelayCommand(StartExecute); }
            set
            {
                this._OpenCOM = value;
            }
        }
        private void StartExecute()
        {

        }        

        

       
        #endregion

    }
}