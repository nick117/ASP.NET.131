<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasePage.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Programs.Basic.CasePage" %>

<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ResourceManager.GetString("CasePage_Title_name")%></title>
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css" rel="stylesheet" type="text/css" />
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/GridView.css" rel="stylesheet" type="text/css" />

    <script src="../../../Inc/Script/pub.js" type="text/javascript"></script>

    <script type="text/javascript">

        //新增資料合法性檢查
        function CheckAdd() {
            var ret = true;

            if ($id("txt_CaseNo").value == "") {
                alert('<%=ResourceManager.GetString("Pub_Msg_V_1")%>');
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
            <%=ResourceManager.GetString("CasePage_Title_name")%></div>
    </div>
    <asp:UpdatePanel ID="CustomPanel1" runat="server">
        <ContentTemplate>
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
                    <asp:Button ID="btn_add" class="button" runat="server" Text=" 新 增 " OnClick="btn_add_Click" /></div>
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
                        <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_edit")%>' CommandArgument='<%# Eval("CaseNo")%>'></asp:LinkButton>
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
                                    Text='<%#ResourceManager.GetString("Pub_Lbtn_delete")%>' CommandArgument='<%# Eval("CaseNo")%>'></asp:LinkButton>
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
    <script type="text/javascript">
        function is_null(obj) {
            if (typeof (obj) == 'undefined' || obj == null)
                return true;
            return false;
        }
        function GetCustomer(mySelect) {
            var table = document.getElementById("<%=CaseLists.ClientID %>");
            if (!is_null(table.rows[mySelect].cells[3]))
                if (!is_null(table.rows[mySelect].cells[3].getElementsByTagName("input")[0]))
                    window.open('../../Tools/Customers.aspx?TextBoxId=ACaseLists,3,4,' + mySelect, '', 'height=530,width=400,status=no,toolbar=no,menubar=no,location=no', '');
        }
  </script>
</body>
</html>
