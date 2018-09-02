using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 类：转出命令类集合 继承自Command
    /// </summary>
    public  class TransferOutCommand:Command
    {
        private decimal amount;
        public TransferOutCommand(BankAccount account, decimal amount)
            : base(account)
        {
            this.amount = amount;
        }

        /// <summary>
        /// 实现 转出 命令
        /// </summary>
        public override void Execute()
        {
           // throw new NotImplementedException();
            _individualAccount.TransferOut(amount);
        }
    }
}
