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


public partial class Admin_addteacher : System.Web.UI.Page
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
            teacher myteacher = new teacher();
            bool add = myteacher.AddTeacher(lsname.Text.Trim(), lscode.Text.Trim(),lstel.Text.Trim());
            if (add)
            {
                lsname.Text = lscode.Text = lstel.Text  = "";
                Response.Write("<script>alert('老师添加成功！')</script>");
                Response.Write("<script>window.close();</script>");
                
            }
            else
            {
                Response.Write("<script>alert('老师添加失败，请注意老师编码的正确性')</script>");
            }
        }
    }
}