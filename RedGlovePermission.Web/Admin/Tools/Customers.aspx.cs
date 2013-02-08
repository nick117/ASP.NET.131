using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;

/**************************************
 * 模組：客戶資料選取
 * 作者：Nick.Lee
 * 日期:2012-05-15
 * ***********************************/

namespace RedGlovePermission.Web.Admin.Programs.Basic
{
    public partial class Customers : CommonPage
    {
        RedGlovePermission.BLL.Customers bll = new RedGlovePermission.BLL.Customers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模組權限
                UserHandle.InitModule("Mod_Customers");
                if (!UserHandle.ValidationHandle("RGP_BROWSE"))
                {
                    Response.Redirect("~/Admin/Frameset/NoRight.aspx");
                }
                if (!IsPostBack)
                {
                    BindOrder();

                    #region 語言加入
                    #endregion
                }
            }
        }

        /// <summary>
        /// 將資料綁定到DataSet for 新增
        /// </summary>
        public void BindOrder()
        {
            DataSet ds = bll.GetCustomerList("", "order by MA001 asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            CustomersLists.DataSource = ds;
            CustomersLists.DataBind();
        }

        /// <summary>
        /// 將資料綁定到DataSet  for 查詢
        /// </summary>
        public void BindOrder2()
        {
            DataSet ds = bll.GetCustomerList("MA001 like '%" + txt_ID.Text.Trim() + "%' and MA002 like '%" + txt_Name.Text.Trim() + "%' and MA027 like '%" + txt_Address.Text.Trim() + "%'", "order by MA001 asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            CustomersLists.DataSource = ds;
            CustomersLists.DataBind();
        }

        /// <summary>
        /// 分頁
        /// </summary>
        protected void CustomersLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustomersLists.PageIndex = e.NewPageIndex;
            BindOrder2(); //重新綁定GridView資料的函数 
        }

        /// <summary>
        /// 退出編輯狀態
        /// </summary>
        protected void CustomersLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CustomersLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 執行事件（選取操作, 傳選取值回到呼叫表單的正確欄位）
        /// </summary>
        protected void CustomersLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "sel")
            {
                //string sScript;
                string sTextBoxID;

                sTextBoxID = Request.QueryString["TextBoxId"].Substring(1);
                if (Request.QueryString["TextBoxId"].Substring(0, 1) == "A") //GridView用,需傳入(GridViewID,客戶編號CellsID,簡稱CellsID,編輯RowID)
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('{2}').rows[{0}].cells[{3}].getElementsByTagName(\"input\")[0].value='{1}'</script>", sTextBoxID.Split(',')[3].Trim(), e.CommandArgument.ToString().Split(',')[0].Trim(), sTextBoxID.Split(',')[0].Trim(), sTextBoxID.Split(',')[1].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('{2}').rows[{0}].cells[{3}].innerText='{1}'</script>", sTextBoxID.Split(',')[3].Trim(), e.CommandArgument.ToString().Split(',')[1].Trim(), sTextBoxID.Split(',')[0].Trim(), sTextBoxID.Split(',')[2].Trim())));
                    //{ sScript = "opener.window.document.getElementById('gvMaster').rows[" + sTextBoxID + "].cells[4].getElementsByTagName(\"input\")[0].value='" + e.CommandArgument.ToString().Trim() + "';"; }               
                }
                else if (Request.QueryString["TextBoxId"].Substring(0, 1) == "B") //頭身檔頭檔用, 只須傳入B即可(切記gvMaster不可改變名稱, 要共用請比照A來改程式)
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[1].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[0].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[3].value='{0}'</script>", e.CommandArgument.ToString().Split(',')[2].Trim())));
                    //{ sScript = "opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[0].value='" + e.CommandArgument.ToString().Trim() + "';"; }
                }
                else if (Request.QueryString["TextBoxId"].Substring(0, 1) == "C") //單檔表頭用, 須傳入控件ID, 可共用
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('" + Request.QueryString["TextBoxId"].Substring(1) + "').value='{0}'</script>", e.CommandArgument.ToString().Split(',')[0].Trim())));
                }
                this.Page.Controls.Add(new LiteralControl("<script>window.close();</script>"));
                //sScript = sScript + "window.close();";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "sScript", sScript, true);
            }
        }

        /// <summary>
        /// 變更到編輯狀態
        /// </summary>
        protected void CustomersLists_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CustomersLists.EditIndex = e.NewEditIndex;
            BindOrder2();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        protected void CustomersLists_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RedGlovePermission.Model.Customers model = new RedGlovePermission.Model.Customers();
            model.CustomerID = CustomersLists.DataKeys[e.RowIndex].Values[0].ToString();
            model.CustomerAbbrev = ((TextBox)CustomersLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            UserSession user = SessionBox.GetUserSession();
            model.Modifier = user.LoginName.ToString();
            model.Modi_Date = DateTime.Now.ToString("yyyyMMdd");

            if (!bll.UpdateCustomer(model))
            {
                //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_update_false") + "')", true);
            }
            //返回瀏覽狀態
            CustomersLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 資料綁定到表格
        /// </summary>
        protected void CustomersLists_RowDataBound(object sender, GridViewRowEventArgs e)
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
        /// 查詢資料
        /// </summary>
        protected void btn_query_Click(object sender, EventArgs e)
        {
                    BindOrder2();
                    //txt_ID.Text = "";
                    //txt_Name.Text = "";
        }


        protected void CustomersLists_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;

                #region 語言
                tcHeader[0].Text = ResourceManager.GetString("CustomersPage_Lab_0");
                tcHeader[1].Text = ResourceManager.GetString("CustomersPage_Lab_1");
                tcHeader[2].Text = ResourceManager.GetString("Pub_Lbtn_sel");
                #endregion
            }
        }
    }
}
