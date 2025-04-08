using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YGHM_STUDENTS
{
    public partial class Form1 : Form
    {
        bool shouldActivate = false;
        moonsDataContext db = new moonsDataContext();
        moonsDataSetTableAdapters.all table = new moonsDataSetTableAdapters.all();
        DataSet1TableAdapters.DataTable1TableAdapter mainDel = new DataSet1TableAdapters.DataTable1TableAdapter();
        DataSet1TableAdapters.courseDetailsTableAdapter donefaslgetClass = new DataSet1TableAdapters.courseDetailsTableAdapter();
        DataSet1TableAdapters.courseDetails1TableAdapter showCourses = new DataSet1TableAdapters.courseDetails1TableAdapter();
        DataSet1TableAdapters.DataTable2TableAdapter searchMains = new DataSet1TableAdapters.DataTable2TableAdapter();
        DataSet1TableAdapters.DataTable3TableAdapter courseList = new DataSet1TableAdapters.DataTable3TableAdapter();
        DataSet1TableAdapters.DataTable4TableAdapter getNation = new DataSet1TableAdapters.DataTable4TableAdapter();
        DataSet1TableAdapters.courseDetails2TableAdapter getClass = new DataSet1TableAdapters.courseDetails2TableAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = mainDel.mainView();
                if (PL.Login.type != "admin")
                {

                    button1.Enabled = false;
                    button2.Enabled = false;
                    button6.Enabled = false;
                }

            }
            catch
            {

                return;
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            shouldActivate = true;
            Record frm = new Record();
            Record.edit = false;
            frm.ShowDialog();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            courseCodeCbx();
           
            
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                shouldActivate = false;
                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

                DialogResult warn = MessageBox.Show(" هل أنت متأكد من حذف هذا الطالب" + " " + dataGridView1.CurrentRow.Cells["name"].Value.ToString(), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;
                PL.Password p = new PL.Password();
                DialogResult r = p.ShowDialog();
                if (Properties.Settings.Default.password != PL.Login.userName+PL.Login.pass)
                {
                    MessageBox.Show("كلمة المرور خطأ");
                    return;
                }
                int m = (from x in db.receipts where x.studentId == id select x).Count();
                if (m > 0)
                {
                    MessageBox.Show("لا يمكن حذف الطالب لوجود فواتير مدفوعة");
                    return;
                }
                try { mainDel.delStudent(id); }
                catch { MessageBox.Show("لا يمكن حذف الطالب لوجود فواتير مدفوعه"); }

                dataGridView1.DataSource = mainDel.mainView();
            }
            if (e.ColumnIndex == dataGridView1.Columns["fasl"].Index)
            {
                shouldActivate = false;
                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                int courseId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["courseId"].Value.ToString());
                DialogResult warn = MessageBox.Show(" هل أنت متأكد من فصل هذا الطالب" + " " + dataGridView1.CurrentRow.Cells["name"].Value.ToString(), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;

                //m.fasl(id, courseId);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "بحث بالاسم أو الجوال أو الهويه أو رقم الدورة")
                textBox1.Text = "";



        }
        void searchMain()
        {
            DataTable dt = new DataTable();
            string search;

            try
            {
                if (textBox1.Text != string.Empty)
                {
                    search = textBox1.Text;
                    dt = searchMains.searchMain(search);
                    dataGridView1.DataSource = dt;

                }
                else
                    dataGridView1.DataSource = mainDel.mainView();
            }
            catch
            {

                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shouldActivate = true;
            Record frm = new Record();
            Record.edit = true;
            frm.txtName.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString().Trim();
            Record.realName = frm.txtName.Text;
            frm.txtMobile.Text = dataGridView1.CurrentRow.Cells["mobile"].Value.ToString().Trim();
            frm.txtIqama.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            frm.txtIqama.ReadOnly = true;
            frm.txtNation.Text = getNation.getNation(frm.txtIqama.Text).Rows[0][0].ToString();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            searchMain();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button8_Click(sender, e);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            moonsDataSet ser = new moonsDataSet();
            try
            {
                if (shouldActivate)
                {
                    dataGridView1.DataSource = mainDel.mainView();
                    courseCodeCbx();
                }

            }
            catch (Exception)
            {

                return;
            }


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            courseCodeCbx();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void courseCodeCbx()
        {
            DataTable dt = new DataTable();
            courseCode.ValueMember = "code";
            courseCode.DisplayMember = "courseName";
            dt = courseList.coursesList();
            courseCode.DataSource = dt;
            dataGridView2.DataSource = showCourses.showCourses(dataGridView1.CurrentRow.Cells["id"].Value.ToString());

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shouldActivate = false;
            PL.remaining frm = new PL.remaining();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shouldActivate = false;
            PL.Courses frm = new PL.Courses();
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            shouldActivate = false;
            PL.dismissed frm = new PL.dismissed();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shouldActivate = true;
            PL.extend frm = new PL.extend();
            frm.textBox1.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString().Trim();
            frm.ShowDialog();
        }
       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.ColumnIndex == dataGridView2.Columns["company"].Index)
            {
              
                     return;
            
            }
            if (e.ColumnIndex == dataGridView2.Columns["done"].Index)
            {
                shouldActivate = false;
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["coursess"].Value.ToString());

                DialogResult warn = MessageBox.Show(" هل أنت متأكد من انهاء الدورة لن تظهر في الشهور الاضافية " + " " + dataGridView1.CurrentRow.Cells["name"].Value.ToString(), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;

                donefaslgetClass.done(id);
                MessageBox.Show("تم الانهاء");
                courseCodeCbx();
                return;
            }
            if (e.ColumnIndex == dataGridView2.Columns["changeCompany"].Index)
            {

                companyCheckBox(); courseCodeCbx(); return;


            }
            if (e.ColumnIndex == dataGridView2.Columns["fasls"].Index)
            {
                shouldActivate = false;
                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                int courseId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["coursess"].Value.ToString());
                DialogResult warn = MessageBox.Show(" هل أنت متأكد من فصل هذا الطالب" + " " + dataGridView1.CurrentRow.Cells["name"].Value.ToString(), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;

                donefaslgetClass.fasl(id, courseId);
                courseCodeCbx();
                return;
            }
            else
            {

                shouldActivate = false;
                MessageBox.Show("رقم القاعة" + "\n" + getClass.getClass(Convert.ToInt32(dataGridView2.CurrentRow.Cells["coursess"].Value.ToString())).Rows[0][0].ToString());


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            shouldActivate = false;
            this.Cursor = Cursors.WaitCursor;

            qima frm = new qima();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                courseCodeCbx();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            searchMain();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; searchMain();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            shouldActivate = false;
            PL.billQuery frm = new PL.billQuery();
            frm.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            shouldActivate = false;
            PL.billQuery frm = new PL.billQuery();
            frm.ShowDialog();
        }
        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int m1;
            int m2;
            if (d1 < d2)
            {
                m1 = (d2.Month - d1.Month);//for years
                m2 = (d2.Year - d1.Year) * 12; //for months
                return m1 + m2;
            }
            else
            {
                m1 = (d1.Month - d2.Month);//for years
                m2 = (d1.Year - d2.Year) * 12; //for months
                return (m1 + m2) * -1;
            }


        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["fasldata"].Value.ToString()) == 1)
            {
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            if (Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["donedata"].Value.ToString()) == 1)
            {
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Green;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;

            }
            if (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["remain"].Value.ToString()) > 0)
            {
                dataGridView2.Rows[e.RowIndex].Cells["cost"].Style.BackColor = Color.Yellow;
                dataGridView2.Rows[e.RowIndex].Cells["cost"].Style.ForeColor = Color.Black;
                dataGridView2.Rows[e.RowIndex].Cells["cost"].Style.SelectionBackColor = Color.Yellow;
                dataGridView2.Rows[e.RowIndex].Cells["cost"].Style.SelectionForeColor = Color.Black;

            }
            DateTime d1 = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["startDate"].Value.ToString());
            DateTime d2 = DateTime.Now;
            int diff = MonthDiff(d1, d2);
            if (diff >= 1 && Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["remain"].Value.ToString()) == 0 && Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["fasldata"].Value.ToString()) == 0 && Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["donedata"].Value.ToString()) == 0)
            {
                dataGridView2.Rows[e.RowIndex].Cells["courseCode"].Style.BackColor = Color.Blue;
                dataGridView2.Rows[e.RowIndex].Cells["courseCode"].Style.ForeColor = Color.White;
                dataGridView2.Rows[e.RowIndex].Cells["courseCode"].Style.SelectionBackColor = Color.Blue;
                dataGridView2.Rows[e.RowIndex].Cells["courseCode"].Style.SelectionForeColor = Color.White;
            }
        }
      
        void companyCheckBox()
        {

            if (dataGridView2.CurrentRow != null)
            {
                shouldActivate = false;
                if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells["company"].Value) == true)
                {
                    if (Convert.ToDecimal(dataGridView2.CurrentRow.Cells["remain"].Value.ToString()) > 0)
                    {
                        MessageBox.Show("يجب الغاء قسط الدورة عن طريق تغيير سعر الدورة بحيث لا يوجد باقي");
                        dataGridView2.CurrentRow.Cells["company"].Value = false;
                        return;
                    }
                    PL.Password frm = new PL.Password();
                    frm.ShowDialog();
                    if (Properties.Settings.Default.password == PL.Login.userName+PL.Login.pass)
                    {
                        int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["coursess"].Value.ToString());
                        donefaslgetClass.updatestudentCompany(true, id);
                        Properties.Settings.Default.password = "";
                        return;
                        //courseCodeCbx();
                    }
                    else
                    { MessageBox.Show("لم يتم التعديل"); dataGridView2.CurrentRow.Cells["company"].Value = false; dataGridView2.Refresh(); return; }

                }
                if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells["company"].Value) == false)
                {
                    PL.Password frm = new PL.Password();
                    frm.ShowDialog();
                    if (Properties.Settings.Default.password == "aboRakan")
                    {
                        int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["coursess"].Value.ToString());
                        donefaslgetClass.updatestudentCompany(false, id);

                        Properties.Settings.Default.password = "";
                        //courseCodeCbx();
                    }
                    else
                    { MessageBox.Show("لم يتم التعديل"); dataGridView2.CurrentRow.Cells["company"].Value = true; }
                }
            }
        }
        
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
