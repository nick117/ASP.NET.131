using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface ISales_Return
    {
        /// <summary>
        /// 判斷銷貨退回單是否存在
        /// </summary>
        /// <param name="OrderID">銷貨退回編號</param>
        /// <returns></returns>
        bool ReturnExists(string ReturnID);

        /// <summary>
        ///  銷貨退回單總額重算
        /// </summary>
        /// <param name="ReturnID">銷貨退回單編號</param>
        /// <returns></returns>
        int ReturnTotal(string ReturnID);

        /// <summary>
        /// 得到一筆銷貨退回單資料
        /// </summary>
        /// <param name="ReturnID">銷貨退回編號</param>
        /// <returns></returns>
        RedGlovePermission.Model.Sales_Return GetReturnModel(string ReturnID);

        /// <summary>
        /// 取得一個新銷貨退回單編號
        /// </summary>
        /// <param name="Track">銷貨退回單字軌</param>
        /// <returns></returns>
        string GetNewReturnID(string Track);

        /// <summary>
        /// 取得一個新銷貨退回單明細編號
        /// </summary>
        /// <param name="OID">銷貨退回單號碼</param>
        /// <returns></returns>
        string GetNewReturnSeq(string OID);
    }
}
