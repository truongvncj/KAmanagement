
using KAmanagement.Control;
using KAmanagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace KAmanagement.View
{

    // public partial
    public partial class VInputchange : Form
    {


        public LinqtoSQLDataContext db { get; set; }
        //  public LinqtoSQLDataContext dc { get; set; }
        public string tblnamemain { get; set; }
        public string tblnamesub { get; set; }
        public string IDmain { get; set; }
        public IQueryable rs { get; set; }
        public string IDsub { get; set; }
        public System.Type Typeofftablemain { get; set; }

        public System.Type Typeofftablesub { get; set; }

        public BindingSource source1;
        public BindingSource source2;

        public string Username { get; set; }
        //public string username { get; set; }
        //public int codeinput { get; set; }

        void Control_KeyPress(object sender, KeyEventArgs e)
        {


            if (this.tblnamesub == "tbl_KaCustomer" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tblCustomered")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblCustomered");
                    sheaching.Show();
                }




            }


            // tbl_kacontractbegindatadetail

            if (this.tblnamesub == "tbl_kacontractsdatadetail" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tbl_kacontractsdatadetail")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tbl_kacontractsdatadetail");
                    sheaching.Show();
                }




            }

            //    tbl_kacontractbegindata

            if (this.tblnamesub == "tbl_kacontractbegindata" && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tbl_kacontractbegindata")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tbl_kacontractbegindata");
                    sheaching.Show();
                }




            }




        }

        public VInputchange(string lbheader, string lbsub, LinqtoSQLDataContext db, string tblnamemain, string tblnamesub, System.Type Typeofftablemain, System.Type Typeofftablsub, String IDmain, String IDsub, string Username)//;//, string username, int codeinput
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.Username = Username;

            this.btrigh.Visible = false;

            if (tblnamesub == "tbl_Temp")
            {
                this.btrigh.Visible = true;
            }

            this.lbseachedit.Visible = false;
            this.Bt_uploadbegin.Visible = false;
            // this.lbusername.Text = Utils.getusername();




            this.bnt_adddataselected.Visible = false;
            this.Bt_Adddata.Visible = true;
            if (lbheader == "")
            {
                //    this.p
                this.mainpanel.Hide();
                this.Bt_Adddata.Hide();
                this.splitContainer1.Panel2Collapsed = true;

            }


            if (lbsub == "LIST MASTER DATA CUSTOMER ")
            {
                this.lbseachedit.Visible = true;
            }


            if (tblnamemain == "tbl_CustomerneedLetter")
            {

                this.Bt_Adddata.Visible = false;

            }

            // lbseachedit
            if (tblnamemain == "tbl_kacontractbegindata" || tblnamemain == "tbl_kacontractsdatadetail")
            {

                this.lbseachedit.Visible = true;

            }



            this.db = db;
            this.tblnamemain = tblnamemain;
            this.tblnamesub = tblnamesub;
            this.Typeofftablemain = Typeofftablemain;
            this.Typeofftablesub = Typeofftablsub;
            //  this.tblnamesub = tblnamesub;

            this.IDmain = IDmain;
            this.IDsub = IDsub;

            this.lb_headermain.Text = lbheader;
            this.lb_headersub.Text = lbsub;


            string slqtext = "select * from " + tblnamemain;

            var results3 = db.ExecuteQuery(Typeofftablemain, slqtext);
            source2 = new BindingSource();
            //   TableAdapter = source2.tablead

            source2.DataSource = results3;

            this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

            this.dataGridView2.AllowUserToAddRows = true;



            if (this.dataGridView2.Columns[IDmain] != null)
            {
                //      this.dataGridView2.Columns[IDmain].Visible = false;
            }



            if (Username != "")
            {
                slqtext = "select *  from  " + tblnamesub + " where " + tblnamesub + ".Username ='" + Username + "'"; // EXCEPT (" + IDsub + ") 

            }
            else
            {
                slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 
            }




            var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
            source1 = new BindingSource();
            source1.DataSource = results2;
            source1.AllowNew = true;

            this.dataGridView1.DataSource = source1;
            //if (tblnamesub == "USERNAME AND PASSWORD CONFIG ! ")

            //{


            //    dataGridView1.Columns["username"].DisplayIndex = 2;


            //};


            //if (this.dataGridView1.Columns["Username"] != null)
            //{
            //    this.dataGridView1.Columns.Remove("Username");
            //    //  MessageBox.Show("ok");
            //}

            //    nếu daraa bàng không thì tao mọt bản gi mới và xem lại

            if (source1.Count == 0)
            {

                #region if tbl_kacontracttype null


                if (tblnamesub == "tbl_kacontracttype")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_kacontracttype in dc.tbl_kacontracttypes
                                       select tbl_kacontracttype;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_kacontracttype null


                #region if tbl_kacurrency null


                if (tblnamesub == "tbl_kacurrency")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_kacurrency in dc.tbl_kacurrencies
                                       select tbl_kacurrency;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_kacurrency null



                #region if tbl_Kafuctionlist null


                if (tblnamesub == "tbl_Kafuctionlist")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
                                       select tbl_Kafuctionlist;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_Kafuctionlist null


                #region if tbl_kaPrdgrp null


                if (tblnamesub == "tbl_kaPrdgrp")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_kaPrdgrp in dc.tbl_kaPrdgrps
                                       select tbl_kaPrdgrp;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_Kafuctionlist null


                // "tbl_Temp")
               
             

                #region if tbl_Temp null


                if (tblnamesub == "tbl_Temp")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_Temp in dc.tbl_Temps
                                       select tbl_Temp;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_Kafuctionlist null

                //      tbl_PaymentTerm


                #region if tbl_PaymentTerm null


                if (tblnamesub == "tbl_PaymentTerm")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_PaymentTerm in dc.tbl_PaymentTerms
                                       select tbl_PaymentTerm;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_PaymentTerm null


                #region if tbl_kaChannel null


                if (tblnamesub == "tbl_kaChannel")
                {

                    //       MessageBox.Show("ok !!!!!!!!");
                    string connection_string = Utils.getConnectionstr();
                    //      UpdateDatagridview
                    System.Data.DataTable dt = new System.Data.DataTable();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    var rsthisperiod = from tbl_kaChannel in dc.tbl_kaChannels
                                       select tbl_kaChannel;

                    Utils ut = new Utils();
                    dt = ut.ToDataTable(dc, rsthisperiod);

                    this.dataGridView1.DataSource = dt;


                }
                #endregion if tbl_PaymentTerm null




            }

            ///        tạo một bản gi mưới




            this.dataGridView1.AutoGenerateColumns = true;
            if (this.dataGridView1.Columns[IDsub] != null)
            {
                this.dataGridView1.Columns[IDsub].Visible = false;

            }

            dataGridView1.Update();
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;


         
        }



        public void Reloadeditcustomer(string text)
        {

            #region tbl_KaCustomer



            if (tblnamesub == "tbl_KaCustomer")
            {
                string slqtext = "select *  from   tbl_KaCustomer where  CONVERT(INT, tbl_KaCustomer.Customer) like '%" + text + "%'"; // EXCEPT (" + IDsub + ") 


                var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
                source1 = new BindingSource();
                source1.DataSource = results2;
                source1.AllowNew = true;

                //   IQueryable results2 = db.ExecuteQuery(Typeofftable, slqtext);
                //   this.rs = results2.AsQueryable();


                //    string slqtext2 = "select * from " + tblnamemain;

                //    IQueryable results3 = db.ExecuteQuery(Typeofftable, slqtext);


                this.dataGridView1.DataSource = source1;

                this.dataGridView1.AutoGenerateColumns = true;

                if (this.dataGridView1.Columns[IDsub] != null)
                {
                    this.dataGridView1.Columns[IDsub].Visible = false;
                    //   this.dataGridView1.Columns["Username"]. = false;
                }


                this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            #endregion


        }

        public void Reloadtbl_kacontractbegindata(string text)
        {

            #region tbl_KaCustomer

            //tbl_kacontractbegindata tbl = new tbl_kacontractbegindata();

            //tbl.Customer

            if (tblnamesub == "tbl_kacontractbegindata")
            {
                string slqtext = "select *  from   tbl_kacontractbegindata where  CONVERT(INT, tbl_kacontractbegindata.Customer) like '%" + text + "%'"; // EXCEPT (" + IDsub + ") 


                var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
                source1 = new BindingSource();
                source1.DataSource = results2;
                source1.AllowNew = true;

                //   IQueryable results2 = db.ExecuteQuery(Typeofftable, slqtext);
                //   this.rs = results2.AsQueryable();


                //    string slqtext2 = "select * from " + tblnamemain;

                //    IQueryable results3 = db.ExecuteQuery(Typeofftable, slqtext);


                this.dataGridView1.DataSource = source1;

                this.dataGridView1.AutoGenerateColumns = true;

                if (this.dataGridView1.Columns[IDsub] != null)
                {
                    this.dataGridView1.Columns[IDsub].Visible = false;
                    //   this.dataGridView1.Columns["Username"]. = false;
                }


                this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            #endregion


        }


        public void Reloadtbl_kacontractsdatadetail(string text)
        {

            #region tbl_KaCustomer

         

            if (tblnamesub == "tbl_kacontractsdatadetail")
            {
                string slqtext = "select *  from   tbl_kacontractsdatadetail where  CONVERT(INT, tbl_kacontractsdatadetail.Customercode) like '%" + text + "%'"; // EXCEPT (" + IDsub + ") 


                var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
                source1 = new BindingSource();
                source1.DataSource = results2;
                source1.AllowNew = true;

                //   IQueryable results2 = db.ExecuteQuery(Typeofftable, slqtext);
                //   this.rs = results2.AsQueryable();


                //    string slqtext2 = "select * from " + tblnamemain;

                //    IQueryable results3 = db.ExecuteQuery(Typeofftable, slqtext);


                this.dataGridView1.DataSource = source1;

                this.dataGridView1.AutoGenerateColumns = true;

                if (this.dataGridView1.Columns[IDsub] != null)
                {
                    this.dataGridView1.Columns[IDsub].Visible = false;
                    //   this.dataGridView1.Columns["Username"]. = false;
                }


                this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            #endregion


        }



        private void bt_updatedata_Click(object sender, EventArgs e)
        {


            #region // update datagridview to database    source1.EndEdit();

            #region   foreach (DataGridViewRow r in dataGridView1.Rows)


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[IDsub].Value != null)
                {


                    var indexvalue = int.Parse(r.Cells[IDsub].Value.ToString());
                    //      var kq = source1.Find(IDsub, indexvalue);

                    if (indexvalue == 0) //neewu co tron view khong co trong dataa == add vao dat ta
                    {
                        //var bk = new tblEDLP();

                        string stringfield = "";
                        //    string stringvalue = "";

                        int idculum = this.dataGridView1.ColumnCount;

                        for (int idculumid = 0; idculumid < idculum; idculumid++)
                        {
                            var colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;
                            var colname = this.dataGridView1.Columns[idculumid].HeaderText;

                            var valueid = r.Cells[colheadertext].Value;

                            if (valueid != null && colheadertext != IDsub)
                            {

                                var IDType = r.Cells[colheadertext].ValueType;

                                if (colheadertext.Contains("_"))
                                {
                                    colheadertext = colheadertext.Replace("_", " ");
                                    string temp = "[" + colheadertext + "]";
                                    colheadertext = temp;
                                }


                                if (IDType.ToString().Contains("String")|| IDType.ToString().Contains("Bool"))
                                {

                                    valueid = "'" + valueid + "'";
                                }



                                if (IDType.ToString().Contains("Date"))
                                {

                                    valueid = "'" + valueid + "'";
                                }

                                if (stringfield != "")
                                {

                                    stringfield = tblnamesub + "." + colname + " = " + valueid + "," + stringfield;

                                }
                                else
                                {
                                    stringfield = tblnamesub + "." + colname + " = " + valueid;


                                }

                                string StrQuery = "update " + tblnamesub +
                                    " set " + stringfield +
                                    " where " + tblnamesub + ".id =" + indexvalue; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";
                                try
                                {


                                    db.ExecuteCommand(StrQuery);
                                    db.SubmitChanges();
                                }
                                catch (Exception )
                                {
                                    MessageBox.Show(StrQuery);
                                    //this.dataGridView1.Rows[0].Cells["Status"].Value = ex.ToString();
                                }






                            }




                        }


                        //                  update tbl_FreGlass
                        //  set tbl_FreGlass.CUSTOMERgroupcode = Rtrim(cast((convert(int, tbl_CustomerGroup.Customergropcode)) as varchar(50))) + right(tbl_FreGlass.SALORG, 2)

                        //  from tbl_FreGlass, tbl_CustomerGroup
                        //  where tbl_FreGlass.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
                        //and tbl_FreGlass.CUSTOMER = tbl_CustomerGroup.Customercode







                    }





                }



            }
            #endregion foreach



            #endregion//update datagridview to database

            //try
            //{
            //    db.SubmitChanges();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.ToString(), "Please Check !");

            //    return;
            //}    












            #region        // insert cac dong  khong co trong gridview khong co cos tron data


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[IDsub].Value != null)
                {


                    var indexvalue = int.Parse(r.Cells[IDsub].Value.ToString());
                    //      var kq = source1.Find(IDsub, indexvalue);

                    if (indexvalue == 0) //neewu co tron view khong co trong dataa == add vao dat ta
                    {
                        //var bk = new tblEDLP();

                        string stringfield = "";
                        string stringvalue = "";

                        int idculum = this.dataGridView1.ColumnCount;

                        for (int idculumid = 0; idculumid < idculum; idculumid++)
                        {
                            var colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;
                            var colname = this.dataGridView1.Columns[idculumid].Name;

                            var valueid = r.Cells[colheadertext].Value;

                            if (valueid != null && colheadertext != IDsub)
                            {

                                var IDType = r.Cells[colheadertext].ValueType;

                                if (colheadertext.Contains("_"))
                                {
                                    colheadertext = colheadertext.Replace("_", " ");
                                    string temp = "[" + colheadertext + "]";
                                    colheadertext = temp;
                                }


                                if (IDType.ToString().Contains("String") || IDType.ToString().Contains("Bool"))
                                {

                                    valueid = "'" + valueid + "'";
                                }



                                if (IDType.ToString().Contains("Date"))
                                {

                                    valueid = "'" + valueid + "'";
                                }
                                
                                if (IDType.ToString().Contains("bool"))
                                {

                                    valueid = "'" + valueid + "'";
                                }

                                if (stringvalue != "")
                                {

                                    stringvalue = stringvalue + "," + valueid;
                                    stringfield = stringfield + "," + colheadertext;

                                }
                                else
                                {
                                    stringvalue = stringvalue + valueid;

                                    stringfield = stringfield + colname;

                                }



                            }




                        }



                        string StrQuery = "INSERT INTO " + tblnamesub + " ( " + stringfield + " ) VALUES (" + stringvalue + ")"; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";
                        try
                        {


                            db.ExecuteCommand(StrQuery);
                            db.SubmitChanges();
                        }
                        catch (Exception )
                        {

                            MessageBox.Show(StrQuery);
                        }



                        //MessageBox.Show(StrQuery, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }





                }



            }
            #endregion foreach



            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Please Check !");
            }


            // view lại
            //   string slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 
            string slqtext = "";
            if (Username != "")
            {
                slqtext = "select *  from  " + tblnamesub + " where " + tblnamesub + ".Username ='" + Username + "'"; // EXCEPT (" + IDsub + ")   
            }
            else
            {
                slqtext = "select *  from  " + tblnamesub;// + " where " + tblnamesub + ".Username ='" + Username + "'"; // EXCEPT (" + IDsub + ") 
            }

            var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
            source1.DataSource = results2;
            this.dataGridView1.DataSource = source1;
            // view lại
            MessageBox.Show("Data update done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }



        private void Bt_Deleteddata_Click(object sender, EventArgs e)
        {

            var select = dataGridView1.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView1.Rows[select2.Index].Cells[IDsub].Value.ToString());


                    var slqtext = "delete  from  " + tblnamesub + " where " + tblnamesub + "." + IDsub + " = " + gridviewid;
                    try
                    {
                        db.ExecuteCommand(slqtext);
                        db.SubmitChanges();
                    }
                    catch (Exception)
                    {


                        //  /     //   throw;
                    }



                    this.dataGridView1.Rows.Remove(select2);
                    //  db.SubmitChanges();
                }

            }

            dataGridView1.Refresh();
            //      dataGridView1.UserDeletedRow;

            //   dataGridView1.RowsRemoved();





            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);






        }

        private void Bt_Adddata_Click(object sender, EventArgs e)
        {


            string slqtext2 = "select * from " + tblnamemain;

            var results = db.ExecuteQuery(Typeofftablemain, slqtext2);

            source2.DataSource = results;


            this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

            this.dataGridView2.AllowUserToAddRows = true;



            string fieldtblemain = "";
            string colheadertext = "";
            int idculum = this.dataGridView1.ColumnCount;

            for (int idculumid = 0; idculumid < idculum; idculumid++)
            {


                colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;

                if (colheadertext.Contains("_"))
                {
                    colheadertext = colheadertext.Replace("_", " ");
                    string temp = "[" + colheadertext + "]";
                    colheadertext = temp;
                }



                if (colheadertext != IDsub && colheadertext != "Status" && colheadertext != "Username")
                {
                    if (fieldtblemain == "")
                    {
                        fieldtblemain = fieldtblemain + colheadertext;
                    }
                    else
                    {
                        fieldtblemain = fieldtblemain + "," + colheadertext;

                    }




                }



            }





            string slqtext = "insert into " + tblnamemain + " ( " + fieldtblemain + ") select  " + fieldtblemain + " from  " + tblnamesub;
            // MessageBox.Show(slqtext);
            bool kq = true;

            try
            {
                int result = db.ExecuteCommand(slqtext);
                //    db.SubmitChanges();
                //  MessageBox.Show(result.ToString());
                if (result < 0)
                {
                    MessageBox.Show("Không update vào được, please check !");
                    return;

                }



            }
            catch (Exception ex)
            {
                // this.dataGridView1.Rows[0].Cells["Status"].Value = ex.ToString();
                MessageBox.Show(ex.ToString());
                kq = false;
            }

            // doij cho xuwr ly xong




            // doi cho xu ly xong

            slqtext2 = "select * from " + tblnamemain;

            var results3 = db.ExecuteQuery(Typeofftablemain, slqtext2);

            //    source2.DataSource = null;

            source2.DataSource = results3;



            this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

            this.dataGridView2.AllowUserToAddRows = true;

            if (kq)
            {
                MessageBox.Show("Add data Done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


           //     string connection_string = Utils.getConnectionstr();
             //   var db = new LinqtoSQLDataContext(connection_string);
                string username = Utils.getusername();
              
                db.ExecuteCommand("DELETE FROM " + tblnamesub + " where " + tblnamesub + ".Username = '" + username + "'");
              
                db.SubmitChanges();


                //        string slqtext = "";
                if (Username != "")
                {
                    slqtext = "select *  from  " + tblnamesub + " where " + tblnamesub + ".Username ='" + Username + "'"; // EXCEPT (" + IDsub + ")   
                }
                else
                {
                    slqtext = "select *  from  " + tblnamesub;// + " where " + tblnamesub + ".Username ='" + Username + "'"; // EXCEPT (" + IDsub + ") 
                }

                var results2 = db.ExecuteQuery(Typeofftablesub, slqtext);
                source1.DataSource = results2;
                this.dataGridView1.DataSource = source1;




            }



            // dataGridView2.Refresh();

            // }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bt_detletedsetlectmain_Click(object sender, EventArgs e)
        {
            var select = dataGridView2.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView2.Rows[select2.Index].Cells[IDsub].Value.ToString());


                    var slqtext = "delete  from  " + tblnamemain + " where " + tblnamemain + "." + IDmain + " = " + gridviewid;
                    try
                    {
                        db.ExecuteCommand(slqtext);
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {


                        MessageBox.Show(ex.ToString());
                    }



                    slqtext = "select * from " + tblnamemain;

                    var results = db.ExecuteQuery(Typeofftablemain, slqtext);

                    source2.DataSource = results;


                    this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

                    this.dataGridView2.AllowUserToAddRows = true;
                }

            }

            dataGridView2.Refresh();
            //      dataGridView1.UserDeletedRow;

            //   dataGridView1.RowsRemoved();





            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }


        //private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)

        //    if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))

        //    {

        //        //  source1.EndEdit();

        //        //     db.SubmitChanges();




        //        char[] rowSplitter = { '\r', '\n' };

        //        char[] columnSplitter = { '\t' };

        //        //get the text from clipboard

        //        IDataObject dataInClipboard = Clipboard.GetDataObject();

        //        string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

        //        //split it into lines

        //        string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

        //        //get the row and column of selected cell in grid

        //        int r = dataGridView1.SelectedCells[0].RowIndex;

        //        int c = dataGridView1.SelectedCells[0].ColumnIndex;

        //        //add rows into grid to fit clipboard lines

        //        if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))

        //        {

        //            ////   uodate trước đã

        //            //source1.EndEdit();

        //            //db.SubmitChanges();

        //            ////// view lại
        //            ////string sql3 = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 
        //            //var rge = db.ExecuteQuery(Typeofftable, sql3);
        //            //source1.DataSource = rge;
        //            //this.dataGridView1.DataSource = source1;

        //            //uupdate news row trước đã


        //            for (int i = 0; i < r + rowsInClipboard.Length - dataGridView1.Rows.Count + 1; i++)
        //            {

        //                //    #region //   // add new row in datagridvidw by inserinto data base black data
        //                //    string stringfield = "";
        //                //    string stringvalue = "";

        //                //    //   int idculum = this.dataGridView1.ColumnCount;

        //                //    //   for (int idculumid = 0; idculumid < idculum - 1; idculumid++)
        //                //    //    {
        //                //    var colheadertext = this.dataGridView1.Columns[0].HeaderText;


        //                //    var valueid = dataGridView1.Rows[0].Cells[colheadertext].Value;

        //                //    if (valueid != null && colheadertext != IDsub)
        //                //    {

        //                //        var IDType = dataGridView1.Rows[0].Cells[colheadertext].ValueType;

        //                //        if (colheadertext.Contains("_"))
        //                //        {
        //                //            colheadertext = colheadertext.Replace("_", " ");
        //                //            string temp = "[" + colheadertext + "]";
        //                //            colheadertext = temp;
        //                //        }


        //                //        if (IDType.ToString().Contains("String"))
        //                //        {

        //                //            valueid = "'" + " " + "'";
        //                //        }
        //                //        else
        //                //        {
        //                //            if (IDType.ToString().Contains("Date"))
        //                //            {

        //                //                valueid = "'" + "" + "'";
        //                //            }
        //                //            else
        //                //            {
        //                //                valueid = "0";
        //                //            }
        //                //        }

        //                //        if (stringvalue != "")
        //                //        {

        //                //            stringvalue = stringvalue + "," + valueid;
        //                //            stringfield = stringfield + "," + colheadertext;

        //                //        }
        //                //        else
        //                //        {
        //                //            stringvalue = stringvalue + valueid;

        //                //            stringfield = stringfield + colheadertext;

        //                //        }



        //                //    }






        //                //    string StrQuery = "INSERT INTO " + tblnamesub + " ( " + stringfield + " ) VALUES (" + stringvalue + ")"; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";
        //                //    try
        //                //    {


        //                //        var results3 = db.ExecuteQuery(Typeofftable, StrQuery);
        //                //    }
        //                //    catch //(Exception)
        //                //    {

        //                //        //   throw;
        //                //    }


        //                //}


        //                //#endregion//


        //                //    }


        //                //string slqtext = "select *  from  " + tblnamesub; // EXCEPT (" + IDsub + ") 


        //                //var results2 = db.ExecuteQuery(Typeofftable, slqtext);

        //                //source1.DataSource = results2;
        //                //dataGridView1.Refresh();

        //                // loop through the lines, split them into cells and place the values in the corresponding cell.

        //                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)

        //                {

        //                    //split row into cell values

        //                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

        //                    //cycle through cell values

        //                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)

        //                    {

        //                        //assign cell value, only if it within columns of the grid

        //                        if (dataGridView1.ColumnCount - 1 >= c + iCol)

        //                        {

        //                            dataGridView1.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];


        //                        }

        //                    }

        //                }

        //            }
        //        }

        //    }
        //    }
        //  customerBegibalancelist





        private void Updatechange_Click_1(object sender, EventArgs e)
        {




        }

        private void bt_detletedsetlectmain_Click_1(object sender, EventArgs e)
        {

            var select = dataGridView2.SelectedRows;

            foreach (var item in select)
            {
                DataGridViewRow select2 = (DataGridViewRow)item;
                if (!select2.IsNewRow)
                {

                    //  select2.ind

                    var gridviewid = int.Parse(dataGridView2.Rows[select2.Index].Cells[IDmain].Value.ToString());


                    string slqtext = "delete  from  " + tblnamemain + " where " + tblnamemain + "." + IDmain + " = " + gridviewid;
                    try
                    {
                        //  MessageBox.Show(slqtext);

                        db.ExecuteCommand(slqtext);
                        db.SubmitChanges();
                        //db.SubmitChanges();






                    }
                    catch (Exception ex)
                    {


                        MessageBox.Show(ex.ToString());
                    }






                }



            }
            MessageBox.Show("Data deleted done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string slqtext2 = "select * from " + tblnamemain;

            var results = db.ExecuteQuery(Typeofftablemain, slqtext2);

            source2.DataSource = results;


            this.dataGridView2.DataSource = source2;  // view 2 la main view 1 detaik

            this.dataGridView2.AllowUserToAddRows = true;

        }

        private void Bt_uploadbegin_Click(object sender, EventArgs e)
        {

            //     customerinput_ctrl md = new customerinput_ctrl();
            //     string connection_string = Utils.getConnectionstr();

            ////     md.customerBegibalancelist();

            //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     var rs = from tblFBL5beginbalace in db.tblFBL5beginbalaces

            //              select tblFBL5beginbalace;

            //     this.dataGridView1.DataSource = rs;
            //     this.db = db;

            //     //    this.rs = rs;













        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (this.tblnamesub == "tbl_kaProductlistemp")
            {
                var rs = from tbl_kaProductlistemp in db.tbl_kaProductlistemps
                         select tbl_kaProductlistemp;
                this.rs = rs;

            }

            if (this.tblnamesub == "tbl_KaCustomertemp")
            {
                var rs = from tblCustomerTmp in db.tbl_KaCustomertemps
                         select tblCustomerTmp;
                this.rs = rs;

            }

            //if (this.tblnamesub == "tblFBL5beginbalaceTemp")
            //{
            //    var rs = from tblFBL5beginbalaceTemp in db.tbl_be
            //             select tblFBL5beginbalaceTemp;
            //    this.rs = rs;

            //}

            //if (this.tblnamesub == "tbl_kaCustomerGroupTemp")
            //{
            //    var rs = from tbl_kaCustomerGroupTemp in db.tbl_kaCustomerGroupTemps
            //             select tbl_kaCustomerGroupTemp;
            //    this.rs = rs;

            //}


            //if (this.tblnamesub == "tbl_Comboundtemp")
            //{
            //    var rs = from tbl_Comboundtemp in db.tbl_Comboundtemps
            //             select tbl_Comboundtemp;
            //    this.rs = rs;

            //}


            if (this.tblnamesub == "tbl_KaCustomer")
            {
                var rs = from tbl_KaCustomer in db.tbl_KaCustomers
                         select tbl_KaCustomer;
                this.rs = rs;

            }

            if (this.tblnamesub == "tbl_kaProductlist")
            {
                var rs = from tbl_kaProductlist in db.tbl_kaProductlists
                         select tbl_kaProductlist;
                this.rs = rs;

            }
            if (this.tblnamesub == "tbl_kacontractbegindata")
            {
                var rs = from tblFBL5beginbalace in db.tbl_kacontractbegindatas
                         select tblFBL5beginbalace;
                this.rs = rs;

            }





            if (this.rs != null)
            {
                Control_ac ctrex = new Control_ac();


                ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);
            }
            //else
            //{


            //}



        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (lbsub == "Update Customer make reports !" && e.KeyCode == Keys.F3)
            //{





            //    FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //    bool kq = false;
            //    foreach (Form frm in fc)
            //    {
            //        if (frm.Text == "Seachcode")
            //        {
            //            kq = true;
            //            frm.Focus();

            //        }
            //    }

            //    if (!kq)
            //    {
            //        Seachcode sheaching = new Seachcode(this, "tblCustomered");
            //        sheaching.Show();
            //    }
            //}
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {


            View.kAuserRightsetup userset = new kAuserRightsetup();

            userset.ShowDialog();



        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);
        //    // var rs = from tbl_Remark in db.tbl_Remarks
        //    //            select tbl_Remark;


        //    //IQueryable querydata = db.("select * FROM " + tblnamesub);
        //    ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    //db.SubmitChanges();


        //    //MethodInfo mi = typeof(Queryable).GetMethod("AsQueryable", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(IEnumerable<tblnamesub>) }, null);
        //    //Expression buff = Expression.Call(mi, new[] { collection });
        //    //Expression final = Expression.Convert(buff, typeof(IQueryable<RelatedEntity>));






        //}




    }
}
