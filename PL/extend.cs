using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGHM_STUDENTS.PL
{
    public partial class extend : Form
    {
        DataSet1TableAdapters.DataTable3TableAdapter corseList = new DataSet1TableAdapters.DataTable3TableAdapter();
        int duration;
        BL.Extend ex = new BL.Extend();
        public extend()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                e.Handled = true;
        }

        private void extend_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            cmbList.ValueMember = "code";
            cmbList.DisplayMember = "courseName";
            dt = corseList.coursesList();
            cmbList.DataSource = dt;
        }
        public void populatecombo(){
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "courseName";
            comboBox1.DataSource = ex.extendCourse(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            populatecombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    return;
                ex.extendEndCourse(Convert.ToInt32(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue.ToString()), textBox1.Text);
                MessageBox.Show("تم التأجيل ");
            }
            catch 
            {
                
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ex.grade(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txtRatio.Text), txtGrade.Text,dateTimePicker1.Value,dateTimePicker2.Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

                rep.forPrint frm = new rep.forPrint();
                rep.certif rpt = new rep.certif();
                rpt.Refresh();
                //rpt.SetParameterValue(0, Convert.ToInt32(comboBox1.SelectedValue));
                rpt.SetDataSource(ex.certif(Convert.ToInt32(comboBox1.SelectedValue)));
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.courseDetailsTableAdapter canceldone = new DataSet1TableAdapters.courseDetailsTableAdapter();
            canceldone.cancelDone(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            MessageBox.Show("تم الغاء الانهاء");
        }

        private void cmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            duration = (int)ex.getDuration(Convert.ToInt32(cmbList.SelectedValue.ToString())).Rows[0][0];
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("are you sure to change the course", "changing course...", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                ex.changeCourse(Convert.ToInt32(cmbList.SelectedValue.ToString()), Convert.ToInt32(comboBox1.SelectedValue), cmbList.Text, duration);
                MessageBox.Show("changed");
            }
        }
    }
}
