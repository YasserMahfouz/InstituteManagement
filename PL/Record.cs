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

namespace YGHM_STUDENTS
{
    public partial class Record : Form
    {
        moonsDataContext db = new moonsDataContext();
        public static bool edit = false;
        public static string realName;
        //BL.Record r = new BL.Record();
        DataSet1TableAdapters.courseDetails1TableAdapter showCourses = new DataSet1TableAdapters.courseDetails1TableAdapter();
        DataSet1TableAdapters.DataTable3TableAdapter corseList = new DataSet1TableAdapters.DataTable3TableAdapter();
        DataSet1TableAdapters.studentsTableAdapter addStudent = new DataSet1TableAdapters.studentsTableAdapter();
        DataSet1TableAdapters.courseDetailsTableAdapter addCourse = new DataSet1TableAdapters.courseDetailsTableAdapter();
        DataSet1TableAdapters.courseMenusTableAdapter calcEnd = new DataSet1TableAdapters.courseMenusTableAdapter();
        DataSet1TableAdapters.DataTable1TableAdapter mainDel = new DataSet1TableAdapters.DataTable1TableAdapter();
        DateTime endDate;
        public Record()
        {
            InitializeComponent();
            populatecmbList();
            courseCodeCbx();
            dataGridView1.DataSource = showCourses.showCourses(txtIqama.Text);
            txtTax.Text = Properties.Settings.Default.tax.ToString();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void populatecmbList() {
            DataTable dt = new DataTable();
            cmbList.ValueMember = "code";
            cmbList.DisplayMember = "courseName";
            dt= corseList.coursesList();
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "-- اسم الدورة--";
            dt.Rows.InsertAt(row, 0);
            cmbList.DataSource = dt;
           
        }
        public void courseCodeCbx()
        {
            try
            {
                DataTable dt = new DataTable();
                courseCode.ValueMember = "code";
                courseCode.DisplayMember = "courseName";
                dt = corseList.coursesList();
                courseCode.DataSource = dt;
                dataGridView1.DataSource = showCourses.showCourses(txtIqama.Text);
            }
            catch (Exception)
            {
                
                return;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(txtIqama.Text) || string.IsNullOrEmpty(txtNation.Text))
            {
                MessageBox.Show("يوجد حقول غير مكتملة", "Error");
                return;
            }
            //label1.Text = dataGridView1.Rows[0].Cells["courseCode"].Value.ToString();
            //label2.Text = cmbList.SelectedValue.ToString();
            foreach (DataGridViewRow r in dataGridView1.Rows) {
                if (r.Cells["courseCode"].Value.ToString() == cmbList.SelectedValue.ToString()
                    && ((DateTime)r.Cells["startDate"].Value).Month == ((DateTime)dtPicker.Value).Month
                     && ((DateTime)r.Cells["startDate"].Value).Year == ((DateTime)dtPicker.Value).Year) { MessageBox.Show("مينفعش  تسجل نفس الدورة في نفس الشهر"); return; }
            }
            if (edit == false)
            {
                moonsDataContext db = new moonsDataContext();
                int n = (from x in db.students where x.id == txtIqama.Text select x.id).Count();
                if (n == 1)
                {
                    student st = new student();

                    st = (from x in db.students where x.id == txtIqama.Text select x).First();
                    txtName.Text = st.name.Trim();
                    txtMobile.Text = st.mobile.Trim();
                    txtNation.Text = st.nation.Trim();
                    lblRepeat.Text = "رقم الهويه المسجل يخص هذا الطالب";
                    lblRepeat.Visible = true;
                    courseCodeCbx();
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        if (r.Cells["courseCode"].Value.ToString() == cmbList.SelectedValue.ToString()
                            && ((DateTime)r.Cells["startDate"].Value).Month == ((DateTime)dtPicker.Value).Month
                             && ((DateTime)r.Cells["startDate"].Value).Year == ((DateTime)dtPicker.Value).Year) { MessageBox.Show("مينفعش  تسجل نفس الدورة في نفس الشهر"); return; }
                    }
                }
                else
                    lblRepeat.Visible = false;

            }
            else
            {
                addStudent.InsertStudent(txtIqama.Text, txtName.Text, txtMobile.Text, txtNation.Text);
                addStudent.updateStudent(txtName.Text, txtMobile.Text, txtNation.Text, txtIqama.Text);
                realName = txtName.Text;
                MessageBox.Show("تم تعديل بيانات الطالب");
                if (string.IsNullOrEmpty(txtCourseNumber.Text) || string.IsNullOrEmpty(txtCost.Text) || string.IsNullOrEmpty(txtTax.Text) || cmbList.SelectedIndex == 0)
                    return;
            }
           
            if(string.IsNullOrEmpty(txtCourseNumber.Text)||string.IsNullOrEmpty(txtCost.Text)||string.IsNullOrEmpty(txtTax.Text)||cmbList.SelectedIndex==0)
            {   MessageBox.Show(" يوجد حقول غير مكتملة في تسجيل الدورة", "Error");
                return;}
            endDate=Convert.ToDateTime(dtPicker.Value.AddMonths(Convert.ToInt32(calcEnd.calcEndDate(Convert.ToInt32(cmbList.SelectedValue)).Rows[0][0].ToString())));
            decimal total=
                Convert.ToDecimal(txtCost.Text);
            int num = 0;
            if (txtClass.Text != string.Empty)
                num = Convert.ToInt32(txtClass.Text);
            addStudent.InsertStudent(txtIqama.Text, txtName.Text, txtMobile.Text, txtNation.Text);
            addStudent.updateStudent(txtName.Text, txtMobile.Text, txtNation.Text, txtIqama.Text);
            //MessageBox.Show("تم اضافة الطالب");
            addCourse.addCourse(txtIqama.Text, Convert.ToInt32(cmbList.SelectedValue.ToString()), txtCourseNumber.Text, dtPicker.Value, endDate, total, Convert.ToDecimal(txtTax.Text.Replace('%', ' ')), num,checkBox1.Checked);
            MessageBox.Show("تمت الاضافة");
            courseCodeCbx();

        }

