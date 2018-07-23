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
using System.Text;
using System.IO;

public partial class Teacher_teacher_ViewMyMonitor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/login.html");
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {  
        role_GetDataSet myDS = new role_GetDataSet();
        role_User user = new role_User();
        lsname.Text = user.GetUserName(Session["user"].ToString());
        gvmonitor.DataSource = myDS.GetUserMonitorData(Session["user"].ToString());
        gvmonitor.DataKeyNames = new string[] { "monitorID" };
        gvmonitor.DataBind();
    }
    protected void gvmonitor_RowDataBound(object sender, GridViewRowEventArgs e)
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
    
    protected void down_Click(object sender, EventArgs e)
    {
        role_GetDataSet myDS = new role_GetDataSet();
        gvmonitor.DataSource = myDS.GetUserMonitorData(Session["user"].ToString());
        gvmonitor.DataKeyNames = new string[] { "monitorID" };
        gvmonitor.AllowPaging = false;
        gvmonitor.DataBind();
        string FileName = "监考安排" + DateTime.Now + ".xls";
        Response.Charset = "GB2312";
        Response.ContentEncoding = Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
        Response.AddHeader("content-type", "appliction/ms-excel");//或者Response.ContentType=File Type
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        gvmonitor.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void anpcatalog_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    
}
