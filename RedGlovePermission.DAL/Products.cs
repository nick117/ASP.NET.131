using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using RedGlovePermission.DBUtility;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.SQLServerDAL
{
    /// <summary>
    /// 產品管理資料操作類別
    /// </summary>
    public class Products : IProducts
    {
        public Products()
        { }
        #region  成员方法

        /// <summary>
        /// 判斷產品是否存在
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public bool Exists(string ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from INVMB");
            strSql.Append(" where MB001=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Char,20)};
            parameters[0].Value = ProductID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一個產品
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        public bool CreateProduct(RedGlovePermission.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into INVMB(");
            strSql.Append("MB001,MB002,MB003,MB004,CREATOR,CREATE_DATE)");
            strSql.Append(" values (");
            strSql.Append("@ProductID,@ProductName,@ProductSpec,@StorageUnit,@Creator,@Create_Date)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Char,20),
					new SqlParameter("@ProductName", SqlDbType.Char,30),
                    new SqlParameter("@ProductSpec", SqlDbType.Char,30),
                    new SqlParameter("@StorageUnit", SqlDbType.Char,4),
                    new SqlParameter("@Creator", SqlDbType.Char,10),
                    new SqlParameter("@Create_Date", SqlDbType.Char,8)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.ProductSpec;
            parameters[3].Value = model.StorageUnit;
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
        /// 更新一筆產品資料
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        public bool UpdateProduct(RedGlovePermission.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update INVMB set ");
            strSql.Append("MB002=@ProductName,");
            strSql.Append("MB003=@ProductSpec,");
            strSql.Append("MB004=@StorageUnit,");
            strSql.Append("MODIFIER=@Modifier,");
            strSql.Append("MODI_DATE=@Modi_Date");
            strSql.Append(" where MB001=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Char,20),
					new SqlParameter("@ProductName", SqlDbType.Char,30),
                    new SqlParameter("@ProductSpec", SqlDbType.Char,30),
                    new SqlParameter("@StorageUnit", SqlDbType.Char,4),
					new SqlParameter("@Modifier", SqlDbType.Char,10),
					new SqlParameter("@Modi_Date", SqlDbType.Char,8)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.ProductSpec;
            parameters[3].Value = model.StorageUnit;
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
        /// 删除一筆產品資料
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        public int DeleteProduct(string ProductID)
        {
            int ret = 0;
            //string strSql1 = "Select RoleID from RGP_Roles where RoleGroupID=@GroupID"; //查看此產品是否存在銷貨單
            //string strSql2 = "Select UserID from Users where UserGroup=@GroupID";        //查看此產品是否存在銷貨退回單
            string strSql3 = "delete INVMB where MB001=@ProductID";

            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Char,20)};
            parameters[0].Value = ProductID;

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
        /// 得到一筆產品資料
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Products GetProductModel(string ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 MB001,MB002,MB003,MB004 from INVMB ");
            strSql.Append(" where MB001=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Char,20)};
            parameters[0].Value = ProductID;

            RedGlovePermission.Model.Products model = new RedGlovePermission.Model.Products();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                //{
                    model.ProductID = ds.Tables[0].Rows[0]["MB001"].ToString();
                //}
                model.ProductName = ds.Tables[0].Rows[0]["MB002"].ToString();
                model.ProductSpec = ds.Tables[0].Rows[0]["MB003"].ToString();
                model.StorageUnit = ds.Tables[0].Rows[0]["MB004"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得產品資料列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetProductList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM INVMB ");

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