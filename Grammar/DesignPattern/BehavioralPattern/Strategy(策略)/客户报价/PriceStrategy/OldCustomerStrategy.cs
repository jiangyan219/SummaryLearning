using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    public class OldCustomerStrategy : Strategy
    {
        public double CalcPrice(double goodPrice)
        {
            Console.WriteLine("对于老用户，统一折扣价5%");
            return goodPrice*(1-0.05);
        }
    }
}
