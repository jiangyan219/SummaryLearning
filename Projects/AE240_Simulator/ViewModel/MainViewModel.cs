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
    /// ������������ͼ���԰󶨵������ԡ�
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// ʹ��MVVMinpc�����ӵĿɰ����Ե����⡣
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// �������Խ����ʹ���빤��֧�ֵ����ݰ󶨡�
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
        /// ��ʼ��һ��MainViewModel��ʵ��
        /// </summary>
        public MainViewModel()//string[] comportList
        {           
            
            Initealize();
            btnOpenPort_Click();
            btnClosePort_Click();
        }

        

        #region ������Ϣ

        #region ��������Ϣ

        public List<string> COMS { get; set; }

        public List<string> BaudRates { get; set; }
        public List<string> StopBits { get; set; }
        public List<string> DataBits { get; set; }
        public List<string> Paritys { get; set; }
        public List<string> BaseStreams { get; set; }



        #endregion

        #region ������Ϣ

        public string _BaudRate;

        /// <summary>
        /// ��������
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// ������
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
        /// ��żУ��λ
        /// </summary>
        public string Parity { get; set; }

        /// <summary>
        /// ����λ
        /// </summary>
        public string DataBit { get; set; }

        /// <summary>
        /// ֹͣλ
        /// </summary>
        public string StopBit { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string BaseStream { get; set; }

        #endregion

        public string strTest = "����123";
        public string SendString
        {
            get { return strTest; }
            set
            {
                strTest = value;
                RaisePropertyChanged("SendString");//�󶨵ķ�����Ӧ  ���Ǹı�ֵ֮��  ������Ӧ���˴θı� ���� 20180110
            }

        }

        #endregion

        #region ����

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void Initealize()
        {

            COMS = new List<string>();
            GetPorts();
            LoadViewInfo();            
            port = new TSerialPortController(portInfo);
            SerialPortInitealize();
            SendString = "�󶨲���";
            
        }

        /// <summary>
        /// ���ش�����Ϣ
        /// </summary>
        private void SerialPortInitealize()
        {
            portInfo.PortName = PortName;
            portInfo.BaudRate = Convert.ToInt32(BaudRate);
            portInfo.DataBit = Convert.ToInt32(DataBit);
            portInfo.StopBit = (StopBits)Convert.ToDouble(StopBit);//���õ�ǰֹͣλ  SelectedValue   

        }

        /// <summary>
        /// ���ؽ�����Ϣ
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
        /// ��ȡ��������list
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

        #region ��������
        public RelayCommand OpenCommand { get; set; }

        public RelayCommand CloseCommand { get; set; }


        #endregion

        #region �¼�
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

            CloseCommand = new RelayCommand(() => { SendString = "�������"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); });

            n++;
        }


        #endregion


        #region


        private RelayCommand _OpenCOM;

        /// <summary>
        /// ��������
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