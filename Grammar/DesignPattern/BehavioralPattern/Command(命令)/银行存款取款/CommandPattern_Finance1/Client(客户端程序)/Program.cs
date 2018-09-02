using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern_Finance.Receiver_命令的接受者_;
using CommandPattern_Finance.Command_命令抽象类_;
using CommandPattern_Finance.ConcreteCommand_具体命令_;
using CommandPattern_Finance.Invoker_命令的调用者_;

namespace CommandPattern_Finance
{
    /// <summary>
    /// 客户端
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 
            //BankAccount account = new BankAccount();//创建银行账号
            //Command commandIn = new MoneyInCommand(account,500);//创建一个存款500的命令
            //Invoker invoker = new Invoker();// 创建一个调度者

            //invoker.SetCommand(commandIn);//调度一个 存款 命令
            //invoker.ExecuteCommand();//执行刚调度的命令

            //Command commandIn2 = new MoneyInCommand(account,500);//创建一个 再次 存入 500元 的命令
            //invoker.SetCommand(commandIn2);//调度这个 又存入500元的 命令
            //invoker.ExecuteCommand();//执行刚调度的命令

            //Command commandOut = new MoneyOutCommand(account, 300);//创建一个 取款 300元 的命令
            //invoker.SetCommand(commandOut);//调度一个 取款命令
            //invoker.ExecuteCommand();//执行刚调度的命令

            //Command commandTransferIn = new TransferInCommand(account,8000);//创建一个 转入 8000元 的命令
            //invoker.SetCommand(commandTransferIn);//调度这个 转入命令
            //invoker.ExecuteCommand();//执行刚调度的命令

            //Command commandTransferOut = new TransferOutCommand(account,1500);//穿件一个 转出 1500元 的命令
            //invoker.SetCommand(commandTransferOut);//调度这个 转出命令
            //invoker.ExecuteCommand();//执行刚调度的命令

            ////AlipayAccount alipayAccount = new AlipayAccount();
            ////Command alipayIn = new AlipayAccountMoneyInCommand(alipayAccount, 8888);
            ////AlipayUser alipayUser = new AlipayUser();

            ////alipayUser.SetCommand(alipayIn);
            ////alipayUser.ExecuteCommand();

            //AlipayAccount alipayAccount = new AlipayAccount();
            //Command alipayIn = new AlipayAccountMoneyInCommand(alipayAccount, 8888);
            //Invoker alipayUser = new Invoker();

            //alipayUser.SetCommand(alipayIn);
            //alipayUser.ExecuteCommand();

            //Command alipayAccountTransferInCommand = new AlipayAccountTransferInCommand(alipayAccount ,5000);
            //alipayUser.SetCommand(alipayAccountTransferInCommand);
            //alipayUser.ExecuteCommand();
            #endregion

            FinancialInstitution financialInstitution = new Alipay();//金融机构类型：支付宝
            ConcreteFinancialInstitutionCommand command
                = new ConcreteFinancialInstitutionCommand(financialInstitution, 1000);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);//装载命令
            invoker.ExecuteCommand();//执行命令


            financialInstitution = new ICBC();//金融机构类型：支付宝
            command
                = new ConcreteFinancialInstitutionCommand(financialInstitution, 5000);
            //Invoker invoker = new Invoker();
            invoker.SetCommand(command);//装载命令
            invoker.ExecuteCommand();//执行命令

            Console.Read();

        }
    }
}
