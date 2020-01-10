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
    public partial class Kasalesuploadandreports : Form
    {
        public Kasalesuploadandreports()
        {
            InitializeComponent();


            Model.Username used = new Model.Username();

            if (used.saledeleted == true)
            {

                btdelete.Enabled = true;
            }
            else
            {
                btdelete.Enabled = false;

            }


            if (used.saleupdate == true)
            {

                btupdate.Enabled = true;
            }
            else
            {
                btupdate.Enabled = false;

            }



            if (used.saleview == true)
            {

                btsalesview.Enabled = true;
            }
            else
            {
                btsalesview.Enabled = false;

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
            //          select tblEDLP;
            string username = Utils.getusername();

            //  tbl_Kasa
            dc.ExecuteCommand("DELETE FROM tbl_kasalesTemp where tbl_kasalesTemp.Username = '" + username + "' or tbl_kasalesTemp.Username is null or tbl_kasalesTemp.Priod is null");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            //tbl_kasalesTemp p = new tbl_kasalesTemp();
            //p.Priod


            dc.ExecuteCommand("DELETE FROM tbl_KaCustomertemp where tbl_KaCustomertemp.Username ='" + username + "' or tbl_KaCustomertemp.Username is null");
            dc.SubmitChanges();


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {
                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

                //   Datepick
                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                DateTime fromdate = kaPriodpicker.fromdate;
                DateTime todate = kaPriodpicker.todate;

                bool chon = kaPriodpicker.kq;
                if (chon)
                {


                    if (priod != "" && fromdate != todate && priod != null)
                    {

                        Model.Salesinput_ctrl slmodel = new Model.Salesinput_ctrl();


                        slmodel.edlpinput();

                        List<string> condtypelist = new List<string>();
                        condtypelist.Add("YPR0");
                        condtypelist.Add("YPRD");
                        condtypelist.Add("NETP");


                        #region // giới hạn doc type  chỉ chấp nhận 3 loại YPR0,YPRD,NETP 

                        var rsdoc = (from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                     where tbl_kasalesTemp.Username == username && !condtypelist.Contains(tbl_kasalesTemp.Cond_Type)

                                     select tbl_kasalesTemp).Take(10);
                        if (rsdoc.Count() > 0)
                        {
                            Viewtable viewtbl2 = new Viewtable(rsdoc, dc, "kHÔNG UPLOAD ĐƯỢC, CÓ CÁC DOC TYPE KHÔNG ĐÚNG KIỂU : YPR0, YPRD, NETP ", 3);// view code 1 la can viet them lenh

                            viewtbl2.Show();
                            viewtbl2.Focus();

                            return;

                        }


                        #endregion


                        #region // list  doc da post

                        var rsdoc3 = (from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                      where tbl_kasalesTemp.Username == username &&
                                      ((tbl_kasalesTemp.Invoice_Date < fromdate || tbl_kasalesTemp.Invoice_Date > todate))
                                      select tbl_kasalesTemp).Take(10);
                        if (rsdoc3.Count() > 0)
                        {
                            Viewtable viewtbl2 = new Viewtable(rsdoc3, dc, "kHÔNG UPLOAD ĐƯỢC, CÓ CÁC DOC DATE KHÔNG THUỘC PRIOD: " + priod, 3);// view code 1 la can viet them lenh

                            viewtbl2.Show();
                            viewtbl2.Focus();

                            return;

                        }


                        #endregion

                        #region // productnew


                        var da = new LinqtoSQLDataContext(connection_string);
                        da.ExecuteCommand("DELETE FROM tbl_kaProductlistemp where tbl_kaProductlistemp.Username ='" + username + "'");
                        da.SubmitChanges();

                        var rscustemp = from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                        where !(from tbl_kaProductlist in dc.tbl_kaProductlists
                                                select tbl_kaProductlist.MatNumber).Contains(tbl_kasalesTemp.Mat_Number) && tbl_kasalesTemp.Mat_Number != null
                                        group tbl_kasalesTemp by tbl_kasalesTemp.Mat_Number into g

                                        select new
                                        {
                                            MatNumber = g.Key,
                                            MatText = g.Select(gg => gg.Mat_Text).FirstOrDefault(),
                                            UoM = g.Select(gg => gg.UoM).FirstOrDefault(),
                                            Pcrate = 0,
                                            Ucrate = 0
                                        };


                        if (rscustemp.Count() > 0)
                        {

                            //      var db = new LinqtoSQLDataContext(connection_string);
                            foreach (var item in rscustemp)
                            {
                                tbl_kaProductlistemp prduct = new tbl_kaProductlistemp();
                                prduct.MatNumber = item.MatNumber;
                                prduct.MatText = item.MatText;
                                prduct.UoM = item.UoM;
                                prduct.Pcrate = 0;
                                prduct.Ucrate = 0;
                                prduct.Username = username;
                                if (prduct.MatNumber != null)
                                {
                                    da.tbl_kaProductlistemps.InsertOnSubmit(prduct);
                                    da.SubmitChanges();

                                }

                            }

                            var typeffmain = typeof(tbl_kaProductlist);
                            var typeffsub = typeof(tbl_kaProductlistemp);

                            VInputchange inputcdata = new VInputchange("PRODUCT LIST", "LIST PRODUCT NOT IN MASTER DATAPRODUCT", dc, "tbl_kaProductlist", "tbl_kaProductlistemp", typeffmain, typeffsub, "id", "id", username);
                            inputcdata.Show();
                            inputcdata.Focus();
                            return;


                        }


                        #endregion product new  //--------------------


                        #region// update pc, uc

                        SqlConnection conn2 = null;
                        SqlDataReader rdr1 = null;

                        string destConnString = Utils.getConnectionstr();
                        try
                        {

                            conn2 = new SqlConnection(destConnString);
                            conn2.Open();
                            SqlCommand cmd1 = new SqlCommand("KAupdateSalePC_UCtemptable", conn2);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.Add("@priod", SqlDbType.VarChar).Value = priod;
                            cmd1.CommandTimeout = 0;
                            rdr1 = cmd1.ExecuteReader();



                            //       rdr1 = cmd1.ExecuteReader();

                        }
                        finally
                        {
                            if (conn2 != null)
                            {
                                conn2.Close();
                            }
                            if (rdr1 != null)
                            {
                                rdr1.Close();
                            }
                        }
                        //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        #endregion update pc, uc

                        #region  // view sales volume

                        var rs = from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                 where tbl_kasalesTemp.Username == username && tbl_kasalesTemp.Priod == priod //&& tbl_kasalesTemp.Username == username
                                 select new
                                 {
                                     tbl_kasalesTemp.Priod,


                                     tbl_kasalesTemp.Sold_to,
                                     tbl_kasalesTemp.Sales_Org,
                                     tbl_kasalesTemp.Sales_District,
                                     tbl_kasalesTemp.Sales_District_desc,

                                     tbl_kasalesTemp.Cust_Name,
                                     tbl_kasalesTemp.Outbound_Delivery,

                                     tbl_kasalesTemp.Delivery_Date,

                                     tbl_kasalesTemp.Invoice_Doc_Nr,
                                     tbl_kasalesTemp.Invoice_Date,

                                     tbl_kasalesTemp.Key_Acc_Nr,
                                     tbl_kasalesTemp.Cond_Type,

                                     tbl_kasalesTemp.Mat_Group,
                                     tbl_kasalesTemp.Mat_Group_Text,
                                     tbl_kasalesTemp.Mat_Number,
                                     tbl_kasalesTemp.Mat_Text,

                                     tbl_kasalesTemp.Currency,


                                     PCs = tbl_kasalesTemp.EC,
                                     tbl_kasalesTemp.UoM,
                                     tbl_kasalesTemp.EmptyCountValue,
                                     tbl_kasalesTemp.GSR,
                                     tbl_kasalesTemp.Litter,
                                     tbl_kasalesTemp.NETP,
                                     tbl_kasalesTemp.NSR,

                                     EC = tbl_kasalesTemp.PC,

                                     tbl_kasalesTemp.UC,

                                     tbl_kasalesTemp.Username,
                                     tbl_kasalesTemp.id,



                                 };





                        if (rs.Count() > 0)
                        {
                            Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 1);// view code 1 la can viet them lenh

                            viewtbl.Show();
                            viewtbl.Focus();


                        }

                        #endregion



                    }

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                dc.CommandTimeout = 0;

                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


                kaPriodpicker.ShowDialog();

                string priod = kaPriodpicker.priod;
                bool chon = kaPriodpicker.kq;


                if (chon)
                {
                    #region view


                    var rs = from tbl_kasale in dc.tbl_kasales
                             where tbl_kasale.Priod == priod
                             select new
                             {
                                 tbl_kasale.Priod,
                                 tbl_kasale.Sales_District,
                                 tbl_kasale.Sales_District_desc,
                                 tbl_kasale.Sales_Org,
                                 tbl_kasale.Sold_to,
                                 tbl_kasale.Cust_Name,
                                 tbl_kasale.Outbound_Delivery,
                                 tbl_kasale.Key_Acc_Nr,
                                 tbl_kasale.Delivery_Date,
                                 tbl_kasale.Invoice_Doc_Nr,
                                 tbl_kasale.Invoice_Date,
                                 tbl_kasale.Currency,
                                 tbl_kasale.Mat_Group,
                                 tbl_kasale.Mat_Group_Text,
                                 tbl_kasale.Mat_Number,
                                 tbl_kasale.Mat_Text,

                                 PCs = tbl_kasale.EC,
                                 tbl_kasale.UoM,
                                 EC = tbl_kasale.PC,

                                 tbl_kasale.UC,
                                 tbl_kasale.Litter,
                                 tbl_kasale.GSR,

                                 tbl_kasale.NSR,





                                 tbl_kasale.Username,
                                 tbl_kasale.id


                             };

                    Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 55);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                    #endregion

                }



            }


        }

        private void button3_Click(object sender, EventArgs e)
        {


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                bool chon = kaPriodpicker.kq;
                if (chon)
                {

                    if (priod != "")
                    {
                        string connection_string = Utils.getConnectionstr();

                        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                        db.ExecuteCommand("DELETE FROM tbl_kasales where tbl_kasales.Priod = '" + priod + "'");
                        db.SubmitChanges();

                        MessageBox.Show("Delete sales data of priod " + priod + "  Done !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kasalesuploadandreports_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
            //          select tblEDLP;
            string username = Utils.getusername();

            //  tbl_Kasa
            dc.ExecuteCommand("DELETE FROM tbl_kasalesTemp where tbl_kasalesTemp.Username = '" + username + "' or tbl_kasalesTemp.Username is null or tbl_kasalesTemp.Priod is null");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            //tbl_kasalesTemp p = new tbl_kasalesTemp();
            //p.Priod


            dc.ExecuteCommand("DELETE FROM tbl_KaCustomertemp where tbl_KaCustomertemp.Username ='" + username + "' or tbl_KaCustomertemp.Username is null");
            dc.SubmitChanges();









            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {
                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

                //   Datepick
                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                DateTime fromdate = kaPriodpicker.fromdate;
                DateTime todate = kaPriodpicker.todate;

                //string connection_string = Utils.getConnectionstr();
                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //string username = Utils.getusername();

                if (priod != "" && fromdate != todate && priod != null)
                {

                    Model.Salesinput_ctrl slmodel = new Model.Salesinput_ctrl();


                    slmodel.COGSinput();

                    #region // giới hạn doc type  chỉ chấp nhận 3 loại YPR0,YPRD,NETP 

                    List<string> condtypelist = new List<string>();
                    condtypelist.Add("VPRS");

                    //#region // giới hạn doc type  chỉ chấp nhận 3 loại YPR0,YPRD,NETP 

                    //var rsdoc = (from tbl_kasalesTemp in dc.tbl_kasalesTemps
                    //             where tbl_kasalesTemp.Username == username && !condtypelist.Contains(tbl_kasalesTemp.Cond_Type)





                    var rsdoc1 = (from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                  where tbl_kasalesTemp.Username == username && !condtypelist.Contains(tbl_kasalesTemp.Cond_Type)


                                  select tbl_kasalesTemp).Take(10);
                    if (rsdoc1.Count() > 0)
                    {
                        Viewtable viewtbl2 = new Viewtable(rsdoc1, dc, "kHÔNG UPLOAD ĐƯỢC, CÓ CÁC DOC TYPE KHÔNG ĐÚNG KIỂU : VPRS ", 3);// view code 1 la can viet them lenh

                        viewtbl2.Show();
                        viewtbl2.Focus();

                        return;

                    }


                    #endregion


                    #region // list  doc da không thuộc kỳ hiện thời post

                    var rsdoc = (from tbl_kasalesTemp in dc.tbl_kasalesTemps
                                 where tbl_kasalesTemp.Username == username &&
                                 ((tbl_kasalesTemp.Invoice_Date < fromdate || tbl_kasalesTemp.Invoice_Date > todate))
                                 select tbl_kasalesTemp).Take(5);
                    if (rsdoc.Count() > 0)
                    {
                        Viewtable viewtbl2 = new Viewtable(rsdoc, dc, "kHÔNG UPLOAD ĐƯỢC, CÓ CÁC DOC VÍ DỤ NHƯ CÁC DOC SAU DATE KHÔNG THUỘC PRIOD: " + priod, 3);// view code 1 la can viet them lenh

                        viewtbl2.Show();
                        viewtbl2.Focus();

                        return;

                    }


                    #endregion



                    #region// update cogs value, ĐỒNG THỜI ĐÁNH DAU CÁC DOC KO UP ĐUOCWJ

                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("KAupdateCOGStemptable", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@priod", SqlDbType.VarChar).Value = priod;
                        cmd1.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;

                        cmd1.CommandTimeout = 0;
                        rdr1 = cmd1.ExecuteReader();



                        //       rdr1 = cmd1.ExecuteReader();

                    }
                    finally
                    {
                        if (conn2 != null)
                        {
                            conn2.Close();
                        }
                        if (rdr1 != null)
                        {
                            rdr1.Close();
                        }
                    }
                    MessageBox.Show("Upload done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    #endregion update pc, uc






                }


            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {
                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

                //   Datepick
                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                DateTime fromdate = kaPriodpicker.fromdate;
                DateTime todate = kaPriodpicker.todate;
                bool chon = kaPriodpicker.kq;


                if (chon)
                {
                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    #region  // view sales volume

                    var rs33 = from tbl_kasale in dc.tbl_kasales
                               where tbl_kasale.Priod == priod
                               && tbl_kasale.Cogs != null
                               select new
                               {
                                   tbl_kasale.Priod,


                                   tbl_kasale.Sold_to,
                                   tbl_kasale.Sales_Org,
                                   tbl_kasale.Sales_District,
                                   tbl_kasale.Sales_District_desc,

                                   tbl_kasale.Cust_Name,
                                   tbl_kasale.Outbound_Delivery,

                                   tbl_kasale.Delivery_Date,

                                   tbl_kasale.Invoice_Doc_Nr,
                                   tbl_kasale.Invoice_Date,

                                   tbl_kasale.Key_Acc_Nr,
                                   ///tbl_kasale.c,

                                   tbl_kasale.Mat_Group,
                                   tbl_kasale.Mat_Group_Text,
                                   tbl_kasale.Mat_Number,
                                   tbl_kasale.Mat_Text,

                                   tbl_kasale.Currency,


                                   PCs = tbl_kasale.EC,
                                   tbl_kasale.UoM,
                                   //    tbl_kasalesTemp.EmptyCountValue,
                                   COGS = tbl_kasale.Cogs,
                                   //     tbl_kasalesTemp.Litter,
                                   //    tbl_kasalesTemp.NETP,
                                   //   tbl_kasalesTemp.NSR,
                                   //    tbl_kasalesTemp.
                                   //    EC = tbl_kasalesTemp.PC,

                                   //     tbl_kasalesTemp.UC,

                                   UserUpdate = tbl_kasale.Username,
                                   tbl_kasale.id,



                               };





                    if (rs33.Count() >= 0)
                    {
                        Viewtable viewtbl = new Viewtable(rs33, dc, "COGS DATA PRIOD: " + priod, 22);// view code 22 la can viet cogs

                        viewtbl.ShowDialog();
                        //    viewtbl.Focus();


                    }

                    #endregion

                }





            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //     kaPriodandcustomerpicker
            // XmlReadMode



            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriod and Customer code picker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                dc.CommandTimeout = 0;

                View.kaPriodandcustomerpicker kaPriodpicker = new View.kaPriodandcustomerpicker();


                kaPriodpicker.ShowDialog();

                string priod = kaPriodpicker.priod;
                string customercode = kaPriodpicker.customercode;
                string fromcode = kaPriodpicker.fromcode;
                string tocode = kaPriodpicker.tocode;
                bool onlycust = kaPriodpicker.onlycust;
                bool fromcodeto = kaPriodpicker.fromcodeto;



                bool chon = kaPriodpicker.kq;
                if (chon & onlycust == true)
                {
                    #region show so da chon



                    var rs = from tbl_kasale in dc.tbl_kasales
                             where tbl_kasale.Priod == priod
                             && tbl_kasale.Sold_to == double.Parse(customercode)

                             select new
                             {
                                 tbl_kasale.Priod,
                                 tbl_kasale.Sales_District,
                                 tbl_kasale.Sales_District_desc,
                                 tbl_kasale.Sales_Org,
                                 tbl_kasale.Sold_to,
                                 tbl_kasale.Cust_Name,
                                 tbl_kasale.Outbound_Delivery,
                                 tbl_kasale.Key_Acc_Nr,
                                 tbl_kasale.Delivery_Date,
                                 tbl_kasale.Invoice_Doc_Nr,
                                 tbl_kasale.Invoice_Date,
                                 tbl_kasale.Currency,
                                 tbl_kasale.Mat_Group,
                                 tbl_kasale.Mat_Group_Text,
                                 tbl_kasale.Mat_Number,
                                 tbl_kasale.Mat_Text,

                                 PCs = tbl_kasale.EC,
                                 tbl_kasale.UoM,
                                 EC = tbl_kasale.PC,

                                 tbl_kasale.UC,
                                 tbl_kasale.Litter,
                                 tbl_kasale.GSR,

                                 tbl_kasale.NSR,





                                 tbl_kasale.Username,
                                 tbl_kasale.id


                             };

                    Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod + " OF CUSTOMER " + customercode, 55);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                    #endregion

                }

                if (chon & fromcodeto == true)
                {
                    #region show so da chon



                    var rs = from tbl_kasale in dc.tbl_kasales
                             where tbl_kasale.Priod == priod
                             && tbl_kasale.Sold_to >= double.Parse(fromcode)
                               && tbl_kasale.Sold_to <= double.Parse(tocode)

                             select new
                             {
                                 tbl_kasale.Priod,
                                 tbl_kasale.Sales_District,
                                 tbl_kasale.Sales_District_desc,
                                 tbl_kasale.Sales_Org,
                                 tbl_kasale.Sold_to,
                                 tbl_kasale.Cust_Name,
                                 tbl_kasale.Outbound_Delivery,
                                 tbl_kasale.Key_Acc_Nr,
                                 tbl_kasale.Delivery_Date,
                                 tbl_kasale.Invoice_Doc_Nr,
                                 tbl_kasale.Invoice_Date,
                                 tbl_kasale.Currency,
                                 tbl_kasale.Mat_Group,
                                 tbl_kasale.Mat_Group_Text,
                                 tbl_kasale.Mat_Number,
                                 tbl_kasale.Mat_Text,

                                 PCs = tbl_kasale.EC,
                                 tbl_kasale.UoM,
                                 EC = tbl_kasale.PC,

                                 tbl_kasale.UC,
                                 tbl_kasale.Litter,
                                 tbl_kasale.GSR,

                                 tbl_kasale.NSR,





                                 tbl_kasale.Username,
                                 tbl_kasale.id


                             };

                    Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod + " FROM CODE " + fromcode + " TO CODE " + tocode, 55);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                    #endregion

                }




            }






        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriod and Customer code picker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {
                View.kaPriodandcustomerpicker kaPriodpicker = new View.kaPriodandcustomerpicker();

                //   Datepick
                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                string customercode = kaPriodpicker.customercode;

                DateTime fromdate = kaPriodpicker.fromdate;
                DateTime todate = kaPriodpicker.todate;
                bool chon = kaPriodpicker.kq;


                if (chon)
                {
                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    #region  // view sales volume

                    var rs33 = from tbl_kasale in dc.tbl_kasales
                               where tbl_kasale.Priod == priod
                               && tbl_kasale.Sold_to == double.Parse(customercode)
                                   && tbl_kasale.Cogs != null
                               select new
                               {
                                   tbl_kasale.Priod,


                                   tbl_kasale.Sold_to,
                                   tbl_kasale.Sales_Org,
                                   tbl_kasale.Sales_District,
                                   tbl_kasale.Sales_District_desc,

                                   tbl_kasale.Cust_Name,
                                   tbl_kasale.Outbound_Delivery,

                                   tbl_kasale.Delivery_Date,

                                   tbl_kasale.Invoice_Doc_Nr,
                                   tbl_kasale.Invoice_Date,

                                   tbl_kasale.Key_Acc_Nr,
                                   ///tbl_kasale.c,

                                   tbl_kasale.Mat_Group,
                                   tbl_kasale.Mat_Group_Text,
                                   tbl_kasale.Mat_Number,
                                   tbl_kasale.Mat_Text,

                                   tbl_kasale.Currency,


                                   PCs = tbl_kasale.EC,
                                   tbl_kasale.UoM,
                                   //    tbl_kasalesTemp.EmptyCountValue,
                                   COGS = tbl_kasale.Cogs,
                                   //     tbl_kasalesTemp.Litter,
                                   //    tbl_kasalesTemp.NETP,
                                   //   tbl_kasalesTemp.NSR,
                                   //    tbl_kasalesTemp.
                                   //    EC = tbl_kasalesTemp.PC,

                                   //     tbl_kasalesTemp.UC,

                                   UserUpdate = tbl_kasale.Username,
                                   tbl_kasale.id,



                               };





                    if (rs33.Count() >= 0)
                    {
                        Viewtable viewtbl = new Viewtable(rs33, dc, "COGS DATA PRIOD: " + priod + " OF CUSTOMER CODE " + customercode, 00);// view code 22 la can viet cogs

                        viewtbl.ShowDialog();
                        //    viewtbl.Focus();


                    }

                    #endregion

                }





            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();

                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;
                bool chon = kaPriodpicker.kq;
                if (chon)
                {

                    if (priod != "")
                    {
                        string connection_string = Utils.getConnectionstr();

                        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                        db.ExecuteCommand("update  tbl_kasales  SET Cogs = null where tbl_kasales.Priod = '" + priod + "'");
                        db.SubmitChanges();

                        MessageBox.Show("Delete Cogs of Priod " + priod + " Done !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

            }
        }
    }
}
