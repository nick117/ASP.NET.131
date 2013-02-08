using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace RedGlovePermission.Web.Admin.Report
{
    public partial class Sales_OrderRPT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //load crystal report
                ReportDocument Report = new ReportDocument();
                Report.Load(Server.MapPath("Sales_order.rpt "));
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
                ParamValue.Value = Request.QueryString["TextBoxId"].ToString().Trim();
                ParamValues.Add(ParamValue);
                Report.DataDefinition.ParameterFields[0].ApplyCurrentValues(ParamValues);

                //bind
                this.CrystalReportViewer1.ReportSource = Report;
                //this.CrystalReportViewer1.ReportSourceID = this.CrystalReportSource1.ID;
                //關閉左邊
                this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                //強制安裝ActiveX
                CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
                this.CrystalReportViewer1.DataBind();
            }
        }
    }
}