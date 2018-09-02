using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseAndCat
{
    class Program
    {

        public delegate void mcEventHandler();

        class Cat
        {
            string cName;
            public event mcEventHandler CatCryEvent;

            public Cat(string name)
            {
                cName = name;
            }

            public void Cry()
            {
                Console.WriteLine(cName+"来了！");
                //CatCryEvent();
                //CatCryEvent?.Invoke();//这一句也可以 姜彦20180319 1648
                CatCryEvent.Invoke();//这一句竟然也可以 姜彦20180319 1651  上面两句 什么区别呢？？？？？？？？？
            }

        }

        class Mouse
        {
            public string mName;

            public Mouse(Cat cat)
            {
                cat.CatCryEvent += Run;
            }

            private void Run()
            {
                Console.WriteLine("猫来了"+mName+"先溜一步！");
            }

            private void See()
            {
                Console.WriteLine("看看猫还在不在？");
            }

        }


        static void Main(string[] args)
        {
            Cat cat1 = new Cat("Tom");
            Mouse m1 = new Mouse(cat1);

            cat1.Cry();

            Console.ReadLine();
        }
    }
}
