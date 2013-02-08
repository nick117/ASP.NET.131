using System;
using System.Data;
using System.Collections.Generic;

using RedGlovePermission.Lib;
using RedGlovePermission.Model;
using RedGlovePermission.DALFactory;
using RedGlovePermission.IDAL;

namespace RedGlovePermission.BLL
{
    /// <summary>
    /// 商業邏輯類別Basic_Companies 的摘要說明。
    /// </summary>
    /// 
    public class Basic_Companies
    {
        private readonly IBasic_Companies dal = DataAccess.CreateCompanies();

        public Basic_Companies()
        {}

        /// <summary>
        /// 判斷公司是否存在
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public bool Exists(string Company)
        {
            return dal.Exists(Company);
        }

        /// <summary>
        /// 增加一家公司
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        public bool CreateCompany(RedGlovePermission.Model.Basic_Companies model)
        {
            return dal.CreateCompany(model);
        }

        /// <summary>
        /// 更新一家公司
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        public bool UpdateCompany(RedGlovePermission.Model.Basic_Companies model)
        {
            return dal.UpdateCompany(model);
        }

        /// <summary>
        /// 删除一家公司
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public int DeleteCompany(string Company)
        {
            return dal.DeleteCompany(Company);
        }

        /// <summary>
        /// 得到一家公司資料
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Basic_Companies GetCCompanyModel(string Company)
        {
            return dal.GetCompanyModel(Company);
        }

        /// <summary>
        /// 取得公司資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        public DataSet GetCompanyList(string strWhere, string strOrder)
        {
            return dal.GetCompanyList(strWhere, strOrder);
        }
    }
}