using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 类：取款命令类集合
    /// </summary>
    public class MoneyOutCommand:Command
    {
        private decimal amount;

        public MoneyOutCommand(BankAccount account, decimal amount)
            : base(account)
        {
            this.amount = amount;
        }
        
        
        public override void Execute()
        {
           // throw new NotImplementedException();
            _individualAccount.MoneyOut(amount);
        }
    }
}
