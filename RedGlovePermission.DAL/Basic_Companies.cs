using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
    /// <summary>
    /// 公司管理資料操作類別
    /// </summary>
    public class Basic_Companies : IBasic_Companies
    {
        public Basic_Companies()
		{}
		#region  成员方法

        /// <summary>
        /// 判斷客戶是否存在
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public bool Exists(string Company)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Basic_Company");
            strSql.Append(" where Company=@Company ");
            SqlParameter[] parameters = {
					new SqlParameter("@Company", SqlDbType.Char,10)};
            parameters[0].Value = Company;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一家公司
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        public bool CreateCompany(RedGlovePermission.Model.Basic_Companies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Basic_Company(");
            strSql.Append("Company,Track,Description,CREATOR,CREATE_DATE)");
            strSql.Append(" values (");
            strSql.Append("@Company,@Track,@Description,@Creator,@Create_Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@Company", SqlDbType.Char,10),
                    new SqlParameter("@Track", SqlDbType.Char,2),
					new SqlParameter("@Description", SqlDbType.Char,10),
                    new SqlParameter("@Creator", SqlDbType.Char,10),
                    new SqlParameter("@Create_Date", SqlDbType.Char,8)};
            parameters[0].Value = model.Company;
            parameters[1].Value = model.Track;
            parameters[2].Value = model.Description;
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
        /// 更新一家公司資料
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        public bool UpdateCompany(RedGlovePermission.Model.Basic_Companies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Basic_Company set ");
            strSql.Append("Track=@Track,");
            strSql.Append("Description=@Description,");
            strSql.Append("MODIFIER=@Modifier,");
            strSql.Append("MODI_DATE=@Modi_Date");
            strSql.Append(" where Company=@Company ");
            SqlParameter[] parameters = {
					new SqlParameter("@Company", SqlDbType.Char,10),
                    new SqlParameter("@Track", SqlDbType.Char,2),
					new SqlParameter("@Description", SqlDbType.Char,10),
					new SqlParameter("@Modifier", SqlDbType.Char,10),
					new SqlParameter("@Modi_Date", SqlDbType.Char,8)};
            parameters[0].Value = model.Company;
            parameters[1].Value = model.Track;
            parameters[2].Value = model.Description;
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
        /// 删除一家公司資料
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public int DeleteCompany(string Company)
        {
            int ret = 0;
            //string strSql1 = "Select RoleID from RGP_Roles where RoleGroupID=@GroupID"; //查看此客戶下是否存在銷貨單
            //string strSql2 = "Select UserID from Users where UserGroup=@GroupID";        //查看此客戶下是否存在銷貨退回單
            string strSql3 = "delete Basic_Company where Company=@Company";

            SqlParameter[] parameters = {
					new SqlParameter("@Company", SqlDbType.Char,10)};
            parameters[0].Value = Company;

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
        /// 得到一家公司資料
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Basic_Companies GetCompanyModel(string Company)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Company,Description,Track from Basic_Company ");
            strSql.Append(" where Company=@Company ");
            SqlParameter[] parameters = {
					new SqlParameter("@Company", SqlDbType.Char,10)};
            parameters[0].Value = Company;

            RedGlovePermission.Model.Basic_Companies model = new RedGlovePermission.Model.Basic_Companies();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["MA001"].ToString() != "")
                //{
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                //}
                model.Track = ds.Tables[0].Rows[0]["Track"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得公司資料列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetCompanyList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM Basic_Company ");

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