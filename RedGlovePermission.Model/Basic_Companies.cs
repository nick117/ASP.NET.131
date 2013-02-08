using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Basic_Companies 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Basic_Companies
    {
        public Basic_Companies()
        {}
        #region Model
        private string _company;
        private string _track;
        private string _description;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 表單字軌
        /// </summary>
        public string Track
        {
            set { _track = value; }
            get { return _track; }
        }
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
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
