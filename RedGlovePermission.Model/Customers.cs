using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Customers 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Customers
    {
        public Customers()
        {}
        #region Model
        private string _customerid;
        private string _customerabbrev;
        private string _address;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string CustomerAbbrev
        {
            set { _customerabbrev = value; }
            get { return _customerabbrev; }
        }
        /// <summary>
        /// 送貨地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
