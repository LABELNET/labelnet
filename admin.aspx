<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/fabu.css" rel="stylesheet" />
    <script src="js/jquery.mousewheel.js"></script>
    <title>管理员登陆</title>

</head>
<body>
    <div id="top">
        <img src="images/houtai_logo.png" />
        <label>分享后台管理</label>

        <div id="daohang">
            <img src="images/logo.png" />
        
            <label>精彩分享，快乐分享！</label>  
            
        </div>
    </div>
    <form id="login_form" runat="server">
        <div style="width: 447px">
            <asp:Label ID="lb_aname" runat="server" Text="用户名:" Font-Size="Larger" ForeColor="Black" />
            <asp:TextBox ID="tb_aname" runat="server" Font-Size="Larger" Height="19px" Width="167px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lb_apass" runat="server" Text="密   码 :" Font-Size="Larger" ForeColor="Black" />
            <asp:TextBox ID="tb_apass" runat="server" Font-Size="Larger" Height="19px" Width="167px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
            <br />
            <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btn_login" runat="server" Text="登录" BackColor="White" Font-Size="Larger" ForeColor="Black" Height="32px" Width="80px" BorderStyle="Solid" OnClick="btn_login_Click" />
        </div>
    </form>
       <div id="footer_top"></div>
    <footer>
        <div class="footer_div">Copyright © 2015 LABELNET. All rights reserved.</div>
    </footer>
</body>
</html>
