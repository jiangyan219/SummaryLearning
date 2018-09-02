using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    public class NormalCustomerStrategy : Strategy
    {        
        public double  CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于新客户或者普通客户，没有折扣");
            return goodPrice;
        }
    }
}
