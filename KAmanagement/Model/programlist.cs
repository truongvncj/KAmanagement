using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KAmanagement.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace KAmanagement.Model
{
    class programlist
    {


        public bool deleteallprogramlist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
          //  var rs = from tblVat in db.tblVats
            //         select tblVat;
        
            db.ExecuteCommand("DELETE FROM tbl_kaprogramlist");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }


        public IQueryable setlect_all(LinqtoSQLDataContext db)
        {

            //var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_kaprogramlist in db.tbl_kaprogramlists
                     select tbl_kaprogramlist;

            return rs;

        }

        class datainportF
        {

            public string filename { get; set; }

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


        public void input()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Program list excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importsexcel);
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



        }
        private void importsexcel(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            programlist md = new programlist();

            bool kq = md.deleteallprogramlist();

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
                                    @"SELECT Code ,Name FROM [Sheet1$]
                                    WHERE (Code is not null ) ", conn);

               


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            //   adapter.FillSchema(sourceData, SchemaType.Source);
             // sourceData.Columns["Pro Forma Date"].DataType = typeof(DateTime);
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
                // @"SELECT Code ,Name FROM [Sheet1$]
                //                    WHERE ([SAP Invoice Number] is not null ) ", conn);

                bulkCopy.DestinationTableName = "tbl_kaprogramlist";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Code", "Code");
                bulkCopy.ColumnMappings.Add("Name", "Name");






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


        private string changevalueminus(string value)
        {

            if (value.Contains("-"))
            {
                if (value.IndexOf('-') == value.Length - 1)
                {
                    value = "-" + value.Substring(0, value.Length - 1);
                }

            }


            return value;


        }



    }// LASS




}// NAMSPACE



