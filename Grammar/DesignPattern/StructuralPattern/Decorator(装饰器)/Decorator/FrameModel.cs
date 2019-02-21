/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Decorator
 * 类 名 称 ：FrameModel 
 * 命名空间 ：Decorator
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 12:55:04
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 装饰器原始积累
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Decorator
{
    /// <summary>
    /// FrameModel
    /// </summary>
    public abstract class FrameModel
    {
        #region 帧基本结构
        /// <summary>
        /// 帧头
        /// </summary>
        public static readonly byte FrameBegin = 0xFA;

        /// <summary>
        /// 命令ID
        /// </summary>
        public CommandID CmdID;

        /// <summary>
        /// 帧号 2 BYTES - (0 ~ 0xFEFE)
        /// </summary>
        public ushort iSeqNo;

        /// <summary>
        /// 是否需要应答
        /// 00：不需要 or  上报帧
        /// 01：需要  
        /// 02:应答帧
        /// </summary>
        public byte IsReply;

        /// <summary>
        /// 命令的数据内容
        /// </summary>
        public byte[] CmdData;

        /// <summary>
        /// 校验码 
        /// </summary>
        public byte LRC { get; set; }

        /// <summary>
        /// 帧尾 
        /// </summary>
        public static readonly byte FrameEnd = 0xFB;

        #endregion

        #region 帧其他属性

        /// <summary>
        /// 该包的存活时间
        /// </summary>
        public DateTime iLiveTime;

        /// <summary>
        /// 是否立即发送 
        /// </summary>
        public bool Immediate;
        public static bool IsEncode { get; set; }

        public static bool IsBigEndian = true;
        public int IConSendCnt { get; set; }

        #endregion

        #region 帧其他方法

        /// <summary>
        /// 计算LRC校验值
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte GetLRC(List<byte> datas)
        {
            byte Cs;
            Cs = 0;
            foreach (byte data in datas)
                Cs = (byte)(Cs + data);

            uint sub = 256 - (uint)Cs;
            Cs = (byte)sub;
            switch (IsEncode)
            {
                case false:
                    byte[] ds;
                    //ds = DataConverter.ToBytes(Cs);
                    //Cs = ds[0];
                    break;

                default: break;
            }
            return Cs;

        }

        #endregion

        #region 抽象方法
        /// <summary>
        /// 将通信帧转化为byte[]
        /// </summary>
        /// <returns></returns>        
        public abstract byte[] ToByte();

        /// <summary>
        /// 将通信帧转为字符串类型
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();

        #endregion
    }

    public enum CommandID
    {
        MSG_Connect,
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
