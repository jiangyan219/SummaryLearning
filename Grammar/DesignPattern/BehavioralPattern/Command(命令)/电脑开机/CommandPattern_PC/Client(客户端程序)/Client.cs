using CommandPattern_PC.Command_命令抽象接口_;
using CommandPattern_PC.ConcreteCommand_具体命令_;
using CommandPattern_PC.Invoker_命令的调用者_;
using CommandPattern_PC.Receiver_命令的接受者_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.Client_客户端程序_
{
    public  class Client
    {
        public void Assemble()
        {
            Receiver receiverDell = new Receiver();

            Command command = new ConcreteCommand(receiverDell );

            Invoker invoker = new Invoker();
            invoker.SetCommand(command );
        }
    }
}
