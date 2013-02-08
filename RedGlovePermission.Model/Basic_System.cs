using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Basic_System 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Basic_System
    {
        public Basic_System()
        {}
        #region Model
        private string _code;
        private string _items;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 參數代號
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 項目值
        /// </summary>
        public string Items
        {
            set { _items = value; }
            get { return _items; }
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
