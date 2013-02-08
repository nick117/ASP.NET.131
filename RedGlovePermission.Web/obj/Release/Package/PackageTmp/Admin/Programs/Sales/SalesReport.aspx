<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Basic.SalesReport" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("SalesReport_Title_name")%></title>
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css" rel="stylesheet" type="text/css" />
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/GridView.css" rel="stylesheet" type="text/css" />

    <script src="../../../Inc/Script/pub.js" type="text/javascript"></script>

    <script type="text/javascript">

        //新增資料合法性檢查
        function CheckAdd() {
            var ret = true;

            if ($id("txt_Name").value == "") {
                alert('<%=ResourceManager.GetString("Pub_Msg_V_1")%>');
                ret = false;
            }
            else if ($id("txt_ID").value == "") {
                alert('<%=ResourceManager.GetString("Pub_Msg_V_0") %>');
                ret = false;
            }
            return ret;
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divToolBar" class="topBar">
        <div class="toolBar">
        </div>
        <div class="moduleName">
            <%=ResourceManager.GetString("SalesReport_Title_name")%></div>
    </div>
    <div id="title" class="childtoolbar">
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("SalesReport_Lab_0")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_Customer" Width="120" MaxLength="30" CssClass="inputbox" runat="server" onclick="window.open('../../Tools/Customers.aspx?TextBoxId=Ctxt_Customer', '','height=550,width=750,status=no,toolbar=no,menubar=no,location=no', '');" ></asp:TextBox> -->
            <asp:TextBox ID="txt_Customer1" Width="120" MaxLength="30" CssClass="inputbox" runat="server" onclick="window.open('../../Tools/Customers.aspx?TextBoxId=Ctxt_Customer1', '','height=550,width=750,status=no,toolbar=no,menubar=no,location=no', '');" ></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("SalesReport_Lab_2")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_Date" Width="120" MaxLength="30" CssClass="inputbox" runat="server" onclick="window.open('../../Tools/Calendar.aspx?TextBoxId=Btxt_Date', '', 'height=315,width=350,status=no,toolbar=no,menubar=no,location=no', '');"></asp:TextBox> -->
            <asp:TextBox ID="txt_Date1" Width="120" MaxLength="30" CssClass="inputbox" runat="server" onclick="window.open('../../Tools/Calendar.aspx?TextBoxId=Btxt_Date1', '', 'height=315,width=350,status=no,toolbar=no,menubar=no,location=no', '');"></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 5px; line-height: 30px;">
            <asp:Button ID="btn_query" class="button" runat="server" Text=" 查 詢 " OnClick="btn_query_Click" /></div>
        <div id="GridViewMsg" style="padding: 5px;" runat="server"></div>
    </div>
<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        DisplayToolbar="True"/>
    </form>
</body>
</html>
