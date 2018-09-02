using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    /// <summary>
    /// 开发部门
    /// </summary>
    public sealed class Development : Department
    {
        public Development(Mediator m) : base(m)
        {

        }

        public override void Apply()
        {
            //throw new NotImplementedException();
            Console.WriteLine("专心科研，开发项目！");
        }

        public override void Process()
        {
            //throw new NotImplementedException();
            Console.WriteLine("我们是开发部门，要进行项目开发，没钱了，需要资金支持！");
        }
    }
}
