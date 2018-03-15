using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class kamasscontractChange : Form
    {
        public kamasscontractChange()
        {
            InitializeComponent();


            Model.Username used = new Model.Username();

            this.cb_contractstatus.SelectedIndex = 1;


            //if (used.saleview == true)
            //{

            //    btsalesview.Enabled = true;
            //}
            //else
            //{
            //    btsalesview.Enabled = false;

            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
            //          select tblEDLP;
            string username = Utils.getusername();


            dc.ExecuteCommand("DELETE FROM tbl_MassContractChangeTemp where tbl_MassContractChangeTemp.Username ='" + username + "' or tbl_MassContractChangeTemp.Username is null");
            dc.SubmitChanges();

            Model.MassConfirm MassConfirm = new Model.MassConfirm();
            //   slmodel.deleteedlp();

            //    string connection_string = Utils.getConnectionstr();
            //    var db = new LinqtoSQLDataContext(connection_string);
            //   string username = Utils.getusername();
            //  var rs = from tblEDLP in db.tblEDLPs


            //    confirmmodel.


            //        Model.Salesinput_ctrl slmodel = new Model.Salesinput_ctrl();
            string contracts =      cb_contractstatus.Text;


            MassConfirm.massfileContractchangeinput(contracts);

            var rs = from tbl_MassContractChangeTemp in dc.tbl_MassContractChangeTemps
                     where tbl_MassContractChangeTemp.Username == username
                     select tbl_MassContractChangeTemp;


        
            if (rs.Count() > 0)
            {
                Viewtable viewtbl = new Viewtable(rs, dc, "CONTRACT LIST TO CHANGE STATUS", 12);// view code 11 la can viet them lenh MASS CONFIL

                viewtbl.Show();
                viewtbl.Focus();


            }





      //  }




    }

    private void button1_Click(object sender, EventArgs e)
        {

            //FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //bool kq = false;
            //foreach (Form frm in fc)
            //{
            //    if (frm.Text == "kaPriodpicker")
            //    {
            //        kq = true;
            //        frm.Focus();

            //    }
            //}

            //if (!kq)
            //{

            //    string connection_string = Utils.getConnectionstr();

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //    View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


            //    kaPriodpicker.ShowDialog();
            //    string priod = kaPriodpicker.priod;

            //    var rs = from tbl_kasale in dc.tbl_kasales
            //             where tbl_kasale.Priod == priod
            //             select new
            //             {
            //                 tbl_kasale.Priod,
            //                 tbl_kasale.Sales_District,
            //                 tbl_kasale.Sales_District_desc,
            //                 tbl_kasale.Sales_Org,
            //                 tbl_kasale.Sold_to,
            //                 tbl_kasale.Cust_Name,
            //                 tbl_kasale.Outbound_Delivery,
            //                 tbl_kasale.Key_Acc_Nr,
            //                 tbl_kasale.Delivery_Date,
            //                 tbl_kasale.Invoice_Doc_Nr,
            //                 tbl_kasale.Invoice_Date,
            //                 tbl_kasale.Currency,
            //                 tbl_kasale.Mat_Group,
            //                 tbl_kasale.Mat_Group_Text,
            //                 tbl_kasale.Mat_Number,
            //                 tbl_kasale.Mat_Text,

            //                 PCs = tbl_kasale.EC,
            //                 tbl_kasale.UoM,
            //                 EC = tbl_kasale.PC,

            //                 tbl_kasale.UC,
            //                 tbl_kasale.Litter,
            //                 tbl_kasale.GSR,

            //                 tbl_kasale.NSR,

                          

                       
                   
            //                 tbl_kasale.Username,
            //                 tbl_kasale.id


            //             };

            //    Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 2);// view code 1 la can viet them lenh

            //    viewtbl.Show();
            //    viewtbl.Focus();
            //}


        }

        private void button3_Click(object sender, EventArgs e)
        {


            //FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //bool kq = false;
            //foreach (Form frm in fc)
            //{
            //    if (frm.Text == "kaPriodpicker")
            //    {
            //        kq = true;
            //        frm.Focus();

            //    }
            //}

            //if (!kq)
            //{


            //    View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

            //    kaPriodpicker.ShowDialog();
            //    string priod = kaPriodpicker.priod;
            //    if (priod != "")
            //    {
            //        string connection_string = Utils.getConnectionstr();

            //        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //        db.ExecuteCommand("DELETE FROM tbl_kasales where tbl_kasales.Priod = '" + priod + "'");
            //        db.SubmitChanges();

            //        MessageBox.Show("Delete Done !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }



            //}


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kasalesuploadandreports_Load(object sender, EventArgs e)
        {

        }
    }
}
