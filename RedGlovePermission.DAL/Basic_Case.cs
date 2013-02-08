using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
	/// <summary>
	/// 案件管理資料操作類別
	/// </summary>
	public class Basic_Case : IBasic_Case
	{
		public Basic_Case()
		{}
		#region  成员方法

		/// <summary>
		/// 判斷案件是否存在
		/// </summary>
		/// <param name="CaseNo">案件編號</param>
		/// <returns></returns>
		public bool Exists(string CaseNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Basic_Case");
			strSql.Append(" where CaseNo=@CaseNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@CaseNo", SqlDbType.Char,20)};
			parameters[0].Value = CaseNo;

			return SqlServerHelper.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 增加一個案件
		/// </summary>
		/// <param name="model">案件類別</param>
		/// <returns></returns>
		public bool CreateCase(RedGlovePermission.Model.Basic_Case model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into Basic_Case(");
			strSql.Append("CaseNo,CaseDescription,Department,MA001,CREATOR,CREATE_DATE)");
			strSql.Append(" values (");
			strSql.Append("@CaseNo,@CaseDescription,@Department,@MA001,@Creator,@Create_Date)");
			SqlParameter[] parameters = {
					new SqlParameter("@CaseNo", SqlDbType.Char,20),
					new SqlParameter("@CaseDescription", SqlDbType.Char,50),
					new SqlParameter("@Department", SqlDbType.Char,20),
					new SqlParameter("@MA001", SqlDbType.Char,10),
					new SqlParameter("@Creator", SqlDbType.Char,10),
					new SqlParameter("@Create_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.CaseNo;
			parameters[1].Value = model.CaseDescription;
			parameters[2].Value = model.Department;
			parameters[3].Value = model.MA001;
			parameters[4].Value = model.Creator;
			parameters[5].Value = model.Create_Date;

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
		/// 更新一個案件資料
		/// </summary>
		/// <param name="model">案件類別</param>
		/// <returns></returns>
		public bool UpdateCase(RedGlovePermission.Model.Basic_Case model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Basic_Case set ");
			strSql.Append("CaseDescription=@CaseDescription,");
			strSql.Append("Department=@Department,");
			strSql.Append("MA001=@MA001,");
			strSql.Append("MODIFIER=@Modifier,");
			strSql.Append("MODI_DATE=@Modi_Date");
			strSql.Append(" where CaseNo=@CaseNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@CaseNo", SqlDbType.Char,20),
					new SqlParameter("@CaseDescription", SqlDbType.Char,50),
					new SqlParameter("@Department", SqlDbType.Char,20),
					new SqlParameter("@MA001", SqlDbType.Char,10),
					new SqlParameter("@Modifier", SqlDbType.Char,10),
					new SqlParameter("@Modi_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.CaseNo;
			parameters[1].Value = model.CaseDescription;
			parameters[2].Value = model.Department;
			parameters[3].Value = model.MA001;
			parameters[4].Value = model.Modifier;
			parameters[5].Value = model.Modi_Date;

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
		/// 删除一個案件資料
		/// </summary>
		/// <param name="CaseNo">案件編號</param>
		/// <returns></returns>
		public int DeleteCase(string CaseNo)
		{
			int ret = 0;
			//string strSql1 = "Select RoleID from RGP_Roles where RoleGroupID=@GroupID"; //查看此客戶下是否存在銷貨單
			//string strSql2 = "Select UserID from Users where UserGroup=@GroupID";        //查看此客戶下是否存在銷貨退回單
			string strSql3 = "delete Basic_Case where CaseNo=@CaseNo";

			SqlParameter[] parameters = {
					new SqlParameter("@CaseNO", SqlDbType.Char,20)};
			parameters[0].Value = CaseNo;

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
		/// 得到一個案件資料
		/// </summary>
		/// <param name="CaseNo">案件編號</param>
		/// <returns></returns>
		public RedGlovePermission.Model.Basic_Case GetCaseModel(string CaseNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 CcaseNo,CaseDescription,Department,MA001 from Basic_Case ");
			strSql.Append(" where CaseNo=@CaseNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@CaseNo", SqlDbType.Char,20)};
			parameters[0].Value = CaseNo;

			RedGlovePermission.Model.Basic_Case model = new RedGlovePermission.Model.Basic_Case();
			DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				//if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
				//{
				model.CaseNo = ds.Tables[0].Rows[0]["CaseNo"].ToString();
				//}
				model.CaseDescription = ds.Tables[0].Rows[0]["CaseDescription"].ToString();
				model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
				model.MA001 = ds.Tables[0].Rows[0]["MA001"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 取得案件資料列表
		/// </summary>
		/// <param name="strWhere">Where条件</param>
		/// <param name="strOrder">排序条件</param>
		/// <returns></returns>
		public DataSet GetCaseList(string strWhere, string strOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select B.*,C.MA002,C.MA027 FROM Basic_Case B left join COPMA C on B.MA001=C.MA001");

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

		#endregion  成员方法
	}
}