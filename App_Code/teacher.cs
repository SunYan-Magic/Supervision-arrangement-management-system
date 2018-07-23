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
/// N38_Student 的摘要说明
/// </summary>
public class teacher
{
    public teacher()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 判断学号是否存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitTeacher(string code1)
    {
        SqlParameter para2 = new SqlParameter("@code", code1);
        string sqlStr = "select count(*) from teacher where teachercode=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr,para2 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool ExitTeacherUndate(int ID, string code)
    {
        SqlParameter para0 = new SqlParameter("@id", ID);
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from teacher where teachercode=@code and teacherID!=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1,para0 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加老师
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool AddTeacher(string name1, string code1, string tel1)
    {
        if (this.ExitTeacher(code1))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@name", name1);
            SqlParameter para2 = new SqlParameter("@code", code1);          
            SqlParameter para5 = new SqlParameter("@tel", tel1);            
            string sqlStr = "insert into teacher(teachername,teachercode,teacherpw,teachertel) values (@name,@code,@code,@tel)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2,para5  );
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除老师
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool DeleteTeacher(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from teacher where teacherID=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改老师信息
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="pro"></param>
    /// <returns></returns>
    public bool UpdateTeacher(int id1,string name1, string code1, string tel1,string monnum1)
    {
        if (this.ExitTeacherUndate(id1,code1))
        {
            return false;
        }
        else
        {
            SqlParameter para0 = new SqlParameter("@id", id1);
            SqlParameter para1 = new SqlParameter("@name", name1);
            SqlParameter para2 = new SqlParameter("@code", code1);
            SqlParameter para4 = new SqlParameter("@tel", tel1);
            int Mon = int.Parse(monnum1);
            SqlParameter para7 = new SqlParameter("@monnum", Mon);
            string sqlStr = "update teacher set teachername=@name,teachercode=@code,teachertel=@tel,teachermonnum=@monnum where teacherID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para4, para7, para0);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 获取老师学号
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetTeacherData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select teacherID from teacher where teacherID=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
}
