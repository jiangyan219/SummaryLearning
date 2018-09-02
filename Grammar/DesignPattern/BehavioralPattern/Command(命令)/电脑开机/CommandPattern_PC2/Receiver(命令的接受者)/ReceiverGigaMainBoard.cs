using CommandPattern_PC.Command_命令抽象接口_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.Receiver_命令的接受者_
{
    /// <summary>
    /// 技嘉主板：继承于主板
    /// </summary>
    public class ReceiverGigaMainBoard : MainBoardApi
    {
        public void Open()
        {
            //throw new NotImplementedException();
            Console.WriteLine("【技嘉】主板现在正在开机，请等候");
            Console.WriteLine("接通电源......");
            Console.WriteLine("设备检查......");
            Console.WriteLine("装载系统......");
            Console.WriteLine("机器正常运转起来......");
            Console.WriteLine("机器已经正常打开，请操作");
           // Console.ReadLine();
        }


        public void Reset()
        {
           // throw new NotImplementedException();
            Console.WriteLine("【技嘉】主板现在正在重启，请等候");
            Console.WriteLine("接通电源......");
            Console.WriteLine("设备检查......");
            Console.WriteLine("装载系统......");
            Console.WriteLine("机器正常运转起来......");
            Console.WriteLine("机器已经正常打开，请操作");
           // Console.ReadLine();
        }
    }
}
