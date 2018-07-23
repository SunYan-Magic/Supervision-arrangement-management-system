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

public partial class Admin_addclass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
    }
    protected void lbtnadd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Class myClass = new Class();
            bool add = myClass.AddClass(bjname.Text.Trim(), bjcode.Text.Trim(), bjnum.Text.Trim());
            if (add)
            {
                bjcode.Text = bjname.Text=bjnum.Text   = "";
                Response.Write("<script>alert('专业添加成功！')</script>");
                Response.Write("<script>window.close();</script>");                
            }
            else
            {
                Response.Write("<script>alert('专业添加失败，请注意专业编码的正确性')</script>");
            }
        }
    }
}