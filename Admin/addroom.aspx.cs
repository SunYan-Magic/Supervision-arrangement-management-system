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

public partial class Admin_addroom : System.Web.UI.Page
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
            room myRoom = new room();
            bool add = myRoom.AddRoom(kcname.Text.Trim(), kccode.Text.Trim(), kcnum.Text.Trim());
            if (add)
            {
                kcname.Text = kccode.Text = kcnum.Text = "";
                Response.Write("<script>alert('考场添加成功！')</script>");
                Response.Write("<script>window.close();</script>");
                
            }
            else
            {
                Response.Write("<script>alert('考场添加失败，请注意课程编码的正确性')</script>");
            }
        }
    }
}