using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 正常用户策略
    /// </summary>
    public class NormalCustomerStrategy : Strategy
    {        
        public double  CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于新客户或者普通客户，没有折扣");
            return goodPrice;
        }
    }
}
