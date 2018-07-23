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

public partial class Teacher_ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( Session["user"] == null)
        {
            Response.Redirect("~/login.html");
        }
    }
    protected void ibtnok_Click(object sender, ImageClickEventArgs e)
    {
        role_User myUser = new role_User();
        bool result = myUser.StudentPwd(tbpwd.Text.Trim(), tbrepwd.Text.Trim(), Session["user"].ToString());
        if (result)
        {
            Response.Write("<script>alert('密码修改成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('密码输入错误')</script>");
        }
    }   
}