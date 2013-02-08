using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Sales_Return_Dtl 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Sales_Return_Dtl
    {
        public Sales_Return_Dtl()
        {}
        #region Model
        private string _returnid;
        private int _seq;
        private string _mb001;
        private float _qty;
        private float _unitprice;
        private float _discount;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 銷貨退回單ID
        /// </summary>
        public string ReturnID
        {
            set { _returnid = value; }
            get { return _returnid; }
        }
        /// <summary>
        /// 產品ID
        /// </summary>
        public string MB001
        {
            set { _mb001 = value; }
            get { return _mb001; }
        }
        /// <summary>
        /// 數量
        /// </summary>
        public float Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 單價
        /// </summary>
        public float UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public float Discount
        {
            set { _discount = value; }
            get { return _discount; }
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
