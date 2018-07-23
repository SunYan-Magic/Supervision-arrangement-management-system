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

public partial class Admin_admin_roommanage : System.Web.UI.Page
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
        lbtnadd.Attributes.Add("onclick", "window.showModalDialog('addroom.aspx',window,'center=yes;help=no;status=no;dialogheight:250px;dialogwidth:360px;scroll:yes');");
        lbtnupd.Attributes.Add("onclick", "window.showModalDialog('updateroom.aspx',window,'center=yes;help=no;status=no;dialogheight:250px;dialogwidth:440px;scroll:yes');");
       /// BindData();///
    }
    private void BindData()
    {
        role_GetDataSet myDS = new role_GetDataSet();
        anproom.RecordCount = myDS.GetRoomSearchCount(kcnamesearch, kccodesearch);
        int pageindex = anproom.CurrentPageIndex - 1;
        int pagesize = 13;
        gvroom.DataSource = myDS.GetRoomSearchData(kcnamesearch, kccodesearch, pageindex, pagesize);
        gvroom.DataKeyNames = new string[] { "roomID" };
        gvroom.DataBind();
    }
    protected void gvclass_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void anpcatalog_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lbtnsearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lbtnrefresh_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void cball_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvroom.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvroom.Rows[i].FindControl("cbsel");
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
        for (int i = 0; i < gvroom.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvroom.Rows[i].FindControl("cbsel");
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
    protected void lbtndel_Click(object sender, EventArgs e)
    {
        int j = 0;
        for (int i = 0; i < gvroom.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvroom.Rows[i].FindControl("cbsel");
            if (cb.Checked)
            {
                j = j + 1;
                int id = int.Parse(gvroom.DataKeys[i].Value.ToString());
                room  myRoom = new room();
                myRoom.DeleteRoom(id);
            }
        }
        if (j == 0)
        {
            Response.Write("<script>alert('请选择要删除的考场')</script>");
        }
        else
        {
            BindData();
        }
    }
    protected void lbtnupd_Click(object sender, EventArgs e)
    {
        
    }
    protected void lbtnadd_Click(object sender, EventArgs e)
    {

    }
}