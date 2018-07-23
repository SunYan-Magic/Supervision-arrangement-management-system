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
/// N38_Course 的摘要说明
/// </summary>
public class course
{
    public course()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 判断课程是否已存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitCourse(string kcname, string kccode, string bjcode, string lscode)
    {
        SqlParameter para1 = new SqlParameter("@Kcname", kcname);
        SqlParameter para2 = new SqlParameter("@Kccode", kccode);
        SqlParameter para3 = new SqlParameter("@Bjcode", bjcode);
        SqlParameter para4 = new SqlParameter("@Lscode", lscode);
        string sqlStr = "select count(*) from course where coursecode=@Kccode and coursename=@Kcname and classcode=@Bjcode and teachercode=@Lscode";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1,para2 ,para3 ,para4  ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool ExitCourseUpdate( int ID,string kcname, string kccode, string bjcode, string lscode)
    {
        SqlParameter para0 = new SqlParameter("@id", ID);
        SqlParameter para1 = new SqlParameter("@Kcname", kcname);
        SqlParameter para2 = new SqlParameter("@Kccode", kccode);
        SqlParameter para3 = new SqlParameter("@Bjcode", bjcode);
        SqlParameter para4 = new SqlParameter("@Lscode", lscode);
        string sqlStr = "select count(*) from course where coursecode=@Kccode and coursename=@Kcname and classcode=@Bjcode and teachercode=@Lscode and courseID!=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1,para2 ,para3 ,para4 ,para0 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// 添加课程
    /// </summary>
    /// <param name="kvname"></param>
    /// <param name="code"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool AddCourse(string kcname, string kccode, string bjcode, string lscode)
    {
        if (this.ExitCourse(kcname, kccode, bjcode, lscode))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@Kcname", kcname);
            SqlParameter para2 = new SqlParameter("@Kccode", kccode);
            SqlParameter para3 = new SqlParameter("@Bjcode", bjcode);
            SqlParameter para4 = new SqlParameter("@Lscode", lscode);
            string sqlStr = "insert into course (coursename,coursecode,teachercode,classcode,classrelate) values (@Kcname,@Kccode,@Lscode,@Bjcode,0)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para3, para4);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除课程
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool DeleteCourse(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from course where courseID=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改课程
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool UpdateCourse(int ID, string kcname, string kccode, string bjcode, string lscode)
    {
        if (this.ExitCourseUpdate(ID, kcname, kccode, bjcode, lscode))
        {
            return false;
        }
        else
        {
            SqlParameter para0 = new SqlParameter("@id", ID);
            SqlParameter para1 = new SqlParameter("@Kcname", kcname);
            SqlParameter para2 = new SqlParameter("@Kccode", kccode);
            SqlParameter para3 = new SqlParameter("@Bjcode", bjcode);
            SqlParameter para4 = new SqlParameter("@Lscode", lscode);

            string sqlStr = "update course set coursecode=@Kccode,coursename=@Kcname,classcode=@Bjcode , teachercode=@Lscode where courseID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para3, para4, para0);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 获取课程代码
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetCourseData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select coursecode from course where courseID=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
    /// <summary>
    /// 根据id获取课程名称
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetCourseName(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select coursename from course where courseID=@id";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return name;
    }
    /// <summary>
    /// 根据id获取课程需要人数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetCourseCount(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select coursenum from course where courseID=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return num;
    }
    /// <summary>
    /// 根据id获取课程已选人数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetCourseSelected(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select * from course where courseID=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return num;
    }
    /// <summary>
    /// 改变指定id的课程的状态
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>   
   
   
}
