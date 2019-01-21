/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Clone
 * 类 名 称 ：Cup 
 * 命名空间 ：Clone
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/1/21 9:24:15
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 对克隆接口ICloneable的使用学习，
 *            重在比对更CloneExtends里深度克隆的区别联系
 * 参考文献：https://blog.csdn.net/heyangyi_19940703/article/details/51241081           
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;

namespace Clone
{
    /// <summary>
    /// Cup
    /// </summary>
    [Serializable]
    public class Cup : ICloneable
    {
        public int Height { get; set; }
        public int RL { get; set; }
        public Colors c { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();//浅克隆
        }

        public object DeepClone()
        {
            Cup cupClone = (Cup)this.MemberwiseClone();//cupClone是一个浅克隆对象，只克隆了引用地址及值类型值，没有克隆值引用类型值；
           
            Colors c = new Colors()//实例化一个引用类型值新的对象；
            {
                foot = this.c.foot,
                Top=this.c.Top,
            };
            cupClone.c = c;//通过一个新的实例化对象，传入已经浅克隆的引用类型对象的值，实现深克隆；
            return cupClone;
        }
    }

    /// <summary>
    /// 杯子的局部颜色属性
    /// </summary>
    [Serializable]
    public class Colors
    {
        /// <summary>
        /// 顶部颜色
        /// </summary>
        public string Top { get; set; }

        /// <summary>
        /// 底部颜色
        /// </summary>
        public string foot { get; set; }

    }

}

/*----------------------------------------------------------------
 * 备    注 ：
 * 
 * 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/
