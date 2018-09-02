using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 策略，定义算法接口
    /// </summary>
    public interface Strategy
    {
        /// <summary>
        /// 计算价格方式-接口
        /// </summary>
        double CalcPrice(double goodPrice);
    }
}
