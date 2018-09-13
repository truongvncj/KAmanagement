using KAmanagement.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.Model
{
    class Contract
    {



        public bool deleteallbegincontract()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            // var rs = from tbl_Remark in db.tbl_Remarks
            //            select tbl_Remark;
            db.ExecuteCommand("DELETE FROM tbl_kacontractbegindata");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }

     



        public static bool checkispaidandalive(string contractNo)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            var rs = (from tbl_kacontractsdetailpayment in db.tbl_kacontractsdetailpayments
                      where tbl_kacontractsdetailpayment.ContractNo.Equals(contractNo) && tbl_kacontractsdetailpayment.PayControl == "REQ"
                      && tbl_kacontractsdetailpayment.BatchNo != 0
                      select tbl_kacontractsdetailpayment.ContractNo).FirstOrDefault();

            var rs1 = (from tbl_kacontractdata in db.tbl_kacontractdatas
                       where tbl_kacontractdata.ContractNo == contractNo && tbl_kacontractdata.Consts != "ALV"
                       select tbl_kacontractdata.Consts).FirstOrDefault();

            if (rs != null || rs1 != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool deleteallcontractbegindetail()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            // var rs = from tbl_Remark in db.tbl_Remarks
            //            select tbl_Remark;

            db.ExecuteCommand("DELETE FROM tbl_kacontractbegindatadetail");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }


        public IQueryable Setlect_all_begin(LinqtoSQLDataContext db)
        {

            //var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_kacontractbegindata in db.tbl_kacontractbegindatas
                     select tbl_kacontractbegindata;

            return rs;

        }




        class datainportF
        {

            public string filename { get; set; }

        }

        public void inputempmastercontract()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract Master excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importempmastercontractsexcel2);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });


                View.Caculating wat = new View.Caculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        public void inputempdetailcontract()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract detail excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importempdetailcontractsexcel2);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                View.Caculating wat = new View.Caculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }




            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        public void inputcontract()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importexcelcontract);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });


                View.Caculating wat = new View.Caculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }




            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        private void importempmastercontractsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();




            db.ExecuteCommand("DELETE FROM tbl_tempmastercontractmasscreate where Username = '" + username+"'" );
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            datainportF inf = (datainportF)obj;
            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

            //------
            //---------------fill data


            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);
            //        Sales Group Sales Group desc Sales Off Sales Office Desc

            System.Data.DataTable batable = new System.Data.DataTable();
            batable.Columns.Add("ContractNo", typeof(string));
            batable.Columns.Add("SalesOrg", typeof(string));
             batable.Columns.Add("ConType", typeof(string));
            batable.Columns.Add("ExtendDate", typeof(DateTime));
            batable.Columns.Add("EftoDate", typeof(DateTime));
            batable.Columns.Add("EfFromDate", typeof(DateTime));
            batable.Columns.Add("Customer", typeof(double));
              batable.Columns.Add("Fullname", typeof(string));
            batable.Columns.Add("Representative", typeof(string));
            batable.Columns.Add("Channel", typeof(string));
            batable.Columns.Add("DeliveredBy", typeof(string));
            batable.Columns.Add("HouseNo", typeof(string));
            batable.Columns.Add("District", typeof(string));
            batable.Columns.Add("Province", typeof(string));
            batable.Columns.Add("VATregistrationNo", typeof(string));
              batable.Columns.Add("CreditLimit", typeof(double));
            batable.Columns.Add("CreditTerm", typeof(string));
            batable.Columns.Add("NSRCommitment", typeof(double));
             batable.Columns.Add("VolCommitment", typeof(double));
                   batable.Columns.Add("Remark", typeof(string));
            batable.Columns.Add("Username", typeof(string));

            #region setcolum







            int ContractNoid = -1;
            int SalesOrgid = -1;
              int ConTypeid = -1;
            int ExtendDateid = -1;
            int EftoDateid = -1;
            int EfFromDateid = -1;
            int Customerid = -1;
               int Fullnameid = -1;
           int Representativeid = -1;
           int Channelid = -1;
            int DeliveredByid = -1;
            int HouseNoid = -1;
            int Districtid = -1;
            int Provinceid = -1;
            int VATregistrationNoid = -1;
            int CreditLimitid = -1;
            int CreditTermid = -1;
            int NSRCommitmentid = -1;
             int VolCommitmentid = -1;
            int Remarkid = -1;
     

            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    string value;
                    try
                    {
                         value = sourceData.Rows[rowid][columid].ToString();
                    }
                    catch (Exception)
                    {

                        value = null;
                    }

               
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "ContractNo")
                        {
                            ContractNoid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Sales Org"))
                        {

                            SalesOrgid = columid;
                            //   headindex = rowid;

                        }


                        if (value.Trim() == ("Con Type"))
                        {

                            ConTypeid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == ("Extend Date"))
                        {

                            ExtendDateid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == "Sales Org")
                        {
                            SalesOrgid = columid;
                            // headindex = rowid;
                        }
                        if (value.Trim() == "Ef From Date")
                        {
                            EfFromDateid = columid;
                            //   headindex = rowid;
                        }

                        if (value.Trim() == "Ef to Date")
                        {
                            EftoDateid = columid;
                            //    headindex = rowid;
                        }

                        if (value.Trim() == "Customer")
                        {
                            Customerid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == "Fullname")
                        {
                            Fullnameid = columid;
                            //   headindex = rowid;
                        }

                        if (value.Trim() == "Representative")
                        {
                            Representativeid = columid;
                            //  headindex = rowid;
                        }
                        if (value.Trim() == "Channel")
                        {
                            Channelid = columid;
                            //     headindex = rowid;
                        }
                        if (value.Trim() == "DeliveredBy")
                        {
                            DeliveredByid = columid;
                            //   headindex = rowid;
                        }
                        if (value.Trim() == "HouseNo")
                        {
                            HouseNoid = columid;
                            //     headindex = rowid;
                        }
                        if (value.Trim() == "District")
                        {
                            Districtid = columid;
                            //    headindex = rowid;
                        }
                        if (value.Trim() == "Province")
                        {
                            Provinceid = columid;
                            //    headindex = rowid;
                        }
                        if (value.Trim() == "VATregistrationNo")
                        {
                            VATregistrationNoid = columid;
                            //     headindex = rowid;
                        }
                        if (value.Trim() == "CreditLimit")
                        {
                            CreditLimitid = columid;
                            // headindex = rowid;
                        }
                        if (value.Trim().Contains("CreditTerm"))
                        {
                            CreditTermid = columid;
                            // headindex = rowid;
                        }

                        if (value.Trim() == "Vol Commitment")
                        {
                            VolCommitmentid = columid;
                            //   headindex = rowid;
                        }

                        if (value.Trim() == "NSR Commitment")
                        {
                            NSRCommitmentid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == "Remarks")
                        {
                            Remarkid = columid;
                            //  headindex = rowid;
                        }

               
                        #endregion

                    }


                }// colum



            }// roww off heatder

            #endregion


            if (ContractNoid == -1)
            {
                MessageBox.Show("Please check ContractNo colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (SalesOrgid == -1)
            {
                MessageBox.Show("Please check Sales Org", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ConTypeid == -1)
            {
                MessageBox.Show("Please check ConType  colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ExtendDateid == -1)
            {
                MessageBox.Show("Please check Extend Date colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SalesOrgid == -1)
            {
                MessageBox.Show("Please check SalesOrg colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EftoDateid == -1)
            {
                MessageBox.Show("Please check Ef to Date colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EfFromDateid == -1)
            {
                MessageBox.Show("Please check Ef From Date colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Customerid == -1)
            {
                MessageBox.Show("Please check Customer colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Fullnameid == -1)
            {
                MessageBox.Show("Please check Fullname colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Representativeid == -1)
            {
                MessageBox.Show("Please check  Representative colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Channelid == -1)
            {
                MessageBox.Show("Please check Channel colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DeliveredByid == -1)
            {
                MessageBox.Show("Please check DeliveredBy colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (HouseNoid == -1)
            {
                MessageBox.Show("Please check HouseNo colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Districtid == -1)
            {
                MessageBox.Show("Please check District colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (VATregistrationNoid == -1)
            {
                MessageBox.Show("Please check VATregistrationNo colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CreditLimitid == -1)
            {
                MessageBox.Show("Please check CreditLimit colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CreditTermid == -1)
            {
                MessageBox.Show("Please check CreditTerm colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NSRCommitmentid == -1)
            {
                MessageBox.Show("Please check NSRCommitment colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (VolCommitmentid == -1)
            {
                MessageBox.Show("Please check VolCommitment colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Remarkid == -1)
            {
                MessageBox.Show("Please check Remarks colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


          


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                // && Utils.IsValidateddmm(sourceData.Rows[rowixd][EfFromDateid].ToString()
                string ContractNo = sourceData.Rows[rowixd][ContractNoid].ToString();

                if (ContractNo != "" && rowixd>0)
                {


                    DataRow dr = batable.NewRow();
                    dr["ContractNo"] = sourceData.Rows[rowixd][ContractNoid].ToString();
                    dr["SalesOrg"] = sourceData.Rows[rowixd][SalesOrgid].ToString().Trim();
                    dr["ConType"] = sourceData.Rows[rowixd][ConTypeid].ToString().Trim();

                    dr["ExtendDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][ExtendDateid].ToString().Trim());

                    dr["EftoDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][EftoDateid].ToString().Trim());
                    dr["EfFromDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][EfFromDateid].ToString().Trim());
                    dr["Representative"] = sourceData.Rows[rowixd][Representativeid].ToString().Trim();
                    dr["Channel"] = sourceData.Rows[rowixd][Channelid].ToString().Trim();
                    dr["DeliveredBy"] = sourceData.Rows[rowixd][DeliveredByid].ToString().Trim();

                    if (sourceData.Rows[rowixd][Customerid].ToString() != "" && sourceData.Rows[rowixd][Customerid] != null)
                    {
                        dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString().Trim());

                    }

                    dr["Fullname"] = sourceData.Rows[rowixd][Fullnameid].ToString().Trim();
                    dr["HouseNo"] = sourceData.Rows[rowixd][HouseNoid].ToString().Trim();//.Trim();
                    dr["District"] = sourceData.Rows[rowixd][Districtid].ToString().Trim();
                    dr["Province"] = sourceData.Rows[rowixd][Provinceid].ToString().Trim();
                    dr["VATregistrationNo"] = sourceData.Rows[rowixd][VATregistrationNoid].ToString().Trim();
                    if (sourceData.Rows[rowixd][CreditLimitid].ToString() != "" && sourceData.Rows[rowixd][CreditLimitid] != null)
                    {
                        dr["CreditLimit"] = double.Parse(sourceData.Rows[rowixd][CreditLimitid].ToString().Trim());
                    }
                    dr["CreditTerm"] = sourceData.Rows[rowixd][CreditTermid].ToString().Trim();
                    if (sourceData.Rows[rowixd][NSRCommitmentid].ToString() != "" && sourceData.Rows[rowixd][NSRCommitmentid] != null)
                    {
                        dr["NSRCommitment"] = double.Parse(sourceData.Rows[rowixd][NSRCommitmentid].ToString().Trim());
                    }
                    if (sourceData.Rows[rowixd][VolCommitmentid].ToString() != "" && sourceData.Rows[rowixd][VolCommitmentid] != null)
                    {
                        dr["VolCommitment"] = double.Parse(sourceData.Rows[rowixd][VolCommitmentid].ToString().Trim());

                    }
                    dr["Remark"] = sourceData.Rows[rowixd][Remarkid].ToString().Trim();
                    //  Remarks
                    dr["Username"] = username;
                  
                                    batable.Rows.Add(dr);


                }



                #endregion

            }// row





            string destConnString = Utils.getConnectionstr();

            //---------------fill data
       
         
                   using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_tempmastercontractmasscreate";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("SalesOrg", "SalesOrg");

                bulkCopy.ColumnMappings.Add("ConType", "ConType");
                bulkCopy.ColumnMappings.Add("ExtendDate", "ExtendDate");
                bulkCopy.ColumnMappings.Add("EftoDate", "EftoDate");
                bulkCopy.ColumnMappings.Add("EfFromDate", "EfFromDate");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Fullname", "Fullname");
                bulkCopy.ColumnMappings.Add("Representative", "Representative");
                bulkCopy.ColumnMappings.Add("Channel", "Channel");
                bulkCopy.ColumnMappings.Add("DeliveredBy", "DeliveredBy");
                bulkCopy.ColumnMappings.Add("HouseNo", "HouseNo");
                bulkCopy.ColumnMappings.Add("District", "District");
                bulkCopy.ColumnMappings.Add("Province", "Province");
                bulkCopy.ColumnMappings.Add("VATregistrationNo", "VATregistrationNo");
                bulkCopy.ColumnMappings.Add("CreditLimit", "CreditLimit");
                bulkCopy.ColumnMappings.Add("CreditTerm", "CreditTerm");
                bulkCopy.ColumnMappings.Add("NSRCommitment", "NSRCommitment");
                bulkCopy.ColumnMappings.Add("VolCommitment", "VolCommitment");
                bulkCopy.ColumnMappings.Add("Remark", "Remark");
                bulkCopy.ColumnMappings.Add("Username", "Username");
                
                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }

            //  ExcelProvide.releaseObject();
         //   ExcelProvide.releaseObject();


        }

        private void importempdetailcontractsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();




            db.ExecuteCommand("DELETE FROM tbl_tempcontractsdatadetail where Username = '" + username+"'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            datainportF inf = (datainportF)obj;
            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

     //   [StatusNote]
      //,[ContractNo]
      //,[]
      //,[]
      //,[]
      //,[]
      //,[Sponsored Amount]
      //,[Remark]
      //,[]
      //,[]
      //,[id]
      //,[Username]


        ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);
            //        Sales Group Sales Group desc Sales Off Sales Office Desc

            System.Data.DataTable batable = new System.Data.DataTable();
            batable.Columns.Add("ContractNo", typeof(string));
            batable.Columns.Add("Programe", typeof(string));
            batable.Columns.Add("PayControl", typeof(string));
            batable.Columns.Add("Description", typeof(string));
            batable.Columns.Add("PrdGrp", typeof(string));
            batable.Columns.Add("SponsoredAmount", typeof(double));
            batable.Columns.Add("Remark", typeof(string));
            batable.Columns.Add("EffFrom", typeof(DateTime));
            batable.Columns.Add("EffTo", typeof(DateTime));
            batable.Columns.Add("Username", typeof(string));

         


          
            batable.Columns["Username"].DefaultValue = username;

            #region setcolum







            int ContractNoid = -1;
            int Programeid = -1;
            int PayControlid = -1;
            int Descriptionid = -1;
            int PrdGrpid = -1;
            int SponsoredAmountid = -1;
            int Remarkid = -1;
            int EffFromid = -1;

            int EffToid = -1;

         

            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    string value;
                    try
                    {
                         value = sourceData.Rows[rowid][columid].ToString();
                    }
                    catch (Exception)
                    {

                        value = null;
                    }
                 
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "ContractNo")
                        {
                            ContractNoid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("Programe"))
                        {

                            Programeid = columid;
                            //   headindex = rowid;

                        }


                        if (value.Trim() == ("PayControl"))
                        {

                            PayControlid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == ("Description"))
                        {

                            Descriptionid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == "PrdGrp")
                        {
                            PrdGrpid = columid;
                            // headindex = rowid;
                        }
                        if (value.Trim() == "Sponsored Amount")
                        {
                            SponsoredAmountid = columid;
                            //   headindex = rowid;
                        }

                        if (value.Trim() == "Remark")
                        {
                            Remarkid = columid;
                            //    headindex = rowid;
                        }

                        if (value.Trim() == "Eff From")
                        {
                            EffFromid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == "Eff To")
                        {
                            EffToid = columid;
                            //   headindex = rowid;
                        }

                      
                        #endregion

                    }


                }// colum



            }// roww off heatder

            #endregion


            if (ContractNoid == -1)
            {
                MessageBox.Show("Please check ContractNo colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Programeid == -1)
            {
                MessageBox.Show("Please check Programe colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PayControlid == -1)
            {
                MessageBox.Show("Please check PayControl colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Descriptionid == -1)
            {
                MessageBox.Show("Please check Description colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PrdGrpid == -1)
            {
                MessageBox.Show("Please check PrdGrp colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SponsoredAmountid == -1)
            {
                MessageBox.Show("Please check SponsoredAmount colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Remarkid == -1)
            {
                MessageBox.Show("Please check Remark colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EffFromid == -1)
            {
                MessageBox.Show("Please check Eff From colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EffToid == -1)
            {
                MessageBox.Show("Please check Eff To  colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        

            for (int rowixd = 1; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string ContractNo = sourceData.Rows[rowixd][ContractNoid].ToString();
                if (ContractNo != "" )
                {
                 

                    DataRow dr = batable.NewRow();
                    dr["ContractNo"] = sourceData.Rows[rowixd][ContractNoid].ToString().Trim();
                    dr["Programe"] = sourceData.Rows[rowixd][Programeid].ToString().Trim();
                    dr["PayControl"] = sourceData.Rows[rowixd][PayControlid].ToString().Trim();

                    dr["Description"] = sourceData.Rows[rowixd][Descriptionid].ToString().Trim();
                    dr["PrdGrp"] = sourceData.Rows[rowixd][PrdGrpid].ToString().Trim();

                    if (sourceData.Rows[rowixd][SponsoredAmountid].ToString() != "" && sourceData.Rows[rowixd][SponsoredAmountid] != null)
                    {
                        dr["SponsoredAmount"] = double.Parse(sourceData.Rows[rowixd][SponsoredAmountid].ToString().Trim());
                    }

                    dr["Remark"] = sourceData.Rows[rowixd][Remarkid].ToString().Trim();
                    dr["EffFrom"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][EffFromid].ToString().Trim());
                    dr["EffTo"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][EffToid].ToString().Trim());



                    batable.Rows.Add(dr);


                }



                #endregion

            }// row





            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_tempcontractsdatadetail";
       
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "[ContractNo]");
                bulkCopy.ColumnMappings.Add("Programe", "[Programe]");
                bulkCopy.ColumnMappings.Add("PayControl", "[PayControl]");
                bulkCopy.ColumnMappings.Add("Description", "[Description]");
                bulkCopy.ColumnMappings.Add("PrdGrp", "[PrdGrp]");
                bulkCopy.ColumnMappings.Add("SponsoredAmount", "[Sponsored Amount]");
                bulkCopy.ColumnMappings.Add("Remark", "[Remark]");
                bulkCopy.ColumnMappings.Add("EffFrom", "[EffFrom]");
                bulkCopy.ColumnMappings.Add("EffTo", "[EffTo]");

                bulkCopy.ColumnMappings.Add("Username", "[Username]");


                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }





        }

        public void inputcontractdetail()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importexcelcontractdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                View.Caculating wat = new View.Caculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }


        class datashowwait
        {

            public View.Caculating wat { get; set; }


        }



        private void showwait(object obj)
        {
            // View.Caculating wat = new View.Caculating();

            //            View.Caculating wat = (View.Caculating)obj;
            datashowwait obshow = (datashowwait)obj;

            View.Caculating wat = obshow.wat;

            wat.ShowDialog();


        }


        private void importexcelcontract(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            //Contract Rm = new Contract();

            //bool kq = Rm.deleteallbegincontract();



            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

            //------
            //---------------fill data

            System.Data.DataTable sourceData = new System.Data.DataTable();
            using (OleDbConnection conn =
                                   new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Open connextion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Get the data from the source table as a SqlDataReader.

                //            

                OleDbCommand command = new OleDbCommand(
                                                    @"SELECT ContractNo, SalesOrg,Consts,
ConType, MEANo,EffDate,
EftDate, ExtDate,Customer,


Representative, Channel,DeliveredBy,
CreditLimit, CreditTerm,ConTerm,
AnnualVolume, VolComm,UN,
NSRComm, NSRPer,PrdGrp,
Revenue, VolAched,VolAched_S,
VolPer, VolPer_S,LitPer,
LitAched, FTNAched,NSRAched,
TotDeal, Currency,Cash,
POS, FreeGood,Promotion,


MKTFunPer, MKTFun,Cash_Acc,
POS_Acc, FreeGood_Acc,Promotion_Acc,
MKTFun_Acc, SponsorPerCase,TotDealPC,
CashPC, POSPC,FreeGoodPC,
PromotionPC, MKTFunPC,Tot_paid,
Cash_paid, POS_paid,FreeGood_paid,
Promotion_paid, MKTFun_paid,Tot_rem,
Cash_rem, POS_rem,FreeGood_rem,
Promotion_rem, MKTFun_rem,Remarks,
CRDDAT, CRDUSR,UPDDAT,


UPDUSR, BatchNo,SignOn,
MFD, SALORG_CTR,EftNoOfMonth,
CurrentMonth



                                     FROM [Sheet1$]
                                     WHERE ( ContractNo is not null ) ", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                //adapter.FillSchema(sourceData, SchemaType.Source);
                //sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
                //sourceData.Columns["Invoice Doc Nr"].DataType = typeof(float);
                //sourceData.Columns["Billed Qty"].DataType = typeof(float);
                //sourceData.Columns["Cond Value"].DataType = typeof(float);
                //sourceData.Columns["Sales Org"].DataType = typeof(string);
                //sourceData.Columns["Cust Name"].DataType = typeof(string);
                //sourceData.Columns["Outbound Delivery"].DataType = typeof(string);
                //sourceData.Columns["Mat Group"].DataType = typeof(string);
                //sourceData.Columns["Mat Group Text"].DataType = typeof(string);
                //sourceData.Columns["UoM"].DataType = typeof(string);


                try
                {

                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }

            //   Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                //                @"SELECT ContractNo, SalesOrg,ConType,
                //  Consts, Currency,EffDate,
                //  ExtDate, Customer,CustomerGroup,
                //  FullName, Channel,TotDeal,
                //  Tot_paid, Tot_rem,VolComm,
                //  VolAched, VolPer,CRDDAT,
                //  CRDUSR, UPDDAT,UPDUSR,
                //  SignOn



                bulkCopy.DestinationTableName = "tbl_kacontractbegindata";
                // Write from the source to the destination.

                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("SalesOrg", "SalesOrg");
                bulkCopy.ColumnMappings.Add("Consts", "Consts");
                bulkCopy.ColumnMappings.Add("ConType", "ConType");
                bulkCopy.ColumnMappings.Add("MEANo", "MEANo");
                bulkCopy.ColumnMappings.Add("EffDate", "EffDate");
                bulkCopy.ColumnMappings.Add("EftDate", "EftDate");
                bulkCopy.ColumnMappings.Add("ExtDate", "ExtDate");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Representative", "Representative");
                bulkCopy.ColumnMappings.Add("Channel", "Channel");
                bulkCopy.ColumnMappings.Add("DeliveredBy", "DeliveredBy");
                bulkCopy.ColumnMappings.Add("CreditLimit", "CreditLimit");
                bulkCopy.ColumnMappings.Add("CreditTerm", "CreditTerm");
                bulkCopy.ColumnMappings.Add("ConTerm", "ConTerm");
                bulkCopy.ColumnMappings.Add("AnnualVolume", "AnnualVolume");
                bulkCopy.ColumnMappings.Add("VolComm", "VolComm");
                bulkCopy.ColumnMappings.Add("UN", "UN");
                bulkCopy.ColumnMappings.Add("NSRComm", "NSRComm");
                bulkCopy.ColumnMappings.Add("PrdGrp", "PrdGrp");
                bulkCopy.ColumnMappings.Add("Revenue", "Revenue");


                bulkCopy.ColumnMappings.Add("VolAched", "VolAched");




                bulkCopy.ColumnMappings.Add("VolAched_S", "VolAched_S");
                bulkCopy.ColumnMappings.Add("VolPer", "VolPer");
                bulkCopy.ColumnMappings.Add("VolPer_S", "VolPer_S");
                bulkCopy.ColumnMappings.Add("LitPer", "LitPer");
                bulkCopy.ColumnMappings.Add("LitAched", "LitAched");
                bulkCopy.ColumnMappings.Add("FTNAched", "FTNAched");
                bulkCopy.ColumnMappings.Add("NSRAched", "NSRAched");
                bulkCopy.ColumnMappings.Add("TotDeal", "TotDeal");
                bulkCopy.ColumnMappings.Add("Currency", "Currency");
                bulkCopy.ColumnMappings.Add("Cash", "Cash");
                bulkCopy.ColumnMappings.Add("POS", "POS");
                bulkCopy.ColumnMappings.Add("FreeGood", "FreeGood");
                bulkCopy.ColumnMappings.Add("Promotion", "Promotion");
                bulkCopy.ColumnMappings.Add("MKTFunPer", "MKTFunPer");
                bulkCopy.ColumnMappings.Add("MKTFun", "MKTFun");
                bulkCopy.ColumnMappings.Add("Cash_Acc", "Cash_Acc");
                bulkCopy.ColumnMappings.Add("POS_Acc", "POS_Acc");
                bulkCopy.ColumnMappings.Add("FreeGood_Acc", "FreeGood_Acc");
                bulkCopy.ColumnMappings.Add("Promotion_Acc", "Promotion_Acc");
                bulkCopy.ColumnMappings.Add("MKTFun_Acc", "MKTFun_Acc");
                bulkCopy.ColumnMappings.Add("SponsorPerCase", "SponsorPerCase");
                bulkCopy.ColumnMappings.Add("TotDealPC", "TotDealPC");
                bulkCopy.ColumnMappings.Add("CashPC", "CashPC");
                bulkCopy.ColumnMappings.Add("POSPC", "POSPC");
                bulkCopy.ColumnMappings.Add("FreeGoodPC", "FreeGoodPC");
                bulkCopy.ColumnMappings.Add("PromotionPC", "PromotionPC");
                bulkCopy.ColumnMappings.Add("MKTFunPC", "MKTFunPC");
                bulkCopy.ColumnMappings.Add("Tot_paid", "Tot_paid");
                bulkCopy.ColumnMappings.Add("Cash_paid", "Cash_paid");
                bulkCopy.ColumnMappings.Add("POS_paid", "POS_paid");
                bulkCopy.ColumnMappings.Add("FreeGood_paid", "FreeGood_paid");
                bulkCopy.ColumnMappings.Add("Promotion_paid", "Promotion_paid");
                bulkCopy.ColumnMappings.Add("MKTFun_paid", "MKTFun_paid");
                bulkCopy.ColumnMappings.Add("Tot_rem", "Tot_rem");
                bulkCopy.ColumnMappings.Add("Cash_rem", "Cash_rem");
                bulkCopy.ColumnMappings.Add("POS_rem", "POS_rem");
                bulkCopy.ColumnMappings.Add("FreeGood_rem", "FreeGood_rem");
                bulkCopy.ColumnMappings.Add("Promotion_rem", "Promotion_rem");
                bulkCopy.ColumnMappings.Add("MKTFun_rem", "MKTFun_rem");
                bulkCopy.ColumnMappings.Add("Remarks", "Remarks");
                bulkCopy.ColumnMappings.Add("CRDDAT", "CRDDAT");
                bulkCopy.ColumnMappings.Add("CRDUSR", "CRDUSR");
                bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");
                bulkCopy.ColumnMappings.Add("UPDUSR", "UPDUSR");
                bulkCopy.ColumnMappings.Add("BatchNo", "BatchNo");
                bulkCopy.ColumnMappings.Add("SignOn", "SignOn");
                bulkCopy.ColumnMappings.Add("MFD", "MFD");
                bulkCopy.ColumnMappings.Add("SALORG_CTR", "SALORG_CTR");
                bulkCopy.ColumnMappings.Add("EftNoOfMonth", "EftNoOfMonth");
                bulkCopy.ColumnMappings.Add("CurrentMonth", "CurrentMonth");



                #region   tìm id



                #endregion




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }
        }

        private void importexcelcontractdetail(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();



            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

            //------
            //---------------fill data

            System.Data.DataTable sourceData = new System.Data.DataTable();
            using (OleDbConnection conn =
                                   new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Open connextion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                // Get the data from the source table as a SqlDataReader.
                OleDbCommand command = new OleDbCommand(
                                            @"SELECT ContractNo, PayType,PayID,
           SubID,PayControl,Description,PrdGrp,FundPercentage,AmountPC,
               SponsoredAmt,DisAmount,VolAchvmt,Unit,CommittedDate_frm,
CommittedDate,AccruedAmt,AccruedDate,PaidOn,PaidAmt,ConfAmt,Balance,
PrintChk,BatchNo,DoneOn,IntOrdNum,APDocNum,Remark,CRDDAT,CRDUSR,
UPDDAT,UPDUSR,MFD,BLOCKED,VAT,EffFrm,EffTo,EffDays,Days,EFFPCs,EFFNSR
                                     FROM [Sheet1$]
                                     WHERE ( ContractNo is not null ) ", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);




                //   adapter.FillSchema(sourceData, SchemaType.Source);
                //   sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
                //   sourceData.Columns["Invoice Doc Nr"].DataType = typeof(float);
                //   sourceData.Columns["Billed Qty"].DataType = typeof(float);
                //   sourceData.Columns["Cond Value"].DataType = typeof(float);
                //   sourceData.Columns["Sales Org"].DataType = typeof(string);
                //   sourceData.Columns["Cust Name"].DataType = typeof(string);
                //   sourceData.Columns["Outbound Delivery"].DataType = typeof(string);
                //   sourceData.Columns["Mat Group"].DataType = typeof(string);
                //   sourceData.Columns["Mat Group Text"].DataType = typeof(string);
                //   sourceData.Columns["UoM"].DataType = typeof(string);


                try
                {

                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }

            //   Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.DestinationTableName = "tbl_kacontractbegindatadetail";

                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("PayType", "PayType");

                bulkCopy.ColumnMappings.Add("PayID", "PayID");
                bulkCopy.ColumnMappings.Add("SubID", "SubID");
                bulkCopy.ColumnMappings.Add("PayControl", "PayControl");


                bulkCopy.ColumnMappings.Add("Description", "Description");

                bulkCopy.ColumnMappings.Add("PrdGrp", "PrdGrp");
                bulkCopy.ColumnMappings.Add("FundPercentage", "FundPercentage");
                bulkCopy.ColumnMappings.Add("AmountPC", "AmountPC");
                bulkCopy.ColumnMappings.Add("SponsoredAmt", "SponsoredAmt");
                bulkCopy.ColumnMappings.Add("DisAmount", "DisAmount");
                bulkCopy.ColumnMappings.Add("VolAchvmt", "VolAchvmt");

                bulkCopy.ColumnMappings.Add("Unit", "Unit");

                bulkCopy.ColumnMappings.Add("CommittedDate_frm", "CommittedDate_frm");

                bulkCopy.ColumnMappings.Add("CommittedDate", "CommittedDate");
                bulkCopy.ColumnMappings.Add("AccruedAmt", "AccruedAmt");
                bulkCopy.ColumnMappings.Add("AccruedDate", "AccruedDate");
                bulkCopy.ColumnMappings.Add("PaidOn", "PaidOn");
                bulkCopy.ColumnMappings.Add("PaidAmt", "PaidAmt");
                bulkCopy.ColumnMappings.Add("ConfAmt", "ConfAmt");
                bulkCopy.ColumnMappings.Add("Balance", "Balance");
                bulkCopy.ColumnMappings.Add("PrintChk", "PrintChk");
                bulkCopy.ColumnMappings.Add("BatchNo", "BatchNo");
                bulkCopy.ColumnMappings.Add("DoneOn", "DoneOn");
                bulkCopy.ColumnMappings.Add("IntOrdNum", "IntOrdNum");
                bulkCopy.ColumnMappings.Add("APDocNum", "APDocNum");
                bulkCopy.ColumnMappings.Add("Remark", "Remark");

                bulkCopy.ColumnMappings.Add("CRDDAT", "CRDDAT");
                bulkCopy.ColumnMappings.Add("CRDUSR", "CRDUSR");
                bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");
                bulkCopy.ColumnMappings.Add("UPDUSR", "UPDUSR");
                bulkCopy.ColumnMappings.Add("MFD", "MFD");
                bulkCopy.ColumnMappings.Add("BLOCKED", "BLOCKED");
                bulkCopy.ColumnMappings.Add("VAT", "VAT");
                bulkCopy.ColumnMappings.Add("EffFrm", "EffFrm");
                bulkCopy.ColumnMappings.Add("EffTo", "EffTo");
                bulkCopy.ColumnMappings.Add("EffDays", "EffDays");

                bulkCopy.ColumnMappings.Add("Days", "Days");

                bulkCopy.ColumnMappings.Add("EFFPCs", "EFFPCs");
                bulkCopy.ColumnMappings.Add("EFFNSR", "EFFNSR");


                #region   tìm id



                #endregion




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }
        }





    }
}
