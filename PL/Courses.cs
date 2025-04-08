using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGHM_STUDENTS.PL
{

    public partial class Courses : Form
    {
        BL.Courses c = new BL.Courses();
        public Courses()
        {
            InitializeComponent(); populateDatagrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Courses_Load(object sender, EventArgs e)
        {

        }
        void populateDatagrid()
        {
            dataGridView1.DataSource = c.coursesList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
                {
                    DialogResult warn = MessageBox.Show("هل أنت متأكد من حذف هذه الدورة من سجلات جميع الطلاب", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (warn != DialogResult.OK)
                        return;
                    PL.Password p = new PL.Password();
                    DialogResult r = p.ShowDialog();
                    if (Properties.Settings.Default.password != "aboRakan")
                        return;
                    c.delCourseMenu(Convert.ToInt32(dataGridView1.CurrentRow.Cells["code"].Value.ToString()));
                    populateDatagrid();
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("لا يمكن حذف الدورة");
            }


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = dataGridView1.CurrentRow;
                if (dataGridView1.CurrentRow != null)
                {
                    if (row.Cells["code"].Value != DBNull.Value)
                    {
                        c.addUpdateCourse(row.Cells["code"].Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["code"].Value),
                        row.Cells["courseName"].Value == DBNull.Value ? "-" : (row.Cells["courseName"].Value.ToString()),
                         row.Cells["duration"].Value == DBNull.Value ? 0 : (Convert.ToInt32(row.Cells["duration"].Value.ToString())));
                        populateDatagrid();
                    }
                    else
                    {
                        c.addUpdateCourse(0,
                            row.Cells["courseName"].Value == DBNull.Value ? "-" : (row.Cells["courseName"].Value.ToString()),
                             row.Cells["duration"].Value == DBNull.Value ? 0 : (Convert.ToInt32(row.Cells["courseName"].Value.ToString())));
                        populateDatagrid();
                    }
                }

            }
            catch
            {
                MessageBox.Show("ربما أدخلت أحد الحقول بطريقة خاطئة");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
