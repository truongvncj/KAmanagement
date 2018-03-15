namespace KAmanagement.View
{
    partial class SetCustGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetCustGroup));
            this.btfingroup = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.txtcustgroup = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.custcode = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btadd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textregion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbcust = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btfingroup
            // 
            this.btfingroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btfingroup.ForeColor = System.Drawing.Color.Red;
            this.btfingroup.Location = new System.Drawing.Point(249, 7);
            this.btfingroup.Name = "btfingroup";
            this.btfingroup.Size = new System.Drawing.Size(24, 22);
            this.btfingroup.TabIndex = 43;
            this.btfingroup.Text = ">>";
            this.btfingroup.UseVisualStyleBackColor = true;
            this.btfingroup.Click += new System.EventHandler(this.btfingroup_Click);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(24, 9);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(92, 16);
            this.label38.TabIndex = 41;
            this.label38.Text = "Group Code";
            // 
            // txtcustgroup
            // 
            this.txtcustgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtcustgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustgroup.FormattingEnabled = true;
            this.txtcustgroup.Location = new System.Drawing.Point(123, 7);
            this.txtcustgroup.Name = "txtcustgroup";
            this.txtcustgroup.Size = new System.Drawing.Size(120, 21);
            this.txtcustgroup.TabIndex = 42;
            this.txtcustgroup.SelectedIndexChanged += new System.EventHandler(this.txtcustgroup_SelectedIndexChanged);
            this.txtcustgroup.TextChanged += new System.EventHandler(this.txtcustgroup_TextChanged);
            this.txtcustgroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcustgroup_KeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(243, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 22);
            this.button1.TabIndex = 46;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Customer Code";
            // 
            // custcode
            // 
            this.custcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.custcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custcode.FormattingEnabled = true;
            this.custcode.Location = new System.Drawing.Point(117, 41);
            this.custcode.Name = "custcode";
            this.custcode.Size = new System.Drawing.Size(120, 21);
            this.custcode.TabIndex = 45;
            this.custcode.SelectedIndexChanged += new System.EventHandler(this.custcode_SelectedIndexChanged);
            this.custcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(458, 274);
            this.dataGridView1.TabIndex = 47;
            // 
            // btadd
            // 
            this.btadd.ForeColor = System.Drawing.Color.Red;
            this.btadd.Location = new System.Drawing.Point(293, 69);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(88, 19);
            this.btadd.TabIndex = 48;
            this.btadd.Text = "Add to GRoup";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(387, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 19);
            this.button2.TabIndex = 49;
            this.button2.Text = "Remove ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbcust);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textregion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btadd);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.custcode);
            this.groupBox1.Location = new System.Drawing.Point(7, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 385);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // textregion
            // 
            this.textregion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.textregion.Enabled = false;
            this.textregion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textregion.FormattingEnabled = true;
            this.textregion.Location = new System.Drawing.Point(117, 65);
            this.textregion.Name = "textregion";
            this.textregion.Size = new System.Drawing.Size(70, 23);
            this.textregion.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Add Member Of Group";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Region";
            // 
            // cbcust
            // 
            this.cbcust.AutoSize = true;
            this.cbcust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcust.ForeColor = System.Drawing.Color.Red;
            this.cbcust.Location = new System.Drawing.Point(293, 49);
            this.cbcust.Name = "cbcust";
            this.cbcust.Size = new System.Drawing.Size(15, 14);
            this.cbcust.TabIndex = 55;
            this.cbcust.UseVisualStyleBackColor = true;
            // 
            // SetCustGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btfingroup);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.txtcustgroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetCustGroup";
            this.Text = "SetCustGroup";
            this.Load += new System.EventHandler(this.SetCustGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btfingroup;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox txtcustgroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox custcode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox textregion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbcust;
    }
}