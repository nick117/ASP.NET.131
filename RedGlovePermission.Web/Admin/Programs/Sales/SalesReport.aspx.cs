using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

/**************************************
 * 模組：銷售資料查詢
 * 作者：Nick.Lee
 * 日期:2012-06-05
 * ***********************************/

namespace RedGlovePermission.Web.Admin.Programs.Basic
{
    public partial class SalesReport : CommonPage
    {
        //RedGlovePermission.BLL.Basic_System bllCode = new RedGlovePermission.BLL.Basic_System();
        RedGlovePermission.BLL.Customers bllCust = new RedGlovePermission.BLL.Customers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模組權限
                UserHandle.InitModule("Mod_SalesReport");
                if (!UserHandle.ValidationHandle("RGP_BROWSE"))
                {
                    Response.Redirect("~/Admin/Frameset/NoRight.aspx");
                }
                if (!IsPostBack)
                {
                    ////綁定業務組下拉選單
                    //ddl_Department.DataSource = CreateDataTable();
                    //ddl_Department.DataTextField = "Items";
                    //ddl_Department.DataValueField = "Items";
                    //ddl_Department.DataBind();
                    txt_Customer.Text = bllCust.GetFirst();
                    txt_Customer1.Text = bllCust.GetLast();

                    #region 語言加入
                    #endregion
                }
                else
                {
                    //load crystal report
                    ReportDocument Report = new ReportDocument();
                    Report.Load(Server.MapPath("../../Report/SalesReport.rpt"));
                    //this.CrystalReportSource1.Report.FileName = Server.MapPath("Sales_order.rpt");

                    TableLogOnInfo logOnInfo = new TableLogOnInfo();
                    logOnInfo.ConnectionInfo.ServerName = "USER-3924AC2E56";
                    logOnInfo.ConnectionInfo.DatabaseName = "MyData";
                    logOnInfo.ConnectionInfo.UserID = "sa";
                    logOnInfo.ConnectionInfo.Password = "Goldjoint123";
                    //对报表中的每个表进行循环 
                    for (int i = 0; i < Report.Database.Tables.Count; i++)
                    {
                        Report.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
                    }

                    //load param
                    //CrystalDecisions.Web.Parameter param = new CrystalDecisions.Web.Parameter();
                    //param.Name = "OrderID";
                    //param.DefaultValue = Request.QueryString["TextBoxId"].ToString().Trim();

                    //add param
                    //this.CrystalReportSource1.Report.Parameters.Add(param);
                    ParameterValues ParamValues = new ParameterValues();
                    ParameterDiscreteValue ParamValue = new ParameterDiscreteValue();
                    ParamValue.Value = txt_Customer.Text.Trim();
                    ParamValues.Add(ParamValue);
                    Report.DataDefinition.ParameterFields[2].ApplyCurrentValues(ParamValues);
                    ParamValue.Value = txt_Customer1.Text.Trim();
                    ParamValues.Add(ParamValue);
                    Report.DataDefinition.ParameterFields[3].ApplyCurrentValues(ParamValues);
                    ParamValue.Value = txt_Date.Text.Trim();
                    ParamValues.Add(ParamValue);
                    Report.DataDefinition.ParameterFields[0].ApplyCurrentValues(ParamValues);
                    ParamValue.Value = txt_Date1.Text.Trim();
                    ParamValues.Add(ParamValue);
                    Report.DataDefinition.ParameterFields[1].ApplyCurrentValues(ParamValues);

                    //bind
                    this.CrystalReportViewer1.ReportSource = Report;
                    //this.CrystalReportViewer1.ReportSourceID = this.CrystalReportSource1.ID;
                    //關閉左邊
                    //this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                    //強制安裝ActiveX
                    CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
                    this.CrystalReportViewer1.DataBind();
                }
            }
        }

        /// <summary>
        /// 取得業務組
        /// </summary>
        //protected DataTable CreateDataTable()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Items", typeof(string));
        //    RedGlovePermission.Model.Basic_System mdlCode = bllCode.GetCodeModel("SalesGroup");
        //    string[] ddl_Deparment_Items = mdlCode.Items.Split(',');
        //    foreach (string s in ddl_Deparment_Items)
        //    {
        //        dt.Rows.Add(s.Trim());
        //    }
        //    return dt;

        //}


        /// <summary>
        /// 查詢資料
        /// </summary>
        protected void btn_query_Click(object sender, EventArgs e)
        {

        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }


    }
}
