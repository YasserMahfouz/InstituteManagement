using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Extend
    {
        DAL.DL dl = new DAL.DL();
        public DataTable extendCourse(string studentId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@studentId", SqlDbType.VarChar);
            param[0].Value = studentId;

            DataTable dt = new DataTable();
            dt = dl.select("extendCourse", param);
            dl.disconnect();
            return dt;
        }

        public DataTable getDuration(int code)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@code", SqlDbType.Int);
            param[0].Value = code;

            DataTable dt = new DataTable();
            dt = dl.select("getDuration", param);
            dl.disconnect();
            return dt;
        }
        public DataTable certif(int courseId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = courseId;

            DataTable dt = new DataTable();
            dt = dl.select("certif", param);
            dl.disconnect();
            return dt;
        }
        public void extendEndCourse(int numMonth, int id, string studentId)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@numMonth", SqlDbType.Int);
            param[0].Value = numMonth;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            param[2] = new SqlParameter("@studentId", SqlDbType.VarChar);
            param[2].Value = studentId;

            dl.execute("extendEndCourse", param);
            dl.disconnect();

        }
        public void grade(int courseId, decimal ratio, string grade,DateTime start,DateTime en)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = courseId;
            param[1] = new SqlParameter("@ratio", SqlDbType.Float);
            param[1].Value = ratio;
            param[2] = new SqlParameter("@grade", SqlDbType.NChar);
            param[2].Value = grade;
            param[3] = new SqlParameter("@startDate", SqlDbType.DateTime);
            param[3].Value = start;
            param[4] = new SqlParameter("@enDate", SqlDbType.DateTime);
            param[4].Value = en;
            dl.execute("grade", param);
            dl.disconnect();

        }
        public void changeCourse(int courseCode, int id, string courseName, int duration)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@courseCode", SqlDbType.Int);
            param[0].Value = courseCode;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            param[2] = new SqlParameter("@courseName", SqlDbType.NChar);
            param[2].Value = courseName;
            param[3] = new SqlParameter("@duration", SqlDbType.Int);
            param[3].Value = duration;
            dl.execute("changeCourse", param);
            dl.disconnect();
        }
    }
}
