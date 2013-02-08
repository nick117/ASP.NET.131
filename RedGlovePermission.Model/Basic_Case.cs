using System;
namespace RedGlovePermission.Model
{
    /// <summary>
    /// 類別Basic_Case 。(屬性說明自動提取資料庫欄位的說明資料)
    /// </summary>
    public class Basic_Case
    {
        public Basic_Case()
        {}
        #region Model
        private string _caseno;
        private string _casedescription;
        private string _department;
        private string _ma001;
        private string _creator;
        private string _create_date;
        private string _modifier;
        private string _modi_date;
        /// <summary>
        /// 案件編號
        /// </summary>
        public string CaseNo
        {
            set { _caseno = value; }
            get { return _caseno; }
        }
        /// <summary>
        /// 案件名稱
        /// </summary>
        public string CaseDescription
        {
            set { _casedescription = value; }
            get { return _casedescription; }
        }
        /// <summary>
        /// 業務組
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
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
