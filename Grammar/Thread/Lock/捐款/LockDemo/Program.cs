using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LockDemo
{
    class Program
    {
        static object locker = new object();//创建锁
        public static int money = 0;//捐款总额

        static void Main(string[] args)
        {
            Thread t1 = new Thread(write1);//创建一个新线程t1（捐款人）
            Thread t2 = new Thread(write1);
            t1.Start();//运行该线程
            t2.Start();


        }
        private static int n = 10;
        private static void write1()
        {
            while (n>0)
            {
                n--;
                /*
                 * 掏钱，咒骂，排队等 捐款人可同时进行的事情                 
                 */
                lock(locker)//可以注释掉锁之后看看情况 对比一下  姜彦20180331 2213
                {
                    money += 100;//没人捐款100元
                    Console.WriteLine("有人正在塞钱，每次只能一个人塞。后面的请等待....");
                    Thread.Sleep(800);
                    Console.WriteLine("目前共募集 "+money+"元\n");
                }

                /*
                 *伤心，继续工作，回家，挨老婆打等可以并发的事
                 */
                
            }

            Console.ReadLine();

        }


    }
}
