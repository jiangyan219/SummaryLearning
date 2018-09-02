using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 转账命令：继承Command
    /// </summary>
    public class TransferInCommand:Command
    {

        private decimal amount;

        public TransferInCommand(BankAccount account, decimal amount)
            : base(account)
        {
            this.amount = amount;
        }
        
        /// <summary>
        /// 实现 转如 命令
        /// </summary>
        public override void Execute()
        {
          //  throw new NotImplementedException();
            _individualAccount.TransferIn(amount);

        }
    }
}
