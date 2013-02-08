<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="RedGlovePermission.Web.Admin.Frameset.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>歡迎光臨</title>
    <link href="../../Inc/Style/<%=Request.Cookies["UIStyle"].Value%>/css/indexControl.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formWelcome" runat="server">
    <div style="width: 700px; font-size: 14px; line-height: 22px; margin: 10px">
        <b>維護人員 : Nick.Lee
            <br />
            分機 : 5338
            <br />
            E-mail : <a href="mailto:nick.lee@goldjoint.com.tw" target="_blank">nick.lee@goldjoint.com.tw</a>
            <br />
            公司網址:<a href="http://www.gold-joint.com" target="_blank">http://www.gold-joint.com</a><br />
            服務網址:<a href="http://EIP" target="_blank">http://EIP</a><br />
            <br />
            愛地球加把勁 <a href="http://www.youtube.com/watch?v=lQ8nXN7z4ZU" target="_blank">http://www.youtube.com/watch?v=lQ8nXN7z4ZU</a><br />
            <br />
        </b><b>版本更新(Ver 1.0.0Beta)</b><br />
          <b>版權申明</b><br />
        &nbsp;&nbsp;&nbsp; 本系統完全開源，免費使用，也將會不斷完善更新.有什麼問題可發送郵件，如果您有好建議或意見，但說無妨，希望這個系统真能為您幫上點忙，那就是我們資訊部最開心的事了.
    </div>
    </form>
</body>
</html>
