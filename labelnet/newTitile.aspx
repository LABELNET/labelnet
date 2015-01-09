<%@ Page Title="" Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="newTitile.aspx.cs" Inherits="newTitile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>最新文章</title>
    <link href="css/userform.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%
        
        List<titleModel> list = titleBLL.selectTitle();
        int count = list.Count;
        if (count >= 4)
        {
            for (int i = 1; i <= 4; i++)
            {
                titleModel tm = list[count - i];
                Response.Write("<div class='user_form'>");
                Response.Write("  <div class='form_date'>");
                Response.Write("<a href='detaile.aspx?id="+tm.Tid+"&state="+tm.Tstate+"'>" + tm.Tname + "</a> ");
                Response.Write("<label id='lb_date'>" + tm.Tdate + "</label>");
                Response.Write("</div>");
                Response.Write("<img src='" + tm.Timage + "'/>");
                Response.Write("<div class='form_body'>");
                Response.Write("<p>" + tm.Tbody + "</p>");
                Response.Write("<p> ……</p> ");
                Response.Write("<label>作者:" + tm.Tadmin + " | 分类：" + tm.Tfenlei + " | 标签：" + tm.Tlabel + "</label>");
                Response.Write("<a href='detaile.aspx?id=" + tm.Tid + "&state=" + tm.Tstate + "'>阅读全文</a>");
                Response.Write("</div>");
                Response.Write("</div>");
            }
        }
        else
        {
            int co = count % 4;
            for (int i = 1; i <= co; i++)
            {
                titleModel tm = list[co - i];
                Response.Write("<div class='user_form'>");
                Response.Write("  <div class='form_date'>");
                Response.Write("<a href='detaile.aspx?id=" + tm.Tid + "&state=" + tm.Tstate + "'>" + tm.Tname + "</a> ");
                Response.Write("<label id='lb_date'>" + tm.Tdate + "</label>");
                Response.Write("</div>");
                Response.Write("<img src='" + tm.Timage + "'/>");
                Response.Write("<div class='form_body'>");
                Response.Write("<p>" + tm.Tbody + "</p>");
                Response.Write("<p> ……</p> ");
                Response.Write("<label>作者:" + tm.Tadmin + " | 分类：" + tm.Tfenlei + " | 标签：" + tm.Tlabel + "</label>");
                Response.Write("<a href='detaile.aspx?id=" + tm.Tid + "&state=" + tm.Tstate + "'>阅读全文</a>");
                Response.Write("</div>");
                Response.Write("</div>");
            }
        }
    %>
</asp:Content>

