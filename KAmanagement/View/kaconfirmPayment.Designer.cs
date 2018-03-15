namespace KAmanagement.View
{
    partial class kaconfirmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kaconfirmPayment));
            this.lb_doc = new System.Windows.Forms.Label();
            this.lbtextamount = new System.Windows.Forms.Label();
            this.lbuntextamount = new System.Windows.Forms.Label();
            this.txtpaidnote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBactchdoc = new System.Windows.Forms.Label();
            this.lbpayid = new System.Windows.Forms.Label();
            this.lbsubid = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpaidnote2 = new System.Windows.Forms.TextBox();
            this.pickdatedoneon = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbpaymentamt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbcontractno = new System.Windows.Forms.Label();
            this.lb_programe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaydoc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_doc
            // 
            this.lb_doc.AutoSize = true;
            this.lb_doc.Location = new System.Drawing.Point(9, 33);
            this.lb_doc.Name = "lb_doc";
            this.lb_doc.Size = new System.Drawing.Size(55, 13);
            this.lb_doc.TabIndex = 12;
            this.lb_doc.Text = "Bacth No.";
            // 
            // lbtextamount
            // 
            this.lbtextamount.AutoSize = true;
            this.lbtextamount.Location = new System.Drawing.Point(9, 74);
            this.lbtextamount.Name = "lbtextamount";
            this.lbtextamount.Size = new System.Drawing.Size(39, 13);
            this.lbtextamount.TabIndex = 14;
            this.lbtextamount.Text = "Pay ID";
            // 
            // lbuntextamount
            // 
            this.lbuntextamount.AutoSize = true;
            this.lbuntextamount.Location = new System.Drawing.Point(9, 98);
            this.lbuntextamount.Name = "lbuntextamount";
            this.lbuntextamount.Size = new System.Drawing.Size(40, 13);
            this.lbuntextamount.TabIndex = 16;
            this.lbuntextamount.Text = "Sub ID";
            // 
            // txtpaidnote
            // 
            this.txtpaidnote.Location = new System.Drawing.Point(87, 212);
            this.txtpaidnote.Name = "txtpaidnote";
            this.txtpaidnote.Size = new System.Drawing.Size(241, 20);
            this.txtpaidnote.TabIndex = 2;
            this.txtpaidnote.Tag = "2";
            this.txtpaidnote.TextChanged += new System.EventHandler(this.txtpaidnote_TextChanged);
            this.txtpaidnote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txconfimr_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Description";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // lbBactchdoc
            // 
            this.lbBactchdoc.AutoSize = true;
            this.lbBactchdoc.ForeColor = System.Drawing.Color.Magenta;
            this.lbBactchdoc.Location = new System.Drawing.Point(90, 33);
            this.lbBactchdoc.Name = "lbBactchdoc";
            this.lbBactchdoc.Size = new System.Drawing.Size(35, 13);
            this.lbBactchdoc.TabIndex = 21;
            this.lbBactchdoc.Text = "label1";
            // 
            // lbpayid
            // 
            this.lbpayid.AutoSize = true;
            this.lbpayid.Location = new System.Drawing.Point(90, 74);
            this.lbpayid.Name = "lbpayid";
            this.lbpayid.Size = new System.Drawing.Size(35, 13);
            this.lbpayid.TabIndex = 22;
            this.lbpayid.Text = "label5";
            // 
            // lbsubid
            // 
            this.lbsubid.AutoSize = true;
            this.lbsubid.Location = new System.Drawing.Point(90, 98);
            this.lbsubid.Name = "lbsubid";
            this.lbsubid.Size = new System.Drawing.Size(35, 13);
            this.lbsubid.TabIndex = 23;
            this.lbsubid.Text = "label6";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtpaidnote2);
            this.panel1.Controls.Add(this.pickdatedoneon);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbpaymentamt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbcontractno);
            this.panel1.Controls.Add(this.lb_programe);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPaydoc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbsubid);
            this.panel1.Controls.Add(this.lbuntextamount);
            this.panel1.Controls.Add(this.txtpaidnote);
            this.panel1.Controls.Add(this.lbpayid);
            this.panel1.Controls.Add(this.lb_doc);
            this.panel1.Controls.Add(this.lbBactchdoc);
            this.panel1.Controls.Add(this.lbtextamount);
            this.panel1.Location = new System.Drawing.Point(7, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 288);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Paid Note";
            // 
            // txtpaidnote2
            // 
            this.txtpaidnote2.Location = new System.Drawing.Point(86, 243);
            this.txtpaidnote2.Name = "txtpaidnote2";
            this.txtpaidnote2.Size = new System.Drawing.Size(241, 20);
            this.txtpaidnote2.TabIndex = 37;
            this.txtpaidnote2.Tag = "2";
            this.txtpaidnote2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpaidnote2_KeyPress);
            // 
            // pickdatedoneon
            // 
            this.pickdatedoneon.CustomFormat = "dd.MM.yyyy";
            this.pickdatedoneon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickdatedoneon.Location = new System.Drawing.Point(88, 146);
            this.pickdatedoneon.Name = "pickdatedoneon";
            this.pickdatedoneon.Size = new System.Drawing.Size(108, 20);
            this.pickdatedoneon.TabIndex = 1;
            this.pickdatedoneon.Tag = "1";
            this.pickdatedoneon.Value = new System.DateTime(2016, 3, 12, 0, 0, 0, 0);
            this.pickdatedoneon.ValueChanged += new System.EventHandler(this.pickdatedoneon_ValueChanged);
            this.pickdatedoneon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Paid on";
            // 
            // lbpaymentamt
            // 
            this.lbpaymentamt.AutoSize = true;
            this.lbpaymentamt.ForeColor = System.Drawing.Color.Red;
            this.lbpaymentamt.Location = new System.Drawing.Point(90, 120);
            this.lbpaymentamt.Name = "lbpaymentamt";
            this.lbpaymentamt.Size = new System.Drawing.Size(35, 13);
            this.lbpaymentamt.TabIndex = 34;
            this.lbpaymentamt.Text = "label6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Payment amt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Contract No.";
            // 
            // lbcontractno
            // 
            this.lbcontractno.AutoSize = true;
            this.lbcontractno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcontractno.ForeColor = System.Drawing.Color.Red;
            this.lbcontractno.Location = new System.Drawing.Point(90, 12);
            this.lbcontractno.Name = "lbcontractno";
            this.lbcontractno.Size = new System.Drawing.Size(41, 13);
            this.lbcontractno.TabIndex = 32;
            this.lbcontractno.Text = "label1";
            // 
            // lb_programe
            // 
            this.lb_programe.AutoSize = true;
            this.lb_programe.Location = new System.Drawing.Point(89, 54);
            this.lb_programe.Name = "lb_programe";
            this.lb_programe.Size = new System.Drawing.Size(35, 13);
            this.lb_programe.TabIndex = 27;
            this.lb_programe.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Program";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Payment Doc.";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtPaydoc
            // 
            this.txtPaydoc.Location = new System.Drawing.Point(87, 183);
            this.txtPaydoc.Name = "txtPaydoc";
            this.txtPaydoc.Size = new System.Drawing.Size(241, 20);
            this.txtPaydoc.TabIndex = 3;
            this.txtPaydoc.Tag = "3";
            this.txtPaydoc.TextChanged += new System.EventHandler(this.txtPaydoc_TextChanged);
            this.txtPaydoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(33, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 21);
            this.button1.TabIndex = 4;
            this.button1.Tag = "4";
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(150, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "PAYMENT CONTROL ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 443);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 22);
            this.button4.TabIndex = 6;
            this.button4.TabStop = false;
            this.button4.Text = "Release Print";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 22);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "Reject";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::KAmanagement.Properties.Resources.coca_cola;
            this.pictureBox1.Image = global::KAmanagement.Properties.Resources.coca_cola;
            this.pictureBox1.InitialImage = global::KAmanagement.Properties.Resources.coca_cola;
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // kaconfirmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 515);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kaconfirmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment control";
            this.Load += new System.EventHandler(this.kaconfirmPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_doc;
        private System.Windows.Forms.Label lbtextamount;
        private System.Windows.Forms.Label lbuntextamount;
        private System.Windows.Forms.TextBox txtpaidnote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBactchdoc;
        private System.Windows.Forms.Label lbpayid;
        private System.Windows.Forms.Label lbsubid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaydoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_programe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbcontractno;
        private System.Windows.Forms.Label lbpaymentamt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker pickdatedoneon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpaidnote2;
    }
}