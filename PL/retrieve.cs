using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing;
using System.IO;
namespace YGHM_STUDENTS.PL
{
    public partial class retrieve : Form
    {
        moonsDataContext db = new moonsDataContext();
        retrievTableAdapters.retrieveTableAdapter ret = new retrievTableAdapters.retrieveTableAdapter();

        public retrieve()
        {
            InitializeComponent();
        }
        public Stream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, format);
                byte[] dd = ms.ToArray();
                ;

                ret.InsertQuery(Convert.ToInt32(txtNumber.Text), Convert.ToInt32(txtBill.Text), txtStudentName.Text, txtCourseName.Text, Convert.ToDecimal(txtCost.Text),
                    Convert.ToDecimal(txtTax.Text), Convert.ToDecimal(txtTotal.Text), dd, Login.userName, txtNotes.Text);
                MessageBox.Show("saved");
                return ms;
            }
            catch
            { MessageBox.Show("خطأ"); return null; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var x = db.retrieves.FirstOrDefault(y => y.number == int.Parse(txtNumber.Text));
            if (x == null)
            {

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
                var result = new Bitmap(qr.Write("معهد الأقمار للتدريب على الحاسب الألي وتعليم اللغة  " + "\n" + "السجل الضريبي: " + "300027432100003" + "\n" + " اسم الطالب " + txtStudentName.Text + "\n" + " تحريرا في " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt") + "\n" + "المبلغ المسترجع: " + txtCost.Text
                    + "\n" + "الضريبة: " + txtTax.Text + "%" + "\n" + "اجمالي المسترجع" + " " + txtTotal.Text));
                pictureBox1.Image = result;
                using (Stream stream = ImageToStream(pictureBox1.Image,
                           System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                }

            }
            else { MessageBox.Show("الاشعار موجود مسبقا"); }

        }

        private void retrieve_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { printRetrieve.reviewNumber = Convert.ToInt32(txtNumber.Text);
            printRetrieve frm = new printRetrieve();
            frm.ShowDialog();
            }
            catch { return; }
          
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCost.Text = string.Format("{0:0.00}", (Convert.ToDecimal(txtTotal.Text) / (1 + Convert.ToDecimal(txtTax.Text) / 100)));
            }
            catch { txtCost.Clear(); }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCost.Text =string.Format("{0:0.00}", (Convert.ToDecimal(txtTotal.Text) / (1 + Convert.ToDecimal(txtTax.Text) / 100)));
            }
            catch { txtCost.Clear(); }

        }
    }
}
