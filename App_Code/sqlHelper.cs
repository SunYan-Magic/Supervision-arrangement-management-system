using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;
/// <summary>
/// Summary description for sqlHelper
/// </summary>
namespace Web.sqlHelper
{
    /// <summary>
    /// 数据库操作帮助
    /// </summary>
    public class sqlHelper
    {
        private string myConStr = string.Empty;
        private DbProviderFactory myFactory;

        private DbConnection _myConn;
        public DbConnection myConn
        {
            get { return _myConn; }
            set { _myConn = value; }
        }

        private DbTransaction _myTrans;
        public DbTransaction myTrans
        {
            get { return _myTrans; }
            set { _myTrans = value; ;}
        }

        public sqlHelper(string ConStr, string dbProviderName)
        {
            this.myConStr = ConStr;
            myFactory = DbProviderFactories.GetFactory(dbProviderName);
        }
        /// <summary>
        /// 打开
        /// </summary>
        public void Open()
        {
            if (this.myConn == null)
            {
                this.myConn = this.myFactory.CreateConnection();
                this.myConn.ConnectionString = this.myConStr;
            }
            if (this.myConn.State != ConnectionState.Open)
                this.myConn.Open();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (this.myTrans == null)
            {
                if (this.myConn != null)
                {
                    this.myConn.Dispose();
                    this.myConn.Close();
                    this.myConn = null;
                }
            }
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTrans()
        {
            this.Open();
            if (this.myTrans == null)
                this.myTrans = this.myConn.BeginTransaction();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTrans()
        {
            if (this.myTrans != null)
            {
                this.myTrans.Commit();
                this.myTrans.Dispose();
                this.myTrans = null;
                this.Dispose();
            }
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTrans()
        {
            if (this.myTrans != null)
            {
                this.myTrans.Rollback();
                this.myTrans.Dispose();
                this.myTrans = null;
                this.Dispose();
            }
        }
        /// <summary>
        /// 创建命令参数
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        private DbCommand CreateCmd(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            DbCommand myCmd = this.myConn.CreateCommand();
            myCmd.CommandText = cmdText;
            myCmd.CommandType = cmdType;           
            myCmd.Parameters.AddRange(cmdParas);
            if (this.myTrans != null) myCmd.Transaction = this.myTrans;
            //myCmd.Parameters.Clear();//添加
            return myCmd;
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                DbDataAdapter myDataAdapter = this.myFactory.CreateDataAdapter();
                myDataAdapter.SelectCommand = myCmd;
                DataSet mySet = new DataSet();
                myDataAdapter.Fill(mySet);
                return mySet;
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 返回AspNetPager分页控件数据源
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet2(CommandType cmdType, string cmdText,int PageIndex,int PageSize,string table,params DbParameter[] cmdParas)
        {
            try
            {
                int firstpage=PageSize * PageIndex;
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                DbDataAdapter myDataAdapter = this.myFactory.CreateDataAdapter();
                myDataAdapter.SelectCommand = myCmd;
                DataSet mySet = new DataSet();
                myDataAdapter.Fill(mySet,firstpage,PageSize,table);
                return mySet;
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                DbDataAdapter myDataAdapter = this.myFactory.CreateDataAdapter();
                myDataAdapter.SelectCommand = myCmd;
                DataTable myTable = new DataTable();
                myDataAdapter.Fill(myTable);
                return myTable;
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                return myCmd.ExecuteNonQuery();
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 返回结果集，１行１列
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                return myCmd.ExecuteScalar();
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public bool CheckData(string sqlStr)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["monitorConnectionString"].ToString());
            try
            {
                Conn.Open();
                SqlCommand myCmd = new SqlCommand(sqlStr,Conn);
                SqlDataReader myRead = myCmd.ExecuteReader();
                if (myRead .HasRows)
                    return true;
                else
                    return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string cmdText)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["monitorConnectionString"]);
                Conn.Open();
                SqlCommand Cmd = new SqlCommand(cmdText, Conn);
                return Cmd.ExecuteReader();
        }
        /// <summary>
        /// 返回泛型记录集合-对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public IList<T> ExecuteReaderList<T>(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            try
            {
                this.Open();
                DbCommand myCmd = this.CreateCmd(cmdType, cmdText, cmdParas);
                DbDataReader myDbDataReader = myCmd.ExecuteReader();
                IList<T> list = ToList<T>(myDbDataReader);
                return list;
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 返回泛型记录-对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public T ExecuteReaderObject<T>(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            return ExecuteReaderList<T>(cmdType, cmdText, cmdParas)[0];
        }

        
        #region T
        private IList<T> ToList<T>(DbDataReader reader)
        {
            Type type = typeof(T);
            IList<T> list = null;
            if (type.IsValueType || type == typeof(string))
                list = CreateValue<T>(reader, type);
            else
                list = CreateObject<T>(reader, type);
            reader.Dispose();
            reader.Close();
            return list;
        }
        private IList<T> CreateObject<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            PropertyInfo[] properties = type.GetProperties();
            string name = string.Empty;
            while (reader.Read())
            {
                T local = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    name = reader.GetName(i);
                    foreach (PropertyInfo info in properties)
                    {
                        if (name.Equals(info.Name)) { info.SetValue(local, Convert.ChangeType(reader[info.Name], info.PropertyType), null); break; }
                    }
                }
                list.Add(local);
            }
            return list;
        }
        private IList<T> CreateValue<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            while (reader.Read())
            {
                T local = (T)Convert.ChangeType(reader[0], type, null);
                list.Add(local);
            }
            return list;
        } 
        #endregion
        }
}