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
using Web.sqlHelper;
using System.Data.SqlClient;

/// <summary>
/// Summary description for request
/// </summary>
public class request
{
	public request()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool ExitRequest(string code, DateTime cannot)
    {
        SqlParameter para1 = new SqlParameter("@code", code);
        SqlParameter para2 = new SqlParameter("@date", cannot.Date);
        string sqlStr = "select count(*) from request where teachercode=@code and datecannot=@date";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1,para2 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
   //public bool SetRequest(int ID)
    //{
    //    SqlParameter para = new SqlParameter("@id", ID);
     //   string sqlStr = "select count(*) from request where requeststate=0 and requestID=@id";
    //    int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
     //   if (num > 0)
     //       return true;
    //    else
    //        return false;
   // }
    /// <summary>
    /// 添加班级
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cannot"></param>
    /// <returns></returns>
    public bool AddRequest(string teacode, DateTime  cannot)
    {
        if (this.ExitRequest(teacode,cannot))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@code", teacode );
            SqlParameter para2 = new SqlParameter("@date", cannot);
            string sqlStr = "insert into request (teachercode,datecannot,requeststate) values (@code,@date,1)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2);
            if (num > 0)
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
    public bool ExitRequestDel(int id1)
    {
        SqlParameter para1 = new SqlParameter("@id", id1);
        string sqlStr = "select count(*) from request where requestID=@id and requestresult is not NULL";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool DeleteRequest(int ID)
    {
        if (this.ExitRequestDel(ID))
        {
            return false;
        }
        else
        {
            SqlParameter para = new SqlParameter("@id", ID);
            string sqlStr = "delete from request where requestID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
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
    public string GetRequestData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select teachercode  from request where requestID=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
    public bool ExitRequestSet(int id1)
    {
        SqlParameter para1 = new SqlParameter("@id", id1);
        string sqlStr = "select count(*) from request where requestID=@id and requestresult is not NULL";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool SetResultYes(int ID)
    {
        if (this.ExitRequestSet(ID))
        {
            return false;
        }
        else
        {
            SqlParameter para = new SqlParameter("@id", ID);
            string sqlStr = "update request set requestresult=1,requeststate=0 where requestID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    public bool SetResultNo(int ID)
    {
        if (this.ExitRequestSet(ID))
        {
            return false;
        }
        else
        {
            SqlParameter para = new SqlParameter("@id", ID);
            string sqlStr = "update request set requestresult=0,requeststate=0 where requestID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
}