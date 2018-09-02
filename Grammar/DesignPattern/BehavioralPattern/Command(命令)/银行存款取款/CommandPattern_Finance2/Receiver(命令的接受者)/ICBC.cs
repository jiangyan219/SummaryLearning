using CommandPattern_Finance.Command_命令抽象类_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.Receiver_命令的接受者_
{
    /// <summary>
    /// 工商银行
    /// </summary>
    public class ICBC : FinancialInstitution
    {
        /// <summary>
        /// 账号总金额
        /// </summary>
        private decimal totalAmount { get; set; }
        public void MoneyIn(decimal amount)
        {
            //throw new NotImplementedException();
            this.totalAmount += amount;
            Console.WriteLine("【工商银行】存钱：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        public void MoneyOut(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void TransferIn(decimal amount)
        {
            //throw new NotImplementedException();
            this.totalAmount += amount;
            Console.WriteLine("【工商银行】转入：" + amount.ToString("N2") + "  当前金额是： " + GetTotalAmount().ToString("N2"));

        }

        public void TransferOut(decimal amount)
        {
            throw new NotImplementedException();
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
