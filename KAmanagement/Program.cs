using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// </summary>
        [STAThread]

        static void Main()
        {
          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new View.Main());

           Application.Run(new View.Login());

            //  Priodchoice

            //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_ColdetailRpt);

            //Application.Run(new View.Inputchange("Main data", "Sub data", db, "tbl_ColdetailRpt", "tbl_ColdetailRpt", typeff, "id", "id"));
        }
    }
}
