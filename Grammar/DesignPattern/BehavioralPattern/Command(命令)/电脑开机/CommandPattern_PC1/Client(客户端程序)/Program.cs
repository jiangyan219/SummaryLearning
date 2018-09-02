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
        static void Main(string[] args)
        {

            ////MainBoardApi mainBoard =new GigaMainBoard();
            //MainBoardApi mainBoard = new DellMainBoard();

            //OpenCommand openCommand = new OpenCommand(mainBoard);

            //Box box = new Box();
            //box.SetOpenCommand(openCommand);
            //box.OpenButtonPressed();

            //ReceiverDellMainBoard mainBoard = new ReceiverDellMainBoard();//主板类型

            //ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard );//执行命令类型：开机

            //Invoker invoker = new Invoker();//机箱
            //invoker.SetCommand(openCommand);//机箱 装载 开机命令
            //invoker.RunCommand();//机箱 执行 装载的开机命令

            //MainBoardApi mainBoard = new ReceiverDellMainBoard();//主板类型:戴尔
            MainBoardApi mainBoard = new ReceiverGigaMainBoard();//主板类型：技嘉

            ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard);//执行命令类型：开机

            Invoker invoker = new Invoker();//机箱
            invoker.SetCommand(openCommand);//机箱 装载 开机命令
            invoker.RunCommand();//机箱 执行 装载的开机命令
        }
    }
}
