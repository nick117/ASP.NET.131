using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;

/**************************************
 * 模組：案件資料選取
 * 作者：Nick.Lee
 * 日期:2012-05-25
 * ***********************************/

namespace RedGlovePermission.Web.Admin.Programs.Basic
{
    public partial class Case : CommonPage
    {
        RedGlovePermission.BLL.Basic_Case bll = new RedGlovePermission.BLL.Basic_Case();
        RedGlovePermission.BLL.Basic_System bllCode = new RedGlovePermission.BLL.Basic_System();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模組權限
                UserHandle.InitModule("Mod_Case");
                if (!UserHandle.ValidationHandle("RGP_BROWSE"))
                {
                    Response.Redirect("~/Admin/Frameset/NoRight.aspx");
                }
                if (!IsPostBack)
                {
                    BindOrder();

                    //綁定業務組下拉選單
                    ddl_Department.DataSource = CreateDataTable();
                    ddl_Department.DataTextField = "Items";
                    ddl_Department.DataValueField = "Items";
                    ddl_Department.DataBind();

                    #region 語言加入
                     #endregion
                }
            }
        }

        protected DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            //產生業務組下拉選單
            dt.Columns.Add("Items", typeof(string));
            RedGlovePermission.Model.Basic_System mdlCode = bllCode.GetCodeModel("SalesGroup");
            string[] ddl_Deparment_Items = mdlCode.Items.Split(',');
            foreach (string s in ddl_Deparment_Items)
            {
                dt.Rows.Add(s.Trim());
            }
            return dt;

        }

        /// <summary>
        /// 將資料綁定到DataSet for 新增
        /// </summary>
        public void BindOrder()
        {
            DataSet ds = bll.GetCaseList("", "order by CaseNo asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            CaseLists.DataSource = ds;
            CaseLists.DataBind();
        }

        /// <summary>
        /// 將資料綁定到DataSet  for 查詢
        /// </summary>
        public void BindOrder2()
        {
            DataSet ds = bll.GetCaseList("CaseNo like '%" + txt_CaseNo.Text.Trim() + "%' and CaseDescription like '%" + txt_CaseDescription.Text.Trim() + "%' and Department like '%" + ddl_Department.SelectedValue.Trim() + "%' and B.MA001 like '%" + txt_MA001.Text.Trim() + "%'", "order by CaseNo asc");
 
            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            CaseLists.DataSource = ds;
            CaseLists.DataBind();
        }

        /// <summary>
        /// 分頁
        /// </summary>
        protected void CaseLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CaseLists.PageIndex = e.NewPageIndex;
            BindOrder2(); //重新綁定GridView資料的函数 
        }

        /// <summary>
        /// 退出編輯狀態
        /// </summary>
        protected void CaseLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CaseLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 執行事件（删除操作）
        /// </summary>
        protected void CaseLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "sel")
            {
                string sTextBoxID;
                sTextBoxID = Request.QueryString["TextBoxId"].Substring(1);
                if (Request.QueryString["TextBoxId"].Substring(0, 1) == "A") //GridView用,需傳入(GridViewID,案件編號CellsID,案件名稱CellsID,編輯RowID)
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('{2}').rows[{0}].cells[{3}].getElementsByTagName(\"input\")[0].value='{1}'</script>", sTextBoxID.Split(',')[3].Trim(), e.CommandArgument.ToString().Split(',')[0].Trim(), sTextBoxID.Split(',')[0].Trim(), sTextBoxID.Split(',')[1].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('{2}').rows[{0}].cells[{3}].innerText='{1}'</script>", sTextBoxID.Split(',')[3].Trim(), e.CommandArgument.ToString().Split(',')[1].Trim(), sTextBoxID.Split(',')[0].Trim(), sTextBoxID.Split(',')[2].Trim())));
                 }
                else if (Request.QueryString["TextBoxId"].Substring(0, 1) == "B") //頭身檔頭檔用, 只須傳入B即可(切記gvMaster不可改變名稱, 要共用請比照A來改程式)
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[0].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[0].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[1].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[3].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[3].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[5].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"select\")[0].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[2].Trim())));
                 }
                else if (Request.QueryString["TextBoxId"].Substring(0, 1) == "C") //頭身檔頭檔用, 只須傳入C即可(切記gvMaster不可改變名稱, 要共用請比照A來改程式)
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[0].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[0].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[1].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[3].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"select\")[0].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[2].Trim())));
                }
                this.Page.Controls.Add(new LiteralControl("<script>window.close();</script>"));
            }
        }

        /// <summary>
        /// 變更到編輯狀態
        /// </summary>
        protected void CaseLists_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BindOrder2();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        protected void CaseLists_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RedGlovePermission.Model.Basic_Case model = new RedGlovePermission.Model.Basic_Case();
            model.CaseNo = CaseLists.DataKeys[e.RowIndex].Values[0].ToString();
            model.CaseDescription = ((TextBox)CaseLists.Rows[e.RowIndex].FindControl("txt_CaseDescription")).Text.Trim();
            model.Department = ((DropDownList)CaseLists.Rows[e.RowIndex].FindControl("ddl_Department2")).Text.Trim();
            model.MA001 = ((TextBox)CaseLists.Rows[e.RowIndex].FindControl("txt_MA001")).Text.Trim();
            UserSession user = SessionBox.GetUserSession();
            model.Modifier = user.LoginName.ToString();
            model.Modi_Date = DateTime.Now.ToString("yyyyMMdd");

            if (!bll.UpdateCase(model))
            {
                //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_update_false") + "')", true);
            }
            //返回瀏覽狀態
            CaseLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 資料綁定到表格
        /// </summary>
        protected void CaseLists_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                
                LinkButton btnSel = ((LinkButton)e.Row.FindControl("btn_sel"));

                btnSel.Attributes.Add("onclick", "return true");
            }
        }

        /// <summary>
        /// 新增資料
        /// </summary>


        /// <summary>
        /// 查詢資料
        /// </summary>
        protected void btn_query_Click(object sender, EventArgs e)
        {
                    BindOrder2();
                    //txt_ID.Text = "";
                    //txt_Name.Text = "";
        }


        protected void CaseLists_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;

                #region 語言
                tcHeader[0].Text = ResourceManager.GetString("CasePage_Lab_0");
                tcHeader[1].Text = ResourceManager.GetString("CasePage_Lab_1");
                tcHeader[2].Text = ResourceManager.GetString("CasePage_Lab_2");
                tcHeader[3].Text = ResourceManager.GetString("CasePage_Lab_3");
                tcHeader[4].Text = ResourceManager.GetString("CasePage_Lab_4");
                tcHeader[5].Text = ResourceManager.GetString("Pub_Lbtn_sel");
                #endregion
            }
        }
    }
}
