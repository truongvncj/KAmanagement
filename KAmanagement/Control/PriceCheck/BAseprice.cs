using KAmanagement.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.Control.PriceCheck
{
    class BAseprice
    {

        class datainportF
        {

            public string filename { get; set; }

        }
        class datainportF2
        {

            public string filename { get; set; }
            public string programe { get; set; }

        }
        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }
        public void inputbasepricelist()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Base price excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();
            //    string programe = "Y1";

                                Thread t1 = new Thread(inputbasepricelistdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });//, programe = programe});


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1996);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }
        public void inputpromotionpricelist(string programe)
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File promotion price excel :  " + programe ;
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();
                //    string programe = "Y1";

                Thread t1 = new Thread(inputpromotionpricelistdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF2() { filename = filename, programe = programe });//, programe = programe});


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1996);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }


        public void inputbasepricelistdetail(object obj)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

         //   string filename = theDialog.FileName.ToString();

             //   string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        
                dc.ExecuteCommand("DELETE FROM tbl_KAbaseprice");
                //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                dc.CommandTimeout = 0;
                dc.SubmitChanges();



                ExcelProvider ExcelProvide = new ExcelProvider();
                //#endregion
                System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

                DataTable batable = new DataTable();
                batable.Columns.Add("PriceList", typeof(string));
                batable.Columns.Add("Material", typeof(string));
                batable.Columns.Add("MaterialNAme", typeof(string));
                batable.Columns.Add("Amount", typeof(double));

                batable.Columns.Add("Unit", typeof(string));
                batable.Columns.Add("UoM", typeof(string));

                batable.Columns.Add("Valid_From", typeof(DateTime));
                batable.Columns.Add("Valid_to", typeof(DateTime));




                string Pricelist = "";
                int columpricelist = 0;
                int columpmaterial = 0;
                int columname = 0;
                int columpamount = 0;
                int columunit = 0;
                int columUoM = 0;
                int columValid_From = 0;
                int columValid_to = 0;
                int headindex = 0;

                for (int rowid = 0; rowid < sourceData.Rows.Count; rowid++)
                {
                    headindex = 1;
                    for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                    {

                        string value = sourceData.Rows[rowid][columid].ToString();

                        if (value != null)
                        {

                            #region setcolum
                            if (value.Trim() == "CnTy")
                            {
                                columpricelist = columid;
                                headindex = 0;
                            }

                            if (value.Trim() == "Material")
                            {
                                if (columname == 0)
                                {
                                    columpmaterial = columid;
                                    headindex = 0;
                                }

                            }


                            if (value.Trim() == "Material")
                            {
                                if (columpmaterial != 0)
                                {
                                    columname = columid;
                                    headindex = 0;
                                }


                            }


                            if (value.Trim() == "Amount")
                            {
                                columpamount = columid;
                                headindex = 0;
                            }
                            if (value.Trim() == "Unit")
                            {
                                columunit = columid;
                                headindex = 0;
                            }

                            if (value.Trim() == "UoM")
                            {
                                columUoM = columid;
                                headindex = 0;
                            }

                            if (value.Trim() == "Valid From")
                            {
                                columValid_From = columid;
                                headindex = 0;
                            }

                            if (value.Trim() == "Valid to")
                            {
                                columValid_to = columid;
                                headindex = 0;
                            }

                            #endregion

                    
                            // view basetable


                        }

                        //------------



                    }// colum


                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string valuepricelist = sourceData.Rows[rowid][columpricelist].ToString();
                if (headindex != 0 && valuepricelist != "" && valuepricelist != "YPR0")
                {
                    Pricelist = valuepricelist;


                }

                if (headindex != 0  && valuepricelist == "YPR0")
                {
                    DataRow dr = batable.NewRow();
                    dr["PriceList"] = Pricelist.Trim();

                    //   dr["Material"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpmaterial);
                    dr["Material"] = sourceData.Rows[rowid][columpmaterial].ToString().Trim();

                    dr["MaterialNAme"] = sourceData.Rows[rowid][columname].ToString().Trim();//Utils.GetValueOfCellInExcel(worksheet, rowid, columname);
                    dr["Amount"] = double.Parse(sourceData.Rows[rowid][columpamount].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);
                    dr["Unit"] = sourceData.Rows[rowid][columunit].ToString().Trim();//  Utils.GetValueOfCellInExcel(worksheet, rowid, columunit);
                    dr["UoM"] = sourceData.Rows[rowid][columUoM].ToString().Trim();// Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
                    dr["Valid_From"] = Utils.chageExceldatetoData(sourceData.Rows[rowid][columValid_From].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_From);
                    dr["Valid_to"] = Utils.chageExceldatetoData(sourceData.Rows[rowid][columValid_to].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);

                    batable.Rows.Add(dr);


                }

                #endregion

            }// row

            //conpy to server
            string destConnString = Utils.getConnectionstr();

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
                //---------------fill data


                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
                {


                    bulkCopy.DestinationTableName = "tbl_KAbaseprice";
                    // Write from the source to the destination.
                    bulkCopy.BulkCopyTimeout = 0;
                  
                    bulkCopy.ColumnMappings.Add("PriceList", "PriceList");
                    
                    bulkCopy.ColumnMappings.Add("Material", "Material");
                    bulkCopy.ColumnMappings.Add("MaterialNAme", "MaterialNAme");
                    bulkCopy.ColumnMappings.Add("Amount", "Amount");
                    bulkCopy.ColumnMappings.Add("Unit", "Unit");
                    bulkCopy.ColumnMappings.Add("UoM", "UoM");
                    bulkCopy.ColumnMappings.Add("Valid_From", "[Valid From]");
                    bulkCopy.ColumnMappings.Add("Valid_to", "[Valid to]");
                   

                    //bulkCopy.ColumnMappings.Add("Valid_to", "Valid_to");
                    //bulkCopy.ColumnMappings.Add("Valid_to", "Valid_to");
                    //bulkCopy.ColumnMappings.Add("Valid_to", "Valid_to");
                    //bulkCopy.ColumnMappings.Add("Valid_to", "Valid_to");




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


        public void inputpromotionpricelistdetail(object obj)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            datainportF2 inf = (datainportF2)obj;

            string filename = inf.filename;
            string programe = inf.programe.Trim();
          


            //   string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_KApromotinprice Where tbl_KApromotinprice.programId = '" + programe+"'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.CommandTimeout = 0;
            dc.SubmitChanges();


            //list vn
            var listvn = new List<string>();
            listvn = (from tbl_karegion in dc.tbl_karegions
                      select tbl_karegion.Region.Trim()).ToList();
            listvn.Add("VN");

            //list vn
            // listvn.Contains("dog");
            // lisKanuber
            
             var listkeyaccount = new List<string>();
              var   listkeyaccountrs = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                                   group tbl_ka_prCustomer.KeyAccount by tbl_ka_prCustomer.KeyAccount into h
                              select h.Key);

            foreach (var item in listkeyaccountrs)
            {
                listkeyaccount.Add(((int)item).ToString());
            }
            //   listvn.Add("VN");
            //liskanumber

            // listsaledistric

            var listsaledistric = new List<string>();
            listsaledistric = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                              group tbl_ka_prCustomer.Salesdistrict by tbl_ka_prCustomer.Salesdistrict into g
                              select g.Key.Trim()).ToList();
            //   listvn.Add("VN");
            //listsaledistric

            // listsafuction

            var listfuction = new List<string>();
            listfuction = (from tbl_KAlistpricefunction in dc.tbl_KAlistpricefunctions
                           group tbl_KAlistpricefunction.function by tbl_KAlistpricefunction.function into g
                              select g.Key.Trim()).ToList();

            //   listvn.Add("VN");
            //listsafuction



            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

            DataTable batable = new DataTable();

            batable.Columns.Add("product_code", typeof(string));
            batable.Columns.Add("product_group", typeof(string));

            batable.Columns.Add("percent_amount", typeof(double));
            batable.Columns.Add("amount", typeof(double));

            batable.Columns.Add("customerid", typeof(double));
            batable.Columns.Add("keyaccount", typeof(double));

            batable.Columns.Add("sales_region", typeof(string));
            batable.Columns.Add("saledistrict", typeof(string));
            batable.Columns.Add("programId", typeof(string));
            
            batable.Columns.Add("fromdate", typeof(DateTime));
            batable.Columns.Add("todate", typeof(DateTime));
            batable.Columns.Add("row", typeof(int));



            string sales_region = "0";
            double keyaccount = 0;
            string saledistrict = "0";
            double customerid = 0;


            //string product_group = "0";
            //double percent_amount = 0;
            //double amount = 0;
         
         
      
            int product_codeid = 0;
       //     int product_nameid = 0;

            int product_groupid = 0;
        //    int product_groupnameid = 0;

           // int percent_amountid = 0;
            int amountid = 0;
            int unitid = 0;

            int UoMid = 0;

            //int customeridid = 0;
            //int keyaccountid = 0;
            int sales_regionid = 0;
            //int saledistrictid = 0;
            int colid = 0;

            int fromdateid = 0;
            int todateid = 0;

        //    int rowif = 0;

            int headindex = 0;
            bool grouproduct = false;
            double penctamount = 0;
            double amount = 0;

            for (int rowid = 0; rowid < sourceData.Rows.Count; rowid++)
            {
                headindex = 1;
              

                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                

                    string value = sourceData.Rows[rowid][columid].ToString();

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "CnTy")
                        {
                            sales_regionid = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Material")
                        {
                            //   product_nameid = columid;
                            colid = product_codeid;
                            product_codeid = columid;
                            grouproduct = false;
                            headindex = 0;
                           
                        }


                        if (value.Trim() == "Material")
                        {
                            if (colid < columid && colid != 0)
                            {
                                product_codeid = colid;
                                headindex = 0;
                                grouproduct = false;
                            }
                          
                         
                        }


                        if (value.Trim() == "Matl Group")
                        {
                            colid = product_groupid;
                            product_groupid = columid;
                            //       product_groupnameid = columid;
                            grouproduct = true;
                            headindex = 0;
                        }

                        if (value.Trim() == "Matl Group")
                        {
                            if (colid < columid && colid != 0)
                            {
                                product_groupid = colid;
                                headindex = 0;
                                grouproduct = true;
                            }
                         
                        }





                        if (value.Trim() == "Amount")
                        {
                            amountid = columid;
                            headindex = 0;
                        }
                        if (value.Trim() == "Unit")
                        {
                            unitid = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "UoM")
                        {
                            UoMid = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Valid From")
                        {
                            fromdateid = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Valid to")
                        {
                            todateid = columid;
                            headindex = 0;
                        }

                        #endregion

                    // view basetable


                    }

                    //------------



                }// forcolum

                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string sales_regionvalue = sourceData.Rows[rowid][sales_regionid].ToString();
              

                if (headindex != 0 && sales_regionvalue != "" && listvn.Contains(sales_regionvalue.Trim()))   // trong nhoms fuction
                {
                    sales_region = sales_regionvalue;
                    keyaccount = 0;

                }




                if (headindex != 0 && sales_regionvalue != "" && listkeyaccount.Contains(sales_regionvalue))   // trong nhoms fuction
                {
                    // sales_region = sales_regionvalue;
                    keyaccount = double.Parse(sales_regionvalue);

                }

                if (headindex != 0 && sales_regionvalue != "" && listsaledistric.Contains(sales_regionvalue.Trim()))   // trong nhoms fuction
                {


                    sales_region = "0";
                    keyaccount = 0;

                    saledistrict = sales_regionvalue;


                }

                if (headindex != 0 && sales_regionvalue != "" && sales_regionvalue.Trim().Length >= 8 && Utils.IsValidnumber(sales_regionvalue))   // trong nhoms fuction
                {
                    sales_region = "0";
                    keyaccount = 0;
                    saledistrict = "0";
                    customerid = double.Parse(sales_regionvalue.ToString());


                }


                if (headindex != 0 && sales_regionvalue != "" && listfuction.Contains(sales_regionvalue.Trim()))   // trong nhoms fuction
                {

                 

                    DataRow dr = batable.NewRow();

                    dr["sales_region"] = sales_region.Trim();
                    dr["programId"] = programe;// sourceData.Rows[rowid][product_codeid].ToString().Trim();// Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);

                    //   dr["Material"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpmaterial);
                    dr["keyaccount"] = keyaccount;
                    dr["saledistrict"] = saledistrict.ToString();// sourceData.Rows[rowid][columunit].ToString().Trim();//  Utils.GetValueOfCellInExcel(worksheet, rowid, columunit);
                    dr["customerid"] = customerid;//sourceData.Rows[rowid][columname].ToString().Trim();//Utils.GetValueOfCellInExcel(worksheet, rowid, columname);
                    if (sourceData.Rows[rowid][product_codeid] != null && sourceData.Rows[rowid][product_codeid].ToString() != "" && grouproduct == false)
                    {
                        dr["product_code"] = sourceData.Rows[rowid][product_codeid].ToString().Trim();// Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
                        dr["product_group"] = "0";
                    }
                    else
                    {
                        dr["product_code"] = "0";

                    }

                    if (sourceData.Rows[rowid][product_groupid] != null && sourceData.Rows[rowid][product_groupid].ToString() != "" && grouproduct == true)
                    {
                        dr["product_group"] = sourceData.Rows[rowid][product_groupid].ToString().Trim();// Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
                        dr["product_code"] = "0";
                    }
                    else
                    {
                        dr["product_group"] = "0";
                    }

                    dr["row"] = rowid;// double.Parse(sourceData.Rows[rowid][columpamount].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);

                    if (sourceData.Rows[rowid][unitid].ToString().Trim() == "%")
                    {
                    //    dr["percent_amount"] = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);
                      //  dr["amount"] = 0;

                        penctamount = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);;
                        amount = 0;
                        dr["percent_amount"] = penctamount;
                        dr["amount"] = amount;

                    }
                    else
                    {
                        penctamount = 0;
                        amount = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);;
                        dr["percent_amount"] = penctamount;
                        dr["amount"] = amount;

                  //      dr["amount"] = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);
                    //    dr["percent_amount"] = 0;
                    }
                    dr["fromdate"] = Utils.chageExceldatetoData(sourceData.Rows[rowid][fromdateid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_From);
                    dr["todate"] = Utils.chageExceldatetoData(sourceData.Rows[rowid][todateid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);

                    if (penctamount +amount != 0)
                    {
                        batable.Rows.Add(dr);
                    }
                    
                }







                #endregion



            } //fro row

            //conpy to server
            string destConnString = Utils.getConnectionstr();

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
            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {


                bulkCopy.DestinationTableName = "tbl_KApromotinprice";
                // Write from the source to the destination.
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.ColumnMappings.Add("product_code", "product_code");

                bulkCopy.ColumnMappings.Add("product_group", "product_group");
             //   bulkCopy.ColumnMappings.Add("MaterialNAme", "MaterialNAme");
                bulkCopy.ColumnMappings.Add("percent_amount", "percent_amount");
                bulkCopy.ColumnMappings.Add("amount", "amount");
                bulkCopy.ColumnMappings.Add("customerid", "customerid");
                bulkCopy.ColumnMappings.Add("keyaccount", "keyaccount");
                bulkCopy.ColumnMappings.Add("sales_region", "sales_region");


                bulkCopy.ColumnMappings.Add("saledistrict", "saledistrict");
                bulkCopy.ColumnMappings.Add("programId", "programId");
                bulkCopy.ColumnMappings.Add("fromdate", "fromdate");
                bulkCopy.ColumnMappings.Add("todate", "todate");
                bulkCopy.ColumnMappings.Add("row", "row");
             

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


    }
}



                
            
