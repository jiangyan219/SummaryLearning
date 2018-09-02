using CommandPattern_PC.Command_命令抽象接口_;
using CommandPattern_PC.Receiver_命令的接受者_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.ConcreteCommand_具体命令_
{
    /*

     * 开机命令的实现，实现Command接口，

     * 持有开机命令的真正实现，通过调用接收者的方法来实现命令

     */
    public class ConcreteOpenCommand : Command
    {
        private MainBoardApi _mainBoard = null;

        //private string _state;

        public ConcreteOpenCommand(MainBoardApi mainBoard)
        {
            this._mainBoard = mainBoard;
        }
        public void Execute()
        {
            //throw new NotImplementedException();
            this._mainBoard.Open();
        }
    }
}
