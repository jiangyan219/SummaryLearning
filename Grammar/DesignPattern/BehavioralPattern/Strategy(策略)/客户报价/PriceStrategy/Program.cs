using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    class Program
    {
        static void Main(string[] args)
        {

            Strategy strategy = null;

            //strategy = new LargeCustomerStrategy();

            //strategy = new LargeCustomerStrategy();

            //strategy = new NormalCustomerStrategy();

            strategy = new CooperateCustomerStrategy();

            Price ctx = new Price(strategy);

            double quote = ctx.Quote(1000);

            Console.WriteLine("原本价格{0}，向客户报价{1}。",1000,quote);

            Console.ReadLine();

        }
    }
}
