<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RedGlovePermission.Web.Register" %>
<%@ Import Namespace="RedGlove.Core.Languages" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=ResourceManager.GetString("Register_Title_Name")%></title>
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/GridView.css"
        rel="stylesheet" type="text/css" />

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
            <%=ResourceManager.GetString("Register_Title_name")%></div>
    </div>
    <asp:UpdatePanel ID="CustomPanel1" runat="server">
        <ContentTemplate>
            <table width="500" border="0" align="center" cellpadding="0" cellspacing="2" style="margin-top: 50px;">
                <tr>
                    <td width="82" style="height: 30px; line-height: 30px;">
                        <div align="right">
                            <%=ResourceManager.GetString("Register_Lab_0")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_username" CssClass="inpubbox" runat="server"></asp:TextBox>
                    </td>
                    <td width="222">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right" style="height: 30px; line-height: 30px;">
                            <%=ResourceManager.GetString("Register_Lab_1")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_password" CssClass="inpubbox" runat="server" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right" style="height: 30px; line-height: 30px;">
                            <%=ResourceManager.GetString("Register_Lab_2")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_password2" CssClass="inpubbox" runat="server" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right" style="height: 30px; line-height: 30px;">
                            <%=ResourceManager.GetString("Register_Lab_3")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_question" CssClass="inpubbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right" style="height: 30px; line-height: 30px;">
                            <%=ResourceManager.GetString("Register_Lab_4")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_answer" CssClass="inpubbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right" style="height: 30px; line-height: 30px;">
                            <%=ResourceManager.GetString("Register_Lab_5")%></div>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txt_verifycode" CssClass="inpubbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="right">
                        </div>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btn_reg" runat="server" Text="送出" Height="37px" Width="94px" OnClick="btn_reg_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
