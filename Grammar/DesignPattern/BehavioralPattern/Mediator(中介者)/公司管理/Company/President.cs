using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    /// <summary>
    /// 总经理-相当于具体中介角色
    /// </summary>
    public sealed class President : Mediator
    {
        

        //总经理有各个部门的管理权限
        private Financial _financial;
        private Market _market;
        private Development _development;

        public void SetFinancial(Financial financial)
        {
            this._financial = financial;
        }
        public void SetDevelopment(Development development)
        {
            this._development = development;
        }

        public void SetMarket(Market market)
        {
            this._market = market;
        }

        public void Command(Department department)
        {
            //throw new NotImplementedException();
            if (department.GetType()==typeof(Market))
            {
                _financial.Process();
            }
        }
    }
}
