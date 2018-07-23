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
/// Summary description for monitor
/// </summary>
public class monitor
{
    public monitor()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool DeleteMonitor()
    {        
        string sqlStr = "delete from monitorplan ";        
        string sb = "select classcode from monitorplan";
       
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sb);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
        DataSet ds = new DataSet();
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        int num = ds.Tables[0].Rows.Count;
        if (num == 0)
            return true;
        else
            return false;
    }
    //可用老师
    public bool  TeacherNum()
    {
        string sb = "select teachercode  from teacher where teacherbool=0";
        DataSet ds = new DataSet();
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        int num = ds.Tables[0].Rows.Count;
        ds.Clear();
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool CourseNum()
    {
        string sb = "select coursecode  from course where coursebool=0";
        DataSet ds = new DataSet();
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        int num = ds.Tables[0].Rows.Count;
        ds.Clear();
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool RoomNum()
    {
        string sb = "select roomcode  from room where roombool=0";        
        DataSet ds = new DataSet();
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        int num = ds.Tables[0].Rows.Count;
        ds.Clear();
        if (num > 0)
            return true;
        else
            return false;
    }
    public bool ClassNum()
    {
        string sb = "select classcode  from class ";
        DataSet ds = new DataSet();
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        int num = ds.Tables[0].Rows.Count;
        ds.Clear();
        if (num > 0)
            return true;
        else
            return false;
    }
    //统计值、标志位、结果数据置零或清除
    public void Initial()
    {
        string sqlStr1 = "update teacher set teacherbool=0 ,teacherbool2=0,teachermonnum=0";//监考老师全部可用
        string sqlStr2 = "update room set roombool=0  ,roombool2=0";//考场全部可用     
        string sqlStr3 = "update course set coursebool2=0 ,coursebool=0";//课程遍历标志清除，且都未安排
        string sql = "update class set examdate=NULL,examnotnum=0";//专业上课考试日期置空，未考试数置零
        string sql2 = "delete from monitorplan";//监考安排结果表清空
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sql);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sql2);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }       
    }
    
    //+++++++++还有考试的班级数据集
    public DataSet HaveExam_Class()
    {
        DataSet ds = new DataSet();
        string sb = "select distinct course.classcode,examnotnum,classnum from course join class on course.classcode=class.classcode where examnotnum>0  order by examnotnum desc, classnum desc";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sb);
        return ds;
    }
    //+++++++++昨天有考试但是还有考试的班级数据集
    public DataSet YesterdayExamClass(DateTime yesterday)
    {
        SqlParameter para1 = new SqlParameter("@day", yesterday.Date);
        string sqlStr2 = "select distinct classcode,examnotnum from class where examnotnum>0 and examdate=@day order by examnotnum desc";
        DataSet dsclass = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr2,para1 );
        return dsclass;
    }
    //班级可以参与今日的考试安排(昨天和今天都没有考试)
    public bool ClassIsOK(string classcode1,DateTime yesterday)
    {
        SqlParameter para1 = new SqlParameter("@classCode", classcode1);
        SqlParameter para2 = new SqlParameter("@day", yesterday);
        string sqlStr2 = "select  distinct classcode from class where classcode  in (select classcode from class  where examnotnum>0 and examdate<@day or examdate is null) and examnotnum>0 and classcode=@classCode";
        DataSet dsclass = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr2, para1,para2 );
        int num=dsclass.Tables[0].Rows.Count;
        if(num==1)
            return true;
        else
            return false ;
    }
    //+++++++++昨天和今天没有考试但是还有考试的班级数据集
        public DataSet YesterdayNoExamClass(DateTime yesterday)
    {
        SqlParameter para1 = new SqlParameter("@day", yesterday.Date);
        string sqlStr2 = "select  distinct course.classcode,examnotnum,examdate ,classnum from course join class on course.classcode=class.classcode where examnotnum>0 and ( examdate< @day or examdate is null ) order by examnotnum desc,classnum desc";
        DataSet dsclass = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr2,para1);
        return dsclass;
    }
    //+++++++++该班级所有未考试且未遍历过的课程数据集，按课程涉及的班级数量降序排序
    public DataSet NotPlanCourse(String classcode1)
    {
        SqlParameter para1 = new SqlParameter("@classCode", classcode1);
        string sqlStr2 = "select coursecode from course where coursebool=0 and coursebool2=0 and classcode=@classCode order by classrelate desc";
        DataSet dsclass = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr2,para1 );
        return dsclass;
    }
    //+++++++++设定课程涉及的班级数目，置classnum
    public void RelateCourseClassNum()
    {
        DataSet ds = new DataSet();
        string sqlStr = "select coursecode,count(classcode) as num from course  group by coursecode";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string coursecode1 = ds.Tables[0].Rows[i]["coursecode"].ToString();
            string notnum = ds.Tables[0].Rows[i]["num"].ToString();
            int notnum1 = int.Parse(notnum);
            SqlParameter para1 = new SqlParameter("@code", coursecode1);
            SqlParameter para2 = new SqlParameter("@num", notnum1);
            string sql1 = "update course set classrelate=@num where coursecode=@code";
            try
            {
                DBManager.Instance().BeginTrans();
                DBManager.Instance().ExecuteNonQuery(CommandType.Text, sql1,para1 ,para2 );               
                DBManager.Instance().CommitTrans();               
            }
            catch (Exception)
            {
                DBManager.Instance().RollbackTrans(); 
            }
        }
        ds.Clear();
    }
    //+++++++++统计所有班级的未考试课程数目
    public void SetCourseNotNum()
    {
        DataSet ds = new DataSet();
        string sqlStr = "select classcode,count(coursecode) as num from course where coursebool=0 group by classcode ";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string classcode1 = ds.Tables[0].Rows[i]["classcode"].ToString();
            string notnum = ds.Tables[0].Rows[i]["num"].ToString();
            int notnum1 = int.Parse(notnum);
            SqlParameter para1 = new SqlParameter("@code", classcode1);
            SqlParameter para2 = new SqlParameter("@num", notnum1);
            string sql1 = "update class set examnotnum=@num where classcode=@code";
            try
            {
                DBManager.Instance().BeginTrans();
                DBManager.Instance().ExecuteNonQuery(CommandType.Text, sql1,para1 ,para2 );                
                DBManager.Instance().CommitTrans(); 
            }
            catch (Exception)
            {
                DBManager.Instance().RollbackTrans();
            }
        }
        ds.Clear();
    }
    //+++++++++课程涉及的班级数据集，按涉及班级人数降序排序
    public DataSet CourseRelateClass(String coursecode1)
    {
        SqlParameter para1 = new SqlParameter("@courseCode", coursecode1);
        string sqlStr1 = "select class.classcode,classnum from course join class on course.classcode=class.classcode where coursecode=@courseCode and coursebool2=0 order by classrelate desc,classnum desc"; ;
        DataSet dsclass = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr1,para1 );
        return dsclass;
    }
    //+++++++++设置课程已被安排成功，即标志已考
    public void SetCourseHave(string course1)
    {
        SqlParameter para3 = new SqlParameter("@Course", course1);
        string sqlStr = "update course set coursebool=1 where coursecode=@Course";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr,para3 );           
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++课程安排成功后，设置有该课程的班级考试日期为今日
    public void SetExamDate(DateTime day, string course1)
    {
        SqlParameter para1 = new SqlParameter("@Day", day.Date );
        SqlParameter para3 = new SqlParameter("@Course", course1);
        string sqlStr = "update class set examdate=@Day,examnotnum=examnotnum-1 from class join course on course.classcode=class.classcode where coursecode=@Course";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr,para1,para3 );
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++老师预监考安排成功，bool=1，bool2=0，老师监考次数加一
    public void TeacherMonSucceed()
    {
        string sqlStr = "update teacher set teachermonnum=teachermonnum+1,teacherbool=1,teacherbool2=0 where teacherbool2=1";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++需要的考场有，并更新monitorplan，插入对应考场值
    //在同一考场的每个班级在最终的考场表格里都有独立行
    public bool RoomCanUse(DateTime Day, int period1, string coursecode1, string classcode, int number)//数据集为在同一考场考试的班级数据集
    {
        bool room1 = true;
        string code1 = null;
        SqlParameter para1 = new SqlParameter("@day", Day.Date);
        SqlParameter para2 = new SqlParameter("@per", period1);
        SqlParameter para5 = new SqlParameter("@coursecod", coursecode1);
        SqlParameter para3 = new SqlParameter("@classcod", classcode);
        SqlParameter para4 = new SqlParameter("@classNum", number);
        string sqlStr6 = "select * from room where roombool=0 and roombool2=0 order by roomcap desc";//可用的考场
        DataSet dsroom = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr6 );
        for (int j = 0; j < dsroom.Tables[0].Rows.Count; j++)
        {
            string num1 = dsroom.Tables[0].Rows[j]["roomcap"].ToString();
            int roomnum = int.Parse(num1);
            code1 = dsroom.Tables[0].Rows[j]["roomcode"].ToString();
            if (roomnum < number)
            {
                room1 = false; break;
            }
            if (roomnum / 2 > number && roomnum > 100)
                continue;  //大考场一半容量未用，找小考场
            else
            {
                SqlParameter para9 = new SqlParameter("@roomcod", code1);
                string sqlStr7 = "insert into monitorplan ( roomcode, coursecode, coursedate, dateperiod, classcode,classnum)values(@roomcod,@coursecod,@day,@per,@classcod,@classNum)";
                SqlParameter para10 = new SqlParameter("@roomcod1", code1);
                string sqlStr8 = "update room set roombool2=1 where roomcode=@roomcod1";
                try
                {
                    DBManager.Instance().BeginTrans();
                    DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7,para1 ,para2 ,para5 ,para3 ,para9,para4  );
                    DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr8,para10 );
                    DBManager.Instance().CommitTrans();
                }
                catch (Exception)
                {
                    DBManager.Instance().RollbackTrans();
                }
                break;
            }
        }
        dsroom.Clear();
        return room1;
    }
    //+++++++++预占用考场成功
    public void SetRoomUse()//数据集为在同一考场考试的班级数据集
    {
        string sqlStr = "update room set roombool=1,roombool2=0 where roombool2=1";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++课程安排失败
    public void SetFailBool(string coursecode1)
    {
        SqlParameter para1 = new SqlParameter("@coursecod", coursecode1);
        string sqlStr = "delete from monitorplan where coursecode=@coursecod";//删除排考表里预安排的信息
        string sqlStr1 = "update teacher set teacherbool2=0 where teacherbool2=1";//清除老师预占用信息
        string sqlStr2 = "update room set roombool2=0 where roombool2=1";//清除考场预占用信息
        SqlParameter para11 = new SqlParameter("@coursecod", coursecode1);
        string sqlStr3 = "update course set coursebool2=1 where coursecode=@coursecod";//标志课程遍历安排过，即安排失败
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr,para1 );
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3,para11 );
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //++++++某课程结束，某时间段遍历初始化
    public void LittleInitial()
    {       
        string sqlStr3 = "update course set coursebool2=0 where coursebool2=1";//课程遍历标志清除
        try
        {
            DBManager.Instance().BeginTrans();            
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++某时间段安排结束：课程遍历过的设置bool2=0，老师和考场全部设为bool=0且bool2=0
    public void CycleInitial()
    {
        string sqlStr1 = "update teacher set teacherbool=0 ,teacherbool2=0";//监考老师全部可用
        string sqlStr2 = "update room set roombool=0  ,roombool2=0";//考场全部可用
        string sqlStr3 = "update course set coursebool2=0 where coursebool2=1";//课程遍历标志清除
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().CommitTrans();
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
        }
    }
    //+++++++++对于某考场的某课程考试，监考老师安排成功为1
    public bool TeacherIsEnough(DateTime Day, int period1, int examnumber, string classcode1, string coursecode1)//考试人数多于100人需要三个监考老师
    {
        int teacherneed = 0; int numL = 0; int numtall = 0;
        SqlParameter para1 = new SqlParameter("@day", Day.Date);        
        SqlParameter para4 = new SqlParameter("@classcod", classcode1);
        SqlParameter para5 = new SqlParameter("@coursecod", coursecode1);
        String teachername1 = "select teachercode,teachertel from teacher where teachercode in(select teachercode from course where classcode=@classcod and coursecode=@coursecod)";//得到该专业该课程讲师
        DataSet dsteacherLL = DBManager.Instance().ExecuteDataSet(CommandType.Text, teachername1, para4, para5);
        if (dsteacherLL.Tables[0].Rows.Count == 1)
        {
            String teachername1L = dsteacherLL.Tables[0].Rows[0]["teachercode"].ToString();
            String teacheTel1L = dsteacherLL.Tables[0].Rows[0]["teachertel"].ToString();
            SqlParameter para6 = new SqlParameter("@teachernam", teachername1L);
            SqlParameter para6j = new SqlParameter("@teacherTel", teacheTel1L);//讲师code及电话
            dsteacherLL.Clear();

            String lectorIs10 = "select distinct teachercode from teacher where teachercode not in(select teachercode from request where datecannot=@day and requestresult=1 and teachercode=@teachernam) and teacherbool=0 and teacherbool2=0  and teachercode=@teachernam ";
            DataSet dsteacherL = DBManager.Instance().ExecuteDataSet(CommandType.Text, lectorIs10, para1, para6);
            numL = dsteacherL.Tables[0].Rows.Count;//讲师当天未请假成功且可用的数据   
            dsteacherL.Clear();

            SqlParameter para101 = new SqlParameter("@day", Day.Date);//
            SqlParameter para606 = new SqlParameter("@teachernam", teachername1L);//添加两句解决：另一个 SqlParameterCollection 中已包含 SqlParameter
            String sqlStr1 = "select distinct teachercode,teachertel,teachermonnum from teacher where teachercode not in(select teacher.teachercode from request join teacher on request.teachercode=teacher.teachercode where datecannot=@day and requestresult=1)and teacherbool=0 and teacherbool2=0  and  teachercode!=@teachernam order by teachermonnum asc,teachercode asc";//可用的非该课程老师
            DataSet dsteacherall = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr1, para606, para101);//不包含讲师的所有可用老师
            numtall = dsteacherall.Tables[0].Rows.Count;

            if (examnumber > 100)
            {
                if (numL == 1) teacherneed = 2;
                else teacherneed = 3;
            }
            else
            {
                if (numL == 1) teacherneed = 1;
                else teacherneed = 2;
            }
            if (numtall >= teacherneed + 3)
            {//留3个人，一个巡考，2个机动；监考老师够用   
                if (numL == 1)//预存监考老师信息
                {
                    SqlParameter para6T = new SqlParameter("@teachernam", teachername1L);
                    SqlParameter para4T = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T = new SqlParameter("@day", Day.Date);
                    SqlParameter para2 = new SqlParameter("@per", period1);
                    string sqlStr2 = "update monitorplan set teachercode1=@teachernam,teachertel1=@teacherTel where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para62T = new SqlParameter("@teachernam", teachername1L);
                    string sqlStr3 = "update teacher set teacherbool2=1 where teachercode=@teachernam";//修改监考表里老师1的信息及老师1的预占用信息
                    try
                    {
                        DBManager.Instance().BeginTrans();
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2, para6T, para6j, para5T, para1T, para2, para4T);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3, para62T);
                        DBManager.Instance().CommitTrans();
                    }
                    catch (Exception)
                    {
                        DBManager.Instance().RollbackTrans();
                    }
                    if (examnumber > 100)//大考场，讲师在，还需要两个老师  
                    {
                        SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T2 = new SqlParameter("@per", period1);
                        string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                        string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                        SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                        SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                        string sqlStr4 = "update monitorplan set teachercode2=@teacherCode1,teachertel2=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para172 = new SqlParameter("@teacherCode1", teachercode11);
                        string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                        SqlParameter para4T3 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T3 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T3 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T3 = new SqlParameter("@per", period1);
                        string teachercode22 = dsteacherall.Tables[0].Rows[1]["teachercode"].ToString();
                        string teachertel22 = dsteacherall.Tables[0].Rows[1]["teachertel"].ToString();
                        SqlParameter para27 = new SqlParameter("@teacherCode2", teachercode22);
                        SqlParameter para29 = new SqlParameter("@teacherTel2", teachertel22);
                        string sqlStr6 = "update monitorplan set teachercode3=@teacherCode2,teachertel3=@teacherTel2 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para272 = new SqlParameter("@teacherCode2", teachercode22);
                        string sqlStr7 = "update teacher set teacherbool2=1 where teachercode=@teacherCode2";
                        try
                        {
                            DBManager.Instance().BeginTrans();
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T2, para1T2, para2T2, para4T2);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para172);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr6, para27, para29, para5T3, para1T3, para2T3, para4T3);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7, para272);
                            DBManager.Instance().CommitTrans();
                        }
                        catch (Exception)
                        {
                            DBManager.Instance().RollbackTrans();
                        }
                    }
                    else
                    {
                        SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T2 = new SqlParameter("@per", period1);
                        string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                        string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                        SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                        SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                        string sqlStr4 = "update monitorplan set teachercode2=@teacherCode1,teachertel2=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para172 = new SqlParameter("@teacherCode1", teachercode11);
                        string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                        try
                        {
                            DBManager.Instance().BeginTrans();
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T2, para1T2, para2T2, para4T2);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para172);
                            DBManager.Instance().CommitTrans();
                        }
                        catch (Exception)
                        {
                            DBManager.Instance().RollbackTrans();
                        }
                    }
                }
                else
                {
                    if (examnumber > 100)
                    {
                        SqlParameter para4T1 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T1 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T1 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T1 = new SqlParameter("@per", period1);
                        string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                        string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                        SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                        SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                        string sqlStr4 = "update monitorplan set teachercode1=@teacherCode1,teachertel1=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para171 = new SqlParameter("@teacherCode1", teachercode11);
                        string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                        SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T2 = new SqlParameter("@per", period1);
                        string teachercode22 = dsteacherall.Tables[0].Rows[1]["teachercode"].ToString();
                        string teachertel22 = dsteacherall.Tables[0].Rows[1]["teachertel"].ToString();
                        SqlParameter para27 = new SqlParameter("@teacherCode2", teachercode22);
                        SqlParameter para29 = new SqlParameter("@teacherTel2", teachertel22);
                        string sqlStr6 = "update monitorplan set teachercode2=@teacherCode2,teachertel2=@teacherTel2 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para272 = new SqlParameter("@teacherCode2", teachercode22);
                        string sqlStr7 = "update teacher set teacherbool2=1 where teachercode=@teacherCode2";
                        SqlParameter para4T3 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T3 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T3 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T3 = new SqlParameter("@per", period1);
                        string teachercode33 = dsteacherall.Tables[0].Rows[2]["teachercode"].ToString();
                        string teachertel33 = dsteacherall.Tables[0].Rows[2]["teachertel"].ToString();
                        SqlParameter para37 = new SqlParameter("@teacherCode3", teachercode33);
                        SqlParameter para39 = new SqlParameter("@teacherTel3", teachertel33);
                        string sqlStr8 = "update monitorplan set teachercode3=@teacherCode3,teachertel3=@teacherTel3 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para373 = new SqlParameter("@teacherCode3", teachercode33);
                        string sqlStr9 = "update teacher set teacherbool2=1 where teachercode=@teacherCode3";
                        try
                        {
                            DBManager.Instance().BeginTrans();
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T1, para1T1, para2T1, para4T1);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para171);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr6, para27, para29, para5T2, para1T2, para2T2, para4T2);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7, para272);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr8, para37, para39, para5T3, para1T3, para2T3, para4T3);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr9, para373);
                            DBManager.Instance().CommitTrans();
                        }
                        catch (Exception)
                        {
                            DBManager.Instance().RollbackTrans();
                        }
                    }
                    else
                    {
                        SqlParameter para4T1 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T1 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T1 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T1 = new SqlParameter("@per", period1);
                        string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                        string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                        SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                        SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                        string sqlStr4 = "update monitorplan set teachercode1=@teacherCode1,teachertel1=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para171 = new SqlParameter("@teacherCode1", teachercode11);
                        string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                        SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                        SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                        SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                        SqlParameter para2T2 = new SqlParameter("@per", period1);
                        string teachercode22 = dsteacherall.Tables[0].Rows[1]["teachercode"].ToString();
                        string teachertel22 = dsteacherall.Tables[0].Rows[1]["teachertel"].ToString();
                        SqlParameter para27 = new SqlParameter("@teacherCode2", teachercode22);
                        SqlParameter para29 = new SqlParameter("@teacherTel2", teachertel22);
                        string sqlStr6 = "update monitorplan set teachercode2=@teacherCode2,teachertel2=@teacherTel2 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                        SqlParameter para272 = new SqlParameter("@teacherCode2", teachercode22);
                        string sqlStr7 = "update teacher set teacherbool2=1 where teachercode=@teacherCode2";
                        try
                        {
                            DBManager.Instance().BeginTrans();
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T1, para1T1, para2T1, para4T1);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para171);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr6, para27, para29, para5T2, para1T2, para2T2, para4T2);
                            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7, para272);
                            DBManager.Instance().CommitTrans();
                        }
                        catch (Exception)
                        {
                            DBManager.Instance().RollbackTrans();
                        }
                    }
                }
                dsteacherall.Clear();
                dsteacherL.Clear();
                return true;
            }
            else return false;
        }
        else////课程老师不在监考老师内
        {
            SqlParameter para101 = new SqlParameter("@day", Day.Date);//            
            String sqlStr1 = "select distinct teachercode,teachertel,teachermonnum from teacher where teachercode not in(select teacher.teachercode from request join teacher on request.teachercode=teacher.teachercode where datecannot=@day and requestresult=1)and teacherbool=0 and teacherbool2=0  order by teachermonnum asc,teachercode asc";//可用的课程老师
            DataSet dsteacherall = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr1, para101);//不包含讲师的所有可用老师
            numtall = dsteacherall.Tables[0].Rows.Count;
            if (examnumber > 100)         teacherneed = 3;           
            else            teacherneed = 2;           
            if (numtall >= teacherneed + 3)
            {//留3个人，一个巡考，2个机动；监考老师够用                  
                if (examnumber > 100)
                {
                    SqlParameter para4T1 = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T1 = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T1 = new SqlParameter("@day", Day.Date);
                    SqlParameter para2T1 = new SqlParameter("@per", period1);
                    string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                    string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                    SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                    SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                    string sqlStr4 = "update monitorplan set teachercode1=@teacherCode1,teachertel1=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para171 = new SqlParameter("@teacherCode1", teachercode11);
                    string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                    SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                    SqlParameter para2T2 = new SqlParameter("@per", period1);
                    string teachercode22 = dsteacherall.Tables[0].Rows[1]["teachercode"].ToString();
                    string teachertel22 = dsteacherall.Tables[0].Rows[1]["teachertel"].ToString();
                    SqlParameter para27 = new SqlParameter("@teacherCode2", teachercode22);
                    SqlParameter para29 = new SqlParameter("@teacherTel2", teachertel22);
                    string sqlStr6 = "update monitorplan set teachercode2=@teacherCode2,teachertel2=@teacherTel2 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para272 = new SqlParameter("@teacherCode2", teachercode22);
                    string sqlStr7 = "update teacher set teacherbool2=1 where teachercode=@teacherCode2";
                    SqlParameter para4T3 = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T3 = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T3 = new SqlParameter("@day", Day.Date);
                    SqlParameter para2T3 = new SqlParameter("@per", period1);
                    string teachercode33 = dsteacherall.Tables[0].Rows[2]["teachercode"].ToString();
                    string teachertel33 = dsteacherall.Tables[0].Rows[2]["teachertel"].ToString();
                    SqlParameter para37 = new SqlParameter("@teacherCode3", teachercode33);
                    SqlParameter para39 = new SqlParameter("@teacherTel3", teachertel33);
                    string sqlStr8 = "update monitorplan set teachercode3=@teacherCode3,teachertel3=@teacherTel3 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para373 = new SqlParameter("@teacherCode3", teachercode33);
                    string sqlStr9 = "update teacher set teacherbool2=1 where teachercode=@teacherCode3";
                    try
                    {
                        DBManager.Instance().BeginTrans();
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T1, para1T1, para2T1, para4T1);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para171);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr6, para27, para29, para5T2, para1T2, para2T2, para4T2);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7, para272);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr8, para37, para39, para5T3, para1T3, para2T3, para4T3);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr9, para373);
                        DBManager.Instance().CommitTrans();
                    }
                    catch (Exception)
                    {
                        DBManager.Instance().RollbackTrans();
                    }
                }
                else
                {
                    SqlParameter para4T1 = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T1 = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T1 = new SqlParameter("@day", Day.Date);
                    SqlParameter para2T1 = new SqlParameter("@per", period1);
                    string teachercode11 = dsteacherall.Tables[0].Rows[0]["teachercode"].ToString();
                    string teachertel11 = dsteacherall.Tables[0].Rows[0]["teachertel"].ToString();
                    SqlParameter para17 = new SqlParameter("@teacherCode1", teachercode11);
                    SqlParameter para19 = new SqlParameter("@teacherTel1", teachertel11);
                    string sqlStr4 = "update monitorplan set teachercode1=@teacherCode1,teachertel1=@teacherTel1 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para171 = new SqlParameter("@teacherCode1", teachercode11);
                    string sqlStr5 = "update teacher set teacherbool2=1 where teachercode=@teacherCode1";
                    SqlParameter para4T2 = new SqlParameter("@classcod", classcode1);
                    SqlParameter para5T2 = new SqlParameter("@coursecod", coursecode1);
                    SqlParameter para1T2 = new SqlParameter("@day", Day.Date);
                    SqlParameter para2T2 = new SqlParameter("@per", period1);
                    string teachercode22 = dsteacherall.Tables[0].Rows[1]["teachercode"].ToString();
                    string teachertel22 = dsteacherall.Tables[0].Rows[1]["teachertel"].ToString();
                    SqlParameter para27 = new SqlParameter("@teacherCode2", teachercode22);
                    SqlParameter para29 = new SqlParameter("@teacherTel2", teachertel22);
                    string sqlStr6 = "update monitorplan set teachercode2=@teacherCode2,teachertel2=@teacherTel2 where coursecode=@coursecod and coursedate=@day and dateperiod=@per and classcode=@classcod";
                    SqlParameter para272 = new SqlParameter("@teacherCode2", teachercode22);
                    string sqlStr7 = "update teacher set teacherbool2=1 where teachercode=@teacherCode2";
                    try
                    {
                        DBManager.Instance().BeginTrans();
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr4, para17, para19, para5T1, para1T1, para2T1, para4T1);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr5, para171);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr6, para27, para29, para5T2, para1T2, para2T2, para4T2);
                        DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr7, para272);
                        DBManager.Instance().CommitTrans();
                    }
                    catch (Exception)
                    {
                        DBManager.Instance().RollbackTrans();
                    }
                }
                dsteacherall.Clear();                
                return true;
            }           
            else   return false;
        }
    }
    //开始制定监考
    public bool MakeMonitor()
    {
        time Time = new time();
        monitor mymon = new monitor();
        DateTime startdate = Convert.ToDateTime(Time.GetStartTime());
        DateTime endtime = Convert.ToDateTime(Time.GetEndTime());
        DateTime today = startdate;
        mymon.RelateCourseClassNum();//统计并设置课程涉及的班级数
        mymon.SetCourseNotNum();//统计所有班级的未考试数 
        while(today.CompareTo(endtime)<0||today.CompareTo(endtime)==0){        
            int period = 1;                        
            DateTime yesterday = today.AddDays(-1);//昨日考试时间            
            DataSet dsyouexam=mymon.HaveExam_Class();//还有考试的班级数据集
            if (dsyouexam.Tables[0].Rows.Count == 0) { dsyouexam.Clear(); break; }//没有班级需要考试了
            else{
                DataSet dsstillexam = mymon.YesterdayExamClass(yesterday);//昨天有考试但是还有考试的班级数据集
                if (dsstillexam.Tables[0].Rows.Count == dsyouexam.Tables[0].Rows.Count){//还需要考试的班级昨天都有考试 
                    today = today.AddDays(1); continue;}
                else{//今天有班级可以安排考试
                    dsyouexam.Clear(); dsstillexam.Clear();
                    while (period < 3){                        
                        bool roombool = true; bool teacherbool = true; bool classbool = true; bool coursebool = false ;
                        DataSet todayexamexapt = mymon.YesterdayNoExamClass(yesterday);//昨天和今天没考试但还有考试未考的班级数据集，按未考试数量降序排序                        
                        if (todayexamexapt.Tables[0].Rows.Count == 0){
                            mymon.CycleInitial(); break;//设置未考试且coursebool2=1设置为coursebool2=0；老师、考场的bool=0，进行下一循环的排考 
                        }
                        for (int i = 0; i < todayexamexapt.Tables[0].Rows.Count; i++)
                        {//今天有可以考试的班级中找到考试最多的班级
                            string class1 = todayexamexapt.Tables[0].Rows[i]["classcode"].ToString();//班级代码-----     
                            if (mymon.ClassIsOK(class1, yesterday) == false){
                                classbool = false; continue ; }
                            DataSet dsclasscourse = mymon.NotPlanCourse(class1);//该班级所有未考试且未遍历过的课程数据集，按课程涉及班级数量降序排序
                            if (dsclasscourse.Tables[0].Rows.Count == 0) continue;//如果为空，continue,寻找下一个有未考试也未遍历过课程的班级
                            for (int j = 0; j < dsclasscourse.Tables[0].Rows.Count; j++)
                            {//考试数量最多的班级，找到需考课程中涉及班级最多的课程
                                string course1 = dsclasscourse.Tables[0].Rows[j]["coursecode"].ToString();//课程代码-----                                
                                DataSet dsAllcourse = mymon.CourseRelateClass(course1);//课程涉及的班级数据集，按班级人数降序
                                if (dsAllcourse.Tables[0].Rows.Count == 0) continue;                               
                                for (int ii = 0; ii < dsAllcourse.Tables[0].Rows.Count; ii++)
                                {//对于有锁定课程的班级依次分配考场核老师                                     
                                    string class2 = dsAllcourse.Tables[0].Rows[ii]["classcode"].ToString();//找课程的班级//存入monitorplan班级、课程，日期，时间段数据
                                    if (mymon.ClassIsOK(class2,yesterday ) == false){
                                        classbool = false; break;}                                    
                                    string classnumber1 = dsAllcourse.Tables[0].Rows[ii]["classnum"].ToString();//找该班级的人数 
                                    int classnumber = int.Parse(classnumber1);
                                    bool room1 = mymon.RoomCanUse(today, period, course1, class2, classnumber);//找该班级该课程的适合的可用考场，并返回考场号
                                    if (room1)
                                    {//若考场不为空，设置该考场bool2为1，表示预占用  //存入monitorplan考场数据
                                        if (mymon.TeacherIsEnough(today, period, classnumber, class2, course1)) ;//为考场寻找监考老师，讲师分有木有预占用
                                        else
                                        {//监考老师寻找成功，设置该老师bool2为1，表示预占用；存入monitorplan监考老师数据
                                            teacherbool = false; break;} }//监考老师寻找失败，teacherbool=false,break；该课程安排失败，                                    
                                    else
                                    {//若考场为空, roombool=false,该课程安排失败
                                        roombool = false; break;}
                                }
                                if (teacherbool == true && roombool == true && classbool == true)
                                { //roombool=true and teacherbool=true，监考安排成功      
                                    coursebool = true;
                                    mymon.SetCourseHave(course1);//课程设置已考
                                    mymon.SetExamDate(today, course1);//班级考试日期设置为今日 
                                    mymon.TeacherMonSucceed();//预占用的老师bool=1,bool2=0；老师监考次数加1
                                    mymon.SetRoomUse(); break; //预占用的考场bool=1,bool2=0 
                                }
                                else{//课程安排过程中，班级不满足安排条件或监考老师或者考场不够用，课程安排失败//将该课程的排考记录删除 
                                    mymon.SetFailBool(course1);
                                if (j < dsclasscourse.Tables[0].Rows.Count) { roombool = true; teacherbool = true; classbool = true; }
                                }//考场、老师bool2=1的都将bool2=0，coursebool2=1，表示课程遍历过，但是安排未成功 
                            }
                            dsclasscourse.Clear();  
                            if (coursebool == true)
                                break;                                                      
                        }
                        mymon.LittleInitial();///
                        if (roombool == false || teacherbool == false)
                        {
                            period++; mymon.CycleInitial();//设置未考试且coursebool2=1设置为coursebool2=0；老师、考场的bool=0，进行下一循环的排考  
                        }
                    }
                }
            }  
            today = today.AddDays(1);
        }
        DataSet dsyouexamfinial =mymon.HaveExam_Class();//还有考试的班级数据集
        if (dsyouexamfinial.Tables[0].Rows.Count == 0)//排考完毕
            return true;
        else 
            return false;
    }
}
