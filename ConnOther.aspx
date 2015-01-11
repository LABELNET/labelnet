<%@ Page Title="" Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="ConnOther.aspx.cs" Inherits="ConnOther" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>给我留言</title>
    <link href="css/connother.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="liuyan_form">
        <div class="liuyan_top">
            <img src="images/psbQ6ELMYU5.jpg" />
            <label>欢迎留言，留下你的足迹！</label>
            <img src="images/zuji.png" style="float: right" />
        </div>
        <div class="liuyan_add">
            <asp:TextBox ID="tb_conn_liuyan" runat="server" Height="60px" Width="90%" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btn_liuyan" runat="server" Text="留言" OnClick="btn_liuyan_Click" />
        </div>
        <hr />
        <%
            List<plunModel> liuyanlist = (List<plunModel>)Session["liuyan"];
            int count = liuyanlist.Count;
            if (count > 0)
            {
                if (count >= 8)
                {
                    for (int i = 1; i <= 8; i++)
                    {
                        plunModel pm = liuyanlist[count - i];
                        Response.Write("<div class='liuyan_body'>");
                        Response.Write("<img src=" + pm.Pturn + " />");
                        Response.Write("<p>" + pm.Pbody + "</p>");
                        Response.Write("<label>" + pm.Pdate + "</label>");
                        Response.Write("</div>");
                    }
                }
                else
                {
                    for (int i = count % 8 - 1; i >= 0; i--)
                    {
                        plunModel pm = liuyanlist[i];
                        Response.Write("<div class='liuyan_body'>");
                        Response.Write("<img src=" + pm.Pturn + " />");
                        Response.Write("<p>" + pm.Pbody + "</p>");
                        Response.Write("<label>" + pm.Pdate + "</label>");
                        Response.Write("</div>");
                    }
                }
            }
            else
            {
                Response.Write("<p style='font-family: '楷体';coloe:red;'>暂无留言</p>");
            }
        %>
    </div>
</asp:Content>

