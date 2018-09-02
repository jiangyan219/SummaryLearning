using CommandPattern_PC.Command_命令抽象接口_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC
{
    /*

     * 开机命令的实现，实现Command接口，

     * 持有开机命令的真正实现，通过调用接收者的方法来实现命令

     */

    public class OpenCommand : Command
    {
        private MainBoardApi mainBoard = null;

        public OpenCommand(MainBoardApi mainBoardApi)
        {
            this.mainBoard = mainBoardApi;
        }

        public void Execute()
        {
            // throw new NotImplementedException();
            this.mainBoard.Open();
        }
    }
}
