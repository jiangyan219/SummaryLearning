using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVM_Binding.ViewModel;
using MVVM_Binding.Model;

namespace MVVM_Binding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel student = new MainViewModel(new Student("Hello"));

        public MainWindow()
        {
            InitializeComponent();           
            this.grid1.DataContext = student;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.student.Name = "JiangYan";            
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel stu = this.student;//你可以取消这两行的注释，修改下textbox的内容，在int i=0 这里打个断点，看看textbox更改后的数据是否传递进来了 姜彦20180117
            //int i = 0;

            this.student = new MainViewModel(new Student("JiangYan"));
            this.grid1.DataContext = student;           
        }
    }
}
