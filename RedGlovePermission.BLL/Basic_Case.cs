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
    /// 商業邏輯類別Basic_Case 的摘要說明。
    /// </summary>
    /// 
    public class Basic_Case
    {
        private readonly IBasic_Case dal = DataAccess.CreateCase();

        public Basic_Case()
        {}

        /// <summary>
        /// 判斷案例是否存在
        /// </summary>
        /// <param name="CaseNo">案例編號</param>
        /// <returns></returns>
        public bool Exists(string CaseNo)
        {
            return dal.Exists(CaseNo);
        }

        /// <summary>
        /// 增加一個案例
        /// </summary>
        /// <param name="model">案例類別</param>
        /// <returns></returns>
        public bool CreateCase(RedGlovePermission.Model.Basic_Case model)
        {
            return dal.CreateCase(model);
        }

        /// <summary>
        /// 更新一個案例
        /// </summary>
        /// <param name="model">案例類別</param>
        /// <returns></returns>
        public bool UpdateCase(RedGlovePermission.Model.Basic_Case model)
        {
            return dal.UpdateCase(model);
        }

        /// <summary>
        /// 删除一個案例
        /// </summary>
        /// <param name="CaseNo">案例編號</param>
        /// <returns></returns>
        public int DeleteCase(string Case)
        {
            return dal.DeleteCase(Case);
        }

        /// <summary>
        /// 得到一個案例資料
        /// </summary>
        /// <param name="CaseNo">案例編號</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Basic_Case GetCCaseModel(string Case)
        {
            return dal.GetCaseModel(Case);
        }

        /// <summary>
        /// 取得案例資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        public DataSet GetCaseList(string strWhere, string strOrder)
        {
            return dal.GetCaseList(strWhere, strOrder);
        }
    }
}