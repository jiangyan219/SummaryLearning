using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.Receiver_命令的接受者_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 支付宝账户转账命令：继承Command
    /// </summary>
    public class AlipayAccountTransferInCommand : Command
    {
        private decimal _amount;

        public AlipayAccountTransferInCommand(AlipayAccount account, decimal amount) : base(account)
        {
            this._amount = amount;
        }

        /// <summary>
        /// 重构/重写：重构抽象类Command中的抽象方法Execute 姜彦20180228 17:34 C#重构与重写似乎是一个概念？
        /// </summary>
        public override void Execute()
        {
            //throw new NotImplementedException();
            AlipayAccount.TransferIn(_amount);
        }
    }
}
