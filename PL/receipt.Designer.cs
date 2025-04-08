namespace YGHM_STUDENTS.PL
{
    partial class receipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtModify = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcheck = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.receiptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidcheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.totalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtModify);
            this.panel1.Controls.Add(this.txtRealName);
            this.panel1.Controls.Add(this.txtStudentName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtcheck);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txtRemain);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCourseName);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCost);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtPicker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCourseId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtReceipt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 253);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(4, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 39);
            this.button3.TabIndex = 26;
            this.button3.Text = "تعديل";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(929, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 22);
            this.label11.TabIndex = 25;
            this.label11.Text = "سبب التعديل";
            this.label11.Visible = false;
            // 
            // txtModify
            // 
            this.txtModify.BackColor = System.Drawing.Color.White;
            this.txtModify.Location = new System.Drawing.Point(676, 154);
            this.txtModify.Name = "txtModify";
            this.txtModify.Size = new System.Drawing.Size(247, 29);
            this.txtModify.TabIndex = 24;
            this.txtModify.Visible = false;
            // 
            // txtRealName
            // 
            this.txtRealName.BackColor = System.Drawing.Color.White;
            this.txtRealName.Location = new System.Drawing.Point(319, 24);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.ReadOnly = true;
            this.txtRealName.Size = new System.Drawing.Size(249, 29);
            this.txtRealName.TabIndex = 23;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(319, 23);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(249, 29);
            this.txtStudentName.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(70, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(607, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 22);
            this.label10.TabIndex = 20;
            this.label10.Text = "شبكة";
            // 
            // txtcheck
            // 
            this.txtcheck.Location = new System.Drawing.Point(393, 142);
            this.txtcheck.Name = "txtcheck";
            this.txtcheck.Size = new System.Drawing.Size(175, 29);
            this.txtcheck.TabIndex = 1;
            this.txtcheck.Text = "0";
            this.txtcheck.TextChanged += new System.EventHandler(this.txtcheck_TextChanged);
            this.txtcheck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcheck_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "كاش",
            "شبكة"});
            this.comboBox1.Location = new System.Drawing.Point(333, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 30);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Visible = false;
            // 
            // txtRemain
            // 
            this.txtRemain.BackColor = System.Drawing.Color.White;
            this.txtRemain.Location = new System.Drawing.Point(748, 95);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.ReadOnly = true;
            this.txtRemain.Size = new System.Drawing.Size(175, 29);
            this.txtRemain.TabIndex = 9;
            this.txtRemain.TextChanged += new System.EventHandler(this.txtRemain_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(963, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 22);
            this.label9.TabIndex = 17;
            this.label9.Text = "المتبقي";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Enabled = false;
            this.txtCourseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCourseName.FormattingEnabled = true;
            this.txtCourseName.Location = new System.Drawing.Point(16, 27);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(228, 30);
            this.txtCourseName.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(426, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "طباعة";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(564, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "حفظ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.Location = new System.Drawing.Point(69, 91);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(175, 29);
            this.txtPrice.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "سعر الدورة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "اسم الدورة";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(393, 91);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(175, 29);
            this.txtCost.TabIndex = 0;
            this.txtCost.Text = "0";
            this.txtCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "كاش";
            // 
            // dtPicker
            // 
            this.dtPicker.CustomFormat = "dd/mm/yyyy";
            this.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicker.Location = new System.Drawing.Point(721, 209);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new System.Drawing.Size(228, 29);
            this.dtPicker.TabIndex = 7;
            this.dtPicker.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(964, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "التاريخ";
            this.label4.Visible = false;
            // 
            // txtCourseId
            // 
            this.txtCourseId.Location = new System.Drawing.Point(41, 207);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.Size = new System.Drawing.Size(175, 29);
            this.txtCourseId.TabIndex = 10;
            this.txtCourseId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "الكورس اي دي مخفي";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "اسم الطالب";
            // 
            // txtReceipt
            // 
            this.txtReceipt.BackColor = System.Drawing.Color.White;
            this.txtReceipt.Location = new System.Drawing.Point(748, 23);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Size = new System.Drawing.Size(175, 29);
            this.txtReceipt.TabIndex = 4;
            this.txtReceipt.TextChanged += new System.EventHandler(this.txtReceipt_TextChanged);
            this.txtReceipt.DoubleClick += new System.EventHandler(this.txtReceipt_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(950, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم السند";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(14, 282);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 311);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "السندات السابقة لهذا الطالب";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receiptNumber,
            this.studentId,
            this.receiptDate,
            this.paid,
            this.paidcheck,
            this.courseCode,
            this.totalCost,
            this.delete,
            this.print});
            this.dataGridView1.Location = new System.Drawing.Point(16, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(993, 234);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // receiptNumber
            // 
            this.receiptNumber.DataPropertyName = "receiptNumber";
            this.receiptNumber.HeaderText = "رقم السند";
            this.receiptNumber.Name = "receiptNumber";
            this.receiptNumber.ReadOnly = true;
            // 
            // studentId
            // 
            this.studentId.DataPropertyName = "studentId";
            this.studentId.HeaderText = "اسم الطالب";
            this.studentId.Name = "studentId";
            this.studentId.ReadOnly = true;
            this.studentId.Visible = false;
            // 
            // receiptDate
            // 
            this.receiptDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.receiptDate.DataPropertyName = "receiptDate";
            dataGridViewCellStyle19.Format = "yyyy/MM/dd";
            dataGridViewCellStyle19.NullValue = null;
            this.receiptDate.DefaultCellStyle = dataGridViewCellStyle19;
            this.receiptDate.HeaderText = "التاريخ";
            this.receiptDate.Name = "receiptDate";
            this.receiptDate.ReadOnly = true;
            // 
            // paid
            // 
            this.paid.DataPropertyName = "paid";
            this.paid.HeaderText = "كاش";
            this.paid.Name = "paid";
            this.paid.ReadOnly = true;
            // 
            // paidcheck
            // 
            this.paidcheck.DataPropertyName = "paidcheck";
            this.paidcheck.HeaderText = "شبكة";
            this.paidcheck.Name = "paidcheck";
            this.paidcheck.ReadOnly = true;
            // 
            // courseCode
            // 
            this.courseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.courseCode.DataPropertyName = "courseCode";
            this.courseCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.courseCode.HeaderText = "اسم الدورة";
            this.courseCode.Name = "courseCode";
            this.courseCode.ReadOnly = true;
            this.courseCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.courseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // totalCost
            // 
            this.totalCost.DataPropertyName = "totalCost";
            this.totalCost.HeaderText = "سعر الدورة";
            this.totalCost.Name = "totalCost";
            this.totalCost.ReadOnly = true;
            // 
            // delete
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Red;
            this.delete.DefaultCellStyle = dataGridViewCellStyle20;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete.HeaderText = "تعديل";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "تعديل";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // print
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Red;
            this.print.DefaultCellStyle = dataGridViewCellStyle21;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.print.HeaderText = "طباعة";
            this.print.Name = "print";
            this.print.ReadOnly = true;
            this.print.Text = "طباعه";
            this.print.UseColumnTextForButtonValue = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(281, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 39);
            this.button4.TabIndex = 27;
            this.button4.Text = "استمارة أول تسجيل";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 614);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "receipt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفع ايصال";
            this.Load += new System.EventHandler(this.receipt_Load);
            this.DoubleClick += new System.EventHandler(this.receipt_DoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox txtCourseName;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtCost;
        public System.Windows.Forms.DateTimePicker dtPicker;
        public System.Windows.Forms.TextBox txtCourseId;
        public System.Windows.Forms.TextBox txtReceipt;
        public System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtcheck;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtStudentName;
        public System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtModify;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidcheck;
        private System.Windows.Forms.DataGridViewComboBoxColumn courseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCost;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn print;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}