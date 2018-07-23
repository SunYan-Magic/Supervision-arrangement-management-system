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
// 下载于www.51aspx.com
public partial class Admin_ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null )
        {
            Response.Redirect("~/login.html");
        }
        lbtnupd.Attributes.Add("onclick", "window.showModalDialog('SetTeacherPwd.aspx',window,'center=yes;help=no;status=no;dialogheight:250px;dialogwidth:350px;scroll:yes');");
    }    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            role_User myUser = new role_User();
            bool result = myUser.AdminPwd(tbpwd.Text.Trim(), tbrepwd.Text.Trim(), Session["admin"].ToString());
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

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
