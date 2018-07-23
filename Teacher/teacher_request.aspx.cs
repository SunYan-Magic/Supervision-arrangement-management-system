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

public partial class Teacher_teacher_request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/login.html");
        }
        if (!IsPostBack)
        {
            role_User user = new role_User();
            time Time = new time();
            llname.Text = user.GetUserName(Session["user"].ToString());//Session["user"].ToString()是teachername
            DateTime T1,T2;
            T1= Convert.ToDateTime(Time.GetStartTime());
            T2 = Convert.ToDateTime(Time.GetEndTime());
            date1.Text = T1.ToString("yyyy-MM-dd");
            date2.Text = T2.ToString("yyyy-MM-dd");
            BindData();
        }
    }
    private void BindData()
    {
        role_GetDataSet myDS = new role_GetDataSet();
        gvrequest.DataSource = myDS.GetUserRequestData(Session["user"].ToString());
        gvrequest.DataKeyNames = new string[] { "requestID" };
        gvrequest.DataBind();     
    }
   
    protected void gvstu_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#d0e5f5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
            e.Row.Attributes.Add("style", "height:22px;background-color:#ffffff");
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Attributes.Add("style", "background-image:url('../images/ht_10.gif');height:22px");
        }
    }
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvrequest.PageIndex = e.NewPageIndex;
        role_GetDataSet myDS = new role_GetDataSet();
        gvrequest.DataSource = myDS.GetUserRequestData(Session["user"].ToString());
        gvrequest.DataKeyNames = new string[] { "requestID" };
        gvrequest.DataBind(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd")) < DateTime.Parse(date1.Text))
        {
            Response.Write("<script>alert('不能监考日期早于考试开始日期！请正确输入该日期！')</script>");
            Button1.Text =  "";
        }
         if(DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd")) > DateTime.Parse(date2.Text))
        {
            Response.Write("<script>alert('不能监考日期晚于考试结束日期！请正确输入该日期！')</script>");
            Button1.Text =  "";
        }
        else
        {
            Button1.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }
    }
    protected void cball_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvrequest.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvrequest.Rows[i].FindControl("cbsel");
            if (cball.Checked)
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            
            request myRequest = new request();
            bool add = myRequest.AddRequest(Session["user"].ToString(), DateTime.Parse(Calendar1.SelectedDate.ToString("yyyy-MM-dd")));
            if (add)
            {
                Button1.Text  = "";
                Response.Write("<script>alert('请求发送成功！')</script>");
                BindData();
            }
            else
            {
                Response.Write("<script>alert('请求已经发送过！')</script>");
            }
          
        }
    }
    protected void lbtnrefresh_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void cbno_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvrequest.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvrequest.Rows[i].FindControl("cbsel");
            if (cb.Checked)
            {
                cb.Checked = false;
            }
            else
            {
                cb.Checked = true;
            }
        }
    }
    protected void gvrequest_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#d0e5f5'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
            e.Row.Attributes.Add("style", "height:22px;background-color:#ffffff");
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Attributes.Add("style", "background-image:url('../images/ht_10.gif');height:22px");
        }
    }
    protected void gvrequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string code = Session["user"].ToString();
        string date = gvrequest.Rows[e.RowIndex].Cells[0].Text.Trim();
        role_User user = new role_User();
        bool result = user.DeleteSelectRequest(code, date);
        if (result)
        {
            BindData();
        }
        else
        {
            Response.Write("<script>alert('撤销失败')</script>");
        }
    }
    protected void anpcatalog_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lbtndel_Click(object sender, EventArgs e)
    {
        int j = 0;
        for (int i = 0; i < gvrequest.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvrequest.Rows[i].FindControl("cbsel");
            if (cb.Checked)
            {
                j = j + 1;
                int id = int.Parse(gvrequest.DataKeys[i].Value.ToString());
                request myRequest = new request();
                myRequest.DeleteRequest(id);
            }
        }
        if (j == 0)
        {
            Response.Write("<script>alert('请选择要撤销的请求信息')</script>");
        }
        else
        {
            BindData();
        }
    }
}
