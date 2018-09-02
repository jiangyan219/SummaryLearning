using CommandPattern_PC.Command_命令抽象接口_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.Receiver_命令的接受者_
{
    /// <summary>
    /// 戴尔主板：继承于主板
    /// </summary>
    public class ReceiverDellMainBoard:MainBoardApi
    {       

        public void Open()
        {
            //throw new NotImplementedException();
            Console.WriteLine("戴尔主板现在正在开机，请等候");
            Console.WriteLine("接通电源......");
            Console.WriteLine("设备检查......");
            Console.WriteLine("装载系统......");
            Console.WriteLine("机器正常运转起来......");
            Console.WriteLine("机器已经正常打开，请操作");
            Console.ReadLine();
        }

        #region 不继承任何接口时，独立创建的方法
        //public void Open()
        //{            
        //    Console.WriteLine("戴尔主板现在正在开机，请等候");
        //    Console.WriteLine("接通电源......");
        //    Console.WriteLine("设备检查......");
        //    Console.WriteLine("装载系统......");
        //    Console.WriteLine("机器正常运转起来......");
        //    Console.WriteLine("机器已经正常打开，请操作");
        //    Console.ReadLine();
        //}
        #endregion

        #region 继承Command接口时自动实现的接口方法
        //public void Execute()
        //{
        //   // throw new NotImplementedException();
        //    Console.WriteLine("戴尔主板现在正在开机，请等候");
        //    Console.WriteLine("接通电源......");
        //    Console.WriteLine("设备检查......");
        //    Console.WriteLine("装载系统......");
        //    Console.WriteLine("机器正常运转起来......");
        //    Console.WriteLine("机器已经正常打开，请操作");
        //    Console.ReadLine();
        //}
        #endregion
    }
}
