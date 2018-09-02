using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Utility.Circuit.Model
{
    public class TTreeMenu : INotifyPropertyChanged
    {
        public TTreeMenu()
        {
            this.Guid = System.Guid.NewGuid().ToString();
            this.Children = new List<TTreeMenu>();
            this.Type = 0;
            this.Tag = string.Empty;
        }

        /// <summary>
        /// 数据标识
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型 0-普通 1-厂站 2-网络节点
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
        public TTreeMenu Parent { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<TTreeMenu> Children { get; set; }

        /// <summary>
        /// Tag
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 菜单选择
        /// </summary>
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
