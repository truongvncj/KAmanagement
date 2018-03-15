namespace KAmanagement.View
{
    partial class Passwordchange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Passwordchange));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtnewconfpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtoldpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbchangepass = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtnewconfpass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtoldpass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtnewpass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbchangepass);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 194);
            this.panel1.TabIndex = 0;
            // 
            // txtnewconfpass
            // 
            this.txtnewconfpass.Location = new System.Drawing.Point(107, 118);
            this.txtnewconfpass.Name = "txtnewconfpass";
            this.txtnewconfpass.PasswordChar = '*';
            this.txtnewconfpass.Size = new System.Drawing.Size(190, 20);
            this.txtnewconfpass.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Confim Password";
            // 
            // txtoldpass
            // 
            this.txtoldpass.Location = new System.Drawing.Point(107, 49);
            this.txtoldpass.Name = "txtoldpass";
            this.txtoldpass.PasswordChar = '*';
            this.txtoldpass.Size = new System.Drawing.Size(190, 20);
            this.txtoldpass.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Old Password";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(107, 23);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(190, 20);
            this.txtusername.TabIndex = 6;
            this.txtusername.Text = "SA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User ID";
            // 
            // txtnewpass
            // 
            this.txtnewpass.Location = new System.Drawing.Point(107, 94);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.PasswordChar = '*';
            this.txtnewpass.Size = new System.Drawing.Size(190, 20);
            this.txtnewpass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password";
            // 
            // tbchangepass
            // 
            this.tbchangepass.Location = new System.Drawing.Point(194, 157);
            this.tbchangepass.Name = "tbchangepass";
            this.tbchangepass.Size = new System.Drawing.Size(103, 25);
            this.tbchangepass.TabIndex = 1;
            this.tbchangepass.Text = "OK";
            this.tbchangepass.UseVisualStyleBackColor = true;
            this.tbchangepass.Click += new System.EventHandler(this.tbchangepass_Click);
            // 
            // Passwordchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 199);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Passwordchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Change";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tbchangepass;
        private System.Windows.Forms.TextBox txtnewconfpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtoldpass;
        private System.Windows.Forms.Label label1;
    }
}