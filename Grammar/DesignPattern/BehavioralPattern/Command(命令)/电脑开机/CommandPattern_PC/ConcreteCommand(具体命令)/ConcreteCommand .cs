using CommandPattern_PC.Command_命令抽象接口_;
using CommandPattern_PC.Receiver_命令的接受者_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.ConcreteCommand_具体命令_
{
    public class ConcreteCommand : Command
    {
        private Receiver _receiverDell = null;

        private string _state;

        public ConcreteCommand(Receiver receiverDell)
        {
            this._receiverDell = receiverDell;
        }
        public void Execute()
        {
            // throw new NotImplementedException();
            _receiverDell.Action();
        }
    }
}
