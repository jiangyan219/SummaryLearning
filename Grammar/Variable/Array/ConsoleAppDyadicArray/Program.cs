using System;

namespace ConsoleAppDyadicArray
{
    class Program
    {
        //二维数组的length  是所有元素的个数 姜彦201808221548
        static void Main(string[] args)
        {
            var bindingPropertys = new string[,]
            {
                {"PortName","string"},
                {"BaudRate","int"},
                {"Parity","Parity"},
                {"DataBit","int"},
                {"StopBit","StopBits"},
                {"BaseStream","Stream"},
            };
            for (int i = 0; i < (bindingPropertys.Length + 1) / 2; i++)
            {
                Console.WriteLine("--------{0}", i);
            }

            //for (int i=0;i<10;i++)
            //{
            //    Console.WriteLine("--------{0}",i);
            //}
            Console.ReadLine();
        }
    }
}
