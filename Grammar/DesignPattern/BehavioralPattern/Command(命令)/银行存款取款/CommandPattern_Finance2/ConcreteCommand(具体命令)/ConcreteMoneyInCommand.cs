using CommandPattern_Finance.Command_命令抽象类_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 创建存钱具体指令：继承于Command接口
    /// </summary>
    public class ConcreteMoneyInCommand : Command
    {
        private decimal _amount;

        private FinancialInstitution _financialInstitution = null;

        public ConcreteMoneyInCommand(FinancialInstitution financialInstitution,decimal amount)
        {
            this._financialInstitution = financialInstitution;
            this._amount = amount;
        }
        public void Execute()
        {
            // throw new NotImplementedException();
            this._financialInstitution.MoneyIn(this._amount);
           // this._financialInstitution.TransferIn(this._amount);
        }
    }
}
