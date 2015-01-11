<%@ Page Title="" Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="newRes.aspx.cs" Inherits="newRes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>实用资源</title>
<link href="css/userform.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%
        
        List<resModel> list = resBLL.selectRes();
        int count = list.Count;
        if (count >= 4)
        {
            for (int i = 1; i <=4; i++)
            {
                resModel rm = list[count - i];
                Response.Write("<div class='user_form'>");
                Response.Write("  <div class='form_date'>");
                Response.Write("<a href='detaile.aspx?id=" + rm.Rid + "&state="+rm.Rstate+"'>Share Once</a> ");
                Response.Write("<label id='lb_date'>" + rm.Rdate+ "</label>");
                Response.Write("</div>");
                Response.Write("<img src='" + rm.Rimage + "'/>");
                Response.Write("<div class='form_body'>");
                Response.Write("<p>" + rm.Rbody + "</p>");
                Response.Write("<p> ……</p> ");
                Response.Write("<label>作者:" + rm.Radmin + " | 分类：" + rm.Rfenlei + " | 标签：实用资源</label>");
                Response.Write("<a href='detaile.aspx?id=" + rm.Rid + "&state=" + rm.Rstate + "'>阅读全文</a>");
                Response.Write("</div>");
                Response.Write("</div>");
            }
        }
        else
        {
            int co = count % 4;
            for (int i = 1; i <=co; i++)
            {
                resModel rm = list[count - i];
                Response.Write("<div class='user_form'>");
                Response.Write("  <div class='form_date'>");
                Response.Write("<a href='detaile.aspx?id=" + rm.Rid + "&state=" + rm.Rstate + "'>Share Once</a> ");
                Response.Write("<label id='lb_date'>" + rm.Rdate + "</label>");
                Response.Write("</div>");
                Response.Write("<img src='" + rm.Rimage + "'/>");
                Response.Write("<div class='form_body'>");
                Response.Write("<p>" + rm.Rbody + "</p>");
                Response.Write("<p> ……</p> ");
                Response.Write("<label>作者:" + rm.Radmin + " | 分类：" + rm.Rfenlei + " | 标签：实用资源</label>");
                Response.Write("<a href='detaile.aspx?id=" + rm.Rid + "&state=" + rm.Rstate + "'>阅读全文</a>");
                Response.Write("</div>");
                Response.Write("</div>");
            }
        }
    %>
</asp:Content>

