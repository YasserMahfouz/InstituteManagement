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
using System.IO;
using ZXing;
using ZXing.QrCode;

namespace YGHM_STUDENTS.PL
{
    public partial class receipt : Form
    {
        decimal oldValue;
        BL.Receipt recip = new BL.Receipt();
        moonsDataContext db = new moonsDataContext();
        DataSet1TableAdapters.students1TableAdapter populateName = new DataSet1TableAdapters.students1TableAdapter();
        DataSet1TableAdapters.DataTable5TableAdapter receiptRemain = new DataSet1TableAdapters.DataTable5TableAdapter();
        DataSet1TableAdapters.DataTable3TableAdapter coursesList = new DataSet1TableAdapters.DataTable3TableAdapter();
        DataSet1TableAdapters.maxReceipts maxReceiptx = new DataSet1TableAdapters.maxReceipts();
        DataSet1TableAdapters.receiptmenu receiptmenu = new DataSet1TableAdapters.receiptmenu();
        DataSet1TableAdapters.maxreceiptforcourseid maxreceiptforcourse = new DataSet1TableAdapters.maxreceiptforcourseid();
        DataSet1TableAdapters.updatereceipt updateRecip = new DataSet1TableAdapters.updatereceipt();
        DataSet1TableAdapters.getCourseid getcourseid = new DataSet1TableAdapters.getCourseid();
        DataSet1TableAdapters.DataTable5TableAdapter receiptremain = new DataSet1TableAdapters.DataTable5TableAdapter();
        DataSet1TableAdapters.courseDetails3TableAdapter getTax = new DataSet1TableAdapters.courseDetails3TableAdapter();
        moonsDataSetTableAdapters.modifyTableAdapter modify = new moonsDataSetTableAdapters.modifyTableAdapter();
        int temporaryReceiptNumber = 0;
        moonsDataSetTableAdapters.courseDetailsTableAdapter costModify = new moonsDataSetTableAdapters.courseDetailsTableAdapter();
        moonsDataSetTableAdapters.receiptTableAdapter receiptR = new moonsDataSetTableAdapters.receiptTableAdapter();
        int id;
        int counter = 0;
        decimal oldCost;
        public receipt()
        {
            InitializeComponent();
          
        }

        public Stream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            byte[] dd = ms.ToArray();
            ;
          
