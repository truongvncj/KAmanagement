using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KAmanagement.Control;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;

namespace KAmanagement.View
{


    public partial class CreatenewContract : Form
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


        public void loadpaymentstausgridview(IQueryable rs)
        {


            dataGridView7.DataSource = rs;



        }

        public void ReloadKASeachcontract(string text)
        {
            this.lbcaculating.Text = text;

        }
        public void Uploadcutomercode(String code, String name, Boolean sfacode)

        {
            if (sfacode == true)
            {
                this.txtfindsacode.Text = code;
                this.cb_customerka.Text = "";
                this.cbsfa.Checked = true;
                this.cbcust.Checked = false;
            }
            else
            {
                this.cb_customerka.Text = code;
                this.txtfindsacode.Text = "";
                this.cbsfa.Checked = false;
                this.cbcust.Checked = true;

            }

            //this.cb_customerka.SelectedIndex = 

            ComboboxItem cb = new ComboboxItem();
            cb.Value = code;
            cb.Text = code + ": " + name;
            this.cb_customerka.Items.Add(cb); // CombomCollection.Add(cb);
            //this.cb_customerka.se = cb_customerka.Items.Count+1;
            this.cb_delivery.Items.Add(cb);



        }

        public void loadtotaldContractnew()
        {


            #region load teamtotal
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rs1 = from tbl_KaCreatCrtracttemp in dc.tbl_KaCreatCrtracttemps
                      where tbl_KaCreatCrtracttemp.Username == username // && tbl_KaCreatCrtracttemp.
                      select tbl_KaCreatCrtracttemp;

            this.dataGridViewtotal.DataSource = rs1;


            this.dataGridViewtotal.Columns["id"].Visible = false;
            this.dataGridViewtotal.Columns["Username"].Visible = false;
            this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Format = "N0";




            this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Total_Achived"].HeaderText = "Total Achived";

            this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Sponror Amount";

            this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentPerPC"].HeaderText = " Amount byPC";



            this.dataGridViewtotal.Columns["CommitmentPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentPercentage"].HeaderText = "Percentage   ";



            this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Total_Paid"].HeaderText = "Total Paid     ";

            this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Balance"].HeaderText = "Balance       ";


            this.dataGridViewtotal.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            //    this.dataGridViewtotal.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;


            #endregion





        }

