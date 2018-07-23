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
/// Summary description for room
/// </summary>
public class room
{
	public room()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool ExitRoom(string code1)
    {
        SqlParameter para2 = new SqlParameter("@code", code1);
        string sqlStr = "select count(*) from room where roomcode=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr,para2 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool ExitRoomUndate(int ID, string code)
    {
        SqlParameter para0 = new SqlParameter("@id", ID);
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from room where roomcode=@code and roomID!=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1,para0 ).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加课程
    /// </summary>
    /// <param name="kvname"></param>
    /// <param name="code"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool AddRoom(string kvname, string code1, string kcnum)
    {
        if (this.ExitRoom(code1))
        {
            return false;
        }
        else
        {
            int Num = int.Parse(kcnum);
            SqlParameter para1 = new SqlParameter("@name", kvname);
            SqlParameter para2 = new SqlParameter("@code", code1);
            SqlParameter para3 = new SqlParameter("@num", Num);

            string sqlStr = "insert into room (roomname,roomcode,roomcap) values (@name,@code,@num)";
            int num = int.Parse(DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para3).ToString());
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
    public bool DeleteRoom(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from room where roomID=@id";
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
    public bool UpdateRoom(int ID, string name, string code, string kcnum)
    {
        if (this.ExitRoomUndate(ID,code))
        {
            return false;
        }
        else
        {
            int Num = int.Parse(kcnum);
            SqlParameter para1 = new SqlParameter("@id", ID);
            SqlParameter para2 = new SqlParameter("@name", name);
            SqlParameter para3 = new SqlParameter("@code", code);
            SqlParameter para4 = new SqlParameter("@num", Num);

            string sqlStr = "update room set roomname=@name,roomcode=@code,roomcap=@num where roomID=@id";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3, para4, para1);
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
    public string GetRoomData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select roomcode from room where roomID=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
    /// <summary>
    /// 根据id获取课程名称
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetRoomName(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select roomname from room where roomID=@id";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return name;
    }
    /// <summary>
    /// 根据id获取课程需要人数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetRoomCount(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select roomnum from room where roomID=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return num;
    }
   
    
    
   
}