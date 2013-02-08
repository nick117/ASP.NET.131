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
    public class Sales_Order : ISales_Order
    {
        public Sales_Order()
		{}
		#region  成员方法

        /// <summary>
        /// 判斷訂單是否存在
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public bool OrderExists(string OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sales_Order");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Char,13)};
            parameters[0].Value = OrderID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 訂單總額重算
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public int OrderTotal(string OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_Order ");
            strSql.Append("set Total = (select sum(Qty*UnitPrice*Discount) from Sales_order_dtl where OrderID=@OrderID group by OrderID) ");
            strSql.Append(", Tax = (select sum(Qty*UnitPrice*Discount) from Sales_order_dtl where OrderID=@OrderID group by OrderID) * TaxRate ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Char,13)};
            parameters[0].Value = OrderID;

            return SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 取得一個新訂單編號
        /// </summary>
        /// <returns></returns>
        public string GetNewOrderID(string Track)
        {
            string NewID;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 OrderID from Sales_Order");
            strSql.Append(" where OrderID like @OrderID ");
            strSql.Append(" order by OrderID Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Char,11)};
            parameters[0].Value = Track+"%";

            RedGlovePermission.Model.Sales_Order model = new RedGlovePermission.Model.Sales_Order();
			DataSet ds=SqlServerHelper.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                NewID = (int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString().Substring(10, 3)) + 1001).ToString();
                NewID = Track + NewID.Substring(NewID.Length - 3);
            }
            else
            {
                NewID = Track + "001";
            }
            return NewID;
        }

        /// <summary>
        /// 取得訂單細項編號
        /// </summary>
        /// <param name="OID">訂單編號</param>
        /// <returns></returns>
        public string GetNewOrderSeq(string OID)
        {
            string NewSEQ;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Seq from Sales_Order_DTL");
            strSql.Append(" where OrderID = @OrderID ");
            strSql.Append(" order by Seq Desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Char,13)};
            parameters[0].Value = OID;

            RedGlovePermission.Model.Sales_Order model = new RedGlovePermission.Model.Sales_Order();
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
        /// 得到一筆訂單資料
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Sales_Order GetOrderModel(string OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from Sales_Order ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Char,13)};
            parameters[0].Value = OrderID;

            RedGlovePermission.Model.Sales_Order model = new RedGlovePermission.Model.Sales_Order();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
                //{
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                //}
                model.Order_Date = ds.Tables[0].Rows[0]["Order_Date"].ToString();
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                model.MA001 = ds.Tables[0].Rows[0]["MA001"].ToString();
                model.CaseNo = ds.Tables[0].Rows[0]["CaseNo"].ToString();
                model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                model.TaxRate = float.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
                model.Amount = float.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                model.Tax = float.Parse(ds.Tables[0].Rows[0]["Tax"].ToString());
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