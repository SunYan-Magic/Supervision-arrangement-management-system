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

public partial class Admin_admin_monitormanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] == null)
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
        anpmonitor.RecordCount = myDS.GetAllMonitorCount();
        int pageindex = anpmonitor.CurrentPageIndex - 1;
        int pagesize = 10;
        gvmonitor.DataSource = myDS.GetAllMonitorData(pageindex, pagesize);
        gvmonitor.DataKeyNames = new string[] { "monitorID" };
        gvmonitor.DataBind();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        monitor myMon=new monitor();
        time Time = new time();
        string Time1 = Time.GetStartTime();
        string Time2 = Time.GetEndTime();
        myMon.Initial();
        if (myMon.TeacherNum() == false | myMon.RoomNum() == false | 
            myMon.CourseNum() == false |myMon.ClassNum() == false | Time1 == Time2)
        {
            Response.Write("<script>alert('监考信息添加不完全，请返回继续添加！')</script>");
        }
        else
        {
            bool  Result=myMon.MakeMonitor();
            if( Result)
                 Response.Write("<script>alert('监考安排成功！')</script>");            
            else
                Response.Write("<script>alert('监考安排失败，考试资源有限，安排任务无法在考试时间内安排成功！')</script>");
        }
    }
   
    protected void download_Click(object sender, EventArgs e)
    {
        role_GetDataSet myDS = new role_GetDataSet();
        gvmonitor.DataSource = myDS.GetMonitorData();
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
    protected void fresh_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void anpcatalog_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void cbno_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvmonitor.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvmonitor.Rows[i].FindControl("cbsel");
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
    protected void del_Click(object sender, EventArgs e)
    {

        monitor  myMonitor = new monitor();
        bool T=myMonitor.DeleteMonitor();
        if(T)
            Response.Write("<script>alert('清除监考安排记录成功！')</script>");    
        else
            Response.Write("<script>alert('清除监考安排记录失败！')</script>");   
    }
}