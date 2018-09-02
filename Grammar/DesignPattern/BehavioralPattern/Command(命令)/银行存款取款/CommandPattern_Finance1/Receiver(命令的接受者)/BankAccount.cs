using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.Receiver_命令的接受者_
{
    /// <summary>
    /// 银行帐号
    /// </summary>
    public  class BankAccount
    {
        /// <summary>
        /// 账号总金额
        /// </summary>
        private decimal totalAmount { get; set; }

        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount"></param>
        public void MoneyIn(decimal amount)
        {
            this.totalAmount += amount;
            Console.WriteLine("【银行帐号】存钱：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount"></param>
        public void MoneyOut(decimal amount)
        {
            this.totalAmount -= amount;
            Console.WriteLine("【银行帐号】取钱：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        /// <summary>
        /// 转入
        /// </summary>
        /// <param name="amount"></param>
        public void TransferIn(decimal amount)
        {
            this.totalAmount += amount;
            Console.WriteLine("【银行帐号】转入：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        /// <summary>
        /// 转出
        /// </summary>
        /// <param name="amount"></param>
        public void TransferOut(decimal amount)
        {
            this.totalAmount -= amount;
            Console.WriteLine("【银行帐号】转出：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        /// <summary>
        /// 获取账号总金额
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalAmount()
        {
            return totalAmount;
        }
    }
}
