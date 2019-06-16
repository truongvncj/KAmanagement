using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using KAmanagement.shared;
using System.Globalization;
using System.Data.Sql;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.IO;

namespace KAmanagement
{
    class Utils
    {
        public static bool ChangeColumnDataType(DataTable table, string columnname, Type newtype)
        {
            if (table.Columns.Contains(columnname) == false)
                return false;

            DataColumn column = table.Columns[columnname];
            if (column.DataType == newtype)
                return true;

            try
            {
                DataColumn newcolumn = new DataColumn("temporary", newtype);
                table.Columns.Add(newcolumn);
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        row["temporary"] = Convert.ChangeType(row[columnname], newtype);
                    }
                    catch
                    {
                    }
                }
                table.Columns.Remove(columnname);
                newcolumn.ColumnName = columnname;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public static string getfirstusersalescontrolregion()
        {
            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            var regioncode = (from tbl_Temp in db.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();
            string rs = (from Tka_RegionRight in db.Tka_RegionRights
                         where Tka_RegionRight.RegionCode == regioncode
                         select Tka_RegionRight.Region).FirstOrDefault();

            return rs;
        }

        public static string getusername()
        {
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\Connectstring.txt";
            //       const Int32 BufferSize = 128;

            //using (var fileStream = File.OpenRead(fileName))
            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            //{
            string line;
            string st4;
            //while ((line = streamReader.ReadLine()) != null)

            //{

            Model.SercurityFucntion bm2 = new Model.SercurityFucntion();
            line = bm2.Readtextfromfile(fileName);
            string line2 = bm2.Decryption(line);


            string[] parts = line2.Split(';');
            if (parts.Count() >= 4)
            {
                st4 = parts[3].Trim();
            }
            else
            {
                st4 = "";
            }
            //       string st1 = parts[0].Trim();
            //       string st2 = parts[1].Trim();
            //  string st3 = parts[2].Trim();


            string username = st4;
            return username;



            //  }

            //      return "";

            // }

        }




        public static int getrightnumber()
        {
            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_Temp in dc.tbl_Temps
                      where tbl_Temp.username == username

                      select tbl_Temp.userright).FirstOrDefault();
            if (rs == null)
            {
                return 0;
            }
            else
            {

                return rs.Value;
            }

        }


        public static string getConnectionstr()
        {
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\Connectstring.txt";
            string connection_string = "";
            //      const Int32 BufferSize = 128;

            //using (var fileStream = File.OpenRead(fileName))
            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            //{
            string line;
            //while ((line = streamReader.ReadLine()) != null)

            //{



            Model.SercurityFucntion bm2 = new Model.SercurityFucntion();
            line = bm2.Readtextfromfile(fileName);
            string line2 = bm2.Decryption(line);



            string[] parts = line2.Split(';');

            string st1 = parts[0].Trim();
            string st2 = parts[1].Trim();
            string st3 = parts[2].Trim();
            //        string st4 = parts[3].Trim();

            connection_string = ("Data Source =" + st1 + "; Initial Catalog = KAmanagement; User Id =" + st2 + "; Password =" + st3).Trim();
            return connection_string;



            //    }

            //    return "";


            //}

        }


        public static bool IsValidateddmm(string testdate)
        {


            Regex regex = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-\.](0?[1 - 9]|1[012])[\/\-\.]\d{ 4 }$");
            return regex.IsMatch(testdate);


        }

        public static string IsValidContractName(string testContractNo, string region, string contracttype, string channel)
        {
            string kq = "OK";
            region = region.Trim();
            testContractNo = testContractNo.Trim();
            contracttype = contracttype.Trim();
            channel = channel.Trim();

            //----------------
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "KA")
            {
                Regex regex = new Regex(@"^S/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/KA/YY-YY/XXX";
                }

            }

