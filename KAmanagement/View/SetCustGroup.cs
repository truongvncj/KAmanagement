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
    public partial class SetCustGroup : Form
    {
        public SetCustGroup()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
        }

        private void SetCustGroup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code","");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;
            if (valueinput == null)
            {
                valueinput = "";
            }
            if (chon)
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.FullNameN.Contains(valueinput) && (tbl_KaCustomer.SapCode == true)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,Choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                string region = viewtb.region;

                if (codetemp != "0" && chon == true && codetemp != null)
                {
                    custcode.Text = codetemp;
                    custcode.Enabled = false;

                    textregion.Text = region;
                    cbcust.Checked = true;
                    //  groupBox1.Enabled = true;
                    //     cbcust.Checked = true;
                }
             
            }
            else
            {
                custcode.Text = "";
                custcode.Enabled = true;
                textregion.Text = "";
                cbcust.Checked = true;
                //     groupBox1.Enabled = false;
                //   cbcust.Checked = false;

            }
        }

        private void txtcustgroup_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = txtcustgroup.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.Customer.ToString().Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.Grpcode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                if (codetemp != "0" && codetemp != null)
                {
                    txtcustgroup.Text = codetemp;
                    txtcustgroup.Enabled = false;

                    groupBox1.Enabled = true;
                }
                else
                {
                    txtcustgroup.Text = "";
                    txtcustgroup.Enabled = true;
                    groupBox1.Enabled = false;


                }



            }

        }

        private void btfingroup_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code","");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;
            if (valueinput == null)
            {
                valueinput = "";
            }
            if (chon)
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.FullNameN.Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.Grpcode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,Choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                string region = viewtb.region;


                if (codetemp != "0" && chon == true && codetemp != null)
                {
                    txtcustgroup.Text = codetemp;
                    txtcustgroup.Enabled = false;
                    groupBox1.Enabled = true;
                    textregion.Text = region;
                    //     cbcust.Checked = true;
                }
              
            }
            else
            {
                txtcustgroup.Text = "";

                txtcustgroup.Enabled = true;
                groupBox1.Enabled = false;
                textregion.Text = "";
                //   cbcust.Checked = false;

            }
        }

        private void txtcustgroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbcust.Checked = false;
            if (e.KeyChar == (char)Keys.Enter)
            {


                string valueinput = custcode.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.Customer.ToString().Contains(valueinput) && (tbl_KaCustomer.SapCode == true)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                string region = viewtb.region;
                //string region  = 

                if (codetemp != "0" && codetemp != null)
                {
                    custcode.Text = codetemp;
                    custcode.Enabled = false;
                    textregion.Text = region;
                    cbcust.Checked = true;
                    //  groupBox1.Enabled = true;
                }
                else
                {
                    custcode.Text = "";
                    custcode.Enabled = true;
                    textregion.Text = "";
                    cbcust.Checked = false;
                    //  groupBox1.Enabled = false;


                }



            }

        }

        private void txtcustgroup_TextChanged(object sender, EventArgs e)
        {

            string Codegroup = txtcustgroup.Text.Trim();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                         where tbl_KaCustomer.Customer.ToString().Contains(Codegroup) && (tbl_KaCustomer.SapCode == true)
                         select tbl_KaCustomer;

            dataGridView1.DataSource = rscode;




        }

        private void btadd_Click(object sender, EventArgs e)
        {
            //if (txtcustgroup.Text != null && txtcustgroup.Text !="")
            //{

                if (custcode.Text != null && custcode.Text != "" && cbcust.Checked == true)
                {


                    string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            double Codegroup = double.Parse(txtcustgroup.Text.Trim());
            double sapcode = double.Parse(custcode.Text.ToString());
            //-------update them code-------------

            tbl_kaCustomerGroup newitem = new tbl_kaCustomerGroup();
                    newitem.Customergropcode = Codegroup;
                    newitem.Customercode = sapcode;
                    newitem.Region = textregion.Text;

            dc.tbl_kaCustomerGroups.InsertOnSubmit(newitem);
            dc.SubmitChanges();
            //   newitem.Group_Name
            custcode.Enabled = true;
            custcode.Text = "";
                cbcust.Checked = false;
            //var insercode = from tbl_kaCustomerGroup in dc.tbl_kaCustomerGroups
            //                where tbl_kaCustomerGroup.Customergropcode.ToString().Contains(Codegroup) //&& (tbl_KaCustomer.SapCode == true)
            //                select tbl_kaCustomerGroup;



                ///-----

                //     Codegroup = txtcustgroup.Text.Trim();


                var rscode = from tbl_kaCustomerGroup in dc.tbl_kaCustomerGroups
                        where tbl_kaCustomerGroup.Customergropcode==Codegroup//&& (tbl_KaCustomer.SapCode == true)
                         select tbl_kaCustomerGroup;

            dataGridView1.DataSource = rscode;


            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void custcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   textregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["id"].Value;


             //   MessageBox.Show(id.ToString());

                double Codegroup = double.Parse(txtcustgroup.Text.ToString());

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




                var rscode = (from tbl_kaCustomerGroup in dc.tbl_kaCustomerGroups
                             where tbl_kaCustomerGroup.id == id
                             select tbl_kaCustomerGroup).FirstOrDefault();

                dc.tbl_kaCustomerGroups.DeleteOnSubmit(rscode);
                dc.SubmitChanges();

                var rscode2 = from tbl_kaCustomerGroup in dc.tbl_kaCustomerGroups
                             where tbl_kaCustomerGroup.Customergropcode == Codegroup//&& (tbl_KaCustomer.SapCode == true)
                             select tbl_kaCustomerGroup;

                dataGridView1.DataSource = rscode2;



            }
            catch (Exception)
            {

              //  throw;
            }

          

            
        }
    }
}
