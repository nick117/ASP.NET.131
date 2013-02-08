using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface IBasic_Case
    {
        /// <summary>
        /// 判斷案件是否存在
        /// </summary>
        /// <param name="CaseNo">案件編號</param>
        /// <returns></returns>
        bool Exists(string CaseNo);

        /// <summary>
        /// 增加一個案件
        /// </summary>
        /// <param name="model">案件類別</param>
        /// <returns></returns>
        bool CreateCase(RedGlovePermission.Model.Basic_Case model);

        /// <summary>
        /// 修改一個案件
        /// </summary>
        /// <param name="model">案件類別</param>
        /// <returns></returns>
        bool UpdateCase(RedGlovePermission.Model.Basic_Case model);

        /// <summary>
        /// 删除一個案件
        /// </summary>
        /// <param name="CaseNo">案件編號</param>
        /// <returns></returns>
        int DeleteCase(string CaseNo);

        /// <summary>
        /// 得到一個案件資料
        /// </summary>
        /// <param name="CaseNo">案件編號</param>
        /// <returns></returns>
        RedGlovePermission.Model.Basic_Case GetCaseModel(string CaseNo);

        /// <summary>
        /// 得到案件資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        DataSet GetCaseList(string strWhere, string strOrder);
    }
}
