using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;

/**************************************
 * 模組：案件資料管理
 * 作者：Nick.Lee
 * 日期:2012-05-22
 * ***********************************/

namespace RedGlovePermission.Web.Admin.Programs.Basic
{
    public partial class CasePage : CommonPage
    {
        RedGlovePermission.BLL.Basic_Case bll = new RedGlovePermission.BLL.Basic_Case();
        RedGlovePermission.BLL.Basic_System bllCode = new RedGlovePermission.BLL.Basic_System();
        string Group; //傳遞業務組編輯前原值用
        

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
                    btn_add.Attributes.Add("onclick", "return CheckAdd()");//加入驗證
                    BindOrder();

                    //綁定業務組下拉選單
                    ddl_Department.DataSource = CreateDataTable();
                    ddl_Department.DataTextField = "Items";
                    ddl_Department.DataValueField = "Items";
                    ddl_Department.DataBind();

                    #region 語言加入
                    btn_add.Text = ResourceManager.GetString("Pub_Btn_add");
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
            if (e.CommandName.ToString() == "Del")
            {
                int ret = bll.DeleteCase(e.CommandArgument.ToString());
                switch (ret)
                {
                    case 1:
                        BindOrder();
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_delete_true") + "');", true);
                        break;
                    case 2:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_IsSalesOrder") + "');", true);
                        break;
                    case 3:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_IsSalesReturn") + "');", true);
                        break;
                    default:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_delete_false") + "');", true);
                        break;
                }
            }
            //else if (e.CommandName.ToString() == "Edit")
            //{
            //    int idx = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            //    ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + CaseLists.Rows[idx].FindControl("Lab_Department").ClientID + "');", true);
            //}
        }

        /// <summary>
        /// 變更到編輯狀態
        /// </summary>
        protected void CaseLists_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CaseLists.EditIndex = e.NewEditIndex;
            //存入編輯前的業務組原值
            Group = ((Label)CaseLists.Rows[e.NewEditIndex].FindControl("Lab_Department")).Text.Trim();
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
                ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_update_false") + "')", true);
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
                if ((e.Row.RowState & DataControlRowState.Edit) != 0)
                {
                    if (e.Row.FindControl("ddl_Department2") != null)
                    { 
                        //綁定業務組下拉選單
                        ((DropDownList)e.Row.FindControl("ddl_Department2")).DataSource = CreateDataTable();
                        ((DropDownList)e.Row.FindControl("ddl_Department2")).DataTextField = "Items";
                        ((DropDownList)e.Row.FindControl("ddl_Department2")).DataValueField = "Items";
                        ((DropDownList)e.Row.FindControl("ddl_Department2")).SelectedValue = Group; //顯示編輯前的原值
                        ((DropDownList)e.Row.FindControl("ddl_Department2")).DataBind();                   
                    }
                }
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ffffcd',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");

                LinkButton btnDel = ((LinkButton)e.Row.FindControl("btn_del"));

                btnDel.Attributes.Add("onclick", "return confirm('" + ResourceManager.GetString("Pub_Msg_confirm") + "')");

                int RI = e.Row.RowIndex + 1;
                e.Row.Cells[3].Attributes.Add("onclick", "GetCustomer(" + RI.ToString() + ");return false;");
                e.Row.Cells[3].Attributes.Add("style", "cursor: hand;");
            }
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_CaseNo.Text.Trim() != "")
            {
                RedGlovePermission.Model.Basic_Case model = new RedGlovePermission.Model.Basic_Case();

                model.CaseNo = txt_CaseNo.Text.Trim();
                model.CaseDescription = txt_CaseDescription.Text.Trim();
                model.Department = ddl_Department.Text.Trim();
                model.MA001 = txt_MA001.Text.Trim();
                UserSession user = SessionBox.GetUserSession();
                model.Creator = user.LoginName.ToString();
                model.Create_Date = DateTime.Now.ToString("yyyyMMdd");

                if (!bll.Exists(txt_CaseNo.Text.Trim()))
                {
                    if (bll.CreateCase(model))
                    {
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_true") + "')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_false") + "')", true);
                    }
                    txt_CaseNo.Text = "";
                    txt_CaseDescription.Text = "";
                    ddl_Department.SelectedIndex = 0;
                    txt_MA001.Text = "";
                    BindOrder();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_IsCustomer") + "')", true);
                }
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
                tcHeader[5].Text = ResourceManager.GetString("Pub_Lbtn_update");
                tcHeader[6].Text = ResourceManager.GetString("Pub_Lbtn_delete");
                #endregion
            }
        }
    }
}
