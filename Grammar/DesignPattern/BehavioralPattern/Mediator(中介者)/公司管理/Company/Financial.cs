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
    public sealed class Financial : Department
    {
        public Financial(Mediator m) : base(m)
        {

        }
        public override void Apply()
        {
            //throw new NotImplementedException();
            Console.WriteLine("汇报工作！没钱了，钱太多了！怎么花?");
        }

        public override void Process()
        {
            // throw new NotImplementedException();
            Console.WriteLine("数钱！");
        }
    }
}
