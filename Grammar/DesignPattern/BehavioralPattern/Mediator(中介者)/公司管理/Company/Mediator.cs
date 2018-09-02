using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    /// <summary>
    /// 抽象中介者
    /// </summary>
    public interface Mediator
    {
        void Command(Department department);
    }
}
