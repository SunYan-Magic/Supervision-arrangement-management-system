using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_timemanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
        if (!IsPostBack)
        {
            BindData();
           
        }
        lbtnadd.Attributes.Add("onclick", "window.showModalDialog('addtime.aspx',window,'center=yes;help=no;status=no;dialogheight:300px;dialogwidth:310px;scroll:yes');");
       // lbtnupd.Attributes.Add("onclick", "window.showModalDialog('updatetime.aspx',window,'center=yes;help=no;status=no;dialogheight:200px;dialogwidth:400px;scroll:yes');");
       /// BindData();////
    }
    private void BindData()
    {
        time Time = new time();
        DateTime T1, T2;
        T1 = Convert.ToDateTime(Time.GetStartTime());
        T2 = Convert.ToDateTime(Time.GetEndTime());
        date1.Text = T1.ToString("yyyy-MM-dd");
        date2.Text = T2.ToString("yyyy-MM-dd");
    }
    protected void lbtnadd_Click(object sender, EventArgs e)
    {

    }
   
    protected void lbtnrefresh_Click(object sender, EventArgs e)
    {
        BindData();
    }
}