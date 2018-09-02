using CommandPattern_PC.Command_命令抽象接口_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC
{
    /*

     * 机箱对象，本身有按钮，持有按钮对应的命令对象

     */

    public class Box
    {
        private Command openCommand;

        public void SetOpenCommand(Command command)
        {
            this.openCommand = command;
        }

        public void OpenButtonPressed()
        {
            openCommand.Execute();
        }
    }
}
