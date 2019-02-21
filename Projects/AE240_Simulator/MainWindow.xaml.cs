using System;
using System.Windows;

namespace AE240_Simulator
{
#pragma warning disable CS1591
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       // private ObservableCollection<MainViewModel> MainWindowVMs;

        public MainWindow()
        {
            InitializeComponent();
            //this.MainWindowVMs = new ObservableCollection<MainViewModel>();
        }

   
    }

    /*接口跟抽象类的区别与联系*/
    
    public enum AllTestType:int
    {       
        Normal=0,       
        Err=1,
    }

    public delegate void OnExceptionedEventHandler(object sender,EventArgs e);
   

    interface IContent
    {
        int Add(int a, int b);
        
        event OnExceptionedEventHandler OnExceptioned;     
        string Age { get; set; }   
        AllTestType TestType { get; set; }
        /*
         * 接口无法声明类型：委托
         * 接口不能包含字段：静态、动态、常量、字符串、整型、枚举等等
         * 接口中的方法、事件、属性不需要修饰符
         */
        //接口无法声明类型：委托
        //delegate void OnConnectedEventHandler();

        //接口不能包含字段
        //const uint SENSOR_RT = 0x64010101;

        //接口不能包含字段
        //string Name;

        //接口不能包含字段
        //AllTestType _TestType;

        //接口不能包含字段
        //static int TotalCount = 100;
    }

    abstract class AbstractContent
    {
        public abstract int Add(int a, int b);        

        public  event OnExceptionedEventHandler OnExceptioned;
        public abstract Delegate GetDelegate();
        public string Age { get; set; }    
        public AllTestType TestType { get; set; }
        /*
         * 抽象类可以声明类型：委托
         * 抽象类能够包含字段：静态、动态、常量、字符串、整型、枚举等等
         * 抽象类中的方法、事件、属性不需要修饰符
         */
        public delegate void OnConnectedEventHandler();
        public const uint SENSOR_RT = 0x64010101;
        public string Name;
        public AllTestType _TestType;
        public static int TotalCount = 100;
    }

}
