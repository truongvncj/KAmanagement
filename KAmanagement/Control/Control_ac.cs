using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using KAmanagement.shared;
using KAmanagement.View;
using System.Threading;

using System.Net;
using System.Data.SqlClient;
using System.Data;

//KAmanagement.LinqtoSQLDataContext

namespace KAmanagement.Control
{
    class Control_ac
    {


  
        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        // ARlettermakebyGroupcodeRegion
        public static void VolumeupdateperContract(string Contractno)
        {

            string ContractNo = Contractno.Trim();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            //#region    //   xoa datavolume conytrac
            //dc.ExecuteCommand("DELETE FROM tbl_kacontractsvolume Where  tbl_kacontractsvolume.ContractNo = '" + ContractNo + "'");

        
            //dc.SubmitChanges();

            //#endregion//   xoa datavolume conytrac


            var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                            where tbl_kacontractdata.ContractNo.Equals(ContractNo)
                            select tbl_kacontractdata).FirstOrDefault();

            if (contract != null)
            {
                #region calulationvoluecontractdetail insql
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("calulationvoluecontractdetail", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                    cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = contract.ExtDate;
                    cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = contract.EffDate;

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

            }







        }

        // ARlettermakebyGroupcodeRegion
        public static void VolumeupdateperContractbyPRdgrp(string Contractno)
        {

            string ContractNo = Contractno.Trim();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region    //   xoa datavolume conytrac
            dc.CommandTimeout = 0;
            dc.ExecuteCommand("DELETE FROM tbl_kacontractsvolumePrductGRP Where  tbl_kacontractsvolumePrductGRP.ContractNo = '" + ContractNo + "'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            #endregion//   xoa datavolume conytrac

            #region // example

            var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                            where tbl_kacontractdata.ContractNo.Equals(ContractNo)
                            select tbl_kacontractdata).FirstOrDefault();

            if (contract != null)
            {

                #region calulationvoluecontractdetailbyGR insql
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("calulationvoluecontractdetailbyGR", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                    cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = contract.ExtDate;
                    cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = contract.EffDate;

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
            }

         
            #endregion example





        }


        public static void DeleteALLConvertContract()
        {
            // string ContractNo = Contractno;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
          


        }


        public static IQueryable getViewcontractMaster(LinqtoSQLDataContext db)
        {


            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in db.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();




            var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username
                               select Tka_RightContracttypeview.Contracttype;

            var rs = from tbl_kacontractdata in db.tbl_kacontractdatas
                     where (from Tka_RegionRight in db.Tka_RegionRights
                            where Tka_RegionRight.RegionCode == regioncode
                            select Tka_RegionRight.Region
                            ).Contains(tbl_kacontractdata.SalesOrg) && tbl_kacontractdata.Consts == "ALV"
                            && typecontract.Contains(tbl_kacontractdata.ConType)
                     orderby tbl_kacontractdata.ConType, tbl_kacontractdata.ContractNo

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
                         tbl_kacontractdata.COGS_ached,

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

                         PosBalance = tbl_kacontractdata.POS_Ached - tbl_kacontractdata.POS_paid, //achived

                         OthersBalance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid - tbl_kacontractdata.POS_Ached + tbl_kacontractdata.POS_paid, /// achived pos


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

            return rs;

        }

        public static void FormatViewcontractmaster(DataGridView dataGridView1)
        {

            #region  format


            //tbl_kacontractdata.ContractNo,
            //dataGridView1.Columns["ContractNo"].DisplayIndex = 0;
            ////             tbl_kacontractdata.SalesOrg,
            //dataGridView1.Columns["SalesOrg"].DisplayIndex = 1;
            ////             tbl_kacontractdata.ConType,//contract type
            //dataGridView1.Columns["ConType"].DisplayIndex = 2;
            ////             tbl_kacontractdata.Consts, //contract status
            //dataGridView1.Columns["Consts"].DisplayIndex = 3;
            ////             tbl_kacontractdata.Currency,
            //dataGridView1.Columns["Currency"].DisplayIndex = 4;
            ////             Validfrom = tbl_kacontractdata.EffDate,
            //dataGridView1.Columns["Validfrom"].DisplayIndex = 5;
            ////             Validto = tbl_kacontractdata.EftDate,
            //dataGridView1.Columns["Validto"].DisplayIndex = 6;
            ////  extDate
            //dataGridView1.Columns["extDate"].DisplayIndex = 7;

            ////             tbl_kacontractdata.Customer,
            //dataGridView1.Columns["Customer"].DisplayIndex = 8;
            ////             tbl_kacontractdata.Fullname,
            //dataGridView1.Columns["Fullname"].DisplayIndex = 9;
            ////    Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
            ////             tbl_kacontractdata.Channel,
            //dataGridView1.Columns["Address"].DisplayIndex = 10;
            //dataGridView1.Columns["Channel"].DisplayIndex = 11;
            ////             FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
            //dataGridView1.Columns["FullCommitment"].DisplayIndex = 12;
            dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                          //             tbl_kacontractdata.Cash,
                                                                                                                          //    dataGridView1.Columns["Cash"].DisplayIndex = 13;
            dataGridView1.Columns["Cash"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Cash"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                //             tbl_kacontractdata.FreeGood,
                                                                                                                //        dataGridView1.Columns["FreeGood"].DisplayIndex = 14;
            dataGridView1.Columns["FreeGood"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FreeGood"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                    //             tbl_kacontractdata.POS,
                                                                                                                    //                dataGridView1.Columns["POS"].DisplayIndex = 15;
            dataGridView1.Columns["POS"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["POS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                               //             tbl_kacontractdata.MKTFun,
                                                                                                               //                    dataGridView1.Columns["MKTFun"].DisplayIndex = 16;
            dataGridView1.Columns["MKTFun"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["MKTFun"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             AchivedCommitment = tbl_kacontractdata.TotDeal,
            //       dataGridView1.Columns["AchivedCommitment"].DisplayIndex = 17;
            dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                             //             tbl_kacontractdata.Tot_paid,
                                                                                                                             //          dataGridView1.Columns["Tot_paid"].DisplayIndex = 18;
            dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                    //             tbl_kacontractdata.Cash_paid,
                                                                                                                    //                   dataGridView1.Columns["Cash_paid"].DisplayIndex = 19;
            dataGridView1.Columns["Cash_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Cash_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.FreeGood_paid,

            //        dataGridView1.Columns["FreeGood_paid"].DisplayIndex = 20;
            dataGridView1.Columns["FreeGood_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FreeGood_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.POS_paid,

            //     dataGridView1.Columns["POS_paid"].DisplayIndex = 21;
            dataGridView1.Columns["POS_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["POS_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.MKTFun_paid,

            //       dataGridView1.Columns["MKTFun_paid"].DisplayIndex = 22;
            dataGridView1.Columns["MKTFun_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["MKTFun_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,

            dataGridView1.Columns["Balance"].DisplayIndex = 23;
            dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



            dataGridView1.Columns["PosBalance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["PosBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            dataGridView1.Columns["OthersBalance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["OthersBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             VolumeCommit = tbl_kacontractdata.VolComm,



            //  dataGridView1.Columns["VolumeCommit"].DisplayIndex = 24;
            dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //     tbl_kacontractdata.NSRComm,
            dataGridView1.Columns["NSRComm"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["NSRComm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //             tbl_kacontractdata.PCVolAched,

            //    dataGridView1.Columns["PCVolAched"].DisplayIndex = 25;
            dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.NSRAched,
            //   dataGridView1.Columns["NSRAched"].DisplayIndex = 26;
            dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.UCVolAched,
            //   dataGridView1.Columns["UCVolAched"].DisplayIndex = 27;
            dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //     dataGridView1.Columns["Revenue"].DisplayIndex = 28;
            dataGridView1.Columns["Revenue"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //
            dataGridView1.Columns["Promotion"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Promotion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            dataGridView1.Columns["Promotion_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Promotion_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.CRDDAT,
            //        dataGridView1.Columns["CRDDAT"].DisplayIndex = 29;

            //             tbl_kacontractdata.CRDUSR,
            //        dataGridView1.Columns["CRDUSR"].DisplayIndex = 30;





            #endregion

            // return null;

        }
        public static void ConvertALLBeginMasterCont()
        {



            #region convert masterContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConverMasterContract", conn2);
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


            #region convert DetailContract begin to 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConvertDetailContract", conn2);
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


            #region convert PaymentinforContract begin to 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConvertPaymentContract", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                //  cmd1.CommandTimeout = 0;
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


        }// end frunction



        public static void AccrualContractinSQL(DateTime Accrualdate)
        {
            if (Accrualdate != null)
            {

                #region tính tren sa

                //  Control.Control_ac.CaculationALLContractinSQLbySQL();

                SqlConnection conn2 = null;

                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("AccrualContractinSQLbySQL", conn2);
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Accrualdate", SqlDbType.DateTime).Value = Accrualdate;

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

                //     #endregion


                #endregion


            }



        }

        public static void CaculationALLContractinSQL()
        {
            #region tính tren sa

            //  Control.Control_ac.CaculationALLContractinSQLbySQL();

            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("CaculationALLContractinSQLbySQL2", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //  cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
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

            //     #endregion


            #endregion


            //#region // tính  hợp đồng trên phương thức 1



            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var contractrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                 where tbl_kacontractdata.Consts == "ALV"
            //                 select tbl_kacontractdata.ContractNo;

            //if (contractrs.Count() > 0)
            //{
            //    foreach (var item in contractrs)
            //    {
            //   //     CaculationContractinSQLmaster(item);


            //        Control_ac.CaculationContract(item); // tinhs toasn contract truo c khi view

            //        Control.Control_ac.CaculationContractinSQLmaster(item);


            //    }




            //}
            //#endregion    

        }
        public static void CaculationContractinSQLmaster(string Contractno)
        {

            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaCaculationContractinSQLmaster", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
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


        }


        public static void CaculationContract(string Contractno)
        {


            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaCaculationContractinSQLdetail", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
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






        }
        public IQueryable KArptdataset2(LinqtoSQLDataContext db)
        {

            string usrname = Utils.getusername();
            //    var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_KAdetailprogrRpt in db.tbl_KAdetailprogrRpts
                     where tbl_KAdetailprogrRpt.Username == usrname
                     select tbl_KAdetailprogrRpt;

            return rs;




            //  throw new NotImplementedException();
        }

        public IQueryable KArptdataset1(LinqtoSQLDataContext db)
        {



            #region lấy dữ liệu bảng ar letter reports ra
            string usrname = Utils.getusername();

            var rs = from tbl_KapaymentrequestRpt in db.tbl_KapaymentrequestRpts
                     where tbl_KapaymentrequestRpt.Username == usrname
                     select tbl_KapaymentrequestRpt;

            return rs;

            #endregion lấy dữ liệu bảng ar letter reports ra


        }


        class datatoExport
        {
            public System.Data.DataTable dataGrid1 { get; set; }
            public string filename { get; set; }
            public string tittle { get; set; }
        }

        public static void caculationAllContract()
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var contractrs = from tbl_kacontractbegindata in dc.tbl_kacontractbegindatas
                             select tbl_kacontractbegindata.ContractNo;

            if (contractrs.Count() > 0)
            {
                foreach (var item in contractrs)
                {
                    CaculationContract(item);
                }




            }





        }

        public static void exportsexcel(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;

            //    DataTable dataTble = new DataTable();
            //   DataSet dataSet, string outputPath

            // Create the Excel Application object
            cExcel.ApplicationClass excelApp = new cExcel.ApplicationClass();

            // Create a new Excel Workbook
            cExcel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

            int sheetIndex = 0;
            System.Data.DataTable dt = dat.dataGrid1;
            var tittle = dat.tittle;
            var filename = dat.filename;

            // Copy the DataTable to an object array
            object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

            // Copy the column names to the first row of the object array
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                rawData[0, col] = dt.Columns[col].ColumnName;
            }

            // Copy the values to the object array
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                }
            }

            // Calculate the final column letter
            string finalColLetter = string.Empty;
            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;

            if (dt.Columns.Count > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                    (dt.Columns.Count - 1) % colCharsetLen, 1);

            // Create a new Sheet
            cExcel.Worksheet excelSheet = (cExcel.Worksheet)excelWorkbook.Sheets.Add(
                excelWorkbook.Sheets.get_Item(++sheetIndex),
                Type.Missing, 1, cExcel.XlSheetType.xlWorksheet);

            //         excelSheet.Name = dt.TableName;

            // Fast data export to Excel
            string excelRange = string.Format("A1:{0}{1}",
                finalColLetter, dt.Rows.Count + 1);

            excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

            // Mark the first row as BOLD
            ((cExcel.Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;


            // Save and Close the Workbook


            excelWorkbook.SaveAs(filename, cExcel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, cExcel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            //   xlApp.Quit();



            //excelWorkbook.SaveAs(outputPath, cExcel.XlFileFormat.xlWorkbookNormal, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, cExcel.XlSaveAsAccessMode.xlExclusive,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //excelWorkbook.Close(true, Type.Missing, Type.Missing);
            //excelWorkbook = null;

            // Release the Application object
            excelApp.Quit();
            excelApp = null;

            // Collect the unreferenced objects
            GC.Collect();
            GC.WaitForPendingFinalizers();



            MessageBox.Show(filename + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void exportExceldatagridtofile(IQueryable IQuery, LinqtoSQLDataContext db, string tittle)
        {


            System.Data.DataTable datatable1 = new System.Data.DataTable();
            //

            Utils ul = new Utils();

            datatable1 = ul.ToDataTable(db, IQuery);


            foreach (var c in datatable1.Columns)
            {
                DataColumn clm = (DataColumn)c;
                clm.ColumnName = clm.ColumnName.Replace("_", " ");
            }


            //  this.dataGridView2.DataSource =  dataGridView1.DataSource;
            //
            #region // connect to excel
            SaveFileDialog theDialog = new SaveFileDialog();
            //


            //   DataGridView dataGridView1 = new DataGridView();
            //   dataGridView1.DataSource = dataGrid.DataSource;

            theDialog.Title = "Export to Excel file";
            theDialog.Filter = "Excel files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";

            #endregion
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                //   DataGridView datagr1 = new DataGridView();
                //  datagr1 = dataGrid1;

                Thread t1 = new Thread(exportsexcel);
                t1.IsBackground = true;
                t1.Start(new datatoExport() { dataGrid1 = datatable1, filename = filename, tittle = tittle });
                // t1.Join();
            }



        }




    }

}