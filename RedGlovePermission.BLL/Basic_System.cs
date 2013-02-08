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
    /// 商業邏輯類別Basic_System 的摘要說明。
    /// </summary>
    /// 
    public class Basic_System
    {
        private readonly IBasic_System dal = DataAccess.CreateCode();

        public Basic_System()
        {}

        /// <summary>
        /// 判斷代碼是否存在
        /// </summary>
        /// <param name="Code">代碼</param>
        /// <returns></returns>
        public bool Exists(string Code)
        {
            return dal.Exists(Code);
        }

        /// <summary>
        /// 增加一個代碼
        /// </summary>
        /// <param name="model">代碼類別</param>
        /// <returns></returns>
        public bool CreateCode(RedGlovePermission.Model.Basic_System model)
        {
            return dal.CreateCode(model);
        }

        /// <summary>
        /// 更新一個代碼
        /// </summary>
        /// <param name="model">代碼類別</param>
        /// <returns></returns>
        public bool UpdateCode(RedGlovePermission.Model.Basic_System model)
        {
            return dal.UpdateCode(model);
        }

        /// <summary>
        /// 删除一個代碼
        /// </summary>
        /// <param name="Code">代碼</param>
        /// <returns></returns>
        public int DeleteCode(string Code)
        {
            return dal.DeleteCode(Code);
        }

        /// <summary>
        /// 得到一個代碼資料
        /// </summary>
        /// <param name="Code">代碼</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Basic_System GetCodeModel(string Code)
        {
            return dal.GetCodeModel(Code);
        }

        /// <summary>
        /// 取得代碼資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        public DataSet GetCodeList(string strWhere, string strOrder)
        {
            return dal.GetCodeList(strWhere, strOrder);
        }
    }
}