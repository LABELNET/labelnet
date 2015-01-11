using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class detaile : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         int   id = Convert.ToInt32(Request.QueryString["id"]);
          int  state = Convert.ToInt32(Request.QueryString["state"]);
            if (state == 1)
            {
                Session["detalie"] = resBLL.selectRes(id);
            }
            else
            {
                Session["detalie"] = titleBLL.selectTitle(id);
            }
            Session["detalie_plun"] = plunBLL.selectPlun(id, state);
        }
    }

    protected void btn_plun_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        int state = Convert.ToInt32(Request.QueryString["state"]);
        string str = tb_body_plun.Text.Trim().ToString();
        if (str != "")
        {
            plunModel pm = new plunModel();
            pm.Pbody = str;
            pm.Pdate = DateTime.Now.ToLongDateString();
            pm.Ptid = id;
            pm.Pstate = state;
            if (plunBLL.addPlun(pm))
            {
                Session["plunList"] = plunBLL.selectPlun();
                Session["detalie_plun"] = plunBLL.selectPlun(id, state);
                Response.Redirect("detaile.aspx?id=" + id + "&state=" + state + "");
            }
        }

    }
}