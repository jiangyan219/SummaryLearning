using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_PC.Command_命令抽象接口_;

namespace CommandPattern_PC.ConcreteCommand_具体命令_
{
    public class ConcreteResetCommand:Command
    {
        private MainBoardApi _mainBoard = null;

        public ConcreteResetCommand(MainBoardApi mainBoard)
        {
            this._mainBoard = mainBoard;
        }

        public void Execute()
        {
            //throw new NotImplementedException();
            this._mainBoard.Reset();
        }
    }
}
