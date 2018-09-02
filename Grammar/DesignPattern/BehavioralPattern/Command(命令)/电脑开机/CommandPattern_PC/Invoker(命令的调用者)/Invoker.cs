using CommandPattern_PC.Command_命令抽象接口_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.Invoker_命令的调用者_
{
    public  class Invoker
    {
        private Command _command = null;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void RunCommand()
        {
            _command.Execute();
        }
    }
}
