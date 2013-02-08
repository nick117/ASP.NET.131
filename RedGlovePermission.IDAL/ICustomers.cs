using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface ICustomers
    {
        /// <summary>
        /// 判斷客戶是否存在
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        bool Exists(string CustomerID);

        /// <summary>
        /// 增加一個客戶
        /// </summary>
        /// <param name="model">客戶類別</param>
        /// <returns></returns>
        bool CreateCustomer(RedGlovePermission.Model.Customers model);

        /// <summary>
        /// 修改一個客戶
        /// </summary>
        /// <param name="model">客戶類別</param>
        /// <returns></returns>
        bool UpdateCustomer(RedGlovePermission.Model.Customers model);

        /// <summary>
        /// 删除一個客戶
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        int DeleteCustomer(string CustomerID);

        /// <summary>
        /// 得到一個客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        RedGlovePermission.Model.Customers GetCustomerModel(string CustomerID);

        /// <summary>
        /// 得到客戶資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        DataSet GetCustomerList(string strWhere, string strOrder);

        /// <summary>
        /// 取回第一家客戶編號
        /// </summary>
        /// <returns></returns>
        String GetFirst();

        /// <summary>
        /// 取回最後一家客戶編號
        /// </summary>
        /// <returns></returns>
        String GetLast();
    }
}
