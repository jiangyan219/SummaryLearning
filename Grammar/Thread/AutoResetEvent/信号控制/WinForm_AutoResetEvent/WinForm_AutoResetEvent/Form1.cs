using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinForm_AutoResetEvent
{
    /*姜彦201803111853*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AutoResetEvent autoEvent = new AutoResetEvent(false);
        bool closed = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thread vThread = new Thread(new ParameterizedThreadStart(DoWork));//这个也可以实现  但是Dowork不能带参数 姜彦20180131
            // vThread.Start();

            ThreadPool.QueueUserWorkItem(DoWork, "姜彦");//可以带参数的Dowork  姜彦20180131

        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoEvent.Set();
        }

        public void DoWork(object obj)
        {
            while (true)
            {
                //autoEvent.WaitOne();
                if (closed) return;

               //// Console.WriteLine("Zswang 路过");

               // string name = (string)obj;
               //// textBox1.AppendText(name + " 路过"+"/n");//不能直接使用textbox  需要建立委托才可以  姜彦201803090856

               // Action<string> actionDelegate = delegate(string txt) { this.textBox1.Text += txt + "\r\n"; };
               // textBox1.Invoke(actionDelegate, name + " 路过");

               //// Console.WriteLine(name + " 路过");
               // //MessageBox.Show(name+" 路过");

                for (int i = 1; i < 10; i++)
                {
                    
                    autoEvent.WaitOne();
                    Action<string> actionDelegate = delegate(string txt) { this.textBox1.Text += txt; };
                    textBox1.Invoke(actionDelegate, i.ToString() + "姜彦测试等待\r\n");
                    if (i == 9)
                    {
                        closed = true;
                    }
                }


            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 1; i < 20;i++ )
            {

                textBox1.AppendText(i.ToString()+"姜彦测试等待\r\n");
            }

        }

                

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            closed = true;
            autoEvent.Set();
        }

        

        #region 跨线程访问控件 textBox

       

        #endregion

    }
}
