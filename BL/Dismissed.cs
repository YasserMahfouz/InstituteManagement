using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Dismissed
    {
        DAL.DL dl = new DAL.DL();
        public DataTable searchFasl(string name)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar);
            param[0].Value = name;

            DataTable dt = new DataTable();
            dt = dl.select("searchFasl", param);
            dl.disconnect();
            return dt;
        }
        public DataTable cancelFasl(string studentId, int id)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@studentId", SqlDbType.VarChar);
            param[0].Value = studentId;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            DataTable dt = new DataTable();
            dt = dl.select("cancelFasl", param);
            dl.disconnect();
            return dt;
        }
    }
}
