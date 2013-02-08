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
    /// 商業邏輯類別Customers 的摘要說明。
    /// </summary>
    /// 
    public class Customers
    {
        private readonly ICustomers dal = DataAccess.CreateCustomers();

        public Customers()
        {}

        /// <summary>
        /// 判斷客戶是否存在
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public bool Exists(string CustomerID)
        {
            return dal.Exists(CustomerID);
        }

        /// <summary>
        /// 增加一個客戶
        /// </summary>
        /// <param name="model">客戶類別</param>
        /// <returns></returns>
        public bool CreateCustomer(RedGlovePermission.Model.Customers model)
        {
            return dal.CreateCustomer(model);
        }

        /// <summary>
        /// 更新一個客戶
        /// </summary>
        /// <param name="model">客戶類別</param>
        /// <returns></returns>
        public bool UpdateCustomer(RedGlovePermission.Model.Customers model)
        {
            return dal.UpdateCustomer(model);
        }

        /// <summary>
        /// 删除一個客戶
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public int DeleteCustomer(string CustomerID)
        {
            return dal.DeleteCustomer(CustomerID);
        }

        /// <summary>
        /// 得到一筆客戶資料
        /// </summary>
        /// <param name="CustomerID">客戶ID</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Customers GetCustomerModel(string CustomerID)
        {
            return dal.GetCustomerModel(CustomerID);
        }

        /// <summary>
        /// 取得客戶資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        public DataSet GetCustomerList(string strWhere, string strOrder)
        {
            return dal.GetCustomerList(strWhere, strOrder);
        }

        /// <summary>
        /// 得到第一筆客戶編號
        /// </summary>
        /// <returns></returns>
        public string GetFirst()
        {
            return dal.GetFirst();
        }

        /// <summary>
        /// 得到最後一筆客戶編號
        /// </summary>
        /// <returns></returns>
        public string GetLast()
        {
            return dal.GetLast();
        }
    }
}