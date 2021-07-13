using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class kareportsform : Form
    {
        public kareportsform()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;

                var rs = from tbl_kasale in dc.tbl_kasales
                         where tbl_kasale.Priod == priod
                         group tbl_kasale by new
                         {
                             tbl_kasale.Sold_to,
                             tbl_kasale.Sales_Org

                         }
                             into g
                             select new
                             {
                                 Priod = g.Select(gg => gg.Priod).FirstOrDefault(),
                                 Region = g.Key.Sales_Org,
                                 Sold_to = g.Key.Sold_to,
                                 Name = g.Select(gg => gg.Cust_Name).FirstOrDefault(),
                                 PCs = g.Sum(gg => gg.EC).GetValueOrDefault(0),
                                 EC = Math.Ceiling(g.Sum(gg => gg.PC).GetValueOrDefault(0)),
                                 UC = Math.Ceiling(g.Sum(gg => gg.UC).GetValueOrDefault(0)),
                                 Litter = Math.Ceiling(g.Sum(gg => gg.Litter).GetValueOrDefault(0)),
                                 NSR = Math.Ceiling(g.Sum(gg => gg.NSR).GetValueOrDefault(0)),
                                 GSR = Math.Ceiling(g.Sum(gg => gg.GSR).GetValueOrDefault(0)),



                             };

                Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 2);// view code 1 la can viet them lenh

                viewtbl.Show();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var typeffmain = typeof(tbl_KaCustomer);

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_KaCustomer in dc.tbl_KaCustomers


                             select tbl_KaCustomer;
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST CUSTOMER DATA", 3);// view code 1 la can viet them lenh

            viewtbl.Show();



        }
        class dateacrrual
        {

            public DateTime Accrualdate { get; set; }

        }

        public void Accrualmake(object Objdateacrrual)
        {
            dateacrrual dat = (dateacrrual)Objdateacrrual;

            DateTime Accrualdate = dat.Accrualdate;




            Control.Control_ac.AccrualContractinSQL(Accrualdate);


        }



        private void button6_Click(object sender, EventArgs e)
        {

            //   DateTime Accrualdate = DateTime.Today;
            View.Datepick kaPriodpicker = new View.Datepick("Choose Accrualdate Date");

            //   Datepick
            kaPriodpicker.ShowDialog();
            DateTime Accrualdate = kaPriodpicker.accrualdate;
            bool chon1 = kaPriodpicker.chon;

            if (chon1 == true)
            {





                Thread t1 = new Thread(Accrualmake);
                t1.IsBackground = true;
                t1.Start(new dateacrrual() { Accrualdate = Accrualdate });


                Thread t2 = new Thread(Control.Control_ac.showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {


                    Thread.Sleep(999);
                    t2.Abort();




                }





                /// ----test





                // tính accrual xong thì 


                string connection_string = Utils.getConnectionstr();
                string username = Utils.getusername();

                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);





                var regioncode = (from tbl_Temp in db.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();

                var rs = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                         where (from Tka_RegionRight in db.Tka_RegionRights
                                where Tka_RegionRight.RegionCode == regioncode
                                select Tka_RegionRight.Region
                                ).Contains(tbl_kacontractsdatadetail.SalesOrg) && tbl_kacontractsdatadetail.Constatus == "ALV"
                         select new
                         {

                             ContractNo = tbl_kacontractsdatadetail.ContractNo,
                             Region = tbl_kacontractsdatadetail.SalesOrg,

                             Constatus = tbl_kacontractsdatadetail.Constatus,
                             Contracttype = tbl_kacontractsdatadetail.ConType,
                             EffFrm = tbl_kacontractsdatadetail.EffFrm,

                             EffTo = tbl_kacontractsdatadetail.EffTo,
                             CustomerCode = tbl_kacontractsdatadetail.Customercode,
                             EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                             CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                             PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                             UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                             LitAched = tbl_kacontractsdatadetail.LitAched,
                             FTNAched = tbl_kacontractsdatadetail.ECAched,
                             NSRAched = tbl_kacontractsdatadetail.NSRAched,
                             AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                             PayControl = tbl_kacontractsdatadetail.PayControl,
                             Description = tbl_kacontractsdatadetail.Description,
                             PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                             FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                             SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                             AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                             FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                             CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                             TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                             Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                         };


                View.KAcontractlisting KAcontractlisting = new View.KAcontractlisting(rs, db, "Accrual reports detail");


                KAcontractlisting.Show();


            }
            ///-------test thread\\



        }

        private void button5_Click(object sender, EventArgs e)
        {




            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_kaProductlist in dc.tbl_kaProductlists


                             select tbl_kaProductlist;
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRODUCTS DATA", 3);// view code 1 la can viet them lenh

            viewtbl.Show();






        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_kacontractdata in dc.tbl_kacontractdatas
                             where tbl_kacontractdata.Consts == "ALV"


                             select new
                             {
                                 tbl_kacontractdata.ContractNo,
                                 tbl_kacontractdata.SalesOrg,
                                 tbl_kacontractdata.ConType,//contract type
                                 tbl_kacontractdata.Consts, //contract status
                                 tbl_kacontractdata.Currency,
                                 Validfrom = tbl_kacontractdata.EffDate,
                                 Validto = tbl_kacontractdata.EftDate,

                                 tbl_kacontractdata.Customer,
                                 tbl_kacontractdata.Fullname,
                                 tbl_kacontractdata.Channel,
                                 FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                 AchivedCommitment = tbl_kacontractdata.TotDeal,
                                 tbl_kacontractdata.Tot_paid,
                                 Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                                 VolumeCommit = tbl_kacontractdata.VolComm,
                                 tbl_kacontractdata.PCVolAched,
                                 tbl_kacontractdata.NSRAched,
                                 tbl_kacontractdata.UCVolAched,
                                 tbl_kacontractdata.CRDDAT,
                                 tbl_kacontractdata.CRDUSR,



                             };


            //Utils ut = new Utils();
            //dt = ut.ToDataTable(db, rs);
            //this.rs = rs;
            //this.dataGridView1.DataSource = dt;

            ////    tbl_kacontractdata t = new tbl_kacontractdata();

            //#region  format
            ////                  tbl_kacontractdata.ContractNo,
            ////                           tbl_kacontractdata.SalesOrg,
            ////                           tbl_kacontractdata.ConType,//contract type
            ////                           tbl_kacontractdata.Consts, //contract status
            ////                           tbl_kacontractdata.Currency,
            ////                           Validfrom = tbl_kacontractdata.EffDate,
            ////                           Validto = tbl_kacontractdata.EftDate,

            ////                           tbl_kacontractdata.Customer,
            ////                           tbl_kacontractdata.Fullname,
            ////                           tbl_kacontractdata.Channel,
            ////                           FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
            //this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            ////                           AchivedCommitment = tbl_kacontractdata.TotDeal,
            //this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["AchivedCommitment"].HeaderText = "Achived Commitment";

            ////                           tbl_kacontractdata.Tot_paid,
            //this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["Tot_paid"].HeaderText = "Total Paid";

            ////                           Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
            //this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                            //       this.dataGridView1.Columns["Balance"].HeaderText = "Total Paid";
            //                                                                                                            //                           VolumeCommit = tbl_kacontractdata.VolComm,
            //this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["VolumeCommit"].HeaderText = "Volume Commit";

            ////                           tbl_kacontractdata.PCVolAched,
            //this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["PCVolAched"].HeaderText = "PC VolAched";

            ////                           tbl_kacontractdata.NSRAched,
            //this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["NSRAched"].HeaderText = "NSR Ached";


            ////                           tbl_kacontractdata.UCVolAched,
            //this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridView1.Columns["UCVolAched"].HeaderText = "UC VolAched";

            ////                           tbl_kacontractdata.CRDDAT,
            ////                           tbl_kacontractdata.CRDUSR,



            //#endregion

            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List Contracts  Master Alive ", 5);// view code 1 la can viet them lenh

            viewtbl.Show();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.Constatus == "ALV"

                             select new
                             {

                                 ContractNo = tbl_kacontractsdatadetail.ContractNo,
                                 Region = tbl_kacontractsdatadetail.SalesOrg,

                                 Constatus = tbl_kacontractsdatadetail.Constatus,
                                 Contracttype = tbl_kacontractsdatadetail.ConType,
                                 EffFrm = tbl_kacontractsdatadetail.EffFrm,

                                 EffTo = tbl_kacontractsdatadetail.EffTo,
                                 CustomerCode = tbl_kacontractsdatadetail.Customercode,
                                 CustomerName = tbl_kacontractsdatadetail.Fullname,
                                 EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                                 CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                                 PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                                 UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                                 LitAched = tbl_kacontractsdatadetail.LitAched,
                                 FTNAched = tbl_kacontractsdatadetail.ECAched,
                                 NSRAched = tbl_kacontractsdatadetail.NSRAched,
                                 AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                                 PayControl = tbl_kacontractsdatadetail.PayControl,
                                 Description = tbl_kacontractsdatadetail.Description,
                                 PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                                 FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                                 SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                                 AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                                 FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                                 CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                                 TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                                 Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                             };

            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List Contracts Detail Alive", 4);// view code 1 la can viet them lenh

            viewtbl.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_kacontractdata in dc.tbl_kacontractdatas
                             where (tbl_kacontractdata.EftDate - DateTime.Today).Value.Days / 30 <= 1 && tbl_kacontractdata.Consts == "ALV"



                             select new
                             {
                                 tbl_kacontractdata.ContractNo,
                                 tbl_kacontractdata.SalesOrg,
                                 tbl_kacontractdata.ConType,//contract type
                                 tbl_kacontractdata.Consts, //contract status
                                 tbl_kacontractdata.Currency,
                                 Validfrom = tbl_kacontractdata.EffDate,
                                 Validto = tbl_kacontractdata.EftDate,

                                 tbl_kacontractdata.Customer,
                                 tbl_kacontractdata.Fullname,
                                 tbl_kacontractdata.Channel,
                                 FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                 AchivedCommitment = tbl_kacontractdata.TotDeal,
                                 tbl_kacontractdata.Tot_paid,
                                 Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                                 VolumeCommit = tbl_kacontractdata.VolComm,
                                 tbl_kacontractdata.PCVolAched,
                                 tbl_kacontractdata.NSRAched,
                                 tbl_kacontractdata.UCVolAched,
                                 tbl_kacontractdata.CRDDAT,
                                 tbl_kacontractdata.CRDUSR,



                             };
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "Contracts Expire Next Month ", 5);// view code 1 la can viet them lenh

            viewtbl.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_kacontractdata in dc.tbl_kacontractdatas
                             where (tbl_kacontractdata.EftDate - DateTime.Today).Value.Days / 30 <= 3 && tbl_kacontractdata.Consts == "ALV"



                             select new
                             {
                                 tbl_kacontractdata.ContractNo,
                                 tbl_kacontractdata.SalesOrg,
                                 tbl_kacontractdata.ConType,//contract type
                                 tbl_kacontractdata.Consts, //contract status
                                 tbl_kacontractdata.Currency,
                                 Validfrom = tbl_kacontractdata.EffDate,
                                 Validto = tbl_kacontractdata.EftDate,

                                 tbl_kacontractdata.Customer,
                                 tbl_kacontractdata.Fullname,
                                 tbl_kacontractdata.Channel,
                                 FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                 AchivedCommitment = tbl_kacontractdata.TotDeal,
                                 tbl_kacontractdata.Tot_paid,
                                 Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                                 VolumeCommit = tbl_kacontractdata.VolComm,
                                 tbl_kacontractdata.PCVolAched,
                                 tbl_kacontractdata.NSRAched,
                                 tbl_kacontractdata.UCVolAched,
                                 tbl_kacontractdata.CRDDAT,
                                 tbl_kacontractdata.CRDUSR,



                             };
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "Contracts Expire Next 3 Months ", 5);// view code 1 la can viet them lenh

            viewtbl.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();
            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();

            var liveandinregion = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                  where tbl_kacontractdata.Consts == "ALV"
                                  && (from Tka_RegionRight in dc.Tka_RegionRights
                                      where Tka_RegionRight.RegionCode == regioncode
                                      select Tka_RegionRight.Region
                              ).Contains(tbl_kacontractdata.SalesOrg)
                                  select tbl_kacontractdata.ContractNo;



            var rscustemp2 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                             where tbl_kacontractsdetailpayment.PayControl == "REQ"
                             && liveandinregion.Contains(tbl_kacontractsdetailpayment.ContractNo)

                             select new
                             {
                                 tbl_kacontractsdetailpayment.ContractNo,

                                 tbl_kacontractsdetailpayment.BatchNo,
                                 ContracName = tbl_kacontractsdetailpayment.ContracName.Trim(),
                                 tbl_kacontractsdetailpayment.PayType,
                                 tbl_kacontractsdetailpayment.PayID,
                                 Description = tbl_kacontractsdetailpayment.Description.Trim(),
                                 tbl_kacontractsdetailpayment.PaidRequestAmt,
                                 tbl_kacontractsdetailpayment.PayControl,
                                 tbl_kacontractsdetailpayment.PrintDate,
                                 Remark = tbl_kacontractsdetailpayment.Remark.Trim(),

                                 tbl_kacontractsdetailpayment.CRDDAT,
                                 tbl_kacontractsdetailpayment.CRDUSR,
                                 tbl_kacontractsdetailpayment.SubID,

                             };
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PAYMENT REQUEST FOR APPROVAL", 3);// view code 1 la can viet them lenh

            viewtbl.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);
            var regioncode = (from tbl_Temp in da.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();




            var rscustemp2 = from tbl_kacontractsdatadetail in da.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.SponsoredTotal > tbl_kacontractsdatadetail.PaidAmt
                              && (from Tka_RegionRight in da.Tka_RegionRights
                                  where Tka_RegionRight.RegionCode == regioncode
                                  select Tka_RegionRight.Region
                              ).Contains(tbl_kacontractsdatadetail.SalesOrg)

                             select new
                             {
                                 tbl_kacontractsdatadetail.SalesOrg,
                                 tbl_kacontractsdatadetail.CommittedDate,
                                 tbl_kacontractsdatadetail.ContractNo,
                                 tbl_kacontractsdatadetail.ConType,
                                 tbl_kacontractsdatadetail.Constatus,
                                 tbl_kacontractsdatadetail.Customercode,
                                 tbl_kacontractsdatadetail.Fullname,
                                 tbl_kacontractsdatadetail.Address,

                                 tbl_kacontractsdatadetail.PayType,
                                 tbl_kacontractsdatadetail.PayControl,
                                 tbl_kacontractsdatadetail.Description,

                                 Achived = tbl_kacontractsdatadetail.SponsoredTotal,
                                 Paid = tbl_kacontractsdatadetail.PaidAmt,
                                 Unpaid = tbl_kacontractsdatadetail.SponsoredTotal - tbl_kacontractsdatadetail.PaidAmt,

                                 tbl_kacontractsdatadetail.EffFrm,
                                 tbl_kacontractsdatadetail.EffTo,
                                 tbl_kacontractsdatadetail.Remark,


                             };
            Viewtable viewtbl = new Viewtable(rscustemp2, da, "List Detail Unpaid reports", 33);// view code 1 la can viet them lenh

            viewtbl.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //var q4 = from tblFBL5N in dc.tblFBL5Ns
            //         from tblFBL5Nnew in dc.tblFBL5Nnews
            //         where (tblFBL5N.Document_Number == tblFBL5Nnew.Document_Number)
            //         select tblFBL5N;

            //var q = from tblVat in dc.tblVats
            //        where !(from tblFBL5N in dc.tblFBL5Ns
            //                select tblFBL5N.Document_Number).Contains(tblVat.SAP_Invoice_Number)
            //        //Tương đương từ khóa NOT IN trong SQL
            //        select tblVat;
            var regioncode = (from tbl_Temp in db.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();

            var rs = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                     where (from Tka_RegionRight in db.Tka_RegionRights
                            where Tka_RegionRight.RegionCode == regioncode
                            select Tka_RegionRight.Region
                            ).Contains(tbl_kacontractsdatadetail.SalesOrg) && tbl_kacontractsdatadetail.Constatus == "ALV"
                     select new
                     {

                         ContractNo = tbl_kacontractsdatadetail.ContractNo,
                         Region = tbl_kacontractsdatadetail.SalesOrg,

                         Constatus = tbl_kacontractsdatadetail.Constatus,
                         Contracttype = tbl_kacontractsdatadetail.ConType,
                         EffFrm = tbl_kacontractsdatadetail.EffFrm,

                         EffTo = tbl_kacontractsdatadetail.EffTo,
                         CustomerCode = tbl_kacontractsdatadetail.Customercode,
                         EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                         CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                         PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                         UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                         LitAched = tbl_kacontractsdatadetail.LitAched,
                         FTNAched = tbl_kacontractsdatadetail.ECAched,
                         NSRAched = tbl_kacontractsdatadetail.NSRAched,
                         AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                         PayControl = tbl_kacontractsdatadetail.PayControl,
                         Description = tbl_kacontractsdatadetail.Description,
                         PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                         FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                         SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                         AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                         FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                         CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                         TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                         Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                     };


            View.KAcontractlisting KAcontractlisting = new View.KAcontractlisting(rs, db, "Accrual reports detail");


            KAcontractlisting.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();



            #region update lai groupcode
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateCustGrcode", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






            LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);
            var regioncode = (from tbl_Temp in da.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();




            var rscustemp2 = from tbl_kacontractdata in da.tbl_kacontractdatas
                             where (from Tka_RegionRight in da.Tka_RegionRights
                                    where Tka_RegionRight.RegionCode == regioncode
                                    select Tka_RegionRight.Region
                              ).Contains(tbl_kacontractdata.SalesOrg)

                             select new
                             {
                                 tbl_kacontractdata.SalesOrg,
                                 tbl_kacontractdata.ContractNo,
                                 tbl_kacontractdata.ConType,
                                 tbl_kacontractdata.Consts,
                                 tbl_kacontractdata.Channel,
                                 tbl_kacontractdata.Customer,
                                 tbl_kacontractdata.ListCodeinGroup,
                                 tbl_kacontractdata.Fullname,
                                 //tbl_kacontractsdatadetail.Address,

                                 //tbl_kacontractsdatadetail.PayType,
                                 //tbl_kacontractsdatadetail.PayControl,
                                 //tbl_kacontractsdatadetail.Description,

                                 //Achived = tbl_kacontractsdatadetail.SponsoredTotal,
                                 //Paid = tbl_kacontractsdatadetail.PaidAmt,
                                 //Unpaid = tbl_kacontractsdatadetail.SponsoredTotal - tbl_kacontractsdatadetail.PaidAmt,

                                 //tbl_kacontractsdatadetail.EffFrm,
                                 //tbl_kacontractsdatadetail.EffTo,
                                 //tbl_kacontractsdatadetail.Remark,


                             };
            Viewtable viewtbl = new Viewtable(rscustemp2, da, "CONTRACTS WITH GROUP CODE", 555);// view code 1 la can viet them lenh

            viewtbl.Show();




        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //    UpdateControlTypeforPaymentrpt


            #region    ClearABbelanceZezoinFbl5n

            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;
            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateControlTypeforPaymentrpt", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





            #endregion




            string username = Utils.getusername();


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "Fromdate to Date Select")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.KafromtoSelect kafromto = new View.KafromtoSelect();

                kafromto.ShowDialog();
                DateTime fromdate = kafromto.fromdate;
                DateTime todate = kafromto.todate;




                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();

                var liveandinregion = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                      where (from Tka_RegionRight in dc.Tka_RegionRights
                                             where Tka_RegionRight.RegionCode == regioncode
                                             select Tka_RegionRight.Region
                                  ).Contains(tbl_kacontractdata.SalesOrg)
                                      select tbl_kacontractdata.ContractNo;



                var rscustemp2 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                 from tbl_kacontractdata in dc.tbl_kacontractdatas
                                 where liveandinregion.Contains(tbl_kacontractsdetailpayment.ContractNo)
                               && tbl_kacontractsdetailpayment.ContractNo == tbl_kacontractdata.ContractNo
                               && tbl_kacontractsdetailpayment.PaidOn >= fromdate
                                   && tbl_kacontractsdetailpayment.PaidOn <= todate

                                 select new
                                 {
                                     tbl_kacontractsdetailpayment.ContractNo,
                                     Contract_status = tbl_kacontractdata.Consts,
                                     Contract_Type = tbl_kacontractdata.ConType,
                                     tbl_kacontractsdetailpayment.BatchNo,
                                     ContracName = tbl_kacontractsdetailpayment.ContracName.Trim(),
                                     tbl_kacontractsdetailpayment.PayType,
                                     tbl_kacontractsdetailpayment.PayID,
                                     Description = tbl_kacontractsdetailpayment.Description.Trim(),
                                     tbl_kacontractsdetailpayment.PaidRequestAmt,
                                     tbl_kacontractsdetailpayment.PayControl,
                                     tbl_kacontractsdetailpayment.ControlType,

                                     tbl_kacontractsdetailpayment.PrintDate,
                                     Remark = tbl_kacontractsdetailpayment.Remark.Trim(),

                                     tbl_kacontractsdetailpayment.CRDDAT,
                                     tbl_kacontractsdetailpayment.CRDUSR,
                                     tbl_kacontractsdetailpayment.SubID,

                                 };
                Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST ALL PAYMENT FROM DATE TO DATE", 3);// view code 1 la can viet them lenh

                viewtbl.Show();




            }










        }
    }
}
