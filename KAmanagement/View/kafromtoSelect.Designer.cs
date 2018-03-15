namespace KAmanagement.View
{
    partial class KafromtoSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KafromtoSelect));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pkfromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pk_todate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(111, 102);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(93, 29);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Select";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "From date";
            // 
            // pkfromdate
            // 
            this.pkfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pkfromdate.Location = new System.Drawing.Point(140, 25);
            this.pkfromdate.Name = "pkfromdate";
            this.pkfromdate.Size = new System.Drawing.Size(122, 21);
            this.pkfromdate.TabIndex = 14;
            this.pkfromdate.ValueChanged += new System.EventHandler(this.pkfromdate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "To date";
            // 
            // pk_todate
            // 
            this.pk_todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pk_todate.Location = new System.Drawing.Point(140, 56);
            this.pk_todate.Name = "pk_todate";
            this.pk_todate.Size = new System.Drawing.Size(122, 21);
            this.pk_todate.TabIndex = 16;
            // 
            // KafromtoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 151);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pk_todate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pkfromdate);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KafromtoSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fromdate to Date Select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pkfromdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker pk_todate;
    }
}