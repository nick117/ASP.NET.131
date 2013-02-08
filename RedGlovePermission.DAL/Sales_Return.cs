using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
    /// <summary>
    /// 訂單管理資料操作類別
    /// </summary>
    public class Sales_Return : ISales_Return
    {
        public Sales_Return()
		{}
		#region  成员方法

        /// <summary>
        /// 判斷銷貨退回單是否存在
        /// </summary>
        /// <param name="ReturnID">銷貨退回單編號</param>
        /// <returns></returns>
        public bool ReturnExists(string ReturnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sales_Return");
            strSql.Append(" where ReturnID=@ReturnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnID", SqlDbType.Char,13)};
            parameters[0].Value = ReturnID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 銷貨退回單總額重算
        /// </summary>
        /// <param name="ReturnID">銷貨退回單編號</param>
        /// <returns></returns>
        public int ReturnTotal(string ReturnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_Return ");
            strSql.Append("set Total = (select sum(Qty*UnitPrice*Discount) from Sales_Return_dtl where ReturnID=@ReturnID group by ReturnID) ");
            strSql.Append(", Tax = (select sum(Qty*UnitPrice*Discount) from Sales_Return_dtl where ReturnID=@ReturnID group by ReturnID) * TaxRate ");
            strSql.Append(" where ReturnID=@ReturnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnID", SqlDbType.Char,13)};
            parameters[0].Value = ReturnID;

            return SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 取得一個新銷貨退回單編號
        /// </summary>
        /// <returns></returns>
        public string GetNewReturnID(string Track)
        {
            string NewID;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ReturnID from Sales_Return");
            strSql.Append(" where ReturnID like @ReturnID ");
            strSql.Append(" order by ReturnID Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnID", SqlDbType.Char,11)};
            parameters[0].Value = Track+"%";

            RedGlovePermission.Model.Sales_Return model = new RedGlovePermission.Model.Sales_Return();
			DataSet ds=SqlServerHelper.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                NewID = (int.Parse(ds.Tables[0].Rows[0]["ReturnID"].ToString().Substring(10, 3)) + 1001).ToString();
                NewID = Track + NewID.Substring(NewID.Length - 3);
            }
            else
            {
                NewID = Track + "001";
            }
            return NewID;
        }

        /// <summary>
        /// 取得銷貨退回單細項編號
        /// </summary>
        /// <param name="OID">銷貨退回單編號</param>
        /// <returns></returns>
        public string GetNewReturnSeq(string OID)
        {
            string NewSEQ;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Seq from Sales_Return_DTL");
            strSql.Append(" where ReturnID = @ReturnID ");
            strSql.Append(" order by Seq Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnID", SqlDbType.Char,13)};
            parameters[0].Value = OID;

            RedGlovePermission.Model.Sales_Return model = new RedGlovePermission.Model.Sales_Return();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                NewSEQ = (int.Parse(ds.Tables[0].Rows[0]["SEQ"].ToString()) + 1).ToString();
            }
            else
            {
                NewSEQ = "1";
            } return NewSEQ;
        }

        /// <summary>
        /// 得到一筆銷貨退回單單資料
        /// </summary>
        /// <param name="ReturnID">銷貨退回單單編號</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Sales_Return GetReturnModel(string ReturnID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sales_Return ");
            strSql.Append(" where ReturnID=@ReturnID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnID", SqlDbType.Char,13)};
            parameters[0].Value = ReturnID;

            RedGlovePermission.Model.Sales_Return model = new RedGlovePermission.Model.Sales_Return();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
                //{
                model.ReturnID = ds.Tables[0].Rows[0]["ReturnID"].ToString();
                //}
                model.Return_Date = ds.Tables[0].Rows[0]["Return_Date"].ToString();
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                model.MA001 = ds.Tables[0].Rows[0]["MA001"].ToString();
                model.CaseNo = ds.Tables[0].Rows[0]["CaseNo"].ToString();
                model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                model.TaxRate = float.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
                model.Amount = float.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                model.Tax = float.Parse(ds.Tables[0].Rows[0]["Tax"].ToString());
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法
    }
}