using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_fabuRes : System.Web.UI.Page
{
    private string username = null;
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

    protected void btn_fabuRes_Click(object sender, EventArgs e)
    {
       
            if (file_upload.HasFile)
            {
                DateTime dt = DateTime.Now;
                string filename = dt.ToFileTime().ToString();
                file_upload.SaveAs(Server.MapPath("image/" + filename + ".jpg"));
                resModel rm = new resModel();
                rm.Rfenlei = list_box.SelectedValue.ToString();
                rm.Rbody = tb_body_res.Text.Trim().ToString();
                rm.Radmin = username;
                rm.Rdate = DateTime.Now.ToLongDateString();
                rm.Rimage = "image/" + filename + ".jpg";
                if (resBLL.addRes(rm))
                {
                    Response.Redirect("admin_fabuRes.aspx");
                }
            }
        
        
    }
    protected void btn_Reszhuxiao_Click(object sender, EventArgs e)
    {
    
            Session.Abandon();
            //返回用户主页
            Response.Redirect("index.aspx");
     
    }

}