 学习自http://www.jb51.net/article/85571.htm 
 姜彦20180228

 姜彦20180228 16:00
   设计模式-行为型模式-Command（命令模式）的实例---银行账户转账、存钱、取钱的实例---
1.扩展支付宝账户存钱指令
2.在Receiver（命令接受者）中增加 AlipayAccount
  在Invoker（命令调用者）中增加 AlipayUser
  在ConcreteCommand（具体名利）中增加 AlipayAccountMoneyInCommand
  在Command（命令抽象类）中 重载了 Command这个构造函数（重载：方法名不变；参数必须变类型or个数；内部逻辑可变或不变）
3.在Client（客户端程序）中 增加了调用支付宝存钱的命令

****姜彦20180301 02:23****
通过学习 电脑开机这个命令模式 后 
在这个金融机构的一些金融操作诸如：存钱、转入...等 做了一些修改
基本上了实现了，创建一个Command接口 一个FinancialInstitution(金融机构)接口与一个总的具体命令类
ConcreteCommand(具体命令)：ConcreteMoneyInCommand（当时这个类中Execute方法执行了多个方法，如存钱、转入故而不行；姜彦201800302 0:24）
通过
一个命令调用者（Invoker）
实现了，在Receiver(命令的接受者)中，可以仅在此文件夹中，添加不同类型的金融机构，比如支付宝、工商银行就可以
完成在Client(客户端程序)中的相应的命令的执行调用，将来可以继续扩展其他的比如农业银行、建设银行、微信支付...等等的扩展，
极大的实现了代码的利用率，架构非常的好

但是这个实例中，存在一个问题，就是不能实现不同的方法的分开使用，比如一旦写好了，存钱、转入是一个固定模式运行，
我想应该还有方式可以实现存钱、转入的分开执行，这应该需要优化下FinancialInstitution(金融机构)接口，
并在ConcreteCommand(具体命令)通过创建不同的指令来分别执行，这应该会导致Client(客户端程序)端的代码量增多，
不过这对于大型的软件系统来说，我想通过命令模式实现的架构的合理而言，客户端的代码增加应该是不值得多虑的，
因为客户端本来就要完成很多操作，而相对命令模式带来的极高的可扩展性、极高的可维护性而言，这个代码增加的损失是极小极小的
20180301 02:30

****姜彦20180302 00:16****
把昨天没有把不用方法分开执行的问题的解决了，原来的第一版中，由于仅仅创建了一个
ConcreteCommand(具体命令)：ConcreteMoneyInCommand，而这个类中的Execute执行了多个方法，除了存钱，还有转入，这样无法显示存钱与转入分开；
故而今天想到了解决方法，那就是在
ConcreteCommand(具体命令)中，除了创建ConcreteMoneyInCommand类，新增一个转入类ConcreteTransferInCommand，并且
ConcreteMoneyInCommand    类中：仅Execute执行 存钱方法： this._financialInstitution.MoneyIn(this._amount);
ConcreteTransferInCommand 类中：仅Execute执行 转入方法： this._financialInstitution.TransferIn(this._amount);
这样就实现了 存钱 跟 转入 命令的分开。
并且，在客户端中
FinancialInstitution financialInstitution;//抽象一个金融机构类型
Invoker invoker = new Invoker();//抽象一个App
Command moneyInCommand;//抽象一个存钱指令
Command transferInCommand;//抽象一个转入指令

当金融机构为支付宝时，就把 financialInstitution new 为Alipay；
当金融机构为工商银时，就把 financialInstitution new 为ICBC；

并且在某个金融机构下面，如支付宝下，可以 new 不同金融指令，如：
moneyInCommand  = new ConcreteMoneyInCommand(financialInstitution, 1000);//new一个存钱指令，   然后 装载 并 执行
transferInCommand = new ConcreteTransferInCommand(financialInstitution,888);//new一个转入指令，然后 装载 并 执行


同样的方式，也可以到工商银行ICBC下面（复制）实现，也可以到农业银行ICBC下面（复制）实现
20180302 00:49

