using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubscribeAndPublish
{
    /// <summary>
    /// 妈妈类
    /// </summary>
    public class Mom
    {
        /// <summary>
        /// 定义一个Eat事件；用于发布吃饭消息
        /// </summary>
        public event Action Eat;

        /// <summary>
        /// 饭好了，发布吃饭的消息-----------妈妈做饭的方法？
        /// </summary>
        public void Cook()
        {
            Console.WriteLine("妈妈说：饭好了！");
            Eat?.Invoke();
        }
    }
}
