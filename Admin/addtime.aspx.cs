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

public partial class Admin_addtime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
    }
    protected void Button1_Click(object sender, EventArgs e) 
    {
        Calendar1.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Calendar2.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if(DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd"))<DateTime.Now.Date )
        {
            Response.Write("<script>alert('考试起始日期不得早于今日日期，请重新添加！')</script>");
            Button1.Text ="";
        }
        Button1.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd") ;
        Calendar1.Visible = false;
        
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        Button2.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
        Calendar2.Visible = false;
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if(DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd"))<=DateTime.Parse(Calendar2.SelectedDate.ToString("yyyy-MM-dd")))
            {
                time myTime = new time();
                bool add = myTime.AddTime(Convert.ToDateTime(Calendar1.SelectedDate.Date), Convert.ToDateTime(Calendar2.SelectedDate.Date));
                if (add)
                {
                    Button1.Text = Button2.Text = "";
                    Response.Write("<script>alert('时间设定成功')</script>");
                    Response.Write("<script>window.close();</script>");
                   
                }
                else
                {
                    Response.Write("<script>alert('时间已经设定')</script>");
                    Response.Write("<script>window.close();</script>");
                }
                
            }
            else 
            {
                Response.Write("<script>alert('考试起始日期和终止日期添加不正确或者不完全，请重新添加！')</script>");
                Button1.Text = Button2.Text = "";
            }
        }
    }
}