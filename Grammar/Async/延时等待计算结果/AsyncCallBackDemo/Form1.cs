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

namespace AsyncCallBackDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //【3】初始化委托变量
            objMyCal = new MyCalculator(ExecuteTask);

            //objMyCal = (num, ms) =>//把ExecuteTask方法用Lambda表达式代替
            //  {
            //      Thread.Sleep(ms);
            //      return num * num;
            //  };
        }

        //【1】生命一个委托
        public delegate int MyCalculator(int num,int ms);

        //【2】根据委托，定义方法：返回一个数的平方
        private int ExecuteTask(int num, int ms)
        {
            Thread.Sleep(ms);
            return num * num;
        }

        //【3】创建委托变量
        MyCalculator objMyCal = null; //ExecuteTask;

        //【4】同时执行多个任务
        private void button1_Click(object sender, EventArgs e)
        {
            

            for (int i=1;i<11;i++)//产生10个任务
            {
                //开始异步执行，并封装回调函数
                objMyCal.BeginInvoke(10*i,1000*i, MyCallBack, i);
                //最后一个参数i给回调函数的字段AsyncState赋值，这个字段的类型为Object类型，如果数据很多，可以传递集合、类、结构；
            }

        }

        //【5】编写回调函数
        private void MyCallBack(IAsyncResult result)
        {
            int res= objMyCal.EndInvoke(result);
            //异步显示结果的形式：第1个计算结果为：100
            Console.WriteLine("第{0}个计算结果为:{1}",result.AsyncState.ToString(),res);

        }
        //异步编程总结：
        /*
         *1.异步编程是建立在委托基础上的编程方法。
         * 2.异步调用的每个方法都是在独立的线程中执行的。因此，本质上就是一种多线程程序，也可以说是一种“简化的多线程”
         * 3.比较适合在后台运行较为耗费时间的《简单任务》，并且要求任务之间是独立的，任务中不要有直接访问可视化控件的内容，
         * 4.如果后台任务要求必须按照特定的顺序执行，或者访问到特定的资源，异步编程不太适合，而应该选择多线程开发技术。
         * 
         
         
         */

    }
}
