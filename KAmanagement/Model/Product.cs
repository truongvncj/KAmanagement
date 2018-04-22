using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KAmanagement.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace KAmanagement.Model
{
    class Product
    {
        public IQueryable product_select_all(LinqtoSQLDataContext dblink)
        {

            // var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_kaProductlist in dblink.tbl_kaProductlists
                     select tbl_kaProductlist;

            return rs;

        }
        public bool Deleteprodctlist()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            //   var rs = from tblFBL5N in db.tblFBL5Ns
            //          select tblFBL5N;

            db.ExecuteCommand("DELETE FROM tbl_kaProductlist");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();

            return true;
        }

        class datainportF
        {

            public string filename { get; set; }

        }

        private void importsexcel(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

     
            Product md = new Product();

            bool kq = md.Deleteprodctlist();

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
                                    @"SELECT MatNumber, MatText ,UoM,Pcrate,Litter,UnitSize,PackUnit,
                                    Ucrate FROM [Sheet1$]
                                     WHERE ( MatNumber is not null  ) ", conn); // AND ISNUMERIC (MatNumber)

            

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
          //      adapter.FillSchema(sourceData, SchemaType.Source);
        //        sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
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
                //@"SELECT MatNumber, MatText ,UoM,Pcrate,
                //                    Ucrate FROM [Sheet1$]
                //                     WHERE ( MatNumber is not null  ) AND ISNUMERIC (MatNumber)", conn); //

                bulkCopy.DestinationTableName = "tbl_kaProductlist";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("MatNumber", "MatNumber");
                bulkCopy.ColumnMappings.Add("MatText", "MatText");
                bulkCopy.ColumnMappings.Add("UoM", "UoM");
                bulkCopy.ColumnMappings.Add("Pcrate", "Pcrate");
                bulkCopy.ColumnMappings.Add("Ucrate", "Ucrate");
                bulkCopy.ColumnMappings.Add("PackUnit", "PackUnit");
                bulkCopy.ColumnMappings.Add("Litter", "Litter");
                bulkCopy.ColumnMappings.Add("UnitSize", "UnitSize");


                //  ,

                #region   tìm id
                //   "Account"
                //    "Assignment"
                //    "Posting Date"
                //  "Document Type"
                //     "Document Number"
                //   "Business Area"
                //     "Amount in local currency"


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


        public void productlistinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Product list excel";
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



            //  return true;



        }



    } // en class
} // endname space
