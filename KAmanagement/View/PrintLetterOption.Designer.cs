namespace KAmanagement.View
{
    partial class PrintLetterOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintLetterOption));
            this.cb_groupprit = new System.Windows.Forms.CheckBox();
            this.cb_onlycode = new System.Windows.Forms.CheckBox();
            this.cb_fromcodetocode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.input_groupcode = new System.Windows.Forms.ComboBox();
            this.input_onlycode = new System.Windows.Forms.ComboBox();
            this.input_fromcode = new System.Windows.Forms.ComboBox();
            this.input_tocode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_printall = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_groupprit
            // 
            this.cb_groupprit.AutoSize = true;
            this.cb_groupprit.Location = new System.Drawing.Point(2, 95);
            this.cb_groupprit.Name = "cb_groupprit";
            this.cb_groupprit.Size = new System.Drawing.Size(166, 17);
            this.cb_groupprit.TabIndex = 0;
            this.cb_groupprit.Text = "Print letter by Group Customer";
            this.cb_groupprit.UseVisualStyleBackColor = true;
         //   this.cb_groupprit.CheckedChanged += new System.EventHandler(this.cb_groupprit_CheckedChanged);
            // 
            // cb_onlycode
            // 
            this.cb_onlycode.AutoSize = true;
            this.cb_onlycode.Location = new System.Drawing.Point(2, 21);
            this.cb_onlycode.Name = "cb_onlycode";
            this.cb_onlycode.Size = new System.Drawing.Size(104, 17);
            this.cb_onlycode.TabIndex = 1;
            this.cb_onlycode.Text = "Print Only Comer";
            this.cb_onlycode.UseVisualStyleBackColor = true;
        ///    this.cb_onlycode.CheckedChanged += new System.EventHandler(this.cb_onlycode_CheckedChanged);
            // 
            // cb_fromcodetocode
            // 
            this.cb_fromcodetocode.AutoSize = true;
            this.cb_fromcodetocode.Location = new System.Drawing.Point(2, 162);
            this.cb_fromcodetocode.Name = "cb_fromcodetocode";
            this.cb_fromcodetocode.Size = new System.Drawing.Size(166, 17);
            this.cb_fromcodetocode.TabIndex = 2;
            this.cb_fromcodetocode.Text = "Print letter from code  to Code";
            this.cb_fromcodetocode.UseVisualStyleBackColor = true;
         //   this.cb_fromcodetocode.CheckedChanged += new System.EventHandler(this.cb_fromcodetocode_CheckedChanged);
         //   this.cb_fromcodetocode.CheckStateChanged += new System.EventHandler(this.cb_fromcodetocode_CheckStateChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thực hiện";
            this.button1.UseVisualStyleBackColor = true;
         //   this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // input_groupcode
            // 
            this.input_groupcode.FormattingEnabled = true;
            this.input_groupcode.Location = new System.Drawing.Point(19, 118);
            this.input_groupcode.Name = "input_groupcode";
            this.input_groupcode.Size = new System.Drawing.Size(289, 21);
            this.input_groupcode.TabIndex = 5;
         //   this.input_groupcode.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
        //    this.input_groupcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // input_onlycode
            // 
            this.input_onlycode.FormattingEnabled = true;
            this.input_onlycode.Location = new System.Drawing.Point(19, 44);
            this.input_onlycode.Name = "input_onlycode";
            this.input_onlycode.Size = new System.Drawing.Size(289, 21);
            this.input_onlycode.TabIndex = 6;
          //  this.input_onlycode.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
         //   this.input_onlycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
            // 
            // input_fromcode
            // 
            this.input_fromcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.input_fromcode.FormattingEnabled = true;
            this.input_fromcode.Location = new System.Drawing.Point(87, 194);
            this.input_fromcode.Name = "input_fromcode";
            this.input_fromcode.Size = new System.Drawing.Size(147, 21);
            this.input_fromcode.TabIndex = 7;
          //  this.input_fromcode.SelectedValueChanged += new System.EventHandler(this.comboBox3_SelectedValueChanged);
         //   this.input_fromcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox3_KeyPress);
            // 
            // input_tocode
            // 
            this.input_tocode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.input_tocode.FormattingEnabled = true;
            this.input_tocode.Location = new System.Drawing.Point(87, 220);
            this.input_tocode.Name = "input_tocode";
            this.input_tocode.Size = new System.Drawing.Size(147, 21);
            this.input_tocode.TabIndex = 8;
      //      this.input_tocode.SelectedValueChanged += new System.EventHandler(this.comboBox4_SelectedValueChanged);
      //      this.input_tocode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox4_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "From Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "To Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_printall);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.input_tocode);
            this.groupBox1.Controls.Add(this.input_fromcode);
            this.groupBox1.Controls.Add(this.input_onlycode);
            this.groupBox1.Controls.Add(this.input_groupcode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_fromcodetocode);
            this.groupBox1.Controls.Add(this.cb_onlycode);
            this.groupBox1.Controls.Add(this.cb_groupprit);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 331);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // cb_printall
            // 
            this.cb_printall.AutoSize = true;
            this.cb_printall.Location = new System.Drawing.Point(2, 259);
            this.cb_printall.Name = "cb_printall";
            this.cb_printall.Size = new System.Drawing.Size(60, 17);
            this.cb_printall.TabIndex = 13;
            this.cb_printall.Text = "Print all";
            this.cb_printall.UseVisualStyleBackColor = true;
        //    this.cb_printall.CheckStateChanged += new System.EventHandler(this.cb_printall_CheckStateChanged);
            // 
            // PrintLetterOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 329);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintLetterOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintLetterOption";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_groupprit;
        private System.Windows.Forms.CheckBox cb_onlycode;
        private System.Windows.Forms.CheckBox cb_fromcodetocode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox input_groupcode;
        private System.Windows.Forms.ComboBox input_onlycode;
        private System.Windows.Forms.ComboBox input_fromcode;
        private System.Windows.Forms.ComboBox input_tocode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_printall;
    }
}