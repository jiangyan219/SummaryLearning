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
            Student stu = new Student()
            {
                ID=1,
                Name="姜彦",
                Age=29               
            };

            Student stu1 = new Student();
            Student stuClone = new Student();

            stu1 = stu;
            stuClone = stu.DeepCloneObject();

            stu.ID = 2;
            stu.Name = "腾腾";


            var changes=  stu.GetChanges(stuClone);


            Console.ReadLine();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }

}
