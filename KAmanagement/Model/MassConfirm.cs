using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.Model
{


    class MassConfirm
    {
        class datainportF
        {

            public string filename { get; set; }

        }

        class datainportFileContarcts
        {

            public string filename { get; set; }
            public string contracts { get; set; }
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





        private void importsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            Salesinput_ctrl md = new Salesinput_ctrl();
            bool kq = md.deleteedlp();
            //if (!kq)
            //{
            //    MessageBox.Show("Không xóa được bảng Edlpinput!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

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
            //  batable.Columns.Add("Soldto", typeof(double));
            batable.Columns.Add("ContractNo", typeof(string));
            batable.Columns.Add("BatchNo", typeof(double));
            batable.Columns.Add("PayType", typeof(string));
            batable.Columns.Add("PaidRequestAmt", typeof(double));
            batable.Columns.Add("PaidNote", typeof(string));
            batable.Columns.Add("PaymentDoc", typeof(string));
            //  PaymentDoc


            string username = Utils.getusername();

            batable.Columns.Add("Username", typeof(string));
            batable.Columns["Username"].DefaultValue = username;
            batable.Columns.Add("status", typeof(Boolean));
            batable.Columns["status"].DefaultValue = false;




            #region setcolum


            int PaymentDocid = -1;
            int ContractNoid = -1;
            int BatchNoid = -1;
            int PayTypeid = -1;
            int PaidRequestAmtid = -1;
            int PaidNoteid = -1;

            //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

            //     vi1.ShowDialog();
            //        int headindex = -2;

            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "ContractNo")
                        {
                            ContractNoid = columid;
                            //  headindex = rowid;
                        }

                        if (value.Trim() == ("BatchNo"))
                        {

                            BatchNoid = columid;
                            //   headindex = rowid;

                        }


                        if (value.Trim() == ("PayType"))
                        {

                            PayTypeid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == ("PaidRequestAmt"))
                        {

                            PaidRequestAmtid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim() == "PaidNote")
                        {
                            PaidNoteid = columid;
                            // headindex = rowid;
                        }



                        if (value.Trim() == "PaymentDoc")
                        {
                            PaymentDocid = columid;
                            // headindex = rowid;
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


            if (BatchNoid == -1)
            {
                MessageBox.Show("Please check BatchNo colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PayTypeid == -1)
            {
                MessageBox.Show("Please check PayType colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PaidRequestAmtid == -1)
            {
                MessageBox.Show("Please check PaidRequestAmt colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PaidNoteid == -1)
            {
                MessageBox.Show("Please check PaidNote colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PaymentDocid == -1)
            {
                MessageBox.Show("Please check PaymentDoc colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of massconfirm
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string PaidRequestAmt = sourceData.Rows[rowixd][PaidRequestAmtid].ToString();
                if (PaidRequestAmt != "" && Utils.IsValidnumber(PaidRequestAmt))
                {


                    DataRow dr = batable.NewRow();
                    dr["ContractNo"] = sourceData.Rows[rowixd][ContractNoid].ToString().Trim();
                    dr["BatchNo"] = double.Parse(sourceData.Rows[rowixd][BatchNoid].ToString().Trim());
                    dr["PayType"] = sourceData.Rows[rowixd][PayTypeid].ToString().Trim();
                    dr["PaidRequestAmt"] = double.Parse(sourceData.Rows[rowixd][PaidRequestAmtid].ToString().Trim());
                    dr["PaidNote"] = sourceData.Rows[rowixd][PaidNoteid].ToString().Trim();
                    dr["PaymentDoc"] = sourceData.Rows[rowixd][PaymentDocid].ToString().Trim();



                    batable.Rows.Add(dr);


                }



                #endregion

            }// row





            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_MassConfirmTemp";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("BatchNo", "BatchNo");
                bulkCopy.ColumnMappings.Add("PayType", "PayType");
                bulkCopy.ColumnMappings.Add("PaidRequestAmt", "PaidRequestAmt");
                bulkCopy.ColumnMappings.Add("PaidNote", "PaidNote");
                bulkCopy.ColumnMappings.Add("PaymentDoc", "PaymentDoc");

                bulkCopy.ColumnMappings.Add("Username", "Username");
                bulkCopy.ColumnMappings.Add("status", "status");


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



        private void importcontractlist(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            Salesinput_ctrl md = new Salesinput_ctrl();
            bool kq = md.deleteedlp();
            //if (!kq)
            //{
            //    MessageBox.Show("Không xóa được bảng Edlpinput!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            datainportFileContarcts inf = (datainportFileContarcts)obj;
            string filename = inf.filename;
            string contracts = inf.contracts;

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
            //  batable.Columns.Add("Soldto", typeof(double));
            batable.Columns.Add("ContractNo", typeof(string));

            //batable.Columns.Add("BatchNo", typeof(double));
            //batable.Columns.Add("PayType", typeof(string));
            //batable.Columns.Add("PaidRequestAmt", typeof(double));
            //batable.Columns.Add("PaidNote", typeof(string));

            batable.Columns.Add("Consts", typeof(string));
            batable.Columns["Consts"].DefaultValue = contracts;


            string username = Utils.getusername();

            batable.Columns.Add("Username", typeof(string));
            batable.Columns["Username"].DefaultValue = username;
            batable.Columns.Add("status", typeof(Boolean));
            batable.Columns["status"].DefaultValue = false;

      //      Consts
           // contracts




            #region setcolum



            int ContractNoid = -1;
        
            //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

            //     vi1.ShowDialog();
            //        int headindex = -2;

            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "ContractNo")
                        {
                            ContractNoid = columid;
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



            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of massconfirm
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string Contractitem = sourceData.Rows[rowixd][ContractNoid].ToString();
                if (Contractitem != "" && Contractitem.Trim() != "ContractNo")
                {


                    DataRow dr = batable.NewRow();
                    dr["ContractNo"] = sourceData.Rows[rowixd][ContractNoid].ToString().Trim();
                 
                    batable.Rows.Add(dr);


                }



                #endregion

            }// row





            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_MassContractChangeTemp";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("Username", "Username");
                bulkCopy.ColumnMappings.Add("status", "status");
                bulkCopy.ColumnMappings.Add("Consts", "Consts");
                
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



        public void massfilepinput( )
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importsexcel2);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename } );
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




        }



        public void massfileContractchangeinput(string contracts)
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importcontractlist);
                t1.IsBackground = true;
                t1.Start(new  datainportFileContarcts() { filename = filename, contracts = contracts });

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




        }





    }
}
