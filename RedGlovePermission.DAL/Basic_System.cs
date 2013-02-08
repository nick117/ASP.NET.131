using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
	/// <summary>
	/// 代碼管理資料操作類別
	/// </summary>
	public class Basic_System : IBasic_System
	{
		public Basic_System()
		{}
		#region  成员方法

		/// <summary>
		/// 判斷代碼是否存在
		/// </summary>
		/// <param name="Code">代碼</param>
		/// <returns></returns>
		public bool Exists(string Code)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Basic_System");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.Char,10)};
			parameters[0].Value = Code;

			return SqlServerHelper.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 增加一個代碼
		/// </summary>
		/// <param name="model">代碼類別</param>
		/// <returns></returns>
		public bool CreateCode(RedGlovePermission.Model.Basic_System model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into Basic_System(");
			strSql.Append("Code,Items,CREATOR,CREATE_DATE)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Items,@Creator,@Create_Date)");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.Char,10),
					new SqlParameter("@Items", SqlDbType.Char,200),
					new SqlParameter("@Creator", SqlDbType.Char,10),
					new SqlParameter("@Create_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Items;
			parameters[2].Value = model.Creator;
			parameters[3].Value = model.Create_Date;

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
		/// 更新一個代碼資料
		/// </summary>
		/// <param name="model">代碼類別</param>
		/// <returns></returns>
		public bool UpdateCode(RedGlovePermission.Model.Basic_System model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Basic_System set ");
			strSql.Append("Items=@Items,");
			strSql.Append("MODIFIER=@Modifier,");
			strSql.Append("MODI_DATE=@Modi_Date");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.Char,10),
					new SqlParameter("@Items", SqlDbType.Char,200),
					new SqlParameter("@Modifier", SqlDbType.Char,10),
					new SqlParameter("@Modi_Date", SqlDbType.Char,8)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Items;
			parameters[2].Value = model.Modifier;
			parameters[3].Value = model.Modi_Date;

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
		/// 删除一個代碼資料
		/// </summary>
		/// <param name="Code">代碼</param>
		/// <returns></returns>
		public int DeleteCode(string Code)
		{
			int ret = 0;
			//string strSql1 = "Select RoleID from RGP_Roles where RoleGroupID=@GroupID"; //查看此客戶下是否存在銷貨單
			//string strSql2 = "Select UserID from Users where UserGroup=@GroupID";        //查看此客戶下是否存在銷貨退回單
			string strSql3 = "delete Basic_System where Code=@Code";

			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.Char,10)};
			parameters[0].Value = Code;

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
		/// 得到一個代碼資料
		/// </summary>
		/// <param name="Code">代碼</param>
		/// <returns></returns>
		public RedGlovePermission.Model.Basic_System GetCodeModel(string Code)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select top 1 Code,Items from Basic_System ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.Char,10)};
			parameters[0].Value = Code;

			RedGlovePermission.Model.Basic_System model = new RedGlovePermission.Model.Basic_System();
			DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				//if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
				//{
				model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
				//}
				model.Items = ds.Tables[0].Rows[0]["Items"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 取得代碼資料列表
		/// </summary>
		/// <param name="strWhere">Where条件</param>
		/// <param name="strOrder">排序条件</param>
		/// <returns></returns>
		public DataSet GetCodeList(string strWhere, string strOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * FROM Basic_System ");

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