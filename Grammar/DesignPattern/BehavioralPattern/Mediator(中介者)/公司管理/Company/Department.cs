using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    /// <summary>
    /// 抽象部门类
    /// </summary>
    public abstract class Department
    {
        private Mediator _Mediator;//持有中介者（总经理）的引用

        protected Department(Mediator mediator)
        {
            this._Mediator = mediator;
        }

        public Mediator GetMediator
        {
            get { return _Mediator; }
            set { this._Mediator = value; }
        }

        /// <summary>
        /// 做本部门的事情
        /// </summary>
        public abstract void Process();

        /// <summary>
        /// 向经理发出申请
        /// </summary>
        public abstract void Apply();

    }
}
