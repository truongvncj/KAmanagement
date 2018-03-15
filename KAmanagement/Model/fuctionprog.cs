using KAmanagement.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.Model
{
    class fuctionprog
    {


        public bool deleteallfction()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_FreGlass in db.tbl_FreGlasses
       //              select tbl_FreGlass;

            db.ExecuteCommand("DELETE FROM tbl_Kafuctionlist");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }


        public IQueryable Funtionsetlect_all(LinqtoSQLDataContext db)
        {

            //var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
                     select tbl_Kafuctionlist;

            return rs;

        }




        class datainportF
        {

            public string filename { get; set; }

        }



        public void Fuction_input()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Free Fuction excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importFuctionexcel);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(555);
                    t2.Abort();
                }






            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }


        private void importFuctionexcel(object obj)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            fuctionprog Rm = new fuctionprog();

            bool kq = Rm.deleteallfction();


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

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Open conext !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Get the data from the source table as a SqlDataReader.
                OleDbCommand command = new OleDbCommand(
                                    @"SELECT Code, Description,Example,Explan
                                     FROM [Sheet1$]
                                     WHERE ( Code is not null ) ", conn);
           

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                //  adapter.FillSchema(sourceData, SchemaType.Source);
                //     sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
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

        //    Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                //@"SELECT Code, Description,Example,Explan
                //                     FROM [Sheet1$]
                //                     WHERE ( Code is not null ) ", conn);
                
                bulkCopy.DestinationTableName = "tbl_Kafuctionlist";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Code", "Code");
                bulkCopy.ColumnMappings.Add("Description", "Description");
                bulkCopy.ColumnMappings.Add("Explan", "Explan");
                bulkCopy.ColumnMappings.Add("Example", "Example");
              

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
