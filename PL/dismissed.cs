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
    public partial class dismissed : Form
    {
        BL.Dismissed d = new BL.Dismissed();
     
        DataSet2TableAdapters.DataTable2TableAdapter searchfasl = new DataSet2TableAdapters.DataTable2TableAdapter();
    
        public dismissed()
        {
            InitializeComponent();
            populteDataGrid();
        }
        void populteDataGrid()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                dataGridView1.DataSource =
            searchfasl.searchFasl();
            else
                dataGridView1.DataSource = searchfasl.searchFasl1(textBox1.Text);
            dataGridView1.Refresh();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cancel"].Index)
            {
                int id =Convert.ToInt32 (dataGridView1.CurrentRow.Cells["idCourse"].Value.ToString());
                string studentId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                DialogResult warn = MessageBox.Show(" هل أنت متأكد من الغاء فصل هذا الطالب" + " " + dataGridView1.CurrentRow.Cells["name"].Value.ToString(), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;

                searchfasl.cancelFasl(studentId, id);
                populteDataGrid();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dismissed_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            populteDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rep.forPrint frm = new rep.forPrint();
            rep.mafsoleenPrint rpt = new rep.mafsoleenPrint();
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }
    }
}
