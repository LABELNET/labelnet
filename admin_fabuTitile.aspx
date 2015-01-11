<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_fabuTitile.aspx.cs" Inherits="admin_fabu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/fabu.css" rel="stylesheet" />
    <title>发布文章</title>
    <script src="js/jquery.mousewheel.js"></script>
</head>
<body>

    <div class="top_label">
        <asp:Label ID="lb_user" runat="server" Text="当前用户：" ForeColor="#FF3300"></asp:Label>
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

    <form id="fabutitle_form" runat="server">
        <label>发布文章信息</label>
        <hr />
        <div id="fabu_div">
            标&nbsp;&nbsp;&nbsp;题：<asp:TextBox ID="tb_title_name" runat="server"></asp:TextBox><br />
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
           </asp:ListBox><br />
            <br />
            文章内容：
           <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="tb_body_title" runat="server" Height="150px" Width="300px" TextMode="MultiLine"></asp:TextBox><br />
            <br />
            关键字：&nbsp;<asp:TextBox ID="tb_label" runat="server"></asp:TextBox><br />
            <br />
            <br />
            添加图片：&nbsp;<asp:FileUpload ID="file_upload" runat="server" />
            <br />
            <br />
            <hr />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="btn_fabutitle" runat="server" Text="发表文章" BackColor="White" Width="100px" Height="40px" OnClick="btn_fabutitle_Click"/>
            <div class="form_btn_zhuxiao">
                <asp:Button ID="btn_titlezhuxiao" runat="server" Text="注销退出" BackColor="YellowGreen" ForeColor="White" Width="100px" Height="40px" OnClick="btn_titlezhuxiao_Click"/>
            </div>
        </div>
    </form>
    <div id="footer_top"></div>
    <footer>
        <div class="footer_div">Copyright © 2015 LABELNET. All rights reserved.</div>
    </footer>

</body>
</html>
