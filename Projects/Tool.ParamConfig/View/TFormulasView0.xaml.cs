using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tool.ParamConfig.ViewModel;
using Utility.Circuit.Controller;
using Utility.Circuit.Model;

//某一个单元单独根据具体条件而变色 115行Background="{Binding Path=PId,Converter={StaticResource ColorConvert}}"  配合ColorConvert文件  姜彦 20180115
namespace Tool.ParamConfig.View
{
    /// <summary>
    /// TFormulasView.xaml 的交互逻辑
    /// </summary>
    public partial class TFormulasView0 : UserControl
    {
        private ObservableCollection<TFormulaViewModel> FormulaVMs;
        public TFormulasView0()
        {
            InitializeComponent();
            this.FormulaVMs = new ObservableCollection<TFormulaViewModel>();
            this.dgFormula.ItemsSource = this.FormulaVMs;
        }

        private void LoadFormula()
        {

            List<TFormula> Formulas = TFormulaController.GetFormulas();
            foreach (TFormula Formula in Formulas)
            {
                this.FormulaVMs.Add(new TFormulaViewModel(Formula));
            }
        }

        private void btnAddFormula_Click(object sender, RoutedEventArgs e)
        {
            TFormula Formula = TFormulaController.CreateFormula();
            if (TFormulaController.InsertFormula(Formula))
            {
                Formula.Id = TFormulaController.GetMaxID();
                this.FormulaVMs.Add(new TFormulaViewModel(Formula));
            }
            else
            {
                MessageBox.Show("添加规约失败！", "添加失败", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDeleteFormula_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveFormula_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                foreach (TFormulaViewModel FormulaVM in this.FormulaVMs)
                {
                    if (FormulaVM.IsDataModied == true)
                    {
                        TFormulaController.UpdateFormula(FormulaVM.Model);
                        FormulaVM.IsDataModied = false;
                    }
                }
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("计算公式参数已成功保存至参数库中！", "计算保存成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }));
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFormula();
        }

        //姜彦 20180112 21:23
        string strPId1 = string.Empty;  //全局变量  为了传递cell的变化内容，上一个跟下一个对比的传递媒介
        static BrushConverter conv1 = new BrushConverter();
        Brush color0;//通过第三个值  交换颜色 原理 A B C 通过C 交换A B
        Brush color1 = conv1.ConvertFromInvariantString("#E2E9E1") as Brush;//浅绿色EECEE0
        Brush color2 = conv1.ConvertFromInvariantString("#FFFFFF") as Brush;//白色
        private void dgFormula_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //var obj1 = e.Row.DataContext;
            //var vM = obj1 as TFormulaViewModel;
            //if (strPId1 == vM.StrId)
            //{
            //    e.Row.Background = (System.Windows.Media.Brush)color1;//浅绿色
            //}
            //else
            //{
            //    e.Row.Background = (System.Windows.Media.Brush)color2;//白色   
            //    color0 = color1;//通过第三个值  交换颜色 原理 A B C 通过C 交换A B
            //    color1 = color2;
            //    color2 = color0;
            //}
            //strPId1 = vM.StrId;

        }
    }
}
