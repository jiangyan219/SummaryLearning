using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Binding.Model
{
    /// <summary>
    /// 原始数据类对象  可以不只有这三个字段  提供给ViewModel数据支持
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Student(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字符
        /// </summary>
        public string Char
        {
            get { return this.Name.Substring(2, 1); }
            set { Name = value; }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Len
        {
            get { return this.Name.Length; }
            set { Name = value.ToString(); }
        }


    }
}
