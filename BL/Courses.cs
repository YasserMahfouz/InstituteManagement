using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Courses
    {
        DAL.DL dl = new DAL.DL();
        public DataTable coursesList()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("coursesList",null);
            dl.disconnect();
            return dt;
        }
        public void delCourseMenu(int id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@code", SqlDbType.Int);
            param[0].Value = id;

            dl.execute("delCourseMenu", param);
            dl.disconnect();
        }
        public void addUpdateCourse(int code, string courseName, int duration)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@code", SqlDbType.Int);
            param[0].Value = code;
            param[1] = new SqlParameter("@courseName", SqlDbType.NChar);
            param[1].Value = courseName;
            param[2] = new SqlParameter("@duration", SqlDbType.Int);
            param[2].Value = duration;
            dl.execute("addUpdateCourse", param);
            dl.disconnect();
        }
    }
}