            updateRecip.barCode(dd,Convert.ToInt32(txtReceipt.Text));
            return ms;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void populatestudentName()
        {
          
            populateCourseName();
            maxReceipt();


        }
        public decimal lastreceiptRemain()
        {

            decimal val = Convert.ToDecimal(receiptRemain.receiptRemain(Convert.ToInt32(txtCourseId.Text)).Rows[0][0].ToString());
           if (val >= 0)
               return val;
           else
               return Convert.ToDecimal(txtPrice.Text);
        }
        public void populateCourseName()
        {
            txtCourseName.ValueMember = "code";
            txtCourseName.DisplayMember = "courseName";
            txtCourseName.DataSource = coursesList.coursesList();
            courseCode.ValueMember = "code";
            courseCode.DisplayMember = "courseName";
            courseCode.DataSource = coursesList.coursesList();
        }
        public void maxReceipt() {
            
            txtReceipt.Text = maxReceiptx.maxReceipt().Rows[0][0].ToString();
           
        }
        private void txtStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void receipt_Load(object sender, EventArgs e)
        {
            txtRemain.Text = lastreceiptRemain().ToString();
            txtCost.Focus(); dataGridView1.DataSource = receiptmenu.receiptMenu(txtStudentName.Text);
            comboBox1.SelectedIndex = 0;
            dataGridView1.Columns["delete"].Visible = false;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal A = Convert.ToDecimal(txtCost.Text);
            decimal B = Convert.ToDecimal(txtcheck.Text);
            decimal C = Convert.ToDecimal(txtRemain.Text);
            if (A == 0 && B == 0 && C == 0) { return; }
            if (Convert.ToDouble(txtRemain.Text) < 0)
            {
                MessageBox.Show("أدخل قيمة صحيحة");
                return;
            }
            try
            {
                if (button1.Text == "تعديل")
                {
                    int nn = (from x in db.receipts where (x.receiptNumber == Convert.ToInt32(txtReceipt.Text)) select x.receiptNumber).Count();
                    if (nn == 0)
                    {
                        moonsDataSetTableAdapters.receiptTableAdapter table = new moonsDataSetTableAdapters.receiptTableAdapter();
                        table.UpdateQuery(Convert.ToInt32(txtReceipt.Text), temporaryReceiptNumber);

                    }
                    else if (Convert.ToInt32(txtReceipt.Text) != temporaryReceiptNumber)
                    {
                        MessageBox.Show("خطأ هذا يخص رقم مستند اخر");
                        return;
                    }
                    int courseid = Convert.ToInt32(txtCourseId.Text);//new
                    //if (Convert.ToInt32(maxreceiptforcourse.maxReceiptforCourseid(courseid).Rows[0][0].ToString()) == Convert.ToInt32(txtReceipt.Text))
                    //{
                        int m = (from x in db.receipts where (x.receiptNumber == Convert.ToInt32(txtReceipt.Text) && x.studentId == dataGridView1.CurrentRow.Cells["studentId"].Value.ToString()) select x.receiptNumber).Count();
                        if (m > 0)
                        {
                            updateRecip.updateReceipt(Convert.ToDecimal(txtCost.Text), Convert.ToDecimal(txtcheck.Text), Convert.ToDecimal(txtRemain.Text), comboBox1.Text, Convert.ToInt32(txtReceipt.Text));
                            updateRecip.updateReceipt2(Convert.ToDecimal(txtRemain.Text), Convert.ToInt32(txtCourseId.Text));
                            modify.Insert1(Convert.ToInt32(txtReceipt.Text), oldValue, Convert.ToDecimal(txtCost.Text) + Convert.ToDecimal(txtcheck.Text), txtModify.Text, Login.userName);
                            MessageBox.Show("تم الحفظ بنجاح");
                            button4.Enabled = true;
                            decimal taxi = (from x in db.courseDetails where (x.id == Convert.ToInt32(txtCourseId.Text)) select x.tax).First();// للحصول على نسبة الضريبة

                            DateTime tarikh = (from x in db.receipts where x.receiptNumber == Convert.ToInt32(txtReceipt.Text) select x.receiptDate).First();
                            DateTime sa3a =(DateTime)( (from x in db.receipts where x.receiptNumber == Convert.ToInt32(txtReceipt.Text) select x.actTim).First());





                            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                            options = new QrCodeEncodingOptions
                            {
                                DisableECI = true,
                                CharacterSet = "UTF-8",
                                Width = 250,
                                Height = 250,
                            };
                            var writer = new BarcodeWriter();
                            writer.Format = BarcodeFormat.QR_CODE;
                            writer.Options = options;
                            var qr = new ZXing.BarcodeWriter();
                            qr.Options = options;
                            qr.Format = ZXing.BarcodeFormat.QR_CODE;
                            var result = new Bitmap(qr.Write("معهد الأقمار للتدريب على الحاسب الألي وتعليم اللغة  " + "\n" + "السجل الضريبي: " + "300027432100003" + "\n" + " اسم الطالب " + txtRealName.Text.Trim() + "\n" + " تحريرا في " + tarikh.ToString("dd/MM/yyyy") + " " + sa3a.ToString("hh:mm:ss tt") + "\n" + " المبلغ المستلم " + string.Format("{0:0.00}", (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) / (1 + Convert.ToDouble(taxi) / 100)) + "\n" + " القيمة المضافة" + " " + taxi + "%" + "\n" + " اجمالي القيمة المضافة " + string.Format("{0:0.00}", (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) - (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) / (1 + Convert.ToDouble(taxi) / 100)) + "\n" + " اجمالي الفاتورة " + (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text))));
                            pictureBox1.Image = result;







                            //BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                            //pictureBox1.Image = writer.Write(txtReceipt.Text.Trim());
                            using (Stream stream = ImageToStream(pictureBox1.Image,
                                                       System.Drawing.Imaging.ImageFormat.Jpeg))
                            {
                            }












                            dataGridView1.DataSource = receiptmenu.receiptMenu(txtStudentName.Text);
                            button1.Enabled = false;
                            button2.Enabled = true;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("رقم السند مسجل مسبقا اختر رقم أخر، لا يمكن الحفظ");
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("لا يمكن التعديل في هذا السند لانه ليس الاخير");
                    //}
                    return;
                }

                int n = (from x in db.receipts where x.receiptNumber == Convert.ToInt32(txtReceipt.Text) select x.receiptNumber).Count();
                if (n > 0) {
                    MessageBox.Show("رقم السند مسجل مسبقا اختر رقم أخر، لا يمكن الحفظ");
                    return;
                }
                updateRecip.insertReceipt(Convert.ToInt32(txtReceipt.Text), 
                    txtStudentName.Text.Trim(),
                   Convert.ToInt32(txtCourseId.Text),
                   dtPicker.Value.ToString(),
                   Convert.ToDecimal(txtCost.Text),
                   Convert.ToDecimal(txtcheck.Text),
                   Convert.ToInt32(txtCourseName.SelectedValue.ToString())
                    , Convert.ToDecimal(txtPrice.Text),
                    txtCourseName.Text,
                    Convert.ToDecimal(txtRemain.Text),
                    comboBox1.Text);
                updateRecip.updateReceipt2(Convert.ToDecimal(txtRemain.Text), Convert.ToInt32(txtCourseId.Text));
                MessageBox.Show("تم الحفظ بنجاح");



                decimal taxis = (from x in db.courseDetails where (x.id == Convert.ToInt32(txtCourseId.Text)) select x.tax).First();// للحصول على نسبة الضريبة

                DateTime tarikhs = (from x in db.receipts where x.receiptNumber == Convert.ToInt32(txtReceipt.Text) select x.receiptDate).First();
                DateTime sa3as = (DateTime)((from x in db.receipts where x.receiptNumber == Convert.ToInt32(txtReceipt.Text) select x.actTim).First());


                QrCodeEncodingOptions optionss = new QrCodeEncodingOptions();
                optionss = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 250,
                    Height = 250,
                };
                var writers = new BarcodeWriter();
                writers.Format = BarcodeFormat.QR_CODE;
                writers.Options = optionss;
                var qrs = new ZXing.BarcodeWriter();
                qrs.Options = optionss;
                qrs.Format = ZXing.BarcodeFormat.QR_CODE;
                decimal first=Convert.ToDecimal(txtPrice.Text);
                decimal second = first
              ;

                string dareba = string.Format("{0:0.00}", second);

                var results = new Bitmap(qrs.Write("معهد الأقمار للتدريب على الحاسب الألي وتعليم اللغة  " + "\n" + "السجل الضريبي: " + "300027432100003" + "\n" + " اسم الطالب " + txtRealName.Text.Trim() + "\n" + " تحريرا في " + tarikhs.ToString("dd/MM/yyyy") + " " + sa3as.ToString("hh:mm:ss tt") + "\n" + " المبلغ المستلم " + string.Format("{0:0.00}", (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) / (1 + Convert.ToDouble(taxis) / 100)) + "\n" + " القيمة المضافة" + " " + taxis + "%" + "\n" + " اجمالي القيمة المضافة " + string.Format("{0:0.00}", (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) - (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text)) / (1 + Convert.ToDouble(taxis) / 100)) + "\n" + " اجمالي الفاتورة " + (Convert.ToDouble(txtCost.Text) + Convert.ToDouble(txtcheck.Text))));
                pictureBox1.Image = results;









