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
using Utility.Circuit.Model;
using Utility.Circuit.Controller;
using Tool.ParamConfig.View;

namespace Tool.ParamConfig
{
    /// <summary>
    /// ParamConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ParamConfigWindow : Window
    {
        private List<TTreeMenu> menuInfos;
       // private List<TStation> stations;
        public ParamConfigWindow()
        {
            this.menuInfos = new List<TTreeMenu>();
           // this.stations = new List<TStation>();
            InitializeComponent();
        }

        private void menuTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TTreeMenu menuInfo = e.NewValue as TTreeMenu;
            if (menuInfo == null)
            {
                return;
            }
            int stationId = 0;
            int commDevId = 0;
            switch (menuInfo.Name)
            {
               
                case "计算公式配置":
                    this.gdContainer.Children.Clear();
                    this.gdContainer.Children.Add(new TFormulasView());
                    break;
                case "系统参数配置":
                    this.gdContainer.Children.Clear();
                    this.gdContainer.Children.Add(new TFormulasView0());
                    break;

                default: break;
            };
        }
    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMenu(6);
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        private void LoadMenu(int selectMenu)
        {
            string treeIcon1 = "/STool.ParamConfig;component/Image/TreeIcon1.png";
            string treeIcon2 = "/Tool.ParamConfig;component/Image/TreeIcon2.png";

            this.menuInfos.Clear();
            this.menuInfos.Add(new TTreeMenu() { Name = "系统参数配置", Icon = treeIcon1 });
            this.menuInfos.Add(new TTreeMenu() { Name = "计算公式配置", Icon = treeIcon1 });
            this.menuInfos.Add(new TTreeMenu() { Name = "计算量配置", Icon = treeIcon1 });
            this.menuInfos.Add(new TTreeMenu() { Name = "越限参数配置", Icon = treeIcon1 });
            this.menuInfos.Add(new TTreeMenu() { Name = "规约参数配置", Icon = treeIcon1 });
            this.menuInfos.Add(new TTreeMenu() { Name = "通讯设备配置", Icon = treeIcon1 });

           
            

            if (selectMenu < this.menuInfos.Count)
            {
                this.menuInfos[selectMenu].IsSelected = true;
            }
            else
            {
                this.menuInfos[0].IsSelected = true;
            }
            menuTree.ItemsSource = null;
            menuTree.ItemsSource = this.menuInfos;
        }
    }
}
