using KAmanagement.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class kamasspaidcreated : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public Boolean beforecheck { get; set; }




        public DataGridView Dtgridview;
        public List<ComboboxItem> dataCollectionaccount;

        public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
                                                      //1. Định nghĩa 1 delegate


        class datatoExport
        {
            public DataGridView dataGrid1 { get; set; }

        }

        public kamasspaidcreated()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);






            if (this.gridviewmaster.Columns["ContractNo"] != null)
            {
                this.gridviewmaster.Columns["ContractNo"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                this.gridviewmaster.Columns["ContractNo"].DefaultCellStyle.BackColor = Color.LightYellow;


            }




        }


        void Control_KeyPress(object sender, KeyEventArgs e)
        {







        }






        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statusview_Click(object sender, EventArgs e)
        {

        }

        private void cbcontracttypefil_SelectedValueChanged(object sender, EventArgs e)
        {


            //          ReloadKASeachcontractype("", "", "", contractype);



        }





        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // inputempmastercontract
            Model.Contract ctrtemp = new Model.Contract();

            ctrtemp.inputempmascreatepayment();

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var tempaymentlist = from p in dc.tbl_tempmasscreatepayments
                             where p.Username == username
                             select p;

            gridviewmaster.DataSource = tempaymentlist;




        }

    
        private void button3_Click_3(object sender, EventArgs e)
        {




            bool checkberore = true;
            //ContractNo	Sales Org	Con Type	Ef From Date	Ef to Date	Extend Date	Customer				DeliveredBy	HouseNo	District	Province	VATregistrationNo	CreditLimit	CreditTerm	Vol Commitment	NSR Commitment	Remarks

            #region  check số hợp đồng có đúng không / số hợp đồng và id
            // master khong co detai
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region  //  ok paid   typecontract.Contains(tbl_kacontractdata.ConType)

            var masterlist = from p in dc.tbl_tempmasscreatepayments
                             where p.Username == username && !(from dp in dc.tbl_kacontractsdatadetails
                                                               where p.PAYID == dp.PayID
                                                               select dp.ContractNo).Contains(p.ContractNo)
                             select p;
            if (masterlist.Count() > 0)
            {
                foreach (var item in masterlist)
                {
                    item.StatusNote = "Số hợp đồng / Payid bị sai ";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }





            #endregion

     

          
            #region   // ok paid Số tiền thanh toán  phải lớn hơn 0
            var mlist8 = from p in dc.tbl_tempmasscreatepayments
                         where p.PaidRequestAmt <0 
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist8.Count() > 0)
            {
                foreach (var item in mlist8)
                {
                    item.StatusNote = "Số tiền thanh toán phải lớn hơn 0  ";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }
            #endregion

            #region // ok paid contract no phải có, note phải có, paid id phải có
            var mlist9 = from p in dc.tbl_tempmasscreatepayments
                         where p.Noteofpayment.Trim() == ""
                               || p.PAYID <=0
                                 || p.ContractNo.Trim() == ""
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist9.Count() > 0)
            {
                foreach (var item in mlist9)
                {
                    item.StatusNote = "Thiếu số hợp đồng, PayId, note thanh toán ";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion


          



            #endregion

            #region nếu lỗi thoát và refesh lại màn hình

      //      string connection_string = Utils.getConnectionstr();
        //    string username = Utils.getusername();

          //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            if (checkberore == false)
            {
                var tempaymentlist = from p in dc.tbl_tempmasscreatepayments
                                     where p.Username == username
                                     select p;

                gridviewmaster.DataSource = tempaymentlist;

              MessageBox.Show("Thông tin upload vào chưa chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
              #endregion


            if (checkberore == true)
            {


                // string connection_string = Utils.getConnectionstr();

                //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var listcontract = from p in dc.tbl_tempmasscreatepayments
                                   where p.Username == username
                                   select p;

                foreach (var itemtempcontract in listcontract)
                {



                    Control.Control_ac.CaculationContract(itemtempcontract.ContractNo);

                    double totalpairequest = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                              where tbl_kacontractsdetailpayment.ContractNo == itemtempcontract.ContractNo
                                              && tbl_kacontractsdetailpayment.PayID == itemtempcontract.PAYID
                                              select tbl_kacontractsdetailpayment.PaidRequestAmt).Sum().GetValueOrDefault(0);


                    double totalachived = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                           where tbl_kacontractsdatadetail.ContractNo == itemtempcontract.ContractNo
                                               && tbl_kacontractsdatadetail.PayID == itemtempcontract.PAYID
                                           select tbl_kacontractsdatadetail.SponsoredTotal).Sum().GetValueOrDefault(0);






                    if (totalachived < totalpairequest + itemtempcontract.PaidRequestAmt)
                    {

                        #region -- nếu vượt ngân sách thì note
                        itemtempcontract.StatusNote = "PaidRequestAmt phải nhỏ hơn totalachived";
                        dc.SubmitChanges();

                        #endregion

                    }
                    else
                    {
                        #region -- nếu không vượt thì tạo payment
                        var maxbatcno = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments

                                         select tbl_kacontractsdetailpayment.BatchNo).Max();

                        //var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                        //                          where tbl_kacontractsdetailpayment.ContractNo == itemtempcontract.ContractNo && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.BatchNo == 0 && tbl_kacontractsdetailpayment.CRDUSR == Utils.getusername()
                        //                          select tbl_kacontractsdetailpayment;

                        //if (newrequestpaymentRS != null && newrequestpaymentRS.Count() > 0)
                        //{
                        //    foreach (var item in newrequestpaymentRS)
                        //    {

                        //        item.BatchNo = maxbatcno + 1;
                        //        item.CRDDAT = DateTime.Today;
                        //        dc.SubmitChanges();
                        //    }

                        itemtempcontract.StatusNote = "OK";
                        itemtempcontract.BATCHNO = (maxbatcno + 1).ToString();


                        dc.SubmitChanges();

                     //   tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();


                        #region insert to table payment
                        tbl_kacontractsdetailpayment newrequestpayment = new tbl_kacontractsdetailpayment();

                        newrequestpayment.ContractNo = itemtempcontract.ContractNo;
                        newrequestpayment.ContracName = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                                         where tbl_kacontractdata.ContractNo == itemtempcontract.ContractNo
                                                         select tbl_kacontractdata.Fullname).FirstOrDefault();

                        //  newrequestpayment.BLOCKED = false;

                        newrequestpayment.PaidRequestAmt = itemtempcontract.PaidRequestAmt;
                        //       newrequestpayment.PaidAmt = double.Parse(txt_paymentamount.Text);

                        newrequestpayment.PayControl = "REQ";
                        newrequestpayment.BatchNo = (maxbatcno + 1);
                        newrequestpayment.PayID = itemtempcontract.PAYID;

                        newrequestpayment.SubID = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                                   where tbl_kacontractsdetailpayment.PayID == itemtempcontract.PAYID && tbl_kacontractsdetailpayment.ContractNo == itemtempcontract.ContractNo
                                                   select tbl_kacontractsdetailpayment.SubID).Max().GetValueOrDefault(0) + 1;

                        //newrequestpayment.PrdGrp = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                        //                            where tbl_kacontractsdatadetail.PayID == payiD && tbl_kacontractsdatadetail.ContractNo == contractno
                        //                            select tbl_kacontractsdatadetail.PrdGrp).FirstOrDefault();


                        newrequestpayment.PayType = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                                     where tbl_kacontractsdatadetail.PayID == itemtempcontract.PAYID && tbl_kacontractsdatadetail.ContractNo == itemtempcontract.ContractNo
                                                     select tbl_kacontractsdatadetail.PayType).FirstOrDefault();

                        newrequestpayment.Description = "Payment for. " + itemtempcontract.PAYID + "-" + newrequestpayment.SubID;

                        newrequestpayment.Remark = itemtempcontract.Noteofpayment;
                        newrequestpayment.CRDUSR = Utils.getusername();

                        //   cb_subid.Text = newrequestpayment.SubID.ToString();
                     //   this.subid = (int)newrequestpayment.SubID;


                        dc.tbl_kacontractsdetailpayments.InsertOnSubmit(newrequestpayment);
                        dc.SubmitChanges();
                        #endregion



                        #endregion

                    }





                 

                }

                var tempaymentlist2 = from p in dc.tbl_tempmasscreatepayments
                                      where p.Username == username
                                      select p;

                gridviewmaster.DataSource = tempaymentlist2;

                MessageBox.Show("Mass created payment done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var listupdate1 = from p in dc.tbl_tempmasscreatepayments
                              where p.Username == username
                              select p;

            ctrex.exportExceldatagridtofile(listupdate1, dc, "DANH SÁCH PAYMENT AUTO CREATE ");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
