<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_fabuRes.aspx.cs" Inherits="admin_fabuRes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/fabu.css" rel="stylesheet" />
    <script src="js/jquery.mousewheel.js"></script>
    <title>发布资源</title>
</head>
<body>
    <div class="top_label">
        <asp:Label ID="lb_user" runat="server" Text="当前用户" ForeColor="#FF3300"></asp:Label>
    </div>

    <div id="top">
        <img src="images/houtai_logo.png" />
        <label>分享后台管理</label>

        <div id="daohang">
           <img src="images/logo.png" />
            <ul>
                <li><a href="admin_fabuTitile.aspx">发布文章</a></li>
                <li><a href="admin_fabuRes.aspx">发布资源</a></li>
            </ul>
        </div>
    </div>
    <form id="fabuRes_form" runat="server">
        <label>发布资源信息</label>
     
             <hr />
     分&nbsp;&nbsp;&nbsp;类：<br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:ListBox ID="list_box" runat="server">
            <asp:ListItem Selected="True">.NET</asp:ListItem>
            <asp:ListItem>Java</asp:ListItem>
            <asp:ListItem>android</asp:ListItem>
            <asp:ListItem>杂谈</asp:ListItem>
            <asp:ListItem>科技普及</asp:ListItem>
            <asp:ListItem>C++</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>趣文</asp:ListItem>
            <asp:ListItem>笑话</asp:ListItem>
        </asp:ListBox><br /><br />
           资源介绍：
           <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="tb_body_res" runat="server" Height="150px" Width="300px" TextMode="MultiLine"></asp:TextBox><br />
           <br />
          添加图片：&nbsp;<asp:FileUpload ID="file_upload" runat="server" />
           <br /><br />
           <hr />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="btn_fabuRes" runat="server" Text="发表资源" BackColor="WhiteSmoke" Width="100px" Height="40px" BorderStyle="Solid" OnClick="btn_fabuRes_Click"/>
             <div class="form_btn_zhuxiao">
         <asp:Button ID="btn_Reszhuxiao" runat="server" Text="安全退出" BackColor="YellowGreen" ForeColor="White" Width="100px" Height="40px" OnClick="btn_Reszhuxiao_Click"/>
       </div>
    </form>
       <div id="footer_top"></div>
    <footer>
        <div class="footer_div">Copyright © 2015 LABELNET. All rights reserved.</div>
    </footer>
</body>
</html>
