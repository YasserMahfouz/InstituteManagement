using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class remaining
    {
        DAL.DL dl = new DAL.DL();
        public DataTable showRemain()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("showRemain", null);
            dl.disconnect();
            return dt;
        }
        public DataTable populatestudentName()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("populatestudentName", null);
            dl.disconnect();
            return dt;
        }
        public DataTable coursesList()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("coursesList", null);
            dl.disconnect();
            return dt;
        }
        public DataTable searchRemain(string id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar);
            param[0].Value = id;

            DataTable dt = new DataTable();
            dt = dl.select("searchRemain", param);
            dl.disconnect();
            return dt;
        }
    }
}
