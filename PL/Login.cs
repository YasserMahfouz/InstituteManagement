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
    public partial class Login : Form
    {
        int counterUser = 0;
        int counter = 0;
        public static string type;
        public static string userName;

        moonsDataContext db = new moonsDataContext();
        moonsDataSetTableAdapters.usersTableAdapter user = new moonsDataSetTableAdapters.usersTableAdapter();
        public static int i = 0;
        public static string pass = null;
        public Login()
        {
            InitializeComponent(); textBox1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int m = (from row in db.users where (row.userName == textBox1.Text && row.password == textBox2.Text) select row).Count();

                if (m > 0)
                {
                    pass = (from row in db.users where (row.userName == textBox1.Text && row.password == textBox2.Text) select row.password).First();

                    type = (from row in db.users where (row.userName == textBox1.Text && row.password == textBox2.Text) select row.type).First();
                    userName = textBox1.Text;
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else { MessageBox.Show("اسم المستخدم أو كلمة السر غير صحيحة"); }
            }
            catch 
            {
                
               MessageBox.Show("خطأ بالوصول للمعلومات");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int m = (from row in db.users where (row.userName == textBox1.Text && row.password == textBox2.Text) select row).Count();
                if (m <= 0)
                {
                    MessageBox.Show("اسم المستخدم وكلمة السر غير صحيحين");
                    return;
                }
                this.Size = new Size(503, 371);
                button1.Location = new Point(350, 267);
                button2.Location = new Point(180, 267);
                button3.Location = new Point(15, 267);
                lblnew.Visible = true;
                counter++;
                txtnew.Visible = true;
                button2.Text = "حفظ";
                if (counter < 2)
                    return;
                if (string.IsNullOrEmpty(txtnew.Text))
                {
                    MessageBox.Show("يجب تحديد كلمة السر الجديدة");
                    return;
                }
                user.changePassword(txtnew.Text, textBox1.Text);
                MessageBox.Show("تم تغيير كلمة المرور");
                txtnew.Clear();
                button1.Location = new Point(350, 193);
                button2.Location = new Point(180, 193);
                button3.Location = new Point(15, 193);
                lblnew.Visible = false;
                txtnew.Visible = false;
                counter = 0;
                button2.Text = "تغيير كلمة السر";
                this.Size = new Size(503, 287);
            }
            catch 
            {
                
              MessageBox.Show("خطأ بالوصول للمعلومات");
            }

               

        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1_Click(sender, e); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Size = new Size(503, 444);
                button1.Location = new Point(350, 340);
                button2.Location = new Point(180, 340);
                button3.Location = new Point(15, 340);
                txtnew.Visible = true;
                txtnew.PasswordChar = (char)0;
                textBox3.Visible = true;
                comboBox1.SelectedIndex = 0;
                lblnew.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                comboBox1.Visible = true;
                label1.Text = "اسم المسئول";
                label2.Text = "كلمة سر المسئول";
                lblnew.Text = "اسم المستخدم الجديد";
                label3.Text = "كلمة سر المستخدم";
                counterUser++;
                button3.Text = "حفظ";
                if (counterUser < 2)
                    return;
                int m = (from row in db.users where (row.userName == textBox1.Text && row.password == textBox2.Text && row.type == "admin") select row).Count();
                if (m <= 0)
                {
                    MessageBox.Show("لست مؤهلا لانشاء مستخدم جديد"); return;
                }
                if (!string.IsNullOrEmpty(txtnew.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {

                    user.Insert(txtnew.Text, textBox3.Text, comboBox1.Text);
                    MessageBox.Show("تم انشاء مستخدم جديد");
                    txtnew.Clear();
                    textBox3.Clear();
                    textBox2.Clear();
                    counterUser = 0;
                    button1.Location = new Point(350, 193);
                    button2.Location = new Point(180, 193);
                    button3.Location = new Point(15, 193);
                    lblnew.Visible = false;
                    txtnew.Visible = false;
                    label3.Visible = false;
                    label1.Text = "اسم المستخدم";
                    label2.Text = "كلمة السر";
                    this.Size = new Size(503, 287);
                    button3.Text = "مستخدم جديد";
                    comboBox1.Visible = false;
                    label4.Visible = false;
                    textBox3.Visible = false;
                    txtnew.PasswordChar = '*';

                }
            }
            catch 
            {
                MessageBox.Show("تم انتهاء صلاحية البرنامج");
                
            }

        }

        private void txtnew_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1_Click(sender, e); }

        }
    }
}
