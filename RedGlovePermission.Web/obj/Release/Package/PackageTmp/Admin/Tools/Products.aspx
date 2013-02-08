<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Basic.Products" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("Products_Title_name")%></title>
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css" rel="stylesheet" type="text/css" />
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/GridView.css" rel="stylesheet" type="text/css" />

    <script src="../../../Inc/Script/pub.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divToolBar" class="topBar">
        <div class="toolBar">
        </div>
        <div class="moduleName">
            <%=ResourceManager.GetString("Products_Title_name")%></div>
    </div>
    <div id="title" class="childtoolbar">
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("ProductsPage_Lab_0")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_ID" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("ProductsPage_Lab_1")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("ProductsPage_Lab_2")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_Spec" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 3px;">
            <%=ResourceManager.GetString("ProductsPage_Lab_3")%>:</div>
        <div class="rowdiv">
            <asp:TextBox ID="txt_Unit" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
        <div class="rowdiv" style="margin-left: 5px; line-height: 30px;">
            <asp:Button ID="btn_query" class="button" runat="server" Text=" 查 詢 " OnClick="btn_query_Click" /></div>
    </div>
    <div class="gv">
        <asp:GridView ID="ProductsLists" runat="server" DataKeyNames="MB001" CssClass="Grid"
            AllowSorting="True" OnRowCommand="ProductsLists_RowCommand" OnRowDataBound="ProductsLists_RowDataBound"
            AllowPaging="True" OnPageIndexChanging="ProductsLists_PageIndexChanging" PageSize="15"
            AutoGenerateColumns="False" OnRowCancelingEdit="ProductsLists_RowCancelingEdit"
            OnRowEditing="ProductsLists_RowEditing" OnRowUpdating="ProductsLists_RowUpdating"
            OnRowCreated="ProductsLists_RowCreated">
            <pagersettings mode="NumericFirstLast"
                    position="Bottom"           
                    pagebuttoncount="10"/>
            <FooterStyle CssClass="GridFooter" />
            <RowStyle CssClass="Row" />
            <Columns>
                <asp:BoundField DataField="MB001" HeaderText="編號" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="MB002" HeaderText="品名" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="MB003" HeaderText="規格" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="選取" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_sel" runat="server" CausesValidation="False" CommandName="sel"
                            Text='<%#ResourceManager.GetString("Pub_Lbtn_sel")%>' CommandArgument='<%# Eval("MB001")+","+Eval("MB002")+","+Eval("MB003")+","+Eval("MB004")%>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeadingCell" />
            <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
        </asp:GridView>
        <div id="GridViewMsg" style="padding: 5px;" runat="server">
        </div>
    </div>
    </form>
</body>
</html>
