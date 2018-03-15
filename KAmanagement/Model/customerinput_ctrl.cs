using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KAmanagement.shared;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace KAmanagement.Model
{
    class customerinput_ctrl
    {


        public IQueryable customersetlect_all(LinqtoSQLDataContext db)
        {

            //  var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_KaCustomer in db.tbl_KaCustomers
                     orderby tbl_KaCustomer.Customer
                     select tbl_KaCustomer;

            return rs;

        }

        public bool customerdeleted()
        {
            #region // xóa data bảng tblCustomer
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();



            return true;
            #endregion

        }


        class datainportF
        {

            public string filename { get; set; }

        }

        private void importsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
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

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Get the data from the source table as a SqlDataReader.

                //  Customer	Vendor	SalesOrg	FullName	TradingName	Street	District	City	Telephone1	Telephone2	FaxNumber	VATregistrationNo	Indirect	CustomerGroup	SALORG_CTR

                OleDbCommand command = new OleDbCommand(
                                        @"SELECT Customer, 
                                    SalesOrg, 
FullName, 
TradingName ,
  Street,
District,
City ,    Telephone1,  VATregistrationNo, Indirect, 
    SALORG_CTR  FROM [Sheet1$]

                                     WHERE  (Customer IS NOT NULL)", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                try
                {
                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                conn.Close();
            }

            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();
            //      sourceData.Columns.Add("SapCode");
            //        sourceData.Columns["SapCode"].DefaultValue = true;
            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                //            @"SELECT BU, CCDescription,
                //                                CConsumption, CentralOrBlk, CHN ,
                //                               City, CreatedOn, CTDescription ,
                //                               Customer, District, FullNameN ,
                //                               KAGROUP, KANAME, KeyAcc ,
                //                               OrBlk, PaymentTerms, PriceList ,
                //  ReconciliationAcct, Region, SalesDistrict ,
                //  SalesOrg, Street, Telephone1 ,
                //  UPDDAT, VATregistrationNo  FROM [Sheet1$]
                //  
                //  	Vendor			Telephone2	FaxNumber				
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_KaCustomer";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("SalesOrg", "Region");
                bulkCopy.ColumnMappings.Add("FullName", "FullNameN");
                bulkCopy.ColumnMappings.Add("TradingName", "KANAME");
                bulkCopy.ColumnMappings.Add("Street", "Street");
                bulkCopy.ColumnMappings.Add("District", "District");
                bulkCopy.ColumnMappings.Add("City", "City");
                bulkCopy.ColumnMappings.Add("Telephone1", "Telephone1");
                bulkCopy.ColumnMappings.Add("VATregistrationNo", "VATregistrationNo");

                //    bulkCopy.ColumnMappings.Add("CustomerGroup", "CustomerGroup");

                bulkCopy.ColumnMappings.Add("Indirect", "indirectCode");
                bulkCopy.ColumnMappings.Add("SALORG_CTR", "SALORG_CTR");




                //bulkCopy.ColumnMappings.Add("BU", "BU");
                //bulkCopy.ColumnMappings.Add("CCDescription", "CCDescription");
                //bulkCopy.ColumnMappings.Add("CConsumption", "CConsumption");
                //bulkCopy.ColumnMappings.Add("CentralOrBlk", "CentralOrBlk");
                //bulkCopy.ColumnMappings.Add("CHN", "CHN");


                //bulkCopy.ColumnMappings.Add("CreatedOn", "CreatedOn");
                //bulkCopy.ColumnMappings.Add("CTDescription", "CTDescription");



                //bulkCopy.ColumnMappings.Add("KAGROUP", "KAGROUP");

                //bulkCopy.ColumnMappings.Add("KeyAcc", "KeyAcc");
                //bulkCopy.ColumnMappings.Add("OrBlk", "OrBlk");
                //bulkCopy.ColumnMappings.Add("PaymentTerms", "PaymentTerms");
                //bulkCopy.ColumnMappings.Add("PriceList", "PriceList");

                //bulkCopy.ColumnMappings.Add("ReconciliationAcct", "ReconciliationAcct");

                //bulkCopy.ColumnMappings.Add("SalesDistrict", "SalesDistrict");



                //bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            //   Thread.CurrentThread.Abort();

        }


        public void importsexceltoPricingcheck(object obj)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            //   string filename = theDialog.FileName.ToString();

            //   string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_ka_prCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.CommandTimeout = 0;
            dc.SubmitChanges();

            //    Customer Sales Organization Name 1  House num &Street  Street 4    City Telephone 1 Sales Office    Delivering Plant    Terms of Payment Price List Key Account No  Sales district  Created on  Created by  VAT Registration No.Central order block Order block for sales area


            //                   


            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();
            batable.Columns.Add("Customer", typeof(double));
            batable.Columns.Add("SalesOrg", typeof(string));
            batable.Columns.Add("Name", typeof(string));
            batable.Columns.Add("House", typeof(string));

            batable.Columns.Add("Street", typeof(string));
            batable.Columns.Add("City", typeof(string));
            batable.Columns.Add("Telephone", typeof(string));

            batable.Columns.Add("Salesoff", typeof(string));
            batable.Columns.Add("Plant", typeof(string));
            batable.Columns.Add("Termpayment", typeof(string));

            batable.Columns.Add("Pricelist", typeof(string));
            batable.Columns.Add("KeyAccount", typeof(double));
            batable.Columns.Add("SalesDist", typeof(string));
            batable.Columns.Add("Createdon", typeof(DateTime));
            batable.Columns.Add("Createby", typeof(string));
            batable.Columns.Add("VATregistno", typeof(string));
            batable.Columns.Add("orderblock", typeof(string));
            batable.Columns.Add("salesblock", typeof(string));






            int Customerid = 0;
            int Salesogid = 0;
            int Nameid = 0;
            int Houseid = 0;
            int Streetid = 0;
            int Cityid = 0;
            int telephoneid = 0;
            int salesofficeid = 0;

            int Deliveringid = 0;

            int Termsid = 0;

            int Priceid = 0;

            int Keyid = 0;
            int Salesdistid = 0;
            int Createdonid = 0;
            int Createdbyid = 0;
            int VATid = 0;
            int orderblockid = 0;
            int salesblockid = 0;


       //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

       //     vi1.ShowDialog();
            int headindex =-2;

            for (int rowid = 0; rowid < 3; rowid++)
            {
               // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
      //            MessageBox.Show(value +":"+ rowid);

                    if (value != null )
                    {

                        #region setcolum
                        if (value.Trim().Contains("Customer"))
                        {
                            Customerid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim().Contains("Sales Organization") && headindex == rowid)
                        {

                          Salesogid = columid;
                      //    headindex = 0;

                        }


                        if (value.Trim().Contains("Name 1") && headindex == rowid)
                        {

                            Nameid = columid;
                         //   headindex = 0;



                        }


                        if (value.Trim().Contains("House num & Street") &&  headindex == rowid)
                        {
                            Houseid = columid;
                           
                        }
                        if (value.Trim().Contains( "Street 4" ) && headindex == rowid)
                        {
                            Streetid = columid;
                           
                        }

                        if (value.Trim().Contains( "City") && headindex == rowid)
                        {
                            Cityid = columid;
                           
                        }

                        if (value.Trim().Contains( "Telephone 1" )&& headindex == rowid)
                        {
                            telephoneid = columid;
                           // headindex = 0;
                        }

                        if (value.Trim().Contains(  "Sales Office" )&& headindex == rowid)
                        {
                            salesofficeid = columid;
                            
                        }

                        if (value.Trim().Contains( "Delivering Plant" )&& headindex == rowid)
                        {
                            Deliveringid = columid;
                          
                        }
                        if (value.Trim().Contains( "Terms of Payment" )&& headindex == 0)
                        {
                            Termsid = columid;
                            headindex = 0;
                        }
                        if (value.Trim().Contains( "Price List") && headindex == rowid)
                        {
                            Priceid = columid;
                          
                        }
                        if (value.Trim().Contains( "Key Account No") && headindex == rowid)
                        {
                            Keyid = columid;
                           
                        }
                        if (value.Trim().Contains( "Sales district" )&& headindex == rowid)
                        {
                            Salesdistid = columid;
                           
                        }
                        if (value.Trim().Contains( "Created on" )&& headindex == rowid)
                        {
                            Createdonid = columid;
                            
                        }
                        if (value.Trim().Contains( "Created by" )&& headindex == rowid)
                        {
                            Createdbyid = columid;
                          
                        }
                        if (value.Trim().Contains( "VAT Registration No" )&& headindex == rowid)
                        {
                            VATid = columid;
                            
                        }
                        if (value.Trim().Contains( "Central order block" )&& headindex == rowid)
                        {
                            orderblockid = columid;
                          
                        }

                        if (value.Trim().Contains( "Order block for sales area" )&& headindex == rowid)
                        {
                            salesblockid = columid;
                           
                        }

                        #endregion

                    }


                }// colum
                
            }// roww off heatder


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {
                               
                    #region setvalue of pricelist
                    //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                  string customer = sourceData.Rows[rowixd][Customerid].ToString();
                if ( customer != "" && Utils.IsValidnumber(customer))
                {
                  
           
                    DataRow dr = batable.NewRow();
                    dr["Customer"] = double.Parse(sourceData.Rows[rowixd][Customerid].ToString());
                    dr["SalesOrg"] = sourceData.Rows[rowixd][Salesogid].ToString().Trim();
                      dr["Name"] = sourceData.Rows[rowixd][Nameid].ToString().Trim();
                    dr["House"] = sourceData.Rows[rowixd][Houseid].ToString().Trim();
                    dr["Street"] = sourceData.Rows[rowixd][Streetid].ToString().Trim();
                    dr["City"] = sourceData.Rows[rowixd][Cityid].ToString().Trim();
                    dr["Telephone"] = sourceData.Rows[rowixd][telephoneid].ToString().Trim();

                    dr["Salesoff"] = sourceData.Rows[rowixd][salesofficeid].ToString().Trim();

                    dr["Plant"] = sourceData.Rows[rowixd][Deliveringid].ToString().Trim();

                    dr["Termpayment"] = sourceData.Rows[rowixd][Termsid].ToString().Trim();

                    dr["Pricelist"] = sourceData.Rows[rowixd][Priceid].ToString().Trim();

                    dr["KeyAccount"] = double.Parse(sourceData.Rows[rowixd][Keyid].ToString());//.Trim();

                    dr["SalesDist"] = sourceData.Rows[rowixd][Salesdistid].ToString().Trim();

                    dr["Createby"] = sourceData.Rows[rowixd][Createdbyid].ToString().Trim();

                    dr["VATregistno"] = sourceData.Rows[rowixd][VATid].ToString().Trim();

                    dr["orderblock"] = sourceData.Rows[rowixd][orderblockid].ToString().Trim();

                    dr["salesblock"] = sourceData.Rows[rowixd][salesblockid].ToString().Trim();

             
                    dr["Createdon"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][Createdonid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);

                    batable.Rows.Add(dr);


                }

                #endregion

            }// row

            //conpy to server
            string destConnString = Utils.getConnectionstr();

            //adapter.FillSchema(sourceData, SchemaType.Source);
            //sourceData.Columns["Posting Date"].DataType = typeof(DateTime);

            //batable.Columns.Add("", typeof(string));
        


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {


                bulkCopy.DestinationTableName = "tbl_ka_prCustomer";
                // Write from the source to the destination.
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.ColumnMappings.Add("Customer", "Customer");

                bulkCopy.ColumnMappings.Add("SalesOrg", "SalesOrg");
                bulkCopy.ColumnMappings.Add("Name", "Name");
                bulkCopy.ColumnMappings.Add("House", "House");

                bulkCopy.ColumnMappings.Add("Street", "Street");
                bulkCopy.ColumnMappings.Add("City", "City");
                bulkCopy.ColumnMappings.Add("Telephone", "Telephone");
           
                bulkCopy.ColumnMappings.Add("Salesoff", "SalesOff");
                bulkCopy.ColumnMappings.Add("Plant", "Plant");
                bulkCopy.ColumnMappings.Add("Termpayment", "TermPayment");
                bulkCopy.ColumnMappings.Add("Pricelist", "PriceList");

                bulkCopy.ColumnMappings.Add("KeyAccount", "KeyAccount");
                bulkCopy.ColumnMappings.Add("SalesDist", "Salesdistrict");
                bulkCopy.ColumnMappings.Add("Createdon", "Createdon");
                bulkCopy.ColumnMappings.Add("Createby", "Createdby");
                bulkCopy.ColumnMappings.Add("VATregistno", "VATRegistration");
                bulkCopy.ColumnMappings.Add("orderblock", "blockOrder");
                bulkCopy.ColumnMappings.Add("salesblock", "blockArea");
             
             


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
            //copy to server
            //   string connection_string = Utils.getConnectionstr();

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    var typeffmain = typeof(tbl_KAbaseprice);
            //     var typeffsub = typeof(tbl_KAbaseprice);

            //    VInputchange inputcdata1 = new VInputchange("", "Base price list", dc, "tbl_KAbaseprice", "tbl_KAbaseprice", typeffmain, typeffsub, "id", "id", "");
            //    inputcdata1.ShowDialog();
            //  View.Viewdatatable TB = new View.Viewdatatable(batable, "lIST DATA");
            //  TB.ShowDialog();

            //  }
        }



        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }
        public void customerinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Customer excel data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsexcel2);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                //      ThreadPool.QueueUserWorkItem(new WaitCallback(importsexcel)); //join

                // sina
                // dynamic_cast<AutoResetEvent*>(stateInfo)->Set();
                // ((AutoResetEvent)stateInfo).Set();
                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {





                    Thread.Sleep(1999);
                    t2.Abort();


                    //    MessageBox.Show("Upload Customer done !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //#region updateCustgoupinListcust


                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //var qr = from tblCustomer in dc.tblCustomers
                //             //  where tblCustomer.Reportsend == true
                //         select tblCustomer;
                ////------------//
                //foreach (var tblCustomer in qr)
                //{

                //    var qr2 = (from tbl_CustomerGroup in dc.tbl_CustomerGroups
                //               where tbl_CustomerGroup.Customercode == tblCustomer.Customer && 
                //               select tbl_CustomerGroup).FirstOrDefault();


                //    if (qr2 != null)
                //    {
                //        tblCustomer.Cusromergroup = qr2.Customergropcode;


                //    }


                //    if (qr2 == null)
                //    {
                //        tblCustomer.Cusromergroup = tblCustomer.Customer;

                //    }



                //    dc.SubmitChanges();



                //}

                //#endregion updateCustgoupinListcust


            }





        }
        public void customerinputpriceingupdate()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File ZNKA1 Customer excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsexceltoPricingcheck);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                //      ThreadPool.QueueUserWorkItem(new WaitCallback(importsexcel)); //join

                // sina
                // dynamic_cast<AutoResetEvent*>(stateInfo)->Set();
                // ((AutoResetEvent)stateInfo).Set();
                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {





                    Thread.Sleep(1999);
                    t2.Abort();


                    //    MessageBox.Show("Upload Customer done !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //#region updateCustgoupinListcust


                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //var qr = from tblCustomer in dc.tblCustomers
                //             //  where tblCustomer.Reportsend == true
                //         select tblCustomer;
                ////------------//
                //foreach (var tblCustomer in qr)
                //{

                //    var qr2 = (from tbl_CustomerGroup in dc.tbl_CustomerGroups
                //               where tbl_CustomerGroup.Customercode == tblCustomer.Customer && 
                //               select tbl_CustomerGroup).FirstOrDefault();


                //    if (qr2 != null)
                //    {
                //        tblCustomer.Cusromergroup = qr2.Customergropcode;


                //    }


                //    if (qr2 == null)
                //    {
                //        tblCustomer.Cusromergroup = tblCustomer.Customer;

                //    }



                //    dc.SubmitChanges();



                //}

                //#endregion updateCustgoupinListcust


            }





        }

      






    }
}
