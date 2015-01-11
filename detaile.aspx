<%@ Page Title="" Language="C#" MasterPageFile="~/user.master" AutoEventWireup="true" CodeFile="detaile.aspx.cs" Inherits="detaile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>信息详情</title>
    <link href="css/detaile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="detalie_form">
        <%
         int  state = Convert.ToInt32(Request.QueryString["state"]);
         titleModel tm = null;
         resModel rm = null;
         if (state == 1)
         {
             rm = (resModel)Session["detalie"];
             Response.Write("<div class='detalie_name'>");
             Response.Write("<img src='images/psbQ6ELMYU5.jpg' />");
             Response.Write("<label>Share  Once</label>");
             Response.Write("<p>" + rm.Rdate + "</p>");
             Response.Write("</div>");
             Response.Write("<div class='detalie_body'>");
             Response.Write("<img src=" + rm.Rimage + " />");
             Response.Write("<p>&nbsp;&nbsp;" + rm.Rbody + "</p>");
             Response.Write("</div>");
             Response.Write("<div class='detalie_buttom'>");
             Response.Write("<hr />");
             Response.Write("<label>作者:" + rm.Radmin + " | 分类：" + rm.Rfenlei + " | 标签：实用资源</label>");
             Response.Write("<hr />");
             Response.Write("</div>");
             Response.Write("");
         }
         else {
             tm = (titleModel)Session["detalie"];
             Response.Write("<div class='detalie_name'>");
             Response.Write("<img src='images/psbQ6ELMYU5.jpg' />");
             Response.Write("<label>"+tm.Tname+"</label>");
             Response.Write("<p>" + tm.Tdate + "</p>");
             Response.Write("</div>");
             Response.Write("<div class='detalie_body'>");
             Response.Write("<img src=" + tm.Timage + " />");
             Response.Write("<p>&nbsp;&nbsp;" + tm.Tbody + "</p>");
             Response.Write("</div>");
             Response.Write("<div class='detalie_buttom'>");
             Response.Write("<hr />");
             Response.Write("<label>作者:" + tm.Tadmin + " | 分类：" + tm.Tfenlei + " | 标签："+tm.Tlabel+"</label>");
             Response.Write("<hr />");
             Response.Write("</div>");
             Response.Write(""); 
         }
             %>
        <div class="detalie_plun">
              <%
                  List<plunModel> plunlist = (List<plunModel>)Session["detalie_plun"];
                          int count = plunlist.Count;
                          if (count > 0)
                          {
                              if (count >= 5)
                              {
                                  for (int i = 1; i <= 5; i++)
                                  {
                                      plunModel pm = plunlist[count - i];
                                      Response.Write("<img src=" + "images/psbQ6ELMYU5.jpg" + " style='width: 30px; height: 30px;' />");
                                      Response.Write("<Label style='float:right;font-size:12px;'>" + pm.Pdate + "</Label>&nbsp");
                                      Response.Write("<Label style='font-size:15px;'>" + pm.Pbody + "</Label><br/>");
                                      Response.Write("<hr/>");
                                  }
                              }
                              else
                              {
                                  for (int i = count % 5 - 1; i >= 0; i--)
                                  {
                                      plunModel pm = plunlist[i];
                                      Response.Write("<img src=" + "images/psbQ6ELMYU5.jpg" + " style='width: 30px; height: 30px;' />");
                                      Response.Write("<Label style='float:right;font-size:12px;'>" + pm.Pdate + "</Label>&nbsp");
                                      Response.Write("<Label style='font-size:15px;'>" + pm.Pbody + "</Label><br/>");
                                      Response.Write("<hr/>");
                                  }
                              }
                          }
                          else {
                              Response.Write("<Label style='font-size:15px;'>暂无评论</Label><br/>");
                          }
                        %>
            <hr />
        </div>

        <div class="detalie_addplun">
            <asp:TextBox ID="tb_body_plun" runat="server" Height="60px" Width="800px" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btn_plun" runat="server" Text="发表评论" OnClick="btn_plun_Click" />
        </div>

    </div>
</asp:Content>

