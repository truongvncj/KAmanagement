using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;


namespace KAmanagement.shared
{



    class Constants
    {
        //ảnh mặc định của app
   //     public const string MainForm_Img = ".\\Image\\Untitled.jpg";

        #region String Format
        public const string Double_String_Format = "{0:0.00}";
        //public const string Double_String_Format = "{0:0,0.00}";
        public const string DateTime_String_Format = "{dd/MM/yyyy}";
        #endregion


        public static cExcel.Application app = new cExcel.Application();
        
        public static cExcel.Workbook book;
     
        
      


        #region ttda
        public const string URLtoFileStoreData = @"C:\" ;
        //  public const string Khong_Dat_text_Value = "Không Đạt";
        #endregion
        #region linq
      public static LinqtoSQLDataContext db = new LinqtoSQLDataContext() ;
      //  public static LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        #endregion

        public static DataGridView DataGridView1 = new DataGridView();
    }


}

