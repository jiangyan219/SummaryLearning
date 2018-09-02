using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 战略合作用户
    /// </summary>
    public class CooperateCustomerStrategy : Strategy
    {
        public double CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于战略合作客户，统一8折");
            return goodPrice*0.8;
        }
    }
}
