using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = ExectueTask1(10).ToString();
            label2.Text = ExectueTask2(10).ToString();
        }
        //【2】根据委托定义实现方法
        private int ExectueTask1(int num)
        {
            Thread.Sleep(5000);
            return num * num;
        }

        private int ExectueTask2(int num)
        {
            return 2*num * num;
        }

        //【3】异步调用
        private void button2_Click(object sender, EventArgs e)
        {
            MyCalculator objMyCal = ExectueTask1;//创建委托变量，并代表方法1
            //通过委托异步调用方法
            //委托类型的 BeginInvoke（<输入和输出变量>，AsyncCallBack callBack,Objet asyncState）方法：异步调用的核心
            //第一个参数10，表示委托对应的实参；
            //第二个参数callBack,表示异步调用后自动调用的函数；
            //第三个参数asyncState,用于向回调函数提供参数信息；
            //返回值：IAsyncResult->异步操作状态接口，封装了异步执行中的参数；
            //异步调用任务
            IAsyncResult result = objMyCal.BeginInvoke(10,null,null);
            label1.Text = "正在计算，请稍等....";

            //同时执行其他任务
            label2.Text = ExectueTask2(10).ToString();

            //获取异步执行的结果
            int res = objMyCal.EndInvoke(result);
            //委托类型的EndInvoke()方法：借助于IAsyncResult接口对象，不断的查询异步调用是否结束；
            //该方法知道异步调用的方法所有参数，所以，异步调用完毕后，取出异步调用的结果作为返回值；
            //
            label1.Text = res.ToString();

        }


        //【1】定义一个委托
        public delegate int MyCalculator(int num);


    }
}
