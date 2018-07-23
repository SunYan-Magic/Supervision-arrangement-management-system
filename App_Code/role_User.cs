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
/// N38_User 的摘要说明：用户操作类
/// </summary>
public class role_User
{
	public role_User()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 管理员登陆
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public bool AdminLogin(string name, string pwd)
    {
        SqlParameter para1 = new SqlParameter("@name", name);
        SqlParameter para2 = new SqlParameter("@pwd", pwd);
        string sqlStr = "select count(*) from admin where admincode=@name and adminpw=@pwd";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1, para2).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 学生登录
    /// </summary>
    /// <param name="code"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public bool StudentLogin(string code, string pwd)
    {
        SqlParameter para1 = new SqlParameter("@name", code);
        SqlParameter para2 = new SqlParameter("@pwd", pwd);
        string sqlStr = "select count(*) from teacher where teachercode=@name and teacherpw=@pwd";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1, para2).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 管理员修改密码
    /// </summary>
    /// <param name="oldpwd"></param>
    /// <param name="newpwd"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool AdminPwd(string oldpwd, string newpwd,string name)
    {
        if (this.AdminLogin(name, oldpwd))
        {
            SqlParameter para2 = new SqlParameter("@npwd", newpwd);
            SqlParameter para3 = new SqlParameter("@name", name);
            string sqlStr = "update admin set adminpw=@npwd where admincode=@name";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3);
            if (num > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }
    /// <summary>
    /// 学生修改密码
    /// </summary>
    /// <param name="oldpwd"></param>
    /// <param name="newpwd"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool StudentPwd(string oldpwd, string newpwd, string code)
    {
        if (this.StudentLogin(code, oldpwd))
        {
            SqlParameter para2 = new SqlParameter("@npwd", newpwd);
            SqlParameter para3 = new SqlParameter("@name", code);
            string sqlStr = "update teacher set teacherpw=@npwd where teachercode=@name";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3);
            if (num > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public bool SetStudentPwd( string newpwd, string code)
    {       
        SqlParameter para2 = new SqlParameter("@npwd", newpwd);
        SqlParameter para3 = new SqlParameter("@name", code);
        string sqlStr = "update teacher set teacherpw=@npwd where teachercode=@name";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3);
        if (num > 0)
            return true;
        else
            return false;       
    }
    /// <summary>
    /// 删除学生的选课
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    
    public bool DeleteSelectRequest(string code, string date)
    {
        string sqlStr1 = "delete * from request where teachercode=@code and datecannot=@date";
         try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);            
            DBManager.Instance().CommitTrans();
            return true;
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
            return false;
        }
    }
    /// <summary>
    /// 通过学号获取姓名
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string GetUserName(string code)
    {
        SqlParameter para = new SqlParameter("@code", code);
        string sqlStr = "select teachername from teacher where teachercode=@code";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return name;
    }
    
    /// <summary>
    /// 学生选择课程方法
    /// </summary>
    /// <param name="UserCode">学号</param>
    /// <param name="CourseName">课程名称</param>
    /// <returns></returns>
    public bool SelectCourse(string UserCode, string CourseName)
    {
        //SqlParameter prar1 = new SqlParameter("@user", UserCode);
        //SqlParameter para2 = new SqlParameter("@course", CourseName);
        string sqlStr1 = "insert into n38_25175_select (n38_select_course,n38_select_student) values ('" + CourseName + "','" + UserCode + "')";
        string sqlStr2 = "update n38_25175_course set n38_course_selected = n38_course_selected + 1 where n38_course_name = '" + CourseName + "'";
        string sqlStr3 = "update n38_25175_student set n38_student_course = n38_student_course + 1 where n38_student_code = '" + UserCode + "'";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().CommitTrans();
            return true;
        }
        catch(Exception)
        {
            DBManager.Instance().RollbackTrans();
            return false;
        }
    }
    /// <summary>
    /// 通过学号获取学生已选课数
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public int GetUserSelectCount(string code)
    {
        SqlParameter para = new SqlParameter("@code", code);
        string sqlStr = "select n38_student_course from n38_25175_student where n38_student_code=@code";
        int count = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return count;
    }
    /// <summary>
    /// 判断学生是否已选了这门课程
    /// </summary>
    /// <param name="CourseName"></param>
    /// <returns></returns>
    public bool ExitCourse(string UserCode,string CourseName)
    {
        SqlParameter para1=new SqlParameter("@user",UserCode );
        SqlParameter para2 = new SqlParameter("@course", CourseName);
        string sqlStr = "select count(*) from n38_25175_select where n38_select_course=@course and n38_select_student=@user";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para2, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
}