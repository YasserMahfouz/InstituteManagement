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
    public partial class billQuery : Form
    {

        moonsDataContext db = new moonsDataContext();
        DataSet1TableAdapters.updatereceipt updateRecip = new DataSet1TableAdapters.updatereceipt();
        moonsDataSetTableAdapters.StatisticsTableAdapter statistics = new moonsDataSetTableAdapters.StatisticsTableAdapter();
        bool shouldDelete = false;
       
        int courseId;
        decimal cost;
        decimal remain;
       
        public billQuery()
        {
            InitializeComponent();
        }

        private void billQuery_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            shouldDelete = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var x = db.receipts.FirstOrDefault(y => y.receiptNumber == int.Parse(txtReceipt.Text));
                var yy = db.courseDetails.FirstOrDefault(zz => zz.id == x.courseId);

                if (x == null)
                {
                    shouldDelete = false;
                    txtReceipt.BackColor = Color.Red;
                    return;

                }
                txtReceipt.BackColor = Color.White;

                string id = x.studentId;
                courseId = x.courseId;
                cost = x.paid + x.paidcheck;
                txtBillValue.Text = cost.ToString();
                remain = x.remain;
                txtRemain.Text = remain.ToString();
                string courseName = x.courseName.Trim();
                txtCourseName.Text = courseName;
                var z = db.students.FirstOrDefault(y => y.id == id);
                string name = z.name.Trim();
                txtStudentName.Text = name;
                txtTax.Text = yy.tax.ToString();

                shouldDelete = true;
            }
            catch
            {
                txtReceipt.BackColor = Color.Red;
                return;
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shouldDelete == true && txtPass.Text == "aboRakan")
            {
                var xx = db.courseDetails.FirstOrDefault(y => y.id == courseId);
                xx.remain += cost;
                db.SubmitChanges();
                updateRecip.DeleteReceipt(int.Parse(txtReceipt.Text));
                shouldDelete = false;
                MessageBox.Show("تم الحذف");

            }
            else { MessageBox.Show("تأكد أولا من الفاتورة أو كلمة السر"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = statistics.GetStatistics(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            decimal sum = 0;
            for (int i=0;i< dataGridView1.Rows.Count;i++)
            {
                DataGridViewRow r=dataGridView1.Rows[i];
                if (r != null)
                {
                    sum = sum +Convert.ToDecimal( r.Cells[1].Value);
                
                }
            }
            label10.Text ="الاجمالي: "+ sum.ToString();
        }

        private void txtReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2_Click(sender,e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            observingBills frm = new observingBills();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (shouldDelete == true)
            {
                retrievTableAdapters.maxRetrieve retrieve = new retrievTableAdapters.maxRetrieve();
                PL.retrieve frm = new PL.retrieve();
                frm.txtBill.Text = txtReceipt.Text;
                frm.txtStudentName.Text = txtStudentName.Text;
                frm.txtCourseName.Text = txtCourseName.Text;
                frm.txtTax.Text =string.Format("{0:0.00}", txtTax.Text);
                frm.txtTotal.Text =string.Format("{0:0.00}", txtBillValue.Text);
                frm.txtNumber.Text = retrieve.maxret().Rows[0][0].ToString();
                frm.txtCost.Text = string.Format("{0:0.00}",(Convert.ToDecimal(frm.txtTotal.Text) / (1 + Convert.ToDecimal(txtTax.Text) / 100)));
               
                frm.ShowDialog();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            retrieve frm = new retrieve();
            frm.txtNumber.ReadOnly = false;
            frm.button1.Enabled = false;
            frm.ShowDialog();
        }
    }
}
