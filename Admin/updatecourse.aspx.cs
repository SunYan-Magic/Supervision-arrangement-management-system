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

public partial class Admin_updatecourse : System.Web.UI.Page
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
            course myCourse = new course();
            bool add = myCourse.UpdateCourse(int.Parse(courseid.Text.Trim()), kcname.Text.Trim(), kccode.Text.Trim(),  bjcode.Text.Trim(),kcteacher.Text.Trim());
            if (add)
            {
                courseid.Text = kcname.Text = kccode.Text = kcteacher.Text = bjcode.Text = "";
                Response.Write("<script>alert('课程修改成功')</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('课程更新失败，请注意课程编码或者ID的正确性')</script>");
            }         
        }
    }
}