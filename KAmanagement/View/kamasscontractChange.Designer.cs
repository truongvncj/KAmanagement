namespace KAmanagement.View
{
    partial class kamasscontractChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kamasscontractChange));
            this.btupdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_contractstatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(23, 25);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(173, 23);
            this.btupdate.TabIndex = 2;
            this.btupdate.Text = "UPLOAD  LIST CONTRACT TO CHANGE STATUS TO";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_contractstatus);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 73);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cb_contractstatus
            // 
            this.cb_contractstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_contractstatus.BackColor = System.Drawing.Color.White;
            this.cb_contractstatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cb_contractstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_contractstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_contractstatus.ForeColor = System.Drawing.Color.Black;
            this.cb_contractstatus.FormattingEnabled = true;
            this.cb_contractstatus.Items.AddRange(new object[] {
            "CRT",
            "ALV",
            "CLS",
            "CAN"});
            this.cb_contractstatus.Location = new System.Drawing.Point(412, 27);
            this.cb_contractstatus.Name = "cb_contractstatus";
            this.cb_contractstatus.Size = new System.Drawing.Size(65, 21);
            this.cb_contractstatus.TabIndex = 23;
            this.cb_contractstatus.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(309, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Con. Status";
            // 
            // kamasscontractChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(567, 81);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kamasscontractChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MASS CHANGE CONTRACT STATUS";
            this.Load += new System.EventHandler(this.Kasalesuploadandreports_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_contractstatus;
        private System.Windows.Forms.Label label11;
    }
}