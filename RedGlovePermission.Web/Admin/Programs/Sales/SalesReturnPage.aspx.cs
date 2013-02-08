using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RedGlove.Core.Languages;

namespace RedGlovePermission.Web.Admin.Programs.Sales
{
    public partial class SalesReturnPage : System.Web.UI.Page
    {
        RedGlovePermission.BLL.Basic_Companies bll = new RedGlovePermission.BLL.Basic_Companies();
        RedGlovePermission.BLL.Sales_Return bllReturn = new RedGlovePermission.BLL.Sales_Return();
        RedGlovePermission.BLL.Basic_System bllCode = new RedGlovePermission.BLL.Basic_System();
        string Group; //傳遞業務組編輯前原值用
        string TTaxRate; //傳遞業務組編輯前原值用

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模組權限
                UserHandle.InitModule("Mod_SalesReturn");
                if (!UserHandle.ValidationHandle("RGP_BROWSE"))
                {
                    Response.Redirect("~/Admin/Frameset/NoRight.aspx");
                }
                if (!IsPostBack)
                {
                    BindCompanyOrder();
                    if (CompanyList.SelectedItem.Selected)
                        dsMaster.SelectParameters[0].DefaultValue = CompanyList.SelectedItem.ToString();
                    BindData();

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

        protected DataTable CreateTaxRateTable()
        {
            DataTable dt = new DataTable();
            //產生稅率下拉選單
            dt.Columns.Add("Items", typeof(string));
            RedGlovePermission.Model.Basic_System mdlCode = bllCode.GetCodeModel("Tax");
            string[] ddl_TaxRate_Items = mdlCode.Items.Split(',');
            foreach (string s in ddl_TaxRate_Items)
            {
                dt.Rows.Add(s.Trim());
            }
            return dt;

        }

        protected void gvMaster_PreRender(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvMaster.Rows)
            {
                ImageButton img = (ImageButton)row.FindControl("imgButSel");
                GridView gv = (GridView)row.FindControl("gvChild");
                SqlDataSource dsChild = (SqlDataSource)row.FindControl("dsChild");
                if (dsChild != null)
                    dsChild.SelectParameters[0].DefaultValue = row.Cells[5].Text;

                if (gv != null)
                {
                    if (!gv.Visible)
                    {
                        if (img != null)
                            img.ImageUrl = "~/images/noselect.gif";
                    }
                    else
                    {
                        BindChildData(gv);
                        if (img != null)
                            img.ImageUrl = "~/images/select.gif";
                    }
                }
            }
        }
 
        protected void gvMaster_SearchGrid(object sender, string _strSearch)
        {
            //如果搜索欄位非string時要用這個來作
            //if (_strSearch != null && _strSearch.ToUpper().StartsWith("ORDERID "))
            //    _hfSearch.Value = _strSearch.ToUpper().Replace("ORDERID ", "Convert(OrderID, 'System.String') ");
            //else
            _hfSearch.Value = _strSearch;
            BindData();
        }

        void BindData()
        {
            dsMaster.FilterExpression = _hfSearch.Value;
            dsMaster.Select(new DataSourceSelectArguments());
        }

        /// <summary>
        /// 變更到編輯狀態
        /// </summary>
        protected void gvMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMaster.EditIndex = e.NewEditIndex;
            //存入編輯前的業務組原值
            Group = ((Label)gvMaster.Rows[e.NewEditIndex].FindControl("Lab_Department")).Text.Trim();
            TTaxRate = ((Label)gvMaster.Rows[e.NewEditIndex].FindControl("Lab_TaxRate")).Text.Trim();
            BindData();
        }

        protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strReturnID = (string)e.Keys[0];
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCSConnectionString"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from Sales_Return_DTL where ReturnID = '" + strReturnID + "'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_IsDetail") + "');", true);
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('SQLException : " + exp.Message + "');", true);
                e.Cancel = true;
                return;
            }
            finally
            {
                connection.Close();
            }

            dsMaster.DeleteParameters["ReturnID"].DefaultValue = strReturnID.ToString();
            dsMaster.Delete();
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_delete_true") + "');", true);
        }

        protected void gvMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddlDepartment = (DropDownList)gvMaster.Rows[gvMaster.EditIndex].Cells[9].FindControl("ddl_Department2");
            DropDownList ddlTaxRate = (DropDownList)gvMaster.Rows[gvMaster.EditIndex].Cells[10].FindControl("ddl_TaxRate2");
            //Need to get updated value for none boundfield 
            string strReturnID = (string)e.Keys[0];
            dsMaster.UpdateParameters["ReturnID"].DefaultValue = strReturnID.ToString();
            dsMaster.UpdateParameters["Department"].DefaultValue = ddlDepartment.SelectedValue;
            dsMaster.UpdateParameters["TaxRate"].DefaultValue = ddlTaxRate.SelectedValue;
            UserSession user = SessionBox.GetUserSession();
            dsMaster.UpdateParameters["MODIFIER"].DefaultValue = user.LoginName.ToString();
            dsMaster.UpdateParameters["MODI_DATE"].DefaultValue = DateTime.Now.ToString("yyyyMMdd");
            dsMaster.Update();
         }

        protected void gvChild_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            SqlDataSource dsChild = (SqlDataSource)gvr.FindControl("dsChild");

            dsChild.DeleteParameters["ReturnID"].DefaultValue = gvr.Cells[5].Text;
            dsChild.DeleteParameters["SEQM"].DefaultValue = ((GridView)sender).Rows[e.RowIndex].Cells[1].Text;
            dsChild.Delete();
            //處理單頭合計及稅額
            if (bllReturn.ReturnTotal(gvr.Cells[5].Text) == 0)
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_total_false") + "');", true);
            else
            {
                RedGlovePermission.Model.Sales_Return Returnmodel = new RedGlovePermission.Model.Sales_Return();
                Returnmodel = bllReturn.GetReturnModel(gvr.Cells[5].Text);
                gvr.Cells[13].Text = Returnmodel.Amount.ToString();
                gvr.Cells[14].Text = Returnmodel.Tax.ToString();
            }
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_delete_true") + "');", true);
        }

        protected void gvChild_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            SqlDataSource dsChild = (SqlDataSource)gvr.FindControl("dsChild");

            dsChild.UpdateParameters["ReturnID"].DefaultValue = gvr.Cells[5].Text;
            dsChild.UpdateParameters["SEQM"].DefaultValue = ((GridView)sender).Rows[e.RowIndex].Cells[1].Text;
            UserSession user = SessionBox.GetUserSession();
            dsChild.UpdateParameters["MODIFIER"].DefaultValue = user.LoginName.ToString();
            dsChild.UpdateParameters["MODI_DATE"].DefaultValue = DateTime.Now.ToString("yyyyMMdd");
            dsChild.Update();
         }

        void BindChildData(GridView gv)
        {
            GridViewRow gvr = (GridViewRow)gv.NamingContainer;
            HiddenField _hfChildSearch = (HiddenField)gvr.FindControl("_hfChildSearch");
            SqlDataSource dschild = (SqlDataSource)gvr.FindControl("dsChild");
            dschild.FilterExpression = _hfChildSearch.Value;
            dschild.Select(new DataSourceSelectArguments());
            gv.DataBind();
            if (gv.Rows.Count > 0)
                gv.SelectedIndex = 0;
        }

        protected void gvChild_SearchGrid(object sender, string _strSearch)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            HiddenField _hfChildSearch = (HiddenField)gvr.FindControl("_hfChildSearch");
            if (_strSearch != null && _strSearch.ToUpper().StartsWith("Seq "))
                _hfChildSearch.Value = _strSearch.ToUpper().Replace("Seq ", "Convert(Seq, 'System.String') ");
            else
                _hfChildSearch.Value = _strSearch;
            BindChildData((GridView)sender);
        }
 
        protected void gvMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvMaster_PageIndexChanged(object sender, EventArgs e)
        {
        }
 
        protected void gvChild_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            //處理單頭合計及稅額
            if (bllReturn.ReturnTotal(gvr.Cells[5].Text) == 0)
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_total_false") + "');", true);
            else
            {
                RedGlovePermission.Model.Sales_Return Returnmodel = new RedGlovePermission.Model.Sales_Return();
                Returnmodel = bllReturn.GetReturnModel(gvr.Cells[5].Text);
                gvr.Cells[13].Text = Returnmodel.Amount.ToString();
                gvr.Cells[14].Text = Returnmodel.Tax.ToString();
            }
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_update_true") + "');", true);
        }
 
        protected void gvMaster_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_update_true") + "');", true);
        }
 
        protected void gvMaster_Sorted(object sender, EventArgs e)
        {
        }
 
        protected void gvMaster_AddRow(object sender)
        {
            _hfSearch.Value = "1 = 2";
            BindData();
        }
 
        protected void gvChild_AddRow(object sender)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            HiddenField _hfChildSearch = (HiddenField)gvr.FindControl("_hfChildSearch");
            _hfChildSearch.Value = "1 = 2";
            BindChildData((GridView)sender);
        }
 
        protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNewM")
            {
                //TextBox tbOrderID = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbOrderID");
                TextBox tbMA001 = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbMA001");
                TextBox tbCompany = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbCompany");
                TextBox tbReturn_Date = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbReturn_Date");
                TextBox tbCaseNo = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbCaseNo");
                DropDownList ddlDepartment = (DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_Department");
                DropDownList ddlTaxRate = (DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate");
                TextBox tbRemark = (TextBox)gvMaster.Controls[0].Controls[0].FindControl("tbRemark");

                //if (tbOrderID != null)
                //    dsMaster.InsertParameters["OrderID"].DefaultValue = tbOrderID.Text;
                RedGlovePermission.Model.Basic_Companies model = new RedGlovePermission.Model.Basic_Companies();
                model = bll.GetCCompanyModel(CompanyList.SelectedItem.ToString());
                dsMaster.InsertParameters["ReturnID"].DefaultValue = bllReturn.GetNewReturnID(model.Track + DateTime.Now.ToString("yyyyMMdd"));
                if (tbMA001 != null)
                    dsMaster.InsertParameters["MA001"].DefaultValue = tbMA001.Text;
                dsMaster.InsertParameters["COMPANY"].DefaultValue = CompanyList.SelectedItem.ToString();
                if (tbReturn_Date != null)
                    dsMaster.InsertParameters["Return_DATE"].DefaultValue = tbReturn_Date.Text;
                if (tbCaseNo != null)
                    dsMaster.InsertParameters["CaseNo"].DefaultValue = tbCaseNo.Text;
                dsMaster.InsertParameters["Department"].DefaultValue = ddlDepartment.SelectedValue;
                dsMaster.InsertParameters["TaxRate"].DefaultValue = ddlTaxRate.SelectedValue;
                if (tbRemark != null)
                    dsMaster.InsertParameters["Remark"].DefaultValue = tbRemark.Text;
                UserSession user = SessionBox.GetUserSession();
                dsMaster.InsertParameters["CREATOR"].DefaultValue = user.LoginName.ToString();
                dsMaster.InsertParameters["CREATE_DATE"].DefaultValue = DateTime.Now.ToString("yyyyMMdd");
                int aff_row = dsMaster.Insert();
                if (aff_row == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_add_false") + "');", true);
                    _hfSearch.Value = "";
                }
                else 
                //{
                //    ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_add_true") + dsMaster.InsertParameters["OrderID"].DefaultValue.ToString() + "');", true);
                //    _hfSearch.Value = "";
                //}
                    _hfSearch.Value = "ReturnID='" + dsMaster.InsertParameters["ReturnID"].DefaultValue.ToString() + "'";
                BindData();
            }
            if (e.CommandName == "InsertCancelM")
            {
                _hfSearch.Value = "";
                BindData();
            }
            //if (e.CommandName == "Prt")
            //{}
        }
 
        protected void gvChild_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((GridView)sender).NamingContainer;
            HiddenField _hfChildSearch = (HiddenField)gvr.FindControl("_hfChildSearch");
            SqlDataSource dsChild = (SqlDataSource)gvr.FindControl("dsChild");

            if (e.CommandName == "InsertNew")
            {
                //TextBox tbSeq = (TextBox)((GridView)sender).Controls[0].Controls[0].FindControl("tbSeq");
                TextBox tbMB001 = (TextBox)((GridView)sender).Controls[0].Controls[0].FindControl("tbMB001");
                TextBox tbQty = (TextBox)((GridView)sender).Controls[0].Controls[0].FindControl("tbQty");
                TextBox tbUnitPrice = (TextBox)((GridView)sender).Controls[0].Controls[0].FindControl("tbUnitPrice");
                TextBox tbDiscount = (TextBox)((GridView)sender).Controls[0].Controls[0].FindControl("tbDiscount");
                //if (tbSeq != null)
                //    dsChild.InsertParameters["Seq"].DefaultValue = tbSeq.Text;
                RedGlovePermission.Model.Basic_Companies model = new RedGlovePermission.Model.Basic_Companies();
                model = bll.GetCCompanyModel(CompanyList.SelectedItem.ToString());
                dsChild.InsertParameters["Seq"].DefaultValue = bllReturn.GetNewReturnSeq(gvr.Cells[5].Text);
                if (tbMB001 != null)
                    dsChild.InsertParameters["MB001"].DefaultValue = tbMB001.Text;
                if (tbQty != null)
                    dsChild.InsertParameters["Qty"].DefaultValue = tbQty.Text;
                if (tbUnitPrice != null)
                    dsChild.InsertParameters["unitPrice"].DefaultValue = tbUnitPrice.Text;
                if (tbDiscount != null)
                    dsChild.InsertParameters["Discount"].DefaultValue = tbDiscount.Text;
                else
                    dsChild.InsertParameters["Discount"].DefaultValue = "1";
                dsChild.InsertParameters["ReturnId"].DefaultValue = gvr.Cells[5].Text;
                UserSession user = SessionBox.GetUserSession();
                dsChild.InsertParameters["CREATOR"].DefaultValue = user.LoginName.ToString();
                dsChild.InsertParameters["CREATE_DATE"].DefaultValue = DateTime.Now.ToString("yyyyMMdd");
                dsChild.Insert();
                //處理單頭合計及稅額
                if (bllReturn.ReturnTotal(gvr.Cells[5].Text) == 0)
                    ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_total_false") + "');", true);
                else
                {
                    RedGlovePermission.Model.Sales_Return Returnmodel = new RedGlovePermission.Model.Sales_Return();
                    Returnmodel = bllReturn.GetReturnModel(gvr.Cells[5].Text);
                    gvr.Cells[13].Text = Returnmodel.Amount.ToString();
                    gvr.Cells[14].Text = Returnmodel.Tax.ToString();
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + ResourceManager.GetString("Pub_Msg_update_true") + "');", true);
                _hfChildSearch.Value = "";
                BindChildData((GridView)sender);
            }
            if (e.CommandName == "InsertCancel")
            {
                _hfChildSearch.Value = "";
                BindChildData((GridView)sender);
            }
        }

        protected void gvMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //if (gvMaster.Rows[e.NewSelectedIndex].FindControl("pnlChild") != null)
            //    gvMaster.Rows[e.NewSelectedIndex].FindControl("pnlChild").Visible = !gvMaster.Rows[e.NewSelectedIndex].FindControl("pnlChild").Visible;
        }

        protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
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
                    if (e.Row.FindControl("ddl_TaxRate2") != null)
                    {
                        //綁定業務組下拉選單
                        ((DropDownList)e.Row.FindControl("ddl_TaxRate2")).DataSource = CreateTaxRateTable();
                        ((DropDownList)e.Row.FindControl("ddl_TaxRate2")).DataTextField = "Items";
                        ((DropDownList)e.Row.FindControl("ddl_TaxRate2")).DataValueField = "Items";
                        ((DropDownList)e.Row.FindControl("ddl_TaxRate2")).SelectedValue = TTaxRate; //顯示編輯前的原值
                        ((DropDownList)e.Row.FindControl("ddl_TaxRate2")).DataBind();
                    }
                    int RI = e.Row.RowIndex + 1;
                    e.Row.Cells[6].Attributes.Add("onclick", "GetCustomer(" + RI.ToString() + ");return false;");
                    e.Row.Cells[6].Attributes.Add("style", "cursor: hand;");
                    e.Row.Cells[8].Attributes.Add("onclick", "GetDate(" + RI.ToString() + ");return false;");
                    e.Row.Cells[8].Attributes.Add("style", "cursor: hand;");
                    e.Row.Cells[9].Attributes.Add("onclick", "GetCase(" + RI.ToString() + ");return false;");
                    e.Row.Cells[9].Attributes.Add("style", "cursor: hand;");
                }
                else
                {
                    e.Row.Cells[15].Attributes.Add("onclick", "PrintOrder('" + e.Row.Cells[5].Text + "');return false;");
                    e.Row.Cells[15].Attributes.Add("style", "cursor: hand;");
                }
            }
            //傳統的Grid寫法, 這裡會執行但不發生作用????會不會是UpdatePanel造成的呢? 改到Dropdownlist的OnInit()去
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow || e.Row.RowType == DataControlRowType.Header)
            //{
            //    if (e.Row.FindControl("ddl_Department") != null)
            //    {
            //    ((DropDownList)e.Row.FindControl("ddl_Department")).DataSource = CreateDataTable();
            //    ((DropDownList)e.Row.FindControl("ddl_Department")).DataTextField = "Items";
            //    ((DropDownList)e.Row.FindControl("ddl_Department")).DataValueField = "Items";
            //    ((DropDownList)e.Row.FindControl("ddl_Department")).DataBind();
            //    }
            //}
        }

        protected void ddl_Department_OnInit(object sender, EventArgs e)
        {
            if (gvMaster.Controls[0].Controls[0].FindControl("ddl_Department") != null)
            {
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_Department")).DataSource = CreateDataTable();
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_Department")).DataTextField = "Items";
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_Department")).DataValueField = "Items";
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_Department")).DataBind();
            }
        }

        protected void ddl_TaxRate_OnInit(object sender, EventArgs e)
        {
            if (gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate") != null)
            {
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate")).DataSource = CreateTaxRateTable();
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate")).DataTextField = "Items";
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate")).DataValueField = "Items";
                ((DropDownList)gvMaster.Controls[0].Controls[0].FindControl("ddl_TaxRate")).DataBind();
            }
        }

        protected void gvChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) != 0)
                {

                    int RI = e.Row.RowIndex + 1;
                    e.Row.Cells[2].Attributes.Add("onclick", "GetProduct(" + RI.ToString() + ",this);return false;");
                    e.Row.Cells[2].Attributes.Add("style", "cursor: hand;");
                }
            }
        }

        protected void CompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsMaster.SelectParameters[0].DefaultValue = CompanyList.SelectedItem.ToString();
            BindData();
        }

        /// <summary>
        /// 將公司名稱綁定到DataSet
        /// </summary>
        public void BindCompanyOrder()
        {
            DataSet ds = bll.GetCompanyList("","");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string s = ds.Tables[0].Rows[i]["Company"].ToString();
                CompanyList.Items.Add(new ListItem(s, ds.Tables[0].Rows[i]["Company"].ToString()));
            }
            CompanyList.DataBind();
        }
    }
}