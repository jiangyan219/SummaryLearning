using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttitudeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Myclass.Message("In Main function.");
            function1();
            Console.ReadKey();
        }

        static void function1()
        {
            Myclass.Message("In Function 1.");
            function2();
        }
        static void function2()
        {
            Myclass.Message("In Function 2.");
        }
    }

    public class Myclass
    {
        [Conditional("DEBUG")]//仅限在Debug调试模式下有效特性，Release下则无效；姜彦201809031652
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
