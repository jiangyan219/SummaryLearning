using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace params_Code
{

    /* 姜彦20180124
     使用 params 关键字可以指定采用数目可变的参数的方法参数。
     可以发送参数声明中所指定类型的逗号分隔的参数列表或指定类型的参数数组。 还可以不发送参数。 如果未发送
     任何参数，则 params 列表的长度为零。
     在方法声明中的 params 关键字之后不允许有任何其他参数，并且在方法声明中只允许有一个 params 关键字。        
         
         */
    class Program
    {

        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // You can send a comma-separated list of arguments of the
            // specified type.
            UseParams(1, 2, 3, 4);
            UseParams2(1, 'a', "test");
            // A params parameter accepts zero or more arguments.
            // The following calling statement displays only a blank line.
            UseParams2();
            // An array argument can be passed, as long as the array
            // type matches the parameter type of the method being called.
            int[] myIntArray = { 5, 6, 7, 8, 9 };
            UseParams(myIntArray);
            object[] myObjArray = { 2, 'b', "test", "again" };
            UseParams2(myObjArray);
            // The following call causes a compiler error because the object
            // array cannot be converted into an integer array.
            //UseParams(myObjArray);
            // The following call does not cause an error, but the entire
            // integer array becomes the first element of the params array.
            UseParams2(myIntArray);

            Console.Read();
        }
    }
}
