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
    public partial class KASeachaddcode : Form
    {
        //    public KAcontractlisting Fromviewable;
        ////    public DataGridView Dtgridview;

        //    public string tablename;

        public int icount { get; set; }

        public string ContractNo { get; set; }



        public KASeachaddcode(string ContractNo)
        {


            //   return false;





            InitializeComponent();
            //this.Fromviewable = Fromviewable;
            this.ContractNo = ContractNo;

            //this.tablename = tablename;

        }



        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            //    this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    sendingcontract.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}

        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    sendingname.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    this.sendingcode.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    this.sendingcode.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void sendingcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void KASeachaddcode_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtcode.Focus();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();

            var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                         where tbl_KaCustomer.FullNameN.Contains(txtname.Text.ToString().Trim())
                    && ((int)tbl_KaCustomer.Customer).ToString().Contains(txtcode.Text.ToString()) 

                         && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                              ).Contains(tbl_KaCustomer.SalesOrg)
                         select new
                         {
                             Region = tbl_KaCustomer.Region,
                             Code = tbl_KaCustomer.Customer,
                             Name = tbl_KaCustomer.FullNameN,
                             //   tbl_KaCustomer.SapCode,

                         };


            icount = rscode.Count();
            dataGridView1.DataSource = rscode;


        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtname.Focus();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();

            var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers

                         where tbl_KaCustomer.FullNameN.Contains(txtname.Text.ToString().Trim())
             && ((int)tbl_KaCustomer.Customer).ToString().Contains(txtcode.Text.ToString())

                         && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                                           ).Contains(tbl_KaCustomer.SalesOrg)

                         select new
                         {
                             Region = tbl_KaCustomer.Region,
                             Code = tbl_KaCustomer.Customer,
                             Name = tbl_KaCustomer.FullNameN,
                             //  tbl_KaCustomer.SapCode,

                         };

            icount = rscode.Count();

            dataGridView1.DataSource = rscode;

        }

        private void button1_Click(object sender, EventArgs e)
        {






        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ////  dataGridView1.DataSource.
            //if (icount != 1)
            //{
            //    MessageBox.Show("Bạn tìm cho hiện duy nhất 1 code cần add vào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            //}

            //if (icount == 1)
            //{
            //  MessageBox.Show("Bạn tìm cho hiện duy nhất 1 code cần add vào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    xxxx


            //  tbl_kacontractCustcode cust = new tbl_kacontractCustcode();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            string username = Utils.getusername();

         //   string ContractNo = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ContractNo"].Value;
            double codetemp = (double)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Code"].Value;// (double)this.dataGridView1.Rows[0].Cells["Code"].Value;
            string codename = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Name"].Value; //(string)this.dataGridView1.Rows[0].Cells["Name"].Value;



            #region  không add code đã có rồi
            var regioncode = (from p in dc.tbl_kacontractCustcodes

                              where p.CustomerCode == codetemp
                              && p.ContractNo == ContractNo

                              select p).FirstOrDefault();


            #endregion


            if (regioncode != null)
            {
                MessageBox.Show("Code :" + codetemp + "bị lặp đã có trong group code !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ///
                View.Kainputaddcode inputcode = new Kainputaddcode(ContractNo, codename, codetemp);

                inputcode.ShowDialog();

            }

            //    }


        }
    }
}
