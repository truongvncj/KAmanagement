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

    // public static 
    public partial class kaconfirmPayment : Form
    {

        public View.CreatenewContract Contractview { get; set; }

        public string ContractNo { get; set; }
        public string Description { get; set; }
        //  string Description
        // PaymentDoc
        public string PaymentDoc { get; set; }
        public int Batchno { get; set; }

        public string Programe { get; set; } //= programe
        public int PayID { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());
        public int SubID { get; set; }// = int.Parse(this.txconfimr.Text.ToString()); //deposiamount + deposiamount

        public double PaidRequestAmt { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());
   //     public string header { get; set; }




     //   public string header { get; set; }
        public kaconfirmPayment(View.CreatenewContract Contract, string ContractNo,  int Batchno, string Programe, int PayID, int SubID, double PaidRequestAmt, string Description, string PaymentDoc)
        {

        

            #region khowri taoj



            InitializeComponent();
            //     this.header = header;
            this.Contractview = Contract;
            this.ContractNo = ContractNo;
            this.Description = Description;
            this.PaymentDoc = PaymentDoc;
            this.Batchno = Batchno;
            this.Programe = Programe;
            this.PayID = PayID;
            this.SubID = SubID;
            this.PaidRequestAmt = PaidRequestAmt;

            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            txtPaydoc.Text = PaymentDoc.Trim();
            lbcontractno.Text = ContractNo.Trim();
            txtpaidnote.Text = Description.Trim();

            lbBactchdoc.Text = Batchno.ToString();
            lb_programe.Text = Programe.ToString();
            lbpayid.Text = PayID.ToString();
            lbsubid.Text = SubID.ToString();
            lbpaymentamt.Text = PaidRequestAmt.ToString();

            pickdatedoneon.Value = DateTime.Today;
            #endregion




        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {





        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string contractno = lbcontractno.Text;


            string connection_string = Utils.getConnectionstr();

            //if (Utils.IsValidnumber(lbBactchdoc.Text) == false)
            //{
            //    MessageBox.Show("Please check Batchno doc. " + lbBactchdoc.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            int BatchNo = int.Parse(lbBactchdoc.Text);


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rsprint = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                          where tbl_kacontractsdetailpayment.BatchNo == BatchNo
                          select tbl_kacontractsdetailpayment;

            if (rsprint.Count() > 0)
            {
                foreach (var item in rsprint)
                {
                    item.PrintChk = false;
                    item.Reprint = true;
                    dc.SubmitChanges();

                }







            }

            #region dataGridView7  detail pay ment

            var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                           where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.BatchNo == BatchNo

                                           select new
                                           {

                                               Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                               PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                               Description = tbl_kacontractsdetailpayment.Remark.Trim(),
                                           
                                               Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                           //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                               PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,

                                               tbl_kacontractsdetailpayment.PaidRequestAmt,
                                               tbl_kacontractsdetailpayment.PrintChk,
                                               tbl_kacontractsdetailpayment.Reprint,
                                               tbl_kacontractsdetailpayment.PrintDate,

                                            //   Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                               tbl_kacontractsdetailpayment.BatchNo,
                                               tbl_kacontractsdetailpayment.CRDDAT,
                                               tbl_kacontractsdetailpayment.CRDUSR,
                                               tbl_kacontractsdetailpayment.DoneOn,
                                               Paid_Note = tbl_kacontractsdetailpayment.PaidNote,
                                          //     Paid_Note = tbl_kacontractsdetailpayment.PaidNote,
                                               tbl_kacontractsdetailpayment.UPDDAT,
                                               tbl_kacontractsdetailpayment.UPDUSR,
                                               PayID = tbl_kacontractsdetailpayment.PayID,
                                               SubID = tbl_kacontractsdetailpayment.SubID,



                                           };


            Contractview.loadpaymentstausgridview(dataGridProgramdetailrs7);

            #endregion

            this.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.cb_customerka.DroppedDown == false)
            //{
            //    SendKeys.Send("{F4}");
            //    //  SendKeys.Send("{F4}");
            //}
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtpaidnote.Focus();




            }

        }

        private void txconfimr_KeyPress(object sender, KeyPressEventArgs e)
        {
            //       txtpaidnote2
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtpaidnote2.Focus();




            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var paymentdetail = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                          where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNo) &&
                          tbl_kacontractsdetailpayment.PayControl.Equals( Programe) &&
                          tbl_kacontractsdetailpayment.PayID == PayID  &&
                          tbl_kacontractsdetailpayment.SubID == SubID &&
                          tbl_kacontractsdetailpayment.BatchNo == Batchno
                            select tbl_kacontractsdetailpayment).FirstOrDefault();

            if (paymentdetail != null)
            {

                paymentdetail.PayControl = "PAY";
                paymentdetail.PaidAmt = PaidRequestAmt;
                //   paymentdetail.PaidRequestAmt = 0;
                if (txtpaidnote.Text != null )
                {
                    if (txtpaidnote.Text.ToString().Trim() != "")
                    {
                        paymentdetail.Remark = txtpaidnote.Text.ToString();
                    }
                    
                }


                //// txtpaidnote
                //if (txtpaidnote.Text != null)
                //{
                //    if (txtpaidnote.Text.Trim() != "")
                //    {
                //        //  txtpaidnote2
                //        paymentdetail.Description = txtpaidnote.Text.ToString();
                //    }
                //}


                if (txtpaidnote2.Text != null)
                {
                    if (txtpaidnote2.Text.Trim() != "")
                    {
                        //  txtpaidnote2
                        paymentdetail.PaidNote = txtpaidnote2.Text.ToString();
                    }
                }

                if (txtPaydoc.Text != null)
                {
                    if (txtPaydoc.Text.ToString().Trim() != "")
                    {
                        paymentdetail.PaymentDoc = txtPaydoc.Text.ToString();
                    }
                }

                       
                paymentdetail.PaidOn = pickdatedoneon.Value;
                paymentdetail.DoneOn =  DateTime.Today;

                paymentdetail.UPDDAT = DateTime.Today;
                paymentdetail.UPDUSR = Utils.getusername();

                dc.SubmitChanges();
             //   this.Close();
            }


            #region dataGridView7  detail pay ment

            var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                           where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNo)// && tbl_kacontractsdetailpayment.BatchNo == Batchno

                                           select new
                                           {

                                               Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                               PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                               Description = tbl_kacontractsdetailpayment.Remark.Trim(),
                                           
                                               Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                           //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                               PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,

                                               tbl_kacontractsdetailpayment.PaidRequestAmt,
                                               tbl_kacontractsdetailpayment.PrintChk,
                                               tbl_kacontractsdetailpayment.Reprint,
                                               tbl_kacontractsdetailpayment.PrintDate,

                                        //       Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                               tbl_kacontractsdetailpayment.BatchNo,
                                               tbl_kacontractsdetailpayment.CRDDAT,
                                               tbl_kacontractsdetailpayment.CRDUSR,
                                               tbl_kacontractsdetailpayment.DoneOn,
                                               Paid_Note = tbl_kacontractsdetailpayment.PaidNote,

                                               tbl_kacontractsdetailpayment.UPDDAT,
                                               tbl_kacontractsdetailpayment.UPDUSR,

                                               PayID = tbl_kacontractsdetailpayment.PayID,
                                               SubID = tbl_kacontractsdetailpayment.SubID,


                                           };


            Contractview.loadpaymentstausgridview(dataGridProgramdetailrs7);
            //  Contractview.loadpaymentstausgridview(dataGridProgramdetailrs7);
            Contractview.loadtotaldContractView(ContractNo);


            #endregion


            this.Close();
        }

        private void txtPaydoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtPaydoc.Focus();




            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var paymentdetail = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                 where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNo) &&
                                 tbl_kacontractsdetailpayment.PayControl.Equals(Programe) &&
                                 tbl_kacontractsdetailpayment.PayID == PayID &&
                                 tbl_kacontractsdetailpayment.SubID == SubID &&
                                 tbl_kacontractsdetailpayment.BatchNo == Batchno
                                 select tbl_kacontractsdetailpayment).FirstOrDefault();

            if (paymentdetail != null)
            {

                paymentdetail.PayControl = "REJ";
                paymentdetail.PaidAmt = 0;
                //   paymentdetail.PaidRequestAmt = 0;
                if (txtpaidnote.Text != null)
                {
                    if (txtpaidnote.Text.ToString().Trim() != "")
                    {
                        paymentdetail.Remark = txtpaidnote.Text.ToString();
                    }

                }


                //// txtpaidnote
                //if (txtpaidnote.Text != null)
                //{
                //    if (txtpaidnote.Text.Trim() != "")
                //    {
                //        //  txtpaidnote2
                //        paymentdetail.Description = txtpaidnote.Text.ToString();
                //    }
                //}


                if (txtpaidnote2.Text != null)
                {
                    if (txtpaidnote2.Text.Trim() != "")
                    {
                        //  txtpaidnote2
                        paymentdetail.PaidNote = txtpaidnote2.Text.ToString();
                    }
                }

                if (txtPaydoc.Text != null)
                {
                    if (txtPaydoc.Text.ToString().Trim() != "")
                    {
                        paymentdetail.PaymentDoc = txtPaydoc.Text.ToString();
                    }
                }


                //       paymentdetail.PaidOn = pickdatedoneon.Value;
                //     paymentdetail.DoneOn = DateTime.Today;

                paymentdetail.UPDDAT = DateTime.Today;
                paymentdetail.UPDUSR = Utils.getusername();

                dc.SubmitChanges();


                #region dataGridView7  detail pay ment

                var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                               where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNo)// && tbl_kacontractsdetailpayment.BatchNo == Batchno

                                               select new
                                               {

                                                   Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                                   PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                                   Description = tbl_kacontractsdetailpayment.Remark.Trim(),

                                                   Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                                   //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                                   PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,

                                                   tbl_kacontractsdetailpayment.PaidRequestAmt,
                                                   tbl_kacontractsdetailpayment.PrintChk,
                                                   tbl_kacontractsdetailpayment.Reprint,
                                                   tbl_kacontractsdetailpayment.PrintDate,

                                                   //       Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                                   tbl_kacontractsdetailpayment.BatchNo,
                                                   tbl_kacontractsdetailpayment.CRDDAT,
                                                   tbl_kacontractsdetailpayment.CRDUSR,
                                                   tbl_kacontractsdetailpayment.DoneOn,
                                                   Paid_Note = tbl_kacontractsdetailpayment.PaidNote,

                                                   tbl_kacontractsdetailpayment.UPDDAT,
                                                   tbl_kacontractsdetailpayment.UPDUSR,

                                                   PayID = tbl_kacontractsdetailpayment.PayID,
                                                   SubID = tbl_kacontractsdetailpayment.SubID,


                                               };


                Contractview.loadpaymentstausgridview(dataGridProgramdetailrs7);
                //  Contractview.loadpaymentstausgridview(dataGridProgramdetailrs7);
                Contractview.loadtotaldContractView(ContractNo);


                #endregion


                this.Close();

                 }
        

            }

        private void kaconfirmPayment_Load(object sender, EventArgs e)
        {

        }

        private void txtpaidnote_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void pickdatedoneon_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtpaidnote2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                button1.Focus();




            }
        }
    }
}
