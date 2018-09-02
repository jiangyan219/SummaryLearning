using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern_Finance.Command_命令抽象类_
{
    /// <summary>
    /// 抽象命令 or 执行命令的接口
    /// </summary>
    public interface Command
    {
        void Execute();
    }
}
