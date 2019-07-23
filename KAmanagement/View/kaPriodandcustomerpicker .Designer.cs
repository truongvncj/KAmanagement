namespace KAmanagement.View
{
    partial class kaPriodandcustomerpicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kaPriodandcustomerpicker));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.bl_priod = new System.Windows.Forms.Label();
            this.cb_priod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtodates = new System.Windows.Forms.Label();
            this.lb_fromdates = new System.Windows.Forms.Label();
            this.lb_priods = new System.Windows.Forms.Label();
            this.cbcustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(113, 238);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(93, 29);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Thực hiện";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // bl_priod
            // 
            this.bl_priod.AutoSize = true;
            this.bl_priod.ForeColor = System.Drawing.Color.Teal;
            this.bl_priod.Location = new System.Drawing.Point(71, 132);
            this.bl_priod.Name = "bl_priod";
            this.bl_priod.Size = new System.Drawing.Size(36, 15);
            this.bl_priod.TabIndex = 4;
            this.bl_priod.Text = "Priod";
            this.bl_priod.Click += new System.EventHandler(this.bl_priod_Click);
            // 
            // cb_priod
            // 
            this.cb_priod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_priod.FormattingEnabled = true;
            this.cb_priod.Location = new System.Drawing.Point(113, 10);
            this.cb_priod.Name = "cb_priod";
            this.cb_priod.Size = new System.Drawing.Size(122, 23);
            this.cb_priod.TabIndex = 10;
            this.cb_priod.SelectionChangeCommitted += new System.EventHandler(this.cb_priod_SelectionChangeCommitted);
            this.cb_priod.SelectedValueChanged += new System.EventHandler(this.cb_priod_SelectedValueChanged);
            this.cb_priod.TextChanged += new System.EventHandler(this.cb_priod_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Priod Select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(70, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "From date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(70, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "To date";
            // 
            // lbtodates
            // 
            this.lbtodates.AutoSize = true;
            this.lbtodates.ForeColor = System.Drawing.Color.Red;
            this.lbtodates.Location = new System.Drawing.Point(164, 184);
            this.lbtodates.Name = "lbtodates";
            this.lbtodates.Size = new System.Drawing.Size(69, 15);
            this.lbtodates.TabIndex = 16;
            this.lbtodates.Text = "31/12/2015";
            // 
            // lb_fromdates
            // 
            this.lb_fromdates.AutoSize = true;
            this.lb_fromdates.ForeColor = System.Drawing.Color.Red;
            this.lb_fromdates.Location = new System.Drawing.Point(162, 159);
            this.lb_fromdates.Name = "lb_fromdates";
            this.lb_fromdates.Size = new System.Drawing.Size(69, 15);
            this.lb_fromdates.TabIndex = 15;
            this.lb_fromdates.Text = "28/11/2015";
            // 
            // lb_priods
            // 
            this.lb_priods.AutoSize = true;
            this.lb_priods.ForeColor = System.Drawing.Color.Red;
            this.lb_priods.Location = new System.Drawing.Point(180, 135);
            this.lb_priods.Name = "lb_priods";
            this.lb_priods.Size = new System.Drawing.Size(49, 15);
            this.lb_priods.TabIndex = 14;
            this.lb_priods.Text = "122015";
            // 
            // cbcustomer
            // 
            this.cbcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbcustomer.FormattingEnabled = true;
            this.cbcustomer.Location = new System.Drawing.Point(113, 56);
            this.cbcustomer.Name = "cbcustomer";
            this.cbcustomer.Size = new System.Drawing.Size(177, 23);
            this.cbcustomer.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Customer code";
            // 
            // kaPriodandcustomerpicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 279);
            this.Controls.Add(this.cbcustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbtodates);
            this.Controls.Add(this.lb_fromdates);
            this.Controls.Add(this.lb_priods);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_priod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bl_priod);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kaPriodandcustomerpicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "kaPriod and Customer code picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.Label bl_priod;
        private System.Windows.Forms.ComboBox cb_priod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtodates;
        private System.Windows.Forms.Label lb_fromdates;
        private System.Windows.Forms.Label lb_priods;
        private System.Windows.Forms.ComboBox cbcustomer;
        private System.Windows.Forms.Label label1;
    }
}