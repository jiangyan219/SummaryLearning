using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Utility.Circuit.Model;

namespace Tool.ParamConfig.ViewModel
{
    public class TFormulaViewModel : ViewModelBase
    {
        private TFormula Formula;
        private bool isSelected;
        public TFormulaViewModel(TFormula Formula)
        {
            this.Formula = Formula;
            this.isSelected = false;
        }

        /// <summary>
        /// 数据模型
        /// </summary>
        public TFormula Model
        {
            get
            {
                return this.Formula;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get
            {
                return this.Formula.Id;
            }
        }

        public int PId
        {
            get
            {
                return this.Formula.PId;
            }

            set
            {
                if (this.Formula.PId != value)
                {
                    this.Formula.PId = value;
                    this.IsDataModied = true;
                }
            }

        }


        public string StrId
        {
            get
            {
                return this.Formula.StrId;
            }

            set
            {
                if (this.Formula.StrId != value)
                {
                    this.Formula.StrId = value;
                    this.IsDataModied = true;
                }
            }

        }

        public bool ColorFlag
        {
            get { return this.Formula.ColorFlag; }
            set { this.Formula.ColorFlag = value; }

        }

       
        //private int flagA = 1;
        //private int flagB = 0;
        //private int flagC;
        //private string _StrId = string.Empty;

        //int n = 0;
        //private int GetBool()
        //{
        //    int flag = 0;

        //    if (_StrId == this.Formula.StrId)
        //    {
        //        flag = flagA;
        //    }
        //    else
        //    {
        //        flag = flagB;
        //        flagC = flagA;
        //        flagA = flagB;
        //        flagB = flagC;
        //    }
        //    return flag;

        //    //if (n == 0)
        //    //{
        //    //    _StrId = this.Formula.StrId;
        //    //    return 0;
        //    //}
        //    //else
        //    //{


        //    //    if (_StrId == this.Formula.StrId)
        //    //    {
        //    //        flag = flagA;
        //    //    }
        //    //    else
        //    //    {
        //    //        flag = flagB;
        //    //        flagC = flagA;
        //    //        flagA = flagB;
        //    //        flagB = flagC;
        //    //    }
        //    //    return flag;
        //    //}
        //    //n++;

        //}

        //public int ColorFlag
        //{
        //    get
        //    {
        //        return GetBool();
        //    }
        //    set
        //    {                
        //        _StrId = this.Formula.StrId;
        //    }

        //}

        /// <summary>
        /// 计算公式名称
        /// </summary>
        public string FormulaName
        {
            get
            {
                return this.Formula.FormulaName;
            }
            set
            {
                if (this.Formula.FormulaName != value)
                {
                    this.Formula.FormulaName = value;
                    this.IsDataModied = true;
                }
            }
        }

        /// <summary>
        /// 计算公式名称
        /// </summary>
        public string ScriptContent
        {

            #region 无法更新文本编辑框的内容到cell
            //get
            //{
            //    return this.Formula.ScriptContent;
            //}
            //set
            //{
            //    if (this.Formula.ScriptContent != value)
            //    {
            //        this.Formula.ScriptContent = value;
            //        this.IsDataModied = true;
            //    }
            //}
            #endregion

            get
            {
                return this.Formula.ScriptContent;
            }
            set
            {
                if (this.Formula.ScriptContent != value)
                {
                    this.Formula.ScriptContent = value;
                    this.IsDataModied = true;
                    RaisePropertyChanged(() => this.ScriptContent);//是否跟更新cells内容有关  姜彦 20170306 
                }
            }

        }

        /// <summary>
        /// 数据修改标记
        /// </summary>
        public bool IsDataModied { get; set; }

        /// <summary>
        /// 选中
        /// </summary>
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    RaisePropertyChanged(() => this.IsSelected);
                }
            }

        }


    }
}
