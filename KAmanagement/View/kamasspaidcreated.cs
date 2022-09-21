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

            #region  // taok mới contract



            //if (checkberore == true)
            //{
              

            //    // master
            //    var dsmastercontract = from p in dc.tbl_tempmastercontractmasscreates
            //                           where p.Username == username
            //                           select p;

            //    if (dsmastercontract.Count() > 0)
            //    {

            //        foreach (var item in dsmastercontract)
            //        {
            //            tbl_kacontractdata newcontract = new tbl_kacontractdata();

            //            newcontract.Customer = (double)item.Customer;//
            //            newcontract.CustomerType = "SFA";
            //            newcontract.Channel = item.Channel;
            //            newcontract.tel = item.tel;
            //            newcontract.Consts = "CRT";
            //            newcontract.ContractNo = item.ContractNo;
            //            newcontract.ConType = item.ConType;
            //            newcontract.Currency = "VND";
            //            newcontract.Representative = item.Representative;
            //            newcontract.Fullname = item.Fullname;
            //            newcontract.CreditLimit = item.CreditLimit;
            //            newcontract.CreditTerm = item.CreditTerm;
            //            newcontract.DeliveredBy = item.DeliveredBy;
            //            newcontract.SalesOrg = item.SalesOrg;
            //            newcontract.VolComm = item.VolCommitment;
            //            newcontract.NSRComm = item.NSRCommitment;
            //            newcontract.ConTerm = (-item.EfFromDate.Value.Year + item.EftoDate.Value.Year + 1);
            //            newcontract.AnnualVolume = item.VolCommitment / (-item.EfFromDate.Value.Year + item.EftoDate.Value.Year + 1);
            //            newcontract.District = item.District;
            //            newcontract.Province = item.Province;
            //            newcontract.HouseNo = item.HouseNo;
            //            newcontract.VATregistrationNo = item.VATregistrationNo;
            //            newcontract.CRDUSR = username;
            //            newcontract.SignOn = item.EfFromDate;
            //            newcontract.CRDDAT = DateTime.Today;
            //            newcontract.Remarks = item.Remark;
            //            newcontract.EffDate = item.EfFromDate;//  this.dateTimePicker1.Value;
            //            newcontract.EftDate = item.EftoDate;// this.dateTimePicker2.Value;
            //            newcontract.ExtDate = item.ExtendDate; // this.dateTimePicker3.Value;
            //            newcontract.SALORG_CTR = Utils.getfirstusersalescontrolregion();

            //            dc.tbl_kacontractdatas.InsertOnSubmit(newcontract);
            //            dc.SubmitChanges();


            //            var listdetail = from p in dc.tbl_tempcontractsdatadetails
            //                             where p.Username == username
            //                             && p.ContractNo == item.ContractNo
            //                             select p;

            //            if (listdetail.Count() > 0)
            //            {
            //                List<tbl_kacontractsdatadetail> tbl_kacontractsdatadetaillist = new List<tbl_kacontractsdatadetail>();
            //                foreach (var item2 in listdetail)
            //                {
            //                    tbl_kacontractsdatadetail newdetailContract = new tbl_kacontractsdatadetail();

            //                    newdetailContract.Customercode = item.Customer;
            //                    newdetailContract.PayType = item2.Programe;
            //                    newdetailContract.CustomerType = "SFA";
            //                    newdetailContract.Description = item2.PayControl.Trim() + " : " + (from p in dc.tbl_Kafuctionlists
            //                                                                                       where p.Code == item2.PayControl
            //                                                                                       select p.Description.Trim()).FirstOrDefault(); //Description pay control
            //                    newdetailContract.PayControl = item2.PayControl;
            //                    newdetailContract.CommittedDate = item2.Paydate;

            //                    newdetailContract.Remark = item2.Description; // Description contract

            //                    newdetailContract.PrdGrp = item2.PrdGrp;
            //                    newdetailContract.ContractNo = item2.ContractNo;
            //                    newdetailContract.VATregistrationNo = item.VATregistrationNo;
            //                    newdetailContract.SponsoredAmt = item2.Sponsored_Amount;
            //                    newdetailContract.EffFrm = item2.EffFrom;
            //                    newdetailContract.EffTo = item2.EffTo;

            //                    newdetailContract.SALORG_CTR = Utils.getfirstusersalescontrolregion();
            //                    newdetailContract.SalesOrg = item.SalesOrg;
            //                    newdetailContract.Constatus = "CRT";
            //                    newdetailContract.Fullname = item.Fullname;
            //                    newdetailContract.ConType = item.ConType;
            //                    newdetailContract.Address = item.HouseNo.Trim() + " " + item.District.Trim() + " " + item.Province.Trim();


            //                    newdetailContract.CRDDAT = DateTime.Today;
            //                    newdetailContract.CRDUSR = Utils.getusername();

            //                    tbl_kacontractsdatadetaillist.Add(newdetailContract);





            //                }
            //                dc.tbl_kacontractsdatadetails.InsertAllOnSubmit(tbl_kacontractsdatadetaillist);
            //                dc.SubmitChanges();

            //            }






            //        }

            //    }


            //    // detail






            //    MessageBox.Show("Mass contract create done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

       //     }




            #endregion

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
