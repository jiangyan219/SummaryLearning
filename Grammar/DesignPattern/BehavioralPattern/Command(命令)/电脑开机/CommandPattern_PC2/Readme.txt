学习自：http://www.cnblogs.com/sjms/archive/2010/07/09/1774069.html
命令模式
算是真正意义上理解了命令模式的妙处

在这个实例中，我们找到了现实生活中电脑开机这个事例。
在这个事例中，我们开机这个指令，下发给电脑机箱，也就说电脑机箱实际上就是命令的调用者Invoker，
接受这个命令的接受者（Receiver），就是机箱里面的主板，实际生活中，有很多主板吧，比如戴尔的、技嘉的...等等
原本只要在主板内部写一个方法就够了，但是实际上，每种不同的主板都是主板的子类，与主板是继承关系，
这样我们就可以定义一个主板的总接口了，就能非常方便的实现不同类型主板的扩展。
接下来我们创建开机指令（ConcreteCommand），开机指令的关联者就是主板，因为主板是接受开机指令的具体接受者，
在创建的开机指令中，我们继承主板的总接口，就可以将来实现 主板实例化时，new不同类型的主板
接下来，整个事例中，真正命令的调用者（Invoker），就是机箱，因为机箱上有开机按钮，机箱调用命令，
在机箱中，我们通过构造函数SetCommand 传入外界的指令，再增加一个方法RunCommand 模拟开机按钮 其实就是执行命令的执行-即按开机按钮
那么我们就可以在（客户端程序）中，实现开机了
    MainBoardApi mainBoard = new ReceiverGigaMainBoard();//主板类型：技嘉
    ConcreteOpenCommand openCommand = new ConcreteOpenCommand(mainBoard);//执行命令类型：开机
    Invoker invoker = new Invoker();//机箱
    invoker.SetCommand(openCommand);//机箱 装载 开机命令
    invoker.RunCommand();//机箱 执行 装载的开机命令

在整个的开机事例中，各种真实的物件在命令模式中的角色如下：
Command(命令抽象接口)：声明一个执行操作的接口Execute，当然我们在这个文件夹下面创建的主板Api接口，并不是命令接口，而是主板的抽象接口，放在这里便于结构的条理分明；
ConcreteCommand(具体命令)：开机指令
Invoker(命令的调用者)：机箱
Receiver(命令的接受者)：主板，比如戴尔主板

姜彦2018301 00:54


