using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Web.sqlHelper;
using System.Data.SqlClient;


/// <summary>
/// N38_GetDataSet 的摘要说明
/// </summary>
public class role_GetDataSet
{
	public role_GetDataSet()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 获取class表记录的条数
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetClassSearchCount(TextBox Name, TextBox Code)
    {
        string sb = "select count(*) from class ";
        if (Name.Text!= "")
        {
            sb = sb + "where classname like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and classcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where classcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取class表的数据集
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetClassSearchData(TextBox Name, TextBox Code, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from class ";
        if (Name.Text != "")
        {
            sb = sb + "where classname like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and classcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where classcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "class");
        return ds;
    }

    /// <summary>
    /// 获取student表的数据条数
    /// </summary>
    /// <param name="ClassCode"></param>
    /// <param name="teacherCode"></param>
    /// <returns></returns>
    public int GetTeacherSearchCount(TextBox  teachername, TextBox teacherCode)
    {
        string sb = "select count(*) from teacher ";
        if (teachername.Text != "")
        {
            sb = sb + "where teachername like '%" + teachername.Text.Trim() + "%'";
            if (teacherCode.Text != "")
            {
                sb = sb + "and teachercode like '%" + teacherCode.Text.Trim() + "%'";
            }
        }
        else
        {
            if (teacherCode.Text != "")
            {
                sb = sb + "where teachercode like '%" + teacherCode.Text.Trim() + "%'";
            }
        }
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取student表的数据集
    /// </summary>
    /// <param name="teachername"></param>
    /// <param name="teacherCode"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetTeacherSearchData(TextBox  teachername, TextBox teacherCode, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from teacher ";
        if (teachername.Text != "")
        {
            sb = sb + "where teachername like '%" + teachername.Text.Trim() + "%'";
            if (teacherCode.Text != "")
            {
                sb = sb + "and teachercode like '%" + teacherCode.Text.Trim() + "%'";
            }
        }
        else
        {
            if (teacherCode.Text != "")
            {
                sb = sb + "where teachercode like '%" + teacherCode.Text.Trim() + "%'";
            }
        }
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "teacher");
        return ds;
    }
    /// <summary>
    /// 获取course表记录条数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetCourseSearchCount(TextBox Name, TextBox Code)
    {
        string sb = "select count(*) from course ";
        if (Name.Text != "")
        {
            sb = sb + "where coursename like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and coursecode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where coursecode like '%" + Code.Text.Trim() + "%'";
            }
        }
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取course表数据集
    /// </summary>
    /// <param name="name"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetCourseSearchData(TextBox  Name, TextBox Code, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from course ";
        if (Name.Text != "")
        {
            sb = sb + "where coursename like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and coursecode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where coursecode like '%" + Code.Text.Trim() + "%'";
            }
        }
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "class");
        return ds;
    }
    public int GetRequestSearchCount(TextBox name, TextBox date)
    {
        string sb = "select count(*) from request";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }

    public DataSet GetRequestSearchData(TextBox name, TextBox date, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from request";        
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "request");
        return ds;
    }
    public int GetUserRequestCount(string teachercode1)
    {
        SqlParameter para = new SqlParameter("@code", teachercode1);
        string sb = "select count(*) from request where teachercode=@code ";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb, para).ToString().Trim());
        return num;
    }
    public int GetAllRequestCount()
    {
        string sb = "select count(*) from request";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    public DataSet GetAllRequestData(int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from request";
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "request");
        return ds;
    }
    public DataSet GetUserRequestData(string teachercode1)
    {
        SqlParameter para = new SqlParameter("@code", teachercode1);
        DataSet ds = new DataSet();
        string sb = "select * from request where teachercode=@code ";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb, para);
        return ds;
    }
    /// <summary>
    /// 获取学生的选课信息
    /// </summary>
    /// <param name="StudentCode"></param>
    /// <returns></returns>
    public DataSet GetUserMonitorData(string teacode)
    {
        SqlParameter para = new SqlParameter("@code", teacode);
        string sqlStr = "select * from monitorplan where (teachercode1=@code or teachercode2=@code or teachercode3=@code)";
        DataSet ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr, para);
        return ds;
    }

    /// <summary>
    /// 获取学生搜索的course表记录条数
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetUserMonitorSearchCount(string code)
    {
        string sb = "select count(*) from monitorplan where teachercode=@code ";
        if (code != "")
            {
                sb = sb + "where teachercode like '%" +code.Trim() + "%'";
            }
       
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    
    /// <summary>
    /// 获取学生搜索course表的数据集
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetAllMonitorData(int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from monitorplan";         
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "monitorplan");
        return ds;
    }
    public int GetAllMonitorCount()
    {
        DataSet ds = new DataSet();
        string sb = "select count(*) from monitorplan";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
   // public int GetRoomSearchCount(TextBox kcnamesearch, TextBox kccodesearch)
    //{
   ///     throw new NotImplementedException();
  //  }

   // public object GetRoomSearchData(TextBox kcnamesearch, TextBox kccodesearch, int pageindex, int pagesize)
   // {
    //    throw new NotImplementedException();
    //}
    public int GetRoomSearchCount(TextBox Name, TextBox Code)
    {
        string sb = "select count(*) from room ";
        if (Name.Text != "")
        {
            sb = sb + "where roomname like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and roomcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where roomcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取class表的数据集
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetRoomSearchData(TextBox Name, TextBox Code, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from room ";
        if (Name.Text != "")
        {
            sb = sb + "where roomname like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and roomcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where roomcode like '%" + Code.Text.Trim() + "%'";
            }
        }
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "class");
        return ds;
    }
     public DataSet GetMonitorData()
    {
        DataSet ds = new DataSet();
        string sb = "select * from monitorplan";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        return ds;
    }
}
