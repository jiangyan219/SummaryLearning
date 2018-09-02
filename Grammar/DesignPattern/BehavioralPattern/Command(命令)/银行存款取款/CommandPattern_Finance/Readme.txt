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