            if ((region == "VN13") && contracttype == "KA")
            {
                Regex regex = new Regex(@"^C/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/KA/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "KA")
            {
                Regex regex = new Regex(@"^N/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/KA/YY-YY/XXX";
                }
            }


            //--------------------------

            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "RKA")
            {
                Regex regex = new Regex(@"^S/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/KA/YY-YY/XXX";
                }

            }

            if ((region == "VN13") && contracttype == "RKA")
            {
                Regex regex = new Regex(@"^C/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/KA/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "RKA")
            {
                Regex regex = new Regex(@"^N/KA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/KA/YY-YY/XXX";
                }
            }

            // NKA
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "NKA")
            {
                Regex regex = new Regex(@"^S/NKA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/NKA/YY-YY/XXX";
                }
            }

            if ((region == "VN13") && contracttype == "NKA")
            {
                Regex regex = new Regex(@"^C/NKA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/NKA/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "NKA")
            {
                Regex regex = new Regex(@"^N/NKA/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/NKA/YY-YY/XXX";
                }
            }
            // SCHOOL   EDU
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "SCHOOL" && channel == "EDU")
            {
                Regex regex = new Regex(@"^S/SCH/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/SCH/YY-YY/XXX";
                }
            }

            if ((region == "VN13") && contracttype == "SCHOOL" && channel == "EDU")
            {
                Regex regex = new Regex(@"^C/SCH/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/SCH/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "SCHOOL" && channel == "EDU")
            {
                Regex regex = new Regex(@"^N/SCH/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/SCH/YY-YY/XXX";
                }
            }
            // ASMPQ
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "ASMPQ")
            {
                Regex regex = new Regex(@"^S/ASMPQ/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/ASMPQ/YY-YY/XXX";
                }
            }

            if ((region == "VN13") && contracttype == "ASMPQ")
            {
                Regex regex = new Regex(@"^C/ASMPQ/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/ASMPQ/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "ASMPQ")
            {
                Regex regex = new Regex(@"^N/ASMPQ/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/ASMPQ/YY-YY/XXX";
                }
            }
            // DASANI
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "DASANI")
            {
                Regex regex = new Regex(@"^S/DAS/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/DAS/YY-YY/XXX";
                }
            }

            if ((region == "VN13") && contracttype == "DASANI")
            {
                Regex regex = new Regex(@"^C/DAS/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/DAS/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "DASANI")
            {
                Regex regex = new Regex(@"^N/DAS/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/DAS/YY-YY/XXX";
                }
            }

            // AT WORK   ATW
            if ((region == "VN11" || region == "VN15" || region == "VN17") && contracttype == "AT WORK" && channel == "ATW")
            {
                Regex regex = new Regex(@"^S/ATW/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "S/ATW/YY-YY/XXX";
                }
            }

            if ((region == "VN13") && contracttype == "AT WORK" && channel == "ATW")
            {
                Regex regex = new Regex(@"^C/ATW/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "C/ATW/YY-YY/XXX";
                }
            }

            if ((region == "VN12" || region == "VN16" || region == "VN19") && contracttype == "AT WORK" && channel == "ATW")
            {
                Regex regex = new Regex(@"^N/ATW/([0-9]{2})-([0-9]{2})/([0-9]{3,5})$");

                if (regex.IsMatch(testContractNo))
                {
                    kq = "OK";
                }
                else
                {
                    kq = "N/ATW/YY-YY/XXX";
                }
            }
            return kq;

        }


        public static bool IsValidatemmdd(string testdate)
        {


            Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01])[\/\-\.](0?[1-9]|1[012])[\/\-\.]((19|20)\d\d)");
            return regex.IsMatch(testdate);


        }

        public static bool IsValidnumber(string number)
        {


            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(number);


        }


        public DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IDbCommand cmd = ctx.GetCommand(query as IQueryable);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = (System.Data.SqlClient.SqlCommand)cmd;
            DataTable dt = new DataTable();


            try
            {

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }





                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }
        //run other app
        public static void RunOtherApp(string filename, bool isOpenInventer)
        {
            try
            {
                if (System.IO.File.Exists(filename))
                {
                    var p = new Process();
                    p.StartInfo.FileName = filename;
                    p.Start();
                    //p.WaitForExit(120000);
                    if (!isOpenInventer)
                    {
                        p.WaitForInputIdle(120000);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }


        //show form full screen
        /*      public static void FullScreen(Form f)
              {
                  f.Width = Screen.PrimaryScreen.WorkingArea.Width;
                  f.Height = Screen.PrimaryScreen.WorkingArea.Height;
                  f.StartPosition = FormStartPosition.CenterScreen;
              }*/


        //show form full parent
        /*       public static void ShowFormFullParent(Form f)
               {
                   f.Width = f.Parent.Width;
                   f.Height = f.Parent.Height; // -30;
               }

               public static void ShowFormInPanel(Form f, Panel p)
               {
                   foreach (Control c in p.Controls)
                   {
                       if (c.GetType().BaseType.FullName == "System.Windows.Forms.Form")
                       {
                           Form old_frm = (Form)c;
                           old_frm.Close();
                       }
                   }

                   f.TopLevel = false;
                   p.Controls.Clear();
                   p.Controls.Add(f);
                   f.Show();
                   f.BringToFront();
               }
               */


        /*      public static void ShowFormCenterOfParent(Form f)
              {
                  f.Left = (f.Parent.Width - f.Width) / 2;
                  f.Top = (f.Parent.Height - f.Height) / 2;
              }
              */
        //get function of FormMain
        //    public static form getparentofsubform(form subform)
        //  {
        //    mainform fm = (mainform)subform.parent.parent;
        //  return fm;

        //}

        //set value of specific cell in excel
        public static bool SetValueOfCellInExcel(cExcel.Worksheet sheet, int rowIndex, int clmIndex, string value)
        {
            // sheet.Cells[rowIndex,co]
            try
            {
                // cExcel.Range rng = sheet.Cells[rowIndex, clmIndex]; //get_Range("B5", "B5");
                cExcel.Range rng = (cExcel.Range)sheet.Cells[rowIndex, clmIndex];


                rng.Value2 = value;
                return true;
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.ToString());
                return false;
            }

        }


        //get value of specific cell in excel
        public static string GetValueOfCellInExcel(cExcel.Worksheet sheet, int rowIndex, int clmIndex)
        {
            try
            {
                cExcel.Range rng = (cExcel.Range)sheet.Cells[rowIndex, clmIndex]; //get_Range("B5", "B5");         
                if (rng.Value != null)
                {
                    return ((object)rng.Value).ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
                return null;
            }

        }

        //show message box when catch
        /*     public static void ShowErrorGeneralMsgBox(Exception ex)
             {
                 if (MessageBox.Show(Constants.Err_General_msg, Constants.Err_Caption_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                 {
                     MessageBox.Show(ex.ToString(), Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
             */
        //show message box when can't convert datetime

        /*public static void ShowErrorConvertDateTimeMsgBox(Exception ex)
        {
            if (MessageBox.Show(Constants.DateTime_Is_NOT_Valid_msg, Constants.Err_Caption_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                MessageBox.Show(ex.ToString(), Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        //ghi dữ liệu kiểu thông số ra file excel
        /*       public static void Write_ThongSoEttData_ToSheet(List<TextBox> lstTxtBx, string sheetName, List<Model.ThongSo_Ett> lstThongSoEtt, double default_value)
               {
                   try
                   {
                       //save thông số vào đối tượng 
                       for (int i = 0; i < lstTxtBx.Count; i++)
                       {
                           if (lstTxtBx[i].Text != "")
                           {
                               lstThongSoEtt[i].GiaTri = double.Parse(lstTxtBx[i].Text);
                           }
                           else
                           {
                               lstThongSoEtt[i].GiaTri = default_value;
                           }
                       }

                       //save thông số vào file excel
                       cExcel.Worksheet sheet2 = new cExcel.Worksheet();
                       //kiểm tra xem đã có sheet tương ứng chưa.
                       bool isExistent_Sheet = false;

                       if (OpenFile_Excel_of_Project())
                       {
                           foreach (cExcel.Worksheet sheet in Constants.book.Worksheets)
                           {
                               //nếu đã tồn tại sheet thì gọi sheet đó ra
                               if (sheet.Name.Equals(sheetName))
                               {
                                   isExistent_Sheet = true;
                                   sheet2 = sheet;
                               }
                           }
                           //nếu chưa tồn tại sheet này thì tạo sheet mới và chèn vào 
                           if (!isExistent_Sheet)
                           {
                               sheet2 = Constants.book.Worksheets.Add();
                               sheet2.Name = sheetName;
                           }

                           for (int i = 0; i < lstThongSoEtt.Count; i++)
                           {
                               if (SetHeader_ForSheet_NhapSL(sheet2))
                               {
                                   ThongSo_Ett ts = lstThongSoEtt[i];
                                   //set value in file
                                   Utils.SetValueOfCellInExcel(sheet2, i + 2, 1, ts.STT.ToString());
                                   Utils.SetValueOfCellInExcel(sheet2, i + 2, 2, ts.TenThongSo);
                                   Utils.SetValueOfCellInExcel(sheet2, i + 2, 3, ts.KyHieu);
                                   Utils.SetValueOfCellInExcel(sheet2, i + 2, 4, ts.GiaTri.ToString());
                                   Utils.SetValueOfCellInExcel(sheet2, i + 2, 5, ts.DonViTinh);
                               }
                           }

                           Constants.book.Save();
                           //đóng file excel sau khi sử dụng
                           Close_File_Excel_of_Project();
                           MessageBox.Show(Constants.Save_Data_Success_msg, Constants.Info_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                   }
                   catch (Exception ex)
                   {
                       Utils.ShowErrorGeneralMsgBox(ex);
                   }
               }
               */
        //ghi dữ liệu kiểu validate request ra file excel


        /*     public static void Write_ValidateRequestKTKCEttData_ToSheet(string sheetName, List<Model.KiemTraKC.Validate_Request_KTKC_Ett> lstValidateRequestKTKCEtt)
             {
                 try
                 {
                     //save thông số vào file excel
                     cExcel.Worksheet sheet2 = new cExcel.Worksheet();
                     //kiểm tra xem đã có sheet tương ứng chưa.
                     bool isExistent_Sheet = false;

                     if (OpenFile_Excel_of_Project())
                     {
                         foreach (cExcel.Worksheet sheet in Constants.book.Worksheets)
                         {
                             //nếu đã tồn tại sheet thì gọi sheet đó ra
                             if (sheet.Name.Equals(sheetName))
                             {
                                 isExistent_Sheet = true;
                                 sheet2 = sheet;
                             }
                         }
                         //nếu chưa tồn tại sheet này thì tạo sheet mới và chèn vào 
                         if (!isExistent_Sheet)
                         {
                             sheet2 = Constants.book.Worksheets.Add();
                             sheet2.Name = sheetName;
                         }

                         for (int i = 0; i < lstValidateRequestKTKCEtt.Count; i++)
                         {
                             //if (SetHeader_ForSheet_NhapSL(sheet2))
                             //{
                             Validate_Request_KTKC_Ett ts = lstValidateRequestKTKCEtt[i];
                             //set value in file
                             Utils.SetValueOfCellInExcel(sheet2, i + 2, 2, ts.Name);
                             if (ts.OK)
                             {
                                 Utils.SetValueOfCellInExcel(sheet2, i + 2, 3, Constants.Dat_text_Value);
                             }
                             else
                             {
                                 Utils.SetValueOfCellInExcel(sheet2, i + 2, 3, Constants.Khong_Dat_text_Value);
                             }
                             //}
                         }

                         Constants.book.Save();
                         //đóng file excel sau khi sử dụng
                         Close_File_Excel_of_Project();
                         //MessageBox.Show(Constants.Save_Data_Success_msg, Constants.Info_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                 }
                 catch (Exception ex)
                 {
                     Utils.ShowErrorGeneralMsgBox(ex);
                 }
             }

             //phương thức ghi header cho toàn bộ Sheet NhapSL
             public static bool SetHeader_ForSheet_NhapSL(cExcel.Worksheet sheet)
             {
                 try
                 {
                     Utils.SetValueOfCellInExcel(sheet, 1, 1, Model.ThongSo_HeaderName_ett.STT);
                     Utils.SetValueOfCellInExcel(sheet, 1, 2, Model.ThongSo_HeaderName_ett.TenThongSo);
                     Utils.SetValueOfCellInExcel(sheet, 1, 3, Model.ThongSo_HeaderName_ett.KyHieu);
                     Utils.SetValueOfCellInExcel(sheet, 1, 4, Model.ThongSo_HeaderName_ett.GiaTri);
                     Utils.SetValueOfCellInExcel(sheet, 1, 5, Model.ThongSo_HeaderName_ett.DonViTinh);

                     return true;
                 }
                 catch (Exception ex)
                 {
                     ShowErrorGeneralMsgBox(ex);
                     return false;
                 }
             }
             */

        //Phương thức check xem có workbook excel nào đang được mở hay k?
        // đổi kiểu dd.MM.yyyy thành datime

        //public static DateTime chageExceldatetoData(string exceldatedotstring)  // dd.MM.YYYY to date
        //{

        //    string get_data = exceldatedotstring;//.Replace("9999",(DateTime.Now.Year +1).ToString());
        //    char spl2 = '.';
        //    //get_data
        //    if (get_data.Contains("/"))
        //    {

        //        spl2 = '/';
        //    }
        //    else
        //    {
        //        if (get_data.Contains("-"))
        //        {
        //            spl2 = '-';

        //        }
        //        else
        //        {
        //            spl2 = '.';

        //        }

        //    }

        //    List<string> lst_get_data = get_data.Split(spl2).ToList();
        //    // cmd.Parameters.AddWithValue("?", GetDateWithoutMilliseconds(DateTime.Now));

        //    //private DateTime GetDateWithoutMilliseconds(DateTime d)
        //    //        {
        //    //            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        //    //        }
        //    DateTime kq;
        //    try
        //    {
        //        kq = new DateTime(int.Parse(lst_get_data[2]), int.Parse(lst_get_data[1]), int.Parse(lst_get_data[0]));

        //    }
        //    catch (Exception) //DateTime year, month, day
        //    {
        //        kq = new DateTime(9999,12,31);


        //        //  throw;
        //    }

        //    //     DateTime result = new DateTime(kq.Year, kq.Month, kq.Day, kq.Hour, kq.Minute, kq.Second);
        //    // string result =  lst_get_data[2] + "-" + lst_get_data[1] + "-" + lst_get_data[0] ;
        //    return kq;
        //    //throw new NotImplementedException();
        //}

        public static DateTime chageExceldatetoData(string get_data)


        {
            DateTime result_date;//= DateTime.Now;
                                 //   get_data = "";
                                 //   if (excelDate != "")
                                 // {
                                 //    string get_data = excelDate;
                                 //  }

            if (Utils.IsValidnumber(get_data))
            {
                result_date = DateTime.FromOADate(double.Parse(get_data));
                
            }
            else
            {
                #region  tính nếu ko phải định dang số

                get_data = get_data.Replace(" ", "");
                get_data = get_data.Replace("'", "");
                get_data = get_data.Replace("-", "/");
                get_data = get_data.Replace(".", "/");


                //   result_date = DateTime.ParseExact(sresultdate, "dd/MM/yyyy", provider);
                CultureInfo provider = CultureInfo.InvariantCulture;
                try
                {
                    result_date = DateTime.ParseExact(get_data, "dd/MM/yyyy", provider);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi định dạng ngày tháng must be as: " + "dd.MM.yyyy" + "   " + ex.ToString());
                    result_date = new DateTime(00001, 01, 01);
                }

                #endregion
            }

            return result_date;

        }


        //public static DateTime newringchageExceldatetoData(string exceldatedotstring)  // dd.MM.YYYY to date
        //{
        //    DateTime kq = new DateTime(9999, 12, 31); ;
        //    if (exceldatedotstring == "" || exceldatedotstring == null)
        //    {

        //        MessageBox.Show("Please check Format date in excel file !", "Please check", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //  return;
        //    }

        //    string get_data = exceldatedotstring.Trim();//.Replace("9999",(DateTime.Now.Year +1).ToString());
        //    char spl2 = '.';
        //    //get_data
        //    if (get_data.Contains("/"))
        //    {

        //        spl2 = '/';
        //    }
        //    else
        //    {
        //        if (get_data.Contains("-"))
        //        {
        //            spl2 = '-';

        //        }

        //    }

        //    List<string> lst_get_data = get_data.Split(spl2).ToList();
        //    // cmd.Parameters.AddWithValue("?", GetDateWithoutMilliseconds(DateTime.Now));

        //    //private DateTime GetDateWithoutMilliseconds(DateTime d)
        //    //        {
        //    //            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        //    //        }

        //    try
        //    {
        //        kq = new DateTime(int.Parse(lst_get_data[2]), int.Parse(lst_get_data[1]), int.Parse(lst_get_data[0]));

        //    }
        //    catch (Exception) //DateTime year, month, day
        //    {
        //        kq = new DateTime(9999, 12, 31);
        //        MessageBox.Show("Please check Format date in excel file !", "Please check", MessageBoxButtons.OK, MessageBoxIcon.Error);


        //        //  throw;
        //    }

        //    //     DateTime result = new DateTime(kq.Year, kq.Month, kq.Day, kq.Hour, kq.Minute, kq.Second);
        //    // string result =  lst_get_data[2] + "-" + lst_get_data[1] + "-" + lst_get_data[0] ;
        //    return kq;
        //    //throw new NotImplementedException();
        //}





        public static bool IsHasWorkbookActive()
        {
            try
            {
                cExcel.Application isActive = (cExcel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                if (isActive != null)
                {
                    if (isActive.ActiveWorkbook != null)
                    //if (Constants.app.ActiveWorkbook != null)
                    {
                        isActive.Quit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.ToString());
                return false;
            }

        }

        //phương thức mở file excel của dự án 
        public static bool OpenFile_Excel(string filename)
        {
            try
            {
                object valueMissing = System.Reflection.Missing.Value;
                //check xem application đã được khởi tạo hay chưa
                if (Constants.app == null)
                {
                    //nếu chưa được khởi tạo thì khởi tạo mới
                    cExcel.Application app = new cExcel.Application();
                }
                else
                {
                    //nếu đã được khởi tạo thì ...
                    //check xem có dự án nào đang mở hay k, nếu có thì đóng lại trước khi mở dự án mới
                    if (Utils.IsHasWorkbookActive())
                    {
                        Constants.app.Quit();
                        //Constants.app = new cExcel.Application();
                    }
                }


                //     Constants.app.WorkbookOpen
                //mở file excel mới
                //   Constants.book = Constants.app.Workbooks.Open(Constants.URLtoFileStoreData, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                //      Constants.book = Constants.app.Workbooks.Open(filename, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);

                Constants.book = Constants.app.Workbooks.Open(filename, 0, false, 5, "", "", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                //   cExcel.Workbooks = new cExcel.Workbooks.

                //ok = Constants.app.WorkbookOpen;

                //      .app.Workbooks.Open(Constants.URLtoFileStoreData, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        //---
        public void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static bool CreatFile_Excel(string filename)
        {

            cExcel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            #region // kiểm tra file excel đã inteal chưa
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return false;
            }

            #endregion

            #region // tạo 1 file excel
            cExcel.Workbook xlWorkBook;
            cExcel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (cExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //   xlWorkSheet.Cells[1, 1] = "Sheet1";




            xlWorkBook.SaveAs(filename, cExcel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, cExcel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //  xlWorkBook.SaveAs(filename,cExcel.XlFileFormat.xlWorkbookDefault,)
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Utils ut = new Utils();

            ut.ReleaseObject(xlWorkSheet);
            ut.ReleaseObject(xlWorkBook);
            ut.ReleaseObject(xlApp);

            // MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
            return true;

            #endregion tạo 1 file excel


        }




        //phương thức đóng file excel của dự án và mở sẵn 1 file excel mới
        public static bool Close_File_Excel()
        {
            try
            {
                Constants.app.Quit();
                //Constants.app = new cExcel.Application();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //phương thức chèn dữ liệu ban đầu cho list_Validate_Request_KTKC
        /*   public static void Set_Value_for_List_Validate_Request_KTKC()
           {
               Constants.lst_Validate_Request_KTKC = new List<Model.KiemTraKC.Validate_Request_KTKC_Ett>();

               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienAAGiuaDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienBBDauDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.KetCauBanCanhDuoi_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.DieuKienDoCung_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.DieuKienOnDinhCucBo_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienCCGiuaDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
           }
           */
        //reset all global param
        /*    public static void Reset_All_Global_Param()
            {
                Controlers.NhapSL.ThongSoChoTruoc_ctrl.resetValueForThongSoDauVao();
                Controlers.NhapSL.ThongSoHinhHoc.KichThuocVaTietDienDam_ctrl.resetValueForKichThuocVaTietDienDam();
                Controlers.NhapSL.ThongSoHinhHoc.ThongSoGanTangCung_ctrl.resetValueForTS_GanTangCung();
                Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuCheTao_ctrl.resetValueForTS_VL_CheTao();
                Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuLienKet_ctrl.resetValueTS_VL_LienKet();
                Utils.Set_Value_for_List_Validate_Request_KTKC();
            }
            */


        //set value for all global param
        /*   public static void Set_Value_4_All_Global_Param()
           {
               try
               {
                   if (Utils.OpenFile_Excel_of_Project())
                   {
                       if (Constants.book.Worksheets.Count >= 0)
                       {
                           bool hasSheetTTDA = false;
                           //bool hasSheetTS_Chotruoc = false;

                           //reset all value of application
                           Utils.Reset_All_Global_Param();

                           foreach (cExcel.Worksheet sheet in Constants.book.Worksheets)
                           {
                               //nếu tồn tại sheet thoogn tin dự án thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongTinDuAn_MenuName))
                               {
                                   Controlers.NhapSL.ThongTinDuAn_ctrl.setValueForTTDA(sheet);
                                   hasSheetTTDA = true;
                               }

                               //nếu tồn tại sheet Thông số cho trước thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongSoChoTruoc_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoChoTruoc_ctrl.setValueForThongSoDauVao(sheet);
                               }

                               //nếu tồn tại sheet Kích thước và tiết diện dầm thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoHinhHoc_KichThuocVaTietDienDam_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoHinhHoc.KichThuocVaTietDienDam_ctrl.setValueForKichThuocVaTietDienDam(sheet);
                               }

                               //nếu tồn tại sheet Thông số gân tăng cứng thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoHinhHoc_ThongSoGanTangCung_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoHinhHoc.ThongSoGanTangCung_ctrl.setValueForTS_GanTangCung(sheet);
                               }

                               //nếu tồn tại sheet ThongSoVatLieuCheTao thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoVatLieu_ThongSoVatLieuCheTao_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuCheTao_ctrl.setValueForTS_VL_CheTao(sheet);
                               }

                               //nếu tồn tại sheet ThongSoVatLieuLienKet thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongSoVatLieu_ThongSoVatLieuLienKet_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuLienKet_ctrl.setValueForTS_VL_LienKet(sheet);
                               }

                               //nếu tồn tại sheet KiemTraKC thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.KiemTraKC_MenuName))
                               {
                                   Controlers.KiemTraKC.KiemTraKC_ctrl.setValueFor_ListValidateRequest(sheet);
                               }
                           }

                           //show msg error
                           if (!hasSheetTTDA)
                           {
                               MessageBox.Show(Constants.NOT_Existent_Sheet_msg + Constants.ThongTinDuAn_MenuName, Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                               Constants.ttda = new Model.NhapSL.ThongTinDuAn_Ett();
                           }
                       }

                       //đóng file excel sau khi sử dụng
                       if (!Utils.Close_File_Excel_of_Project())
                       {
                           if (MessageBox.Show(Constants.Error_Close_File_Excel_msg, Constants.Err_Caption_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                           {
                               Application.Exit();
                           }
                       }

                       //thôngTinDựÁnToolStripMenuItem_Click(sender, e);
                   }
                   else
                   {
                       MessageBox.Show(Constants.Error_Open_File_Excel_msg, Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               catch (Exception ex)
               {
                   ShowErrorGeneralMsgBox(ex);
               }
           }

           public static double LamTron_SoChan(double input_param)
           {
               try
               {
                   double tg = Math.Round(input_param, 0);
                   //kiểm tra xem có phải số chẵn hay k
                   if (tg % 2 == 0)
                   {
                       //Nếu là số chẵn thì trả ra
                       return tg;
                   }
                   else
                   {
                       //Nếu không phải là số chẵn thì cộng 1 và trả ra
                       return tg + 1;
                   }
               }
               catch (Exception ex)
               {
                   return double.NaN;
               }
           }
           */

        // doc file excel va so sanh vơi cac fied của data và update vào sql





        // doc file excel va so sanh vơi cac fied của data và update vào sql
        public static bool CopyFolder(string sourcePath, string targetPath)
        {
            try
            {
                if (System.IO.Directory.GetDirectories(sourcePath).Count() > 0)
                {
                    foreach (string d in System.IO.Directory.GetDirectories(sourcePath))
                    {
                        //chặt string lấy tên folder cuối cùng cộng thêm vào tên folder đích
                        string[] lst_folder = d.Split('\\');
                        targetPath = targetPath + "\\" + lst_folder[lst_folder.Count() - 1];
                        System.IO.Directory.CreateDirectory(targetPath);
                        CopyFolder(d, targetPath);

                        //sau khi copy file -> trả lại đường dẫn đến folder đích
                        string[] target_fdn_lst = targetPath.Split('\\');
                        int start_Index = targetPath.IndexOf(target_fdn_lst[target_fdn_lst.Count() - 1]);
                        targetPath = targetPath.Remove(start_Index - 1);
                    }
                }

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi copy file" + ex);
                return false;
            }

        }
    }


}

