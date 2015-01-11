<%@ Page Title="" Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>关于我</title>
    <link href="css/about.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="about_form">
        <div class="about_me">
            <img src="images/psbQ6ELMYU5.jpg" />
            <h3>基本资料</h3>
            <label>
                站 名：Share Once</label><br />
            <label>译 名：分享一下</label>
            <br />
            <label>家 乡：河南焦作</label>
            <br />
            <label>
                简 介：好咖啡要和朋友一起品尝，好机会也要和朋友一起分享</label>
            <br />

            <h3>联系我们</h3>
            <label>
                    QQ：1406046087</label><br />
            <label>
                E-mail: LABELNET@outlook.com</label><br />
        </div>
    </div>
</asp:Content>