        private void txtIqama_TextChanged(object sender, EventArgs e)
        {
            clearGrid();
        }
        private void clearGrid() {
            if (edit == false)
            {
                while (dataGridView1.Rows.Count != 0)
                    dataGridView1.Rows.RemoveAt(0);
            }
        
        }

        private void Record_Load(object sender, EventArgs e)
        {
            if(edit==true)
                courseCodeCbx();
            else
            txtNation.SelectedIndex= 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex==dataGridView1.Columns["delete"].Index)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                DialogResult warn = MessageBox.Show("هل أنت متأكد من حذف هذه الدورة", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;
                PL.Password p = new PL.Password();
                DialogResult rr = p.ShowDialog();
                if (Properties.Settings.Default.password != PL.Login.userName+PL.Login.pass)
                    return;
                int m = (from x in db.receipts where (x.courseId == id) select x.courseId).Count();
                if (m > 0)
                {

                    MessageBox.Show("لا يمكن حذف الدورة لوجود ايصالات دفع");
                    return;
                }
                addCourse.delCourse(id);
                courseCodeCbx();


                if (dataGridView1.Rows.Count == 0)
                {
                    mainDel.delStudent(txtIqama.Text);
                    MessageBox.Show("تم حذف بيانات الطالب ايضاً لعدم وجود دورات له");
                }


            }
            if (e.ColumnIndex == dataGridView1.Columns["pay"].Index)
            {
                PL.receipt frm = new PL.receipt();
                frm.populatestudentName();
                if (edit == false)
                    frm.txtRealName.Text = txtName.Text.Trim();
                else
                    frm.txtRealName.Text = realName.Trim();
                frm.txtStudentName.Text = txtIqama.Text;
                frm.txtCourseName.SelectedValue = dataGridView1.CurrentRow.Cells["courseCode"].Value.ToString();
                frm.txtPrice.Text = dataGridView1.CurrentRow.Cells["cost"].Value.ToString();
                frm.txtCourseId.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                frm.ShowDialog();
               

            }
           
                if (e.ColumnIndex == dataGridView1.Columns["document"].Index)
                {
                   
                    {
                        if (db.receipts.Where(x => x.courseId == Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString())).Count() > 0)
                        {
                            estimaraForm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                            estimaraForm frm = new estimaraForm();
                            frm.ShowDialog();
                        }
                        else {
                            copyOfStudentForm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                            copyOfStudentForm frm = new copyOfStudentForm();
                            frm.ShowDialog();
                        
                        }
                    }
                  
                }
           
         



        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtIqama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCourseNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                e.Handled = true;
        }

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
                return;
           
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCost.Text) || string.IsNullOrEmpty(txtTax.Text))
            {
                lblCost.Text = "";
                lblTotal.Text = "";
                return; }
            double cost = Convert.ToDouble(txtCost.Text) /(1+ Convert.ToDouble(txtTax.Text.Replace('%', ' '))/100);
            lblCost.Text = string.Format("{0:0.00}", cost);//حساب المبلغ الاساسي من الاجمالي

            lblTotal.Text =
              string.Format("{0:0.00}", Convert.ToDouble(txtCost.Text)- cost);// حساب قيمة الضريبة
           
        
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.tax =(txtTax.TextLength>0? Convert.ToDecimal(txtTax.Text):0);
            Properties.Settings.Default.Save();
            if (string.IsNullOrEmpty(txtCost.Text) || string.IsNullOrEmpty(txtTax.Text))
            {  lblCost.Text = "";
            lblTotal.Text = ""; return;
            }
            double cost = Convert.ToDouble(txtCost.Text) / (1 + Convert.ToDouble(txtTax.Text.Replace('%', ' ')) / 100);
            lblCost.Text = string.Format("{0:0.00}", cost);//حساب المبلغ الاساسي من الاجمالي

            lblTotal.Text =
              string.Format("{0:0.00}", Convert.ToDouble(txtCost.Text) - cost);// حساب قيمة الضريبة
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            clearGrid();
        }

        private void cmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbList_Click(object sender, EventArgs e)
        {
            

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PL.Classes c = new PL.Classes();
            c.Show();
            

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            clearGrid();
        }

        private void txtNation_TextChanged(object sender, EventArgs e)
        {
            clearGrid();
        }

        private void Record_Activated(object sender, EventArgs e)
        {
            courseCodeCbx();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCost.Text=(checkBox1.Checked?"0":"");
            txtCost.ReadOnly = (checkBox1.Checked ? true : false);
        }


    }
}
