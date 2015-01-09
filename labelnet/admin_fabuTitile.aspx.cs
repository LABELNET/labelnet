using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_fabu : System.Web.UI.Page
{
    private string username = null;
    //初始页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            username = Session["user"].ToString();
            lb_user.Text = "欢迎您！" + username;
        }
        catch
        {
            Response.Redirect("admin.aspx");
        }
    }
    //发布文章
    protected void btn_fabutitle_Click(object sender, EventArgs e)
    {
       
            if (file_upload.HasFile)
            {
                DateTime dt = DateTime.Now;
                string filename = dt.ToFileTime().ToString();
                file_upload.SaveAs(Server.MapPath("image/" + filename + ".jpg"));
                titleModel tm = new titleModel();
                tm.Tname = tb_title_name.Text.Trim().ToString();
                tm.Tfenlei = list_box.SelectedValue.ToString();
                tm.Tbody = tb_body_title.Text.Trim().ToString();
                tm.Tlabel = tb_label.Text.Trim().ToString();
                tm.Timage = "image/" + filename + ".jpg";
                tm.Tdate = DateTime.Now.ToLongDateString();
                tm.Tadmin = username;
                if (titleBLL.addTitle(tm))
                {
                    Response.Redirect("admin_fabuTitile.aspx");
                }
                else
                {
                    Response.Write("<script>window.alert('发布失败')</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('选择添加图片')</script>");
            }
    
    }
    //用户注销
    protected void btn_titlezhuxiao_Click(object sender, EventArgs e)
    {
      
            Session.Abandon();
            //转到用户页面
            Response.Redirect("index.aspx");
     
    }

}