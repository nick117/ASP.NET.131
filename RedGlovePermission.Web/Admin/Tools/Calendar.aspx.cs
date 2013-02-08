using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedGlovePermission.Web.Admin
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string sScript;
            string sTextBoxID;

            sTextBoxID = Request.QueryString["TextBoxId"].Substring(1);
            if (Request.QueryString["TextBoxId"].Substring(0, 1) == "A")
                { sScript = "opener.window.document.getElementById('gvMaster').rows[" + sTextBoxID + "].cells[8].getElementsByTagName(\"input\")[0]. value='" + Calendar1.SelectedDate.Date.ToString("yyyyMMdd") + "';"; }
            else if (Request.QueryString["TextBoxId"].Substring(0, 1) == "B") //單檔表頭用, 須傳入控件ID, 可共用
                { sScript = "opener.window.document.getElementById('" + Request.QueryString["TextBoxId"].Substring(1) + "').value='" + Calendar1.SelectedDate.Date.ToString("yyyyMMdd") + "';"; }
            else
                 { sScript = "opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[2]. value='" + Calendar1.SelectedDate.Date.ToString("yyyyMMdd") + "';"; }
            sScript = sScript + "window.close();";
            Page.ClientScript.RegisterStartupScript(this.GetType(),"sScript", sScript, true);

        }
    
    }
}