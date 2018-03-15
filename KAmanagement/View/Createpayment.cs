using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KAmanagement.Control;

namespace KAmanagement.View
{


    public partial class Createpayment : Form
    {
        public string contractno { get; set; }

        public View.CreatenewContract formcreatCtract;
        public int payiD { get; set; }
        public int subid { get; set; }

        public void loaddatagriviewpayment()
        {

            string connection_string = Utils.getConnectionstr();
            string Username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var viewrs = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                         where tbl_kacontractsdetailpayment.ContractNo == contractno  && tbl_kacontractsdetailpayment.CRDUSR == Username && tbl_kacontractsdetailpayment.BatchNo == 0  && tbl_kacontractsdetailpayment.PayControl == "REQ"
                         select new
                         {
                             tbl_kacontractsdetailpayment.ContractNo,
                             PayType = tbl_kacontractsdetailpayment.PayType.Trim(),
                             tbl_kacontractsdetailpayment.PayID,
                             tbl_kacontractsdetailpayment.SubID,
                             tbl_kacontractsdetailpayment.PayControl,
                             tbl_kacontractsdetailpayment.PaidRequestAmt,
                             //     tbl_kacontractsdetailpayment.Balance,
                             //   tbl_kacontractsdetailpayment.BalanceAft,
                             tbl_kacontractsdetailpayment.BatchNo,
                             tbl_kacontractsdetailpayment.Remark,


                         };

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.DataSource = viewrs;
           

        }

        public void loaddetailprogarme()
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region load combound program

            //       cb_program

            var prgrs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                        where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayType !="DIS"
                        group tbl_kacontractsdatadetail.PayType by tbl_kacontractsdatadetail.PayType into g
                        select g;
            foreach (var item in prgrs)
            {
                cb_program.Items.Add(item.Key);


            }







            cb_payid.Items.Clear();

            var rspayidcb = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                            where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == this.payiD
                            group tbl_kacontractsdatadetail.PayID by tbl_kacontractsdatadetail.PayID into g
                            select g;
            foreach (var item in rspayidcb)
            {
                cb_payid.Items.Add(item.Key);


            }
            cb_payid.SelectedItem = payiD;
            //     cb_payid.Text = payiD.ToString();



            #endregion load combound programe


            #region load detail program




