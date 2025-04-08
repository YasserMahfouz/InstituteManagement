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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }

        private void Classes_Load(object sender, EventArgs e)
        {
            moonsDataSetTableAdapters.courseDetails1TableAdapter c = new moonsDataSetTableAdapters.courseDetails1TableAdapter();
            dataGridView1.DataSource = c.GetData(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moonsDataSetTableAdapters.courseDetails1TableAdapter c = new moonsDataSetTableAdapters.courseDetails1TableAdapter();
            dataGridView1.DataSource = c.GetData(); 

        }
    }
}
