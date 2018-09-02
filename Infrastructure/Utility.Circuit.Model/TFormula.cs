using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Circuit.Common.Helpers;

namespace Utility.Circuit.Model
{
    public class TFormula
    {
        public TFormula()
        {
            this.FormulaName = string.Empty;
            this.ScriptContent = string.Empty;
        }
        public TFormula(DataRow dataRow)
            : this()
        {
            this.Id = DataRowHelper.GetValue<int>(dataRow, "Id");
            this.PId = DataRowHelper.GetValue<int>(dataRow, "PId");
            this.StrId = DataRowHelper.GetValue(dataRow, "StrId");
            this.FormulaName = DataRowHelper.GetValue(dataRow, "FormulaName");
            this.ScriptContent = DataRowHelper.GetValue(dataRow, "ScriptContent");
        }

        /// <summary>
        /// 公式ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// PId
        /// </summary>
        public int PId { get; set; }

        public string StrId { get; set; }

        public bool ColorFlag { get; set; }

        /// <summary>
        /// 公式名称
        /// </summary>
        public string FormulaName { get; set; }

        /// <summary>
        /// 脚本内容
        /// </summary>
        public string ScriptContent { get; set; }
    }
}
