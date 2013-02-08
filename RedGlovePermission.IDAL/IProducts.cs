using System;
using System.Data;

namespace RedGlovePermission.IDAL
{
    public interface IProducts
    {
        /// <summary>
        /// 判斷產品是否存在
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        bool Exists(string ProductID);

        /// <summary>
        /// 增加一個產品
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        bool CreateProduct(RedGlovePermission.Model.Products model);

        /// <summary>
        /// 修改一個產品
        /// </summary>
        /// <param name="model">產品類別</param>
        /// <returns></returns>
        bool UpdateProduct(RedGlovePermission.Model.Products model);

        /// <summary>
        /// 删除一個產品
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        int DeleteProduct(string ProductID);

        /// <summary>
        /// 得到一個產品資料
        /// </summary>
        /// <param name="ProductID">產品ID</param>
        /// <returns></returns>
        RedGlovePermission.Model.Products GetProductModel(string ProductID);

        /// <summary>
        /// 得到產品資料列表
        /// </summary>
        /// <param name="strWhere">Where條件</param>
        /// <param name="strOrder">排序條件</param>
        /// <returns></returns>
        DataSet GetProductList(string strWhere, string strOrder);
    }
}
