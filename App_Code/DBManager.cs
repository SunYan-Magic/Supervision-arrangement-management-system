using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Web.sqlHelper
{
    public class DBManager
    {
        //连接字符串
        public static readonly string myConnStr = ConfigurationManager.AppSettings["monitorConnectionString"].ToString();
        //默认　System.Data.SqlClient
        public static readonly string dbProviderName = string.IsNullOrEmpty(ConfigurationManager.AppSettings["dbProviderName"])
                                                    ? "System.Data.SqlClient" : ConfigurationManager.AppSettings["dbProviderName"];
        [ThreadStatic]
        static sqlHelper helper;
        public static sqlHelper Instance()
        {
            if (helper == null)
            {
                helper = new sqlHelper(myConnStr, dbProviderName);
                return helper;
            }
            return helper;
        }
    }
}
