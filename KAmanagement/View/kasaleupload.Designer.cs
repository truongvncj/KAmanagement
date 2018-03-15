namespace KAmanagement.View
{
    partial class Kasalesuploadandreports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kasalesuploadandreports));
            this.label1 = new System.Windows.Forms.Label();
            this.btsalesview = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "KA SALES UPLOAD && REPORTS";
            // 
            // btsalesview
            // 
            this.btsalesview.Location = new System.Drawing.Point(9, 94);
            this.btsalesview.Name = "btsalesview";
            this.btsalesview.Size = new System.Drawing.Size(203, 23);
            this.btsalesview.TabIndex = 1;
            this.btsalesview.Text = "VIEW SALES REPORTS ";
            this.btsalesview.UseVisualStyleBackColor = true;
            this.btsalesview.Click += new System.EventHandler(this.button1_Click);
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(9, 56);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(203, 23);
            this.btupdate.TabIndex = 2;
            this.btupdate.Text = "UPLOAD  SALES ";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(8, 135);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(203, 23);
            this.btdelete.TabIndex = 3;
            this.btdelete.Text = "DELETE SALES  DATA";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btdelete);
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Controls.Add(this.btsalesview);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 181);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Kasalesuploadandreports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(228, 190);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Kasalesuploadandreports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KaSalesupLoad";
            this.Load += new System.EventHandler(this.Kasalesuploadandreports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btsalesview;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Panel panel1;
    }
}