                //BarcodeWriter writers = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                //pictureBox1.Image = writers.Write(txtReceipt.Text.Trim());
                using (Stream stream = ImageToStream(pictureBox1.Image,
                                           System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                }
                button2.Enabled = true;
                dataGridView1.DataSource = receiptmenu.receiptMenu(txtStudentName.Text);
                button1.Enabled = false;


            }
            catch
            {

            }
        }
        public static decimal remainModify;

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCost.Text))
                txtCost.Text = "0";

            if (button1.Text == "تعديل")
            {
                if (!string.IsNullOrEmpty(txtcheck.Text) && !string.IsNullOrEmpty(txtCost.Text))
                    txtRemain.Text = (remainModify - Convert.ToDecimal(txtCost.Text) - Convert.ToDecimal(txtcheck.Text)).ToString();
                else
                {
                    txtCost.Text = "0";
                    txtcheck.Text = "0";
                }
                return;
            }
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                
                if (string.IsNullOrEmpty(txtcheck.Text))
                    txtRemain.Text = lastreceiptRemain().ToString();
                else
                    txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtcheck.Text)).ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(txtcheck.Text))
                txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtCost.Text)).ToString();
                else
                    txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtCost.Text) - Convert.ToDecimal(txtcheck.Text)).ToString();

            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //rep.forPrint frm = new rep.forPrint();
            //rep.sanadPrint rpt = new rep.sanadPrint();
            //rpt.SetDataSource(recip.sanadPrint(Convert.ToInt32(txtReceipt.Text)));
            //frm.crystalReportViewer1.ReportSource=rpt;
            //frm.ShowDialog();
            bool firstBill = (from x in db.receipts where (x.courseId == Convert.ToInt32(txtCourseId.Text)) select x.receiptNumber).Min() == Convert.ToInt32(txtReceipt.Text);
            if (firstBill)
            {
                sanadat frms = new sanadat();
                sanadat.sanadNumber = Convert.ToInt32(txtReceipt.Text);
                frms.ShowDialog();
            }
            else {

                SanadForKist frms = new SanadForKist();
                SanadForKist.sanadNumber = Convert.ToInt32(txtReceipt.Text);
                frms.ShowDialog();
            }
            this.Cursor = Cursors.Default;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index)
            {
                PL.Password p = new PL.Password();
                DialogResult rr = p.ShowDialog();
                if (Properties.Settings.Default.password != Login.userName+Login.pass)
                {
                    MessageBox.Show("كلمة المرور خطأ");
                    return; }
                txtReceipt.ReadOnly = true;
                DialogResult warn = MessageBox.Show("هل أنت متأكد من تعديل هذه الايصال", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (warn != DialogResult.OK)
                    return;

                button1.Text = "تعديل";
                txtReceipt.Text = dataGridView1.CurrentRow.Cells["receiptNumber"].Value.ToString();
                temporaryReceiptNumber = Convert.ToInt32(txtReceipt.Text);

                txtCourseName.SelectedValue = dataGridView1.CurrentRow.Cells["courseCode"].Value;
                dtPicker.Value =Convert.ToDateTime( dataGridView1.CurrentRow.Cells["receiptDate"].Value.ToString());
                txtPrice.Text = dataGridView1.CurrentRow.Cells["totalCost"].Value.ToString();
                txtCost.Text = "0";
                int courseid=Convert.ToInt32(getcourseid.getCourseId (Convert.ToInt32( txtReceipt.Text)).Rows[0][0].ToString());
                decimal val = Convert.ToDecimal(receiptremain.receiptRemain(Convert.ToInt32(courseid)).Rows[0][0].ToString());
                decimal remain = val + Convert.ToDecimal(dataGridView1.CurrentRow.Cells["paid"].Value.ToString());
                remain = remain + Convert.ToDecimal(dataGridView1.CurrentRow.Cells["paidcheck"].Value.ToString());
                txtRemain.Text = remain.ToString();
                txtCourseId.Text = courseid.ToString();
                remainModify = remain;
                oldValue = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["paid"].Value.ToString()) + Convert.ToDecimal(dataGridView1.CurrentRow.Cells["paidcheck"].Value.ToString());
                txtModify.Visible = true; label11.Visible = true;

            }

            if (e.ColumnIndex == dataGridView1.Columns["print"].Index)
            {
                this.Cursor = Cursors.WaitCursor;

                //rep.forPrint frm = new rep.forPrint();
                //rep.sanadPrint rpt = new rep.sanadPrint();
                //rpt.SetDataSource(recip.sanadPrint(Convert.ToInt32(dataGridView1.CurrentRow.Cells["receiptNumber"].Value.ToString())));
                //frm.crystalReportViewer1.ReportSource = rpt;
                //frm.ShowDialog();
                int sanadNumber= Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentRow.Cells["receiptNumber"].Value.ToString()));
                int courseId = (from x in db.receipts where x.receiptNumber == sanadNumber select x.courseId).First();
                bool firstBill = (from x in db.receipts where (x.courseId == courseId) select x.receiptNumber).Min() == sanadNumber;
                if (firstBill)
                {
                    sanadat.sanadNumber = sanadNumber;
                    sanadat frms = new sanadat();
                    frms.ShowDialog();
                }
                else {
                    SanadForKist.sanadNumber = sanadNumber;
                    SanadForKist frms = new SanadForKist();
                    frms.ShowDialog();
                }
                this.Cursor = Cursors.Default;
                

            }
        }

        private void txtRemain_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtReceipt_DoubleClick(object sender, EventArgs e)
        {
            //if (button1.Text == "تعديل")
            //{ }
            //else 
            //txtReceipt.ReadOnly = false;
        }

        private void txtReceipt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtcheck_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcheck.Text))
                txtcheck.Text = "0";
            if (button1.Text == "تعديل")
            {
                if (!string.IsNullOrEmpty(txtcheck.Text) && !string.IsNullOrEmpty(txtCost.Text))
                    txtRemain.Text = (remainModify - Convert.ToDecimal(txtCost.Text) - Convert.ToDecimal(txtcheck.Text)).ToString();
                else
                { txtCost.Text = "0";
                txtcheck.Text = "0";
                }
                return;
            }
            if (string.IsNullOrEmpty(txtcheck.Text))
            {
                if (string.IsNullOrEmpty(txtCost.Text))
                    txtRemain.Text = lastreceiptRemain().ToString();
                else
                    txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtCost.Text)).ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(txtCost.Text))
                    txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtcheck.Text)).ToString();
                else
                    txtRemain.Text = (lastreceiptRemain() - Convert.ToDecimal(txtCost.Text) - Convert.ToDecimal(txtcheck.Text)).ToString();

            }
        }

        private void txtcheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                e.Handled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPrice.ReadOnly = false;
            if (counter == 0)
            {
                id = Convert.ToInt32(txtCourseId.Text);
                counter++;
                oldCost = Convert.ToDecimal(txtPrice.Text);
                button1.Enabled = false;
                button3.Text = "حفظ";

            }
            else
            {
                if (!String.IsNullOrEmpty(txtPrice.Text) && id == Convert.ToInt32(txtCourseId.Text) && txtcheck.Text == "0" && txtCost.Text == "0"&&button1.Text!="تعديل")
                {
                    if (oldCost > Convert.ToDecimal(txtPrice.Text))
                    {
                        decimal txt = Convert.ToDecimal(txtPrice.Text);
                        decimal remain = Convert.ToDecimal(txtRemain.Text) - (oldCost - Convert.ToDecimal(txtPrice.Text));
                        if (remain < 0) { MessageBox.Show("خطأ"); return; }
                        costModify.updateCost(txt, remain, id);
                        MessageBox.Show("تم الحفظ");
                        DataTable dt = new DataTable();
                        dt = receiptR.getReceiptNumber(id);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            receiptR.updateRemain((oldCost - Convert.ToDecimal(txtPrice.Text)) * -1, txt, Convert.ToInt32(dt.Rows[i][0]));
                        }
                        txtRemain.Text = remain.ToString();
                        counter = 0;
                        button3.Text = "تعديل";
                        txtPrice.ReadOnly = true; dataGridView1.DataSource = receiptmenu.receiptMenu(txtStudentName.Text);
                    }
                    else if (oldCost < Convert.ToDecimal(txtPrice.Text))
                    {
                        decimal txt = Convert.ToDecimal(txtPrice.Text);

                        decimal remain = Convert.ToDecimal(txtRemain.Text) + (Convert.ToDecimal(txtPrice.Text) - oldCost);
                        if (remain < 0) { MessageBox.Show("خطأ"); return; }

                        costModify.updateCost(txt, remain, id);

                        MessageBox.Show("تم الحفظ"); counter = 0; txtPrice.ReadOnly = true; txtRemain.Text = remain.ToString();
                        DataTable dt = new DataTable();
                        dt = receiptR.getReceiptNumber(id);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            receiptR.updateRemain((Convert.ToDecimal(txtPrice.Text) - oldCost)  , txt, Convert.ToInt32(dt.Rows[i][0]));
                        }
                        button3.Text = "تعديل";
                        dataGridView1.DataSource = receiptmenu.receiptMenu(txtStudentName.Text);

                    }
                }
                else
                {
                    MessageBox.Show("خطأ");
                }
            }
        }

        private void receipt_DoubleClick(object sender, EventArgs e)
        {
            button3.Visible = true;
            dataGridView1.Columns["delete"].Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (db.receipts.Where(x => x.courseId == Convert.ToInt32(txtCourseId.Text)).Count() > 0)
            {
                estimaraForm.id = Convert.ToInt32(txtCourseId.Text);
                estimaraForm frm = new estimaraForm();
                frm.ShowDialog();
            }
            else
            {
                copyOfStudentForm.id = Convert.ToInt32(txtCourseId.Text);
                copyOfStudentForm frm = new copyOfStudentForm();
                frm.ShowDialog();

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (db.receipts.Where(x => x.courseId == Convert.ToInt32(txtCourseId.Text)).Count() > 0)
            {
                estimaraForm.id = Convert.ToInt32(txtCourseId.Text);
                estimaraForm frm = new estimaraForm();
                frm.ShowDialog();
            }
            else
            {
                copyOfStudentForm.id = Convert.ToInt32(txtCourseId.Text);
                copyOfStudentForm frm = new copyOfStudentForm();
                frm.ShowDialog();

            }

        }
    }
}
