using GalaSoft.MvvmLight;
using System.ComponentModel;
using MVVM_Binding.Model;

namespace MVVM_Binding.ViewModel
{
    /// <summary>
    /// 交互
    /// ViewModel 为界面提供数据对象  
    /// 界面需要什么字段，就配置什么字段
    /// </summary>
    public class MainViewModel : ViewModelBase 
    {
        private Student _student;// = new Student("Jim");
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(Student stu)
        {

            this._student = stu;
        }

        /// <summary>
        /// 原始对象数据
        /// </summary>
        public Student Model
        {
            get
            {
                return this._student;
            }
        }
       
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            
            get { return this._student.Name; }
            set
            {
                if (this._student.Name != value)
                {
                    this._student.Name = value;
                    RaisePropertyChanged(() => this._student.Name);
                }

            }

        }

        /// <summary>
        /// 字符
        /// </summary>
        public string Char
        {
            get { return this._student.Char; }
            set
            {
                if (this._student.Char != value)
                {
                    this._student.Char = value;
                    RaisePropertyChanged(() => this._student.Char);
                }

            }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Len
        {
            get { return this._student.Len; }
            set
            {
                if (this._student.Len != value)
                {
                    this._student.Len = value;
                    RaisePropertyChanged(() => this._student.Len);
                }

            }
        }

      


    }
}