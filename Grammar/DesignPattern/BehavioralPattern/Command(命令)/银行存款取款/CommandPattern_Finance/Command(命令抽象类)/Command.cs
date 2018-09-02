using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Receiver_命令的接受者_;

namespace CommandPattern_Finance.Command_命令抽象类_
{
    /// <summary>
    /// 抽象命令 or 执行命令的接口
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// 个人账户
        /// </summary>
        protected BankAccount _individualAccount;

        public Command(BankAccount account)
        {
            this._individualAccount = account;
        }

        /// <summary>
        /// 阿里账号
        /// </summary>
        protected AlipayAccount AlipayAccount;

        public Command(AlipayAccount account)
        {
            this.AlipayAccount = account;
        }

        /// <summary>
        /// 抽象方法：抽象类Command中的执行命令 姜彦20180228 16:30
        /// </summary>
        public abstract void Execute();
    }
}
