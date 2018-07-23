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
/// Summary description for time
/// </summary>
public class time
{
	public time()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    /// <summary>
    /// 添加课程
    /// </summary>
    /// <param name="kstime"></param>
    /// <param name="jstime"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool AddTime(DateTime kstime, DateTime jstime)
    {
            SqlParameter para1 = new SqlParameter("@ks", kstime.Date );
            SqlParameter para2 = new SqlParameter("@js", jstime.Date );
            string sqlStr = "update time set starttime=@ks,endtime=@js where timeID=1";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2);
            if (num > 0)
                return true;
            else
                return false;
        }
    public string GetStartTime()
    {      
        string sqlStr = "select [starttime] from time where timeID=1 ";
        string name = "";//System.NullReferenceException：未将对象引用设置到对象的实例        
        name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr).ToString();
        return name;
    }
    public string GetEndTime()
    {
        string sqlStr = "select [endtime] from time where timeID=1 ";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr).ToString();
        return name;
    }
    
 }
    