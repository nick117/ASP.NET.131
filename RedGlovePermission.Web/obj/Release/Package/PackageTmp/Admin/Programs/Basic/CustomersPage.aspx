﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomersPage.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Basic.CustomersPage" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("CustomersPage_Title_name")%></title>
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
            <%=ResourceManager.GetString("CustomersPage_Title_name")%></div>
    </div>
    <asp:UpdatePanel ID="CustomPanel1" runat="server">
        <ContentTemplate>
            <div id="title" class="childtoolbar">
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CustomersPage_Lab_0")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_ID" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CustomersPage_Lab_1")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" CssClass="inputbox" runat="server"></asp:TextBox></div>
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("CustomersPage_Lab_2")%>:</div>
                <div class="rowdiv">
                    <asp:TextBox ID="txt_Address" Width="300" MaxLength="72" CssClass="inputbox" runat="server"></asp:TextBox></div>                 
                <div class="rowdiv" style="margin-left: 5px; line-height: 30px;">
                    <asp:Button ID="btn_add" class="button" runat="server" Text=" 新 增 " OnClick="btn_add_Click" /></div>
                <div class="rowdiv" style="margin-left: 5px; line-height: 30px;">
                    <asp:Button ID="btn_query" class="button" runat="server" Text=" 查 詢 " OnClick="btn_query_Click" /></div>
            </div>
            <div class="gv">
                <asp:GridView ID="CustomersLists" runat="server" DataKeyNames="MA001" CssClass="Grid"
                    AllowSorting="True" OnRowCommand="CustomersLists_RowCommand" OnRowDataBound="CustomersLists_RowDataBound"
                    AllowPaging="True" OnPageIndexChanging="CustomersLists_PageIndexChanging" PageSize="15"
                    AutoGenerateColumns="False" OnRowCancelingEdit="CustomersLists_RowCancelingEdit"
                    OnRowEditing="CustomersLists_RowEditing" OnRowUpdating="CustomersLists_RowUpdating"
                    OnRowCreated="CustomersLists_RowCreated">
                    <pagersettings mode="NumericFirstLast"
                          position="Bottom"           
                          pagebuttoncount="10"/>
                    <FooterStyle CssClass="GridFooter" />
                    <RowStyle CssClass="Row" />
                    <Columns>
                        <asp:BoundField DataField="MA001" HeaderText="編號" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Lab_name" runat="server" Text='<%# Eval("MA002") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_name" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("MA002") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="送貨地址">
                            <ItemTemplate>
                                <asp:Label ID="Lab_address" runat="server" Text='<%# Eval("MA027") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_address" Width="300" MaxLength="72" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("MA027") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_edit")%>' CommandArgument='<%# Eval("MA001")%>'></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btn_update" runat="server" CausesValidation="True" CommandName="Update"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_update")%>'></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="btn_cancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_cancel")%>'></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_del" runat="server" CausesValidation="False" CommandName="Del"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_delete")%>' CommandArgument='<%# Eval("MA001")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="HeadingCell" />
                    <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
                </asp:GridView>
                <div id="GridViewMsg" style="padding: 5px;" runat="server">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
