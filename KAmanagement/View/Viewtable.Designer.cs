using System;

namespace KAmanagement.View
{
    partial class Viewtable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewtable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btmasschangecontract = new System.Windows.Forms.Button();
            this.btmassconfirm = new System.Windows.Forms.Button();
            this.gboxUnpaid = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboucontractstst = new System.Windows.Forms.ComboBox();
            this.cbocntracttype = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.formlabel = new System.Windows.Forms.Label();
            this.lb_seach = new System.Windows.Forms.Label();
            this.bt_addtomaster = new System.Windows.Forms.Button();
            this.statussum = new System.Windows.Forms.Label();
            this.lb_totalrecord = new System.Windows.Forms.Label();
            this.bt_exporttoex = new System.Windows.Forms.Button();
            this.Pl_endview = new System.Windows.Forms.Panel();
            this.lb_uc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_countvalue = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_pc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_netvalue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_bilingqtt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gboxUnpaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Pl_endview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btmasschangecontract);
            this.panel1.Controls.Add(this.btmassconfirm);
            this.panel1.Controls.Add(this.gboxUnpaid);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.formlabel);
            this.panel1.Controls.Add(this.lb_seach);
            this.panel1.Controls.Add(this.bt_addtomaster);
            this.panel1.Controls.Add(this.statussum);
            this.panel1.Controls.Add(this.lb_totalrecord);
            this.panel1.Controls.Add(this.bt_exporttoex);
            this.panel1.Controls.Add(this.Pl_endview);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(4, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 471);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btmasschangecontract
            // 
            this.btmasschangecontract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btmasschangecontract.Location = new System.Drawing.Point(1108, 451);
            this.btmasschangecontract.Name = "btmasschangecontract";
            this.btmasschangecontract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btmasschangecontract.Size = new System.Drawing.Size(127, 19);
            this.btmasschangecontract.TabIndex = 46;
            this.btmasschangecontract.Text = "Mass change Contract";
            this.btmasschangecontract.UseVisualStyleBackColor = true;
            this.btmasschangecontract.Click += new System.EventHandler(this.btmasschangecontract_Click);
            // 
            // btmassconfirm
            // 
            this.btmassconfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btmassconfirm.Location = new System.Drawing.Point(1040, 450);
            this.btmassconfirm.Name = "btmassconfirm";
            this.btmassconfirm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btmassconfirm.Size = new System.Drawing.Size(80, 19);
            this.btmassconfirm.TabIndex = 45;
            this.btmassconfirm.Text = "Mass Confirm";
            this.btmassconfirm.UseVisualStyleBackColor = true;
            this.btmassconfirm.Click += new System.EventHandler(this.btmassconfirm_Click);
            // 
            // gboxUnpaid
            // 
            this.gboxUnpaid.Controls.Add(this.label6);
            this.gboxUnpaid.Controls.Add(this.label2);
            this.gboxUnpaid.Controls.Add(this.comboucontractstst);
            this.gboxUnpaid.Controls.Add(this.cbocntracttype);
            this.gboxUnpaid.ForeColor = System.Drawing.Color.Red;
            this.gboxUnpaid.Location = new System.Drawing.Point(835, 6);
            this.gboxUnpaid.Name = "gboxUnpaid";
            this.gboxUnpaid.Size = new System.Drawing.Size(448, 36);
            this.gboxUnpaid.TabIndex = 44;
            this.gboxUnpaid.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(228, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Contract Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Contract Status";
            // 
            // comboucontractstst
            // 
            this.comboucontractstst.FormattingEnabled = true;
            this.comboucontractstst.Items.AddRange(new object[] {
            "",
            "CLS",
            "ALV",
            "CAN",
            "CRT"});
            this.comboucontractstst.Location = new System.Drawing.Point(97, 11);
            this.comboucontractstst.Name = "comboucontractstst";
            this.comboucontractstst.Size = new System.Drawing.Size(119, 21);
            this.comboucontractstst.TabIndex = 41;
            this.comboucontractstst.SelectedValueChanged += new System.EventHandler(this.comboucontractstst_SelectedValueChanged);
            // 
            // cbocntracttype
            // 
            this.cbocntracttype.FormattingEnabled = true;
            this.cbocntracttype.Location = new System.Drawing.Point(314, 11);
            this.cbocntracttype.Name = "cbocntracttype";
            this.cbocntracttype.Size = new System.Drawing.Size(119, 21);
            this.cbocntracttype.TabIndex = 40;
            this.cbocntracttype.SelectedValueChanged += new System.EventHandler(this.cbocntracttype_SelectedValueChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(238, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // formlabel
            // 
            this.formlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.formlabel.AutoSize = true;
            this.formlabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formlabel.Font = new System.Drawing.Font("Microsoft MHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlabel.Location = new System.Drawing.Point(492, 14);
            this.formlabel.Name = "formlabel";
            this.formlabel.Size = new System.Drawing.Size(169, 21);
            this.formlabel.TabIndex = 8;
            this.formlabel.Text = "VIEW TABLE REPORTS";
            // 
            // lb_seach
            // 
            this.lb_seach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_seach.AutoSize = true;
            this.lb_seach.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.lb_seach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_seach.Location = new System.Drawing.Point(1012, 453);
            this.lb_seach.Name = "lb_seach";
            this.lb_seach.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_seach.Size = new System.Drawing.Size(90, 15);
            this.lb_seach.TabIndex = 6;
            this.lb_seach.Text = "F3: Seach Code";
            this.lb_seach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_addtomaster
            // 
            this.bt_addtomaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_addtomaster.Location = new System.Drawing.Point(1125, 450);
            this.bt_addtomaster.Name = "bt_addtomaster";
            this.bt_addtomaster.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bt_addtomaster.Size = new System.Drawing.Size(108, 19);
            this.bt_addtomaster.TabIndex = 4;
            this.bt_addtomaster.Text = "Upload Sales Data";
            this.bt_addtomaster.UseVisualStyleBackColor = true;
            this.bt_addtomaster.Click += new System.EventHandler(this.bt_addtomaster_Click);
            // 
            // statussum
            // 
            this.statussum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statussum.AutoSize = true;
            this.statussum.Location = new System.Drawing.Point(0, 452);
            this.statussum.Name = "statussum";
            this.statussum.Size = new System.Drawing.Size(70, 13);
            this.statussum.TabIndex = 1;
            this.statussum.Text = "Total record: ";
            // 
            // lb_totalrecord
            // 
            this.lb_totalrecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_totalrecord.AutoSize = true;
            this.lb_totalrecord.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalrecord.ForeColor = System.Drawing.Color.Red;
            this.lb_totalrecord.Location = new System.Drawing.Point(67, 453);
            this.lb_totalrecord.Name = "lb_totalrecord";
            this.lb_totalrecord.Size = new System.Drawing.Size(13, 14);
            this.lb_totalrecord.TabIndex = 2;
            this.lb_totalrecord.Text = "0";
            // 
            // bt_exporttoex
            // 
            this.bt_exporttoex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_exporttoex.Location = new System.Drawing.Point(1241, 449);
            this.bt_exporttoex.Name = "bt_exporttoex";
            this.bt_exporttoex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bt_exporttoex.Size = new System.Drawing.Size(87, 20);
            this.bt_exporttoex.TabIndex = 3;
            this.bt_exporttoex.Text = "Export to Excel";
            this.bt_exporttoex.UseVisualStyleBackColor = true;
            this.bt_exporttoex.Click += new System.EventHandler(this.bt_exporttoex_Click);
            // 
            // Pl_endview
            // 
            this.Pl_endview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pl_endview.BackColor = System.Drawing.Color.Transparent;
            this.Pl_endview.Controls.Add(this.lb_uc);
            this.Pl_endview.Controls.Add(this.label4);
            this.Pl_endview.Controls.Add(this.lb_countvalue);
            this.Pl_endview.Controls.Add(this.Status);
            this.Pl_endview.Controls.Add(this.label7);
            this.Pl_endview.Controls.Add(this.lb_pc);
            this.Pl_endview.Controls.Add(this.label5);
            this.Pl_endview.Controls.Add(this.lb_netvalue);
            this.Pl_endview.Controls.Add(this.label3);
            this.Pl_endview.Controls.Add(this.lb_bilingqtt);
            this.Pl_endview.Controls.Add(this.label1);
            this.Pl_endview.ForeColor = System.Drawing.Color.Black;
            this.Pl_endview.Location = new System.Drawing.Point(154, 450);
            this.Pl_endview.Name = "Pl_endview";
            this.Pl_endview.Size = new System.Drawing.Size(852, 19);
            this.Pl_endview.TabIndex = 1;
            // 
            // lb_uc
            // 
            this.lb_uc.AutoSize = true;
            this.lb_uc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_uc.Location = new System.Drawing.Point(682, 4);
            this.lb_uc.Name = "lb_uc";
            this.lb_uc.Size = new System.Drawing.Size(13, 13);
            this.lb_uc.TabIndex = 10;
            this.lb_uc.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(651, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "UC:";
            // 
            // lb_countvalue
            // 
            this.lb_countvalue.AutoSize = true;
            this.lb_countvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_countvalue.Location = new System.Drawing.Point(227, 4);
            this.lb_countvalue.Name = "lb_countvalue";
            this.lb_countvalue.Size = new System.Drawing.Size(13, 13);
            this.lb_countvalue.TabIndex = 7;
            this.lb_countvalue.Text = "0";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(772, 4);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(22, 13);
            this.Status.TabIndex = 8;
            this.Status.Text = "OK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(153, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "NSR:";
            // 
            // lb_pc
            // 
            this.lb_pc.AutoSize = true;
            this.lb_pc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pc.Location = new System.Drawing.Point(531, 4);
            this.lb_pc.Name = "lb_pc";
            this.lb_pc.Size = new System.Drawing.Size(13, 13);
            this.lb_pc.TabIndex = 5;
            this.lb_pc.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "EC:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lb_netvalue
            // 
            this.lb_netvalue.AutoSize = true;
            this.lb_netvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_netvalue.Location = new System.Drawing.Point(393, 4);
            this.lb_netvalue.Name = "lb_netvalue";
            this.lb_netvalue.Size = new System.Drawing.Size(13, 13);
            this.lb_netvalue.TabIndex = 3;
            this.lb_netvalue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "GSR:";
            // 
            // lb_bilingqtt
            // 
            this.lb_bilingqtt.AutoSize = true;
            this.lb_bilingqtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bilingqtt.Location = new System.Drawing.Point(70, 3);
            this.lb_bilingqtt.Name = "lb_bilingqtt";
            this.lb_bilingqtt.Size = new System.Drawing.Size(13, 13);
            this.lb_bilingqtt.TabIndex = 1;
            this.lb_bilingqtt.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PCs:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.Location = new System.Drawing.Point(3, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.Size = new System.Drawing.Size(1325, 394);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Viewtable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 481);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Viewtable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Viewtable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gboxUnpaid.ResumeLayout(false);
            this.gboxUnpaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Pl_endview.ResumeLayout(false);
            this.Pl_endview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

     



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label statussum;
        private System.Windows.Forms.Label lb_totalrecord;
        private System.Windows.Forms.Button bt_exporttoex;
        private System.Windows.Forms.Panel Pl_endview;
        private System.Windows.Forms.Label lb_countvalue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_pc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_netvalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_bilingqtt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_addtomaster;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label lb_uc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_seach;
        private System.Windows.Forms.Label formlabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox gboxUnpaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboucontractstst;
        private System.Windows.Forms.ComboBox cbocntracttype;
        private System.Windows.Forms.Button btmassconfirm;
        private System.Windows.Forms.Button btmasschangecontract;
    }
}