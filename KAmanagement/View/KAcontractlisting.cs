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
    public partial class KAcontractlisting : Form
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


        public IQueryable rs;
        LinqtoSQLDataContext db;
        public DataGridView Dtgridview;
        public List<ComboboxItem> dataCollectionaccount;

        public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
                                                      //1. Định nghĩa 1 delegate


        class datatoExport
        {
            public DataGridView dataGrid1 { get; set; }

        }

        public KAcontractlisting(IQueryable rs, LinqtoSQLDataContext db, string fornname)
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            filterlabel.Visible = false;
            cbcontracttypefil.Visible = false;
            this.db = db;

            this.rs = rs;


            if (fornname == "Payment Input")
            {

                tbmasscreatecontract.Visible = false;
                btmassconfirm.Visible = false;
                btmasschange.Visible = false;

            }

            if (fornname == "Accrual reports detail")
            {

                button1.Visible = false;
                Bt_Adddata.Visible = false;
                label1.Text = "                                                        F7: Detail list     F8: Master list";

            }
            this.dataGridView1.DataSource = rs;
            if (this.dataGridView1.Columns["ContractNo"] != null)
            {
                this.dataGridView1.Columns["ContractNo"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                this.dataGridView1.Columns["ContractNo"].DefaultCellStyle.BackColor = Color.LightYellow;


            }


            this.formname.Text = fornname;
            if ((fornname == "Input Contract" || fornname == "Payment Input") && statusview.Text == "Master")
            {

                Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);



            }

            if ((fornname == "Input Contract" || fornname == "Payment Input") && statusview.Text == "Master")
            {

                filterlabel.Visible = true;
                cbcontracttypefil.Visible = true;

                string username = Utils.getusername();

                var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                                   where Tka_RightContracttypeview.UserName == username
                                   select Tka_RightContracttypeview.Contracttype;


                this.cbcontracttypefil.Items.Clear();

                foreach (var item in typecontract)
                {
                    cbcontracttypefil.Items.Add(item);
                }

            }

            if (fornname == "Accrual reports detail")
            {

                #region formta detail accrual


                //   ContractNo = tbl_kacontractsdatadetail.ContractNo,
                //             Region = tbl_kacontractsdatadetail.SalesOrg,

                //             Constatus = tbl_kacontractsdatadetail.Constatus,
                //             Contracttype = tbl_kacontractsdatadetail.ConType,
                this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["Contracttype"].HeaderText = "Contract Type";
                //             EffFrm = tbl_kacontractsdatadetail.EffFrm,

                //             EffTo = tbl_kacontractsdatadetail.EffTo,
                //             CustomerCode = tbl_kacontractsdatadetail.Customercode,
                this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                //             EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                //             CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                //             PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                               //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                                                                                                                               //             UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                               //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                                                                                                                               //             LitAched = tbl_kacontractsdatadetail.LitAched,
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //             FTNAched = tbl_kacontractsdatadetail.ECAched,
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //             NSRAched = tbl_kacontractsdatadetail.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //             AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //             PayControl = tbl_kacontractsdatadetail.PayControl,
                //             Description = tbl_kacontractsdatadetail.Description,
                //             PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                //             FundPercentage = tbl_kacontractsdatadetail.FundPercentage,

                //             SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //             AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                //             FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns["FullCommitment"].HeaderText = "SponsoredAmt (Full commitment)";
                //             CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns["CommitmentCurrent"].HeaderText = "Commitment Current";
                //             TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns["TotalPaid"].HeaderText = "Total Paid";
                //             Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns["Balance"].HeaderText = "Balance (to be accrual)";
                #endregion


            }

        }


        void Control_KeyPress(object sender, KeyEventArgs e)
        {

            #region seach input contract


            if ((this.formname.Text == "Input Contract" || this.formname.Text == "Payment Input") && e.KeyCode == Keys.F3)
            {


                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "KASeachcontract")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    KASeachcontract sheaching = new KASeachcontract(this, "KASeachcontract");
                    sheaching.Show();
                }






            }
            #endregion


            #region  hiện màn hình inputnew contract và payment

            if (this.formname.Text == "Input Contract" && e.KeyCode == Keys.F6)
            {
                CreatenewContract newcontrac = new CreatenewContract("CREATING NEW CONTRACT", "");
                newcontrac.Text = "Input Contract";
                newcontrac.ShowDialog();
                //  newcontrac.BringToFront();
                newcontrac.Focus();
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



                //string username = Utils.getusername();



                //var regioncode = (from tbl_Temp in db.tbl_Temps
                //                  where tbl_Temp.username == username
                //                  select tbl_Temp.RegionCode).FirstOrDefault();

                var rs = Control.Control_ac.getViewcontractMaster(db);



                this.dataGridView1.DataSource = rs;
                Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);

                this.db = db;

                this.rs = rs;

                //  Control.Control_ac.CaculationContractinSQLmaster(ContractNo);
                //tbl_kacontractmasterdata kk = new tbl_kacontractmasterdata();
                //kk.

            }




            #endregion



            //if (e.KeyCode == Keys.F2)
            //{


            //  }

            string username = Utils.getusername();


            var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username
                               select Tka_RightContracttypeview.Contracttype;



            if (e.KeyCode == Keys.F7) // this.formname.Text == "Detail Contract" &&
            {
                ///     string connection_string = Utils.getConnectionstr();
                //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                System.Data.DataTable dt = new System.Data.DataTable();



                if (this.formname.Text == "Accrual reports master")
                {

                    #region


                    this.formname.Text = "Accrual reports detail";

                    //var regioncode = (from tbl_Temp in db.tbl_Temps
                    //                  where tbl_Temp.username == username
                    //                  select tbl_Temp.RegionCode).FirstOrDefault();

                    //var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                    //                   where Tka_RightContracttypeview.UserName == username
                    //                   select Tka_RightContracttypeview.Contracttype;



                    var rsthisperiod = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                                       where (from Tka_RegionRight in db.Tka_RegionRights
                                                  //   where// Tka_RegionRight.RegionCode == regioncode
                                              select Tka_RegionRight.Region
                                              ).Contains(tbl_kacontractsdatadetail.SalesOrg) && tbl_kacontractsdatadetail.Constatus == "ALV"
                                                && typecontract.Contains(tbl_kacontractsdatadetail.ConType)
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
                                           tbl_kacontractsdatadetail.Address,

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
                                           CommitmentCurrent = tbl_kacontractsdatadetail.AccSponsoredTotal,
                                           TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                                           Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                                           tbl_kacontractsdatadetail.VATregistrationNo,


                                       };






                    Utils ut = new Utils();
                    dt = ut.ToDataTable(db, rsthisperiod);
                    //  this.db = db;
                    this.rs = rsthisperiod;
                    this.dataGridView1.DataSource = dt;

                    //     tbl_kacontractsdatadetail tem = new tbl_kacontractsdatadetail();

                    //  if (fornname == "Accrual reports detail")
                    // {
                    //
                    #region formta detail accrual


                    //   ContractNo = tbl_kacontractsdatadetail.ContractNo,
                    dataGridView1.Columns["ContractNo"].DisplayIndex = 0;
                    //             Region = tbl_kacontractsdatadetail.SalesOrg,
                    dataGridView1.Columns["Region"].DisplayIndex = 1;

                    //             Constatus = tbl_kacontractsdatadetail.Constatus,
                    dataGridView1.Columns["Constatus"].DisplayIndex = 2;
                    //             Contracttype = tbl_kacontractsdatadetail.ConType,
                    this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    this.dataGridView1.Columns["Contracttype"].HeaderText = "Contract Type";
                    dataGridView1.Columns["Contracttype"].DisplayIndex = 3;
                    //             EffFrm = tbl_kacontractsdatadetail.EffFrm,
                    dataGridView1.Columns["EffFrm"].DisplayIndex = 4;
                    //             EffTo = tbl_kacontractsdatadetail.EffTo,
                    dataGridView1.Columns["EffTo"].DisplayIndex = 5;
                    //             CustomerCode = tbl_kacontractsdatadetail.Customercode,
                    dataGridView1.Columns["CustomerCode"].DisplayIndex = 6;
                    //           this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";

                    dataGridView1.Columns["CustomerName"].DisplayIndex = 7;
                    //             EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                    dataGridView1.Columns["EftNoOfMonth"].DisplayIndex = 8;
                    //             CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,
                    dataGridView1.Columns["CurrentMonth"].DisplayIndex = 9;
                    //             PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["PCVolAched"].DisplayIndex = 10;
                    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                   //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                                                                                                                                   //             UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["UCVolAched"].DisplayIndex = 11;
                    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                   //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                                                                                                                                   //             LitAched = tbl_kacontractsdatadetail.LitAched,
                    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["LitAched"].DisplayIndex = 12;
                    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //             FTNAched = tbl_kacontractsdatadetail.ECAched,
                    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["FTNAched"].DisplayIndex = 13;
                    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //             NSRAched = tbl_kacontractsdatadetail.NSRAched,
                    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["NSRAched"].DisplayIndex = 14;
                    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //             AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["AccruedAmt"].DisplayIndex = 15;
                    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //             PayControl = tbl_kacontractsdatadetail.PayControl,
                    dataGridView1.Columns["PayControl"].DisplayIndex = 16;
                    //             Description = tbl_kacontractsdatadetail.Description,
                    dataGridView1.Columns["Description"].DisplayIndex = 17;
                    //             PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                    dataGridView1.Columns["PrdGrp"].DisplayIndex = 18;
                    //             FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                    dataGridView1.Columns["FundPercentage"].DisplayIndex = 19;
                    //             SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["SponsoredAmtperPC"].DisplayIndex = 20;
                    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //             AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                    //             FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["FullCommitment"].DisplayIndex = 21;
                    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Columns["FullCommitment"].HeaderText = "SponsoredAmt (Full commitment)";
                    //             CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["CommitmentCurrent"].DisplayIndex = 22;
                    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Columns["CommitmentCurrent"].HeaderText = "Commitment Current";
                    //             TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["TotalPaid"].DisplayIndex = 23;
                    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Columns["TotalPaid"].HeaderText = "Total Paid";
                    //             Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                    dataGridView1.Columns["Balance"].DisplayIndex = 24;
                    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dataGridView1.Columns["Balance"].HeaderText = "Balance (to be accrual)";
                    #endregion


                    //  }



                    #endregion = "Accrual reports master")

                }
                else
                {

                    statusview.Text = "Detail";

                    //(from Tka_RegionRight in db.Tka_RegionRights
                    //     //   where// Tka_RegionRight.RegionCode == regioncode
                    // select Tka_RegionRight.Region
                    //                           ).Contains(tbl_kacontractsdatadetail.SalesOrg) && tbl_kacontractsdatadetail.Constatus == "ALV"
                    //                             && typecontract.Contains(tbl_kacontractsdatadetail.ConType)



                    //var typecontract2 = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                    //                    where Tka_RightContracttypeview.UserName == username
                    //                    select Tka_RightContracttypeview.Contracttype;


                    var rsthisperiod = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                                       where (from Tka_RegionRight in db.Tka_RegionRights

                                              select Tka_RegionRight.Region
                                               ).Contains(tbl_kacontractsdatadetail.SalesOrg) && tbl_kacontractsdatadetail.Constatus == "ALV"
                                                 && typecontract.Contains(tbl_kacontractsdatadetail.ConType)

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
                                           tbl_kacontractsdatadetail.Address,

                                           EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                                           CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                                           PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                                           UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                                           LitAched = tbl_kacontractsdatadetail.LitAched,
                                           FTNAched = tbl_kacontractsdatadetail.ECAched,
                                           NSRAched = tbl_kacontractsdatadetail.NSRAched,
                                           tbl_kacontractsdatadetail.COGS_ached,
                                           AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                                           BegindetailCotractAched = tbl_kacontractsdatadetail.BeginAchvmt,

                                           PayControl = tbl_kacontractsdatadetail.PayControl,
                                           tbl_kacontractsdatadetail.PayType,
                                           Description = tbl_kacontractsdatadetail.Description,
                                           PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                                           FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                                           SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                                           AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                                           FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                                           CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                                           TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                                           Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                                           tbl_kacontractsdatadetail.Remark,
                                           tbl_kacontractsdatadetail.UPDUSR,
                                           tbl_kacontractsdatadetail.UPDDAT,
                                           tbl_kacontractsdatadetail.VATregistrationNo,

                                       };



                    Utils ut = new Utils();
                    dt = ut.ToDataTable(db, rsthisperiod);
                    //    this.db = db;
                    this.rs = rsthisperiod;
                    this.dataGridView1.DataSource = dt;


                    #region format





                    ////ContractNo = tbl_kacontractsdatadetail.ContractNo,
                    //dataGridView1.Columns["ContractNo"].DisplayIndex = 0;
                    ////Region = tbl_kacontractsdatadetail.SalesOrg,
                    //dataGridView1.Columns["Region"].DisplayIndex = 1;
                    ////Constatus = tbl_kacontractsdatadetail.Constatus,
                    //dataGridView1.Columns["Constatus"].DisplayIndex = 2;
                    ////Contracttype = tbl_kacontractsdatadetail.ConType,
                    //dataGridView1.Columns["Contracttype"].DisplayIndex = 3;
                    ////EffFrm = tbl_kacontractsdatadetail.EffFrm,
                    //dataGridView1.Columns["EffFrm"].DisplayIndex = 4;
                    ////EffTo = tbl_kacontractsdatadetail.EffTo,
                    //dataGridView1.Columns["EffTo"].DisplayIndex = 5;
                    ////CustomerCode = tbl_kacontractsdatadetail.Customercode,
                    //dataGridView1.Columns["CustomerCode"].DisplayIndex = 6;

                    ////    CustomerName = tbl_kacontractsdatadetail.Fullname,
                    //dataGridView1.Columns["CustomerName"].DisplayIndex = 7;

                    ////EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                    //dataGridView1.Columns["EftNoOfMonth"].DisplayIndex = 8;
                    ////CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,
                    //dataGridView1.Columns["CurrentMonth"].DisplayIndex = 9;
                    //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                    //     dataGridView1.Columns["PCVolAched"].DisplayIndex = 10;
                    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                   //UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                    //      dataGridView1.Columns["UCVolAched"].DisplayIndex = 11;
                    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    //LitAched = tbl_kacontractsdatadetail.LitAched,
                    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                    //    dataGridView1.Columns["LitAched"].DisplayIndex = 12;
                    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    //FTNAched = tbl_kacontractsdatadetail.ECAched,
                    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                    ///    dataGridView1.Columns["FTNAched"].DisplayIndex = 13;
                    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    //NSRAched = tbl_kacontractsdatadetail.NSRAched,
                    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                    //     dataGridView1.Columns["NSRAched"].DisplayIndex = 14;
                    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                 //AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                    //   dataGridView1.Columns["AccruedAmt"].DisplayIndex = 15;
                    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    // BegindetailAched
                    this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Format = "N0";
                    //   dataGridView1.Columns["AccruedAmt"].DisplayIndex = 15;
                    this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



                    //PayControl = tbl_kacontractsdatadetail.PayControl,
                    //    dataGridView1.Columns["PayControl"].DisplayIndex = 16;

                    //Description = tbl_kacontractsdatadetail.Description,
                    //    dataGridView1.Columns["Description"].DisplayIndex = 17;
                    //PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                    //    dataGridView1.Columns["PrdGrp"].DisplayIndex = 18;
                    //FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                    //   dataGridView1.Columns["FundPercentage"].DisplayIndex = 19;
                    //SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                    //  dataGridView1.Columns["SponsoredAmtperPC"].DisplayIndex = 20;
                    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    //AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                    //      dataGridView1.Columns["AccruedDate"].DisplayIndex = 21;
                    //FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                    //     dataGridView1.Columns["FullCommitment"].DisplayIndex = 22;
                    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                    //CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                          //      dataGridView1.Columns["CommitmentCurrent"].DisplayIndex = 23;
                                                                                                                                          //TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                  //      dataGridView1.Columns["TotalPaid"].DisplayIndex = 24;                                                                                                        //Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                //         dataGridView1.Columns["Balance"].DisplayIndex = 25;


                    #endregion



                }






            }
            if (e.KeyCode == Keys.F8) // this.formname.Text == "Detail Contract" &&
            {
                //    string connection_string = Utils.getConnectionstr();
                //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                if (this.formname.Text == "Accrual reports detail")
                {
                    this.formname.Text = "Accrual reports master";
                }

                statusview.Text = "Master";

                System.Data.DataTable dt = new System.Data.DataTable();

                //   string username = Utils.getusername();

                var regioncode = (from tbl_Temp in db.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();


                //var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                //                   where Tka_RightContracttypeview.UserName == username
                //                   select Tka_RightContracttypeview.Contracttype;


                var rsthisperiod = from tbl_kacontractdata in db.tbl_kacontractdatas
                                   where (from Tka_RegionRight in db.Tka_RegionRights
                                          where Tka_RegionRight.RegionCode == regioncode
                                          select Tka_RegionRight.Region.Trim()
                                          ).Contains(tbl_kacontractdata.SalesOrg.Trim())
                                          && typecontract.Contains(tbl_kacontractdata.ConType)
                                   select new
                                   {
                                       tbl_kacontractdata.ContractNo,
                                       tbl_kacontractdata.SalesOrg,
                                       tbl_kacontractdata.ConType,//contract type
                                       tbl_kacontractdata.Consts, //contract status
                                       tbl_kacontractdata.Currency,
                                       Validfrom = tbl_kacontractdata.EffDate,
                                       Validto = tbl_kacontractdata.EftDate,
                                       extDate = tbl_kacontractdata.ExtDate,

                                       tbl_kacontractdata.Customer,
                                       tbl_kacontractdata.Fullname,
                                       Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
                                       tbl_kacontractdata.Channel,
                                       FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                       AchivedCommitment = tbl_kacontractdata.TotDeal,
                                       tbl_kacontractdata.Tot_paid,
                                       Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                                       VolumeCommit = tbl_kacontractdata.VolComm,
                                       tbl_kacontractdata.NSRComm,

                                       tbl_kacontractdata.PCVolAched,
                                       tbl_kacontractdata.NSRAched,
                                       tbl_kacontractdata.UCVolAched,
                                       tbl_kacontractdata.Revenue,
                                       tbl_kacontractdata.CRDDAT,
                                       tbl_kacontractdata.CRDUSR,
                                       tbl_kacontractdata.Remarks,
                                       tbl_kacontractdata.DeliveredBy,
                                       tbl_kacontractdata.Representative,

                                       tbl_kacontractdata.VATregistrationNo,
                                   };


                Utils ut = new Utils();
                dt = ut.ToDataTable(db, rsthisperiod);
                this.rs = rsthisperiod;
                this.dataGridView1.DataSource = dt;

                //    tbl_kacontractdata t = new tbl_kacontractdata();

                #region  format
                ////                  tbl_kacontractdata.ContractNo,
                //dataGridView1.Columns["ContractNo"].DisplayIndex = 0;
                ////                           tbl_kacontractdata.SalesOrg,
                //dataGridView1.Columns["SalesOrg"].DisplayIndex = 1;
                ////                           tbl_kacontractdata.ConType,//contract type
                //dataGridView1.Columns["ConType"].DisplayIndex = 2;
                ////                           tbl_kacontractdata.Consts, //contract status
                //dataGridView1.Columns["Consts"].DisplayIndex = 3;
                ////                           tbl_kacontractdata.Currency,
                //dataGridView1.Columns["Currency"].DisplayIndex = 4;
                ////                           Validfrom = tbl_kacontractdata.EffDate,
                //dataGridView1.Columns["Validfrom"].DisplayIndex = 5;
                ////                           Validto = tbl_kacontractdata.EftDate,
                //dataGridView1.Columns["Validto"].DisplayIndex = 6;

                ////                           tbl_kacontractdata.Customer,
                //dataGridView1.Columns["Customer"].DisplayIndex = 7;
                ////                           tbl_kacontractdata.Fullname,
                //dataGridView1.Columns["Fullname"].DisplayIndex = 8;
                ////                           tbl_kacontractdata.Channel,
                //dataGridView1.Columns["Channel"].DisplayIndex = 9;
                ////                           FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                //dataGridView1.Columns["FullCommitment"].DisplayIndex = 10;
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //                           AchivedCommitment = tbl_kacontractdata.TotDeal,
                this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
                //     dataGridView1.Columns["AchivedCommitment"].DisplayIndex = 11;
                this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["AchivedCommitment"].HeaderText = "Achived Commitment";

                //                           tbl_kacontractdata.Tot_paid,
                this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
                //        dataGridView1.Columns["Tot_paid"].DisplayIndex = 12;
                this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["Tot_paid"].HeaderText = "Total Paid";

                //                           Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                //    dataGridView1.Columns["Balance"].DisplayIndex = 13;
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                            //       this.dataGridView1.Columns["Balance"].HeaderText = "Total Paid";
                                                                                                                            //                           VolumeCommit = tbl_kacontractdata.VolComm,
                this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
                //     dataGridView1.Columns["VolumeCommit"].DisplayIndex = 14;
                this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["VolumeCommit"].HeaderText = "Volume Commit";

                //                           tbl_kacontractdata.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                //     dataGridView1.Columns["PCVolAched"].DisplayIndex = 15;
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["PCVolAched"].HeaderText = "PC VolAched";

                //                           tbl_kacontractdata.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                //      dataGridView1.Columns["NSRAched"].DisplayIndex = 16;
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["NSRAched"].HeaderText = "NSR Ached";


                //                           tbl_kacontractdata.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["UCVolAched"].HeaderText = "UC VolAched";
                //      dataGridView1.Columns["UCVolAched"].DisplayIndex = 17;

                this.dataGridView1.Columns["Revenue"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                            //      dataGridView1.Columns["Revenue"].DisplayIndex = 18;


                //                           tbl_kacontractdata.CRDDAT,
                //      dataGridView1.Columns["CRDDAT"].DisplayIndex = 19;
                //                           tbl_kacontractdata.CRDUSR,
                //      dataGridView1.Columns["CRDUSR"].DisplayIndex = 20;


                //  tbl_kacontractdata.Revenue,



                #endregion





            }
        }

        public void ReloadKASeachcontract(string code, string contract, string name, string txtvat)
        {
            //    string connection_string = Utils.getConnectionstr();
            //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            System.Data.DataTable dt = new System.Data.DataTable();



            string username = Utils.getusername();

            //var regioncode = (from tbl_Temp in db.tbl_Temps
            //                  where tbl_Temp.username == username
            //                  select tbl_Temp.RegionCode).FirstOrDefault();

            var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username
                               select Tka_RightContracttypeview.Contracttype;

            if (statusview.Text == "Master")
            {
                //    statusview.Text = "Master";


                #region


                var rsthisperiod = from tbl_kacontractdata in db.tbl_kacontractdatas
                                   where (from Tka_RegionRight in db.Tka_RegionRights
                                              //        where Tka_RegionRight.RegionCode == regioncode
                                          select Tka_RegionRight.Region.Trim()
                                          ).Contains(tbl_kacontractdata.SalesOrg.Trim()) &&
                                          (tbl_kacontractdata.ContractNo).Contains(contract) &&
                                                 ((int)tbl_kacontractdata.Customer).ToString().Contains(code)
                                                 && tbl_kacontractdata.Fullname.Contains(name)
                                                 && tbl_kacontractdata.VATregistrationNo.Contains(txtvat)
                                                 && typecontract.Contains(tbl_kacontractdata.ConType)


                                   select new
                                   {


                                       tbl_kacontractdata.ContractNo,
                                       tbl_kacontractdata.SalesOrg,
                                       tbl_kacontractdata.ConType,//contract type
                                       tbl_kacontractdata.Consts, //contract status
                                       tbl_kacontractdata.Currency,
                                       Validfrom = tbl_kacontractdata.EffDate,
                                       Validto = tbl_kacontractdata.EftDate,
                                       extDate = tbl_kacontractdata.ExtDate,

                                       tbl_kacontractdata.Customer,
                                       tbl_kacontractdata.Fullname,
                                       Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
                                       tbl_kacontractdata.Province,
                                       tbl_kacontractdata.Channel,
                                       FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                       tbl_kacontractdata.PCVolAched,
                                       tbl_kacontractdata.NSRAched,
                                       tbl_kacontractdata.UCVolAched,
                                       tbl_kacontractdata.Revenue,

                                       tbl_kacontractdata.Cash,
                                       tbl_kacontractdata.FreeGood,
                                       tbl_kacontractdata.POS,

                                       tbl_kacontractdata.Promotion,
                                       tbl_kacontractdata.MKTFun,

                                       AchivedCommitment = tbl_kacontractdata.TotDeal,
                                       tbl_kacontractdata.Tot_paid,
                                       tbl_kacontractdata.Cash_paid,
                                       tbl_kacontractdata.FreeGood_paid,
                                       tbl_kacontractdata.POS_paid,

                                       tbl_kacontractdata.Promotion_paid,
                                       tbl_kacontractdata.MKTFun_paid,

                                       Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,

                                       PosBalance = tbl_kacontractdata.POS_Ached - tbl_kacontractdata.POS_paid,

                                       OthersBalance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid - tbl_kacontractdata.POS_Ached + tbl_kacontractdata.POS_paid,
                                       VolumeCommit = tbl_kacontractdata.VolComm,
                                       tbl_kacontractdata.NSRComm,

                                       tbl_kacontractdata.Remarks,
                                       tbl_kacontractdata.DeliveredBy,
                                       tbl_kacontractdata.Representative,
                                       tbl_kacontractdata.VATregistrationNo,
                                       tbl_kacontractdata.CRDDAT,
                                       tbl_kacontractdata.CRDUSR,
                                       //      tbl_kacontractdata.VolComm,




                                   };

                #endregion




                Utils ut = new Utils();

                dt = ut.ToDataTable(db, rsthisperiod);
                this.rs = rsthisperiod;
                this.dataGridView1.DataSource = dt;

                //    tbl_kacontractdata t = new tbl_kacontractdata();
                Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);





            }


            if (statusview.Text == "Detail")
            {
                //    statusview.Text = "Detail";


                #region


                var rsthisperiod = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails

                                   where (from Tka_RegionRight in db.Tka_RegionRights
                                              //              where Tka_RegionRight.RegionCode == regioncode
                                          select Tka_RegionRight.Region.Trim()
                                          ).Contains(tbl_kacontractsdatadetail.SalesOrg.Trim()) &&
                                          (tbl_kacontractsdatadetail.ContractNo).Contains(contract) &&
                                                 ((int)tbl_kacontractsdatadetail.Customercode).ToString().Contains(code)
                                                     && tbl_kacontractsdatadetail.Fullname.Contains(name)
                                                     && tbl_kacontractsdatadetail.VATregistrationNo.Contains(txtvat)
                                                     && typecontract.Contains(tbl_kacontractsdatadetail.ConType)
                                   //    && Vatlistcontract.

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
                                       tbl_kacontractsdatadetail.Address,
                                       // tbl_kacontractsdatadetail.PR

                                       //     Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
                                       VATregistrationNo = tbl_kacontractsdatadetail.VATregistrationNo,
                                       EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                                       CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                                       PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                                       UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                                       LitAched = tbl_kacontractsdatadetail.LitAched,
                                       FTNAched = tbl_kacontractsdatadetail.ECAched,
                                       NSRAched = tbl_kacontractsdatadetail.NSRAched,
                                       AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                                       BegindetailCotractAched = tbl_kacontractsdatadetail.BeginAchvmt,

                                       PayControl = tbl_kacontractsdatadetail.PayControl,
                                       tbl_kacontractsdatadetail.PayType,
                                       Description = tbl_kacontractsdatadetail.Description,
                                       PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                                       FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                                       SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                                       AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                                       FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                                       CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                                       TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                                       Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                                       tbl_kacontractsdatadetail.Remark,
                                       tbl_kacontractsdatadetail.UPDUSR,
                                       tbl_kacontractsdatadetail.UPDDAT,

                                   };



                Utils ut = new Utils();

                dt = ut.ToDataTable(db, rsthisperiod);
                this.rs = rsthisperiod;
                this.dataGridView1.DataSource = dt;




                #region format





                this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //ContractNo = tbl_kacontractsdatadetail.ContractNo,
                //Region = tbl_kacontractsdatadetail.SalesOrg,

                //Constatus = tbl_kacontractsdatadetail.Constatus,
                //Contracttype = tbl_kacontractsdatadetail.ConType,
                //EffFrm = tbl_kacontractsdatadetail.EffFrm,

                //EffTo = tbl_kacontractsdatadetail.EffTo,
                //CustomerCode = tbl_kacontractsdatadetail.Customercode,
                //EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                //CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                               //UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //LitAched = tbl_kacontractsdatadetail.LitAched,
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //FTNAched = tbl_kacontractsdatadetail.ECAched,
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //NSRAched = tbl_kacontractsdatadetail.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                             //AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //PayControl = tbl_kacontractsdatadetail.PayControl,

                //Description = tbl_kacontractsdatadetail.Description,
                //PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                //FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                //SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                //FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,

                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                      //TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                              //Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



                #endregion




                #endregion


            }




            // throw new NotImplementedException();
        }

        public void ReloadKASeachcontractype(string code, string contract, string name, string contractype)
        {
            //    string connection_string = Utils.getConnectionstr();
            //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            System.Data.DataTable dt = new System.Data.DataTable();
            //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rsthisperiod = from tbl_kacontractdata in db.tbl_kacontractdatas
            //                   where (tbl_kacontractdata.ContractNo).Contains(contract) &&
            //                       ((int)tbl_kacontractdata.Customer).ToString().Contains(code) // &&
            //                                                                                    //(tbl_kacontractmasterdata.FullName).Contains(name)
            //                   select tbl_kacontractdata;


            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in db.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();

            var typecontract = contractype;

            if (statusview.Text == "Master")
            {
                //    statusview.Text = "Master";


                #region


                var rsthisperiod = from tbl_kacontractdata in db.tbl_kacontractdatas
                                   where (from Tka_RegionRight in db.Tka_RegionRights
                                          where Tka_RegionRight.RegionCode == regioncode
                                          select Tka_RegionRight.Region.Trim()
                                          ).Contains(tbl_kacontractdata.SalesOrg.Trim()) &&
                                          (tbl_kacontractdata.ContractNo).Contains(contract) &&
                                                 ((int)tbl_kacontractdata.Customer).ToString().Contains(code)
                                                 && tbl_kacontractdata.Fullname.Contains(name)
                                                 && typecontract == tbl_kacontractdata.ConType


                                   select new
                                   {
                                       tbl_kacontractdata.ContractNo,
                                       tbl_kacontractdata.SalesOrg,
                                       tbl_kacontractdata.ConType,//contract type
                                       tbl_kacontractdata.Consts, //contract status
                                       tbl_kacontractdata.Currency,
                                       Validfrom = tbl_kacontractdata.EffDate,
                                       Validto = tbl_kacontractdata.EftDate,
                                       extDate = tbl_kacontractdata.ExtDate,

                                       tbl_kacontractdata.Customer,
                                       tbl_kacontractdata.Fullname,
                                       Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
                                       tbl_kacontractdata.Channel,
                                       FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                                       tbl_kacontractdata.PCVolAched,
                                       tbl_kacontractdata.NSRAched,
                                       tbl_kacontractdata.UCVolAched,
                                       tbl_kacontractdata.Revenue,

                                       tbl_kacontractdata.Cash,
                                       tbl_kacontractdata.FreeGood,
                                       tbl_kacontractdata.POS,

                                       tbl_kacontractdata.Promotion,
                                       tbl_kacontractdata.MKTFun,

                                       AchivedCommitment = tbl_kacontractdata.TotDeal,
                                       tbl_kacontractdata.Tot_paid,
                                       tbl_kacontractdata.Cash_paid,
                                       tbl_kacontractdata.FreeGood_paid,
                                       tbl_kacontractdata.POS_paid,

                                       tbl_kacontractdata.Promotion_paid,
                                       tbl_kacontractdata.MKTFun_paid,

                                       Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,

                                       PosBalance = tbl_kacontractdata.POS - tbl_kacontractdata.POS_paid,

                                       OthersBalance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid - tbl_kacontractdata.POS + tbl_kacontractdata.POS_paid,
                                       VolumeCommit = tbl_kacontractdata.VolComm,
                                       tbl_kacontractdata.NSRComm,

                                       tbl_kacontractdata.Remarks,
                                       tbl_kacontractdata.DeliveredBy,
                                       tbl_kacontractdata.Representative,
                                       tbl_kacontractdata.VATregistrationNo,
                                       tbl_kacontractdata.CRDDAT,
                                       tbl_kacontractdata.CRDUSR,




                                   };

                #endregion




                Utils ut = new Utils();
                dt = ut.ToDataTable(db, rsthisperiod);
                this.rs = rsthisperiod;
                this.dataGridView1.DataSource = dt;

                //    tbl_kacontractdata t = new tbl_kacontractdata();
                Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);





            }


            if (statusview.Text == "Detail")
            {
                //    statusview.Text = "Detail";


                #region


                var rsthisperiod = from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                                   where (from Tka_RegionRight in db.Tka_RegionRights
                                          where Tka_RegionRight.RegionCode == regioncode
                                          select Tka_RegionRight.Region.Trim()
                                          ).Contains(tbl_kacontractsdatadetail.SalesOrg.Trim()) &&
                                          (tbl_kacontractsdatadetail.ContractNo).Contains(contract) &&
                                                 ((int)tbl_kacontractsdatadetail.Customercode).ToString().Contains(code)
                                                     && tbl_kacontractsdatadetail.Fullname.Contains(name)
                                                     && typecontract == tbl_kacontractsdatadetail.ConType
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
                                       tbl_kacontractsdatadetail.Address,
                                       //    
                                       EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                                       CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                                       PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                                       UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                                       LitAched = tbl_kacontractsdatadetail.LitAched,
                                       FTNAched = tbl_kacontractsdatadetail.ECAched,
                                       NSRAched = tbl_kacontractsdatadetail.NSRAched,
                                       AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,

                                       BegindetailCotractAched = tbl_kacontractsdatadetail.BeginAchvmt,

                                       PayControl = tbl_kacontractsdatadetail.PayControl,
                                       tbl_kacontractsdatadetail.PayType,
                                       Description = tbl_kacontractsdatadetail.Description,
                                       PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                                       FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                                       SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                                       AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                                       FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                                       CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                                       TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                                       Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                                       tbl_kacontractsdatadetail.Remark,
                                       tbl_kacontractsdatadetail.UPDUSR,
                                       tbl_kacontractsdatadetail.UPDDAT,

                                   };



                Utils ut = new Utils();
                dt = ut.ToDataTable(db, rsthisperiod);
                this.rs = rsthisperiod;
                this.dataGridView1.DataSource = dt;

                //    tbl_kacontractdata t = new tbl_kacontractdata();
                //    Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);



                #region format





                //ContractNo = tbl_kacontractsdatadetail.ContractNo,
                //Region = tbl_kacontractsdatadetail.SalesOrg,

                //Constatus = tbl_kacontractsdatadetail.Constatus,
                //Contracttype = tbl_kacontractsdatadetail.ConType,
                //EffFrm = tbl_kacontractsdatadetail.EffFrm,

                //EffTo = tbl_kacontractsdatadetail.EffTo,
                //CustomerCode = tbl_kacontractsdatadetail.Customercode,
                //EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                //CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,
                //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["BegindetailCotractAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                               //UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //LitAched = tbl_kacontractsdatadetail.LitAched,
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //FTNAched = tbl_kacontractsdatadetail.ECAched,
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //NSRAched = tbl_kacontractsdatadetail.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                             //AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //PayControl = tbl_kacontractsdatadetail.PayControl,


                //Description = tbl_kacontractsdatadetail.Description,
                //PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                //FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                //SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                //FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,

                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                      //TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                              //Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



                #endregion




                #endregion


            }




            // throw new NotImplementedException();
        }


        private void Bt_Adddata_Click(object sender, EventArgs e)
        {
            string ContractNo = "";
            try
            {
                ContractNo = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ContractNo"].Value;
            }
            catch (Exception)
            {

                return;


                // throw;
            }

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                      where tbl_kacontractdata.ContractNo == ContractNo
                      select tbl_kacontractdata.ContractNo).FirstOrDefault();
            if (rs == null)
            {
                MessageBox.Show("Please select another contract !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //   string ContractNo = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ContractNo"].Value;

            if (this.formname.Text == "Payment Input")
            {
                if (ContractNo != "" && ContractNo != null)
                {
                    CreatenewContract newcontrac = new CreatenewContract("DISPLAY PAYMENT CONTRACT", ContractNo);
                    newcontrac.Text = "Payment Input";
                    newcontrac.ShowDialog();
                    //   newcontrac.BringToFront();
                    newcontrac.Focus();
                }
                else
                {
                    MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            if (this.formname.Text == "Input Contract")
            {
                if (ContractNo != "" && ContractNo != null)
                {
                    CreatenewContract newcontrac = new CreatenewContract("ENTRY SCREEN DISPLAY CONTRACT", ContractNo);
                    newcontrac.Text = "Input Contract";
                    newcontrac.ShowDialog();
                    //  newcontrac.BringToFront();
                    newcontrac.Focus();

                }
                else
                {
                    MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();


            ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);

        }


        private void button1_Click(object sender, EventArgs e)
        {


            Thread t1 = new Thread(Control.Control_ac.CaculationALLContractinSQL);
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(Control.Control_ac.showwait);
            t2.Start();
            //   autoEvent.WaitOne(); //join
            t1.Join();
            if (t1.ThreadState != ThreadState.Running)
            {


                Thread.Sleep(100);
                t2.Abort();

                //     MessageBox.Show("All contract are update !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                System.Data.DataTable dt = new System.Data.DataTable();
                //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                string connection_string = Utils.getConnectionstr();
                string username = Utils.getusername();

                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


                var rs = Control.Control_ac.getViewcontractMaster(db);


                Utils ut = new Utils();
                dt = ut.ToDataTable(db, rs);
                this.rs = rs;
                this.dataGridView1.DataSource = dt;

                Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);



            }









        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ContractNo = "";
            try
            {
                ContractNo = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ContractNo"].Value;
            }
            catch (Exception)
            {

                return;
                // throw;
            }

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                      where tbl_kacontractdata.ContractNo == ContractNo
                      select tbl_kacontractdata.ContractNo).FirstOrDefault();
            if (rs == null)
            {
                MessageBox.Show("Please select another contract !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (this.formname.Text == "Input Contract")
            {
                if (ContractNo != "" && ContractNo != null)
                {
                    CreatenewContract newcontrac = new CreatenewContract("ENTRY SCREEN DISPLAY CONTRACT", ContractNo);
                    newcontrac.Text = "Input Contract";
                    newcontrac.ShowDialog();
                    //    newcontrac.BringToFront();
                    newcontrac.Focus();
                }
                else
                {
                    MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            if (this.formname.Text == "Payment Input")
            {
                if (ContractNo != "" && ContractNo != null)
                {
                    CreatenewContract newcontrac = new CreatenewContract("DISPLAY PAYMENT CONTRACT", ContractNo);
                    newcontrac.Text = "Payment Input";
                    newcontrac.ShowDialog();
                    //     newcontrac.BringToFront();
                    newcontrac.Focus();
                }
                else
                {
                    MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            ///




            if (this.formname.Text == "Accrual reports detail" || this.formname.Text == "Accrual reports master")
            {
                if (ContractNo != "" && ContractNo != null)
                {
                    CreatenewContract newcontrac = new CreatenewContract("VIEW SCREEN DISPLAY CONTRACT", ContractNo);
                    newcontrac.Text = "Display Contract";
                    newcontrac.ShowDialog();
                    //        newcontrac.BringToFront();
                    newcontrac.Focus();
                }
                else
                {
                    MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


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

            string contractype = cbcontracttypefil.Text;
            ReloadKASeachcontractype("", "", "", contractype);



        }





        private void btmasschange_Click(object sender, EventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "MASS CHANGE CONTRACT STATUS")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {




                View.kamasscontractChange kamasscontractChange = new View.kamasscontractChange();


                kamasscontractChange.Show();
            }




        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "MASS CONFIM PAYMENT")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {




                View.kamassCofirm kamassCofirm = new View.kamassCofirm();


                kamassCofirm.Show();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            View.masscreateContract masscreateContract = new View.masscreateContract();


            masscreateContract.ShowDialog();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }
        }
    }
}
