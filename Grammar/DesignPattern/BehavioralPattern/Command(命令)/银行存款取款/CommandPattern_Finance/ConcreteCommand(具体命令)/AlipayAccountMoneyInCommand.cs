using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 类：支付宝存钱命令类集合 继承自Command
    /// </summary>
    public class AlipayAccountMoneyInCommand:Command
    {
       
        private decimal amount;
        public AlipayAccountMoneyInCommand(AlipayAccount account, decimal amount)
            : base(account)
        {
            this.amount = amount;
        }

        /// <summary>
        /// 重构/重写：重构抽象类Command中的抽象方法Execute 姜彦20180228 16:34 C#重构与重写似乎是一个概念？
        /// </summary>
        public override void Execute()
        {
            //_individualAccount.MoneyIn(amount);
            AlipayAccount.MoneyIn(amount); 
        }
    }
}
