namespace KAmanagement.View
{
    partial class CreatnewCust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatnewCust));
            this.panel1 = new System.Windows.Forms.Panel();
            this.vatno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbsapcode = new System.Windows.Forms.CheckBox();
            this.cbsfa = new System.Windows.Forms.CheckBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txt_provicen = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_district = new System.Windows.Forms.TextBox();
            this.txt_represennt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_houseno = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_chananame = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbregion = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbregion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.vatno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txt_description);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.txt_provicen);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txt_district);
            this.panel1.Controls.Add(this.txt_represennt);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txt_houseno);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_chananame);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 384);
            this.panel1.TabIndex = 0;
            // 
            // vatno
            // 
            this.vatno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatno.Location = new System.Drawing.Point(116, 312);
            this.vatno.Name = "vatno";
            this.vatno.Size = new System.Drawing.Size(352, 20);
            this.vatno.TabIndex = 71;
            this.vatno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vatno_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "VAT No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbsapcode);
            this.groupBox1.Controls.Add(this.cbsfa);
            this.groupBox1.Location = new System.Drawing.Point(346, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 77);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // cbsapcode
            // 
            this.cbsapcode.AutoSize = true;
            this.cbsapcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsapcode.ForeColor = System.Drawing.Color.Red;
            this.cbsapcode.Location = new System.Drawing.Point(17, 19);
            this.cbsapcode.Name = "cbsapcode";
            this.cbsapcode.Size = new System.Drawing.Size(75, 17);
            this.cbsapcode.TabIndex = 70;
            this.cbsapcode.Text = "SAP Code";
            this.cbsapcode.UseVisualStyleBackColor = true;
            this.cbsapcode.CheckedChanged += new System.EventHandler(this.cbsapcode_CheckedChanged);
            this.cbsapcode.CheckStateChanged += new System.EventHandler(this.checkBox3_CheckStateChanged);
            // 
            // cbsfa
            // 
            this.cbsfa.AutoSize = true;
            this.cbsfa.Checked = true;
            this.cbsfa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbsfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsfa.ForeColor = System.Drawing.Color.Red;
            this.cbsfa.Location = new System.Drawing.Point(17, 45);
            this.cbsfa.Name = "cbsfa";
            this.cbsfa.Size = new System.Drawing.Size(74, 17);
            this.cbsfa.TabIndex = 68;
            this.cbsfa.Text = "SFA Code";
            this.cbsfa.UseVisualStyleBackColor = true;
            this.cbsfa.CheckedChanged += new System.EventHandler(this.cbsfa_CheckedChanged);
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Location = new System.Drawing.Point(117, 283);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(352, 20);
            this.txt_description.TabIndex = 7;
            this.txt_description.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_description_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Description";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(171, 354);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 21);
            this.button5.TabIndex = 8;
            this.button5.Text = "Create New";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 21);
            this.label1.TabIndex = 63;
            this.label1.Text = "CREATE NEW CUSTOMER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcode
            // 
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(118, 80);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(131, 20);
            this.txtcode.TabIndex = 0;
            this.txtcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustcode_KeyPress);
            // 
            // txt_provicen
            // 
            this.txt_provicen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_provicen.Location = new System.Drawing.Point(117, 254);
            this.txt_provicen.Name = "txt_provicen";
            this.txt_provicen.Size = new System.Drawing.Size(190, 20);
            this.txt_provicen.TabIndex = 6;
            this.txt_provicen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_provicen_KeyPress);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 224);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 17);
            this.label17.TabIndex = 61;
            this.label17.Text = "District";
            // 
            // txt_district
            // 
            this.txt_district.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_district.Location = new System.Drawing.Point(117, 222);
            this.txt_district.Name = "txt_district";
            this.txt_district.Size = new System.Drawing.Size(352, 20);
            this.txt_district.TabIndex = 5;
            this.txt_district.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_district_KeyPress);
            // 
            // txt_represennt
            // 
            this.txt_represennt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_represennt.Location = new System.Drawing.Point(117, 136);
            this.txt_represennt.Name = "txt_represennt";
            this.txt_represennt.Size = new System.Drawing.Size(242, 20);
            this.txt_represennt.TabIndex = 1;
            this.txt_represennt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_represennt_KeyPress);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 17);
            this.label13.TabIndex = 59;
            this.label13.Text = "City/ Province";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 17);
            this.label14.TabIndex = 58;
            this.label14.Text = "House No";
            // 
            // txt_houseno
            // 
            this.txt_houseno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_houseno.Location = new System.Drawing.Point(117, 192);
            this.txt_houseno.Name = "txt_houseno";
            this.txt_houseno.Size = new System.Drawing.Size(352, 20);
            this.txt_houseno.TabIndex = 4;
            this.txt_houseno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_houseno_KeyPress);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 18);
            this.label15.TabIndex = 57;
            this.label15.Text = "Trade Name";
            // 
            // txt_chananame
            // 
            this.txt_chananame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_chananame.Location = new System.Drawing.Point(117, 164);
            this.txt_chananame.Name = "txt_chananame";
            this.txt_chananame.Size = new System.Drawing.Size(352, 20);
            this.txt_chananame.TabIndex = 2;
            this.txt_chananame.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_chananame_KeyPress);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 16);
            this.label20.TabIndex = 50;
            this.label20.Text = "Code";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(14, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 20);
            this.label21.TabIndex = 49;
            this.label21.Text = "Representative";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Region";
            // 
            // cbregion
            // 
            this.cbregion.FormattingEnabled = true;
            this.cbregion.Items.AddRange(new object[] {
            "VN11",
            "VN12",
            "VN13",
            "VN15",
            "VN16",
            "VN17",
            "VN19"});
            this.cbregion.Location = new System.Drawing.Point(118, 109);
            this.cbregion.Name = "cbregion";
            this.cbregion.Size = new System.Drawing.Size(131, 21);
            this.cbregion.TabIndex = 75;
            // 
            // CreatnewCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 391);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatnewCust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creat New Customer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.TextBox txt_provicen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_district;
        private System.Windows.Forms.TextBox txt_represennt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_houseno;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_chananame;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbsfa;
        private System.Windows.Forms.CheckBox cbsapcode;
        private System.Windows.Forms.TextBox vatno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbregion;
        private System.Windows.Forms.Label label4;
    }
}