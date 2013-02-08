using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface ISales_Order
    {
        /// <summary>
        /// 判斷訂單是否存在
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        bool OrderExists(string OrderID);

        /// <summary>
        ///  訂單總額重算
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        int OrderTotal(string OrderID);

        /// <summary>
        /// 得到一筆訂單資料
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        RedGlovePermission.Model.Sales_Order GetOrderModel(string OrderID);

        /// <summary>
        /// 取得一個新訂單編號
        /// </summary>
        /// <param name="Track">訂單字軌</param>
        /// <returns></returns>
        string GetNewOrderID(string Track);

        /// <summary>
        /// 取得一個新訂單明細編號
        /// </summary>
        /// <param name="OID">訂單號碼</param>
        /// <returns></returns>
        string GetNewOrderSeq(string OID);
    }
}
