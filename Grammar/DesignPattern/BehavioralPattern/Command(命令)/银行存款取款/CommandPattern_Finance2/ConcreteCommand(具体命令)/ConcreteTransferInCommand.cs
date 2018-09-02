using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;

namespace CommandPattern_Finance.ConcreteCommand_具体命令_
{
    /// <summary>
    /// 创建转入具体命令：继承于Command接口
    /// </summary>
    public  class ConcreteTransferInCommand:Command
    {

        private decimal _amount;

        private FinancialInstitution _financialInstitution = null;

        public ConcreteTransferInCommand(FinancialInstitution financialInstitution,decimal amount)
        {
            this._financialInstitution = financialInstitution;
            this._amount = amount;
        }

        public void Execute()
        {
           // throw new NotImplementedException();
            this._financialInstitution.TransferIn(this._amount);
        }
    }
}
