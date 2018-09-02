using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceStrategy
{
    /// <summary>
    /// 上下文
    /// </summary>
    public  class Price
    {

        private Strategy _Strategy=null;

        /// <summary>
        /// 构造方法，传入一种策略
        /// </summary>
        /// <param name="strategy"></param>
        public Price(Strategy strategy)
        {
            this._Strategy = strategy;
        }

        /// <summary>
        /// 上下文对客户端提供的操作接口，可以有参数和返回值
        /// 报价，计算对客户的报价
        /// </summary>
        /// <param name="goodsPrice">商品销售原价</param>
        /// <returns>计算出来的，应该给客户报的价格</returns>
        public double Quote(double goodsPrice)
        {
            return this._Strategy.CalcPrice(goodsPrice);
        }
    }
}
