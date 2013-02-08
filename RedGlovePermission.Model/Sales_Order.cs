using System;
using System.Collections.Generic;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Sales_Order 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Sales_Order
    {
        public Sales_Order()
        {}
        #region Model
        private string _orderid;
        private string _ma001;
        private string _company;
        private string _orderdate;
        private string _caseno;
        private string _department;
        private float _taxrate;
        private float _amount;
        private float _tax;
        private string _address;
        private string _remark;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        private List<Sales_Order_Dtl> _orderdetaillist;
        /// <summary>
        /// 訂單ID
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string MA001
        {
            set { _ma001 = value; }
            get { return _ma001; }
        }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 訂單日期
        /// </summary>
        public string Order_Date
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 案件編號
        /// </summary>
        public string CaseNo
        {
            set { _caseno = value; }
            get { return _caseno; }
        }
                /// <summary>
        /// 業務組
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// 稅率
        /// </summary>
        public float TaxRate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// 未稅金額
        /// </summary>
        public float Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// 稅額
        /// </summary>
        public float Tax
        {
            set { _tax = value; }
            get { return _tax; }
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
        /// 備註
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// <summary>
        /// 訂單明細
        /// </summary>
        public List<Sales_Order_Dtl> Sales_Order_Dtl_List
        {
            set { _orderdetaillist = value; }
            get { return _orderdetaillist; }
        }
        #endregion Model
    }
}
