namespace KAmanagement.View
{
    partial class KASeachpaymentRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KASeachpaymentRequest));
            this.label1 = new System.Windows.Forms.Label();
            this.sendingBatchno = new System.Windows.Forms.TextBox();
            this.sendingcontract = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendingname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch No.";
            // 
            // sendingBatchno
            // 
            this.sendingBatchno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingBatchno.Location = new System.Drawing.Point(16, 31);
            this.sendingBatchno.Name = "sendingBatchno";
            this.sendingBatchno.Size = new System.Drawing.Size(215, 32);
            this.sendingBatchno.TabIndex = 1;
            this.sendingBatchno.TextChanged += new System.EventHandler(this.sendingcode_TextChanged);
            this.sendingBatchno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // sendingcontract
            // 
            this.sendingcontract.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingcontract.Location = new System.Drawing.Point(16, 82);
            this.sendingcontract.Name = "sendingcontract";
            this.sendingcontract.Size = new System.Drawing.Size(215, 32);
            this.sendingcontract.TabIndex = 2;
            this.sendingcontract.TextChanged += new System.EventHandler(this.sendingcontract_TextChanged);
            this.sendingcontract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingcontract_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact ";
            // 
            // sendingname
            // 
            this.sendingname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingname.Location = new System.Drawing.Point(15, 133);
            this.sendingname.Name = "sendingname";
            this.sendingname.Size = new System.Drawing.Size(215, 32);
            this.sendingname.TabIndex = 3;
            this.sendingname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingname_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KAmanagement.Properties.Resources.file_dam_management;
            this.pictureBox1.Location = new System.Drawing.Point(108, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // KASeachpaymentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 227);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendingname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendingcontract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendingBatchno);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KASeachpaymentRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KA Seach Payment Request";
            this.Deactivate += new System.EventHandler(this.Seachcode_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendingBatchno;
        private System.Windows.Forms.TextBox sendingcontract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sendingname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}