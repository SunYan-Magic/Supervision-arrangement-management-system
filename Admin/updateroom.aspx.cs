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

public partial class Admin_updateroom : System.Web.UI.Page
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
            bool add = myRoom.UpdateRoom(int.Parse(roomid.Text.Trim()), kcname.Text.Trim(),kccode.Text.Trim(), kcnum.Text.Trim());
            if (add)
            {
                roomid.Text = kcname.Text = kccode.Text = kcnum.Text  = "";
                Response.Write("<script>alert('考场修改成功')</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('考场更新失败，请注意考场编码或者ID的正确性')</script>");
            }  
        }
    }
}