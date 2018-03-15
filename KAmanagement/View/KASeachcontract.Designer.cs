namespace KAmanagement.View
{
    partial class KASeachcontract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KASeachcontract));
            this.label1 = new System.Windows.Forms.Label();
            this.sendingcode = new System.Windows.Forms.TextBox();
            this.sendingcontract = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendingname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code ";
            // 
            // sendingcode
            // 
            this.sendingcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingcode.Location = new System.Drawing.Point(16, 24);
            this.sendingcode.Name = "sendingcode";
            this.sendingcode.Size = new System.Drawing.Size(215, 32);
            this.sendingcode.TabIndex = 1;
            this.sendingcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // sendingcontract
            // 
            this.sendingcontract.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingcontract.Location = new System.Drawing.Point(16, 75);
            this.sendingcontract.Name = "sendingcontract";
            this.sendingcontract.Size = new System.Drawing.Size(215, 32);
            this.sendingcontract.TabIndex = 2;
            this.sendingcontract.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingcontract_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact ";
            // 
            // sendingname
            // 
            this.sendingname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendingname.Location = new System.Drawing.Point(14, 126);
            this.sendingname.Name = "sendingname";
            this.sendingname.Size = new System.Drawing.Size(215, 32);
            this.sendingname.TabIndex = 3;
            this.sendingname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingname_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KAmanagement.Properties.Resources.file_dam_management;
            this.pictureBox1.Location = new System.Drawing.Point(108, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtvat
            // 
            this.txtvat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvat.Location = new System.Drawing.Point(14, 179);
            this.txtvat.Name = "txtvat";
            this.txtvat.Size = new System.Drawing.Size(215, 32);
            this.txtvat.TabIndex = 4;
            this.txtvat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvat_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "VAT Registation No";
            // 
            // KASeachcontract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 278);
            this.Controls.Add(this.txtvat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendingname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendingcontract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendingcode);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KASeachcontract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KASeachcontract";
            this.Deactivate += new System.EventHandler(this.Seachcode_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendingcode;
        private System.Windows.Forms.TextBox sendingcontract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sendingname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.Label label4;
    }
}