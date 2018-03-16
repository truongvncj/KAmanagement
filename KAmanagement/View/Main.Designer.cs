namespace KAmanagement.View
{
    using KAmanagement;
    using System.Windows.Forms;

    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
       
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.inputusser = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.inputcontract = new System.Windows.Forms.PictureBox();
            this.reports = new System.Windows.Forms.PictureBox();
            this.inputpayment = new System.Windows.Forms.PictureBox();
            this.inpucvolume = new System.Windows.Forms.PictureBox();
            this.inputmarterdata = new System.Windows.Forms.PictureBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.lb_user = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputusser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputcontract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputpayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpucvolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputmarterdata)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.webBrowser2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 1163);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.inputusser);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.inputcontract);
            this.groupBox1.Controls.Add(this.reports);
            this.groupBox1.Controls.Add(this.inputpayment);
            this.groupBox1.Controls.Add(this.inpucvolume);
            this.groupBox1.Controls.Add(this.inputmarterdata);
            this.groupBox1.Location = new System.Drawing.Point(3, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 637);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(295, 261);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(187, 138);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // inputusser
            // 
            this.inputusser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputusser.Image = ((System.Drawing.Image)(resources.GetObject("inputusser.Image")));
            this.inputusser.Location = new System.Drawing.Point(587, 97);
            this.inputusser.Name = "inputusser";
            this.inputusser.Size = new System.Drawing.Size(120, 149);
            this.inputusser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputusser.TabIndex = 2;
            this.inputusser.TabStop = false;
            this.inputusser.Click += new System.EventHandler(this.pictureBox3_Click);
            this.inputusser.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.inputusser.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(6, 19);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(165, 55);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // inputcontract
            // 
            this.inputcontract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputcontract.Image = global::KAmanagement.Properties.Resources.input1;
            this.inputcontract.Location = new System.Drawing.Point(70, 97);
            this.inputcontract.Name = "inputcontract";
            this.inputcontract.Size = new System.Drawing.Size(140, 149);
            this.inputcontract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputcontract.TabIndex = 0;
            this.inputcontract.TabStop = false;
            this.inputcontract.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.inputcontract.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.inputcontract.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // reports
            // 
            this.reports.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reports.Image = global::KAmanagement.Properties.Resources.Reports1;
            this.reports.Location = new System.Drawing.Point(324, 510);
            this.reports.Name = "reports";
            this.reports.Size = new System.Drawing.Size(144, 106);
            this.reports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reports.TabIndex = 4;
            this.reports.TabStop = false;
            this.reports.Click += new System.EventHandler(this.pictureBox5_Click);
            this.reports.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            this.reports.MouseHover += new System.EventHandler(this.pictureBox5_MouseHover);
            // 
            // inputpayment
            // 
            this.inputpayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputpayment.Image = ((System.Drawing.Image)(resources.GetObject("inputpayment.Image")));
            this.inputpayment.Location = new System.Drawing.Point(72, 398);
            this.inputpayment.Name = "inputpayment";
            this.inputpayment.Size = new System.Drawing.Size(138, 137);
            this.inputpayment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputpayment.TabIndex = 3;
            this.inputpayment.TabStop = false;
            this.inputpayment.Click += new System.EventHandler(this.pictureBox4_Click);
            this.inputpayment.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.inputpayment.MouseHover += new System.EventHandler(this.pictureBox4_MouseHover);
            // 
            // inpucvolume
            // 
            this.inpucvolume.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inpucvolume.Image = global::KAmanagement.Properties.Resources.saleupdate1;
            this.inpucvolume.Location = new System.Drawing.Point(280, 10);
            this.inpucvolume.Name = "inpucvolume";
            this.inpucvolume.Size = new System.Drawing.Size(223, 179);
            this.inpucvolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inpucvolume.TabIndex = 1;
            this.inpucvolume.TabStop = false;
            this.inpucvolume.Click += new System.EventHandler(this.pictureBox2_Click);
            this.inpucvolume.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.inpucvolume.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // inputmarterdata
            // 
            this.inputmarterdata.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputmarterdata.Image = global::KAmanagement.Properties.Resources.master1;
            this.inputmarterdata.Location = new System.Drawing.Point(568, 415);
            this.inputmarterdata.Name = "inputmarterdata";
            this.inputmarterdata.Size = new System.Drawing.Size(177, 117);
            this.inputmarterdata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputmarterdata.TabIndex = 5;
            this.inputmarterdata.TabStop = false;
            this.inputmarterdata.Click += new System.EventHandler(this.pictureBox6_Click);
            this.inputmarterdata.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            this.inputmarterdata.MouseHover += new System.EventHandler(this.pictureBox6_MouseHover);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(829, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(197, 628);
            this.webBrowser2.TabIndex = 10;
            this.webBrowser2.Tag = "";
            this.webBrowser2.Url = new System.Uri("https://sites.google.com/site/advcocacolagogle", System.UriKind.Absolute);
            // 
            // lb_user
            // 
            this.lb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(14, 648);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(58, 13);
            this.lb_user.TabIndex = 23;
            this.lb_user.Text = "User name";
            // 
            // lbusername
            // 
            this.lbusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusername.AutoSize = true;
            this.lbusername.ForeColor = System.Drawing.Color.Red;
            this.lbusername.Location = new System.Drawing.Point(78, 648);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(35, 13);
            this.lbusername.TabIndex = 24;
            this.lbusername.Text = "label1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 669);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lb_user);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KA PAYMENT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputusser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputcontract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputpayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpucvolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputmarterdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_user;
        private Label lbusername;
        private PictureBox pictureBox7;
        private PictureBox inputmarterdata;
        private PictureBox reports;
        private PictureBox inputpayment;
        private PictureBox inputusser;
        private PictureBox inpucvolume;
        private PictureBox inputcontract;
        private PictureBox pictureBox8;
        private GroupBox groupBox1;
        private WebBrowser webBrowser2;
    }
}

