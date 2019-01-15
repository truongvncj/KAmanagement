using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KAmanagement.View;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace KAmanagement.Model
{
    class Salesinput_ctrl
    {
        public bool deleteedlp()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            string username = Utils.getusername();
            //  var rs = from tblEDLP in db.tblEDLPs
            //          select tblEDLP;
            //  tbl_Kasa
            db.ExecuteCommand("DELETE FROM tbl_kasalesTemp where tbl_kasalesTemp.Username = '" + username+"'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            return true;
        }


        public IQueryable Salessetlect_all(LinqtoSQLDataContext db)
        {

            //    var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_kasalesTemp in db.tbl_kasalesTemps
                     select tbl_kasalesTemp;

            return rs;

        }

        class datainportF
        {

            public string filename { get; set; }

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
            batable.Columns.Add("Soldto", typeof(double));
            batable.Columns.Add("CustName", typeof(string));
            batable.Columns.Add("MatNumber", typeof(string));
            batable.Columns.Add("SalesOrg", typeof(string));
            batable.Columns.Add("InvoiceDocNr", typeof(double));
            batable.Columns.Add("OutboundDelivery", typeof(double));
            batable.Columns.Add("DeliveryDate", typeof(DateTime));
            batable.Columns.Add("SalesDistrict", typeof(string));
            batable.Columns.Add("SalesDistrictdesc", typeof(string));
        //    batable.Columns.Add("SalesGroup", typeof(string));
         //   batable.Columns.Add("SalesOff", typeof(string));
        //    batable.Columns.Add("SalesOfficeDesc", typeof(double));
            batable.Columns.Add("KeyAccNr", typeof(double));
            batable.Columns.Add("InvoiceDate", typeof(DateTime));
            batable.Columns.Add("MatGroup", typeof(double));
            batable.Columns.Add("MatGroupText", typeof(string));
            batable.Columns.Add("MatText", typeof(string));
             batable.Columns.Add("CondType", typeof(string));

      //      batable.Columns.Add("CondTypedesc", typeof(string));
            batable.Columns.Add("BilledQty", typeof(double));
            batable.Columns.Add("Netvalue", typeof(double));
            batable.Columns.Add("CondValue", typeof(double));
            batable.Columns.Add("Currency", typeof(string));
         //   batable.Columns.Add("Username", typeof(string));
            batable.Columns.Add("UoM", typeof(string));
            string username = Utils.getusername();


            batable.Columns.Add("Username");
            batable.Columns["Username"].DefaultValue = username;

            #region setcolum







            int Soldtoid =-1;
            int CustNameid =-1;
            int MatNumberid =-1;
            int SalesOrgid =-1;
            int InvoiceDocNrid =-1;
            int OutboundDeliveryid =-1;
            int DeliveryDateid =-1;
            int SalesDistrictid =-1;

            int SalesDistrictdescid =-1;

            int KeyAccNrid =-1;

            int InvoiceDateid =-1;

            int MatGroupid =-1;
            int MatGroupTextid =-1;
            int MatTextid =-1;
            int BilledQtyid =-1;
            int Netvalueid =-1;
            int CondValueid =-1;
            int Currencyid =-1;
            int UoMid =-1;
            int CondTypeid = -1;
            //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

            //     vi1.ShowDialog();
    //        int headindex = -2;

            for (int rowid = 0; rowid < 6; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim()== "Sold-to")
                        {
                            Soldtoid = columid;
                          //  headindex = rowid;
                        }

                        if (value.Trim()==("Cust Name")  )
                        {

                            CustNameid = columid;
                         //   headindex = rowid;

                        }

                        
                      if (value.Trim() == ("Cond Type"))
                        {

                            CondTypeid = columid;
                            //  headindex = rowid;



                        }


                        if (value.Trim()==("Mat Number")  )
                        {

                            MatNumberid = columid;
                          //  headindex = rowid;



                        }


                        if (value.Trim()=="Sales Org"  )
                        {
                            SalesOrgid = columid;
                           // headindex = rowid;
                        }
                        if (value.Trim()=="Invoice Doc Nr"  )
                        {
                            InvoiceDocNrid = columid;
                         //   headindex = rowid;
                        }

                        if (value.Trim()=="Outbound Delivery" )
                        {
                            OutboundDeliveryid = columid;
                        //    headindex = rowid;
                        }

                        if (value.Trim()=="Delivery Date" )
                        {
                            DeliveryDateid = columid;
                          //  headindex = rowid;
                        }

                        if (value.Trim()=="Sales District"  )
                        {
                            SalesDistrictid = columid;
                         //   headindex = rowid;
                        }

                        if (value.Trim()=="Sales District desc"  )
                        {
                            SalesDistrictdescid = columid;
                          //  headindex = rowid;
                        }
                        if (value.Trim()=="Key Acc Nr" )
                        {
                            KeyAccNrid = columid;
                       //     headindex = rowid;
                        }
                        if (value.Trim()=="Mat Group"  )
                        {
                            MatGroupid = columid;
                         //   headindex = rowid;
                        }
                        if (value.Trim()=="Mat Group Text"  )
                        {
                            MatGroupTextid = columid;
                       //     headindex = rowid;
                        }
                        if (value.Trim()=="Mat Text"  )
                        {
                            MatTextid = columid;
                        //    headindex = rowid;
                        }
                        if (value.Trim()=="UoM"  )
                        {
                            UoMid = columid;
                        //    headindex = rowid;
                        }
                        if (value.Trim()=="Billed Qty"  )
                        {
                            BilledQtyid = columid;
                       //     headindex = rowid;
                        }
                        if (value.Trim()=="Net value"  )
                        {
                            Netvalueid = columid;
                           // headindex = rowid;
                        }
                        if (value.Trim().Contains("Cond Value")  )
                        {
                            CondValueid = columid;
                           // headindex = rowid;
                        }

                        if (value.Trim()=="Invoice Date"  )
                        {
                            InvoiceDateid = columid;
                         //   headindex = rowid;
                        }

                        if (value.Trim()=="Currency"  )
                        {
                            Currencyid = columid;
                          //  headindex = rowid;
                        }
                        #endregion

                    }


                }// colum

             

            }// roww off heatder

            #endregion
            if (Soldtoid ==-1)
            {
                MessageBox.Show("Please check Sold-to colunm","Thông báo" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
          if (CondTypeid == -1)
            {
                MessageBox.Show("Please check Cond Type colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustNameid == -1)
            {
                MessageBox.Show("Please check Customer colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MatNumberid == -1)
            {
                MessageBox.Show("Please check MatNumber colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SalesOrgid == -1)
            {
                MessageBox.Show("Please check SalesOrg colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (InvoiceDocNrid == -1)
            {
                MessageBox.Show("Please check Invoice Doc Nr colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (OutboundDeliveryid == -1)
            {
                MessageBox.Show("Please check Outbound Delivery colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DeliveryDateid == -1)
            {
                MessageBox.Show("Please check Delivery Date colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SalesDistrictid == -1)
            {
                MessageBox.Show("Please check Sales District colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SalesDistrictdescid == -1)
            {
                MessageBox.Show("Please check Sales District desc colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (KeyAccNrid == -1)
            {
                MessageBox.Show("Please check KeyAcc Nr colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (InvoiceDateid == -1)
            {
                MessageBox.Show("Please check Invoice Date colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MatGroupid == -1)
            {
                MessageBox.Show("Please check MatGroup colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MatGroupTextid == -1)
            {
                MessageBox.Show("Please check MatGroupText colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (BilledQtyid == -1)
            {
                MessageBox.Show("Please check Billed Qty colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Netvalueid == -1)
            {
                MessageBox.Show("Please check Netvalue colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CondValueid == -1)
            {
                MessageBox.Show("Please check CondValue colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Currencyid == -1)
            {
                MessageBox.Show("Please check Currency colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UoMid == -1)
            {
                MessageBox.Show("Please check UoM colunm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        //    Boolean kiemtratype = true;
            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string customer = sourceData.Rows[rowixd][Soldtoid].ToString();
                if (customer != "" && Utils.IsValidnumber(customer))
                {


                    DataRow dr = batable.NewRow();
                    dr["Soldto"] = double.Parse(sourceData.Rows[rowixd][Soldtoid].ToString());
                    dr["CustName"] = sourceData.Rows[rowixd][CustNameid].ToString().Trim();
                    dr["MatNumber"] = sourceData.Rows[rowixd][MatNumberid].ToString().Trim();
                    dr["SalesOrg"] = sourceData.Rows[rowixd][SalesOrgid].ToString().Trim();
                    dr["InvoiceDocNr"] = double.Parse(sourceData.Rows[rowixd][InvoiceDocNrid].ToString().Trim());
                    dr["OutboundDelivery"] = double.Parse(sourceData.Rows[rowixd][OutboundDeliveryid].ToString().Trim());
                    dr["DeliveryDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][DeliveryDateid].ToString().Trim());

                    dr["SalesDistrict"] = sourceData.Rows[rowixd][SalesDistrictid].ToString().Trim();
                    dr["CondType"] = sourceData.Rows[rowixd][CondTypeid].ToString().Trim();

                    if (sourceData.Rows[rowixd][CondTypeid].ToString().Trim() != "VPRS")
                    {

                        //kiemtratype = false;

                        //if (kiemtratype == false)
                        //{
                            MessageBox.Show("Cond type must be: VPRS , please check line: " + rowixd.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                     //   }
                    }

                    dr["SalesDistrictdesc"] = sourceData.Rows[rowixd][SalesDistrictdescid].ToString().Trim();
                    if (sourceData.Rows[rowixd][KeyAccNrid].ToString() !="" && sourceData.Rows[rowixd][KeyAccNrid]!=null)
                    {
                        dr["KeyAccNr"] = double.Parse(sourceData.Rows[rowixd][KeyAccNrid].ToString().Trim());
                    }
                

                    dr["MatGroup"] = double.Parse(sourceData.Rows[rowixd][MatGroupid].ToString().Trim());

                    dr["MatGroupText"] = sourceData.Rows[rowixd][MatGroupTextid].ToString();//.Trim();

                    dr["MatText"] = sourceData.Rows[rowixd][MatTextid].ToString().Trim();

                    dr["BilledQty"] = double.Parse(sourceData.Rows[rowixd][BilledQtyid].ToString().Trim());

                    dr["Netvalue"] = double.Parse(sourceData.Rows[rowixd][Netvalueid].ToString().Trim());

                    dr["Currency"] = sourceData.Rows[rowixd][Currencyid].ToString().Trim();
                    if (Utils.IsValidnumber(sourceData.Rows[rowixd][CondValueid].ToString().Trim()))
                    {
                        dr["CondValue"] = double.Parse(sourceData.Rows[rowixd][CondValueid].ToString().Trim());

                    }
                    else
                    {
                        MessageBox.Show("Please check CondValue in row: " + rowixd.ToString() + " Colum "+ CondValueid.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dr["InvoiceDate"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][InvoiceDateid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);
                    dr["UoM"] = sourceData.Rows[rowixd][UoMid].ToString().Trim();

                    
               //     dr["Username"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][Createdonid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);


                    batable.Rows.Add(dr);


                }



                #endregion

            }// row


         


            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_kasalesTemp";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Soldto", "[Sold-to]");
                bulkCopy.ColumnMappings.Add("[CustName]", "[Cust Name]");
                bulkCopy.ColumnMappings.Add("[MatNumber]", "[Mat Number]");
                bulkCopy.ColumnMappings.Add("[SalesOrg]", "[Sales Org]");
                bulkCopy.ColumnMappings.Add("[InvoiceDocNr]", "[Invoice Doc Nr]");
                bulkCopy.ColumnMappings.Add("[OutboundDelivery]", "[Outbound Delivery]");
                bulkCopy.ColumnMappings.Add("[DeliveryDate]", "[Delivery Date]");
                bulkCopy.ColumnMappings.Add("[SalesDistrict]", "[Sales District]");
                bulkCopy.ColumnMappings.Add("[SalesDistrictdesc]", "[Sales District desc]");
       //         bulkCopy.ColumnMappings.Add("[SalesGroup]", "[Sales Group]");
           ////     bulkCopy.ColumnMappings.Add("[SalesOff]", "[Sales Off]");
             //   bulkCopy.ColumnMappings.Add("[SalesOfficeDesc]", "[Sales Office Desc]");
                bulkCopy.ColumnMappings.Add("[KeyAccNr]", "[Key Acc Nr]");
                bulkCopy.ColumnMappings.Add("[InvoiceDate]", "[Invoice Date]");
                bulkCopy.ColumnMappings.Add("[MatGroup]", "[Mat Group]");
                bulkCopy.ColumnMappings.Add("[MatGroupText]", "[Mat Group Text]");
                bulkCopy.ColumnMappings.Add("[MatText]", "[Mat Text]");
                bulkCopy.ColumnMappings.Add("[CondType]", "[Cond Type]");


          //      bulkCopy.ColumnMappings.Add("[CondTypedesc]", "[Cond Type desc]");
                bulkCopy.ColumnMappings.Add("[BilledQty]", "[EC]");
                bulkCopy.ColumnMappings.Add("[Netvalue]", "[NSR]");
                bulkCopy.ColumnMappings.Add("[CondValue]", "[GSR]");
                bulkCopy.ColumnMappings.Add("[Currency]", "[Currency]");
                bulkCopy.ColumnMappings.Add("[Username]", "[Username]");
              //  bulkCopy.ColumnMappings.Add("[SalesGroupdesc]", "[Sales Group desc]");
                bulkCopy.ColumnMappings.Add("[UoM]", "[UoM]");
                //   bulkCopy.ColumnMappings.Add("[UoM]", "[UoM]");
             


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


        public void edlpinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Sales excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importsexcel2);
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

        public void COGSinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File COGS file excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                Thread t1 = new Thread(importsexcel2);
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




    }
}
