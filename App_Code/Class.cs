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
/// N38_Class 的摘要说明
/// </summary>
public class Class
{
    public Class()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 检查班级是否存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitClass(string code)
    {
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from class where classcode=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    //更新后的信息项，除了该ID号的其他项不能有该编码，否则修改失败
    public bool ExitClassUndate(int ID,string code1)
    {
        SqlParameter para0 = new SqlParameter("@id", ID);
        SqlParameter para1 = new SqlParameter("@code", code1);
        string sqlStr = "select count(*) from class where classcode=@code and classID!=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1 ,para0 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加班级
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool AddClass(string name, string code,string  bjnum)
    {
        if (this.ExitClass(code))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@name", name);
            SqlParameter para2 = new SqlParameter("@code", code);
            int num1 = int.Parse(bjnum);
            SqlParameter para3 = new SqlParameter("@num", num1 );
            string sqlStr = "insert into class (classname,classcode,classnum,examnotnum) values (@name,@code,@num,0)";
            int num2 = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para3);
            if (num2 > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除班级
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool DeleteClass(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from class where classID=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改班级信息
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool UpdateClass(int ID, string name1, string code1,string bjnum)
    {
        if (this.ExitClassUndate(ID,code1))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@id", ID);
            SqlParameter para2 = new SqlParameter("@name", name1);
            SqlParameter para3 = new SqlParameter("@code", code1);
            SqlParameter para4 = new SqlParameter("@num", bjnum);
            string sqlStr = "update class set classname=@name,classcode=@code,classnum=@num where classID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3, para4, para1);
            if (num > 0)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 读取class的代码
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public string GetClassData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select classcode fromclass where classID=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
          
}
