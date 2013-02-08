using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;

/**************************************
 * 模組：產品資料選取
 * 作者：Nick.Lee
 * 日期:2012-05-16
 * ***********************************/

namespace RedGlovePermission.Web.Admin.Programs.Basic
{
    public partial class Products : CommonPage
    {
        RedGlovePermission.BLL.Products bll = new RedGlovePermission.BLL.Products();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模組權限
                UserHandle.InitModule("Mod_Products");
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
            DataSet ds = bll.GetProductList("", "order by MB001 asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            ProductsLists.DataSource = ds;
            ProductsLists.DataBind();
        }

        /// <summary>
        /// 將資料綁定到DataSet  for 查詢
        /// </summary>
        public void BindOrder2()
        {
            DataSet ds = bll.GetProductList("MB001 like '%" + txt_ID.Text.Trim() + "%' and MB002 like '%" + txt_Name.Text.Trim() + "%' and MB003 like '%" + txt_Spec.Text.Trim() + "%' and MB004 like '%" + txt_Unit.Text.Trim() + "%'", "order by MB001 asc");

            if (ds.Tables[0].Rows.Count == 0)
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Msg_norecord");
            else
                GridViewMsg.InnerText = ResourceManager.GetString("Pub_Lab_gy") + ds.Tables[0].Rows.Count + ResourceManager.GetString("Pub_Lab_tjl");

            ProductsLists.DataSource = ds;
            ProductsLists.DataBind();
        }

        /// <summary>
        /// 將使用者輸入資料清空
        /// </summary>
        public void ClearText()
        {
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_Spec.Text = "";
            txt_Unit.Text = "";
        }

        /// <summary>
        /// 分頁
        /// </summary>
        protected void ProductsLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductsLists.PageIndex = e.NewPageIndex;
            BindOrder2(); //重新綁定GridView資料的函数 
        }

        /// <summary>
        /// 退出編輯狀態
        /// </summary>
        protected void ProductsLists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProductsLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 執行事件（删除操作）
        /// </summary>
        protected void ProductsLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "sel")
            {
                //string sScript;
                string sTextBoxID;

                sTextBoxID = Request.QueryString["TextBoxId"].Substring(1);
                if (Request.QueryString["TextBoxId"].Substring(0, 1) == "A")
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[{0}].cells[0].getElementsByTagName(\"input\")[{1}].value='{2}'</script>", sTextBoxID.ToString().Split(',')[0].Trim(), sTextBoxID.ToString().Split(',')[1].Trim(), e.CommandArgument.ToString().Split(',')[0].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[{0}].cells[0].getElementsByTagName(\"table\")[1].rows[{1}].cells[3].innerText='{2}'</script>", sTextBoxID.ToString().Split(',')[0].Trim(), sTextBoxID.ToString().Split(',')[2].Trim(), e.CommandArgument.ToString().Split(',')[1].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[{0}].cells[0].getElementsByTagName(\"table\")[1].rows[{1}].cells[4].innerText='{2}'</script>", sTextBoxID.ToString().Split(',')[0].Trim(), sTextBoxID.ToString().Split(',')[2].Trim(), e.CommandArgument.ToString().Split(',')[2].Trim())));
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[{0}].cells[0].getElementsByTagName(\"table\")[1].rows[{1}].cells[5].innerText='{2}'</script>", sTextBoxID.ToString().Split(',')[0].Trim(), sTextBoxID.ToString().Split(',')[2].Trim(), e.CommandArgument.ToString().Split(',')[3].Trim())));
                    //{ sScript = "opener.window.document.getElementById('gvMaster').rows[" + sTextBoxID + "].cells[4].getElementsByTagName(\"input\")[0].value='" + e.CommandArgument.ToString().Trim() + "';"; }               
                }
                else
                {
                    this.Page.Controls.Add(new LiteralControl(string.Format("<script>opener.window.document.getElementById('gvMaster').rows[{0}].cells[0].getElementsByTagName(\"input\")[0].value='{1}'</script>", sTextBoxID, e.CommandArgument.ToString().Split(',')[0].Trim())));
                    //{ sScript = "opener.window.document.getElementById('gvMaster').rows[0].cells[0].getElementsByTagName(\"input\")[0].value='" + e.CommandArgument.ToString().Trim() + "';"; }
                }
                this.Page.Controls.Add(new LiteralControl("<script>window.close();</script>"));
                //sScript = sScript + "window.close();";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "sScript", sScript, true);
            }
        }

        /// <summary>
        /// 變更到編輯狀態
        /// </summary>
        protected void ProductsLists_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductsLists.EditIndex = e.NewEditIndex;
            BindOrder2();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        protected void ProductsLists_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RedGlovePermission.Model.Products model = new RedGlovePermission.Model.Products();
            model.ProductID = ProductsLists.DataKeys[e.RowIndex].Values[0].ToString();
            model.ProductName = ((TextBox)ProductsLists.Rows[e.RowIndex].FindControl("txt_name")).Text.Trim();
            model.ProductSpec = ((TextBox)ProductsLists.Rows[e.RowIndex].FindControl("txt_spec")).Text.Trim();
            model.StorageUnit = ((TextBox)ProductsLists.Rows[e.RowIndex].FindControl("txt_unit")).Text.Trim();
            UserSession user = SessionBox.GetUserSession();
            model.Modifier = user.LoginName.ToString();
            model.Modi_Date = DateTime.Now.ToString("yyyyMMdd");

            if (!bll.UpdateProduct(model))
            {
                //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_update_false") + "')", true);
            }
            //返回瀏覽狀態
            ProductsLists.EditIndex = -1;
            BindOrder2();
        }

        /// <summary>
        /// 資料綁定到表格
        /// </summary>
        protected void ProductsLists_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Trim() != "" || txt_ID.Text.Trim() != "")
            {
                RedGlovePermission.Model.Products model = new RedGlovePermission.Model.Products();

                model.ProductID = txt_ID.Text.Trim();
                model.ProductName = txt_Name.Text.Trim();
                model.ProductSpec = txt_Spec.Text.Trim();
                model.StorageUnit = txt_Unit.Text.Trim();
                UserSession user = SessionBox.GetUserSession();
                model.Creator = user.LoginName.ToString();
                model.Create_Date = DateTime.Now.ToString("yyyyMMdd");

                if (!bll.Exists(txt_ID.Text.Trim()))
                {
                    if (bll.CreateProduct(model))
                    {
                        //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_true") + "')", true);
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_false") + "')", true);
                    }
                    ClearText();
                    BindOrder();
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_IsCustomer") + "')", true);
                }
            }
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        protected void btn_query_Click(object sender, EventArgs e)
        {
                    BindOrder2();
                    //ClearText();
        }


        protected void ProductsLists_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;

                #region 語言
                tcHeader[0].Text = ResourceManager.GetString("ProductsPage_Lab_0");
                tcHeader[1].Text = ResourceManager.GetString("ProductsPage_Lab_1");
                tcHeader[2].Text = ResourceManager.GetString("ProductsPage_Lab_2");
                tcHeader[3].Text = ResourceManager.GetString("Pub_Lbtn_sel");
                #endregion
            }
        }
    }
}
