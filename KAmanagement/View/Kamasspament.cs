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
    public partial class Kamasspament : Form
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

        public Kamasspament()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);






            if (this.gridviewmasspayment.Columns["ContractNo"] != null)
            {
                this.gridviewmasspayment.Columns["ContractNo"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                this.gridviewmasspayment.Columns["ContractNo"].DefaultCellStyle.BackColor = Color.LightYellow;


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

            ctrtemp.inputempmasspayment();

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var masterlist = from p in dc.tbl_tempmasspayments
                             where p.Username == username
                             select p;

        
            gridviewmasspayment.DataSource = masterlist;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Model.Contract ctrtemp = new Model.Contract();

            ctrtemp.inputempdetailcontract();
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var detaillist = from p in dc.tbl_tempcontractsdatadetails
                             where p.Username == username
                             select p;

            GridViewdetail.DataSource = detaillist;
        }

        private void button3_Click_3(object sender, EventArgs e)
        {




            bool checkberore = true;
            //ContractNo	Sales Org	Con Type	Ef From Date	Ef to Date	Extend Date	Customer				DeliveredBy	HouseNo	District	Province	VATregistrationNo	CreditLimit	CreditTerm	Vol Commitment	NSR Commitment	Remarks

            #region  check  master
            // master khong co detai
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region  //     typecontract.Contains(tbl_kacontractdata.ConType)

            var masterlist = from p in dc.tbl_tempmastercontractmasscreates
                             where p.Username == username && !(from dp in dc.tbl_tempcontractsdatadetails
                                                               where dp.Username == username
                                                               select dp.ContractNo).Contains(p.ContractNo)
                             select p;
            if (masterlist.Count() > 0)
            {
                foreach (var item in masterlist)
                {
                    item.StatusNote = "Master ContractNo  không có Detai ở list Detail !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }





            #endregion

            #region       //contract no đã có bị lặp


            var mlist2 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Username == username && (from dp in dc.tbl_kacontractdatas
                                                              //    where dp.Username == username
                                                          select dp.ContractNo).Contains(p.ContractNo)
                         select p;
            if (mlist2.Count() > 0)
            {
                foreach (var item in mlist2)
                {
                    item.StatusNote = "Master ContractNo bị lặp trên hệ thống !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }

            #endregion


            #region  //Sai contract type
            List<string> listtypyeCtr = new List<string>();
            listtypyeCtr.Add("ASMPQ");
            listtypyeCtr.Add("DASANI");

            var mlist3 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Username == username && !listtypyeCtr.Contains(p.ConType)
                         select p;
            if (mlist3.Count() > 0)
            {
                foreach (var item in mlist3)
                {
                    item.StatusNote = "Contract type sai ! hiện ASMPQ /DASANI ";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion


            #region     //sai Sales Org  
            var mlist4 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Username == username && !(from dp in dc.tbl_karegions

                                                           select dp.Region).Contains(p.SalesOrg)
                         select p;
            if (mlist4.Count() > 0)
            {
                foreach (var item in mlist4)
                {
                    item.StatusNote = "ContractNo có contract sales Orge sai!";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion
            var channellist = from dp in dc.tbl_kaChannels
                              where dp.Channel != ""
                              select dp.Channel.Trim();

            #region   //Channel sai channel
            var mlist5 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Channel != "" && p.Username == username// && ! (from dp in dc.tbl_kaChannels //tbl_kaChannel
                         && !channellist.Contains(p.Channel.Trim())
                         //     select dp.Channel.Trim().ToUpper()).Contains(p.Channel.Trim().ToUpper())
                         select p;
            if (mlist5.Count() > 0)
            {
                foreach (var item in mlist5)
                {
                    item.StatusNote = "ContractNo có Channel sai!";
                    dc.SubmitChanges();
                }


                checkberore = false;

            }

            #endregion



            #region    //Ef From Date >  Ef to Date
            var mlist6 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.EfFromDate > p.EftoDate
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist6.Count() > 0)
            {
                foreach (var item in mlist6)
                {
                    item.StatusNote = "ContractNo có From date > Todate, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }

            #endregion

            #region   //Extend Date <  Ef to Date
            var mlist7 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.ExtendDate < p.EftoDate
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist7.Count() > 0)
            {
                foreach (var item in mlist7)
                {
                    item.StatusNote = "ContractNo có Extend date < Todate, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }

            #endregion

            //Customer  lặp nếu có code
            #region   //Fullname thiếu
            var mlist8 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Fullname.Trim() == ""
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist8.Count() > 0)
            {
                foreach (var item in mlist8)
                {
                    item.StatusNote = "ContractNo có  full name thiếu, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }
            #endregion

            #region //Representative thiếu
            var mlist9 = from p in dc.tbl_tempmastercontractmasscreates
                         where p.Representative.Trim() == ""
                         where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                         //   select dp.Channel).Contains(p.Channel)
                         select p;
            if (mlist9.Count() > 0)
            {
                foreach (var item in mlist9)
                {
                    item.StatusNote = "ContractNo có  full Representative, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion


            #region //HouseNo thiếu
            var mlist11 = from p in dc.tbl_tempmastercontractmasscreates
                          where p.HouseNo.Trim() == ""
                          where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                          //   select dp.Channel).Contains(p.Channel)
                          select p;
            if (mlist11.Count() > 0)
            {
                foreach (var item in mlist11)
                {
                    item.StatusNote = "Cột HouseNo thiếu thông tin, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion



            #region //Province thiếu
            var mlist12 = from p in dc.tbl_tempmastercontractmasscreates
                          where p.Province.Trim() == ""
                          where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                          //   select dp.Channel).Contains(p.Channel)
                          select p;
            if (mlist12.Count() > 0)
            {
                foreach (var item in mlist12)
                {
                    item.StatusNote = "Cột Province thiếu thông tin, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion



            #region //District thiếu
            var mlist13 = from p in dc.tbl_tempmastercontractmasscreates
                          where p.District.Trim() == ""
                          where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                          //   select dp.Channel).Contains(p.Channel)
                          select p;
            if (mlist13.Count() > 0)
            {
                foreach (var item in mlist13)
                {
                    item.StatusNote = "Cột District thiếu thông tin, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion


            #region  // check curent payment terma

            var mlist10 = from p in dc.tbl_tempmastercontractmasscreates

                          where p.CreditTerm != "" && p.Username == username && !(from dp in dc.tbl_PaymentTerms

                                                                                  select dp.PaymentTerm).Contains(p.CreditTerm)
                          select p;
            if (mlist10.Count() > 0)
            {
                foreach (var item in mlist10)
                {
                    item.StatusNote = "ContractNo có CreditTerm sai!";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion



            #endregion

            #region  check  detail


            #region   // detail ko có mastercontract 
            var detailck1 = from p in dc.tbl_tempcontractsdatadetails
                            where p.Username == username && !(from dp in dc.tbl_tempmastercontractmasscreates
                                                              where dp.Username == username
                                                              select dp.ContractNo).Contains(p.ContractNo)
                            select p;
            if (detailck1.Count() > 0)
            {
                foreach (var item in detailck1)
                {
                    item.StatusNote = "Detail ContarctNo không có ở list Master !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }

            #endregion


            #region  //Sai Programe type
            List<string> listprogr = new List<string>();
            listprogr.Add("FRE");
            listprogr.Add("POS");
            //     listprogr.Add("DASANI");

            var mlist14 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Username == username && !listprogr.Contains(p.Programe)
                          select p;
            if (mlist14.Count() > 0)
            {
                foreach (var item in mlist14)
                {
                    item.StatusNote = "Contract type sai ! hiện chỉ có 2 loại FRE và POS ";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion


            #region  //Sai PayControl 
            List<string> payctrlist = new List<string>();
            payctrlist.Add("C00");
            payctrlist.Add("C01");
            //     listprogr.Add("DASANI");

            var mlist15 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Username == username && !payctrlist.Contains(p.PayControl)
                          select p;
            if (mlist15.Count() > 0)
            {
                foreach (var item in mlist15)
                {
                    item.StatusNote = "PayControl sai ! hiện chỉ support loại C00 và C01 ";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion




            #region //Description thiếu
            var mlist16 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Description.Trim() == ""
                          where p.Username == username //&& !(from dp in dc.tbl_kaChannels

                          //   select dp.Channel).Contains(p.Channel)
                          select p;
            if (mlist16.Count() > 0)
            {
                foreach (var item in mlist16)
                {
                    item.StatusNote = "Cột Description thiếu thông tin, please check !";
                    dc.SubmitChanges();
                }

                checkberore = false;
            }


            #endregion


            #region   //PrdGrp sai
            var dlist17 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Username == username && !(from dp in dc.tbl_kaPrdgrps

                                                            select dp.PrdGrp).Contains(p.PrdGrp)
                          select p;
            if (dlist17.Count() > 0)
            {
                foreach (var item in dlist17)
                {
                    item.StatusNote = "PrdGrp code không có trong list prodgrp list !";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion


            //Sponsored Amount thiếu

            #region    // Eff From  >   Eff To nếu có
            var dlist18 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Username == username
                          && p.EffFrom > p.EffTo
                          && p.EffFrom != null
                          && p.EffTo != null
                          select p;
            if (dlist18.Count() > 0)
            {
                foreach (var item in dlist18)
                {
                    item.StatusNote = "Eff From  >   Eff, please check  !";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion



            #region    // check c00 > 20 trieu
            var dlist133 = from p in dc.tbl_tempcontractsdatadetails
                           where p.Username == username
                           && p.PayControl == "C00"
                           && p.Sponsored_Amount >= 20000000
                           select p;
            if (dlist133.Count() > 0)
            {
                foreach (var item in dlist133)
                {


                    #region check




                    //if (newdetailContract.SponsoredAmt >= 20000000 && this.cb_contracttype.SelectedItem.ToString() == "ASMPQ")
                    //{

                    DialogResult surekq = MessageBox.Show("Bạn có chắc tài trợ tiền mặt lớn hơn 20 000 000 VNĐ ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    switch (surekq)
                    {

                        case DialogResult.None:
                            break;
                        case DialogResult.Yes:


                            break;
                        case DialogResult.Cancel:
                            break;
                        case DialogResult.Abort:
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.OK:
                            break;
                        case DialogResult.No:

                            //    tbl_kacontractsdatadetaillist = null;
                            //    newcontract = null;
                            //    checkcontract = false;
                            //  return;

                            item.StatusNote = "C00 trả lớn hơn 20 triệu chưa chắc chắn !";
                            dc.SubmitChanges();

                            checkberore = false;




                            break;
                        default:
                            break;
                    }




                    //     }
                    #endregion check




                }


            }

            #endregion



            #region    // udate nếu thiếu detail date
            var dlist20 = from p in dc.tbl_tempcontractsdatadetails
                          where p.Username == username
                          && p.EffFrom == null
                          || p.EffTo == null
                          select p;
            if (dlist20.Count() > 0)
            {
                foreach (var item in dlist20)
                {

                    var fromdate = (from p in dc.tbl_tempmastercontractmasscreates
                                    where p.Username == username
                                    && p.ContractNo == item.ContractNo
                                    select p.EfFromDate).First();

                    var todate = (from p in dc.tbl_tempmastercontractmasscreates
                                  where p.Username == username
                                  && p.ContractNo == item.ContractNo
                                  select p.EftoDate).First();


                    item.EffFrom = fromdate;
                    item.EffTo = todate;

                    dc.SubmitChanges();
                }
                // checkberore = false;

            }

            #endregion

            #region    // udate nếu thiếu detail date của điều khoản C01
            var dlist201 = from p in dc.tbl_tempcontractsdatadetails
                           where p.Username == username
                           && p.PayControl == "C01"
                           && p.Paydate == null

                           select p;
            if (dlist201.Count() > 0)
            {
                foreach (var item in dlist201)
                {
                    item.StatusNote = "Paydate must bu update, please check  !";
                    dc.SubmitChanges();
                }
                checkberore = false;

            }

            #endregion


            #region    // nếu thiếu code fs thì tạo code mới

            if (checkberore == true)
            {



                var mlist25 = from p in dc.tbl_tempmastercontractmasscreates
                              where p.Username == username
                              && p.Customer == null
                              select p;
                if (mlist25.Count() > 0)
                {
                    foreach (var item in mlist25)
                    {
                        //  item.StatusNote = "ContractNo có contract Channel sai!";
                        tbl_KaCustomer newcUST = new tbl_KaCustomer();

                        var rs1 = (from tbl_KaCustomer in dc.tbl_KaCustomers
                                   where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SFAcode == true
                                       && tbl_KaCustomer.Customer != null
                                   select tbl_KaCustomer.Customer).FirstOrDefault();

                        if (rs1 == null)
                        {
                            rs1 = 13000000;
                        }
                        // double rs1 = 13000000;
                        Boolean kq = true;
                        do
                        {
                            rs1 = rs1 + 1;

                            var rs2 = from tbl_KaCustomer in dc.tbl_KaCustomers
                                      where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SFAcode == true && tbl_KaCustomer.Customer == rs1
                                      select tbl_KaCustomer.Customer;

                            //    MessageBox.Show("rs2" +  rs2.Count(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);





                            if (rs2.Count() == 0)
                            {
                                kq = false;
                            }
                            rs2 = null;

                        } while (kq);


                        newcUST.Customer = rs1;

                        newcUST.SFAcode = true;
                        newcUST.SapCode = false;
                        newcUST.indirectCode = true;
                        newcUST.SALORG_CTR = Utils.getfirstusersalescontrolregion();
                        newcUST.VATregistrationNo = item.VATregistrationNo;
                        newcUST.CreatedOn = DateTime.Today;
                        newcUST.Createdby = Utils.getusername();

                        newcUST.City = item.Province;// txt_provicen.Text;
                        newcUST.District = item.District;//.Text;
                        newcUST.FullNameN = item.Fullname;//.Text;
                        newcUST.Representative = item.Representative;//.Text;
                        newcUST.Street = item.HouseNo;//.Text;
                        item.Customer = rs1;
                        dc.SubmitChanges();

                        dc.tbl_KaCustomers.InsertOnSubmit(newcUST);
                        dc.SubmitChanges();
                    }


                }




            }


            #endregion    // tạo code mới cho mục thiếu code ỏ master





            var listupdate2 = from p in dc.tbl_tempcontractsdatadetails
                              where p.Username == username
                              select p;

            GridViewdetail.DataSource = listupdate2;


            var listupdate1 = from p in dc.tbl_tempmastercontractmasscreates
                              where p.Username == username
                              select p;

            gridviewmasspayment.DataSource = listupdate1;
            #endregion


            #region  // taok mới contract



            if (checkberore == true)
            {

                // master
                var dsmastercontract = from p in dc.tbl_tempmastercontractmasscreates
                                       where p.Username == username
                                       select p;

                if (dsmastercontract.Count() > 0)
                {

                    foreach (var item in dsmastercontract)
                    {
                        tbl_kacontractdata newcontract = new tbl_kacontractdata();

                        newcontract.Customer = (double)item.Customer;//
                        newcontract.CustomerType = "SFA";
                        newcontract.Channel = item.Channel;
                        newcontract.Consts = "CRT";
                        newcontract.ContractNo = item.ContractNo;
                        newcontract.ConType = item.ConType;
                        newcontract.Currency = "VND";
                        newcontract.Representative = item.Representative;
                        newcontract.Fullname = item.Fullname;
                        newcontract.CreditLimit = item.CreditLimit;
                        newcontract.CreditTerm = item.CreditTerm;
                        newcontract.DeliveredBy = item.DeliveredBy;
                        newcontract.SalesOrg = item.SalesOrg;
                        newcontract.VolComm = item.VolCommitment;
                        newcontract.NSRComm = item.NSRCommitment;
                        newcontract.ConTerm = (-item.EfFromDate.Value.Year + item.EftoDate.Value.Year + 1);
                        newcontract.AnnualVolume = item.VolCommitment / (-item.EfFromDate.Value.Year + item.EftoDate.Value.Year + 1);
                        newcontract.District = item.District;
                        newcontract.Province = item.Province;
                        newcontract.HouseNo = item.HouseNo;
                        newcontract.VATregistrationNo = item.VATregistrationNo;
                        newcontract.CRDUSR = username;
                        newcontract.SignOn = item.EfFromDate;
                        newcontract.CRDDAT = DateTime.Today;
                        newcontract.Remarks = item.Remark;
                        newcontract.EffDate = item.EfFromDate;//  this.dateTimePicker1.Value;
                        newcontract.EftDate = item.EftoDate;// this.dateTimePicker2.Value;
                        newcontract.ExtDate = item.ExtendDate; // this.dateTimePicker3.Value;
                        newcontract.SALORG_CTR = Utils.getfirstusersalescontrolregion();

                        dc.tbl_kacontractdatas.InsertOnSubmit(newcontract);
                        dc.SubmitChanges();


                        var listdetail = from p in dc.tbl_tempcontractsdatadetails
                                         where p.Username == username
                                         && p.ContractNo == item.ContractNo
                                         select p;

                        if (listdetail.Count() > 0)
                        {
                            List<tbl_kacontractsdatadetail> tbl_kacontractsdatadetaillist = new List<tbl_kacontractsdatadetail>();
                            foreach (var item2 in listdetail)
                            {
                                tbl_kacontractsdatadetail newdetailContract = new tbl_kacontractsdatadetail();

                                newdetailContract.Customercode = item.Customer;
                                newdetailContract.PayType = item2.Programe;
                                newdetailContract.CustomerType = "SFA";
                                newdetailContract.Description = item2.PayControl.Trim() + " : " + (from p in dc.tbl_Kafuctionlists
                                                                                                   where p.Code == item2.PayControl
                                                                                                   select p.Description.Trim()).FirstOrDefault(); //Description pay control
                                newdetailContract.PayControl = item2.PayControl;
                                newdetailContract.CommittedDate = item2.Paydate;

                                newdetailContract.Remark = item2.Description; // Description contract

                                newdetailContract.PrdGrp = item2.PrdGrp;
                                newdetailContract.ContractNo = item2.ContractNo;
                                newdetailContract.VATregistrationNo = item.VATregistrationNo;
                                newdetailContract.SponsoredAmt = item2.Sponsored_Amount;
                                newdetailContract.EffFrm = item2.EffFrom;
                                newdetailContract.EffTo = item2.EffTo;

                                newdetailContract.SALORG_CTR = Utils.getfirstusersalescontrolregion();
                                newdetailContract.SalesOrg = item.SalesOrg;
                                newdetailContract.Constatus = "CRT";
                                newdetailContract.Fullname = item.Fullname;
                                newdetailContract.ConType = item.ConType;
                                newdetailContract.Address = item.HouseNo.Trim() + " " + item.District.Trim() + " " + item.Province.Trim();


                                newdetailContract.CRDDAT = DateTime.Today;
                                newdetailContract.CRDUSR = Utils.getusername();

                                tbl_kacontractsdatadetaillist.Add(newdetailContract);





                            }
                            dc.tbl_kacontractsdatadetails.InsertAllOnSubmit(tbl_kacontractsdatadetaillist);
                            dc.SubmitChanges();

                        }






                    }

                }


                // detail






                MessageBox.Show("Mass contract create done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var listupdate1 = from p in dc.tbl_tempmastercontractmasscreates
                              where p.Username == username
                              select p;

            ctrex.exportExceldatagridtofile(listupdate1, dc, "DANH SÁCH HỢP ĐỒNG ");
        }
    }
}
