using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface IBasic_System
    {
        /// <summary>
        /// 判斷代碼是否存在
        /// </summary>
        /// <param name="Code">代碼</param>
        /// <returns></returns>
        bool Exists(string Code);

        /// <summary>
        /// 增加一個代碼
        /// </summary>
        /// <param name="model">代碼類別</param>
        /// <returns></returns>
        bool CreateCode(RedGlovePermission.Model.Basic_System model);

        /// <summary>
        /// 修改一個代碼
        /// </summary>
        /// <param name="model">代碼類別</param>
        /// <returns></returns>
        bool UpdateCode(RedGlovePermission.Model.Basic_System model);

        /// <summary>
        /// 删除一個代碼
        /// </summary>
        /// <param name="Code">代碼</param>
        /// <returns></returns>
        int DeleteCode(string Code);

        /// <summary>
        /// 得到一個代碼資料
        /// </summary>
        /// <param name="Company">代碼</param>
        /// <returns></returns>
        RedGlovePermission.Model.Basic_System GetCodeModel(string Code);

        /// <summary>
        /// 得到代碼資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        DataSet GetCodeList(string strWhere, string strOrder);
    }
}
