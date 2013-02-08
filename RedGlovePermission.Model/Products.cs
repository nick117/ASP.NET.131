using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Products 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Products
    {
        public Products()
        {}
        #region Model
        private string _productid;
        private string _productname;
        private string _productspec;
        private string _storageunit;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 產品ID
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 產品規格
        /// </summary>
        public string ProductSpec
        {
            set { _productspec = value; }
            get { return _productspec; }
        }
        /// <summary>
        /// 儲存單位
        /// </summary>
        public string StorageUnit
        {
            set { _storageunit = value; }
            get { return _storageunit; }
        }
        /// <summary>
        /// 資料建立者
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 資料建立日期
        /// </summary>
        public string Create_Date
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 資料最後修改者
        /// </summary>
        public string Modifier
        {
            set { _modifier = value; }
            get { return _modifier; }
        }
        /// <summary>
        /// 資料最後修改日期
        /// </summary>
        public string Modi_Date
        {
            set { _modi_date = value; }
            get { return _modi_date; }
        }
        #endregion Model
    }
}
