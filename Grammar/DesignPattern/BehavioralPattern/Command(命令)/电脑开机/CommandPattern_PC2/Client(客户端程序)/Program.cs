using CommandPattern_PC.Command_命令抽象接口_;
using CommandPattern_PC.ConcreteCommand_具体命令_;
using CommandPattern_PC.Invoker_命令的调用者_;
using CommandPattern_PC.Receiver_命令的接受者_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC
{
    class Program
    {
        #region 原来的代码，正常的，为了调试 暂时注释掉 姜彦20180301
        //static void Main(string[] args)
        //{

        //    ////MainBoardApi mainBoard =new GigaMainBoard();
        //    //MainBoardApi mainBoard = new DellMainBoard();

        //    //OpenCommand openCommand = new OpenCommand(mainBoard);

        //    //Box box = new Box();
        //    //box.SetOpenCommand(openCommand);
        //    //box.OpenButtonPressed();

        //    //ReceiverDellMainBoard mainBoard = new ReceiverDellMainBoard();//主板类型

        //    //ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard );//执行命令类型：开机

        //    //Invoker invoker = new Invoker();//机箱
        //    //invoker.SetCommand(openCommand);//机箱 装载 开机命令
        //    //invoker.RunCommand();//机箱 执行 装载的开机命令

        //    //MainBoardApi mainBoard = new ReceiverDellMainBoard();//主板类型:戴尔
        //    MainBoardApi mainBoard = new ReceiverGigaMainBoard();//主板类型：技嘉

        //    ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard);//执行命令类型：开机

        //    Invoker invoker = new Invoker();//机箱
        //    invoker.SetCommand(openCommand);//机箱 装载 开机命令
        //    invoker.RunCommand();//机箱 执行 装载的开机命令

        //    for (int i = 0; i < 10;i++ )
        //    {
        //        Console.WriteLine("......电脑开机异常........");
        //    }

        //    Console.WriteLine("......电脑需要重启........\n");

        //    //MainBoardApi mainBoard = new ReceiverGigaMainBoard();//主板类型：技嘉

        //    ConcreteResetCommand resetCommand = new ConcreteResetCommand(mainBoard);//执行命令类型：开机

        //   // Invoker invoker = new Invoker();//机箱
        //    invoker.SetCommand(resetCommand);//机箱 装载 开机命令
        //    invoker.RunCommand();//机箱 执行 装载的开机命令

        //    Console.ReadLine();
        //}
        #endregion

        static void Main(string[] args)
        {
            //MainBoardApi mainBoard = new ReceiverDellMainBoard();//主板类型:戴尔
            MainBoardApi mainBoard = new ReceiverGigaMainBoard();//主板类型：技嘉
            Invoker invoker = new Invoker();//机箱
            ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard);//执行命令类型：开机
            ConcreteResetCommand resetCommand = new ConcreteResetCommand(mainBoard);//执行命令类型：开机

            

            
            invoker.SetCommand(openCommand);//机箱 装载 开机命令
            invoker.RunCommand();//机箱 执行 装载的开机命令

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("......电脑开机异常........");
            }

            Console.WriteLine("......电脑需要重启........\n");

            
            invoker.SetCommand(resetCommand);//机箱 装载 开机命令
            invoker.RunCommand();//机箱 执行 装载的开机命令

            Console.ReadLine();
        }
    }
}
