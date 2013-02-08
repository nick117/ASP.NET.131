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
    /// 商業邏輯類別Products 的摘要說明。
    /// </summary>
    /// 
    public class Products
    {
        private readonly IProducts dal = DataAccess.CreateProducts();

        public Products()
        { }

        /// <summary>
        /// 判斷產品是否存在
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        public bool Exists(string ProductID)
        {
            return dal.Exists(ProductID);
        }

        /// <summary>
        /// 增加一個產品
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        public bool CreateProduct(RedGlovePermission.Model.Products model)
        {
            return dal.CreateProduct(model);
        }

        /// <summary>
        /// 更新一個產品
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        public bool UpdateProduct(RedGlovePermission.Model.Products model)
        {
            return dal.UpdateProduct(model);
        }

        /// <summary>
        /// 删除一個產品
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        public int DeleteProduct(string ProductID)
        {
            return dal.DeleteProduct(ProductID);
        }

        /// <summary>
        /// 得到一筆產品資料
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        public RedGlovePermission.Model.Products GetProductModel(string ProductID)
        {
            return dal.GetProductModel(ProductID);
        }

        /// <summary>
        /// 取得產品資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        public DataSet GetProductList(string strWhere, string strOrder)
        {
            return dal.GetProductList(strWhere, strOrder);
        }
    }
}