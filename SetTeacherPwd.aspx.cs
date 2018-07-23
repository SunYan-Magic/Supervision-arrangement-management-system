using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetTeacherPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            role_User myUser = new role_User();
            bool result = myUser.SetStudentPwd(lspw.Text.Trim(), lscode.Text.Trim());
            if (result)
            {
                Response.Write("<script>alert('老师密码修改成功')</script>");
                Response.Write("<script>window.close();</script>"); 
            }
            else
            {
                Response.Write("<script>alert('老师密码修改失败')</script>");
            }
        }
    }
}