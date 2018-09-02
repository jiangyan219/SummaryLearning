using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
    我们用一个简单的例子，来说明一下这种消息传递的机制。

　　有一家三口，妈妈负责做饭，爸爸和孩子负责吃。。。将这三个人，想象成三个类。

　　妈妈有一个方法，叫做“做饭”。有一个事件，叫做“开饭”。做完饭后，调用开发事件，发布开饭消息。

　　爸爸和孩子分别有一个方法，叫做“吃饭”。

　　将爸爸和孩子的“吃饭”方法，注册到妈妈的“开饭”事件。也就是，订阅妈妈的开饭消息。让妈妈做完饭开饭时，发布吃饭消息时，告诉爸爸和孩子一声。
     
     
     */

/// <summary>
/// 事件的订阅和发布  姜彦20180126
/// </summary>
namespace SubscribeAndPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化对象
            Mom mom = new Mom();
            Dad dad = new Dad();
            Child child = new Child();
            Grandfather grd = new Grandfather();

            //将爸爸和孩子的Eat方法注册到妈妈的Eat事件
            //订阅妈妈开饭的消息
            mom.Eat += dad.Eat;
            mom.Eat += child.Eat;
            mom.Eat += grd.Eat;

            //调用妈妈的Cook事件
            mom.Cook();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        //public class Mom
        //{
        //    //定义Eat事件，用于发布吃饭消息
        //    public event Action Eat;

        //    public void Cook()
        //    {
        //        Console.WriteLine("妈妈 : 饭好了");
        //        //饭好了，发布吃饭消息
        //        Eat?.Invoke();
        //    }
        //}

        //public class Dad
        //{
        //    public void Eat()
        //    {
        //        //爸爸去吃饭
        //        Console.WriteLine("爸爸 : 吃饭了。");
        //    }
        //}

        //public class Child
        //{
        //    public void Eat()
        //    {
        //        //熊孩子LOL呢，打完再吃
        //        Console.WriteLine("孩子 : 打完这局再吃。");
        //    }
        //}
    }
}
