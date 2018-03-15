namespace KAmanagement.View
{
    partial class kaPriodmake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kaPriodmake));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.bl_priod = new System.Windows.Forms.Label();
            this.cb_month = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pkfromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pk_todate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(121, 213);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(93, 29);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Make";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // bl_priod
            // 
            this.bl_priod.AutoSize = true;
            this.bl_priod.ForeColor = System.Drawing.Color.Red;
            this.bl_priod.Location = new System.Drawing.Point(236, 104);
            this.bl_priod.Name = "bl_priod";
            this.bl_priod.Size = new System.Drawing.Size(36, 15);
            this.bl_priod.TabIndex = 4;
            this.bl_priod.Text = "Priod";
            this.bl_priod.Click += new System.EventHandler(this.bl_priod_Click);
            // 
            // cb_month
            // 
            this.cb_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_month.FormattingEnabled = true;
            this.cb_month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cb_month.Location = new System.Drawing.Point(150, 68);
            this.cb_month.Name = "cb_month";
            this.cb_month.Size = new System.Drawing.Size(122, 23);
            this.cb_month.TabIndex = 8;
            this.cb_month.SelectedValueChanged += new System.EventHandler(this.cb_month_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Month";
            // 
            // cb_year
            // 
            this.cb_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Items.AddRange(new object[] {
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.cb_year.Location = new System.Drawing.Point(150, 29);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(122, 23);
            this.cb_year.TabIndex = 10;
            this.cb_year.SelectedValueChanged += new System.EventHandler(this.cb_year_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Priod:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "From date";
            // 
            // pkfromdate
            // 
            this.pkfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pkfromdate.Location = new System.Drawing.Point(150, 136);
            this.pkfromdate.Name = "pkfromdate";
            this.pkfromdate.Size = new System.Drawing.Size(122, 21);
            this.pkfromdate.TabIndex = 14;
            this.pkfromdate.ValueChanged += new System.EventHandler(this.pkfromdate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "To date";
            // 
            // pk_todate
            // 
            this.pk_todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pk_todate.Location = new System.Drawing.Point(150, 167);
            this.pk_todate.Name = "pk_todate";
            this.pk_todate.Size = new System.Drawing.Size(122, 21);
            this.pk_todate.TabIndex = 16;
            // 
            // kaPriodmake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 256);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pk_todate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pkfromdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_month);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bl_priod);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kaPriodmake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Priod Make";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.Label bl_priod;
        private System.Windows.Forms.ComboBox cb_month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pkfromdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker pk_todate;
    }
}