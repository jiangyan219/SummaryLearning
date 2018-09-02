using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 类：存款命令类集合
    /// </summary>
    public class MoneyInCommand:Command
    {
        private decimal amount;

        public MoneyInCommand(BankAccount account, decimal amount)
            : base(account)
        {
            this.amount = amount;
        }        
        /// <summary>
        /// 实现存钱命令
        /// </summary>
        public override void Execute()
        {
            _individualAccount.MoneyIn(amount);
        }


        //****************************//

        //转账命令扩张  Execute 这个方法有问题 姜彦 20180104 1443

        //***************************//


        //public MoneyInCommand(Alipay account, decimal amount)
        //    : base(account)
        //{
        //    this.amount = amount;
        //}

        //public override void Execute()
        //{
        //    //_individualAccount.MoneyIn(amount);
        //    AlipayAccount.MoneyIn(amount); 
        //}

    }
}
