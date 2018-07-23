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

public partial class Admin_admin_requestmanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("~/login.html");
        }
        if (!IsPostBack)
        {
            time Time = new time();
            DateTime T1, T2;
            T1 = Convert.ToDateTime(Time.GetStartTime());
            T2 = Convert.ToDateTime(Time.GetEndTime());
            date1.Text = T1.ToString("yyyy-MM-dd");
            date2.Text = T2.ToString("yyyy-MM-dd");
            BindData();
        }

    }
    private void BindData()
    {         
        role_GetDataSet myDS = new role_GetDataSet();
        anprequest.RecordCount = myDS.GetAllRequestCount();
        int pageindex = anprequest.CurrentPageIndex - 1;
        int pagesize = 13;
        gvrequest.DataSource = myDS.GetAllRequestData( pageindex, pagesize);
        gvrequest.DataKeyNames = new string[] { "requestID" };
        gvrequest.DataBind();
       
    }
    protected void lbtnsearch_Click(object sender, EventArgs e)
    {
        BindData();
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
    protected void gvrequest_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void fresh_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void yes_Click(object sender, EventArgs e)
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
                myRequest.SetResultYes(id);     
         
            }
        }
        if (j == 0)
        {
            Response.Write("<script>alert('请选择要处理的请求')</script>");
        }
        else
        {
            BindData();
        }
    }
    protected void no_Click(object sender, EventArgs e)
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
                myRequest.SetResultNo(id);
            }
        }
        if (j == 0)
        {
            Response.Write("<script>alert('请选择要处理的请求')</script>");
        }
        else
        {
            BindData();
        }      
    }
    protected void anpcatalog_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    
}