        public void loadtotaldContractView(string ContractNoin)
        {

            #region load total

            #region  create temtoatalcontract

            #region delete  tbl_KaCreatCrtracttemp


            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();


            #endregion


            //      float totalcommit = 0;

            tbl_KaCreatCrtracttemp temptotal2 = new tbl_KaCreatCrtracttemp();  // hàng tổng kết
            temptotal2.CommitmentAmount = 0;
            temptotal2.CommitmentPerPC = 0;
            temptotal2.CommitmentPercentage = 0;
            temptotal2.Total_Achived = 0;
            temptotal2.Total_Paid = 0;
            temptotal2.Balance = 0;


            var rss1 = from tbl_kaprogramlist in dc.tbl_kaprogramlists
                       where tbl_kaprogramlist.Code != "DIS"
                       select tbl_kaprogramlist;

            foreach (var item in rss1)
            {
                tbl_KaCreatCrtracttemp temptotal = new tbl_KaCreatCrtracttemp();  // các hàng chi tiết

                string filter = "";
                string statusview = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo.Equals(ContractNoin)
                                     select tbl_kacontractdata.Consts).FirstOrDefault();

                if (statusview != null)
                {
                    if (statusview == "ALV")
                    {
                        filter = "ALV";
                    }
                    else
                    {
                        filter = "";
                    }
                }
                else
                {
                    filter = "";
                }


                temptotal.Programe = item.Name;
                //  totalcommit = totalcommit + item.c
                //   temptotal.Analyses = item.Name + "/CS";
                var totaldetailrs = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                     where tbl_kacontractsdatadetail.PayType == item.Code && tbl_kacontractsdatadetail.ContractNo.Equals(ContractNoin)
                                     && tbl_kacontractsdatadetail.Constatus.Contains(filter)
                                     group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayType into g
                                     select new
                                     {
                                         CommitPercentage = g.Sum(gg => gg.FundPercentage).GetValueOrDefault(0),
                                         Commitment = g.Sum(gg => gg.SponsoredAmt).GetValueOrDefault(0),
                                         Commitment_cs = g.Sum(gg => gg.SponsoredAmtperPC).GetValueOrDefault(0),

                                         Total_Achived = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0), // ConfAmt lấy confirm amount làm tinh tong tien 
                                                                                                              //   Balance = g.Sum(gg => gg.Balance).GetValueOrDefault(0)

                                     }).FirstOrDefault();

                if (totaldetailrs != null)
                {
                    temptotal.CommitmentAmount = totaldetailrs.Commitment;
                    temptotal.Total_Achived = totaldetailrs.Total_Achived;
                    temptotal.CommitmentPerPC = totaldetailrs.Commitment_cs;
                    temptotal.CommitmentPercentage = totaldetailrs.CommitPercentage;
                    temptotal.Total_Paid = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                            where tbl_kacontractsdetailpayment.PayType == item.Code && tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNoin)
                                            select tbl_kacontractsdetailpayment.PaidAmt).Sum().GetValueOrDefault(0);
                    temptotal.Balance = totaldetailrs.Total_Achived - temptotal.Total_Paid;
                }
                else
                {
                    temptotal.CommitmentAmount = 0;
                    temptotal.CommitmentPerPC = 0;
                    temptotal.CommitmentPercentage = 0;
                    temptotal.Total_Achived = 0;
                    temptotal.Total_Paid = 0;
                    temptotal.Balance = 0;
                }

                //  paid = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),


                temptotal2.CommitmentAmount = temptotal2.CommitmentAmount + temptotal.CommitmentAmount;
                temptotal2.CommitmentPerPC = temptotal2.CommitmentPerPC + temptotal.CommitmentPerPC;
                temptotal2.CommitmentPercentage = temptotal2.CommitmentPercentage + temptotal2.CommitmentPercentage;
                temptotal2.Total_Achived = temptotal2.Total_Achived + temptotal.Total_Achived;
                temptotal2.Total_Paid = temptotal2.Total_Paid + temptotal.Total_Paid;
                temptotal2.Balance = temptotal2.Balance + temptotal.Balance;


                temptotal.Username = username;
                dc.CommandTimeout = 0;
                dc.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal);
                dc.SubmitChanges();

            }


            temptotal2.Programe = "Total";

            temptotal2.Username = username;
            // temptotal2.Analyses = "Total";


            dc.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal2);
            dc.SubmitChanges();


            #endregion

            #region load teamtotal

            var rs1 = from tbl_KaCreatCrtracttemp in dc.tbl_KaCreatCrtracttemps
                      where tbl_KaCreatCrtracttemp.Username == username
                      select tbl_KaCreatCrtracttemp;

            this.dataGridViewtotal.DataSource = rs1;


            this.dataGridViewtotal.Columns["id"].Visible = false;
            this.dataGridViewtotal.Columns["Username"].Visible = false;

            this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Format = "N0";
            this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Format = "N0";

            //this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //   this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Commitment";

            this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Total_Achived"].HeaderText = "Total Achived";

            this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Sponror Amount";

            this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentPerPC"].HeaderText = " Amount byPC  ";


            this.dataGridViewtotal.Columns["CommitmentPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["CommitmentPercentage"].HeaderText = "Percentage   ";


            this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Total_Paid"].HeaderText = "Total Paid    ";
            this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridViewtotal.Columns["Balance"].HeaderText = "Balance       ";

            this.dataGridViewtotal.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dataGridViewtotal.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewtotal.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            //this.dataGridViewtotal.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            #endregion





        }

        public void loadDetaildContractcreatenew()
        {


            #region  DETAIL datagridview [tbl_kaProgramedetailTemp]

            label36.Visible = false;
            label35.Visible = false;
            //      label34.Visible = false;
            label33.Visible = false;
            label32.Visible = false;
            //Achivedvol.Visible = false;
            RevenueAched.Visible = false;
            AchievdVolPCs.Visible = false;
            Funpercentage.Visible = false;
            Costpercase.Visible = false;


            //bt_fin.Visible = false;
            //bt_finundo.Visible = false;
            //bt_cancel.Visible = false;
            //bt_close.Visible = false;
            //bt_undoclose.Visible = false;
            //bt_undocancel.Visible = false;

            #region load detail pg




            // tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

            //  tb.

            DataTable dt = new DataTable();

            //dt.Columns.Add(new DataColumn("Program", typeof(String)));
            //dt.Columns.Add(new DataColumn("Payment_Control", typeof(String)));
            dt.Columns.Add(new DataColumn("ExtCondition", typeof(Boolean)));
            dt.Columns.Add(new DataColumn("ExtNote", typeof(string)));


            //       dt.Columns.Add(new DataColumn("Product_Group", typeof(Double)));



            dt.Columns.Add(new DataColumn("Fund_Percent", typeof(double)));
            dt.Columns.Add(new DataColumn("Amount_Per_Pc_Lit_FTN", typeof(double)));
            dt.Columns.Add(new DataColumn("Sponsored_Amount", typeof(double)));
            dt.Columns.Add(new DataColumn("Sponsored_Limited", typeof(double)));

            dt.Columns.Add(new DataColumn("SponsortUnit", typeof(string)));

            //Threahold
            dt.Columns.Add(new DataColumn("Taget_Percentage", typeof(double)));
            dt.Columns.Add(new DataColumn("Taget_Achivement", typeof(double)));
            dt.Columns.Add(new DataColumn("TargetUnit", typeof(string)));
            //  dt.Columns.Add(new DataColumn("Payment_Commit_Date", typeof(DateTime)));
            //Time Frame
            //           dt.Columns.Add(new DataColumn("Effect_From", typeof(DateTime)));

            //           dt.Columns.Add(new DataColumn("Effect_To", typeof(DateTime)));
            //Remark
            dt.Columns.Add(new DataColumn("Remark", typeof(string)));

            //dt.Columns.Add(new DataColumn("Start-Date", typeof(DateTime)));

            //dt.Columns.Add(new DataColumn("Start-Date", typeof(DateTime)));

            //  dataGridView1.DataSource = dt;


            //    tb.Remark
            //   tb.Amount_Per_Pc_Lit_FTN
            //   tb.To_Date
            //          tb.From_Date
            //    tb.Ditributor__s_Amount
            //   tb.ExtCondition 
            //  tb.Achivement;
            //  tb.Amount_Per_Pc;
            //  tb.Balance;
            //  tb.Date;
            //  tb.Done_On;
            //  tb.Percent;
            //  tb.id;
            //  tb.Paid_Amount;
            //  tb.Payment_Control;
            //  tb.Payment_Description;
            //  tb.Prepered_On;
            //  tb.Print;
            //  tb.Product_Group;
            //  tb.Program;
            //  tb.Ref_No;
            //  tb.Sponsored_Amount;
            //  tb.Tracking_id;
            //  tb.Unit;
            //  tb.Username;
            //   tb.dis

            //    dt.Columns["Program"].
            this.dataGridProgramdetail.DataSource = dt;
            // this.dataGridProgramdetail.DataSource = detailprogarmers;



            //this.dataGridProgramdetail.Columns["id"].Visible = false;
            //this.dataGridProgramdetail.Columns["Username"].Visible = false;





            #endregion


            //    dgv_list_EditingControlShowing;



            //   dataGridProgramdetail.Columns.Remove("Program");

            bindDataToDataGridViewComboPrograme();
            bindDataToDataGridViewComboPayment_Control();
            bindDataToDataGridViewComboproductgroup_Control();



            DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            col.HeaderText = "Payment Commit Date";
            col.Name = "Payment_Commit_Date";
            dataGridProgramdetail.Columns.Add(col);
            //dataGridProgramdetail.RowCount = 5;
            DGV_DateTimePicker.DateTimePickerColumn col2 = new DGV_DateTimePicker.DateTimePickerColumn();
            col2.HeaderText = "Effect From";
            col2.Name = "Effect_From";

            dataGridProgramdetail.Columns.Add(col2);



            DGV_DateTimePicker.DateTimePickerColumn col3 = new DGV_DateTimePicker.DateTimePickerColumn();
            col3.HeaderText = "Effect To";
            col3.Name = "Effect_To";
            dataGridProgramdetail.Columns.Add(col3);
            //   -----\\\\ batdau load



            dataGridProgramdetail.Columns["Program"].DisplayIndex = 0;
            dataGridProgramdetail.Columns["Program"].Width = 70;
            this.dataGridProgramdetail.Columns["Program"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridProgramdetail.Columns["Payment_Control"].DisplayIndex = 1;
            dataGridProgramdetail.Columns["Payment_Control"].Width = 70;
            dataGridProgramdetail.Columns["Payment_Control"].HeaderText = "Payment\nControl";
            this.dataGridProgramdetail.Columns["Payment_Control"].SortMode = DataGridViewColumnSortMode.NotSortable;
            // Product_Group
            dataGridProgramdetail.Columns["Remark"].DisplayIndex = 2;
            dataGridProgramdetail.Columns["Remark"].Width = 300;
            dataGridProgramdetail.Columns["Remark"].HeaderText = "Description";
            this.dataGridProgramdetail.Columns["Remark"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //  this.dataGridProgramdetail.Columns["Remark"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridProgramdetail.Columns["Product_Group"].DisplayIndex = 3;
            dataGridProgramdetail.Columns["Product_Group"].Width = 80;
            dataGridProgramdetail.Columns["Product_Group"].HeaderText = "Product \nGroup";
            this.dataGridProgramdetail.Columns["Product_Group"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridProgramdetail.Columns["ExtCondition"].DisplayIndex = 4;
            dataGridProgramdetail.Columns["ExtCondition"].Width = 80;
            this.dataGridProgramdetail.Columns["ExtCondition"].SortMode = DataGridViewColumnSortMode.NotSortable;



            dataGridProgramdetail.Columns["ExtNote"].DisplayIndex = 5;
            dataGridProgramdetail.Columns["ExtNote"].Width = 80;
            this.dataGridProgramdetail.Columns["ExtCondition"].SortMode = DataGridViewColumnSortMode.NotSortable;




            //      this.dataGridProgramdetail.Columns["Fund_Percent"].DefaultCellStyle.Format = "N0";
            dataGridProgramdetail.Columns["Fund_Percent"].DisplayIndex = 6;
            //   dataGridProgramdetail.Columns["Fund_Percent"].Width = 150;
            dataGridProgramdetail.Columns["Fund_Percent"].HeaderText = "Sponsor \nPercent";
            this.dataGridProgramdetail.Columns["Fund_Percent"].SortMode = DataGridViewColumnSortMode.NotSortable;



            dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].DisplayIndex = 7;
            //     dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].Width = 120;
            this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].HeaderText = "Sponsor Per \nPC\\UC\\Litter";
            this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].SortMode = DataGridViewColumnSortMode.NotSortable;




            dataGridProgramdetail.Columns["Sponsored_Amount"].DisplayIndex = 8;
            this.dataGridProgramdetail.Columns["Sponsored_Amount"].HeaderText = "Sponsor Amount";
            this.dataGridProgramdetail.Columns["Sponsored_Amount"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Sponsored_Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;



            dataGridProgramdetail.Columns["Sponsored_Limited"].DisplayIndex = 9;
            this.dataGridProgramdetail.Columns["Sponsored_Limited"].HeaderText = "Sponsored \nLimited";
            this.dataGridProgramdetail.Columns["Sponsored_Limited"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Sponsored_Limited"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //     dt.Columns.Add(new DataColumn("SponsortUnit", typeof(string)));

            dataGridProgramdetail.Columns["SponsortUnit"].DisplayIndex = 10;
            this.dataGridProgramdetail.Columns["SponsortUnit"].HeaderText = "Sponsor \nUnit";
            this.dataGridProgramdetail.Columns["SponsortUnit"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["SponsortUnit"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Format = "N0";
            dataGridProgramdetail.Columns["Taget_Percentage"].DisplayIndex = 11;
            this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Taget_Percentage"].HeaderText = "Target \nPercentage";
            this.dataGridProgramdetail.Columns["Taget_Percentage"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridProgramdetail.Columns["Taget_Achivement"].DisplayIndex = 12;
            dataGridProgramdetail.Columns["Taget_Achivement"].HeaderText = "Target Achivement";
            this.dataGridProgramdetail.Columns["Taget_Achivement"].DefaultCellStyle.Format = "N0";
            dataGridProgramdetail.Columns["Taget_Achivement"].Width = 80;
            this.dataGridProgramdetail.Columns["Taget_Achivement"].SortMode = DataGridViewColumnSortMode.NotSortable;




            dataGridProgramdetail.Columns["TargetUnit"].DisplayIndex = 13;
            dataGridProgramdetail.Columns["TargetUnit"].HeaderText = "Target Unit";
            this.dataGridProgramdetail.Columns["TargetUnit"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridProgramdetail.Columns["TargetUnit"].Width = 80;

            //     this.dataGridViewtotal.Columns["TargetUnit"].DefaultCellStyle.Format = "N0";


            dataGridProgramdetail.Columns["Payment_Commit_Date"].DisplayIndex = 14;
            dataGridProgramdetail.Columns["Payment_Commit_Date"].HeaderText = "Payment \nCommitment Date";
            this.dataGridProgramdetail.Columns["Payment_Commit_Date"].SortMode = DataGridViewColumnSortMode.NotSortable;



            dataGridProgramdetail.Columns["Effect_From"].DisplayIndex = 15;
            dataGridProgramdetail.Columns["Effect_From"].HeaderText = "From Date";
            this.dataGridProgramdetail.Columns["Effect_From"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridProgramdetail.Columns["Effect_To"].DisplayIndex = 16;
            dataGridProgramdetail.Columns["Effect_To"].HeaderText = "To Date";
            this.dataGridProgramdetail.Columns["Effect_To"].SortMode = DataGridViewColumnSortMode.NotSortable;



            #endregion


        }

        public void loadDetailContractView(string ContractNoin)
        {

            string connection_string = Utils.getConnectionstr();
            //  string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);





            #region  load detail dataGridView1

            var updatePayID = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                              where tbl_kacontractsdatadetail.ContractNo == ContractNoin
                              select tbl_kacontractsdatadetail;

            foreach (var item in updatePayID)
            {
                if (item.PayID == null)
                {
                    item.PayID = item.id;

                }

                dc.SubmitChanges();
            }


            var dataGridProgramdetailrs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                          where tbl_kacontractsdatadetail.ContractNo == ContractNoin && tbl_kacontractsdatadetail.PayControl != "PAY" && tbl_kacontractsdatadetail.PayControl != "DIS"
                                          select new
                                          {
                                              Programe = tbl_kacontractsdatadetail.PayType.Trim(),
                                              Status = tbl_kacontractsdatadetail.Constatus,
                                              PayControl = tbl_kacontractsdatadetail.Description.Trim(), // tbl_kacontractsdatadetail.PayControl.Trim() + ": " +
                                              Description = tbl_kacontractsdatadetail.Remark,
                                              //       Description = tbl_kacontractsdatadetail.Description.Trim(),


                                              Product_Group = tbl_kacontractsdatadetail.PrdGrp,
                                              //        this.dataGridProgramdetail.Columns["Fund_Percent"].DefaultCellStyle.Format = "N0";
                                              SponsorPercent = tbl_kacontractsdatadetail.FundPercentage,
                                              SponsorByUnit = tbl_kacontractsdatadetail.SponsoredAmtperPC,

                                              SponsorAmount = tbl_kacontractsdatadetail.SponsoredAmt,
                                              Unit = tbl_kacontractsdatadetail.SponsorUnit,
                                              Target_Percentage = tbl_kacontractsdatadetail.TagetPercentage,

                                              Target_Achivement = tbl_kacontractsdatadetail.TagetAchivement,


                                              Achivement = tbl_kacontractsdatadetail.VolAchvmt.GetValueOrDefault(0),//+ tbl_kacontractsdatadetail.BeginAchvmt.GetValueOrDefault(0),
                                              TargetUnit = tbl_kacontractsdatadetail.TargetUnit,
                                              Sponsor_Total = tbl_kacontractsdatadetail.SponsoredTotal,
                                              //     Distribution_Amt = tbl_kacontractsdatadetail.DisAmount,

                                              PaidRequest = tbl_kacontractsdatadetail.PaidRequestAmt,
                                              Paid_Amount = tbl_kacontractsdatadetail.PaidAmt,

                                              Payment_Commit_Date = tbl_kacontractsdatadetail.CommittedDate,
                                              Effect_From = tbl_kacontractsdatadetail.EffFrm,
                                              Effect_To = tbl_kacontractsdatadetail.EffTo,

                                              PayID = tbl_kacontractsdatadetail.PayID,

                                              ExtCondition = tbl_kacontractsdatadetail.ExtCondition,
                                              tbl_kacontractsdatadetail.ExtNote,
                                              Print = tbl_kacontractsdatadetail.PrintChk,
                                              tbl_kacontractsdatadetail.SponsoredLimited,
                                        //      tbl_kacontractsdatadetail.CombineType,


                                              Done_On = tbl_kacontractsdatadetail.DoneOn



                                          };

            dataGridProgramdetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridProgramdetail.DataSource = dataGridProgramdetailrs;
            this.dataGridProgramdetail.Columns["Sponsor_Total"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["PaidRequest"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["SponsorByUnit"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["SponsorAmount"].DefaultCellStyle.Format = "N0";
            this.dataGridProgramdetail.Columns["Target_Achivement"].DefaultCellStyle.Format = "N0";

            this.dataGridProgramdetail.Columns["Achivement"].DefaultCellStyle.Format = "N0";

            this.dataGridProgramdetail.Columns["Sponsor_Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridProgramdetail.Columns["PaidRequest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridProgramdetail.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridProgramdetail.Columns["SponsorAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            this.dataGridProgramdetail.Columns["SponsoredLimited"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            
            this.dataGridProgramdetail.Columns["Achivement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                   //   this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            dataGridProgramdetail.AllowUserToOrderColumns = true;
            dataGridProgramdetail.AllowUserToResizeColumns = true;


            #endregion

            #region dataGridView7  detail pay ment

            var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                           where tbl_kacontractsdetailpayment.ContractNo == ContractNoin
                                           && tbl_kacontractsdetailpayment.BatchNo != 0  // && tbl_kacontractsdetailpayment.PayControl == "PAY"
                                           select new
                                           {

                                               Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                               PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                               Paid_Note = tbl_kacontractsdetailpayment.PaidNote,
                                               Description = tbl_kacontractsdetailpayment.Remark.Trim(),

                                               Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                               tbl_kacontractsdetailpayment.PaidRequestAmt,

                                               //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                               PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
                                               tbl_kacontractsdetailpayment.DoneOn,

                                               tbl_kacontractsdetailpayment.PrintChk,
                                               tbl_kacontractsdetailpayment.Reprint,
                                               tbl_kacontractsdetailpayment.PrintDate,
                                               //     Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                               tbl_kacontractsdetailpayment.BatchNo,
                                               tbl_kacontractsdetailpayment.CRDDAT,
                                               tbl_kacontractsdetailpayment.CRDUSR,
                                               //   tbl_kacontractsdetailpayment.DoneOn,


                                               tbl_kacontractsdetailpayment.UPDDAT,
                                               tbl_kacontractsdetailpayment.UPDUSR,

                                               PayID = tbl_kacontractsdetailpayment.PayID,
                                               SubID = tbl_kacontractsdetailpayment.SubID,


                                           };

            //   dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView7.DataSource = dataGridProgramdetailrs7;

            if (dataGridProgramdetailrs7.Count() > 0)
            {

                this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
                this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";



                this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            }

            #endregion





        }

        public AutoCompleteStringCollection contractdata = new AutoCompleteStringCollection();
        public CreatenewContract(string formlabel, string ContractNoin)
        {
            InitializeComponent();
            //    btupdatecontract.Visible = false;
            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();




            AutoCompleteStringCollection contractdata = new AutoCompleteStringCollection();

            var contractautolist = (from tbl_autodataContract in dc.tbl_autodataContracts
                                    where tbl_autodataContract.Username == username
                                    orderby tbl_autodataContract.id descending
                                    select tbl_autodataContract.ContractNo).Take(10);

            if (contractautolist.Count() > 0)
            {
                foreach (var item in contractautolist)
                {
                    if (item != null)
                    {
                        contractdata.Add(item);
                    }

                }


                var deletelist = from tbl_autodataContract in dc.tbl_autodataContracts
                                 where !contractautolist.Contains(tbl_autodataContract.ContractNo)
                                 select tbl_autodataContract;

                dc.tbl_autodataContracts.DeleteAllOnSubmit(deletelist);
                dc.SubmitChanges();

            }


            this.contractdata = contractdata;
            tb_contractno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_contractno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_contractno.AutoCompleteCustomSource = contractdata;


            btchangecontractitem.Visible = false;
            btaddnewItem.Visible = false;


            this.formlabel.Text = formlabel;

            cbcust.Enabled = false;
            cbsfa.Enabled = false;
            txtinfor.Visible = false;

            btdelete.Enabled = false;
            bt_fin.Visible = false;
            bt_finundo.Visible = false;
            bt_cancel.Visible = false;
            bt_close.Visible = false;
            btchangeRemark.Visible = false;
            btchangensrcomit.Visible = false;
            btchangevolcomit.Visible = false;


            btchangecontrcatype.Visible = false;
            btchangeregion.Visible = false;

            btchanegcontract.Visible = false;

            btcfromdate.Visible = false;
            btchagetodate.Visible = false;



            btchangecret.Visible = false;
            //
            btrepresent.Visible = false;
            btchangetradename.Visible = false;
            bthomeso.Visible = false;
            btchangedistric.Visible = false;
            btchangeprovince.Visible = false;
            btvatchange.Visible = false;

            ///
            bt_undoclose.Visible = false;
            bt_undocancel.Visible = false;



            cbocindirect.Enabled = false;

            #region neu laf "CREATING NEW CONTRACT")


            if (formlabel == "CREATING NEW CONTRACT")

            {


                btaddnewItem.Visible = false;



                this.Nsaperyear.Enabled = false;
                //   groupBox3.Enabled = false;
                this.txt_annualvolume.Enabled = false;
                this.txt_term.Enabled = false;
                txt_annualvolume.Text = "0";
                Nsaperyear.Text = "0";

                this.tb_creditlimit.Text = "0";
                this.bt_etcontract.Visible = false;
                //     this.bt_changecontracts.Visible = false;
                this.txt_volumecomit.Text = "0";

                tabControl1.TabPages.RemoveAt(1);

                tabControl1.TabPages.RemoveAt(2);

                tabControl1.TabPages.RemoveAt(3);

                tabControl1.TabPages.RemoveAt(1);

                tabControl1.TabPages.RemoveAt(1);



                if (Utils.IsValidnumber(txt_volumecomit.Text))
                {


                    #region load term and yeayr  

                    this.txt_term.Text = "1";

                    //this.txt_term.Text = (Math.Ceiling((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365))).ToString();
                    this.txt_annualvolume.Text = "0";// (double.Parse(txt_volumecomit.Text) / double.Parse(txt_term.Text)).ToString();


                    #endregion

                }


                #region load cb currency

                var rs2 = from tbl_kacurrency in dc.tbl_kacurrencies

                          select tbl_kacurrency;

                string drowdownshow = "";

                foreach (var item in rs2)
                {
                    drowdownshow = item.Currency;
                    this.cb_curency.Items.Add(drowdownshow);


                }
                this.cb_curency.SelectedIndex = 0;
                this.cb_contractstatus.SelectedIndex = 0;
                #endregion

                #region load cb tbl_karegion

                var rs4 = from tbl_karegion in dc.tbl_karegions
                              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_karegion;

                drowdownshow = "";

                foreach (var item in rs4)
                {
                    drowdownshow = item.Region;
                    this.cb_salesogr.Items.Add(drowdownshow);


                }

                #endregion


                #region load cb contractype

                var rs3 = from tbl_kacontracttype in dc.tbl_kacontracttypes
                              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_kacontracttype;

                drowdownshow = "";

                foreach (var item in rs3)
                {
                    drowdownshow = item.Contractype;
                    this.cb_contracttype.Items.Add(drowdownshow);


                }

                #endregion



                #region load tbl_PaymentTerm,

                var rs5 = from tbl_PaymentTerm in dc.tbl_PaymentTerms
                              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_PaymentTerm;

                drowdownshow = "";

                foreach (var item in rs5)
                {
                    drowdownshow = item.PaymentTerm;
                    this.cb_paymentterm.Items.Add(drowdownshow);


                }

                #endregion



                #region load tbl_kaChannel



                //       List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                var rs6 = from tbl_kaChannel in dc.tbl_kaChannels
                              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_kaChannel;

                foreach (var item in rs6)
                {
                    ComboboxItem cb = new ComboboxItem();
                    cb.Value = item.Channel;
                    cb.Text = item.Channel + " : " + item.Detail;
                    this.cb_channel.Items.Add(cb); // CombomCollection.Add(cb);

                }


                this.cb_channel.DropDownWidth = 230;

                #endregion


                this.cb_customerka.DropDownStyle = ComboBoxStyle.Simple;
                this.cb_delivery.DropDownStyle = ComboBoxStyle.Simple;
                this.txtfindsacode.DropDownStyle = ComboBoxStyle.Simple;


                //#region load cobcusstomer data


                //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                //var rscustomer = from tbl_KaCustomer in dc.tbl_KaCustomers
                //                     //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                //                 select tbl_KaCustomer;
                //foreach (var item in rscustomer)
                //{
                //    ComboboxItem cb = new ComboboxItem();
                //    cb.Value = item.Customer;
                //    cb.Text = item.Customer + ": " + item.FullNameN;
                //    this.cb_customerka.Items.Add(cb); // CombomCollection.Add(cb);
                //    this.cb_delivery.Items.Add(cb);
                //}


                //this.cb_customerka.DropDownWidth = 350;
                //this.cb_delivery.DropDownWidth = 300;


                ////drowdownshow = "";

                ////foreach (var item in rscustomer)
                ////{
                ////    drowdownshow = item.Customer.;
                ////    this.cb_channel.Items.Add(drowdownshow);


                ////}

                //#endregion






                #region  loadttal datagridview temp

                #region delete  tbl_KaCreatCrtracttemp


                //  string username = Utils.getusername();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
                db.CommandTimeout = 0;
                db.ExecuteCommand(sqltext);

                db.SubmitChanges();


                #endregion


                #region  create temtoatalcontract


                //      float totalcommit = 0;
                var rs = from tbl_kaprogramlist in db.tbl_kaprogramlists
                         where tbl_kaprogramlist.Code != "DIS"
                         select tbl_kaprogramlist;

                foreach (var item in rs)
                {
                    tbl_KaCreatCrtracttemp temptotal = new tbl_KaCreatCrtracttemp();

                    temptotal.Programe = item.Name;
                    //  totalcommit = totalcommit + item.c
                    //  temptotal.Analyses = item.Name + "/CS";
                    temptotal.CommitmentAmount = 0;
                    temptotal.CommitmentPerPC = 0;
                    temptotal.CommitmentPercentage = 0;
                    temptotal.Total_Achived = 0;
                    temptotal.Total_Paid = 0;
                    temptotal.Balance = 0;
                    temptotal.Username = username;
                    db.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal);
                    db.SubmitChanges();

                }

                tbl_KaCreatCrtracttemp temptotal2 = new tbl_KaCreatCrtracttemp();

                temptotal2.Programe = "Total";
                temptotal2.CommitmentAmount = 0;
                temptotal2.CommitmentPerPC = 0;
                temptotal2.CommitmentPerPC = 0;
                temptotal2.Total_Achived = 0;

                temptotal2.Total_Paid = 0;
                temptotal2.Balance = 0;
                temptotal2.Username = username;
                //    temptotal2.Analyses = "Total";


                db.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal2);
                db.SubmitChanges();


                #endregion



                #endregion

                loadtotaldContractnew();


                loadDetaildContractcreatenew();

            }

            #endregion neu laf "CREATING NEW CONTRACT")

            #region // newu la dispaly con tract


            if (formlabel == "DISPLAY PAYMENT CONTRACT" || formlabel == "ENTRY SCREEN DISPLAY CONTRACT" || formlabel == "VIEW SCREEN DISPLAY CONTRACT")
            {
                btviewcode.Visible = true;
                if (used.changeitem)
                {
                    btchangecontractitem.Visible = true;
                    btremoveCusgroup.Visible = true;

                    btAddGroupcode.Visible = true;
                }
                else
                {
                    btchangecontractitem.Visible = false;
                    btAddGroupcode.Visible = false;
                    btremoveCusgroup.Visible = false;
                }


                if (used.btaddnewItem)
                {
                    btaddnewItem.Visible = true;
                }
                else
                {
                    btaddnewItem.Visible = false;
                }


                txtVATno.Enabled = false;
                btfindcust.Enabled = false;
                btfinddeliveryby.Enabled = false;
                btfindsfa.Enabled = false;
                this.cb_contractstatus.Enabled = false;

                Control_ac.CaculationContract(ContractNoin); // tinhs toasn contract truo c khi view

                Control.Control_ac.CaculationContractinSQLmaster(ContractNoin);





                #region loaddata 


                var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                          where tbl_kacontractdata.ContractNo == ContractNoin
                          select tbl_kacontractdata).FirstOrDefault();


                if (rs != null)
                {

                    #region delete  tbl_KaCreatCrtracttemp


                    //    string username = Utils.getusername();
                    // LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
                    dc.ExecuteCommand(sqltext);
                    dc.SubmitChanges();


                    #endregion


                    #region load data master contrac

                    bt_creatnewCust.Visible = false;
                    bt_creatnewcontract.Visible = false;
                    //   but_releaseprint.Visible = false;

                    this.tb_contractno.Text = rs.ContractNo;
                    this.tb_contractno.Enabled = false;

                    this.dateTimePicker1.Value = rs.EffDate.Value;
                    this.dateTimePicker1.Enabled = false;


                    this.dateTimePicker2.Value = rs.EftDate.Value;
                    this.dateTimePicker2.Enabled = false;

                    this.dateTimePicker3.Value = rs.ExtDate.Value;
                    this.dateTimePicker3.Enabled = false;


                    // ToString("#,#", CultureInfo.InvariantCulture);

                    if (rs.ConTerm != null)
                    {
                        this.txt_term.Text = rs.ConTerm.ToString();// (this.dateTimePicker2.Value.Year - this.dateTimePicker1.Value.Year + 1).ToString();

                    }




                    this.txt_term.Enabled = false;
                    if (rs.NSRComm != null)
                    {
                        NSRcommit.Text = ((double)rs.NSRComm).ToString("#,#", CultureInfo.InvariantCulture);

                    }
                    else
                    {
                        NSRcommit.Text = "0";
                    }



                    NSRcommit.Enabled = false;


                    this.Nsaperyear.Enabled = false;

                    AchievdVolPCs.Enabled = false;
                    if (rs.PCVolAched != null)
                    {
                        AchievdVolPCs.Text = double.Parse(rs.PCVolAched.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
                    }

                    if (rs.Revenue != null)
                    {
                        RevenueAched.Text = double.Parse(rs.Revenue.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
                    }
                    RevenueAched.Enabled = false;



                    Funpercentage.Enabled = false;
                    if (rs.VolComm > 0)
                    {

                        Funpercentage.Text = Math.Round((double)((rs.PCVolAched.GetValueOrDefault(0) / rs.VolComm) * 100)).ToString("#,#", CultureInfo.InvariantCulture);

                    }

                    Costpercase.Enabled = false;
                    if (rs.ECAched > 0)
                    {

                        Costpercase.Text = ((double)(rs.TotDeal.GetValueOrDefault(0) / rs.ECAched)).ToString("#,#", CultureInfo.InvariantCulture);

                    }

                    if (rs.VolComm != null)
                    {
                        this.txt_volumecomit.Text = ((double)rs.VolComm).ToString("#,#", CultureInfo.InvariantCulture);
                    }

                    this.txt_volumecomit.Enabled = false;

                    if (rs.AnnualVolume != null)
                    {
                        this.txt_annualvolume.Text = ((double)rs.AnnualVolume).ToString("#,#", CultureInfo.InvariantCulture);
                        // this.txt_annualvolume.Text = ((double)(rs.VolComm/rs.ConTerm)).ToString("#,#", CultureInfo.InvariantCulture);

                    }



                    this.txt_annualvolume.Enabled = false;

                    this.Nsaperyear.Enabled = false;

                    if (rs.NSRPer != null)
                    {
                        this.Nsaperyear.Text = ((double)rs.NSRPer).ToString("#,#", CultureInfo.InvariantCulture);

                    }



                    txtfindsacode.Enabled = false;


                    if (rs.CreditLimit != null)
                    {
                        this.tb_creditlimit.Text = ((double)rs.CreditLimit).ToString("#,#", CultureInfo.InvariantCulture);
                        //     this.tb_creditlimit.Text = rs.CreditLimit.ToString();
                    }

                    this.tb_creditlimit.Enabled = false;


                    this.cb_customerka.DropDownStyle = ComboBoxStyle.Simple;// = false;

                    if (rs.CustomerType.Trim() == "SAP" || rs.CustomerType == null)
                    {
                        this.cb_customerka.Text = rs.Customer.ToString();
                        cbcust.Checked = true;
                    }

                    if (rs.CustomerType.Trim() == "SFA")
                    {
                        this.txtfindsacode.Text = rs.Customer.ToString();
                        cbsfa.Checked = true;
                        cbocindirect.Checked = true;
                    }




                    this.cb_customerka.Enabled = false;


                    this.cb_contracttype.DropDownStyle = ComboBoxStyle.Simple;// = false;
                    this.cb_contracttype.Text = rs.ConType;
                    this.cb_contracttype.Enabled = false;

                    this.cb_salesogr.DropDownStyle = ComboBoxStyle.Simple;// = false;

                    if (rs.SalesOrg != null)
                    {
                        this.cb_salesogr.Text = rs.SalesOrg;
                    }

                    this.cb_salesogr.Enabled = false;



                    this.cb_channel.DropDownStyle = ComboBoxStyle.Simple;// = false;

                    if (rs.Channel != null)
                    {
                        this.cb_channel.Text = rs.Channel;

                    }
                    this.cb_channel.Enabled = false;


                    this.cb_paymentterm.DropDownStyle = ComboBoxStyle.Simple;// = false;
                    this.cb_paymentterm.Text = rs.CreditTerm;
                    this.cb_paymentterm.Enabled = false;


                    this.cb_curency.DropDownStyle = ComboBoxStyle.Simple;// = false;
                    this.cb_curency.Text = rs.Currency;
                    this.cb_curency.Enabled = false;

                    this.cb_delivery.DropDownStyle = ComboBoxStyle.Simple;// = false;
                    this.cb_delivery.Text = rs.DeliveredBy;
                    this.cb_delivery.Enabled = false;

                    if (rs.Representative != null)
                    {
                        this.txt_represennt.Text = rs.Representative;

                    }
                    this.txt_represennt.Enabled = false;

                    if (rs.Fullname != null)
                    {
                        this.txt_chananame.Text = rs.Fullname;

                    }
                    this.txt_chananame.Enabled = false;

                    if (rs.HouseNo != null)
                    {
                        this.txt_houseno.Text = rs.HouseNo;

                    }
                    this.txt_houseno.Enabled = false;

                    if (rs.Province != null)
                    {
                        this.txt_provicen.Text = rs.Province;

                    }
                    this.txt_provicen.Enabled = false;

                    if (rs.District != null)
                    {
                        this.txt_district.Text = rs.District;
                    }
                    this.txt_district.Enabled = false;

                    if (rs.VATregistrationNo != null)
                    {
                        txtVATno.Text = rs.VATregistrationNo;

                    }
                    txtVATno.Enabled = false;



                    this.txt_remarkstt.Text = rs.Remarks;


                    this.txt_remarkstt.Enabled = false;



                    txtinfor.Visible = true;
                    //          MessageBox.Show("Are you sure to change status of contract ?", "Thông báo" ,MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    txtinfor.Text = "Create by: " + rs.CRDUSR + ", Update by: " + rs.UPDUSR;

                    //        Model.Username used = new Model.Username();

                    if (formlabel == "ENTRY SCREEN DISPLAY CONTRACT")
                    {
                        //   this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
                        this.cb_contractstatus.Text = rs.Consts;
                        //  this.cb_contractstatus.Enabled = false;
                        this.bt_etcontract.Visible = true;



                        if (used.inputcontractfinalcontrol == true)
                        {


                            undogroup.Visible = true;

                            undogroup.Enabled = true;
                            // bt_fin.Visible = true;
                            bt_finundo.Visible = true;
                            bt_cancel.Visible = true;
                            bt_close.Visible = true;
                            btchangensrcomit.Visible = true;
                            btchangevolcomit.Visible = true;
                            btchangeRemark.Visible = true;
                            btchangecontrcatype.Visible = true;
                            btchangeregion.Visible = true;


                            btchanegcontract.Visible = true;

                            btchangecret.Visible = true;
                            btchangecret.Visible = true;
                            btcfromdate.Visible = true;
                            btchagetodate.Visible = true;


                            btrepresent.Visible = true;
                            btchangetradename.Visible = true;
                            bthomeso.Visible = true;
                            btchangedistric.Visible = true;
                            btchangeprovince.Visible = true;
                            btvatchange.Visible = true;


                            bt_undoclose.Visible = true;
                            bt_undocancel.Visible = true;



                        }
                        else
                        {
                            undogroup.Visible = false;
                        }
                        // undogroup

                    }
                    else
                    {
                        this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
                        this.cb_contractstatus.Text = rs.Consts;
                        this.cb_contractstatus.Enabled = false;
                        this.bt_etcontract.Visible = false;
                    }


                    #endregion

                    if (formlabel == "DISPLAY PAYMENT CONTRACT")
                    {

                        btchangecontractitem.Visible = false;
                        btaddnewItem.Visible = false;

                    }   // formlabel == "DISPLAY PAYMENT CONTRACT"


                    loadtotaldContractView(ContractNoin);

                    loadDetailContractView(ContractNoin);






                    undogroup.Visible = true;

                    //           Model.Username used = new Model.Username();
                    if (used.inputcontractfinalcontrol == true)
                    {


                        undogroup.Visible = true;

                        undogroup.Enabled = true;
                        // bt_fin.Visible = true;
                        bt_finundo.Visible = true;
                        bt_cancel.Visible = true;
                        bt_close.Visible = true;
                        btchangensrcomit.Visible = true;
                        btchangevolcomit.Visible = true;
                        btchangeRemark.Visible = true;

                        btchangecontrcatype.Visible = true;
                        btchangeregion.Visible = true;

                        btchanegcontract.Visible = true;
                        btchangecret.Visible = true;
                        btrepresent.Visible = true;
                        btchangetradename.Visible = true;
                        bthomeso.Visible = true;
                        btchangedistric.Visible = true;
                        btchangeprovince.Visible = true;
                        btvatchange.Visible = true;




                        bt_undoclose.Visible = true;
                        bt_undocancel.Visible = true;


                    }
                    else
                    {
                        undogroup.Enabled = false;
                    }
                    //    undogroup
                    if (cb_contractstatus.Text == "CRT")
                    {

                        bt_fin.Visible = true;
                        btdelete.Enabled = true;

                    }
                }
                #endregion view

                // addcombound






                var rs2 = from tbl_Kapriod in dc.tbl_Kapriods
                              //  group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_Kapriod;

                string drowdownshow = "";

                foreach (var item in rs2)
                {
                    drowdownshow = item.Priod;
                    cb_priod.Items.Add(drowdownshow);
                    cb_priod2.Items.Add(drowdownshow);

                }


            }

            #endregion


            #endregion



        }




        private void bindDataToDataGridViewComboPrograme()
        {
            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            //  dataGridProgramdetail.Columns["Program"].
            // List<String> itemCodeList = new List<String>();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //  CombomCollection = null;
            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            var rs = from tbl_kaprogramlist in dc.tbl_kaprogramlists
                     orderby tbl_kaprogramlist.Name
                     select tbl_kaprogramlist;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.Code;
                cb.Text = item.Code.Trim() + ": " + item.Name;
                CombomCollection.Add(cb);
            }
            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Program";
            cmbdgv.Name = "Program";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 100;
            cmbdgv.DropDownWidth = 180;
            dataGridProgramdetail.Columns.Add(cmbdgv);

        }
        private void bindDataToDataGridViewComboPayment_Control()
        {
            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            //  dataGridProgramdetail.Columns["Program"].
            // List<String> itemCodeList = new List<String>();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //  CombomCollection = null;
            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            var rs = from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
                     orderby tbl_Kafuctionlist.Code
                     select tbl_Kafuctionlist;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.Code;
                cb.Text = item.Code + ": " + item.Description + "    || Example: " + item.Example;
                CombomCollection.Add(cb);
            }
            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Payment_Control";
            cmbdgv.Name = "Payment_Control";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 300;
            cmbdgv.DropDownWidth = 800;

            dataGridProgramdetail.Columns.Add(cmbdgv);

        }

        private void bindDataToDataGridViewComboproductgroup_Control()
        {
            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            //  dataGridProgramdetail.Columns["Program"].
            // List<String> itemCodeList = new List<String>();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //  CombomCollection = null;
            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            var rs = from tbl_kaPrdgrp in dc.tbl_kaPrdgrps
                     orderby tbl_kaPrdgrp.PrdGrp
                     select tbl_kaPrdgrp;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.PrdGrp;
                cb.Text = item.PrdGrp + ": " + item.ProductGroup;// + "- Exp : " + item.Example;
                CombomCollection.Add(cb);
            }
            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Product Group";
            cmbdgv.Name = "Product_Group";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 70;
            cmbdgv.DropDownWidth = 200;

            dataGridProgramdetail.Columns.Add(cmbdgv);

        }


        //  cmbdgv.Items.Add("Test");


        void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));

        }
        ComboBox cbm;
        DataGridViewCell currentCell;

        public CreatenewContract formcreatCtract { get; private set; }

        //  private DateTimePicker cellDateTimePicker = new DateTimePicker();
        // DateTimePicker[] sp = new DateTimePicker[100];
        void EndEdit()
        {




            if (cbm != null)
            {
                if (cbm.SelectedItem != null)
                {
                    string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                    // int i = dataGridProgramdetail.CurrentRow.Index;
                    int i = currentCell.RowIndex;
                    string colname = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].Name;

                    dataGridProgramdetail.Rows[i].Cells[colname].Value = SelectedItem;
                    //      MessageBox.Show(dataGridProgramdetail.Rows[i].Cells["Program"].Value.ToString());

                }





            }


            //}
        }

        private void dataGridProgramdetail_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {

                cbm = (ComboBox)e.Control;

                if (cbm != null)
                {
                    cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
                }

                currentCell = this.dataGridProgramdetail.CurrentCell;

            }
        }

        private void dataGridProgramdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {





        }

        private void dataGridProgramdetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string colname = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].Name;

            //  MessageBox.Show(colname);
            if (colname == "Program")
            {
                if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
                {
                    string programe = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();

                    #region pdis programe


                    if (programe.Trim() == "DIS")  //     discount on invocie
                    {
                        //   MessageBox.Show(programe);
                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.ForeColor = Color.Blue;

                        if (dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value == null || dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
                        {
                            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value = "DIS";
                        }

                        #region viewdetail
                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "";

                        #endregion view detail


                        #endregion nomale all


                    }
                    #endregion




                }

            }


            #region control_payment


            if (colname == "Payment_Control")
            {

                if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
                {

                    string paymentcontrol = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value.ToString();


                    #region payment type DIs


                    if (paymentcontrol == "DIS")
                    {
                        //if (dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value == null || dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value.ToString().Trim() != "DIS")
                        //{
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value = "DIS";
                        //}


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "";

                    }
                    #endregion


                    #region payment type  C00  tra khong dieu kien


                    if (paymentcontrol == "C00")
                    {

                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;


                    }
                    #endregion



                    #region payment type  NT1  tra khong dieu kien


                    if (paymentcontrol == "NT1")
                    {

                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;





                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = true;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;


                    }
                    #endregion






                    #region payment type  C01 //- tra bao nhieu do vao ngay co dinh


                    if (paymentcontrol == "C01")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;

                    }
                    #endregion



                    #region payment type  C02  - dat bao nhieu phan tram doanh so


                    if (paymentcontrol == "C02")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                                                                                                                                    //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion


                    #region payment type  C03  - dat doanh so krt thung


                    if (paymentcontrol == "C03")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;




                    }
                    #endregion


                    #region payment type  C04  - dat so doanh thu thi tra tien


                    if (paymentcontrol == "C04")
                    {

                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;
                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion



                    #region payment type  C05 //- tra bao nhieu do vao ngay co dinh


                    if (paymentcontrol == "C05")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




                    }
                    #endregion


                    #region payment type  C06  - dat bao nhieu phan tram doanh so


                    if (paymentcontrol == "C06")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                                                                                                                                    //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                    //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion


                    #region payment type  C07  - tra a%so tien  neu dat a% NSR comnit la bao nhieu do


                    if (paymentcontrol == "C07")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "VND";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                                                                                             //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "VND";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion





                    #region payment type  D01  - Trả theo két thùng bán được


                    if (paymentcontrol == "D01")
                    {



                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




                    }
                    #endregion

                    #region payment type  D02  - Trả theo két thùng bán được


                    if (paymentcontrol == "D02")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "LITTER";
                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




                    }
                    #endregion

                    #region payment type  D03  - Trả theo pc


                    if (paymentcontrol == "D03")
                    {

                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "KÉT";
                        // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;

                    }
                    #endregion


                    #region payment type  P00  tra khong dieu kien


                    if (paymentcontrol == "P00")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;// System.DBNull.Value;
                                                                                                           //    dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                                                                                                           //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;



                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




                    }
                    #endregion


                    #region payment type  P01  tra khong dieu kien


                    if (paymentcontrol == "P01")
                    {



                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;





                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;// System.DBNull.Value;
                                                                                                           //    dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                                                                                                           //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




                    }
                    #endregion


                    #region payment type  P02  - tra %nsr neu dat NSR la bao nhieu do


                    if (paymentcontrol == "P02")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "VND";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion


                    #region payment type  P03  - dat bao nhieu phan tram doanh so tra thepo % NSR


                    if (paymentcontrol == "P03")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion



                    #region payment type  P04  - tra %nsr neu dat NSR la bao nhieu with limited


                    if (paymentcontrol == "P04")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "VND";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion


                    #region payment type  P05  - dat bao nhieu phan tram doanh so tra thepo % NSR with limnited


                    if (paymentcontrol == "P05")
                    {


                        #region nomal all
                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

                        //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Limited"].ReadOnly = false;




                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

                        //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


                        //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


                        #endregion nomale all


                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Value = System.DBNull.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].Style.ForeColor = Color.DarkGray;
                        ////dataGridProgramdetail.Rows[e.RowIndex].Cells["ExtCondition"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

                        string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                        if (!Utils.IsValidnumber(txtvaluevolumecommit))
                        {
                            txtvaluevolumecommit = "0";
                        }
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
                                                                                                                                    //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
                                                                                                                                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


                        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



                    }
                    #endregion







                }

            }

            #endregion control payment




        }

        private void dataGridViewtotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewtotal.Rows[e.RowIndex].Cells["Programe"].Value.ToString() == "Total")
            { // condition


                e.CellStyle.BackColor = Color.LightSteelBlue;
                e.CellStyle.ForeColor = Color.OrangeRed;


            }
        }

        private void cb_customerka_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = cb_customerka.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                string username = Utils.getusername();

                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();


                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && tbl_KaCustomer.SapCode == true
                             && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                               ).Contains(tbl_KaCustomer.SalesOrg)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                //  string region = viewtb.region;


                if (codetemp != "0" && codetemp != null)
                {
                    cb_customerka.Text = codetemp;
                    cb_customerka.Enabled = false;
                    //     txtcustgroup.Text = "";
                    txtfindsacode.Text = "";
                    cbcust.Checked = true;
                    //          cbgroup.Checked = false;
                    cbsfa.Checked = false;



                }
                else
                {
                    cb_customerka.Text = "";
                    cb_customerka.Enabled = true;
                    cbcust.Checked = false;

                }



            }



        }

        private void cb_delivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = cb_delivery.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.Customer.ToString().Contains(valueinput) && (tbl_KaCustomer.SapCode == true)
                             && (from Tka_RegionRight in dc.Tka_RegionRights
                                 select Tka_RegionRight.Region).Contains(tbl_KaCustomer.SalesOrg)

                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  delivery code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;

                if (codetemp != "0" && codetemp != null)
                {
                    cb_delivery.Text = codetemp;
                    cb_delivery.Enabled = false;
                    //  cb_customerka.Text = "";
                    //  txtfindsacode.Text = "";

                    //   cbcust.Checked = false;
                    //    cbgroup.Checked = true;
                    //    cbsfa.Checked = false;
                    //



                }
                else
                {
                    cb_delivery.Text = "";
                    cb_delivery.Enabled = true;
                    //   cbgroup.Checked = false;

                }


                txt_volumecomit.Focus();
            }





        }

        private void cb_customerka_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cb_customerka_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void cb_customerka_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_channel.Focus();




            }
        }

        private void cb_channel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_delivery.Focus();




            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //  bt_creatnewcontract.Enabled = false;

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            tbl_kacontractdata newcontract = new tbl_kacontractdata();
            // newcontract = null;
            Boolean checkcontract = true;



            #region kiểm tra contract có dublicate ??
            if (this.tb_contractno.Text != null)
            {


                string ContractNo = this.tb_contractno.Text.Trim();

                var rs = (from tbl_kacontractmasterdata in dc.tbl_kacontractdatas
                          where tbl_kacontractmasterdata.ContractNo == ContractNo
                          select tbl_kacontractmasterdata.ContractNo).FirstOrDefault();

                if (rs != null)
                {
                    MessageBox.Show("Contract No. existed, please check ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkcontract = false;
                    newcontract = null;
                    return;
                }

            }

            #endregion

            #region  update data   check

            #region  // customer tyoe

            newcontract.Customer = 0;

            if (this.cbcust.Checked == true)
            {
                try
                {
                    newcontract.Customer = double.Parse(cb_customerka.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
                    newcontract.CustomerType = "SAP";

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Code khách hàng update sai, please check ! \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkcontract = false;
                    newcontract = null;
                    return;


                }


            }




            if (this.cbsfa.Checked == true)
            {
                try
                {
                    newcontract.Customer = double.Parse(txtfindsacode.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
                    newcontract.CustomerType = "SFA";

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Code SFA upate sai, please check ! \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkcontract = false;
                    newcontract = null;
                    return;

                }


            }


            if (newcontract.Customer == 0)
            {
                MessageBox.Show("Please select a Customer ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }


            #endregion

            #region cac nut



            // nếu không duplicate thì tiết hành add new contract
            if (this.cb_channel.SelectedItem != null)
            {
                //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                newcontract.Channel = (cb_channel.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Please select a Chanel ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //     tbl_kacontractsdatadetaillist = null;
                //     newcontract = null;
                checkcontract = false;
                newcontract = null;
                return;
            }



            if (this.cb_contractstatus.SelectedItem != null)
            {
                newcontract.Consts = this.cb_contractstatus.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Contract status ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    tbl_kacontractsdatadetaillist = null;
                //    newcontract = null;
                checkcontract = false;
                newcontract = null;
                return;
            }



            if (this.tb_contractno.Text != "")
            {
                newcontract.ContractNo = this.tb_contractno.Text.Trim();

            }
            else
            {
                MessageBox.Show("Please input Contract No. ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }

            if (this.cb_contracttype.SelectedItem != null)
            {
                newcontract.ConType = this.cb_contracttype.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a Contract Type ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }

            string usrname = Utils.getusername();


            if (this.cb_curency.SelectedItem != null)
            {
                newcontract.Currency = this.cb_curency.SelectedItem.ToString();
            }
            else
            {

                MessageBox.Show("Please check Currency ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }



            if (this.txt_represennt.Text != "")
            {
                newcontract.Representative = this.txt_represennt.Text;
            }
            else
            {
                //  MessageBox.Show("Please update Representative !  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //  return;

                newcontract.Representative = "";

            }


            // txt_chananame


            if (this.txt_chananame.Text != "")
            {
                newcontract.Fullname = this.txt_chananame.Text;
            }
            else
            {
                MessageBox.Show("Please update Trade Name !  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }

            if (tb_creditlimit.Text != "" && tb_creditlimit.Text != null)
            {

                string txtvaluetb_creditlimit = (tb_creditlimit.Text.Replace(",", "")).Replace(".", "");

                if (Utils.IsValidnumber(txtvaluetb_creditlimit))
                {
                    newcontract.CreditLimit = double.Parse(txtvaluetb_creditlimit);
                }
                else
                {


                    MessageBox.Show("Please check credit limit number !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkcontract = false;
                    newcontract = null;
                    return;

                }

            }
            else
            {
                newcontract.CreditLimit = 0;
            }



            if (this.cb_paymentterm.SelectedItem != null)
            {
                newcontract.CreditTerm = this.cb_paymentterm.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select credit term ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }

            //      newcontract.FullName = txt_chananame.Text;
            //  cb_delivery
            if (this.cb_delivery.SelectedItem != null)
            {
                newcontract.DeliveredBy = (cb_delivery.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }


            //   newcontract.SalesOrg = cb_salesogr
            if (this.cb_salesogr.SelectedItem != null)
            {
                newcontract.SalesOrg = this.cb_salesogr.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please check Sales Org ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }


            double volcom = 0;
            if (txt_volumecomit.Text != "" && txt_volumecomit.Text != null)
            {

                string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

                if (Utils.IsValidnumber(txtvaluetxt_volumecomit))
                {
                    newcontract.VolComm = double.Parse(txtvaluetxt_volumecomit);
                    volcom = double.Parse(txtvaluetxt_volumecomit);
                }
                else
                {
                    // txt_volumecomit.Text = "0";
                    //    newcontract.VolComm = 0;
                    MessageBox.Show("Please check Commitment volume ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkcontract = false;
                    newcontract = null;
                    return;
                }

            }
            //   ''----------------------------'

            //   newcontract.VolPer
            if (NSRcommit.Text != "" && NSRcommit.Text != null)
            {
                string txtvaluensrcomit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");


                if (Utils.IsValidnumber(txtvaluensrcomit))
                {
                    //         newcontract.VolComm = double.Parse(txtvaluetxt_volumecomit);
                    //  volcom = double.Parse(txtvaluetxt_volumecomit);

                    newcontract.NSRComm = double.Parse(txtvaluensrcomit);

                }
                else
                {
                    // txt_volumecomit.Text = "0";
                    //    newcontract.VolComm = 0;
                    MessageBox.Show("Please check NSRComm Commit ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkcontract = false;
                    newcontract = null;
                    return;
                }


            }






            //=======================
            int varyear = 1;

            try
            {
                //    varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
                varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

                if (varyear <= 0)
                {

                    varyear = 1;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Please check Eff and EFT date ! " + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;


            }
            //   newcontract.ConTerm = int.Parse(txt_term.Text);
            this.txt_term.Text = varyear.ToString();
            newcontract.ConTerm = varyear;//int.Parse(txt_term.Text);






            if (Utils.IsValidnumber(txt_volumecomit.Text))
            {


                #region load term and yeayr  


                this.txt_annualvolume.Text = (volcom / varyear).ToString();
                newcontract.AnnualVolume = volcom / varyear;
                #endregion

            }




            if (this.txt_district.Text != "")
            {
                newcontract.District = this.txt_district.Text;//.ToString();
            }
            else
            {
                MessageBox.Show("Please check District ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }


            if (this.txt_provicen.Text != "")
            {
                newcontract.Province = this.txt_provicen.Text;//.ToString();
            }
            else
            {
                MessageBox.Show("Please check Province ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }


            if (this.txt_houseno.Text != "")
            {
                newcontract.HouseNo = this.txt_houseno.Text;//.ToString();
            }
            else
            {
                MessageBox.Show("Please check House No ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkcontract = false;
                newcontract = null;
                return;
            }

            #endregion cacs nut 




            #region kiem tra va updaate dataGridProgramdetail vao detail

            //  dataGridProgramdetail
            //  newdetailContract

            List<tbl_kacontractsdatadetail> tbl_kacontractsdatadetaillist = new List<tbl_kacontractsdatadetail>();




            for (int idrow = 0; idrow < dataGridProgramdetail.RowCount - 1; idrow++)
            {


                #region product group type


                tbl_kacontractsdatadetail newdetailContract = new tbl_kacontractsdatadetail();
                newdetailContract.Customercode = newcontract.Customer;//double.Parse(cb_customerka.Text);// (cbm.SelectedItem as ComboboxItem).Value.ToString();
                newdetailContract.CustomerType = newcontract.CustomerType;

                if ((String)dataGridProgramdetail.Rows[idrow].Cells["Program"].Value != null)
                {
                    newdetailContract.PayType = dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim(); // chính la program
                }
                else
                {
                    MessageBox.Show("Please check Program ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                if ((String)dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value != null)
                {
                    newdetailContract.PayControl = dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString();
                    var rsDescription = (from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
                                         where tbl_Kafuctionlist.Code == newdetailContract.PayControl
                                         select tbl_Kafuctionlist).FirstOrDefault();
                    if (rsDescription != null)
                    {
                        newdetailContract.Description = rsDescription.Code + ": " + rsDescription.Description;
                    }

                }
                else
                {
                    MessageBox.Show("Please check Payment_Control ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                newdetailContract.ContractNo = this.tb_contractno.Text.Trim();
                newdetailContract.VATregistrationNo = this.txtVATno.Text.Trim();

                if (dataGridProgramdetail.Rows[idrow].Cells["Product_Group"].Value != null)
                {

                    newdetailContract.PrdGrp = dataGridProgramdetail.Rows[idrow].Cells["Product_Group"].Value.ToString();

                }
                else
                {
                    MessageBox.Show("Please check Product_Group ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                #endregion product group type

                //condition Cells["Payment_Control"].Value.ToString() == "C00"



                #region //condition Cells["Payment_Control"].Value.ToString() == "DIS"

                if (dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim() != "DIS" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString().Trim() == "DIS")
                {

                    MessageBox.Show("Please check Program line: " + (idrow + 1) + "must be DIS", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;
                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim() == "DIS" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
                {

                    MessageBox.Show("Please check Payment_Control line: " + (idrow + 1) + "must be DIS", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;
                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {


                    MessageBox.Show("Please check Amount_Per_Pc_Lit_FTN and  Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {

                    newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                    dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value = cb_curency.Text;



                }

                if ((dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "") && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {

                    //     newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value = "%";


                }

                if ((dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "") && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {

                    //     newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }





                #endregion



                #region //condition Cells["Payment_Control"].Value.ToString() == "C00"

                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C00")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                  
                    if (newdetailContract.SponsoredAmt >= 20000000 && this.cb_contracttype.SelectedItem.ToString() == "ASMPQ")
                    {

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

                                tbl_kacontractsdatadetaillist = null;
                                newcontract = null;
                                checkcontract = false;
                                return;






                               // break;
                            default:
                                break;
                        }




                    }


                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C00")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }











                #endregion


                //condition Cells["Payment_Control"].Value.ToString() == "C01"

                #region //condition Cells["Payment_Control"].Value.ToString() == "C01"

                if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
                {

                    newdetailContract.CommittedDate = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
                {
                    MessageBox.Show("Please check Payment Date line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }





                #endregion

                //C02


                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02"


                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
                    {
                        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
                    }
                    else
                    {
                        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }



                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion


                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03"


                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {

                    newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //       newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04"


                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {

                    newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion



                #region //condition Cells["Payment_Control"].Value.ToString() == "C05"



                //}

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }



                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }




                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06"


                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {
                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06" && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value <= 0)
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }





                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }
                //    else
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //  newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion




                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07"


                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {

                    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {
                    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {

                    newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {
                    MessageBox.Show("Please check NSR Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C07")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion




                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01"

                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {
                    MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion


                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02"

                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {
                    MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //      newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03"

                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {
                    MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00"
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //        newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {
                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;
                }


                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01"
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---



                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {

                    newdetailContract.CommittedDate = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
                {
                    MessageBox.Show("Please check Payment Date line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                if (dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value != null)
                {

                    if (dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value != DBNull.Value)
                    {
                        newdetailContract.TargetUnit = (String)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value.ToString().Trim();
                    }

                }




                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02"


                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---



                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{

                //    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                //}
                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{
                //    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{
                //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
                //    {
                //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;

                //    }

                //}

                //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{
                //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}



                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion


                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03"


                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    return;

                }
                //---



                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{

                //    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                //}
                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{
                //    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                //{
                //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
                //    {
                //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;

                //    }

                //}

                //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                //{
                //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}



                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion



                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04"


                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }
                //---



                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{

                //    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

                //}
                //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                //{
                //    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}


                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }
            //    SponsoredLimited

           //     if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value > 0)
                    {
                        newdetailContract.SponsoredLimited = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Sponsored_Limited must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Sponsored_Limited line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }



                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion


                #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05"


                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {
                    //newdetailContract.SponsoredAmtperPC
                    newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
                    if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
                    {
                        MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        return;


                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {
                    MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    return;

                }
                //---

                //    SponsoredLimited

                //     if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value > 0)
                    {
                        newdetailContract.SponsoredLimited = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Sponsored_Limited must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Limited"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P04")
                {
                    MessageBox.Show("Please check Sponsored_Limited line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }



                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {

                    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
                    {
                        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbl_kacontractsdatadetaillist = null;
                        newcontract = null;
                        checkcontract = false;
                        return;

                    }
                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {
                    MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;



                }


                //if  zxczxc123*    (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                //{
                //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
                //    {
                //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;

                //    }

                //}

                //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
                //{
                //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;



                //}



                //---
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {

                    newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

                }
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {
                    MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }

                //--
                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {

                    newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

                }

                if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P05")
                {
                    MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;

                }


                //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



                #endregion





                newdetailContract.CRDDAT = DateTime.Today;
                newdetailContract.CRDUSR = Utils.getusername();

                if (dataGridProgramdetail.Rows[idrow].Cells["Remark"].Value.ToString().Length < 225)
                {
                    newdetailContract.Remark = dataGridProgramdetail.Rows[idrow].Cells["Remark"].Value.ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Please check Remarks line: " + (idrow + 1) + " is Too Long", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    return;
                }


                newdetailContract.SALORG_CTR = Utils.getfirstusersalescontrolregion();
                newdetailContract.SalesOrg = this.cb_salesogr.SelectedItem.ToString();
                newdetailContract.Constatus = "CRT";
                newdetailContract.Fullname = this.txt_chananame.Text;
                newdetailContract.ConType = this.cb_contracttype.SelectedItem.ToString().Trim();
                newdetailContract.CustomerType = newcontract.CustomerType;
                newdetailContract.Address = this.txt_houseno.Text.Trim() + " " + txt_district.Text.Trim() + " " + txt_provicen.Text.Trim();


                if (dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value != null)
                {
                    if (dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value != DBNull.Value)
                    {
                        newdetailContract.SponsorUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value.ToString().Trim();
                    }


                }



                if (dataGridProgramdetail.Rows[idrow].Cells["ExtCondition"].Value.ToString() != "")
                {
                    newdetailContract.ExtCondition = true;

                    newdetailContract.ExtNote = (string)dataGridProgramdetail.Rows[idrow].Cells["ExtNote"].Value.ToString().Trim();
                }
                else
                {
                    newdetailContract.ExtCondition = false;
                    newdetailContract.ExtNote = "";// (string)dataGridProgramdetail.Rows[idrow].Cells["ExtNote"].Value.ToString().Trim();
                }



                tbl_kacontractsdatadetaillist.Add(newdetailContract);

                //dc.tbl_kacontractsdatadetails.InsertOnSubmit(newdetailContract);




            }







            #endregion

            #region  check hop dong và contract type

            string kq = Utils.IsValidContractName(tb_contractno.Text, cb_salesogr.Text, cb_contracttype.Text, cb_channel.Text);


            if (kq == "OK")
            {
                //    MessageBox.Show("OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                newcontract.ContractNo = tb_contractno.Text;

            }
            else
            {
                MessageBox.Show("Wrong struct of Contract No, it must be: " + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //   tbl_kacontractsdatadetaillist = null;
                checkcontract = false;
                newcontract = null;
                return;

                //newcontract = null;
                //checkcontract = false;
                //return;
            };


            #endregion

            if (tbl_kacontractsdatadetaillist.Count > 0)
            {




                //   double contractno = double.Parse(this.tb_contractno.Text.Trim());
                newcontract.VATregistrationNo = txtVATno.Text.Trim();
                newcontract.CRDUSR = usrname;
                newcontract.SignOn = dateTimePicker1.Value;
                newcontract.CRDDAT = DateTime.Today;

                if (this.txt_remarkstt.Text.Length < 255)
                {

                    newcontract.Remarks = this.txt_remarkstt.Text;

                }
                else
                {

                    MessageBox.Show("Remarks is too long, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;
                }

                newcontract.EffDate = this.dateTimePicker1.Value;
                newcontract.EftDate = this.dateTimePicker2.Value;
                newcontract.ExtDate = this.dateTimePicker3.Value;
                if (this.dateTimePicker1.Value > this.dateTimePicker2.Value || this.dateTimePicker2.Value > this.dateTimePicker3.Value)
                {
                    MessageBox.Show("Please check fromdate/ todate/ extendate!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    checkcontract = false;
                    return;
                }


                if (checkcontract == false)
                {
                    tbl_kacontractsdatadetaillist = null;
                    newcontract = null;
                    return;
                }


                newcontract.SALORG_CTR = Utils.getfirstusersalescontrolregion();
                dc.tbl_kacontractsdatadetails.InsertAllOnSubmit(tbl_kacontractsdatadetaillist);
                dc.SubmitChanges();
                //  newdetailContract.


                //






                dc.tbl_kacontractdatas.InsertOnSubmit(newcontract);
                dc.SubmitChanges();

                tbl_kacontractCustcode cust = new tbl_kacontractCustcode();
                cust.ContractNo = tb_contractno.Text.Trim();

                if (cb_customerka.Text != "")
                {
                    cust.CustomerCode = double.Parse(cb_customerka.Text.Trim()); //newcontract.Customer;
                }


                dc.tbl_kacontractCustcodes.InsertOnSubmit(cust);
                dc.SubmitChanges();



                MessageBox.Show("Contract " + tb_contractno.Text + " create done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //-------------
                #region  changr display 


                cb_customerka.Enabled = true;
                // txtcustgroup.Enabled = true;
                txtfindsacode.Enabled = true;
                txtVATno.Text = "";

                contractdata.Add(tb_contractno.Text);
                // AD VAO SERVER DE LAM LAN SAU
                //contractautolist
                string username = Utils.getusername();
                tbl_autodataContract newauto = new tbl_autodataContract();
                newauto.ContractNo = tb_contractno.Text;
                newauto.Username = username;


                dc.tbl_autodataContracts.InsertOnSubmit(newauto);
                dc.SubmitChanges();
                //
                tbl_kacontractsdatadetaillist = null;
                newcontract = null;
                //     data.Add("Mac Jocky");
                //   data.Add("Millan Peter");
                // comboBox1.AutoCompleteCustomSource = data;
                tb_contractno.Text = "";
                //        tb_contractno.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tb_contractno.AutoCompleteCustomSource = contractdata;

                //AutoCompleteSource.ListItems;
                //     tb_contractno.
                cb_contracttype.SelectedIndex = -1;
                cb_salesogr.SelectedIndex = -1;
                cb_paymentterm.SelectedIndex = -1;
                cb_channel.SelectedIndex = -1;
                cb_customerka.Text = "";
                //txtcustgroup.Text = "";
                txtfindsacode.Text = "";
                txt_represennt.Text = "";
                txt_chananame.Text = "";
                txt_houseno.Text = "";

                txt_district.Text = "";

                txt_provicen.Text = "";
                cb_delivery.SelectedIndex = -1;
                txt_volumecomit.Text = "0";
                NSRcommit.Text = "0";
                txt_remarkstt.Text = "";
                txt_annualvolume.Text = "0";
                Nsaperyear.Text = "0";
                tb_creditlimit.Text = "0";



                loadDetaildContractcreatenew();

                //       panel1.Enabled = false;

                //                btupdatecontract.Visible = true;
                #endregion



            }
            else
            {
                tbl_kacontractsdatadetaillist = null;
                newcontract = null;
                MessageBox.Show("Please add detail contract !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion update datato masterdata



            //     bt_creatnewcontract.Enabled = true;

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
            if (varyear >= 0)
            {
                if (varyear == 0)
                {
                    varyear = 1;
                }


                this.txt_term.Text = varyear.ToString();


                string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                string txtvaluensrcomit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");

                #region load term and yeayr
                if (Utils.IsValidnumber(txt_volumecomit.Text) && Utils.IsValidnumber(txtvaluensrcomit))
                {
                    //this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();

                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvaluensrcomit) / double.Parse(txt_term.Text))).ToString();
                }
                #endregion

            }
            else
            {

                //     dateTimePicker1.Value = dateTimePicker2.Value;
                //   MessageBox.Show("Todate and Extdate must later Fromdate!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                varyear = 1;
                this.txt_term.Text = varyear.ToString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

            if (varyear == 0)
            {
                varyear = 1;
            }

            if (varyear >= 0)
            {

                this.txt_term.Text = varyear.ToString();


                #region load term and yeayr
                string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");

                if (Utils.IsValidnumber(txtvalueNSRcommit))
                {
                    //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    //    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();
                }
                else
                {
                    txtvalueNSRcommit = "0";
                    //this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();


                }


                if (Utils.IsValidnumber(txtvaluetxt_volumecomit))
                {
                    //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    //     this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();
                }
                else
                {
                    txtvaluetxt_volumecomit = "0";
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;


                }
                #endregion




            }


        }

        private void txt_volumecomit_TextChanged_1(object sender, EventArgs e)
        {
            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            #region load term and yeayr
            if (Utils.IsValidnumber(txtvaluevolumecommit))
            {

                int varyear = 1;
                if (Utils.IsValidnumber(this.txt_term.Text))
                {


                    if (int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString()) != 0)
                    {
                        varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
                    }
                    else
                    {
                        varyear = 1;
                    }


                }
                else
                {
                    varyear = 1;
                }


                this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluevolumecommit) / double.Parse(txt_term.Text))).ToString();
                this.txt_term.Text = varyear.ToString();

            }
            #endregion




        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.Text == "Input Contract")
            {
                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    ///  KAcontractlisting
                    ///    if (frm.Text == "CreatenewContract")
                    if (frm.Text == "Creat New Customer")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {



                    View.CreatnewCust CreatnewCust = new View.CreatnewCust(this);


                    CreatnewCust.Show();
                }





            }




        }

        private void dataGridProgramdetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            //     bool kq = false;

            foreach (Form frm in fc)
            {


                if (frm.Text == "Payment request")
                {
                    //  kq = true;
                    frm.Close();

                }
            }



            if (this.Text == "Payment Input" && formlabel.Text == "DISPLAY PAYMENT CONTRACT")  // pahir la pay ment requyet mowi sduoc tra tien 
            {

                //string ContractNo = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["ContractNo"].Value;
                string ContractNo = tb_contractno.Text;
                int PayID = int.Parse(this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());

                Model.Username used = new Model.Username();

                if (used.paymentcreate)
                {
                    View.Createpayment Createpayment = new View.Createpayment(this, ContractNo, PayID);



                    Createpayment.ShowDialog();
                }


            }


        }

        private void dataGridProgramdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_channel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string ContractNo = this.tb_contractno.Text;


            //Control.Control_ac.CaculationContract(ContractNo);





            //loadtotaldContractView(ContractNo);
            //loadDetailContractView(ContractNo);







        }

        private void dataGridView7_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Payment control")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq && this.Text == "Payment Input")
            //        if (true)  // có queyefn view để duyệt thì hiện lên báo cáo view duyet
            {
                string connection_string = Utils.getConnectionstr();


                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);

                string ContractNo = tb_contractno.Text;
                int PayID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());

                int SubID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["SubID"].Value.ToString());



                int BatchNo = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["BatchNo"].Value.ToString());


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
                           where tbl_kaprogramlist.Code != "DIS"
                           select tbl_kaprogramlist;

                foreach (var item in rss1)
                {

                    tbl_KAdetailprogrRpt detailrpt = new tbl_KAdetailprogrRpt();  //detail line
                    detailrpt.Programe = item.Name;
                    detailrpt.Username = username;
                    detailrpt.Remarks = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                         where tbl_kacontractsdatadetail.PayType.Trim() == item.Code.Trim() && tbl_kacontractsdatadetail.ContractNo == ContractNo && tbl_kacontractsdatadetail.PayID == PayID && tbl_kacontractsdatadetail.PayType != "DIS"
                                         select tbl_kacontractsdatadetail.Remark).FirstOrDefault();



                    var totaldetailrs = (from tbl_kacontractsdatadetail in db.tbl_kacontractsdatadetails
                                         where tbl_kacontractsdatadetail.PayType == item.Code && tbl_kacontractsdatadetail.ContractNo.Trim() == ContractNo.Trim()
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
                                                    where tbl_kacontractsdetailpayment.BatchNo == BatchNo && tbl_kacontractsdetailpayment.ContractNo == ContractNo && tbl_kacontractsdetailpayment.PayType == item.Code && tbl_kacontractsdetailpayment.DoneOn == null
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
                                    where tbl_kacontractdata.ContractNo == ContractNo
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
                    requestmaster.Note = itemmasterKA.Remarks;
                    //      requestmaster.ProductGroup = itemmasterKA.PrdGrp;
                    requestmaster.Representative = itemmasterKA.Representative;
                    requestmaster.SalesOrg = itemmasterKA.SalesOrg;
                    requestmaster.Street = itemmasterKA.HouseNo;
                    // requestmaster.SupportCase
                    requestmaster.TermYear = (itemmasterKA.EftDate.Value.Year - itemmasterKA.EffDate.Value.Year);
                    requestmaster.TradeName = itemmasterKA.Fullname;
                    requestmaster.ReferrenceDoc = BatchNo.ToString();
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
                    Reportsview rpt = new Reportsview(dataset1, dataset2, "PaymentRequest.rdlc", BatchNo, ContractNo, formcreatCtract);
                    rpt.ShowDialog();

                }

                #endregion view reports payment request  // 



            }





            if (!kq && this.Text == "Input Contract")  // pahir la pay ment requyet mowi sduoc tra tien 
                                                       //     if (!kq)
            {

                //string ContractNo = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["ContractNo"].Value;
                string ContractNo = tb_contractno.Text;
                int PayID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());

                int SubID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["SubID"].Value.ToString());



                int BatchNo = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["BatchNo"].Value.ToString());
                string Programe = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PayControlID"].Value.ToString();

                string Description = "";
                if (this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["Description"].Value != null)
                {
                    Description = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["Description"].Value.ToString();
                }


                string PaymentDoc = "";
                if (this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaymentDoc"].Value != null)
                {
                    PaymentDoc = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaymentDoc"].Value.ToString();
                }

                double PaidRequestAmt = double.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaidRequestAmt"].Value.ToString());
                //     public string header { get; set; }





                //        //   public string header { get; set; }
                //public kaconfirmPayment(View.CreatenewContract Contract, string ContractNo, string Batchno, string Programe, int PayID, int SubID, double PaidRequestAmt)
                //{
                if (PaidRequestAmt >= 0)
                {

                    Model.Username used = new Model.Username();

                    if (used.inputcontractconfirm)
                    {


                        View.kaconfirmPayment paymentconf = new View.kaconfirmPayment(this, ContractNo, BatchNo, Programe, PayID, SubID, PaidRequestAmt, Description, PaymentDoc);


                        paymentconf.Show();



                    }





                }

                //            dataGridView7.DefaultCellStyle.kac

            }


        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string contractno = tb_contractno.Text.Trim(); //111

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            // CaculationContract


            #region (tabControl1.SelectedIndex == 0 )  // nuew la volume
            if (tabControl1.SelectedIndex == 0 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
            {

                loadDetailContractView(contractno);


            }

            #endregion

            #region  new la tab1 và tạo hợp đồng mới
            if (tabControl1.SelectedIndex == 1 && formlabel.Text == "CREATING NEW CONTRACT")  // nuew la volume
            {






            }

            #endregion

            if (tabControl1.SelectedIndex == 1 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
            {

                #region  new la tab1 và display



                if (tabControl1.SelectedIndex == 1 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
                {

                    //              dataGriddiscountoninvoice.DataSource = dataGriddiscononinvocie;

                    var dataGriddiscononinvocie = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                                  where tbl_kacontractsdatadetail.ContractNo.Equals(contractno) && tbl_kacontractsdatadetail.PayControl == "DIS"
                                                  select new
                                                  {
                                                      Programe = tbl_kacontractsdatadetail.PayType.Trim(),
                                                      Description = tbl_kacontractsdatadetail.Description.Trim(),

                                                      Product_Group = tbl_kacontractsdatadetail.PrdGrp,

                                                      SponsorPercent = tbl_kacontractsdatadetail.FundPercentage,
                                                      SponsorByUnit = tbl_kacontractsdatadetail.SponsoredAmtperPC,

                                                      //        SponsorAmount = tbl_kacontractsdatadetail.SponsoredAmt,
                                                      Unit = tbl_kacontractsdatadetail.SponsorUnit,
                                                      Effect_From = tbl_kacontractsdatadetail.EffFrm,
                                                      Effect_To = tbl_kacontractsdatadetail.EffTo,
                                                      Remarks = tbl_kacontractsdatadetail.Remark,


                                                  };

                    dataGriddiscountoninvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    dataGriddiscountoninvoice.DataSource = dataGriddiscononinvocie;


                    //     this.dataGriddiscountoninvoice.Columns["Sponsor_Total"].DefaultCellStyle.Format = "N0";
                    //        this.dataGriddiscountoninvoice.Columns["PaidRequest"].DefaultCellStyle.Format = "N0";
                    //        this.dataGriddiscountoninvoice.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
                    this.dataGridProgramdetail.Columns["SponsorByUnit"].DefaultCellStyle.Format = "N0";
                    //this.dataGriddiscountoninvoice.Columns["SponsorAmount"].DefaultCellStyle.Format = "N0";
                    //       this.dataGriddiscountoninvoice.Columns["Target_Achivement"].DefaultCellStyle.Format = "N0";
                    //       this.dataGriddiscountoninvoice.Columns["Achivement"].DefaultCellStyle.Format = "N0";

                    //     this.dataGriddiscountoninvoice.Columns["Sponsor_Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    //        this.dataGriddiscountoninvoice.Columns["PaidRequest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    //       this.dataGriddiscountoninvoice.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    //        this.dataGriddiscountoninvoice.Columns["SponsorAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                    //      this.dataGriddiscountoninvoice.Columns["Achivement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                }
                #endregion
            }



            #region (tabControl1.SelectedIndex == 2)  // nuew la volume



            if (tabControl1.SelectedIndex == 2)  // nuew la volume
            {

                Control.Control_ac.VolumeupdateperContract(contractno);


                var rs1 = from tbl_kacontractsvolume in dc.tbl_kacontractsvolumes
                          where tbl_kacontractsvolume.ContractNo.Equals(contractno)
                          select new
                          {

                              PRIOD = tbl_kacontractsvolume.Priod,
                              PCs = tbl_kacontractsvolume.EC,
                              EC = tbl_kacontractsvolume.PC,
                              tbl_kacontractsvolume.UC,
                              tbl_kacontractsvolume.Litter,
                              //     tbl_kacontractsvolume.Net_value,
                              NSR = tbl_kacontractsvolume.NSR,




                          };


                //    dtg_volumeachived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dtg_volumeachived.DataSource = rs1;
                this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Format = "N0";
                this.dtg_volumeachived.Columns["PCs"].DefaultCellStyle.Format = "N0";
                this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Format = "N0";
                this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Format = "N0";
                //     this.dtg_volumeachived.Columns["Net_value"].DefaultCellStyle.Format = "N0";
                this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Format = "N0";

                //this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
                //this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";



                this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dtg_volumeachived.Columns["PCs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";





            }

            #endregion



            #region (tabControl1.SelectedIndex == 3)  // nuew la volume by grop







            if (tabControl1.SelectedIndex == 3)  // nuew la volume
            {
                Control.Control_ac.VolumeupdateperContractbyPRdgrp(contractno);

                var rs1 = from tbl_kacontractsvolumePrductGRP in dc.tbl_kacontractsvolumePrductGRPs
                          where tbl_kacontractsvolumePrductGRP.ContractNo.Equals(contractno)
                          orderby tbl_kacontractsvolumePrductGRP.Priod, tbl_kacontractsvolumePrductGRP.ProductGRP
                          select new
                          {
                              tbl_kacontractsvolumePrductGRP.Priod,
                              tbl_kacontractsvolumePrductGRP.ProductGRP,
                              PCs = tbl_kacontractsvolumePrductGRP.EC,
                              EC = tbl_kacontractsvolumePrductGRP.PC,
                              tbl_kacontractsvolumePrductGRP.UC,
                              tbl_kacontractsvolumePrductGRP.Litter,
                              //     tbl_kacontractsvolumePrductGRP.Net_value,
                              NSR = tbl_kacontractsvolumePrductGRP.NSR,



                          }; // tbl_kacontractsvolumePrductGRP;



                dtagrviewvolumebyGRP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dtagrviewvolumebyGRP.DataSource = rs1;

                this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Format = "N0";
                this.dtagrviewvolumebyGRP.Columns["PCs"].DefaultCellStyle.Format = "N0";
                this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Format = "N0";
                this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Format = "N0";
                this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Format = "N0";



                this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dtagrviewvolumebyGRP.Columns["PCs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            }

            #endregion


            #region (tabControl1.SelectedIndex == 4)  // nuew batchno
            if (tabControl1.SelectedIndex == 4)  // nuew la volume
            {


                #region loaddatagridview


                var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                               where tbl_kacontractsdetailpayment.ContractNo == contractno // && tbl_kacontractsdetailpayment.BatchNo == BatchNo
                                               group tbl_kacontractsdetailpayment by tbl_kacontractsdetailpayment.BatchNo into g
                                               select new
                                               {

                                                   BatchNo = g.Key,
                                                   Paid_Amount = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),// tbl_kacontractsdetailpayment.PaidAmt,
                                                   PaidRequestAmt = g.Sum(gg => gg.PaidRequestAmt).GetValueOrDefault(0),//   tbl_kacontractsdetailpayment.PaidRequestAmt,
                                                                                                                        // PaidConfAmt = g.Sum(gg => gg.PaidConfAmt).GetValueOrDefault(0),//   tbl_kacontractsdetailpayment.PaidRequestAmt,

                                                   PrintChk = g.Select(gg => gg.PrintChk).FirstOrDefault(),//        tbl_kacontractsdetailpayment.PrintChk,
                                                   Reprint = g.Select(gg => gg.Reprint).FirstOrDefault(),// tbl_kacontractsdetailpayment.Reprint,
                                                   PrintDate = g.Select(gg => gg.PrintDate).FirstOrDefault(),//   tbl_kacontractsdetailpayment.PrintDate,

                                                   CRDUSR = g.Select(gg => gg.CRDUSR).FirstOrDefault(),//  tbl_kacontractsdetailpayment.CRDUSR,
                                                   DoneOn = g.Select(gg => gg.DoneOn).FirstOrDefault(),//  tbl_kacontractsdetailpayment.CRDUSR,tbl_kacontractsdetailpayment.DoneOn,





                                               };

                dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

                dataGridView6.DataSource = dataGridProgramdetailrs7;

                this.dataGridView6.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
                this.dataGridView6.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";




                this.dataGridView6.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dataGridView6.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                #endregion







            }

            #endregion




            #region (tabControl1.SelectedIndex == 5)  // nuew la volume
            if (tabControl1.SelectedIndex == 5)  // nuew la volume
            {


                #region loaddatagridview
                if (Utils.IsValidnumber(cb_batchno.Text) == true)
                {
                    //  MessageBox.Show("Please check Batchno doc. " + this.txt_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    int BatchNo = int.Parse(cb_batchno.Text);
                    // return;
                }




                var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                               where tbl_kacontractsdetailpayment.ContractNo == contractno // && tbl_kacontractsdetailpayment.BatchNo == BatchNo
                                           && tbl_kacontractsdetailpayment.BatchNo != 0
                                               select new
                                               {

                                                   Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                                   PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                                   Paid_Note = tbl_kacontractsdetailpayment.PaidNote,
                                                   Description = tbl_kacontractsdetailpayment.Remark.Trim(),

                                                   Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                                   tbl_kacontractsdetailpayment.PaidRequestAmt,
                                                   //          PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                                   PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
                                                   tbl_kacontractsdetailpayment.DoneOn,

                                                   tbl_kacontractsdetailpayment.PrintChk,
                                                   tbl_kacontractsdetailpayment.Reprint,
                                                   tbl_kacontractsdetailpayment.PrintDate,

                                                   //        Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                                   tbl_kacontractsdetailpayment.BatchNo,
                                                   tbl_kacontractsdetailpayment.CRDDAT,
                                                   tbl_kacontractsdetailpayment.CRDUSR,



                                                   tbl_kacontractsdetailpayment.UPDDAT,
                                                   tbl_kacontractsdetailpayment.UPDUSR,
                                                   PayID = tbl_kacontractsdetailpayment.PayID,
                                                   SubID = tbl_kacontractsdetailpayment.SubID,



                                               };

                //    dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView7.DataSource = dataGridProgramdetailrs7;

                this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
                this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";
                // this.dtg_volumeachived.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";

                this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


                #endregion


                #region   loadcomoub
                cb_batchno.Items.Clear();

                var rsbactchno = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                 where tbl_kacontractsdetailpayment.ContractNo == contractno //&& tbl_kacontractsdetailpayment.BatchNo == BatchNo
                                 group tbl_kacontractsdetailpayment by tbl_kacontractsdetailpayment.BatchNo into g
                                 select g.Key;
                if (rsbactchno != null)
                {
                    foreach (var item in rsbactchno)
                    {
                        cb_batchno.Items.Add(item.ToString());
                    }
                }






                #endregion






            }

            #endregion





        }
        private void cb_priod_SelectedValueChanged(object sender, EventArgs e)
        {

            string contractno = tb_contractno.Text.Trim();
            string priod = cb_priod.Text;

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs1 = from tbl_kacontractsvolume in dc.tbl_kacontractsvolumes
                      where tbl_kacontractsvolume.ContractNo.Equals(contractno) && priod == tbl_kacontractsvolume.Priod
                      select new
                      {

                          tbl_kacontractsvolume.Priod,
                          tbl_kacontractsvolume.EC,
                          tbl_kacontractsvolume.PC,
                          tbl_kacontractsvolume.UC,
                          tbl_kacontractsvolume.Litter,
                          //   tbl_kacontractsvolume.Net_value,
                          NSR = tbl_kacontractsvolume.NSR,




                      };


            dtg_volumeachived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtg_volumeachived.DataSource = rs1;
            this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Format = "N0";
            this.dtg_volumeachived.Columns["PC"].DefaultCellStyle.Format = "N0";
            this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Format = "N0";
            this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Format = "N0";
            //    this.dtg_volumeachived.Columns["Net_value"].DefaultCellStyle.Format = "N0";
            this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Format = "N0";


            this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dtg_volumeachived.Columns["PC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";








        }

        private void cb_priod2_SelectedValueChanged(object sender, EventArgs e)
        {
            string contractno = tb_contractno.Text;
            string priod = cb_priod2.Text;

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = from tbl_kacontractsvolumePrductGRP in dc.tbl_kacontractsvolumePrductGRPs
                      where tbl_kacontractsvolumePrductGRP.ContractNo.Equals(contractno) && tbl_kacontractsvolumePrductGRP.Priod == priod
                      orderby tbl_kacontractsvolumePrductGRP.Priod, tbl_kacontractsvolumePrductGRP.ProductGRP
                      select new
                      {
                          tbl_kacontractsvolumePrductGRP.Priod,
                          tbl_kacontractsvolumePrductGRP.ProductGRP,
                          tbl_kacontractsvolumePrductGRP.EC,
                          tbl_kacontractsvolumePrductGRP.PC,
                          tbl_kacontractsvolumePrductGRP.UC,
                          tbl_kacontractsvolumePrductGRP.Litter,
                          //    tbl_kacontractsvolumePrductGRP.Net_value,
                          NSR = tbl_kacontractsvolumePrductGRP.NSR,



                      }; // tbl_kacontractsvolumePrductGRP;



            dtagrviewvolumebyGRP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtagrviewvolumebyGRP.DataSource = rs1;

            this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Format = "N0";
            this.dtagrviewvolumebyGRP.Columns["PC"].DefaultCellStyle.Format = "N0";
            this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Format = "N0";
            this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Format = "N0";
            //     this.dtagrviewvolumebyGRP.Columns["Net_value"].DefaultCellStyle.Format = "N0";
            this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Format = "N0";

            this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            this.dtagrviewvolumebyGRP.Columns["PC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

        }

        private void CreatenewContract_Activated(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {




        }

        private void cb_batchno_TextChanged(object sender, EventArgs e)
        {
            string contractno = tb_contractno.Text;
            string connection_string = Utils.getConnectionstr();

            if (Utils.IsValidnumber(cb_batchno.Text) == false)
            {
                //  MessageBox.Show("Please check Batchno doc. " + cb_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int BatchNo = int.Parse(cb_batchno.Text);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //       cb_batchno.DroppedDown = true;

            #region dataGridView7  detail pay ment

            var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                           where tbl_kacontractsdetailpayment.ContractNo.Equals(contractno) && tbl_kacontractsdetailpayment.BatchNo == BatchNo

                                           select new
                                           {

                                               Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
                                               PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
                                               Paid_Note = tbl_kacontractsdetailpayment.PaidNote,
                                               Description = tbl_kacontractsdetailpayment.Remark.Trim(),

                                               Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
                                               tbl_kacontractsdetailpayment.PaidRequestAmt,
                                               tbl_kacontractsdetailpayment.PrintChk,
                                               //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
                                               PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
                                               tbl_kacontractsdetailpayment.DoneOn,

                                               tbl_kacontractsdetailpayment.Reprint,
                                               tbl_kacontractsdetailpayment.PrintDate,
                                               //  Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
                                               tbl_kacontractsdetailpayment.BatchNo,
                                               tbl_kacontractsdetailpayment.CRDDAT,
                                               tbl_kacontractsdetailpayment.CRDUSR,
                                               // tbl_kacontractsdetailpayment.DoneOn,


                                               tbl_kacontractsdetailpayment.UPDDAT,
                                               tbl_kacontractsdetailpayment.UPDUSR,
                                               PayID = tbl_kacontractsdetailpayment.PayID,
                                               SubID = tbl_kacontractsdetailpayment.SubID,



                                           };

            //   dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView7.DataSource = dataGridProgramdetailrs7;
            this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";


            this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            #endregion



        }

        private void cb_batchno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_contractcaculatin_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker1.Value.Year + 1).ToString();
            string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "").Trim();
            if (Utils.IsValidnumber(txtvalueNSRcommit) && txtvalueNSRcommit != "")
            {

                #region load term and yeayr


                this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString("#,#", CultureInfo.InvariantCulture);



                #endregion

            }




        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void cb_contractstatus_SelectedValueChanged(object sender, EventArgs e)
        {




            string contractstatus = this.cb_contractstatus.SelectedItem.ToString();
            string contractno = tb_contractno.Text;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                   where tbl_kacontractdata.ContractNo == contractno
                                   select tbl_kacontractdata;

            if (contractstatusrs.Count() > 0)
            {
                foreach (var item in contractstatusrs)
                {
                    item.Consts = contractstatus;
                }

                dc.SubmitChanges();
            }




        }

        private void CreatenewContract_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txt_district_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bt_etcontract_Click(object sender, EventArgs e)
        {

            //    dateTimePicker3.Enabled = true;

            #region


            View.Datepick exdate = new Datepick("Choose Ext Date");
            exdate.ShowDialog();


            DateTime olđate = dateTimePicker3.Value;
            DateTime extdate = exdate.accrualdate;
            bool chon1 = exdate.chon;


            if (chon1 == true)
            {
                //}
                //  el        MessageBox.Show("Ext date must be greater!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //se
                //  {

                if (extdate >= dateTimePicker2.Value)
                {
                    dateTimePicker3.Value = extdate;



                    // update extdate tble master

                    //   string contractno = tb_contractno.Text;
                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                    var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                           where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text.Trim())
                                           select tbl_kacontractdata;

                    if (contractstatusrs.Count() > 0)
                    {
                        foreach (var item in contractstatusrs)
                        {
                            item.ExtDate = extdate;
                        }

                        dc.SubmitChanges();
                    }



                    // update extdate tbl detail ??

                }
                else
                {
                    MessageBox.Show("Ext date must be greater than todate!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }




            #endregion


        }

        private void btfindcust_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code", "");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;
            if (valueinput == null)
            {
                valueinput = "";
            }
            if (chon)
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                string username = Utils.getusername();

                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();

                //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                //               ).Contains(tbl_KaCustomer.SALORG_CTR)



                //var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                //             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)



                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.FullNameN.Contains(valueinput) && tbl_KaCustomer.indirectCode == true // || tbl_KaCustomer.SapCode ==true)
                                 && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                                  ).Contains(tbl_KaCustomer.SalesOrg)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,cChoose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                if (codetemp != "0" && chon == true && codetemp != null)
                {
                    cb_customerka.Text = codetemp;
                    cb_customerka.Enabled = false;
                    cbcust.Checked = true;
                }
                else
                {
                    cb_customerka.Text = "";
                    cb_customerka.Enabled = true;
                    cbcust.Checked = false;

                }
            }

        }

        private void btfindsfa_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach SFA code", "");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;

            //  string valueinput = txtcustgroup.Text;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();


            //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //               ).Contains(tbl_KaCustomer.SALORG_CTR)



            var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                         where tbl_KaCustomer.FullNameN.ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)
                                     && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                           ).Contains(tbl_KaCustomer.SalesOrg)
                         select new
                         {
                             tbl_KaCustomer.Region,
                             tbl_KaCustomer.Customer,
                             tbl_KaCustomer.FullNameN,
                             tbl_KaCustomer.SFAcode,

                         };




            Utils ut = new Utils();
            var tblcustomer = ut.ToDataTable(dc, rscode);

            Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  sfa code !");
            viewtb.ShowDialog();
            string codetemp = viewtb.valuecode;

            if (codetemp != "0" && codetemp != null)
            {
                txtfindsacode.Text = codetemp;
                txtfindsacode.Enabled = false;
                cb_customerka.Text = "";
                // txtcustgroup.Text = "";

                cbcust.Checked = false;
                //  cbgroup.Checked = false;
                cbsfa.Checked = true;
                //



            }
            else
            {
                txtfindsacode.Text = "";
                txtfindsacode.Enabled = true;
                cbsfa.Checked = false;

            }





        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach Group code", "");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;
            if (valueinput == null)
            {
                valueinput = "";
            }
            //  string valueinput = txtcustgroup.Text;
            if (chon)
            {


                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                string username = Utils.getusername();

                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();


                //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                //               ).Contains(tbl_KaCustomer.SALORG_CTR)





                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.FullNameN.ToString().Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)
                                && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                                  ).Contains(tbl_KaCustomer.SalesOrg)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.Grpcode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  Group code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;

                if (codetemp != "0" && codetemp != null)
                {
                    //txtcustgroup.Text = codetemp;
                    //txtcustgroup.Enabled = false;
                    cb_customerka.Text = "";
                    txtfindsacode.Text = "";

                    cbcust.Checked = false;
                    //cbgroup.Checked = false;
                    cbsfa.Checked = true;
                    //



                }


            }

        }

        private void cb_customerka_TextChanged(object sender, EventArgs e)
        {

            // string selectedcode = (cb_customerka.SelectedItem as ComboboxItem).Value.ToString();
            string selectedcode = cb_customerka.Text;
            if (Utils.IsValidnumber(selectedcode))
            {


                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                //  CombomCollection = null;
                //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                          where tbl_KaCustomer.Customer == double.Parse(selectedcode) && tbl_KaCustomer.SapCode == true
                          select tbl_KaCustomer).FirstOrDefault();

                if (rs != null)
                {


                    //       txt_vendor.Text = rs.BU;
                    //     cb_channel.Text = rs.CHN;
                    txt_chananame.Text = rs.FullNameN;
                    txt_houseno.Text = rs.Street;
                    txt_district.Text = rs.District;
                    txt_provicen.Text = rs.City;
                    txt_represennt.Text = rs.Representative;

                    txtVATno.Text = rs.VATregistrationNo;
                    cbocindirect.Checked = rs.indirectCode;
                    cbcust.Checked = rs.SapCode;

                }
                else
                {
                    txt_chananame.Text = "";
                    txt_houseno.Text = "";
                    txt_district.Text = "";
                    txt_provicen.Text = "";
                    txt_represennt.Text = "";


                    cbocindirect.Checked = false;
                    cbcust.Checked = false;
                }



            }


        }

        private void txt_volumecomit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NSRcommit.Focus();

            }
        }

        private void NSRcommit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txt_remarkstt.Focus();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_volumecomit_Leave(object sender, EventArgs e)
        {

            string txtvaluecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");


            if (Utils.IsValidnumber(txtvaluecomit) == true)
            {

                //  txt_volumecomit.Text = (double)(txtvaluecomit).ToString("#,#", CultureInfo.InvariantCulture);
                txt_volumecomit.Text = double.Parse(txtvaluecomit).ToString("#,#", CultureInfo.InvariantCulture);

                int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

                {
                    if (varyear <= 0)
                    {
                        varyear = 1;
                    }
                    this.txt_term.Text = varyear.ToString();
                    #region load term and yeayr
                    string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "").Trim();
                    string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "").Trim();

                    if (Utils.IsValidnumber(txtvaluetxt_volumecomit) && txtvaluetxt_volumecomit != "")
                    {
                        //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                        this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / int.Parse(txt_term.Text))).ToString();
                        this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                        //    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / int.Parse(txt_term.Text))).ToString();
                    }

                    if (Utils.IsValidnumber(txtvalueNSRcommit) && txtvalueNSRcommit != "")
                    {
                        //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                        // this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / int.Parse(txt_term.Text))).ToString();
                        this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                        this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / int.Parse(txt_term.Text))).ToString();
                    }





                    #endregion
                }





            }
            //    else
            //    {
            //        MessageBox.Show("Commit volume must be a number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
        }

        private void NSRcommit_Leave(object sender, EventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");

            if (Utils.IsValidnumber(txtvalueNSRcommit) == true)
            {
                NSRcommit.Text = double.Parse(txtvalueNSRcommit).ToString("#,#", CultureInfo.InvariantCulture);
                int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

                if (varyear >= 0)
                {
                    if (varyear == 0)
                    {
                        varyear = 1;
                    }
                    this.txt_term.Text = varyear.ToString();
                    #region load term and yeayr
                    string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "").Trim();
                    txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "").Trim();

                    if (Utils.IsValidnumber(txtvalueNSRcommit) && txtvalueNSRcommit != "")
                    {
                        //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                        // this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / int.Parse(txt_term.Text))).ToString();
                        this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                        this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / int.Parse(txt_term.Text))).ToString();


                    }


                    if (Utils.IsValidnumber(txtvaluetxt_volumecomit) && txtvaluetxt_volumecomit != "")
                    {
                        //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                        this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / int.Parse(txt_term.Text))).ToString();
                        this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                        //  this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / int.Parse(txt_term.Text))).ToString();
                    }


                    #endregion
                }

            }
            //else
            //{
            //    MessageBox.Show("Commit NSRcommit must be a number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //  }
        }

        private void txt_annualvolume_TextChanged(object sender, EventArgs e)
        {
            string txtvaluetxt_annualvolume = (txt_annualvolume.Text.Replace(",", "")).Replace(".", "").Trim();

            if (Utils.IsValidnumber(txtvaluetxt_annualvolume) && txtvaluetxt_annualvolume != "")
            {
                txt_annualvolume.Text = double.Parse(txtvaluetxt_annualvolume).ToString("#,#", CultureInfo.InvariantCulture);
            }

        }

        private void Nsaperyear_TextChanged(object sender, EventArgs e)
        {


            string txtvalueNsaperyear = (Nsaperyear.Text.Replace(",", "")).Replace(".", "").Trim();

            if (Utils.IsValidnumber(txtvalueNsaperyear) && txtvalueNsaperyear != "")
            {
                Nsaperyear.Text = double.Parse(txtvalueNsaperyear).ToString("#,#", CultureInfo.InvariantCulture);
            }



        }

        private void tb_creditlimit_Leave(object sender, EventArgs e)
        {


            string txtvaluetb_creditlimit = (tb_creditlimit.Text.Replace(",", "")).Replace(".", "");

            if (Utils.IsValidnumber(txtvaluetb_creditlimit))
            {
                tb_creditlimit.Text = double.Parse(txtvaluetb_creditlimit).ToString("#,#", CultureInfo.InvariantCulture);
            }




        }

        private void cb_paymentterm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_creditlimit_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_creditlimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cb_paymentterm.Focus();

            }
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (dateTimePicker3.Enabled == true)
                {
                    dateTimePicker3.Focus();
                }


            }
        }

        private void dateTimePicker3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_creditlimit.Focus();

            }
        }

        //private void txtcustgroup_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // string valueinput = txtcustgroup.Text;

        //        string connection_string = Utils.getConnectionstr();
        //        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //        //

        //        string username = Utils.getusername();

        //        var regioncode = (from tbl_Temp in dc.tbl_Temps
        //                          where tbl_Temp.username == username
        //                          select tbl_Temp.RegionCode).FirstOrDefault();





        //        var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
        //                     where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)
        //                     && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
        //                          ).Contains(tbl_KaCustomer.SALORG_CTR)
        //                     select new
        //                     {
        //                         tbl_KaCustomer.Region,
        //                         tbl_KaCustomer.Customer,
        //                         tbl_KaCustomer.FullNameN,
        //                         tbl_KaCustomer.Grpcode,

        //                     };




        //        Utils ut = new Utils();
        //        var tblcustomer = ut.ToDataTable(dc, rscode);

        //        Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  group code !");
        //        viewtb.ShowDialog();
        //        string codetemp = viewtb.valuecode;

        //        if (codetemp != "0" && codetemp != null)
        //        {
        //        //    txtcustgroup.Text = codetemp;
        //         //   txtcustgroup.Enabled = false;
        //            cb_customerka.Text = "";
        //            txtfindsacode.Text = "";

        //            cbcust.Checked = false;
        //        //    cbgroup.Checked = true;
        //            cbsfa.Checked = false;
        //            //



        //        }



        //    }



        //}

        private void txtfindsacode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = txtfindsacode.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                string username = Utils.getusername();

                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();





                //var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                //             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)



                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)
                              && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                                  ).Contains(tbl_KaCustomer.SalesOrg)

                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SFAcode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one Group code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;

                if (codetemp != "0" && codetemp != null)
                {
                    txtfindsacode.Text = codetemp;
                    txtfindsacode.Enabled = false;
                    cb_customerka.Text = "";
                    //     txtcustgroup.Text = "";

                    cbcust.Checked = false;
                    //       cbgroup.Checked = false;
                    cbsfa.Checked = true;
                    //



                }
                else
                {
                    txtfindsacode.Text = "";
                    txtfindsacode.Enabled = true;
                    cbsfa.Checked = false;

                }



            }

        }

        private void btfinddeliveryby_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code", "");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;


            if (chon)
            {



                //    string valueinput = cb_delivery.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
                             where tbl_KaCustomer.FullNameN.ToString().Contains(valueinput) && (tbl_KaCustomer.SapCode == true)
                             select new
                             {
                                 tbl_KaCustomer.Region,
                                 tbl_KaCustomer.Customer,
                                 tbl_KaCustomer.FullNameN,
                                 tbl_KaCustomer.SapCode,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  delivery code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;

                if (codetemp != "0" && codetemp != null)
                {
                    cb_delivery.Text = codetemp;
                    cb_delivery.Enabled = false;


                    //  cb_customerka.Text = "";
                    //  txtfindsacode.Text = "";

                    //   cbcust.Checked = false;
                    //    cbgroup.Checked = true;
                    //    cbsfa.Checked = false;
                    //



                }
                else
                {
                    cb_delivery.Text = "";
                    cb_delivery.Enabled = true;
                    //   cbgroup.Checked = false;

                }


                txt_volumecomit.Focus();

            }


        }

        //private void txtcustgroup_TextChanged(object sender, EventArgs e)
        //{

        //    // string selectedcode = (cb_customerka.SelectedItem as ComboboxItem).Value.ToString();
        //    string selectedcode = txtcustgroup.Text;
        //    if (Utils.IsValidnumber(selectedcode))
        //    {


        //        string connection_string = Utils.getConnectionstr();

        //        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //    //    string connection_string = Utils.getConnectionstr();
        //      //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //        string username = Utils.getusername();

        //        var regioncode = (from tbl_Temp in dc.tbl_Temps
        //                          where tbl_Temp.username == username
        //                          select tbl_Temp.RegionCode).FirstOrDefault();


        //                       //         && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
        //                       //).Contains(tbl_KaCustomer.SALORG_CTR)




        //        //  CombomCollection = null;
        //        //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //        var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
        //                  where tbl_KaCustomer.Customer == double.Parse(selectedcode) && tbl_KaCustomer.Grpcode == true
        //                                  && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
        //                       ).Contains(tbl_KaCustomer.SALORG_CTR)
        //                  select tbl_KaCustomer).FirstOrDefault();

        //        if (rs != null)
        //        {


        //            //       txt_vendor.Text = rs.BU;
        //            //     cb_channel.Text = rs.CHN;
        //            txt_chananame.Text = rs.FullNameN;
        //            txt_houseno.Text = rs.Street;
        //            txt_district.Text = rs.District;
        //            txt_provicen.Text = rs.City;
        //            txt_represennt.Text = rs.Representative;

        //            txtVATno.Text = rs.VATregistrationNo;
        //            cbocindirect.Checked = false;
        //            cbgroup.Checked = true;

        //        }
        //        else
        //        {
        //            txt_chananame.Text = "";
        //            txt_houseno.Text = "";
        //            txt_district.Text = "";
        //            txt_provicen.Text = "";
        //            txt_represennt.Text = "";


        //            cbocindirect.Checked = false;
        //            cbgroup.Checked = false;
        //        }




        //    }

        //}

        private void txtfindsacode_TextChanged(object sender, EventArgs e)
        {
            // string selectedcode = (cb_customerka.SelectedItem as ComboboxItem).Value.ToString();
            string selectedcode = txtfindsacode.Text;
            if (Utils.IsValidnumber(selectedcode))
            {


                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string connection_string = Utils.getConnectionstr();
                //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                string username = Utils.getusername();

                var regioncode = (from tbl_Temp in dc.tbl_Temps
                                  where tbl_Temp.username == username
                                  select tbl_Temp.RegionCode).FirstOrDefault();


                //         && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                //).Contains(tbl_KaCustomer.SALORG_CTR)






                //  CombomCollection = null;
                //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                          where tbl_KaCustomer.Customer == double.Parse(selectedcode) && tbl_KaCustomer.SFAcode == true
                                   && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
                          ).Contains(tbl_KaCustomer.SalesOrg)


                          select tbl_KaCustomer).FirstOrDefault();

                if (rs != null)
                {


                    //       txt_vendor.Text = rs.BU;
                    //     cb_channel.Text = rs.CHN;
                    txt_chananame.Text = rs.FullNameN;
                    txt_houseno.Text = rs.Street;
                    txt_district.Text = rs.District;
                    txt_provicen.Text = rs.City;
                    txt_represennt.Text = rs.Representative;
                    txtVATno.Text = rs.VATregistrationNo;

                    cbocindirect.Checked = false;
                    cbsfa.Checked = true;

                }
                else
                {
                    txt_chananame.Text = "";
                    txt_houseno.Text = "";
                    txt_district.Text = "";
                    txt_provicen.Text = "";
                    txt_represennt.Text = "";

                    cbocindirect.Checked = false;
                    cbsfa.Checked = false;
                }




            }

        }

        private void bt_fin_Click(object sender, EventArgs e)
        {
            //  cb_contractstatus
            //  cb_contractstatus.Text = "ALV";

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            DialogResult kq = MessageBox.Show(" Are you sure  finalize ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "ALV";

                        db.SubmitChanges();


                        cb_contractstatus.Text = "ALV";
                        bt_fin.Visible = false;
                        bt_cancel.Visible = true;
                        bt_close.Visible = true;
                        btchangensrcomit.Visible = true;
                        btchangevolcomit.Visible = true;
                        btchangeRemark.Visible = true;

                        btchangecontrcatype.Visible = true;
                        btchangeregion.Visible = true;

                        btchanegcontract.Visible = true;

                        btcfromdate.Visible = false;
                        btchagetodate.Visible = false;
                        btchangecret.Visible = true;

                        btrepresent.Visible = true;
                        btchangetradename.Visible = true;
                        bthomeso.Visible = true;
                        btchangedistric.Visible = true;
                        btchangeprovince.Visible = true;
                        btvatchange.Visible = true;





                        bt_finundo.Visible = true;
                        bt_undoclose.Visible = false;
                        bt_undocancel.Visible = false;






                    }


                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() >= 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "ALV";
                            dc.SubmitChanges();

                        }
                    }

                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);

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



                    break;
                default:
                    break;
            }



        }

        private void bt_finundo_Click(object sender, EventArgs e)
        {
            //  cb_contractstatus

            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            DialogResult kq = MessageBox.Show(" Are you sure undo  finalize ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "CRT";
                        db.SubmitChanges();
                        cb_contractstatus.Text = "CRT";



                        bt_fin.Visible = true;
                        bt_cancel.Visible = true;
                        bt_close.Visible = true;
                        btchangensrcomit.Visible = true;
                        btchangevolcomit.Visible = true;
                        btchangeRemark.Visible = true;
                        btchangecontrcatype.Visible = true;
                        btchangeregion.Visible = true;


                        btchanegcontract.Visible = true;

                        btcfromdate.Visible = true;
                        btchagetodate.Visible = true;
                        btchangecret.Visible = true;

                        btrepresent.Visible = true;
                        btchangetradename.Visible = true;
                        bthomeso.Visible = true;
                        btchangedistric.Visible = true;
                        btchangeprovince.Visible = true;
                        btvatchange.Visible = true;





                        //    bt_fin.Visible = true;
                        bt_finundo.Visible = false;
                        //    bt_cancel.Visible = true;
                        //    bt_close.Visible = true;
                        bt_undoclose.Visible = false;
                        bt_undocancel.Visible = false;

                    }

                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() > 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "CRT";
                            dc.SubmitChanges();
                        }
                    }
                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);
                    btdelete.Visible = true;
                    btdelete.Enabled = true;

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



                    break;
                default:
                    break;
            }
            #endregion



        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            DialogResult kq = MessageBox.Show(" Are you sure  cancel this contract ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "CAN";
                        cb_contractstatus.Text = "CAN";
                        db.SubmitChanges();



                        bt_fin.Visible = false;
                        bt_cancel.Visible = false;
                        bt_close.Visible = false;
                        btchangensrcomit.Visible = false;
                        btchangevolcomit.Visible = false;
                        btchangeRemark.Visible = false;

                        btchangecontrcatype.Visible = false;
                        btchangeregion.Visible = false;

                        btchanegcontract.Visible = false;


                        btchangecret.Visible = false;
                        btcfromdate.Visible = false;
                        btchagetodate.Visible = false;


                        btrepresent.Visible = false;
                        btchangetradename.Visible = false;
                        bthomeso.Visible = false;
                        btchangedistric.Visible = false;
                        btchangeprovince.Visible = false;
                        btvatchange.Visible = false;




                        bt_finundo.Visible = false;
                        bt_undoclose.Visible = false;
                        bt_undocancel.Visible = true;

                    }
                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() >= 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "CAN";
                            dc.SubmitChanges();
                        }
                    }
                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);

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



                    break;
                default:
                    break;
            }
            #endregion

        }

        private void bt_undocancel_Click(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            DialogResult kq = MessageBox.Show(" Are you sure  undo cancel to alive ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "ALV";
                        cb_contractstatus.Text = "ALV";
                        db.SubmitChanges();



                        bt_fin.Visible = false;
                        bt_cancel.Visible = true;
                        bt_close.Visible = true;
                        btchangensrcomit.Visible = true;
                        btchangevolcomit.Visible = true;
                        btchangeRemark.Visible = true;

                        btchangecontrcatype.Visible = true;
                        btchangeregion.Visible = true;

                        btchanegcontract.Visible = true;


                        btchangecret.Visible = true;

                        btcfromdate.Visible = false;
                        btchagetodate.Visible = false;

                        btrepresent.Visible = true;
                        btchangetradename.Visible = true;
                        bthomeso.Visible = true;
                        btchangedistric.Visible = true;
                        btchangeprovince.Visible = true;
                        btvatchange.Visible = true;




                        bt_finundo.Visible = true;
                        bt_undoclose.Visible = false;
                        bt_undocancel.Visible = false;



                    }
                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() >= 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "ALV";
                            dc.SubmitChanges();
                        }
                    }
                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);

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



                    break;
                default:
                    break;
            }
            #endregion

        }

        private void bt_close_Click(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            DialogResult kq = MessageBox.Show(" Are you sure  close this contract ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "CLS";
                        cb_contractstatus.Text = "CLS";
                        db.SubmitChanges();


                        bt_fin.Visible = false;
                        bt_cancel.Visible = false;
                        bt_close.Visible = false;
                        btchangensrcomit.Visible = false;
                        btchangevolcomit.Visible = false;
                        btchangeRemark.Visible = false;


                        btchangecontrcatype.Visible = false;
                        btchangeregion.Visible = false;

                        btchanegcontract.Visible = false;


                        btchangecret.Visible = false;
                        btcfromdate.Visible = false;
                        btchagetodate.Visible = false;


                        btrepresent.Visible = false;
                        btchangetradename.Visible = false;
                        bthomeso.Visible = false;
                        btchangedistric.Visible = false;
                        btchangeprovince.Visible = false;
                        btvatchange.Visible = false;


                        bt_finundo.Visible = false;
                        bt_undoclose.Visible = true;
                        bt_undocancel.Visible = false;



                    }

                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() >= 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "CLS";
                            dc.SubmitChanges();
                        }
                    }

                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);

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



                    break;
                default:
                    break;
            }
            #endregion

        }

        private void bt_undoclose_Click(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            DialogResult kq = MessageBox.Show(" Are you sure Undo Close to ALV ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:
                    string contractno = tb_contractno.Text.Trim();

                    var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(contractno)
                                    select tbl_kacontractdata).FirstOrDefault();

                    if (statusrs != null)
                    {
                        statusrs.Consts = "ALV";
                        cb_contractstatus.Text = "ALV";
                        db.SubmitChanges();

                        bt_fin.Visible = false;
                        bt_cancel.Visible = true;
                        bt_close.Visible = true;
                        btchangensrcomit.Visible = true;
                        btchangevolcomit.Visible = true;
                        btchangeRemark.Visible = true;

                        btchangecontrcatype.Visible = true;
                        btchangeregion.Visible = true;

                        btchanegcontract.Visible = true;


                        btchangecret.Visible = true;
                        btcfromdate.Visible = false;
                        btchagetodate.Visible = false;


                        btrepresent.Visible = true;
                        btchangetradename.Visible = true;
                        bthomeso.Visible = true;
                        btchangedistric.Visible = true;
                        btchangeprovince.Visible = true;
                        btvatchange.Visible = true;



                        bt_finundo.Visible = true;
                        bt_undoclose.Visible = false;
                        bt_undocancel.Visible = false;


                    }
                    var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                 select tbl_kacontractsdatadetail;

                    if (detail.Count() >= 0)
                    {
                        foreach (var item in detail)
                        {
                            item.Constatus = "ALV";
                            dc.SubmitChanges();
                        }
                    }
                    Control.Control_ac.CaculationContract(contractno);
                    loadDetailContractView(contractno);
                    loadtotaldContractView(contractno);

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



                    break;
                default:
                    break;
            }
            #endregion

        }

        private void txt_volumecomit_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            DialogResult kq = MessageBox.Show(" Are you sure delete ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // string ContractNo = tb_contractno.Text;

            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:


                    string contractno = tb_contractno.Text;

                    if (contractno != null && contractno != "")
                    {


                        var payment = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                       where tbl_kacontractsdetailpayment.ContractNo.Equals(contractno)
                                       select tbl_kacontractsdetailpayment.ContractNo);


                        if (payment.Count() == 0)
                        {



                            var statusrs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                            where tbl_kacontractdata.ContractNo.Equals(contractno) && tbl_kacontractdata.Consts == "CRT"
                                            // && !payment.Contains(tbl_kacontractdata.ContractNo)
                                            select tbl_kacontractdata).FirstOrDefault();


                            if (statusrs != null)
                            {

                                dc.tbl_kacontractdatas.DeleteOnSubmit(statusrs);
                                dc.SubmitChanges();

                                var statusrs2 = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                                 where tbl_kacontractsdatadetail.ContractNo.Equals(contractno) ///&& tbl_kacontractsdatadetail.Constatus == "CRT"

                                                 select tbl_kacontractsdatadetail);

                                if (statusrs2.Count() > 0)
                                {
                                    dc.tbl_kacontractsdatadetails.DeleteAllOnSubmit(statusrs2);
                                    dc.SubmitChanges();
                                }

                                MessageBox.Show("Contract " + contractno + " delete ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                break;

                            }

                        }
                        else
                        {


                            MessageBox.Show("Can not delete contract that have paid item, please check ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        //  }


                    }



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



                    break;
                default:
                    break;
            }



        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dateTimePicker2.Enabled == true)
                {
                    dateTimePicker2.Focus();
                }


            }
        }

        private void tb_contractno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cb_contracttype.Focus();

            }
        }

        private void cb_contracttype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cb_salesogr.Focus();

            }
        }

        private void cb_salesogr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dateTimePicker1.Enabled == true)
                {
                    dateTimePicker1.Focus();
                }


            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

            //string ContractNoin = tb_contractno.Text;
            //Control.Control_ac.VolumeupdateperContract(ContractNoin);
            //Control.Control_ac.VolumeupdateperContractbyPRdgrp(ContractNoin);

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //#region loaddata 


            //var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
            //          where tbl_kacontractdata.ContractNo == ContractNoin
            //          select tbl_kacontractdata).FirstOrDefault();


            //if (rs != null)
            //{

            //    #region delete  tbl_KaCreatCrtracttemp


            //    string username = Utils.getusername();
            //    // LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
            //    dc.ExecuteCommand(sqltext);
            //    dc.SubmitChanges();


            //    #endregion


            //    #region load data master contrac

            //    bt_creatnewCust.Visible = false;
            //    bt_creatnewcontract.Visible = false;
            //    //   but_releaseprint.Visible = false;

            //    this.tb_contractno.Text = rs.ContractNo;
            //    this.tb_contractno.Enabled = false;

            //    this.dateTimePicker1.Value = rs.EffDate.Value;
            //    this.dateTimePicker1.Enabled = false;


            //    this.dateTimePicker2.Value = rs.EftDate.Value;
            //    this.dateTimePicker2.Enabled = false;

            //    this.dateTimePicker3.Value = rs.ExtDate.Value;
            //    this.dateTimePicker3.Enabled = false;


            //    // ToString("#,#", CultureInfo.InvariantCulture);
            //    this.txt_term.Text = rs.ConTerm.ToString();// (this.dateTimePicker2.Value.Year - this.dateTimePicker1.Value.Year + 1).ToString();

            //    if (rs.ConTerm == null)
            //    {
            //        int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
            //        this.txt_term.Text = varyear.ToString();
            //    }



            //    this.txt_term.Enabled = false;
            //    if (rs.NSRComm != null)
            //    {
            //        NSRcommit.Text = ((double)rs.NSRComm).ToString("#,#", CultureInfo.InvariantCulture);

            //    }
            //    NSRcommit.Enabled = false;
            //    if (rs.ConTerm != null && rs.ConTerm != 0 && rs.NSRComm != null)
            //    {
            //        Nsaperyear.Text = ((double)(rs.NSRComm / rs.ConTerm)).ToString("#,#", CultureInfo.InvariantCulture);

            //    }
            //    else
            //    {
            //        Nsaperyear.Text = "0";
            //    }

            //    this.Nsaperyear.Enabled = false;

            //    Achivedvol.Enabled = false;
            //    if (rs.PCVolAched != null)
            //    {
            //        Achivedvol.Text = double.Parse(rs.PCVolAched.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
            //    }

            //    if (rs.Revenue != null)
            //    {
            //        RevenueAched.Text = double.Parse(rs.Revenue.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
            //    }
            //    RevenueAched.Enabled = false;

            //    if (rs.ECAched != null)
            //    {
            //        AchievdVolPCs.Text = double.Parse(rs.ECAched.ToString()).ToString("#,#", CultureInfo.InvariantCulture);

            //    }
            //    AchievdVolPCs.Enabled = false;


            //    Funpercentage.Enabled = false;
            //    if (rs.VolComm > 0)
            //    {

            //        Funpercentage.Text = Math.Round((double)((rs.PCVolAched.GetValueOrDefault(0) / rs.VolComm) * 100)).ToString("#,#", CultureInfo.InvariantCulture);

            //    }

            //    Costpercase.Enabled = false;
            //    if (rs.ECAched > 0)
            //    {

            //        Costpercase.Text = ((double)(rs.TotDeal.GetValueOrDefault(0) / rs.ECAched)).ToString("#,#", CultureInfo.InvariantCulture);

            //    }

            //    if (rs.VolComm != null)
            //    {
            //        this.txt_volumecomit.Text = ((double)rs.VolComm).ToString("#,#", CultureInfo.InvariantCulture);
            //    }

            //    this.txt_volumecomit.Enabled = false;

            //    if (rs.AnnualVolume != null)
            //    {
            //        this.txt_annualvolume.Text = ((double)rs.AnnualVolume).ToString("#,#", CultureInfo.InvariantCulture);
            //    }

            //    this.txt_annualvolume.Enabled = false;

            //    this.Nsaperyear.Enabled = false;
            //    if (rs.NSRPer != null)
            //    {
            //        this.Nsaperyear.Text = ((double)rs.NSRPer).ToString("#,#", CultureInfo.InvariantCulture);
            //    }




            //    txtfindsacode.Enabled = false;


            //    if (rs.NSRPer != null)
            //    {
            //        this.tb_creditlimit.Text = ((double)rs.CreditLimit).ToString("#,#", CultureInfo.InvariantCulture);
            //        //     this.tb_creditlimit.Text = rs.CreditLimit.ToString();
            //    }

            //    this.tb_creditlimit.Enabled = false;


            //    this.cb_customerka.DropDownStyle = ComboBoxStyle.Simple;// = false;

            //    if (rs.CustomerType.Trim() == "SAP" || rs.CustomerType == null)
            //    {
            //        this.cb_customerka.Text = rs.Customer.ToString();
            //        cbcust.Checked = true;
            //    }
            //    if (rs.CustomerType.Trim() == "GRP")
            //    {
            //        this.txtcustgroup.Text = rs.Customer.ToString();
            //        cbgroup.Checked = true;
            //    }
            //    if (rs.CustomerType.Trim() == "SFA")
            //    {
            //        this.txtfindsacode.Text = rs.Customer.ToString();
            //        cbsfa.Checked = true;
            //        cbocindirect.Checked = true;
            //    }




            //    this.cb_customerka.Enabled = false;


            //    this.cb_contracttype.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_contracttype.Text = rs.ConType;
            //    this.cb_contracttype.Enabled = false;

            //    this.cb_salesogr.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_salesogr.Text = rs.SalesOrg;
            //    this.cb_salesogr.Enabled = false;



            //    this.cb_channel.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_channel.Text = rs.Channel;
            //    this.cb_channel.Enabled = false;



            //    //this.cb_channel.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    //this.cb_channel.Text = rs.Channel;
            //    //this.cb_channel.Enabled = false;


            //    this.cb_paymentterm.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_paymentterm.Text = rs.CreditTerm;
            //    this.cb_paymentterm.Enabled = false;


            //    this.cb_curency.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_curency.Text = rs.Currency;
            //    this.cb_curency.Enabled = false;

            //    this.cb_delivery.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //    this.cb_delivery.Text = rs.DeliveredBy;
            //    this.cb_delivery.Enabled = false;


            //    this.txt_represennt.Text = rs.Representative;
            //    this.txt_represennt.Enabled = false;


            //    this.txt_chananame.Text = rs.Fullname;
            //    this.txt_chananame.Enabled = false;

            //    this.txt_houseno.Text = rs.HouseNo;
            //    this.txt_houseno.Enabled = false;

            //    this.txt_provicen.Text = rs.Province;
            //    this.txt_provicen.Enabled = false;


            //    this.txt_district.Text = rs.District;
            //    this.txt_district.Enabled = false;


            //    //this.Achivedvol.Enabled = false;
            //    //this.Achivedvol.Text = rs.VolAched.ToString();


            //    //this.RevenueAched.Enabled = false;
            //    //this.RevenueAched.Text = rs.Revenue.ToString();


            //    //this.AchievdVolPCs.Enabled = false;
            //    //this.AchievdVolPCs.Text = rs.VolAched_S.ToString();


            //    //this.Funpercentage.Enabled = false;
            //    //this.Funpercentage.Text = ((rs.Tot_paid*100) / rs.TotDeal).ToString();




            //    //this.Costpercase.Enabled = false;
            //    //this.Costpercase.Text = (rs.TotDeal/rs.VolAched).ToString();



            //    this.txt_remarkstt.Text = rs.Remarks;
            //    this.txt_remarkstt.Enabled = false;



            //    txtinfor.Visible = true;
            //    //          MessageBox.Show("Are you sure to change status of contract ?", "Thông báo" ,MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //    txtinfor.Text = "Create by: " + rs.CRDUSR + ", Update by: " + rs.UPDUSR;

            //    Model.Username used = new Model.Username();

            //    if (formlabel == "ENTRY SCREEN DISPLAY CONTRACT")
            //    {
            //        //   this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //        this.cb_contractstatus.Text = rs.Consts;
            //        //  this.cb_contractstatus.Enabled = false;
            //        this.bt_etcontract.Visible = true;



            //        if (used.inputcontractfinalcontrol == true)
            //        {


            //            undogroup.Visible = true;

            //            undogroup.Enabled = true;
            //            // bt_fin.Visible = true;
            //            bt_finundo.Visible = true;
            //            bt_cancel.Visible = true;
            //            bt_close.Visible = true;
            //            bt_undoclose.Visible = true;
            //            bt_undocancel.Visible = true;



            //        }
            //        else
            //        {
            //            undogroup.Visible = false;
            //        }
            //        // undogroup

            //    }
            //    else
            //    {
            //        this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
            //        this.cb_contractstatus.Text = rs.Consts;
            //        this.cb_contractstatus.Enabled = false;
            //        this.bt_etcontract.Visible = false;
            //    }

            //    //     MessageBox.Show(this.Text);

            //    // txt_term
            //    //  MessageBox.Show(rs.ConType);


            //    #endregion




            //    loadtotaldContractView(ContractNoin);

            //    loadDetailContractView(ContractNoin);






            //    undogroup.Visible = true;

            //    //           Model.Username used = new Model.Username();
            //    if (used.inputcontractfinalcontrol == true)
            //    {


            //        undogroup.Visible = true;

            //        undogroup.Enabled = true;
            //        // bt_fin.Visible = true;
            //        bt_finundo.Visible = true;
            //        bt_cancel.Visible = true;
            //        bt_close.Visible = true;
            //        bt_undoclose.Visible = true;
            //        bt_undocancel.Visible = true;


            //    }
            //    else
            //    {
            //        undogroup.Enabled = false;
            //    }
            //    //    undogroup
            //    if (cb_contractstatus.Text == "CRT")
            //    {

            //        bt_fin.Visible = true;
            //        btdelete.Enabled = true;
            //        //bt_finundo.Visible = false;
            //        //bt_cancel.Visible = false;
            //        //bt_close.Visible = false;
            //        //bt_undoclose.Visible = false;
            //        //bt_undocancel.Visible = false;
            //    }
            //}
            //#endregion view








        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {



            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {


                if (frm.Text == "Change Contract Item")
                {
                    kq = true;
                    frm.Focus();

                }
            }



            if (!kq && this.Text == "Input Contract" && formlabel.Text == "ENTRY SCREEN DISPLAY CONTRACT")  // pahir la pay ment requyet mowi sduoc tra tien 
            {

                string Program = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Programe"].Value.ToString();
                string ContractNo = tb_contractno.Text;
                //int PayID = int.Parse(this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());
                int prgID = int.Parse(this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());
                Model.Username used = new Model.Username();

                if (used.changeitem)
                {
                    View.EditContractItem EditContractItem = new View.EditContractItem(this, ContractNo, "EDIT ITEM TERM OF CONTRACT", Program, prgID);



                    EditContractItem.ShowDialog();
                }


            }



        }

        private void btaddnewItem_Click(object sender, EventArgs e)
        {


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {


                if (frm.Text == "Change Contract Item")
                {
                    kq = true;
                    frm.Focus();

                }
            }



            if (!kq && this.Text == "Input Contract" && formlabel.Text == "ENTRY SCREEN DISPLAY CONTRACT")  // pahir la pay ment requyet mowi sduoc tra tien 
            {

                //string ContractNo = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["ContractNo"].Value;
                string ContractNo = tb_contractno.Text;
                string Program = "CAS";

                try
                {
                    Program = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Programe"].Value.ToString();
                }
                catch (Exception)
                {

                    // throw;
                }


                Model.Username used = new Model.Username();

                if (used.changeitem)
                {
                    View.EditContractItem EditContractItem = new View.EditContractItem(this, ContractNo, "CREATE NEW ITEM TERM", Program, 0);



                    EditContractItem.ShowDialog();
                }


            }

        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            //String ContractNoin = tb_contractno.Text.Trim();

            //Control.Control_ac.VolumeupdateperContract(ContractNoin);
            //Control.Control_ac.VolumeupdateperContractbyPRdgrp(ContractNoin);

            //loadDetailContractView(ContractNoin);
            //loadtotaldContractView(ContractNoin);




        }

        private void cb_delivery_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btchangeRemark_Click(object sender, EventArgs e)
        {



            View.valueinput valueiput = new valueinput("Please input new remarks to change", txt_remarkstt.Text);
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.Remarks = newremark;
                    }

                    txt_remarkstt.Text = newremark;

                    dc.SubmitChanges();
                }

            }







            //    MessageBox.Show(newremark);






        }

        private void btrepresent_Click(object sender, EventArgs e)
        {

            View.valueinput valueiput = new valueinput("Please input new Representation to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.Representative = newremark;
                    }

                    txt_represennt.Text = newremark;

                    dc.SubmitChanges();
                }






            }


        }

        private void btchangetradename_Click(object sender, EventArgs e)
        {
            //
            View.valueinput valueiput = new valueinput("Please input new Name to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.Fullname = newremark;
                    }

                    txt_chananame.Text = newremark;

                    dc.SubmitChanges();
                }

                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.Fullname = newremark;
                        dc.SubmitChanges();
                    }
                }



            }

            //

        }

        private void bthomeso_Click(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new Home no to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.HouseNo = newremark;
                    }

                    txt_houseno.Text = newremark;

                    dc.SubmitChanges();
                }


                string Addressnew = this.txt_houseno.Text.Trim() + " " + txt_district.Text.Trim() + " " + txt_provicen.Text.Trim();
                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.Address = Addressnew;
                        dc.SubmitChanges();
                    }
                }


            }

        }

        private void btchangedistric_Click(object sender, EventArgs e)
        {

            View.valueinput valueiput = new valueinput("Please input new District to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.District = newremark;
                    }

                    txt_district.Text = newremark;

                    dc.SubmitChanges();
                }
                string Addressnew = this.txt_houseno.Text.Trim() + " " + txt_district.Text.Trim() + " " + txt_provicen.Text.Trim();
                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.Address = Addressnew;
                        dc.SubmitChanges();
                    }
                }

            }
        }

        private void btchangeprovince_Click(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new Province to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.Province = newremark;
                    }

                    txt_provicen.Text = newremark;

                    dc.SubmitChanges();
                }

                string Addressnew = this.txt_houseno.Text.Trim() + " " + txt_district.Text.Trim() + " " + txt_provicen.Text.Trim();
                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.Address = Addressnew;
                        dc.SubmitChanges();
                    }
                }




            }
        }

        private void btvatchange_Click(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new VAT no to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            if (newremark != null)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                     select tbl_kacontractdata;

                if (contractremark.Count() == 1)
                {
                    foreach (var item in contractremark)
                    {
                        item.VATregistrationNo = newremark;
                    }

                    txtVATno.Text = newremark;

                    dc.SubmitChanges();
                }

                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.VATregistrationNo = newremark;
                        dc.SubmitChanges();
                    }
                }


            }
        }

        private void button1_Click_5(object sender, EventArgs e)
        {

            //    dateTimePicker3.Enabled = true;

            #region


            View.Datepick exdate = new Datepick("Choose Eff to date");
            exdate.ShowDialog();



            DateTime fromdate = dateTimePicker1.Value;
            DateTime todate = dateTimePicker2.Value;
            DateTime extdate = exdate.accrualdate;


            bool chon1 = exdate.chon;


            if (extdate > fromdate && chon1 == true)
            {
                //}
                //  el        MessageBox.Show("Ext date must be greater!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //se
                //  {
                dateTimePicker2.Value = extdate;



                // update extdate tble master

                //   string contractno = tb_contractno.Text;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                       where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text.Trim())
                                       select tbl_kacontractdata;

                if (contractstatusrs.Count() > 0)
                {
                    foreach (var item in contractstatusrs)
                    {
                        item.EftDate = extdate;
                    }

                    dc.SubmitChanges();
                }



                // update extdate tbl detail ??


            }
            else
            {
                MessageBox.Show("Ext date must be greater than fromdate!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //    dateTimePicker3.Enabled = true;

            #region


            View.Datepick exdate = new Datepick("Choose Eff From date");
            exdate.ShowDialog();


            DateTime fromdate = dateTimePicker1.Value;
            DateTime todate = dateTimePicker2.Value;
            DateTime extdate = exdate.accrualdate;
            bool chon1 = exdate.chon;


            if (extdate < todate && chon1 == true)
            {
                //}
                //  el        MessageBox.Show("Ext date must be greater!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //se
                //  {
                dateTimePicker1.Value = extdate;



                // update extdate tble master

                //   string contractno = tb_contractno.Text;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                       where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text.Trim())
                                       select tbl_kacontractdata;

                if (contractstatusrs.Count() > 0)
                {
                    foreach (var item in contractstatusrs)
                    {
                        item.EffDate = extdate;
                    }

                    dc.SubmitChanges();
                }



                // update extdate tbl detail ??


            }




            #endregion




        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new Credit Limit to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            //-------------


            if (newremark != null && newremark != "")
            {
                string number = newremark.Trim();

                if (Utils.IsValidnumber(number))
                {

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                    var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                         where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                         select tbl_kacontractdata;

                    if (contractremark.Count() == 1)
                    {
                        foreach (var item in contractremark)
                        {
                            item.CreditLimit = double.Parse(number);
                        }

                        tb_creditlimit.Text = number.ToString();

                        dc.SubmitChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Credit must be a number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            //-------------



        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input Contract no to change", "");
            valueiput.ShowDialog();


            String newcontractno = valueiput.valuetext;


            if (newcontractno != null && newcontractno != "")
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                // kiem tra neu có trung hop dong thi ko duoc


                var contractcheck = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                    where tbl_kacontractdata.ContractNo.Equals(newcontractno)
                                    select tbl_kacontractdata;

                //if (contractcheck.Count() > 0)
                //{
                //    MessageBox.Show("Hợp đồng này đã tồn tại, please chọn hợp đồng khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                var contractcheck2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                     where tbl_kacontractsdatadetail.ContractNo.Equals(newcontractno)
                                     select tbl_kacontractsdatadetail;

                if (contractcheck.Count() > 0 || contractcheck2.Count() > 0)
                {
                    MessageBox.Show("Hợp đồng này đã tồn tại, please chọn hợp đồng khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else

                //   if (contractcheck.Count() == 0)
                {
                    #region

                    var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                         where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                         select tbl_kacontractdata;

                    if (contractremark.Count() == 1)
                    {
                        foreach (var item in contractremark)
                        {
                            item.ContractNo = newcontractno;
                        }



                        dc.SubmitChanges();



                        var detailcontract = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                                             select tbl_kacontractsdatadetail;

                        if (detailcontract.Count() > 0)
                        {

                            foreach (var item in detailcontract)
                            {
                                item.ContractNo = newcontractno;

                            }
                            dc.SubmitChanges();

                        }

                        var detailcontractpay = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                                where tbl_kacontractsdetailpayment.ContractNo.Equals(tb_contractno.Text)
                                                select tbl_kacontractsdetailpayment;

                        if (detailcontractpay.Count() > 0)
                        {

                            foreach (var item in detailcontractpay)
                            {
                                item.ContractNo = newcontractno;

                            }
                            dc.SubmitChanges();

                        }

                        tb_contractno.Text = newcontractno;
                    }
                    else
                    {
                        MessageBox.Show("Hợp đồng này không thay được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    #endregion
                }



            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            List<selectinput.ComboboxItem> CombomCollection = new List<selectinput.ComboboxItem>();
            var rs = from tbl_kacontracttype in dc.tbl_kacontracttypes
                         //   where tbl_kacontracttype.Code != "DIS"
                     orderby tbl_kacontracttype.Contractype
                     select tbl_kacontracttype;
            foreach (var item2 in rs)
            {
                selectinput.ComboboxItem cb = new selectinput.ComboboxItem();
                cb.Value = item2.Contractype.Trim();
                cb.Text = item2.Contractype.Trim();//  + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
                CombomCollection.Add(cb);
            }

            View.selectinput valueiput = new selectinput("Please input new contract type to change", CombomCollection);
            valueiput.ShowDialog();


            String newContractype = valueiput.valuetext;


            if (newContractype != null)
            {


                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text)
                                     select tbl_kacontractdata;

                if (contractremark.Count() >= 0)
                {
                    foreach (var item in contractremark)
                    {
                        item.ConType = newContractype;
                    }

                    cb_contracttype.Text = newContractype;

                    dc.SubmitChanges();
                }



                var detail = from p in dc.tbl_kacontractsdatadetails
                             where p.ContractNo.Equals(tb_contractno.Text)
                             select p;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.ConType = newContractype;
                        dc.SubmitChanges();
                    }

                    //   cb_contracttype.Text = newContractype;


                }
            }
            #endregion



        }

        private void button1_Click_7(object sender, EventArgs e)
        {

            #region


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            List<selectinput.ComboboxItem> CombomCollection = new List<selectinput.ComboboxItem>();
            var rs = from tbl_karegion in dc.tbl_karegions
                         //   where tbl_kacontracttype.Code != "DIS"
                     orderby tbl_karegion.Region
                     select tbl_karegion;
            foreach (var item2 in rs)
            {
                selectinput.ComboboxItem cb = new selectinput.ComboboxItem();
                cb.Value = item2.Region.Trim();
                cb.Text = item2.Region.Trim();//  + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
                CombomCollection.Add(cb);
            }

            View.selectinput valueiput = new selectinput("Please input new Region to change", CombomCollection);
            valueiput.ShowDialog();


            String newRegion = valueiput.valuetext;


            if (newRegion != null)
            {


                var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                     where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text)

                                     select tbl_kacontractdata;


                if (contractremark.Count() >= 0)
                {
                    foreach (var item in contractremark)
                    {
                        item.SalesOrg = newRegion;
                    }

                    cb_salesogr.Text = newRegion;

                    dc.SubmitChanges();
                }


                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.ContractNo.Equals(tb_contractno.Text)
                             select tbl_kacontractsdatadetail;

                if (detail.Count() >= 0)
                {
                    foreach (var item in detail)
                    {
                        item.SalesOrg = newRegion;
                        dc.SubmitChanges();
                    }
                }


            }




            #endregion


        }

        private void txtcustgroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btviewcode_Click(object sender, EventArgs e)
        {
            // btviewcode


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string contractno = tb_contractno.Text.Trim();
            //   View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


            //    kaPriodpicker.ShowDialog();
            //   string priod = kaPriodpicker.priod;

            var rs = from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                     where tbl_kacontractCustcode.ContractNo == contractno

                     select new
                     {

                         //     ID = tbl_kacontractCustcode.id,
                         Contract = tbl_kacontractCustcode.ContractNo,
                         CustomerCode = tbl_kacontractCustcode.CustomerCode,
                         Name = tbl_kacontractCustcode.Name,
                         Addedby = tbl_kacontractCustcode.Addedby,


                     };

            Viewtable viewtbl = new Viewtable(rs, dc, "Contract code Group List Contract: " + contractno, 99);// view code 1 la can viet them lenh

            viewtbl.Show();





        }

        private void btAddGroupcode_Click(object sender, EventArgs e)
        {


            string contractNo = tb_contractno.Text.Trim();

            View.KASeachaddcode inputval = new KASeachaddcode(contractNo);// ("Input some text in Name to seach code", "");

            inputval.ShowDialog();

            //bool chon = inputval.kq;
            //string valueinput = inputval.valuetext;
            //if (valueinput == null)
            //{
            //    valueinput = "";
            //}
            //if (chon)
            //{



            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    string username = Utils.getusername();

            //    var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                      where tbl_Temp.username == username
            //                      select tbl_Temp.RegionCode).FirstOrDefault();

            //    //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //    //               ).Contains(tbl_KaCustomer.SALORG_CTR)
            //    //var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //    //             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)



            //    var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //                 where tbl_KaCustomer.FullNameN.Contains(valueinput) //&& tbl_KaCustomer.SapCode == true // || tbl_KaCustomer.SapCode ==true)
            //                     && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //                      ).Contains(tbl_KaCustomer.SALORG_CTR)
            //                 select new
            //                 {
            //                     tbl_KaCustomer.Region,
            //                     tbl_KaCustomer.Customer,
            //                     tbl_KaCustomer.FullNameN,
            //                     tbl_KaCustomer.SapCode,

            //                 };




            //    Utils ut = new Utils();
            //    var tblcustomer = ut.ToDataTable(dc, rscode);

            //    Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, Choose one code !");
            //    viewtb.ShowDialog();
            //    string codetemp = viewtb.valuecode;
            //    if (codetemp != "0" && chon == true && codetemp != null)
            //    {

            //        tbl_kacontractCustcode cust = new tbl_kacontractCustcode();
            //        cust.ContractNo = contractNo;
            //        cust.CustomerCode = double.Parse(codetemp);
            //        cust.Addedby = username;

            //        dc.tbl_kacontractCustcodes.InsertOnSubmit(cust);
            //        dc.SubmitChanges();
            //        MessageBox.Show("Code :" + codetemp + " add to Groupcode done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //        //  cb_customerka.Text = codetempcodetemp
            //        //    cb_customerka.Enabled = false;
            //        //   cbcust.Checked = true;

            //    }
            //    // else
            //    //{
            //    //  cb_customerka.Text = "";
            //    //  cb_customerka.Enabled = true;
            //    //   cbcust.Checked = false;

            //    // }
            //     }
        }

        private void bteditCusgroup_Click(object sender, EventArgs e)
        {
            string contractNo = tb_contractno.Text.Trim();
            // cb_salesogr.Enabled = true;
            //   cb_salesogr.Focus();
            string Region1 = cb_salesogr.Text.Trim();




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();

            //  var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                 where tbl_Temp.username == username
            //           select tbl_Temp.RegionCode).FirstOrDefault();

            //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //               ).Contains(tbl_KaCustomer.SALORG_CTR)



            string contractcode = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                   where tbl_kacontractdata.ContractNo == contractNo
                                   select tbl_kacontractdata.Customer).FirstOrDefault().ToString();



            var rscode = from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                         where tbl_kacontractCustcode.ContractNo == contractNo
                         select new
                         {
                             // Region =   tbl_kacontractCustcode.,


                             Customer = tbl_kacontractCustcode.CustomerCode,

                             Name = tbl_kacontractCustcode.Name,

                             Region = Region1 + " : " + tbl_kacontractCustcode.ContractNo,

                             //       Contract = tbl_kacontractCustcode.ContractNo,


                             // , //Region,

                         };




            Utils ut = new Utils();
            var tblcustomer = ut.ToDataTable(dc, rscode);

            var rscode2 = from tbl_KaCustomer in dc.tbl_KaCustomers
                              //  where tbl_KaCustomer.ContractNo == contractNo
                          select new
                          {
                              // Region =   tbl_kacontractCustcode.,


                              Customer = tbl_KaCustomer.Customer,

                              Name = tbl_KaCustomer.FullNameN,

                              Region = tbl_KaCustomer.SalesOrg,//Region1,// + " : " + tbl_KaCustomer.ContractNo,
                                                               // custype  = tbl_KaCustomer.SapCode
                                                               //       Contract = tbl_kacontractCustcode.ContractNo,


                              // , //Region,

                          };
            var tblcustomer2 = ut.ToDataTable(dc, rscode2);

            Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, Choose one code !");



            viewtb.ShowDialog();
            string codetemp = viewtb.valuecode;

            if (codetemp != "0" && codetemp != null)
            {

                var rscoderemoved = (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                                     where tbl_kacontractCustcode.CustomerCode == double.Parse(codetemp)
                                     && tbl_kacontractCustcode.ContractNo == contractNo
                                    && tbl_kacontractCustcode.CustomerCode != double.Parse(contractcode)
                                     select tbl_kacontractCustcode).FirstOrDefault();


                if (rscoderemoved != null)
                {

                    dc.tbl_kacontractCustcodes.DeleteOnSubmit(rscoderemoved);
                    dc.SubmitChanges();
                    MessageBox.Show("Code :" + codetemp + " remove from Groupcode done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var rscoderemoved2 = from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                                         where tbl_kacontractCustcode.CustomerCode == double.Parse(codetemp)
                                         && tbl_kacontractCustcode.ContractNo == contractNo
                                             && tbl_kacontractCustcode.CustomerCode == double.Parse(contractcode)
                                         select tbl_kacontractCustcode;

                    if (rscoderemoved2.Count() > 1)
                    {
                        var rscoderemoved3 = (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                                              where tbl_kacontractCustcode.CustomerCode == double.Parse(codetemp)
                                              && tbl_kacontractCustcode.ContractNo == contractNo
                                                  && tbl_kacontractCustcode.CustomerCode == double.Parse(contractcode)
                                              select tbl_kacontractCustcode).FirstOrDefault();

                        if (rscoderemoved3 != null)
                        {
                            dc.tbl_kacontractCustcodes.DeleteOnSubmit(rscoderemoved3);
                            dc.SubmitChanges();
                            MessageBox.Show("Code :" + codetemp + " remove from Groupcode done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {


                        Model.Username us = new Model.Username();
                        if (us.masterdata == true)
                        {


                            Viewdatatable viewtb2 = new Viewdatatable(tblcustomer2, "Please, Choose one code to Replace the main code !");
                            viewtb2.ShowDialog();
                            string codetemp2 = viewtb2.valuecode;


                            if (codetemp2 != "0" && codetemp2 != null)
                            {

                                var updatenewcode = (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                                                     where tbl_kacontractCustcode.CustomerCode == double.Parse(codetemp)
                                                     && tbl_kacontractCustcode.ContractNo == contractNo
                                                         && tbl_kacontractCustcode.CustomerCode == double.Parse(contractcode)
                                                     select tbl_kacontractCustcode).FirstOrDefault();

                                if (updatenewcode != null)
                                {

                                    updatenewcode.CustomerCode = double.Parse(codetemp2);
                                    updatenewcode.Addedby = username;
                                    //   dc.tbl_kacontractCustcodes.DeleteOnSubmit(rscoderemoved3);
                                    dc.SubmitChanges();
                                    //  MessageBox.Show("Code :" + codetemp + " remove from Groupcode done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }


                                var updatenewcode3 = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                                                      where tbl_kacontractdata.ContractNo == contractNo
                                                      select tbl_kacontractdata).FirstOrDefault();

                                if (updatenewcode3 != null)
                                {
                                    // custype = updatenewcode3.CustomerType;
                                    updatenewcode3.Customer = double.Parse(codetemp2);
                                    //  updatenewcode2.Addedby = username;
                                    //   dc.tbl_kacontractCustcodes.DeleteOnSubmit(rscoderemoved3);
                                    dc.SubmitChanges();

                                }




                                var updatenewcode2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                                     where tbl_kacontractsdatadetail.ContractNo == contractNo
                                                     select tbl_kacontractsdatadetail;


                                foreach (var item in updatenewcode2)
                                {



                                    item.Customercode = double.Parse(codetemp2);
                                    //  updatenewcode2.Addedby = username;
                                    //   dc.tbl_kacontractCustcodes.DeleteOnSubmit(rscoderemoved3);
                                    dc.SubmitChanges();

                                }

                                if (cb_customerka.Text != "")
                                {
                                    cb_customerka.Text = codetemp2;
                                    txtfindsacode.Text = "";
                                }
                                else
                                {
                                    cb_customerka.Text = "";
                                    txtfindsacode.Text = codetemp2;
                                }


                                MessageBox.Show("Code :" + codetemp2 + " replece code: " + codetemp + "  done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);









                            }
                            else
                            {
                                MessageBox.Show("Code :" + codetemp + " is main code, that can not remove !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Code :" + codetemp + " is main code, that can not remove !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }



                    }

                }


            }




        }

        private void btchangevolcomit_Click(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new Volcomit to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            //-------------


            if (newremark != null && newremark != "")
            {
                string number = newremark.Trim();

                if (Utils.IsValidnumber(number))
                {

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                    var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                         where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                         select tbl_kacontractdata;

                    if (contractremark.Count() == 1)
                    {
                        foreach (var item in contractremark)
                        {
                            item.VolComm = double.Parse(number);
                        }

                        txt_volumecomit.Text = number.ToString();

                        dc.SubmitChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Volume comitment must be a number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            //-------------


        }

        private void btchangensrcomit_Click(object sender, EventArgs e)
        {
            View.valueinput valueiput = new valueinput("Please input new NSr Commit to change", "");
            valueiput.ShowDialog();


            String newremark = valueiput.valuetext;


            //-------------


            if (newremark != null && newremark != "")
            {
                string number = newremark.Trim();

                if (Utils.IsValidnumber(number))
                {

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                    var contractremark = from tbl_kacontractdata in dc.tbl_kacontractdatas
                                         where tbl_kacontractdata.ContractNo == tb_contractno.Text
                                         select tbl_kacontractdata;

                    if (contractremark.Count() == 1)
                    {
                        foreach (var item in contractremark)
                        {
                            item.NSRComm = double.Parse(number);
                        }

                        NSRcommit.Text = number.ToString();

                        dc.SubmitChanges();
                    }
                }
                else
                {
                    MessageBox.Show("NSR comitment must be a number", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                //-------------


            }
        }


        //class datasalesinput
        //{
        //    //  public System.Data.DataTable dataGrid1 { get; set; }
        //    //    public string filename { get; set; }
        //    public string Priod { get; set; }
        //    public string ContractNo { get; set; }
        ////    public CreatenewContract Creatcontract { get; set; }
        //    // CreatenewContract. lbcaculating.text lbcaculating { get;  set}
        //}

        //public CreatenewContract Creatcontract;
        //public static void reportsale(object objextoEl)
        //{

        //    datasalesinput dat = (datasalesinput)objextoEl;
        //    string Priod = dat.Priod;
        //    string ContractNo = dat.ContractNo;
        //    //    CreatenewContract Creatcontract = dat.Creatcontract;


        //}

        private void dtg_volumeachived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ContractNo = tb_contractno.Text;



            //      MessageBox.Show("Ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string Priod = "";
            try
            {
                Priod = this.dtg_volumeachived.Rows[this.dtg_volumeachived.CurrentCell.RowIndex].Cells["PRIOD"].Value.ToString();
            }
            catch (Exception)
            {

                Priod = "";
                //  MessageBox.Show(ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Exit sub;
                //throw;
            }

            //   MessageBox.Show("Priod: " + Priod, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            if (Priod != null && Priod != "") //&& lbcaculating.Text == ""
            {



                string username = Utils.getusername();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                //         dc.CommandTimeout = t
                //     Priod = Priod.Trim();

                #region convert PaymentinforContract begin to 
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("KAtempSalesContractPriod", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    cmd1.Parameters.Add("@Priod", SqlDbType.VarChar).Value = Priod;
                    cmd1.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
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



                //var Soldto = from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
                //             where tbl_kacontractCustcode.ContractNo == ContractNo
                //             select tbl_kacontractCustcode;
                ////   string connection_string = Utils.getConnectionstr();
                //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var sales = from tbl_kasalesTemp in dc.tbl_kasalesTemps
                            where tbl_kasalesTemp.Username == username
                            select new
                            {
                                tbl_kasalesTemp.Priod,
                                tbl_kasalesTemp.Sales_District,
                                tbl_kasalesTemp.Sales_District_desc,
                                tbl_kasalesTemp.Sales_Org,
                                tbl_kasalesTemp.Sold_to,
                                tbl_kasalesTemp.Cust_Name,
                                tbl_kasalesTemp.Outbound_Delivery,
                                tbl_kasalesTemp.Key_Acc_Nr,
                                tbl_kasalesTemp.Delivery_Date,
                                tbl_kasalesTemp.Invoice_Doc_Nr,
                                tbl_kasalesTemp.Invoice_Date,
                                tbl_kasalesTemp.Currency,
                                tbl_kasalesTemp.Mat_Group,
                                tbl_kasalesTemp.Mat_Group_Text,
                                tbl_kasalesTemp.Mat_Number,
                                tbl_kasalesTemp.Mat_Text,

                                PCs = tbl_kasalesTemp.EC,
                                tbl_kasalesTemp.UoM,
                                EC = tbl_kasalesTemp.PC,

                                tbl_kasalesTemp.UC,
                                tbl_kasalesTemp.Litter,
                                tbl_kasalesTemp.GSR,

                                tbl_kasalesTemp.NSR,





                                tbl_kasalesTemp.Username,
                                tbl_kasalesTemp.id


                            };

                Viewtable viewtbl = new Viewtable(sales, dc, "SALES REPORTS OF PRIOD: " + Priod, 100);// view code 1 la can viet them lenh

                viewtbl.ShowDialog();
                viewtbl.Focus();
                //  Creatcontract.ReloadKASeachcontract("");

            }





        }
        //   class datasalesinput2
        //   {
        //       //  public System.Data.DataTable dataGrid1 { get; set; }
        //       //    public string filename { get; set; }
        //       public DateTime fromdate { get; set; }
        //       public DateTime todate { get; set; }


        //       public string ContractNo { get; set; }
        ////       public CreatenewContract Creatcontract { get; set; }
        //       // CreatenewContract. lbcaculating.text lbcaculating { get;  set}
        //   }


        //  public static void reportsale2(object objextoE)
        //  {

        //      string connection_string = Utils.getConnectionstr();

        //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //      datasalesinput2 dat = (datasalesinput2)objextoE;
        //      //    string Priod = dat.Priod;
        //      DateTime fromdate = dat.fromdate;
        //      string ContractNo = dat.ContractNo;
        //      DateTime todate = dat.todate;
        //      //     CreatenewContract Creatcontract = dat.Creatcontract;

        //      string username = Utils.getusername();

        //      #region convert PaymentinforContract begin to 
        //      SqlConnection conn2 = null;
        //      SqlDataReader rdr1 = null;

        //      string destConnString = Utils.getConnectionstr();
        //      try
        //      {

        //          conn2 = new SqlConnection(destConnString);
        //          conn2.Open();
        //          SqlCommand cmd1 = new SqlCommand("KAtempSalesContractfromto", conn2);
        //          cmd1.CommandType = CommandType.StoredProcedure;
        //          cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        //          cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
        //          cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
        //          cmd1.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
        //          cmd1.CommandTimeout = 0;
        //          rdr1 = cmd1.ExecuteReader();



        //          //       rdr1 = cmd1.ExecuteReader();

        //      }
        //      finally
        //      {
        //          if (conn2 != null)
        //          {
        //              conn2.Close();
        //          }
        //          if (rdr1 != null)
        //          {
        //              rdr1.Close();
        //          }
        //      }
        //      //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //      #endregion



        //      var sales = from tbl_kasalesTemp in dc.tbl_kasalesTemps
        //                  where tbl_kasalesTemp.Username == username
        //                  select new
        //                  {
        //                      tbl_kasalesTemp.Priod,
        //                      tbl_kasalesTemp.Sales_District,
        //                      tbl_kasalesTemp.Sales_District_desc,
        //                      tbl_kasalesTemp.Sales_Org,
        //                      tbl_kasalesTemp.Sold_to,
        //                      tbl_kasalesTemp.Cust_Name,
        //                      tbl_kasalesTemp.Outbound_Delivery,
        //                      tbl_kasalesTemp.Key_Acc_Nr,
        //                      tbl_kasalesTemp.Delivery_Date,
        //                      tbl_kasalesTemp.Invoice_Doc_Nr,
        //                      tbl_kasalesTemp.Invoice_Date,
        //                      tbl_kasalesTemp.Currency,
        //                      tbl_kasalesTemp.Mat_Group,
        //                      tbl_kasalesTemp.Mat_Group_Text,
        //                      tbl_kasalesTemp.Mat_Number,
        //                      tbl_kasalesTemp.Mat_Text,

        //                      PCs = tbl_kasalesTemp.EC,
        //                      tbl_kasalesTemp.UoM,
        //                      EC = tbl_kasalesTemp.PC,

        //                      tbl_kasalesTemp.UC,
        //                      tbl_kasalesTemp.Litter,
        //                      tbl_kasalesTemp.GSR,

        //                      tbl_kasalesTemp.NSR,





        //                      tbl_kasalesTemp.Username,
        //                      tbl_kasalesTemp.id


        //                  };

        //      Viewtable viewtbl = new Viewtable(sales, dc, "SALES REPORTS OF CONTRACT : " + ContractNo, 100);// view code 1 la can viet them lenh


        //      //  viewtbl.BringToFront();
        //    //  viewtbl.TopMost = true;
        //      viewtbl.ShowDialog();
        //     viewtbl.Focus();
        ////    MessageBox.Show("OK: " + ContractNo + "---" + fromdate + "  " + todate, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        //      //   Creatcontract.ReloadKASeachcontract("");



        //  }



        //private void showwait()
        //{
        //    View.Caculating wat = new View.Caculating();
        //    wat.ShowDialog();


        //}


        private void button1_Click_8(object sender, EventArgs e)
        {


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
                tb_contractno.Focus();
                string ContractNo = tb_contractno.Text;

                if (kafromto.choose) //&& lbcaculating.Text == ""
                {


                    //  this.lbcaculating
                    // this.lbcaculating.Text = "Caculating ...";
                    //       ReloadKASeachcontract("Caculating ...");
                    //-----------

                    //Thread t1 = new Thread(reportsale2);
                    //t1.IsBackground = true;

                    ////   t1.STAThreadAttribute = true;
                    ////  t1.se
                    //t1.SetApartmentState(ApartmentState.STA);
                    //t1.Start(new datasalesinput2() { fromdate = fromdate, todate = todate, ContractNo = ContractNo});
                    ////Thread t2 = new Thread(showwait);
                    //t2.Start();
                    //////   autoEvent.WaitOne(); //join
                    //t1.Join();
                    //if (t1.ThreadState != ThreadState.Running)
                    //{



                    //    Thread.Sleep(1991);
                    //    t2.Abort();
                    //}

                    string connection_string = Utils.getConnectionstr();

                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                    string username = Utils.getusername();

                    #region convert PaymentinforContract begin to 
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("KAtempSalesContractfromto", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                        cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
                        cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
                        cmd1.Parameters.Add("@ContractNo", SqlDbType.VarChar).Value = ContractNo;
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



                    var sales = from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                where tbl_kasalesTemp.Username == username
                                select new
                                {
                                    tbl_kasalesTemp.Priod,
                                    tbl_kasalesTemp.Sales_District,
                                    tbl_kasalesTemp.Sales_District_desc,
                                    tbl_kasalesTemp.Sales_Org,
                                    tbl_kasalesTemp.Sold_to,
                                    tbl_kasalesTemp.Cust_Name,
                                    tbl_kasalesTemp.Outbound_Delivery,
                                    tbl_kasalesTemp.Key_Acc_Nr,
                                    tbl_kasalesTemp.Delivery_Date,
                                    tbl_kasalesTemp.Invoice_Doc_Nr,
                                    tbl_kasalesTemp.Invoice_Date,
                                    tbl_kasalesTemp.Currency,
                                    tbl_kasalesTemp.Mat_Group,
                                    tbl_kasalesTemp.Mat_Group_Text,
                                    tbl_kasalesTemp.Mat_Number,
                                    tbl_kasalesTemp.Mat_Text,

                                    PCs = tbl_kasalesTemp.EC,
                                    tbl_kasalesTemp.UoM,
                                    EC = tbl_kasalesTemp.PC,

                                    tbl_kasalesTemp.UC,
                                    tbl_kasalesTemp.Litter,
                                    tbl_kasalesTemp.GSR,

                                    tbl_kasalesTemp.NSR,





                                    tbl_kasalesTemp.Username,
                                    tbl_kasalesTemp.id


                                };

                    Viewtable viewtbl = new Viewtable(sales, dc, "SALES REPORTS OF CONTRACT : " + ContractNo, 100);// view code 1 la can viet them lenh


                    //  viewtbl.BringToFront();
                    //  viewtbl.TopMost = true;
                    viewtbl.ShowDialog();
                    viewtbl.Focus();
                    //    MessageBox.Show("OK: " + ContractNo + "---" + fromdate + "  " + todate, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }









            }






        }

        private void dtg_volumeachived_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click_2(object sender, EventArgs e)
        {


            string kq = Utils.IsValidContractName(tb_contractno.Text, cb_salesogr.Text, cb_contracttype.Text, cb_channel.Text);


            if (kq == "OK")
            {
                MessageBox.Show("OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                MessageBox.Show("Contract No Error, That must be :" + kq, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            };


        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
