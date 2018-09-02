using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC.Command_命令抽象接口_
{
    /// <summary>
    /// 主板接口
    /// </summary>
    public  interface MainBoardApi
    {
        /// <summary>
        /// 主板开机指令
        /// </summary>
        void Open();

        void Reset();
    }
}
