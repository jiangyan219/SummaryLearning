using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {

            President mediator = new President();
            Market market = new Market(mediator);
            Development development = new Development(mediator);
            Financial financial = new Financial(mediator);

            mediator.SetFinancial(financial);
            mediator.SetDevelopment(development);
            mediator.SetMarket(market);

            // market.Process();
            // market.Apply();

            financial.Process();
            financial.Apply();
            Console.Read();

        }
    }
}
