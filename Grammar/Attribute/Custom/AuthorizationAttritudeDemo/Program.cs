using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationAttritudeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo();
            string userName = "Lucy";

            MethodInfo mi = d.GetType().GetMethod("Test");
            if (mi == null) return;
            AllowExecuteAttribute att = Attribute.GetCustomAttribute(mi, typeof(AllowExecuteAttribute)) as AllowExecuteAttribute;
            if (att == null) return;
            if (att.Check(userName))
                Console.WriteLine("允许执行");
            else
                Console.WriteLine("不允许执行");

            Console.ReadKey();
        }
    }

    class Demo
    {
        [AllowExecute("Jack, Tom")]
        public void Test() { }
    }

    /// <summary> 
    /// 标识某方法允许执行的用户 
    /// </summary> 
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowExecuteAttribute : Attribute
    {
        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="allowedUsers">允许执行的用户名的串联字符串</param> 
        public AllowExecuteAttribute(string allowedUsers)
        {
            this._allowedUsers = allowedUsers;
        }
        private string _allowedUsers;

        public bool Check(string userName)
        {
            return this._allowedUsers.ToLower().IndexOf(userName.ToLower()) > -1;
        }
    }
}
