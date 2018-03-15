using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

//--

using System.ComponentModel;

using KAmanagement.shared;

//--
namespace KAmanagement
{


    /// <summary>
    /// Provides linq querying functionality towards Excel (xls) files
    /// </summary>
    /// 

    public class ExcelProvider
    {
        /// <summary>
        /// Gets or sets the Excel filename
        /// </summary>
        //  private string FileName { get; set; }
        //   public System.Data.DataTable exceldatatb {get;set; }
        /// <summary>
        /// Template connectionstring for Excel connections
        /// </summary>
        //   public string ConnectionStringTemplate = "";
        /// <summary>
        /// Default constructor
        /// </summary>
        //   /// <param name="fileName">The Excel file to process</param>

        //    public LinQToExcelProvider() { }

        //public ExcelProvider()
        //{
        ////    FileName = fileName;
        //}


        /// <summary>
        /// Returns a worksheet as a linq-queryable enumeration
        /// </summary>
        //    /// <param name="sheetName">The name of the worksheet</param>
        /// <returns>An enumerable collection of the worksheet</returns>
        /// 
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
                //  MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public DataTable GetDataFromExcel(string filename)
        {

            var missing = System.Reflection.Missing.Value;


            cExcel.Application xlApp = new cExcel.Application();
    //        cExcel.Workbooks xlWorkBook = null;

        //    cExcel.Worksheet xlWorkSheet = GetworksheetObject(filename);
            //================
            cExcel.Application ExcelObj = new cExcel.Application();

            cExcel.Workbook theWorkbook = null;

         //   string strPath = FileName;// "MENTION PATH OF EXCEL FILE HERE";

            theWorkbook = ExcelObj.Workbooks.Open(filename);
            cExcel.Sheets sheets = theWorkbook.Worksheets;

            cExcel.Worksheet worksheet = (cExcel.Worksheet)sheets.get_Item(1);//Get the reference of second worksheet


            //===========



            cExcel.Range xlRange = worksheet.UsedRange;

            Array myValues = (Array)xlRange.Cells.Value2;

            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);

            DataTable mainDt = new DataTable();
            DataTable MiscDt = new DataTable();

            // must start with index = 1
            // get header information
            for (int i = 1; i <= horizontal; i++)
            {
                if (myValues.GetValue(1, i) == null)
                {
                    mainDt.Columns.Add(new DataColumn(i.ToString()).ToString());
                }
                else
                {
                    mainDt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
                }

            }

            // Get the row information
            for (int a = 1; a <= vertical; a++)
            {


                //SEE Below line for QUESTION..

                //Excel sheet cell has data as "11-30-11" but when i import it convert to "78608".  So i want import those data with data as "11-30-11".  


                string x = Convert.ToString(myValues.GetValue(a, 2));
                object[] poop = new object[horizontal];
                //if (x == "11-30-11")
                //{                    
                for (int b = 1; b <= horizontal; b++)
                {
                    poop[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = mainDt.NewRow();
                row.ItemArray = poop;
                mainDt.Rows.Add(row);
                //}                
            }

            // assign table to default data grid view
            //    dataGridView1.DataSource = mainDt;

            //   xlWorkBook.Close();// (true, missing, missing);
            xlRange = null;
            worksheet = null;
        //    xlWorkBook = null;
            xlApp.Quit();
            releaseObject(xlRange);
            releaseObject(worksheet);
            releaseObject(xlApp);
            //releaseObject(xlRange);
            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);

            return mainDt;
        }
        //-- get string dâttaable
        // Create a new DataTable for every Worksheet
        //public static DataTable GetDataFromExcel2(string filePath)
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("PriceList", typeof(string));
        //    table.Columns.Add("Material", typeof(string));
        //    table.Columns.Add("MaterialNAme", typeof(string));
        //    table.Columns.Add("Amount", typeof(double));

        //    table.Columns.Add("Unit", typeof(string));
        //    table.Columns.Add("UoM", typeof(string));

        //    table.Columns.Add("Valid_From", typeof(DateTime));
        //    table.Columns.Add("Valid_to", typeof(DateTime));




