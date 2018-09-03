using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 老用户策略
    /// </summary>
    public class OldCustomerStrategy : Strategy
    {
        public double CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于老用户，统一折扣价5%");
            return goodPrice*(1-0.05);
        }
    }
}
