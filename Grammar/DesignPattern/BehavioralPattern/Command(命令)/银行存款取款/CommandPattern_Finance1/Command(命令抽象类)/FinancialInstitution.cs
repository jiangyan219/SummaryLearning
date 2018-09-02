using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.Command_命令抽象类_
{
    /// <summary>
    /// 金融机构
    /// </summary>
    public interface FinancialInstitution
    {
        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="amount"></param>
        void MoneyIn(decimal amount);

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount"></param>
        void MoneyOut(decimal amount);

        /// <summary>
        /// 转入
        /// </summary>
        /// <param name="amount"></param>
        void TransferIn(decimal amount);

        /// <summary>
        /// 转出
        /// </summary>
        /// <param name="amount"></param>
        void TransferOut(decimal amount);

        /// <summary>
        /// 获取账户总金额
        /// </summary>
        /// <returns></returns>
        decimal GetTotalAmount();
    }
}
