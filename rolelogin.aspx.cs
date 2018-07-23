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
using System.Data.SqlClient;
// 下载于www.51aspx.com
public partial class role_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request["yonghuming"].ToString();
        string pwd = Request["mima"].ToString();
        string type = Request["type"].ToString();
        role_User myUser = new role_User();
        if (type == "1")
        {
            bool result = myUser.StudentLogin(name, pwd);
            if (result)
            {
                Session.Timeout = 120;
                Session["user"] = name;
                Response.Write("22");
            }
            else
            {
                Response.Write("aa");
            }
        }
        else
        {
            if (type == "2")
            {
                bool result = myUser.AdminLogin(name, pwd);
                if (result)
                {
                    Session.Timeout = 120;
                    Session["admin"] = name;
                    Response.Write("11");
                }
                else
                {
                    Response.Write("ss");
                }
            }
        }

    }
}
