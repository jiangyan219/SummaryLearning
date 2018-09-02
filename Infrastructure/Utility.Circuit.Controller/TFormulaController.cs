using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Circuit.Common.Helpers;
using Utility.Circuit.Model;


namespace Utility.Circuit.Controller
{
    public class TFormulaController
    {
        #region 表名称
        static string TableName = "TFormula ";//TFormula  TFormula  TableJY
        #endregion

        #region 读取计算公式
        /// <summary>
        /// 读取计算公式
        /// </summary>
        /// <returns></returns>      

        public static List<TFormula> GetFormulas()
        {
            List<TFormula> formulas = new List<TFormula>();
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select* from " + TableName);
                SqlParameter[] cmdParams = { };
                DataSet dsResult = SQLHelper.ExecuteDataset(GlobalData.DBConnStr, CommandType.Text, strSql.ToString(), cmdParams);
                foreach (DataRow dataRow in dsResult.Tables[0].Rows)
                {
                    formulas.Add(new TFormula(dataRow));
                }

                bool flag = true;
                var groupInfo = formulas.GroupBy(m => m.StrId).ToList();

                foreach (IGrouping<string, TFormula> info in groupInfo)
                {
                    List<TFormula> s1 = info.ToList<TFormula>();

                    foreach (TFormula f in s1)
                    {
                        f.ColorFlag = flag;
                    }

                    flag = !flag;

                    int j = 0;
                }


            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return formulas;
        }

        public class FormulaGroup
        {
            public string StrId { get; set; }
            public List<TFormula> Formulas { get; set; }

        }


        public static List<TFormula> GetFormulaGroup()
        {

            List<TFormula> formulas = GetFormulas();

            List<FormulaGroup> fGroups = new List<FormulaGroup>();
            FormulaGroup fGroup = new FormulaGroup();

            //List<TFormula> formulaGroups = new List<TFormula>();
            //formulaGroups.GroupBy(x => x.StrId).Select(x => new FormulaGroup { StrId = x.Key, Formulas = x.ToList() });
            var groupTest=  formulas.GroupBy(x => x.StrId).Select(x => new FormulaGroup { StrId = x.Key, Formulas = x.ToList() });

           

            int i = 0;

            return null;
        }


        #endregion

        #region 删除计算公式

        /// <summary>
        /// 删除计算
        /// </summary>
        /// <param name="yxYkId"></param>
        /// <returns></returns>
        public static bool DeleteFormula(int FormulaId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from " + TableName);
                strSql.Append("where ");
                strSql.Append("Id=@Id");
                SqlParameter[] cmdParams =
                {
                     new SqlParameter("@Id", FormulaId)
                };
                int result = SQLHelper.ExecuteNonQuery(GlobalData.DBConnStr, CommandType.Text, strSql.ToString(), cmdParams);
                return result > 0 ? true : false;
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region 修改计算公式

        /// <summary>
        /// 修改计算公式
        /// </summary>
        /// <param name="Formula"></param>
        /// <returns></returns>
        public static bool UpdateFormula(TFormula Formula)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update " + TableName);
                strSql.Append("set ");
               // strSql.Append("Id=@Id,");
                strSql.Append("PId=@PId,");
                strSql.Append("StrId=@StrId,");
                strSql.Append("FormulaName=@FormulaName,");
                strSql.Append("ScriptContent=@ScriptContent ");
                strSql.Append("where ");
                strSql.Append("Id=@Id");
                SqlParameter[] cmdParams =
                {
                     new SqlParameter("@Id", Formula.Id),
                     new SqlParameter("@PId", Formula.PId),
                     new SqlParameter("@StrId", Formula.StrId),
                     new SqlParameter("@FormulaName", Formula.FormulaName),
                     new SqlParameter("@ScriptContent", Formula.ScriptContent)
                };
                int result = SQLHelper.ExecuteNonQuery(GlobalData.DBConnStr, CommandType.Text, strSql.ToString(), cmdParams);
                return result > 0 ? true : false;
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region 添加计算公式

        /// <summary>
        /// 添加计算公式
        /// </summary>
        /// <param name="Formula"></param>
        public static bool InsertFormula(TFormula Formula)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TFormula");
                strSql.Append("(");
                strSql.Append("Id,");
                strSql.Append("PId,");
                strSql.Append("StrId,");
                strSql.Append("FormulaName,");
                strSql.Append("ScriptContent");
                strSql.Append(")");
                strSql.Append("values");
                strSql.Append("(");
                strSql.Append("@Id,");
                strSql.Append("@PId,");
                strSql.Append("@StrId,");
                strSql.Append("@FormulaName,");
                strSql.Append("@ScriptContent");
                strSql.Append(")");
                SqlParameter[] cmdParams =
                {
                     new SqlParameter("@Id", Formula.Id),
                     new SqlParameter("@PId", Formula.PId),
                     new SqlParameter("@StrId", Formula.StrId),
                     new SqlParameter("@FormulaName", Formula.FormulaName),
                     new SqlParameter("@ScriptContent", Formula.ScriptContent),

                };
                int result = SQLHelper.ExecuteNonQuery(GlobalData.DBConnStr, CommandType.Text, strSql.ToString(), cmdParams);
                return result > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region 创建计算公式

        /// <summary>
        /// 创建计算公式
        /// </summary>
        public static TFormula CreateFormula()
        {
            TFormula Formula = new TFormula();
            Formula.Id = GetMaxID() + 1;
            Formula.FormulaName = "名称jy" + Formula.Id;
            //  Formula.ScriptContent ="描述jy"+ Formula.Id;
            return Formula;

            //TProtocolPara protocolPara = new TProtocolPara();
            //protocolPara.Id = GetMaxID() + 1;
            //protocolPara.ProParaName = "规约参数" + protocolPara.Id;
            //return protocolPara;

        }

        #endregion

        #region 读取最大ID值

        /// <summary>
        /// 读取最大ID值
        /// </summary>
        /// <returns></returns>
        public static int GetMaxID()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select max(Id) as maxId from " + TableName);//TFormula  TFormula  TableJY
                SqlParameter[] cmdParams = { };
                DataSet dsResult = SQLHelper.ExecuteDataset(GlobalData.DBConnStr, CommandType.Text, strSql.ToString(), cmdParams);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = dsResult.Tables[0].Rows[0];
                    return int.Parse(dataRow[0].ToString());
                }
                return -1;
            }
            catch
            {
                return -1;
            }

        }

        #endregion
    }
}
