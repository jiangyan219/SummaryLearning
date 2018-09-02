using GalaSoft.MvvmLight;
using System.ComponentModel;
using MVVM_Binding.Model;

namespace MVVM_Binding.ViewModel
{
    /// <summary>
    /// ����
    /// ViewModel Ϊ�����ṩ���ݶ���  
    /// ������Ҫʲô�ֶΣ�������ʲô�ֶ�
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
        /// ԭʼ��������
        /// </summary>
        public Student Model
        {
            get
            {
                return this._student;
            }
        }
       
        /// <summary>
        /// ����
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
        /// �ַ�
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
        /// ����
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