        //    //... add as many columns as your excel file has!!

        //    string connString = SetConnectionString(filePath);
        //    cExcel.Worksheet worksheet = GetworksheetObject(filePath);

        //    string Pricelist = "";
        //    int columpricelist = 0;
        //    int columpmaterial = 0;
        //    int columname = 0;
        //    int columpamount = 0;
        //    int columunit = 0;
        //    int columUoM = 0;
        //    int columValid_From = 0;
        //    int columValid_to = 0;
        //    int headindex = 0;
        //    for (int rowid = 0; rowid < worksheet.Rows.Count; rowid++)
        //    {
        //        headindex = 1;
        //        for (int columid = 0; columid <= 30; columid++)
        //        {

        //            string value = Utils.GetValueOfCellInExcel(worksheet, rowid, columid);

        //            if (value != null)
        //            {

        //                #region setcolum
        //                if (value.Trim() == "CnTy")
        //                {
        //                    columpricelist = columid;
        //                    headindex = 0;
        //                }

        //                if (value.Trim() == "Material")
        //                {
        //                    if (columname == 0)
        //                    {
        //                        columpmaterial = columid;
        //                        headindex = 0;
        //                    }

        //                }


        //                if (value.Trim() == "Material")
        //                {
        //                    if (columpmaterial != 0)
        //                    {
        //                        columname = columid;
        //                        headindex = 0;
        //                    }


        //                }


        //                if (value.Trim() == "Amount")
        //                {
        //                    columpamount = columid;
        //                    headindex = 0;
        //                }
        //                if (value.Trim() == "Unit")
        //                {
        //                    columunit = columid;
        //                    headindex = 0;
        //                }

        //                if (value.Trim() == "UoM")
        //                {
        //                    columUoM = columid;
        //                    headindex = 0;
        //                }

        //                if (value.Trim() == "Valid From")
        //                {
        //                    columValid_From = columid;
        //                    headindex = 0;
        //                }

        //                if (value.Trim() == "Valid to")
        //                {
        //                    columValid_to = columid;
        //                    headindex = 0;
        //                }

        //                #endregion

        //                #region setvalue of pricelist
        //                string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
        //                if (headindex != 0 && valuepricelist != "" && valuepricelist != "YPR0")
        //                {
        //                    Pricelist = value;


        //                }

        //                if (headindex != 0 && value != "" && valuepricelist == "YPR0")
        //                {
        //                    DataRow dr = table.NewRow();
        //                    dr["PriceList"] = Pricelist;
        //                    dr["Material"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpmaterial);
        //                    dr["MaterialNAme"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columname);
        //                    dr["Amount"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);
        //                    dr["Unit"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columunit);
        //                    dr["UoM"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
        //                    dr["Valid_From"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_From);
        //                    dr["Valid_to"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);



        //                    table.Rows.Add(dr);



        //                }



        //                #endregion





        //            }



        //            // copy vao server



        //        }

        //    }





        //    return table;
        //}


        //public static DataTable GetDataFromExcel3(string fileName)
        //{
        //    //        private DataTable GetExcelTable(string fileName, string sheetName)
        //    //  {
        //    // sheetName = sheetName.Replace(".", "#");
        //    string sConnection = SetConnectionString(fileName);
        //    string sSheetName = GetworksheetObject(fileName).Name;
        //    //     string strSelect = string.Format("select * from [{0}$]", sheetName);

        //    DataTable table = new DataTable();
        //    //table.Columns.Add("PriceList", typeof(string));
        //    //table.Columns.Add("Material", typeof(string));
        //    //table.Columns.Add("MaterialNAme", typeof(string));
        //    //table.Columns.Add("Amount", typeof(double));

        //    //table.Columns.Add("Unit", typeof(string));
        //    //table.Columns.Add("UoM", typeof(string));

        //    //table.Columns.Add("Valid_From", typeof(DateTime));
        //    //table.Columns.Add("Valid_to", typeof(DateTime));

        //    cExcel.Application ExcelObj = new cExcel.Application();


