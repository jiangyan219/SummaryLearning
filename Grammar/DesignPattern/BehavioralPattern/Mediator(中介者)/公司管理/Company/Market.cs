using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    /// <summary>
    /// 财务部门
    /// </summary>
    public sealed class Market : Department
    {
        public Market(Mediator m) : base(m)
        {

        }
        public override void Apply()
        {
            //throw new NotImplementedException();
            Console.WriteLine("跑去接项目！");
        }

        public override void Process()
        {
            // throw new NotImplementedException();
            Console.WriteLine("汇报工作！项目承接的进度，需要资金支持！");
            GetMediator.Command(this);
        }
    }
}
