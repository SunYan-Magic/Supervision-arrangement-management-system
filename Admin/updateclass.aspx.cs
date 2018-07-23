using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_updateclass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
    }
    protected void lbtnupd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Class myClass = new Class();
            bool add = myClass.UpdateClass(int.Parse (classid.Text.Trim()), bjname.Text.Trim(), bjcode.Text.Trim(), bjnum.Text.Trim());
            if (add)
            {
                classid.Text = bjname.Text = bjcode.Text = bjnum.Text = "";
                Response.Write("<script>alert('专业修改成功！')</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('专业更新失败，请注意专业编码或者ID的正确性')</script>");
            }         
        }
    }
}