using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.DAL
{
    class DL
    {
        public SqlConnection sql;
        public DL() {

            sql = new SqlConnection(@"server=.\sqlexpress;database=moons;integrated security=true");
        }
        public void connect() {
            if (sql.State != ConnectionState.Open)
                sql.Open();
        }
        public void disconnect() {

            if (sql.State != ConnectionState.Closed)
                sql.Close();
        }
        public DataTable select(string storedprocedure, SqlParameter[] param)
        {
           
            SqlCommand cmd = new SqlCommand(storedprocedure, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            if (param!=null)
            cmd.Parameters.AddRange(param);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        
            return dt;  
        }
        public void execute(string storedprocedure, SqlParameter[] param)
        {

            SqlCommand cmd = new SqlCommand(storedprocedure, sql);
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null)
                cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
           
        }
    }
}
