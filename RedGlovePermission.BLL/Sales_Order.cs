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
    /// 商業邏輯類別Sales_order 的摘要說明。
    /// </summary>
    /// 
    public class Sales_Order
    {
        private readonly ISales_Order dal = DataAccess.CreateOrder();

        public Sales_Order()
        {}

        #region 角色管理
        /// <summary>
        /// 判斷訂單是否存在
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public bool OrderExists(string OrderID)
        {
            return dal.OrderExists(OrderID);
        }

        /// <summary>
        /// 訂單總額重算
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public int OrderTotal(string OrderID)
        {
            return dal.OrderTotal(OrderID);
        }

        /// <summary>
        /// 取得新訂單編號
        /// </summary>
        /// <param name="TrackNo">訂單編號字軌</param>
        /// <returns></returns>
        public string GetNewOrderID(string Track)
        {
            return dal.GetNewOrderID(Track);
        }

        /// <summary>
        /// 取得訂單細項編號
        /// </summary>
        /// <param name="TrackNo">訂單編號</param>
        /// <returns></returns>
        public string GetNewOrderSeq(string OID)
        {
            return dal.GetNewOrderSeq(OID);
        }

        /// <summary>
        /// 得到一筆訂單資料
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Sales_Order GetOrderModel(string OrderID)
        {
            return dal.GetOrderModel(OrderID);
        }

        #endregion
    }
}