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
    public partial class remaining : Form
    {
        BL.remaining r = new BL.remaining();
        //DataSet1TableAdapters.students1TableAdapter populateName = new DataSet1TableAdapters.students1TableAdapter();
        //moonsDataSetTableAdapters.courseMenusTableAdapter courseslist = new moonsDataSetTableAdapters.courseMenusTableAdapter();
        //DataSet2TableAdapters.courseDetails1TableAdapter showremain = new DataSet2TableAdapters.courseDetails1TableAdapter();
        DataSet2TableAdapters.DataTable4TableAdapter showremain = new DataSet2TableAdapters.DataTable4TableAdapter();
        //DataSet2TableAdapters.courseMenusTableAdapter courseList = new DataSet2TableAdapters.courseMenusTableAdapter();
        public remaining()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void remaining_Load(object sender, EventArgs e)
        {
            //studentId.ValueMember = "id";
            //studentId.DisplayMember = "name";
            //courseCode.ValueMember = "code";
            //courseCode.DisplayMember = "courseName";
            //studentId.DataSource = populateName.populatestudentName();

            //courseCode.DataSource = courseList.coursesList();
            //dataGridView1.DataSource = showremain.showRemain();
            dataGridView2.DataSource = showremain.showRemain();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                //dataGridView1.DataSource = searchRemain.searchRemain(textBox1.Text);
                dataGridView2.DataSource = showremain.searchRemain(textBox1.Text);

            }
            else
            {  //dataGridView1.DataSource = showremain.showRemain();
                dataGridView2.DataSource = showremain.showRemain();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //rep.forPrint frm = new rep.forPrint();
            //rep.additionalmonthPrint rpt=new rep.additionalmonthPrint();
            //rpt.Refresh();
            //frm.crystalReportViewer1.ReportSource = rpt;
            //frm.ShowDialog();
            kists frm = new kists();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            rep.forPrint frm = new rep.forPrint();
            rep.carts rpt = new rep.carts();
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }
    }
}
