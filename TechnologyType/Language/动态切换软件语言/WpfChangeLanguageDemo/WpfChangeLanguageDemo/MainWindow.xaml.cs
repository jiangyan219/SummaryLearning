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

namespace WpfChangeLanguageDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //定义ComboBox选项的类，存放Name和Value
        public class CategoryInfo
        {
            public string Name
            {
                get;
                set;
            }
            public string Value
            {
                get;
                set;
            }

        }

        //切换语言
        private void btnChangeLang_Click(object sender, RoutedEventArgs e)
        {
            object selectedName = cbLang.SelectedValue;
            if (selectedName != null)
            {
                string langName = selectedName.ToString();
                //英语的语言文件名为:DefaultLanguage,所有这里要转换一下
                if (langName == "en_US")
                    langName = "DefaultLanguage";
                //根据本地语言来进行本地化,不过这里上不到
                //CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;

                ResourceDictionary langRd = null;
                try
                {
                    //根据名字载入语言文件
                    langRd = Application.LoadComponent(new Uri(@"Language\" + langName + ".xaml", UriKind.Relative)) as ResourceDictionary;
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }

                if (langRd != null)
                {
                    //如果已使用其他语言,先清空
                    if (this.Resources.MergedDictionaries.Count > 0)
                    {
                        this.Resources.MergedDictionaries.Clear();
                    }
                    this.Resources.MergedDictionaries.Add(langRd);
                }
            }
            else
                MessageBox.Show("Please selected one Language first.");
        }

        //控件载入时，为ComboBox赋值
        private void cbLang_Loaded(object sender, RoutedEventArgs e)
        {
            List<CategoryInfo> categoryList = new List<CategoryInfo>();
            categoryList.Add(new CategoryInfo() { Name = "English", Value = "en_US" });
            categoryList.Add(new CategoryInfo() { Name = "中文", Value = "zh_CN" });

            cbLang.ItemsSource = categoryList;//绑定数据，真正的赋值
            cbLang.DisplayMemberPath = "Name";//指定显示的内容
            cbLang.SelectedValuePath = "Value";//指定选中后的能够获取到的内容
        }

      

    }
}
