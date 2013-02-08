using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface IBasic_Companies
    {
        /// <summary>
        /// 判斷公司是否存在
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        bool Exists(string Company);

        /// <summary>
        /// 增加一家公司
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        bool CreateCompany(RedGlovePermission.Model.Basic_Companies model);

        /// <summary>
        /// 修改一家公司
        /// </summary>
        /// <param name="model">公司類別</param>
        /// <returns></returns>
        bool UpdateCompany(RedGlovePermission.Model.Basic_Companies model);

        /// <summary>
        /// 删除一家公司
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        int DeleteCompany(string Company);

        /// <summary>
        /// 得到一家公司資料
        /// </summary>
        /// <param name="Company">公司名</param>
        /// <returns></returns>
        RedGlovePermission.Model.Basic_Companies GetCompanyModel(string Company);

        /// <summary>
        /// 得到公司資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        DataSet GetCompanyList(string strWhere, string strOrder);

    }
}
