﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class KASeachpaymentRequest : Form
    {
        public View.Viewtable Fromviewable;
    //    public DataGridView Dtgridview;
       
        public string tablename;

    



        public KASeachpaymentRequest(View.Viewtable Fromviewable, string tablename)
        {

          
         //   return false;





            InitializeComponent();
            this.Fromviewable = Fromviewable;

            this.tablename = tablename;

        }



        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                sendingcontract.Focus();

                if (tablename == "KASeachPaymentRequest")
                {
                    Fromviewable.ReloadKASeachPayment(this.sendingBatchno.Text, this.sendingcontract.Text, this.sendingname.Text);
                }



            }

        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                sendingname.Focus();


                if (tablename == "KASeachPaymentRequest")
                {
                    Fromviewable.ReloadKASeachPayment(this.sendingBatchno.Text, this.sendingcontract.Text, this.sendingname.Text);
                }



            }
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                this.sendingBatchno.Focus();


                if (tablename == "KASeachPaymentRequest")
                {
                    Fromviewable.ReloadKASeachPayment(this.sendingBatchno.Text, this.sendingcontract.Text, this.sendingname.Text);
                }



            }
        }

      
      

        private void sendingcontract_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendingcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