        //    OleDbCommand oleExcelCommand = default(OleDbCommand);
        //    OleDbDataReader oleExcelReader = default(OleDbDataReader);
        //    OleDbConnection oleExcelConnection = default(OleDbConnection);

        //    //    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Test.xls;Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";

        //    oleExcelConnection = new OleDbConnection(sConnection);
        //    oleExcelConnection.Open();

        //    //       dtTablesList = oleExcelConnection.GetSchema("Tables");

        //    //if (table.Rows.Count > 0)
        //    //{
        //    //    sSheetName = table.Rows[0]["TABLE_NAME"].ToString();
        //    //}

        //    table.Clear();
        //    table.Dispose();


        //    if (!string.IsNullOrEmpty(sSheetName))
        //    {
        //        oleExcelCommand = oleExcelConnection.CreateCommand();
        //        oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
        //        oleExcelCommand.CommandType = CommandType.Text;
        //        oleExcelReader = oleExcelCommand.ExecuteReader();
        //        //    nowputRow = 0;

        //        while (oleExcelReader.Read())
        //        {


        //            for (int i = 0; i < oleExcelReader.FieldCount; i++)
        //            {
        //                if (oleExcelReader[i] != DBNull.Value)
        //                {

        //                    //           dr[i.ToString()] = (oleExcelReader[i]).ToString();
        //                }
        //                else
        //                {
        //                    //             dr[i.ToString()] = "";
        //                }

        //            }


        //            DataRow dr = table.NewRow();
        //            //dr["Material"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpmaterial);
        //            //dr["MaterialNAme"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columname);
        //            //dr["Amount"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);
        //            //dr["Unit"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columunit);
        //            //dr["UoM"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
        //            //dr["Valid_From"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_From);
        //            //dr["Valid_to"] = Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);



        //            table.Rows.Add(dr);





        //        }
        //        oleExcelReader.Close();
        //    }
        //    oleExcelConnection.Close();

        //    ExcelObj.Quit();

        //    //releaseObject(xlWorkSheet);
        //    //releaseObject(xlWorkBook);
        //    //releaseObject.(ExcelObj);

        //    return table;
        //}


        // public static DataTable GetDataFromExcel(string filePath)
        // {
        //     DataTable dt = new DataTable();

        //         string conStr = SetConnectionString(filePath);

        //     OleDbConnection connExcel = new OleDbConnection(conStr);
        //     OleDbCommand cmdExcel = new OleDbCommand();
        //     OleDbDataAdapter oda = new OleDbDataAdapter();
        ////     DataTable dt = new DataTable();
        //     cmdExcel.Connection = connExcel;

        //     //Get the name of First Sheet
        //     connExcel.Open();
        //     DataTable dtExcelSchema;
        //     dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //     string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        //     connExcel.Close();

        //     //Read Data from First Sheet
        //     connExcel.Open();
        //     cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        //     oda.SelectCommand = cmdExcel;
        //     oda.Fill(dt);
        //     connExcel.Close();

        //     //Bind Data to GridView
        //     return dt;

        // }



        //getstring datatable
        public static string SetConnectionString(string fileName)
        {
            string ConnectionStringTemplate;
            if (fileName.Contains(".xlsx"))
            {
                ConnectionStringTemplate = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                ConnectionStringTemplate = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + fileName + ";" + "Extended Properties=Excel 8.0;";
            }

            return ConnectionStringTemplate;
        }



        //public static cExcel.Worksheet GetworksheetObject(string FileName)
        //{


        //    //       SetConnectionString();
        //    // tim sheetName
        //    cExcel.Application ExcelObj = new cExcel.Application();

        //    cExcel.Workbook theWorkbook = null;

        //    string strPath = FileName;// "MENTION PATH OF EXCEL FILE HERE";

        //    theWorkbook = ExcelObj.Workbooks.Open(strPath);
        //    cExcel.Sheets sheets = theWorkbook.Worksheets;

        //    cExcel.Worksheet worksheet = (cExcel.Worksheet)sheets.get_Item(1);//Get the reference of second worksheet




        //    return worksheet;
        //    //  string sheetName =  worksheet.Name;//Get the name of worksheet.
        //    // return sheetName;
        //}


    }






}

