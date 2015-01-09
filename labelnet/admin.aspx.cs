using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        string aname=tb_aname.Text.Trim().ToString();
        string apass=tb_apass.Text.Trim().ToString();
        if(aname.Equals(""))
        {

        }
        else{
          if(apass.Equals(""))
          {
          }
          else
          {
                adminModel am = new adminModel();
                am.Aname = aname;
                am.Apass = apass;
                if (adminBLL.admin_Login(am))
                {
                    Session["user"] = aname;
                    Response.Redirect("admin_fabuTitile.aspx");
                }
                else
                {
                    Response.Write("<script>alert(登录失败);</script>");
                }
                    
          }
        }
      
    }
}