<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Basic.Case" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("Case_Title_name")%></title>
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
            <%=ResourceManager.GetString("Case_Title_name")%></div>
    </div>
            <div id="title" class="childtoolbar">
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CasePage_Lab_0")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_CaseNo" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CasePage_Lab_1")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_CaseDescription" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CasePage_Lab_2")%>:</div>
                <div class="rowdiv">
                    <asp:DropDownList ID="ddl_Department" runat="server" Width="10em">
                </asp:DropDownList></div>
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CasePage_Lab_3")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_MA001" Width="120" MaxLength="30" CssClass="inputbox" runat="server" onclick="window.open('../../Tools/Customers.aspx?TextBoxId=Ctxt_MA001', '','height=550,width=400,status=no,toolbar=no,menubar=no,location=no', '');" ></asp:TextBox></div>
                <div class="rowdiv" style="margin-left: 5px; line-height: 30px;">
                    <asp:Button ID="btn_query" class="button" runat="server" Text=" 查 詢 " OnClick="btn_query_Click" /></div>
            </div>
            <div class="gv">
                <asp:GridView ID="CaseLists" runat="server" DataKeyNames="CaseNo" CssClass="Grid"
                    AllowSorting="True" OnRowCommand="CaseLists_RowCommand" OnRowDataBound="CaseLists_RowDataBound"
                    AllowPaging="True" OnPageIndexChanging="CaseLists_PageIndexChanging" PageSize="15"
                    AutoGenerateColumns="False" OnRowCancelingEdit="CaseLists_RowCancelingEdit"
                    OnRowEditing="CaseLists_RowEditing" OnRowUpdating="CaseLists_RowUpdating"
                    OnRowCreated="CaseLists_RowCreated">
                    <pagersettings mode="NumericFirstLast"
                          position="Bottom"           
                          pagebuttoncount="10"/>
                    <FooterStyle CssClass="GridFooter" />
                    <RowStyle CssClass="Row" />
                    <Columns>
                        <asp:BoundField DataField="CaseNo" HeaderText="案件編號" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="案件名稱">
                            <ItemTemplate>
                                <asp:Label ID="Lab_CaseDescription" runat="server" Text='<%# Eval("CaseDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_CaseDescription" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("CaseDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業務組">
                            <ItemTemplate>
                                <asp:Label ID="Lab_Department" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_Department2" runat="server" Width="10em"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶編號">
                            <ItemTemplate>
                                <asp:Label ID="Lab_MA001" runat="server" Text='<%# Eval("MA001") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_MA001" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("MA001") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MA002" HeaderText="客戶簡稱" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="選取" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_sel" runat="server" CausesValidation="False" CommandName="sel"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_sel")%>' CommandArgument='<%# Eval("CaseNo")+","+Eval("CaseDescription")+","+Eval("Department")+","+Eval("MA001")+","+Eval("MA002")+","+Eval("MA027") %>'></asp:LinkButton>
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
