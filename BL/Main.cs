using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Main
    {
        DAL.DL dl = new DAL.DL();
        public DataTable mainView()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("mainView", null);
            dl.disconnect();
            return dt;
        }
        public void delStudent(string id)
        {
             
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NChar);
            param[0].Value = id;

            dl.execute("delStudent", param);
            dl.disconnect();
        
        }
        public void done(int courseId)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;

            dl.execute("done", param);
            dl.disconnect();

        }
        public void fasl(string studentId, int id)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@studentId", SqlDbType.NChar);
            param[0].Value = studentId;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            dl.execute("fasl", param);
            dl.disconnect();

        }
        public DataTable searchMain(string id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@token", SqlDbType.VarChar);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dt = dl.select("searchMain", param);
            dl.disconnect();
            return dt;
        }
        public DataTable getClass(int id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dt = dl.select("getClass", param);
            dl.disconnect();
            return dt;
        }
        public DataTable getNation(string id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NChar);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dt = dl.select("getNation", param);
            dl.disconnect();
            return dt;
        }

    }
}
