using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class Kainputaddcode : Form
    {

        public string Contactno { get; set; }
        public bool kq { get; set; }
        public string addname { get; set; }
        public double addcode { get; set; }

        public Kainputaddcode(String Contactno, String addname, double addcode)
        {
            InitializeComponent();

            //   this.label1.Text = headcolumname;
            this.kq = false;
            this.Contactno = Contactno;

            this.addname = addname;
            this.addcode = addcode;
            lbcode.Text = addcode.ToString();
            lbname.Text = addname;

        }

        private void valueinput_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       //     nut ok


            tbl_kacontractCustcode cust = new tbl_kacontractCustcode();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            string username = Utils.getusername();
            double codetemp = this.addcode;// (double)this.dataGridView1.Rows[0].Cells["Code"].Value;
            string codename = this.addname;//  (string)this.dataGridView1.Rows[0].Cells["Name"].Value;

            //this.valuetext = textBox1.Text;
            //this.field = this.label1.Text;



            cust.ContractNo = this.Contactno;
            cust.CustomerCode = codetemp;
            cust.Name = codename;
            cust.Addedby = username;

            dc.tbl_kacontractCustcodes.InsertOnSubmit(cust);
            dc.SubmitChanges();
            MessageBox.Show("Code :" + codetemp + " add to Groupcode done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);






            this.kq = true;
            this.Close();




        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
