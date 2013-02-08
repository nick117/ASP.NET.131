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
    /// 商業邏輯類別Return_order 的摘要說明。
    /// </summary>
    /// 
    public class Sales_Return
    {
        private readonly ISales_Return dal = DataAccess.CreateReturn();

        public Sales_Return()
        {}

        #region 角色管理
        /// <summary>
        /// 判斷銷貨退回單是否存在
        /// </summary>
        /// <param name="ReturnID"> 判斷銷貨單編號</param>
        /// <returns></returns>
        public bool ReturnExists(string ReturnID)
        {
            return dal.ReturnExists(ReturnID);
        }

        /// <summary>
        /// 銷貨退回單總額重算
        /// </summary>
        /// <param name="ReturnID">銷貨退回單編號</param>
        /// <returns></returns>
        public int ReturnTotal(string ReturnID)
        {
            return dal.ReturnTotal(ReturnID);
        }

        /// <summary>
        /// 取得新銷貨退回單編號
        /// </summary>
        /// <param name="TrackNo">銷貨退回單編號字軌</param>
        /// <returns></returns>
        public string GetNewReturnID(string Track)
        {
            return dal.GetNewReturnID(Track);
        }

        /// <summary>
        /// 取得銷貨退回單細項編號
        /// </summary>
        /// <param name="TrackNo">銷貨退回單編號</param>
        /// <returns></returns>
        public string GetNewReturnSeq(string OID)
        {
            return dal.GetNewReturnSeq(OID);
        }

        /// <summary>
        /// 得到一筆銷貨退回單資料
        /// </summary>
        /// <param name="OrderID">銷貨退回單編號</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Sales_Return GetReturnModel(string ReturnID)
        {
            return dal.GetReturnModel(ReturnID);
        }

        #endregion
    }
}