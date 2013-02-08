using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
	/// <summary>
	/// 客戶管理資料操作類別
	/// </summary>
	public class Customers : ICustomers
	{
		public Customers()
		{}
		#region  成员方法

		/// <summary>
		/// 判斷客戶是否存在
		/// </summary>
		/// <param name="CustomerID">客戶ID</param>
		/// <returns></returns>
		public bool Exists(string CustomerID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from COPMA");
			strSql.Append(" where MA001=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Char,10)};
			parameters[0].Value = CustomerID;

			return SqlServerHelper.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 增加一個客戶
		/// </summary>
		/// <param name="model">客戶類別</param>
		/// <returns></returns>
		public bool CreateCustomer(RedGlovePermission.Model.Customers model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into COPMA(");
			strSql.Append("MA001,MA002,MA027,CREATOR,CREATE_DATE)");
			strSql.Append(" values (");
			strSql.Append("@CustomerID,@CustomerAbbrev,@Address,@Creator,@Create_Date)");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Char,10),
					new SqlParameter("@CustomerAbbrev", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.Char,72),
					new SqlParameter("@Creator", SqlDbType.Char,10),
					new SqlParameter("@Create_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.CustomerAbbrev;
            parameters[2].Value = model.Address;
			parameters[3].Value = model.Creator;
			parameters[4].Value = model.Create_Date;

			if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一筆客戶資料
		/// </summary>
		/// <param name="model">客戶類別</param>
		/// <returns></returns>
		public bool UpdateCustomer(RedGlovePermission.Model.Customers model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update COPMA set ");
			strSql.Append("MA002=@CustomerAbbrev,");
			strSql.Append("MA027=@Address,");
			strSql.Append("MODIFIER=@Modifier,");
			strSql.Append("MODI_DATE=@Modi_Date");
			strSql.Append(" where MA001=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Char,10),
					new SqlParameter("@CustomerAbbrev", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.Char,72),
					new SqlParameter("@Modifier", SqlDbType.Char,10),
					new SqlParameter("@Modi_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.CustomerAbbrev;
            parameters[2].Value = model.Address;
			parameters[3].Value = model.Modifier;
			parameters[4].Value = model.Modi_Date;

			if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一筆客戶資料
		/// </summary>
		/// <param name="CustomerID">客戶ID</param>
		/// <returns></returns>
		public int DeleteCustomer(string CustomerID)
		{
			int ret = 0;
			//string strSql1 = "Select RoleID from RGP_Roles where RoleGroupID=@GroupID"; //查看此客戶下是否存在銷貨單
			//string strSql2 = "Select UserID from Users where UserGroup=@GroupID";        //查看此客戶下是否存在銷貨退回單
			string strSql3 = "delete COPMA where MA001=@CustomerID";

			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Char,10)};
			parameters[0].Value = CustomerID;

			//if (!SqlServerHelper.Exists(strSql1.ToString(), parameters))
			//{
			//    if (!SqlServerHelper.Exists(strSql2.ToString(), parameters))
			//    {
					if (SqlServerHelper.ExecuteSql(strSql3.ToString(), parameters) >= 1)
					{
						ret = 1;//删除成功
					}
			//    }
			//    else
			//    {
			//        ret = 2;//有銷貨退回單，不能删除
			//    }
			//}
			//else
			//{
			//    ret = 3;//有銷貨單，不能删除
			//}

			return ret;
		}

		/// <summary>
		/// 得到一筆客戶資料
		/// </summary>
		/// <param name="CustomerID">客戶ID</param>
		/// <returns></returns>
		public RedGlovePermission.Model.Customers GetCustomerModel(string CustomerID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 MA001,MA002,MA027 from COPMA ");
			strSql.Append(" where MA001=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.Char,10)};
			parameters[0].Value = CustomerID;

			RedGlovePermission.Model.Customers model = new RedGlovePermission.Model.Customers();
			DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				//if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
				//{
					model.CustomerID = ds.Tables[0].Rows[0]["MA001"].ToString();
				//}
				model.CustomerAbbrev = ds.Tables[0].Rows[0]["MA002"].ToString();
				model.Address = ds.Tables[0].Rows[0]["MA027"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 取得客戶資料列表
		/// </summary>
		/// <param name="strWhere">Where条件</param>
		/// <param name="strOrder">排序条件</param>
		/// <returns></returns>
		public DataSet GetCustomerList(string strWhere, string strOrder)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM COPMA ");

			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}

			if (strOrder.Trim() != "")
			{
				strSql.Append(" " + strOrder);
			}

			return SqlServerHelper.Query(strSql.ToString());
		}

        /// <summary>
        /// 得到第一筆客戶編號
        /// </summary>
        /// <returns></returns>
        public string GetFirst()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MA001 from COPMA order by MA001");
            DataSet ds = SqlServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["MA001"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 得到最後一筆客戶編號
        /// </summary>
        /// <returns></returns>
        public string GetLast()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MA001 from COPMA order by MA001 Desc");
            DataSet ds = SqlServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["MA001"].ToString();
            }
            else
            {
                return "";
            }
        }

		#endregion  成员方法
	}
}