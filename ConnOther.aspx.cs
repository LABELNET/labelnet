using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConnOther : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["liuyan"] = plunBLL.selectliuyan(-1);
        }
    }

    protected void btn_liuyan_Click(object sender, EventArgs e)
    {
        string liuyanstr = tb_conn_liuyan.Text.Trim().ToString();
        Random rm = new Random();
        int i = rm.Next(1, 11);
        string txpath = "images/touxiang" + i + ".jpg";
        if (liuyanstr != "")
        {
            plunModel pm = new plunModel();
            pm.Pbody = liuyanstr;
            pm.Pturn = txpath;
            pm.Pdate = DateTime.Now.ToLongDateString();
            pm.Pstate = -1;
            if (plunBLL.addliuyan(pm))
            {
                Response.Redirect("ConnOther.aspx");
            }
        }
        else
        {
            tb_conn_liuyan.Text = "请输入内容";
        }
    }
}