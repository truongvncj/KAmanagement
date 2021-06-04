using System;

namespace KAmanagement.View
{
    partial class VInputchange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VInputchange));
            this.lb_headersub = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btrigh = new System.Windows.Forms.Button();
            this.lbseachedit = new System.Windows.Forms.Label();
            this.export = new System.Windows.Forms.Button();
            this.Bt_uploadbegin = new System.Windows.Forms.Button();
            this.bnt_adddataselected = new System.Windows.Forms.Button();
            this.Bt_Deleteddata = new System.Windows.Forms.Button();
            this.bt_updatedata = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Bt_Adddata = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.bt_detletedsetlectmain = new System.Windows.Forms.Button();
            this.lb_headermain = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_headersub
            // 
            this.lb_headersub.AutoSize = true;
            this.lb_headersub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_headersub.Location = new System.Drawing.Point(16, 61);
            this.lb_headersub.Name = "lb_headersub";
            this.lb_headersub.Size = new System.Drawing.Size(188, 16);
            this.lb_headersub.TabIndex = 40;
            this.lb_headersub.Text = "DỮ LIỆU CHI TIẾT HIỆN THỜI";
            this.lb_headersub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(4, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btrigh);
            this.splitContainer1.Panel1.Controls.Add(this.lbseachedit);
            this.splitContainer1.Panel1.Controls.Add(this.export);
            this.splitContainer1.Panel1.Controls.Add(this.Bt_uploadbegin);
            this.splitContainer1.Panel1.Controls.Add(this.bnt_adddataselected);
            this.splitContainer1.Panel1.Controls.Add(this.lb_headersub);
            this.splitContainer1.Panel1.Controls.Add(this.Bt_Deleteddata);
            this.splitContainer1.Panel1.Controls.Add(this.bt_updatedata);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.Bt_Adddata);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainpanel);
            this.splitContainer1.Size = new System.Drawing.Size(1153, 485);
            this.splitContainer1.SplitterDistance = 629;
            this.splitContainer1.SplitterIncrement = 15;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 33;
            // 
            // btrigh
            // 
            this.btrigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btrigh.Location = new System.Drawing.Point(185, 452);
            this.btrigh.Name = "btrigh";
            this.btrigh.Size = new System.Drawing.Size(110, 24);
            this.btrigh.TabIndex = 52;
            this.btrigh.Text = "ContType && Region";
            this.btrigh.UseVisualStyleBackColor = true;
            this.btrigh.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbseachedit
            // 
            this.lbseachedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbseachedit.AutoSize = true;
            this.lbseachedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbseachedit.ForeColor = System.Drawing.Color.Red;
            this.lbseachedit.Location = new System.Drawing.Point(224, 457);
            this.lbseachedit.Name = "lbseachedit";
            this.lbseachedit.Size = new System.Drawing.Size(77, 16);
            this.lbseachedit.TabIndex = 51;
            this.lbseachedit.Text = "F3 :Seach";
            // 
            // export
            // 
            this.export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.export.Location = new System.Drawing.Point(399, 450);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(92, 27);
            this.export.TabIndex = 50;
            this.export.Text = "Export To Excel";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bt_uploadbegin
            // 
            this.Bt_uploadbegin.Location = new System.Drawing.Point(48, 450);
            this.Bt_uploadbegin.Name = "Bt_uploadbegin";
            this.Bt_uploadbegin.Size = new System.Drawing.Size(131, 26);
            this.Bt_uploadbegin.TabIndex = 49;
            this.Bt_uploadbegin.Text = "Upload Begin Balace";
            this.Bt_uploadbegin.UseVisualStyleBackColor = true;
            this.Bt_uploadbegin.Click += new System.EventHandler(this.Bt_uploadbegin_Click);
            // 
            // bnt_adddataselected
            // 
            this.bnt_adddataselected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnt_adddataselected.Location = new System.Drawing.Point(108, 451);
            this.bnt_adddataselected.Name = "bnt_adddataselected";
            this.bnt_adddataselected.Size = new System.Drawing.Size(110, 26);
            this.bnt_adddataselected.TabIndex = 41;
            this.bnt_adddataselected.Text = "Add Data Selected ";
            this.bnt_adddataselected.UseVisualStyleBackColor = true;
            // 
            // Bt_Deleteddata
            // 
            this.Bt_Deleteddata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Deleteddata.Location = new System.Drawing.Point(504, 450);
            this.Bt_Deleteddata.Name = "Bt_Deleteddata";
            this.Bt_Deleteddata.Size = new System.Drawing.Size(118, 27);
            this.Bt_Deleteddata.TabIndex = 37;
            this.Bt_Deleteddata.Text = "Delete Sellected Row";
            this.Bt_Deleteddata.UseVisualStyleBackColor = true;
            this.Bt_Deleteddata.Click += new System.EventHandler(this.Bt_Deleteddata_Click);
            // 
            // bt_updatedata
            // 
            this.bt_updatedata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_updatedata.Location = new System.Drawing.Point(301, 451);
            this.bt_updatedata.Name = "bt_updatedata";
            this.bt_updatedata.Size = new System.Drawing.Size(92, 27);
            this.bt_updatedata.TabIndex = 36;
            this.bt_updatedata.Text = "Update  Data";
            this.bt_updatedata.UseVisualStyleBackColor = true;
            this.bt_updatedata.Click += new System.EventHandler(this.bt_updatedata_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(318, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(304, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // Bt_Adddata
            // 
            this.Bt_Adddata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bt_Adddata.Location = new System.Drawing.Point(6, 451);
            this.Bt_Adddata.Name = "Bt_Adddata";
            this.Bt_Adddata.Size = new System.Drawing.Size(102, 27);
            this.Bt_Adddata.TabIndex = 35;
            this.Bt_Adddata.Text = "Add to Main Data";
            this.Bt_Adddata.UseVisualStyleBackColor = true;
            this.Bt_Adddata.Click += new System.EventHandler(this.Bt_Adddata_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(616, 362);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.Controls.Add(this.bt_detletedsetlectmain);
            this.mainpanel.Controls.Add(this.lb_headermain);
            this.mainpanel.Controls.Add(this.dataGridView2);
            this.mainpanel.Location = new System.Drawing.Point(3, 3);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(509, 478);
            this.mainpanel.TabIndex = 0;
            // 
            // bt_detletedsetlectmain
            // 
            this.bt_detletedsetlectmain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_detletedsetlectmain.Location = new System.Drawing.Point(368, 450);
            this.bt_detletedsetlectmain.Name = "bt_detletedsetlectmain";
            this.bt_detletedsetlectmain.Size = new System.Drawing.Size(118, 25);
            this.bt_detletedsetlectmain.TabIndex = 48;
            this.bt_detletedsetlectmain.Text = "Delete Sellected Row";
            this.bt_detletedsetlectmain.UseVisualStyleBackColor = true;
            this.bt_detletedsetlectmain.Click += new System.EventHandler(this.bt_detletedsetlectmain_Click_1);
            // 
            // lb_headermain
            // 
            this.lb_headermain.AutoEllipsis = true;
            this.lb_headermain.AutoSize = true;
            this.lb_headermain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_headermain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_headermain.Location = new System.Drawing.Point(7, 56);
            this.lb_headermain.Name = "lb_headermain";
            this.lb_headermain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_headermain.Size = new System.Drawing.Size(157, 18);
            this.lb_headermain.TabIndex = 46;
            this.lb_headermain.Text = "DANH SÁCH DỮ LIỆU";
            this.lb_headermain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(2, 80);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(500, 365);
            this.dataGridView2.TabIndex = 45;
            // 
            // VInputchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 503);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VInputchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inputchange";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

     

        #endregion
        private System.Windows.Forms.Label lb_headersub;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Bt_Deleteddata;
        private System.Windows.Forms.Button bt_updatedata;
        private System.Windows.Forms.Button Bt_Adddata;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Button bt_detletedsetlectmain;
        private System.Windows.Forms.Label lb_headermain;
        public System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bnt_adddataselected;
        private System.Windows.Forms.Button Bt_uploadbegin;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Label lbseachedit;
        private System.Windows.Forms.Button btrigh;
    }
}