using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Record
    {
        DAL.DL dl = new DAL.DL();
        public DataTable coursesList()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("coursesList", null);
            dl.disconnect();
            return dt;
        }
        public void addStudent(string id, string name, string mobile, string nation)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.NChar);
            param[0].Value = id;
            param[1] = new SqlParameter("@name", SqlDbType.NChar);
            param[1].Value = name;
            param[2] = new SqlParameter("@mobile", SqlDbType.NChar);
            param[2].Value = mobile;
            param[3] = new SqlParameter("@nation", SqlDbType.NChar);
            param[3].Value = nation;
            dl.execute("addStudent", param);
            dl.disconnect();
        }
       
        public void addCourse(string studentId, int courseCode, string courseNumber, DateTime startDate,DateTime enDate,decimal cost,decimal tax,int classNo)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@studentId", SqlDbType.NChar);
            param[0].Value = studentId;
            param[1] = new SqlParameter("@courseCode", SqlDbType.Int);
            param[1].Value = courseCode;
            param[2] = new SqlParameter("@courseNumber", SqlDbType.NChar);
            param[2].Value = courseNumber;
            param[3] = new SqlParameter("@startDate", SqlDbType.Date);
            param[3].Value = startDate;
            param[4] = new SqlParameter("@enDate", SqlDbType.Date);
            param[4].Value = enDate;
            param[5] = new SqlParameter("@cost", SqlDbType.Decimal);
            param[5].Value = cost;
            param[6] = new SqlParameter("@tax", SqlDbType.Decimal);
            param[6].Value = tax;
            param[7] = new SqlParameter("@classNo", SqlDbType.Int);
            param[7].Value = classNo;
            dl.execute("addCourse", param);
            dl.disconnect();
        }
        public DataTable calcEndDate(int code)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@code", SqlDbType.Int);
            param[0].Value = code;
            
            DataTable dt = new DataTable();
            dt = dl.select("calcEndDate", param);
            dl.disconnect();
            return dt;
        }
        public DataTable showCourses(string studentId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@studentId", SqlDbType.NChar);
            param[0].Value = studentId;

            DataTable dt = new DataTable();
            dt = dl.select("showCourses", param);
            dl.disconnect();
            return dt;
        }
        public void delCourse(int id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dl.execute("delCourse", param);
            dl.disconnect();
        }
    }
}
