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
            TestICloneable();
            TestICloneableDeep();
            TestCloneExtends();
            TestDeepCloneExtends();
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
        #endregion
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }

    
}