            var payidrs = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                           where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == this.payiD // && tbl_kacontractsdatadetail.SubID == null
                           group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayID into g
                           select new
                           {
                               SponsoredAmt = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0),
                               PaidAmt = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),
                               Programe = g.Select(gg => gg.PayType).First(),
                               Requesting = g.Sum(gg => gg.PaidRequestAmt).GetValueOrDefault(0),

                           }).FirstOrDefault();

            // txt_sponsoramt
            txt_sponsoramt.Text = payidrs.SponsoredAmt.ToString();
            txt_sponsoramt.Enabled = false;
            txt_paidamt.Text = payidrs.PaidAmt.ToString();
            txt_paidamt.Enabled = false;

            txt_requestedamt.Text = payidrs.Requesting.ToString();
            txt_requestedamt.Enabled = false;

            txt_balance.Text = (payidrs.SponsoredAmt - payidrs.PaidAmt - payidrs.Requesting).ToString();
            txt_balance.Enabled = false;

            cb_program.SelectedItem = payidrs.Programe;
            txt_balancenew.Enabled = false;


            #endregion load detail prgram

        }

        public void loaddetailGRviewrequesting()
        {



        }

        public Createpayment(View.CreatenewContract formcreatCtract, string contractno, int payiD)
        {

    


            #region khoi taok


                InitializeComponent();
                this.contractno = contractno;
                this.formcreatCtract = formcreatCtract;
                txt_contractno.Text = contractno;
                txt_contractno.Enabled = false;
                txt_requestedamt.Enabled = false;
                this.payiD = payiD;
                this.subid = subid;
                // this.txt_batchno.Enabled = false;
                loaddetailprogarme();

                loaddatagriviewpayment();

            if (Model.Contract.checkispaidandalive(contractno) == false)
            {

                button3.Visible = false;
                button2.Visible = false;
                button5.Visible = false;

                
            }   
            
            //&& 
            //if (Model.Contract.checkispaidandalive(tb_contractno.Text) == false && formlabel.Text == "DISPLAY PAYMENT CONTRACT")
            //{
            //    MessageBox.Show(" Không được làm tiếp Payment \n Lý do: \n Hợp đông đã close \n Hoặc chưa hoàn thành thanh toán!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}

            #endregion




        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            // check total paid + totdal request  + this 
            double totalpairequest = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                      where tbl_kacontractsdetailpayment.ContractNo == contractno
                                      select tbl_kacontractsdetailpayment.PaidRequestAmt).Sum().GetValueOrDefault(0);


            double totalachived = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                   where tbl_kacontractsdatadetail.ContractNo == contractno
                                   select tbl_kacontractsdatadetail.SponsoredTotal).Sum().GetValueOrDefault(0);


            if (Utils.IsValidnumber(txt_paymentamount.Text) == true)
            {

                #region
                if (totalachived >= totalpairequest + double.Parse(txt_paymentamount.Text))// + double.Parse(txt_balance.Text) + nếu tổng requeast lớn hơn tổng được trả là không được
                {
                  

                    #region


                    if (double.Parse(txt_paymentamount.Text) > 0)
                    {



                        #region



                        if (double.Parse(txt_balance.Text) >= double.Parse(txt_paymentamount.Text))
                        {


                            #region insert to table payment
                            tbl_kacontractsdetailpayment newrequestpayment = new tbl_kacontractsdetailpayment();

                            newrequestpayment.ContractNo = txt_contractno.Text;
                            //  newrequestpayment.BLOCKED = false;

                            newrequestpayment.PaidRequestAmt = double.Parse(txt_paymentamount.Text);
                            //       newrequestpayment.PaidAmt = double.Parse(txt_paymentamount.Text);

                            newrequestpayment.PayControl = "REQ";
                            newrequestpayment.BatchNo = 0;
                            newrequestpayment.PayID = payiD;

                            newrequestpayment.SubID = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                                       where tbl_kacontractsdetailpayment.PayID == payiD && tbl_kacontractsdetailpayment.ContractNo == contractno
                                                       select tbl_kacontractsdetailpayment.SubID).Max().GetValueOrDefault(0) + 1;

                            //newrequestpayment.PrdGrp = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                            //                            where tbl_kacontractsdatadetail.PayID == payiD && tbl_kacontractsdatadetail.ContractNo == contractno
                            //                            select tbl_kacontractsdatadetail.PrdGrp).FirstOrDefault();


                            newrequestpayment.PayType = cb_program.Text;


                            newrequestpayment.Description = "Payment for. " + payiD + "-" + newrequestpayment.SubID;

                            newrequestpayment.Remark = txt_note.Text.Trim();
                            newrequestpayment.CRDUSR = Utils.getusername();

                            //   cb_subid.Text = newrequestpayment.SubID.ToString();
                            this.subid = (int)newrequestpayment.SubID;


                            dc.tbl_kacontractsdetailpayments.InsertOnSubmit(newrequestpayment);
                            dc.SubmitChanges();
                            #endregion


                            #region update total payment after update payment

                            //   payiD
                            double paymentrequest = double.Parse(txt_paymentamount.Text);
                            string PayType = cb_program.Text;
                            double balancefter = double.Parse(txt_balancenew.Text);
                            // contractno
                            //Update giao dien
                            txt_paymentamount.Text = "0";
                            txt_note.Text = "";
                            txt_balance.Text = balancefter.ToString();
                            txt_requestedamt.Text = (double.Parse(txt_requestedamt.Text) + paymentrequest).ToString();
                            //update value





                            #endregion

                            Control.Control_ac.CaculationContract(txt_contractno.Text);

                            formcreatCtract.loadtotaldContractView(txt_contractno.Text);
                            formcreatCtract.loadDetailContractView(txt_contractno.Text);
                            loaddatagriviewpayment();

                            //    formcreatCtract.loadDetailContractView


                        }
                        else
                        {


                            MessageBox.Show("Payment request must be a number and less than current balace !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }
                        #endregion

                    }
                    else
                    {
                        MessageBox.Show("Payment request must be a greater than 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    #endregion



                    // #endregion

                }
                else
                {


                    MessageBox.Show("Không được do số tiền trả đã lớn hơn tổng được trả ! \n Sponsored total :" + totalachived.ToString() + "\n Total paid & request : "+ totalpairequest.ToString() + "\n This Request :  " + txt_paymentamount.Text +  "\n Balance: " +( totalachived - (totalpairequest + double.Parse(txt_paymentamount.Text))).ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                #endregion
            }
            else
            {


                MessageBox.Show("Payment request must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

               

            }

        //    MessageBox.Show(" Sponsored total :" + totalachived.ToString() + "\n Totalpairequest : " + totalpairequest.ToString() + " This Request :  " + txt_requestedamt.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }






        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_payid.Focus();


            }




        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //      cb_subid.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_sponsoramt.Focus();


            }
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_paidamt.Focus();


            }
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_balance.Focus();


            }
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_paymentamount.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_balancenew.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_contractno.Focus();


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);

            if (this.txt_batchno.Text == "" )
            {
                this.txt_batchno.Text = "0";
            }

            if ( Utils.IsValidnumber(this.txt_batchno.Text) == false)
            {
                MessageBox.Show("Please check Batch No !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int Batchno = int.Parse(this.txt_batchno.Text);


            #region delete  DETAIL AND GRUOP RPT BY USER


            string username = Utils.getusername();
            //  string connection_string = Utils.getConnectionstr();
            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string sqltext = "DELETE FROM tbl_KAdetailprogrRpt WHERE tbl_KAdetailprogrRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();


            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            #endregion



            #region  input detail request payment

            tbl_KAdetailprogrRpt detailrpt2 = new tbl_KAdetailprogrRpt();  //total line
            detailrpt2.Balance = 0;
            detailrpt2.BalanceAftApproval = 0;
            detailrpt2.Paid = 0;
            detailrpt2.PaymentRequest = 0;
            detailrpt2.Sponsorship = 0;
            detailrpt2.Programe = "Total";
            detailrpt2.Username = username;

            var rss1 = from tbl_kaprogramlist in dc.tbl_kaprogramlists
                       where tbl_kaprogramlist.Code !="DIS"
                       select tbl_kaprogramlist;

            foreach (var item in rss1)
            {

                tbl_KAdetailprogrRpt detailrpt = new tbl_KAdetailprogrRpt();  //detail line
                detailrpt.Programe = item.Name;
                detailrpt.Username = username;
                detailrpt.Remarks = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                     where tbl_kacontractsdatadetail.PayType.Trim() == item.Code.Trim() && tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payiD && tbl_kacontractsdatadetail.PayType != "DIS"
                                     select tbl_kacontractsdatadetail.Remark).FirstOrDefault();



                var totaldetailrs = (from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                                     where tbl_kacontractsdatadetail.PayType == item.Code && tbl_kacontractsdatadetail.ContractNo.Trim() == contractno.Trim()
                                     group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayType into g
                                     select new
                                     {

                                         PayType = g.Key,
                                         Paid = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),

                                         Sponsorship = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0),

                                     }).FirstOrDefault();

                if (totaldetailrs != null)
                {

                    detailrpt.Paid = totaldetailrs.Paid;
                    detailrpt.Sponsorship = totaldetailrs.Sponsorship;

                    detailrpt.Balance = detailrpt.Sponsorship - detailrpt.Paid;



                    detailrpt.PaymentRequest = (from tbl_kacontractsdetailpayment in da.tbl_kacontractsdetailpayments
                                                where tbl_kacontractsdetailpayment.BatchNo == Batchno && tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayType == item.Code && tbl_kacontractsdetailpayment.DoneOn ==null
                                                select tbl_kacontractsdetailpayment.PaidRequestAmt).Sum().GetValueOrDefault(0);


                    detailrpt.BalanceAftApproval = detailrpt.Balance - detailrpt.PaymentRequest;

                }
                else
                {
                    detailrpt.PaymentRequest = 0;
                    detailrpt.Paid = 0;
                    detailrpt.Sponsorship = 0;
                    detailrpt.Balance = 0;
                    detailrpt.BalanceAftApproval = 0;
                }


                detailrpt2.Balance = detailrpt2.Balance + detailrpt.Balance;
                detailrpt2.BalanceAftApproval = detailrpt2.BalanceAftApproval + detailrpt.BalanceAftApproval;
                detailrpt2.Paid = detailrpt2.Paid + detailrpt.Paid;
                detailrpt2.PaymentRequest = detailrpt2.PaymentRequest + detailrpt.PaymentRequest;
                detailrpt2.Sponsorship = detailrpt2.Sponsorship + detailrpt.Sponsorship;



                dc.tbl_KAdetailprogrRpts.InsertOnSubmit(detailrpt);
                dc.SubmitChanges();

            }



            dc.tbl_KAdetailprogrRpts.InsertOnSubmit(detailrpt2);
            dc.SubmitChanges();

            #endregion





            #region  MAKE master rpt

            var itemmasterKA = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                where tbl_kacontractdata.ContractNo == contractno
                                select tbl_kacontractdata).FirstOrDefault();


            if (itemmasterKA != null)
            {
                tbl_KapaymentrequestRpt requestmaster = new tbl_KapaymentrequestRpt();

                requestmaster.ContractNo = itemmasterKA.ContractNo;
                requestmaster.Username = username;
                //     requestmaster.AchvRevenue
                // requestmaster.address  = itemmasterKA.a
                requestmaster.Annualvolume = itemmasterKA.AnnualVolume;
                requestmaster.Channel = itemmasterKA.Channel;
                requestmaster.CityProvince = itemmasterKA.Province;
                // requestmaster.Colddrinks
                requestmaster.Committedvol = itemmasterKA.VolComm;
                // requestmaster.ContractNo 
                requestmaster.ContractType = itemmasterKA.ConType;
                // requestmaster.Costpercase
                requestmaster.Creditlimit = itemmasterKA.CreditLimit;
                requestmaster.Creditterm = itemmasterKA.CreditTerm;
                requestmaster.Currency = itemmasterKA.Currency;
                requestmaster.Customercode = itemmasterKA.Customer;
                requestmaster.Deliveredby = itemmasterKA.DeliveredBy;

                // requestmaster.Discount
                requestmaster.District = itemmasterKA.District;
                requestmaster.EffectiveDate = itemmasterKA.EffDate;
                requestmaster.ExpireDate = itemmasterKA.EftDate;
                requestmaster.ExtendDate = itemmasterKA.ExtDate;
                // requestmaster.Fundspercent
                requestmaster.Note = txt_note.Text;
                //      requestmaster.ProductGroup = itemmasterKA.PrdGrp;
                requestmaster.Representative = itemmasterKA.Representative;
                requestmaster.SalesOrg = itemmasterKA.SalesOrg;
                requestmaster.Street = itemmasterKA.HouseNo;
                // requestmaster.SupportCase
                requestmaster.TermYear = (itemmasterKA.EftDate.Value.Year - itemmasterKA.EffDate.Value.Year);
                requestmaster.TradeName = itemmasterKA.Fullname;
                requestmaster.ReferrenceDoc = Batchno.ToString();
                //requestmaster.Username
                requestmaster.AchievedVolPCs = itemmasterKA.PCVolAched; 
                requestmaster.NSRcommit = itemmasterKA.NSRComm;  // hiện nsa co,,it
                requestmaster.AchvRevenue = itemmasterKA.NSRAched;

              if (itemmasterKA.VolComm > 0 && itemmasterKA.VolComm != null && itemmasterKA.PCVolAched != null)
             {

              
              requestmaster.Achievedpercent = ((itemmasterKA.PCVolAched) / itemmasterKA.VolComm);
               }


                dc.tbl_KapaymentrequestRpts.InsertOnSubmit(requestmaster);
                dc.SubmitChanges();


            }

            //requestmaster.Vendor





            #endregion

            #region  view reports payment request  

            Control_ac ctrac = new Control_ac();

            var rs1 = ctrac.KArptdataset1(dc);
            var rs2 = ctrac.KArptdataset2(dc);





            if (rs1 != null && rs2 != null)
            {

                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, rs1);
                var dataset2 = ut.ToDataTable(dc, rs2);
                Reportsview rpt = new Reportsview(dataset1, dataset2, "PaymentRequest.rdlc", Batchno, contractno, formcreatCtract);
                rpt.ShowDialog();

            }

            #endregion view reports payment request  // 



        }


        private void txt_paymentamount_TextChanged(object sender, EventArgs e)
        {
            if (txt_balance.Text =="")
            {
                txt_balance.Text = "0";
            }

            if (Utils.IsValidnumber(txt_paymentamount.Text) && double.Parse(txt_balance.Text) >= double.Parse(txt_paymentamount.Text) && double.Parse(txt_paymentamount.Text) > 0)
            {

                #region load term and yeayr


                this.txt_balancenew.Text = (double.Parse(txt_balance.Text) - double.Parse(txt_paymentamount.Text)).ToString();



                #endregion

            }

        }

        private void txt_paymentamount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                txt_note.Focus();
            }








        }

        private void button2_Click(object sender, EventArgs e)
        {


            string contractno = txt_contractno.Text;

            int payID = int.Parse(cb_payid.Text);

            //     int SubID = int.Parse(cb_subid.Text);


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();



            var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                      where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.BatchNo == 0
                                      select tbl_kacontractsdetailpayment;

            if (newrequestpaymentRS != null)
            {



                dc.tbl_kacontractsdetailpayments.DeleteAllOnSubmit(newrequestpaymentRS);
                dc.SubmitChanges();




            }


            Control.Control_ac.CaculationContract(txt_contractno.Text);
            this.payiD = int.Parse(cb_payid.Text);

            //      this.payiD = int.Parse(this.cb_payid.SelectedValue.ToString());
            //   MessageBox.Show(this.cb_payid.SelectedValue.ToString());
            // loaddetailprogarme();
            #region load detail program

            // string connection_string = Utils.getConnectionstr();

            //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var payidrs = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                           where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == this.payiD // && tbl_kacontractsdatadetail.SubID == null
                           group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayID into g
                           select new
                           {
                               SponsoredAmt = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0),
                               PaidAmt = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),
                               Programe = g.Select(gg => gg.PayType).First(),
                               Requesting = g.Sum(gg => gg.PaidRequestAmt).GetValueOrDefault(0),

                           }).FirstOrDefault();

            // txt_sponsoramt
            txt_sponsoramt.Text = payidrs.SponsoredAmt.ToString();
            txt_sponsoramt.Enabled = false;


            txt_paidamt.Text = payidrs.PaidAmt.ToString();
            txt_paidamt.Enabled = false;

            txt_requestedamt.Text = payidrs.Requesting.ToString();
            txt_requestedamt.Enabled = false;

            txt_balance.Text = (payidrs.SponsoredAmt - payidrs.PaidAmt - payidrs.Requesting).ToString();
            txt_balance.Enabled = false;

            //    cb_program.SelectedItem = payidrs.Programe;
            //  txt_balancenew.Enabled = false;


            #endregion load detail prgram


            // loaddetailprogarme(payiD);
            formcreatCtract.loadtotaldContractView(txt_contractno.Text);
            formcreatCtract.loadDetailContractView(txt_contractno.Text);
            loaddatagriviewpayment();


        }



        private void cb_payid_SelectedValueChanged(object sender, EventArgs e)
        {
            this.payiD = int.Parse(cb_payid.Text);
            txt_paymentamount.Text = "0";

            //      this.payiD = int.Parse(this.cb_payid.SelectedValue.ToString());
            //   MessageBox.Show(this.cb_payid.SelectedValue.ToString());
            // loaddetailprogarme();


            #region load detail program

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var payidrs = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                           where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == this.payiD // && tbl_kacontractsdatadetail.SubID == null
                           group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayID into g
                           select new
                           {
                               SponsoredAmt = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0),
                               PaidAmt = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),
                               Programe = g.Select(gg => gg.PayType).First(),
                               Requesting = g.Sum(gg => gg.PaidRequestAmt).GetValueOrDefault(0),

                           }).FirstOrDefault();

            // txt_sponsoramt
            txt_sponsoramt.Text = payidrs.SponsoredAmt.ToString();
            txt_sponsoramt.Enabled = false;


            txt_paidamt.Text = payidrs.PaidAmt.ToString();
            txt_paidamt.Enabled = false;

            txt_requestedamt.Text = payidrs.Requesting.ToString();
            txt_requestedamt.Enabled = false;

            txt_balance.Text = (payidrs.SponsoredAmt - payidrs.PaidAmt - payidrs.Requesting).ToString();
            txt_balance.Enabled = false;

            //    cb_program.SelectedItem = payidrs.Programe;
            //  txt_balancenew.Enabled = false;


            #endregion load detail prgram


            // loaddetailprogarme(payiD);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();



            var maxbatcno = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments

                             select tbl_kacontractsdetailpayment.BatchNo).Max();



            var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                      where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.BatchNo == 0 && tbl_kacontractsdetailpayment.CRDUSR == Utils.getusername()
                                      select tbl_kacontractsdetailpayment;

            if (newrequestpaymentRS != null && newrequestpaymentRS.Count() > 0)
            {
                foreach (var item in newrequestpaymentRS)
                {

                    item.BatchNo = maxbatcno + 1;
                    item.CRDDAT = DateTime.Today;
                    dc.SubmitChanges();
                }

                

            }

            txt_batchno.Text = (maxbatcno + 1).ToString();

            //     Control.Control_ac.CaculationContract(txt_contractno.Text);

            //formcreatCtract.loadtotaldContractView(txt_contractno.Text);
            //formcreatCtract.loadDetailContractView(txt_contractno.Text);
            loaddatagriviewpayment();

            

        }

        private void Createpayment_Load(object sender, EventArgs e)
        {

        }

        private void cb_program_SelectedValueChanged_1(object sender, EventArgs e)
        {
            //   cb_program



            cb_payid.Items.Clear();

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rspayidcb = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                            where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayType == cb_program.Text.ToString()
                            group tbl_kacontractsdatadetail.PayID by tbl_kacontractsdatadetail.PayID into g
                            select g;
            foreach (var item in rspayidcb)
            {
                cb_payid.Items.Add(item.Key);


            }
            cb_payid.SelectedIndex = 0;
            txt_paymentamount.Text = "0";
           
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string contractno = txt_contractno.Text;
            if (Utils.IsValidnumber(this.txt_batchno.Text)== false)
            {
                MessageBox.Show("Please check Batchno doc. "  + this.txt_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int Batchno = int.Parse(this.txt_batchno.Text);
            //   int payID = int.Parse(cb_payid.Text);

            //     int SubID = int.Parse(cb_subid.Text);


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();



            var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                      where tbl_kacontractsdetailpayment.BatchNo == Batchno
                                      select tbl_kacontractsdetailpayment;

            if (newrequestpaymentRS != null)
            {
                if (newrequestpaymentRS.FirstOrDefault() != null)
                {
                     if (newrequestpaymentRS.FirstOrDefault().PrintChk == false)
                    {

                        dc.tbl_kacontractsdetailpayments.DeleteAllOnSubmit(newrequestpaymentRS);
                        dc.SubmitChanges();
                        MessageBox.Show("Doc." + Batchno + " delete !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Doc." + Batchno + " prited so can not delete! please contact Analyst to help", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please check Batchno doc. " + Batchno , "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            // loaddetailprogarme(payiD);
            formcreatCtract.loadtotaldContractView(txt_contractno.Text);
            formcreatCtract.loadDetailContractView(txt_contractno.Text);
            loaddatagriviewpayment();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string Username = Utils.getusername();
            if (Utils.IsValidnumber(this.txt_batchno.Text) == false)
            {
                MessageBox.Show("Please check Batchno doc. " + this.txt_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int BatchNo = int.Parse(this.txt_batchno.Text);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var viewrs = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                         where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.CRDUSR == Username && tbl_kacontractsdetailpayment.BatchNo == BatchNo
                         select new
                         {
                             tbl_kacontractsdetailpayment.ContractNo,
                             PayType = tbl_kacontractsdetailpayment.PayType.Trim(),
                             tbl_kacontractsdetailpayment.PayID,
                             tbl_kacontractsdetailpayment.SubID,
                             tbl_kacontractsdetailpayment.PayControl,
                             tbl_kacontractsdetailpayment.PaidRequestAmt,
                             //     tbl_kacontractsdetailpayment.Balance,
                             //   tbl_kacontractsdetailpayment.BalanceAft,
                             tbl_kacontractsdetailpayment.BatchNo,
                             tbl_kacontractsdetailpayment.Remark,


                         };

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.DataSource = viewrs;

        }

        private void Createpayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string Username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var viewrs = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                         where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.CRDUSR == Username && tbl_kacontractsdetailpayment.BatchNo == 0// && tbl_kacontractsdetailpayment.PayControl == "REQ
                         select tbl_kacontractsdetailpayment;
                         //{
                         //    tbl_kacontractsdetailpayment.ContractNo,
                         //    PayType = tbl_kacontractsdetailpayment.PayType.Trim(),
                         //    tbl_kacontractsdetailpayment.PayID,
                         //    tbl_kacontractsdetailpayment.SubID,
                         //    tbl_kacontractsdetailpayment.PayControl,
                         //    tbl_kacontractsdetailpayment.PaidRequestAmt,
                         //    //     tbl_kacontractsdetailpayment.Balance,
                         //    //   tbl_kacontractsdetailpayment.BalanceAft,
                         //    tbl_kacontractsdetailpayment.BatchNo,
                         //    tbl_kacontractsdetailpayment.Remark,


                         //};

            //   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //    this.dataGridView1.DataSource = viewrs;
            dc.tbl_kacontractsdetailpayments.DeleteAllOnSubmit(viewrs);
            dc.SubmitChanges();
        }
    }


}
