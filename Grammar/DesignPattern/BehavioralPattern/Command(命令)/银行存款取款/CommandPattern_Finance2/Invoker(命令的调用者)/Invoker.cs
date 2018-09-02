﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Command_命令抽象类_;

namespace CommandPattern_Finance.Invoker_命令的调用者_
{
    /// <summary>
    /// 命令的调用者
    /// </summary>
    public class Invoker
    {
       
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
