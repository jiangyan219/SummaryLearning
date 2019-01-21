using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestICloneable();
            //TestICloneableDeep();
            //TestCloneExtends();
            //TestDeepCloneExtends();
            TestCloneExtendsList();
            Console.ReadLine();
            Student stu = new Student()
            {
                ID=1,
                Name="姜彦",
                Age=29               
            };

            Student stu1 = new Student();
            Student stuClone = new Student();

            stu1 = stu;
            stuClone = stu.CloneObject();

            stu.ID = 2;
            stu.Name = "腾腾";


            var changes=  stu.GetChanges(stuClone);
            if (changes.Count > 0)
            {
                StringBuilder logMsg = new StringBuilder();

                foreach (var item in changes)
                {
                    Console.WriteLine("名称={0},原值={1},更新值={2}", item.Name, item.OriginalValue, item.CurrentValue);                 
                }
            }

            Console.ReadLine();
        }

        /*ICloneable接口克隆方式学习 及 与静态扩展的比较 */
        #region ICloneable接口克隆方式学习 及 与静态扩展的比较 

        /// <summary>
        /// 浅克隆测试
        /// </summary>
        static void TestICloneable()
        {
            Cup cup = new Cup();
            cup.Height = 20;
            cup.RL = 200;
            cup.c = new Colors() { foot="白色",Top="无色"};

            Console.WriteLine("***浅克隆测试***");
            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色
            Console.WriteLine("");

            Cup cup1 = (Cup)cup.Clone();
            cup1.Height = 10;
            cup1.RL = 100;
            cup1.c.foot = "灰色";

            Console.WriteLine("cup1-Height:" + cup1.Height);//10
            Console.WriteLine("cup1-RL:" + cup1.RL);//100
            Console.WriteLine("cup1-foot:" + cup1.c.foot);
            Console.WriteLine("");

            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//灰色 值发生改变了
            Console.WriteLine("");
            
        }

        /// <summary>
        /// 深克隆测试
        /// </summary>
        static void TestICloneableDeep()
        {
            Cup cup = new Cup();
            cup.Height = 20;
            cup.RL = 200;
            cup.c = new Colors() { foot = "白色", Top = "无色" };

            Console.WriteLine("***深克隆测试***");
            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色
            Console.WriteLine("");

            Cup cup1 = (Cup)cup.DeepClone();
            cup1.Height = 10;
            cup1.RL = 100;
            cup1.c.foot = "灰色";

            Console.WriteLine("cup1-Height:" + cup1.Height);//10
            Console.WriteLine("cup1-RL:" + cup1.RL);//100
            Console.WriteLine("cup1-foot:" + cup1.c.foot);
            Console.WriteLine("");

            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色 深克隆后对象中的引用类型的值不发生改变
            Console.WriteLine("");
            
        }

        /// <summary>
        /// 静态扩展浅克隆测试
        /// </summary>
        static void TestCloneExtends()
        {
            Cup cup = new Cup();
            cup.Height = 20;
            cup.RL = 200;
            cup.c = new Colors() { foot = "白色", Top = "无色" };

            Console.WriteLine("***静态扩展浅克隆测试***");
            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色
            Console.WriteLine("");

            Cup cup1 = cup.CloneObject();
            cup1.Height = 10;
            cup1.RL = 100;
            cup1.c.foot = "灰色";

            Console.WriteLine("cup1-Height:" + cup1.Height);//10
            Console.WriteLine("cup1-RL:" + cup1.RL);//100
            Console.WriteLine("cup1-foot:" + cup1.c.foot);
            Console.WriteLine("");

            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//灰色 值发生改变了
            Console.WriteLine("");
            
        }

        /// <summary>
        /// 静态扩展深克隆测试
        /// </summary>
        static void TestDeepCloneExtends()
        {
            Cup cup = new Cup();
            cup.Height = 20;
            cup.RL = 200;
            cup.c = new Colors() { foot = "白色", Top = "无色" };

            Console.WriteLine("***静态扩展深克隆测试***");
            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色
            Console.WriteLine("");

            Cup cup1 = cup.DeepCloneObject();
            cup1.Height = 10;
            cup1.RL = 100;
            cup1.c.foot = "灰色";

            Console.WriteLine("cup1-Height:" + cup1.Height);//10
            Console.WriteLine("cup1-RL:" + cup1.RL);//100
            Console.WriteLine("cup1-foot:" + cup1.c.foot);
            Console.WriteLine("");

            Console.WriteLine("cup-Height:" + cup.Height);//20
            Console.WriteLine("cup-RL:" + cup.RL);//200
            Console.WriteLine("cup-foot:" + cup.c.foot);//白色 深克隆后对象中的引用类型的值不发生改变
            Console.WriteLine("");

        }

        /// <summary>
        /// 静态扩展深克隆List测试-浅克隆+深克隆
        /// </summary>
        static void TestCloneExtendsList()
        {
            List<Cup> cups = new List<Cup>();
            List<Cup> cupsClone = new List<Cup>();
            List<Cup> cupsDeepClone = new List<Cup>();

            for (int i = 0; i < 3; i++)
            {
                Cup cup = new Cup();
                cup.Height = 1+i;
                cup.RL = 10+i;
                cup.c = new Colors() { foot = "白色", Top = "无色" };
                cups.Add(cup);
            }
            cupsClone = (List<Cup>)cups.DeepCloneList();//浅克隆
            cupsDeepClone = cups.DeepCloneObject();//深克隆

            foreach (var cup in cups)//修改原型数据
            {
                cup.Height = 0;//修改值类型数据
                cup.c.foot = "红色";//修改引用类型数据
            }

            Console.WriteLine("***List静态扩展深克隆测试-原型***");
            foreach (var cup in cups)
            {
                Console.WriteLine("cup-Height:" + cup.Height);//20
                Console.WriteLine("cup-RL:" + cup.RL);//200
                Console.WriteLine("cup-foot:" + cup.c.foot);//白色
                Console.WriteLine("");
            }
            Console.WriteLine("=================================");
            Console.WriteLine("");            

            Console.WriteLine("***List静态扩展深克隆测试-浅克隆***");
            foreach (var cup in cupsClone)
            {
                Console.WriteLine("cup-Height:" + cup.Height);//1、2、3
                Console.WriteLine("cup-RL:" + cup.RL);//200
                Console.WriteLine("cup-foot:" + cup.c.foot);//红色
                Console.WriteLine("");
            }
            Console.WriteLine("=================================");
            Console.WriteLine("");

            Console.WriteLine("***List静态扩展深克隆测试-深克隆***");
            foreach (var cup in cupsDeepClone)
            {
                Console.WriteLine("cup-Height:" + cup.Height);//1、2、3
                Console.WriteLine("cup-RL:" + cup.RL);//200
                Console.WriteLine("cup-foot:" + cup.c.foot);//白色
                Console.WriteLine("");
            }
            Console.WriteLine("=================================");
            Console.WriteLine("");


        }
        #endregion
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }

    
}
