using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGHM_STUDENTS.BL
{
    class Receipt
    {
        DAL.DL dl = new DAL.DL();
        public DataTable populatestudentName()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("populatestudentName", null);
            dl.disconnect();
            return dt;
        }
        public DataTable receiptRemain( int courseId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];
           
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;
            DataTable dt = new DataTable();
            dt = dl.select("receiptRemain", param);
            dl.disconnect();
            return dt;
        }
        public DataTable sanadPrint(int receiptNumber)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@receiptNumber", SqlDbType.Int);
            param[0].Value = receiptNumber;
            DataTable dt = new DataTable();
            dt = dl.select("sanadPrint", param);
            dl.disconnect();
            return dt;
        }
        public DataTable receiptMenu(string studentId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@studentId", SqlDbType.NChar);
            param[0].Value = studentId;
            DataTable dt = new DataTable();
            dt = dl.select("receiptMenu", param);
            dl.disconnect();
            return dt;
        }
        public DataTable getCourseId(int receiptNumber)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@receiptNumber", SqlDbType.Int);
            param[0].Value = receiptNumber;
            DataTable dt = new DataTable();
            dt = dl.select("getCourseId", param);
            dl.disconnect();
            return dt;
        }
        public DataTable maxReciptforCourseid(int courseId)
        {
            dl.connect();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;
            DataTable dt = new DataTable();
            dt = dl.select("maxReciptforCourseid", param);
            dl.disconnect();
            return dt;
        }
        public DataTable maxReceipt()
        {
            dl.connect();
            DataTable dt = new DataTable();
            dt = dl.select("maxReceipt", null);
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
        public void insertReceipt(int receiptNumber, string studentId, int courseId, DateTime receiptDate, decimal paid,decimal paidcheck, int courseCode, decimal totalCost, string courseName, decimal remain,string cash)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@receiptNumber", SqlDbType.Int);
            param[0].Value = receiptNumber;
            param[1] = new SqlParameter("@studentId", SqlDbType.VarChar);
            param[1].Value = studentId;
            param[2] = new SqlParameter("@courseId", SqlDbType.Int);
            param[2].Value = courseId;
            param[3] = new SqlParameter("@receiptDate", SqlDbType.Date);
            param[3].Value = receiptDate;
            param[4] = new SqlParameter("@paid", SqlDbType.Float);
            param[4].Value = paid;
            param[5] = new SqlParameter("@courseCode", SqlDbType.Int);
            param[5].Value = courseCode;
            param[6] = new SqlParameter("@totalCost", SqlDbType.Float);
            param[6].Value = totalCost;
            param[7] = new SqlParameter("@courseName", SqlDbType.NChar);
            param[7].Value = courseName;
            param[8] = new SqlParameter("@remain", SqlDbType.Float);
            param[8].Value = remain;
            param[9] = new SqlParameter("@cash", SqlDbType.NChar);
            param[9].Value = cash;
            param[10] = new SqlParameter("@paidcheck", SqlDbType.Float);
            param[10].Value = paidcheck;
            dl.execute("insertReceipt", param);
            dl.disconnect();

        }
        public void updateReceipt(int receiptNumber, double paid,double paidcheck, double remain, int courseId,string cash)
        {

            dl.connect();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@receiptNumber", SqlDbType.Int);
            param[0].Value = receiptNumber;
            param[1] = new SqlParameter("@paid", SqlDbType.Float);
            param[1].Value = paid;
            param[2] = new SqlParameter("@remain", SqlDbType.Float);
            param[2].Value = remain;
            param[3] = new SqlParameter("@courseId", SqlDbType.Int);
            param[3].Value = courseId;
            param[4] = new SqlParameter("@cash", SqlDbType.NChar);
            param[4].Value = cash;
            param[5] = new SqlParameter("@paidcheck", SqlDbType.Float);
            param[5].Value = paidcheck;
            dl.execute("updateReceipt", param);
            dl.disconnect();

        }
        
    }
}
