namespace KAmanagement.View
{
    partial class KaconvertProductdetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KaconvertProductdetail));
            this.bt_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbconvertproduct = new System.Windows.Forms.ComboBox();
            this.cbproduct = new System.Windows.Forms.ComboBox();
            this.textbrate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textremark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_add
            // 
            this.bt_add.ForeColor = System.Drawing.Color.Red;
            this.bt_add.Location = new System.Drawing.Point(12, 82);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(90, 28);
            this.bt_add.TabIndex = 3;
            this.bt_add.Text = "Add";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Convert to Product";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(891, 228);
            this.dataGridView1.TabIndex = 18;
            // 
            // cbconvertproduct
            // 
            this.cbconvertproduct.FormattingEnabled = true;
            this.cbconvertproduct.Location = new System.Drawing.Point(324, 12);
            this.cbconvertproduct.Name = "cbconvertproduct";
            this.cbconvertproduct.Size = new System.Drawing.Size(137, 23);
            this.cbconvertproduct.TabIndex = 19;
            // 
            // cbproduct
            // 
            this.cbproduct.FormattingEnabled = true;
            this.cbproduct.Location = new System.Drawing.Point(75, 12);
            this.cbproduct.Name = "cbproduct";
            this.cbproduct.Size = new System.Drawing.Size(117, 23);
            this.cbproduct.TabIndex = 20;
            // 
            // textbrate
            // 
            this.textbrate.Location = new System.Drawing.Point(565, 14);
            this.textbrate.Name = "textbrate";
            this.textbrate.Size = new System.Drawing.Size(108, 21);
            this.textbrate.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "With Rate";
            // 
            // textremark
            // 
            this.textremark.Location = new System.Drawing.Point(75, 41);
            this.textremark.Name = "textremark";
            this.textremark.Size = new System.Drawing.Size(828, 21);
            this.textremark.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Remarks";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(451, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "Delete all to make again";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KaconvertProductdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 378);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textremark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbrate);
            this.Controls.Add(this.cbproduct);
            this.Controls.Add(this.cbconvertproduct);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_add);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KaconvertProductdetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert Product Detail of Contract Item";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbconvertproduct;
        private System.Windows.Forms.ComboBox cbproduct;
        private System.Windows.Forms.TextBox textbrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textremark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}