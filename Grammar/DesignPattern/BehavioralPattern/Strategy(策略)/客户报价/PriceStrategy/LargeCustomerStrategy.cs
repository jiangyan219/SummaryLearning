using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 大客户策略
    /// </summary>
    public class LargeCustomerStrategy : Strategy
    {
       

        public double CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于大客户，统一折扣10%");
            return goodPrice*(1-0.1);
           
        }
    }
}
