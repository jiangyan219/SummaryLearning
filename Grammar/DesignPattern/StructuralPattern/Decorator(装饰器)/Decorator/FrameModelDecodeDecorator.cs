/*----------------------------------------------------------------
 * 作    者 ：姜  彦 
 * 项目名称 ：Decorator
 * 类 名 称 ：FrameModelDecodeDecorator 
 * 命名空间 ：Decorator
 * CLR 版本 ：4.0.30319.42000
 * 创建时间 ：2019/2/21 12:57:26
 * 当前版本 ：1.0.0.1 
 * My Email ：jiangyan2008.521@gmail.com 
 *            jiangyan2008.521@qq.com   
 * 描述说明： 基类FrameModel的装饰器
 * 
 * 修改历史： 
 * 
*******************************************************************
 * Copyright @ JiangYan 2019. All rights reserved.
*******************************************************************
------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// FrameModelDecodeDecorator
    /// </summary>
    public class FrameModelDecodeDecorator:FrameModel
    {
        #region Construction
        public FrameModelDecodeDecorator()
        {

        }

        public FrameModelDecodeDecorator(FrameModel frameModel)
        {
            _FrameModel = frameModel;
        }

        #endregion

        #region Property

        #region Global Variable

        private FrameModel _FrameModel = null;

        #endregion

        #endregion

        #region Decorator of abstruct fuctions

        public override byte[] ToByte()
        {
            List<byte> packet = new List<byte>();
            byte[] ccmd = BitConverter.GetBytes((ushort)_FrameModel.CmdID);
            byte[] iSeqNo = BitConverter.GetBytes(_FrameModel.iSeqNo);

            packet.Add(FrameBegin);
            packet.Add(ccmd[1]);
            packet.Add(ccmd[0]);
            packet.Add(iSeqNo[1]);
            packet.Add(iSeqNo[0]);
            packet.Add(_FrameModel.IsReply);


            for (int i = 0; i < _FrameModel.CmdData.Length; i++)
            {
                packet.Add(_FrameModel.CmdData[i]);
            }

            byte Cs = GetLRC(packet.Skip(1).Take(packet.Count - 1).ToList());
            packet.Add(Cs);
            packet.Add(FrameEnd);
            return packet.ToArray();
        }
        public override string ToString()
        {
            List<byte> packet = new List<byte>();
            byte[] ccmd = BitConverter.GetBytes((ushort)_FrameModel.CmdID);
            byte[] iSeqNo = BitConverter.GetBytes((ushort)_FrameModel.iSeqNo);

            packet.Add(FrameBegin);
            packet.Add(ccmd[1]);//F0     
            packet.Add(ccmd[0]);//30   
            packet.Add(iSeqNo[1]);//01     
            packet.Add(iSeqNo[0]);//00 
            packet.Add(_FrameModel.IsReply);

            for (int i = 0; i < _FrameModel.CmdData.Length; i++)
            {
                packet.Add(_FrameModel.CmdData[i]);
            }

            byte Cs = GetLRC(packet.Skip(1).Take(packet.Count - 1).ToList());
            packet.Add(Cs);
            packet.Add(FrameEnd);

            StringBuilder recBuffer16 = new StringBuilder();
            string sendStr = string.Empty;
            byte[] sendBytes = packet.ToArray();
            for (int i = 0; i < sendBytes.Length; i++)
            {
                recBuffer16.AppendFormat("{0:X2}" + " ", sendBytes[i]);
            }
            sendStr = recBuffer16.ToString();
            return sendStr;
        }

        #endregion
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
