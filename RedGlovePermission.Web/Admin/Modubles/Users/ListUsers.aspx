<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Modubles.Users.ListUsers" %>
<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=ResourceManager.GetString("ListUsers_Title_Name")%></title>
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
            <%=ResourceManager.GetString("ListUsers_Title_Name")%></div>
    </div>
    <asp:UpdatePanel ID="CustomPanel1" runat="server">
        <ContentTemplate>
            <div id="title" class="childtoolbar">
                <div class="rowdiv" style="margin-left: 3px;">
                    <%=ResourceManager.GetString("ListUsers_Lab_4")%>:</div>
                <div class="rowdiv">
                    <asp:DropDownList ID="GroupList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="GroupList_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="gv">
                <asp:GridView ID="UserList" runat="server" DataKeyNames="UserID" CssClass="Grid"
                    OnRowCommand="UserList_RowCommand" OnRowDataBound="UserList_RowDataBound"
                    PageSize="15"　AutoGenerateColumns="False" 
                    AllowSorting="True" AllowPaging="True" OnPageIndexChanging="UserList_PageIndexChanging" 
                    OnRowCancelingEdit="UserList_RowCancelingEdit"
                    OnRowEditing="UserList_RowEditing" OnRowUpdating="UserList_RowUpdating"
                    onrowcreated="UserList_RowCreated" >
                    <FooterStyle CssClass="GridFooter" />
                    <RowStyle CssClass="Row" />
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="編號" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="用戶名">
                            <ItemTemplate>
                                <asp:HyperLink ID="link_name" runat="server" NavigateUrl='<%# Eval("UserID", "ViewUserPage.aspx?uid={0}") %>'
                                    Text='<%# Eval("UserName") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用戶密碼">
                            <ItemTemplate>
                                <asp:Label ID="Lab_Password" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_password" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text=''></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用戶角色">
                            <ItemTemplate>
                                <asp:Label ID="Lab_RoleName" runat="server" Text='<%# ResourceManager.GetString(Eval("RoleName").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_roleid" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("RoleID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用戶組">
                            <ItemTemplate>
                                <asp:Label ID="Lab_GroupName" runat="server" Text='<%# ResourceManager.GetString(Eval("GroupName").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_usergroup" Width="120" MaxLength="30" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("UserGroup") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="狀態">
                            <ItemTemplate>
                                <asp:Label ID="Lab_state" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_status" Width="20" MaxLength="1" CssClass="inputbox" runat="server"
                                    Text='<%# Eval("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="創建時間" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="最後一次登錄時間" DataField="LastLoginTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_edit")%>' CommandArgument='<%# Eval("UserID")%>'></asp:LinkButton>
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
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_delete")%>' CommandArgument='<%# Eval("UserID")%>'></asp:LinkButton>
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
