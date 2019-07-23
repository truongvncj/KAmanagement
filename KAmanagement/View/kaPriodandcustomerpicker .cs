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
    public partial class kaPriodandcustomerpicker : Form
    {

        public string priod { get; set; }
        public string customercode { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public bool kq { get; set; }



        public kaPriodandcustomerpicker()
        {
            InitializeComponent();

            kq = false;

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs2 = from tbl_Kapriod in dc.tbl_Kapriods
                   where tbl_Kapriod.block == false
                      select tbl_Kapriod;

            string drowdownshow = "";

            foreach (var item in rs2)
            {
                drowdownshow = item.Priod;
                cb_priod.Items.Add(drowdownshow);


            }
            priod = "";
            customercode = "";

            cbcustomer.Text = "";
       //     lbcustomername.Text = "";
            lb_priods.Text = "";
            lb_fromdates.Text = "";
            lbtodates.Text = "";
           // cb_priod.SelectedIndex = 1;
           //   priod = null;
        }

        //private void cb_year_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    //    bl_priod.Text = cb_month.Text + cb_year.Text;





        //}

        //private void cb_month_SelectedValueChanged(object sender, EventArgs e)
        //{
        // //   bl_priod.Text = cb_month.Text + cb_year.Text;
        //}

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
          //  priod = "";
//            customercode = "";


            if (lb_priods.Text != "" && lb_priods.Text !=null && cbcustomer.Text != "" && cbcustomer.Text != null && Utils.IsValidnumber(cbcustomer.Text))
            {
                priod = lb_priods.Text;
                customercode = cbcustomer.Text;
                string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs2 = (from tbl_Kapriod in dc.tbl_Kapriods
                       where tbl_Kapriod.Priod == priod
                       select tbl_Kapriod).FirstOrDefault();


           // lb_priods.Text = rs2.Priod;
            fromdate = rs2.fromdate.Value;
            todate = rs2.todate.Value;
                kq = true;
                this.Close();
            }

            if (lb_priods.Text == "" || lb_priods.Text == null || cbcustomer.Text == "" || cbcustomer.Text == null || !Utils.IsValidnumber(cbcustomer.Text))
            {

                MessageBox.Show("Bạn phải chọ kỳ dữ liệu và code khác hàng !", "Chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


        }

        private void bl_priod_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_priod_SelectionChangeCommitted(object sender, EventArgs e)
        {
         


        }

        private void cb_priod_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_priod_SelectedValueChanged(object sender, EventArgs e)
        {
            priod = cb_priod.Text;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs2 = (from tbl_Kapriod in dc.tbl_Kapriods
                       where tbl_Kapriod.Priod == priod
                       select tbl_Kapriod).FirstOrDefault();


            lb_priods.Text = rs2.Priod;
            lb_fromdates.Text = rs2.fromdate.Value.ToShortDateString();
            lbtodates.Text = rs2.todate.Value.ToShortDateString();
        }
    }
}
