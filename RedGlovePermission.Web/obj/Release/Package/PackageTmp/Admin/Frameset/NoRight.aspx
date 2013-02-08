<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoRight.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Frameset.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>歡迎光臨</title>
    <link href="../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="formNoRight" runat="server">
    <div style="width: 700px; font-size: 14px; line-height: 22px; margin: 10px">
        <h1 class="style1">
        <b>沒有此功能操作權限!</h1>
        <br />
        如有需要, 請聯絡...<br />
        維護人員 : Nick.Lee
            <br />
            分機 : 5338
            <br />
            E-mail : <a href="mailto:nick.lee@goldjoint.com.tw" target="_blank">nick.lee@goldjoint.com.tw</a>
            <br />
            公司網址:<a href="http://www.gold-joint.com" target="_blank">http://www.gold-joint.com</a><br />
            服務網址:<a href="http://EIP" target="_blank">http://EIP</a></b></div>
    </form>
</body>
</html>
