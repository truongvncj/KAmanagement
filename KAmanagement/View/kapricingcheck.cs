using KAmanagement.Control;
using KAmanagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class kapricingcheck : Form
    {

        public static string connection_string1 = Utils.getConnectionstr();
        public LinqtoSQLDataContext db = new LinqtoSQLDataContext(kapricingcheck.connection_string1);
        public IQueryable rs { get; set; }
        public IQueryable rs2 { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }



        //public void customercomboundadd(List<ComboboxItem> CombomCollection3)
        //{
        //    cbcustomercode.DataSource = CombomCollection3;
        //    //cbcustomercode.DropDownWidth = 500;
        //    this.lbkey.Text = "B";
        //    this.groupBox2.Visible = true;
        //}

        //public delegate void customercomboundaddcall(List<ComboboxItem> CombomCollection3);



        //public void updacustomercb() { 


        //#region  cobound cbcustomercode
        //string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    //     CombomCollection = null;

        //   List<ComboboxItem> CombomCollection3 = new List<ComboboxItem>();
        //    var rscust = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
        //                 orderby tbl_ka_prCustomer.Customer
        //                 select tbl_ka_prCustomer;
        //    foreach (var item in rscust)
        //    {
        //        ComboboxItem cb = new ComboboxItem();
        //        cb.Value = item.Customer;
        //        cb.Text = item.Customer + ": " + item.Name_1;// + "- Exp : " + item.Example;
        //        CombomCollection3.Add(cb);



        //    }

        //    //this.lb_bilingqtt.Invoke(new UpdateTextCallback(this.UpdateText),
        //    //                             new object[] { Billed_Qty.ToString(), Cond_Value.ToString(), UC.ToString(), PC.ToString(), Net_value.ToString() });

        //    this.cbcustomercode.Invoke(new customercomboundaddcall(this.customercomboundadd),
        //                              new object[] { CombomCollection3 });



        // //   customercomboundaddcall(CombomCollection3);

        //    #endregion


        //}


        public kapricingcheck()
        {
            InitializeComponent();

            this.rs = null;
            this.rs2 = null;
            dataGridView1.DataSource = rs;

            //       groupBox7.Visible = false;
            //      splitContainer1.Visible = false;


            #region load comboubnd region

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //  CombomCollection = null;
            //   List<ComboboxItem> CombomCollection = new List<ComboboxItem>();

            var rs2 = from tbl_karegion in dc.tbl_karegions
                      orderby tbl_karegion.Region
                      select tbl_karegion.Region;
            //     cbregion3.DataSource = rs2;
            foreach (var item in rs2)
            {
                cbregion3.Items.Add(item);

                cbregion2.Items.Add(item);
                cbregion1.Items.Add(item);
                cbregion4.Items.Add(item);
            }
            //      cbregion1.Text = "VN12";
            //       cbregion2.Text = "VN12";
            //     cbregion3.Text = "VN12";
            #endregion

            cbcustomercode.DropDownStyle = ComboBoxStyle.Simple;



            Model.Username used = new Username();

            if (used.pricingcheckupdate)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }

            //if (Utils.getrightnumber() != 7)
            //{
            //    groupBox1.Visible = false;
            //}

            //if (Utils.getrightnumber() == 1 || Utils.getrightnumber() == 6 || Utils.getrightnumber() == 2)
            //{
            //    groupBox1.Visible = true;
            //}

            //#endregion



            #region   //       cbkeyaccount

            var rskeyaccount = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                               group tbl_ka_prCustomer by tbl_ka_prCustomer.KeyAccount into g

                               select g.Key;
            //     cbregion3.DataSource = rs2;
            foreach (var item in rskeyaccount)
            {
                cbkeyaccount.Items.Add(item);
                cbkeyaccount2.Items.Add(item);
                keyaccountcb.Items.Add(item);
                // cbregion1.Items.Add(item);
            }
            //      cbkeyaccount.Text = "90104";
            //      cbkeyaccount2.Text = "90104";
            // cbkeyaccount.DataSource = rskeyaccount;


            #endregion



            #region//   cbkeyaccount2
            var Salediss3 = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                            group tbl_ka_prCustomer by tbl_ka_prCustomer.Salesdistrict into g

                            select g.Key;

            foreach (var item in Salediss3)
            {
                cbsalesdis.Items.Add(item);
                cbsalesdic.Items.Add(item);
                // cbregion1.Items.Add(item);
            }
            //    cbsalesdis.Text = "V12AA";
            //  cbkeyaccount2.Items.Add(item);

            #endregion


            #region//   pricelist
            var pricelist = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                            group tbl_ka_prCustomer by tbl_ka_prCustomer.PriceList into g

                            select g.Key;

            foreach (var item in pricelist)
            {
                cbpricelist.Items.Add(item);

                cbpricelis2.Items.Add(item);
                cbcplist.Items.Add(item);
            }
            //     cbpricelis2.Text = "V2";
            // cbregion1.Items.Add(item);
            //    cbpricelist.Text = "V2";

            #endregion

            //  txtproduct
            #region//   pricelist

          //  CombomCollection = null;
           // List<ComboboxItem> CombomCollection = new List<ComboboxItem>();

            var txtproductlist = from tbl_kaProductlist in dc.tbl_kaProductlists
                         //    group tbl_ka_prCustomer by tbl_ka_prCustomer.PriceList into g
                         orderby tbl_kaProductlist.MatNumber

                                 select tbl_kaProductlist;

            foreach (var item in txtproductlist)
            {
               
                ComboboxItem cust = new ComboboxItem();
                cust.Value = item.MatNumber;
                cust.Text = item.MatNumber + " : " + item.MatText;
                        txtproduct.Items.Add(cust);
            }
            txtproduct.DropDownWidth = 250;
            //     cbpricelis2.Text = "V2";
            // cbregion1.Items.Add(item);
            //    cbpricelist.Text = "V2";

            #endregion

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox1.Text != "")
            {

                string programe = comboBox1.Text.ToString();
                Control.PriceCheck.BAseprice bas = new Control.PriceCheck.BAseprice();
                bas.inputpromotionpricelist(programe);


            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {






        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        class datainportPriceF
        {

            public double customer { get; set; }
            public string region { get; set; }
            public DateTime dateprice { get; set; }
            public double keyaccount { get; set; }
            public string pricelistid { get; set; }

            public string saledistrict { get; set; }
            public string username { get; set; }
            public string product { get; set; }
        }


        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        public void PricemakeOfcustomer(object obj)
        {

            datainportPriceF inf = (datainportPriceF)obj;

            double customer = inf.customer;
            DateTime dateprice = inf.dateprice;
            string region = inf.region;



            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("ka_makepriceforonecodeforcheck2", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@customer", SqlDbType.Float).Value = customer;
                cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = region;
                cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
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

            #endregion




        }


        private void button5_Click(object sender, EventArgs e)
        {
            double Cust = 0;
            if (cbcustomercode.Text != "" && Utils.IsValidnumber(cbcustomercode.Text) && cbregion1.Text != "")
            {

                // ---- tinh
                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                dc.ExecuteCommand("DELETE FROM tbl_PriceRptCustomer");
                //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                dc.CommandTimeout = 0;
                dc.SubmitChanges();

                //         string filename = theDialog.FileName.ToString();
                Cust = double.Parse(cbcustomercode.Text.Trim());
                string region = cbregion1.Text.ToString().Trim();
                DateTime dateprice = datePrice.Value;
                // input dat at

                Thread t1 = new Thread(PricemakeOfcustomer);
                t1.IsBackground = true;
                t1.Start(new datainportPriceF() { customer = Cust, region = region, dateprice = dateprice });

                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1991);
                    t2.Abort();

                }


                #region hhieenr thi



                //  string regionchoi = cbregion1.Text;

                //     string connection_string = Utils.getConnectionstr();
                //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rscustemp2 = from tbl_PriceRptCustomer in dc.tbl_PriceRptCustomers
                                 where tbl_PriceRptCustomer.Customer == Cust && region == tbl_PriceRptCustomer.Region
                                 select new
                                 {
                                     tbl_PriceRptCustomer.Region,
                                     tbl_PriceRptCustomer.Customer,
                                     tbl_PriceRptCustomer.KeyAccount,
                                     tbl_PriceRptCustomer.SalesDistrict,
                                     tbl_PriceRptCustomer.MatNumber,
                                     tbl_PriceRptCustomer.MatText,
                                     Base_Price = tbl_PriceRptCustomer.BasePrice,
                                     Function_Discount = tbl_PriceRptCustomer.FuctionDiscountY1,
                                     Promotion_Discount = tbl_PriceRptCustomer.PromotionDiscountY2,
                                     Surcharge_Discount = tbl_PriceRptCustomer.SurchargeDiscountY3,
                                     Net_Price = tbl_PriceRptCustomer.NetPrice

                                 };// tbl_PriceRptCustomer;
                if (rscustemp2.Count() > 0)
                {
                    Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRICE OF CUSTOMER: " + ((int)Cust).ToString() + "   ON DATE: " + datePrice.Value.ToShortDateString(), 3);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check customer: " + cbcustomercode.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion


            }
            else
            {
                MessageBox.Show("Please slect full condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_KAbaseprice in dc.tbl_KAbaseprices


                             select tbl_KAbaseprice;
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST BASE PRICE", 3);// view code 1 la can viet them lenh

            viewtbl.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rscustemp2 = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers


                             select tbl_ka_prCustomer;
            Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST CUSTOMER FROM ZNKA1", 3);// view code 1 la can viet them lenh

            viewtbl.ShowDialog();
        }


        public void PricemakeOfkeyacountandregion(object obj)
        {

            datainportPriceF inf = (datainportPriceF)obj;

            //   double customer = inf.customer;
            DateTime dateprice = inf.dateprice;
            string region = inf.region;
            double keyaccount = inf.keyaccount;
            string pricelistid = inf.pricelistid;


            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("ka_makepriceforoneKeyaccountforcheck", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@pricelistid", SqlDbType.NVarChar).Value = pricelistid;
                cmd1.Parameters.Add("@keyaccount", SqlDbType.Float).Value = keyaccount;
                cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = region;
                cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
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

            #endregion







        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            //cbkeyaccount
            //  double Cust = 0;
            string pricelistid = "";
            if (cbpricelist.Text != "" && cbkeyaccount.Text != "" && cbregion2.Text != "")
            {
                pricelistid = cbpricelist.Text.Trim();
                double keyaccount = double.Parse(cbkeyaccount.Text.ToString());
                string region = cbregion2.Text.ToString().Trim();
                DateTime dateprice = datePrice.Value;
                string connection_string = Utils.getConnectionstr();
                //  string pricelistid = 
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                dc.ExecuteCommand("DELETE FROM tbl_PriceRptCustomer");
                //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                dc.CommandTimeout = 0;
                dc.SubmitChanges();



                Thread t1 = new Thread(PricemakeOfkeyacountandregion);
                t1.IsBackground = true;
                t1.Start(new datainportPriceF() { pricelistid = pricelistid, region = region, dateprice = dateprice, keyaccount = keyaccount });

                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1991);
                    t2.Abort();
                }





                #region hhieenr thi


                pricelistid = cbpricelist.Text;


                string regionchoi = cbregion2.Text;

                //     string connection_string = Utils.getConnectionstr();
                //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rscustemp2 = from tbl_PriceRptCustomer in dc.tbl_PriceRptCustomers
                                 where tbl_PriceRptCustomer.PriceList.Trim() == pricelistid.Trim() && regionchoi.Trim() == tbl_PriceRptCustomer.Region.Trim()
                                 select new
                                 {
                                     tbl_PriceRptCustomer.Region,
                                     tbl_PriceRptCustomer.PriceList,
                                     tbl_PriceRptCustomer.KeyAccount,
                                     //    tbl_PriceRptCustomer.SalesDistrict,
                                     tbl_PriceRptCustomer.MatNumber,
                                     tbl_PriceRptCustomer.MatText,
                                     Base_Price = tbl_PriceRptCustomer.BasePrice,
                                     Function_Discount = tbl_PriceRptCustomer.FuctionDiscountY1,
                                     Promotion_Discount = tbl_PriceRptCustomer.PromotionDiscountY2,
                                     Surcharge_Discount = tbl_PriceRptCustomer.SurchargeDiscountY3,
                                     Net_Price = tbl_PriceRptCustomer.NetPrice

                                 };// tbl_PriceRptCustomer;
                if (rscustemp2.Count() > 0)
                {
                    Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRICE OF : " + cbpricelist.Text + "  KEYACCOUNT: " + keyaccount.ToString() + "   ON DATE: " + datePrice.Value.ToShortDateString(), 3);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

            }
            else
            {
                MessageBox.Show("Please slect full condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control.PriceCheck.BAseprice bas = new Control.PriceCheck.BAseprice();
            bas.inputbasepricelist();







        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != null && comboBox1.Text != "")
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                string programid = comboBox1.Text.Trim();
                var rscustemp2 = from tbl_KApromotinprice in dc.tbl_KApromotinprices
                                 where tbl_KApromotinprice.programId.Trim() == programid
                                 select tbl_KApromotinprice;
                Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST FUNCTION AND PROMOTION DISCOUNT PRICE: " + programid, 3);// view code 1 la can viet them lenh

                viewtbl.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please check Fuction List !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateprcustfrompricecust()
        {


            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("updateprcustfrompricecust", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //cmd1.Parameters.Add("@pricelistid", SqlDbType.NVarChar).Value = pricelistid;
                //cmd1.Parameters.Add("@saledistrict", SqlDbType.NVarChar).Value = saledistric;
                //cmd1.Parameters.Add("@keyaccount", SqlDbType.Float).Value = keyaccount;
                //cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = region;
                //cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
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

            #endregion






        }

        private void btuploadCust_Click(object sender, EventArgs e)
        {
            customerinput_ctrl udatecust = new customerinput_ctrl();
            udatecust.customerinputpriceingupdate();

            Thread t1 = new Thread(updateprcustfrompricecust);
            t1.IsBackground = true;
            t1.Start();



        }

        private void cbcustomercode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = cbcustomercode.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                             where ((int)tbl_ka_prCustomer.Customer).ToString().Contains(valueinput)
                             select new
                             {
                                 Region = tbl_ka_prCustomer.SalesOrg,
                                 tbl_ka_prCustomer.Customer,
                                 tbl_ka_prCustomer.Name,
                                 tbl_ka_prCustomer.PriceList,
                                 tbl_ka_prCustomer.KeyAccount,
                                 tbl_ka_prCustomer.Salesdistrict,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                double codetempid = double.Parse(codetemp);

                string region = viewtb.region;

                if (codetemp != "0" && codetemp != null)
                {
                    cbcustomercode.Text = codetemp;

                    //cbregion1.SelectedItem = c

                    cbregion1.Text = region;
                    lbNAme.Text = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                                   where tbl_ka_prCustomer.Customer == codetempid
                                   select tbl_ka_prCustomer.Name).FirstOrDefault();


                }
                else
                {


                }



            }




        }


        public void PricemakeOfkeyacountsaledistric(object obj)
        {

            datainportPriceF inf = (datainportPriceF)obj;

            //   double customer = inf.customer;
            DateTime dateprice = inf.dateprice;
            string region = inf.region;
            double keyaccount = inf.keyaccount;
            string pricelistid = inf.pricelistid;
            string saledistric = inf.saledistrict;



            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("ka_makepriceforoneSalesdistrictforcheck", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@pricelistid", SqlDbType.NVarChar).Value = pricelistid;
                cmd1.Parameters.Add("@saledistrict", SqlDbType.NVarChar).Value = saledistric;
                cmd1.Parameters.Add("@keyaccount", SqlDbType.Float).Value = keyaccount;
                cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = region;
                cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
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

            #endregion







        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            //  double Cust = 0;
            //     string pricelistid = "";
            //     string saledistrict = "";
            if (cbpricelis2.Text != "" && cbregion3.Text != "" && cbsalesdis.Text != "" && cbkeyaccount2.Text != "")
            {
                string pricelistid = cbpricelis2.Text.Trim();
                string saledistrict = cbsalesdis.Text.Trim();
                string region = cbregion3.Text.Trim();
                DateTime dateprice = datePrice.Value;
                double keyaccount = double.Parse(cbkeyaccount2.Text.ToString());


                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                dc.ExecuteCommand("DELETE FROM tbl_PriceRptCustomer");
                //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                dc.CommandTimeout = 0;
                dc.SubmitChanges();



                Thread t1 = new Thread(PricemakeOfkeyacountsaledistric);
                t1.IsBackground = true;
                t1.Start(new datainportPriceF() { pricelistid = pricelistid, region = region, dateprice = dateprice, keyaccount = keyaccount, saledistrict = saledistrict });

                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1991);
                    t2.Abort();
                }






                #region hhieenr thi


                pricelistid = cbpricelis2.Text;


                string regionchoi = cbregion3.Text;

                //     string connection_string = Utils.getConnectionstr();
                //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                var rscustemp2 = from tbl_PriceRptCustomer in dc.tbl_PriceRptCustomers
                                 where tbl_PriceRptCustomer.PriceList.Trim() == pricelistid.Trim() && regionchoi.Trim() == tbl_PriceRptCustomer.Region.Trim()
                                 select new
                                 {
                                     tbl_PriceRptCustomer.Region,
                                     tbl_PriceRptCustomer.PriceList,
                                     tbl_PriceRptCustomer.KeyAccount,
                                     tbl_PriceRptCustomer.SalesDistrict,
                                     tbl_PriceRptCustomer.MatNumber,
                                     tbl_PriceRptCustomer.MatText,
                                     Base_Price = tbl_PriceRptCustomer.BasePrice,
                                     Function_Discount = tbl_PriceRptCustomer.FuctionDiscountY1,
                                     Promotion_Discount = tbl_PriceRptCustomer.PromotionDiscountY2,
                                     Surcharge_Discount = tbl_PriceRptCustomer.SurchargeDiscountY3,
                                     Net_Price = tbl_PriceRptCustomer.NetPrice

                                 };// tbl_PriceRptCustomer;
                if (rscustemp2.Count() > 0)
                {
                    Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRICE OF : " + pricelistid + " KEYACCOUNT :" + keyaccount.ToString() + " SALES DISTRICT : " + saledistrict + "   ON DATE: " + datePrice.Value.ToShortDateString(), 3);// view code 1 la can viet them lenh

                    viewtbl.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

            }
            else
            {
                MessageBox.Show("Please slect full condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }












        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DateTime dateprice = datePrice.Value;
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //dc.ExecuteCommand("DELETE FROM tbl_PriceRptCustomer");
            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.CommandTimeout = 0;
            //dc.SubmitChanges();

            //#region convert PaymentinforContract begin to 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            //try
            //{

            //    conn2 = new SqlConnection(destConnString);
            //    conn2.Open();
            //    SqlCommand cmd1 = new SqlCommand("ka_makepriceforAllcodeforcheck", conn2);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //  //  cmd1.Parameters.Add("@customer", SqlDbType.Float).Value = double.Parse(cbcustomercode.Text);
            //    //cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = cbregion1.Text;
            //    cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
            //    cmd1.CommandTimeout = 0;
            //    rdr1 = cmd1.ExecuteReader();



            //    //       rdr1 = cmd1.ExecuteReader();

            //}
            //finally
            //{
            //    if (conn2 != null)
            //    {
            //        conn2.Close();
            //    }
            //    if (rdr1 != null)
            //    {
            //        rdr1.Close();
            //    }
            //}
            ////     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //#endregion


            //#region hhieenr thi


            //   var rscustemp2 = from tbl_PriceRptCustomer in dc.tbl_PriceRptCustomers
            //             //    where tbl_PriceRptCustomer.Customer == Cust && regionchoi == tbl_PriceRptCustomer.Region
            //                 select new
            //                 {
            //                     tbl_PriceRptCustomer.Region,
            //                     tbl_PriceRptCustomer.Customer,
            //                     tbl_PriceRptCustomer.KeyAccount,
            //                     tbl_PriceRptCustomer.SalesDistrict,
            //                     tbl_PriceRptCustomer.MatNumber,
            //                     tbl_PriceRptCustomer.MatText,
            //                     Base_Price = tbl_PriceRptCustomer.BasePrice,
            //                     Function_Discount = tbl_PriceRptCustomer.FuctionDiscountY1,
            //                     Promotion_Discount = tbl_PriceRptCustomer.PromotionDiscountY2,
            //                     Surcharge_Discount = tbl_PriceRptCustomer.SurchargeDiscountY3,
            //                     Net_Price = tbl_PriceRptCustomer.NetPrice

            //                 };// tbl_PriceRptCustomer;
            //if (rscustemp2.Count() > 0)
            //{
            //    Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRICE OF All CUSTOMER  ON DATE: " + datePrice.Value.ToShortDateString(), 3);// view code 1 la can viet them lenh

            //    viewtbl.ShowDialog();
            //}


            //#endregion


        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btfindcust_Click(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code","");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;



            if (valueinput == null)
            {
                valueinput = "";
            }
            if (chon)
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                             where tbl_ka_prCustomer.Name.Contains(valueinput)
                             select new
                             {
                                 Region = tbl_ka_prCustomer.SalesOrg,
                                 tbl_ka_prCustomer.Customer,
                                 tbl_ka_prCustomer.Name,
                                 tbl_ka_prCustomer.PriceList,
                                 tbl_ka_prCustomer.KeyAccount,
                                 tbl_ka_prCustomer.Salesdistrict,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,cChoose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                string region = viewtb.region;

                double codetempid = double.Parse(codetemp);
                if (codetemp != "0" && chon == true && codetemp != null)
                {
                    cbcustomercode.Text = codetemp;

                    //cbregion1.SelectedItem = c

                    cbregion1.Text = region;
                    lbNAme.Text = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                                   where tbl_ka_prCustomer.Customer == codetempid
                                   select tbl_ka_prCustomer.Name).FirstOrDefault();


                }

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void bt_exporttoex_Click(object sender, EventArgs e)
        {

            //dataGridView1.DataSource = rs;

            Control_ac ctrex = new Control_ac();
            ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);


        }
        //     
        public void PricemakeOftbl_kaPrcingreportsTem(object obj)
        {

            datainportPriceF inf = (datainportPriceF)obj;

            //   double customer = inf.customer;
            DateTime dateprice = inf.dateprice;
            string region = inf.region;
            double keyaccount = inf.keyaccount;
            string pricelistid = inf.pricelistid;
            string saledistric = inf.saledistrict;
            double cust = inf.customer;
            string username = inf.username;
            string product = inf.product;

            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("maketbl_kaPrcingreportsTem", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //  cmd1.Parameters.Add("@pricelistid", SqlDbType.NVarChar).Value = pricelistid;
                cmd1.Parameters.Add("@saledistrict", SqlDbType.NVarChar).Value = saledistric;
                cmd1.Parameters.Add("@keyaccount", SqlDbType.Float).Value = keyaccount;
                cmd1.Parameters.Add("@region", SqlDbType.NVarChar).Value = region;
                cmd1.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                cmd1.Parameters.Add("@cust", SqlDbType.Float).Value = cust;
                cmd1.Parameters.Add("@dateprice", SqlDbType.DateTime).Value = dateprice;
                cmd1.Parameters.Add("@product", SqlDbType.NVarChar).Value = product;
                //  product
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

            #endregion







        }



        private void button1_Click(object sender, EventArgs e)
        {



            //     this.rs = dataselected;
            if (cbcplist.Text != "" && keyaccountcb.Text != "" && cbregion4.Text != "" && txtproduct.Text != "")
            {

                DateTime dateprice = datePrice.Value;
                string pricelist = cbcplist.Text.Trim();
                string region = cbregion4.Text.Trim();
                string salesdic;
                if (cbsalesdic.Text != "" && cbsalesdic.Text != null)
                {
                    salesdic = cbsalesdic.Text.Trim();
                }
                else
                {
                    salesdic = "-1";
                }
                double Cust;
                if (cbcust2.Text != "" && cbcust2.Text != null)
                {
                    Cust = double.Parse(cbcust2.Text.Trim());



                }
                else
                {
                    Cust = -1;
                }

                double keyaccount = double.Parse(keyaccountcb.Text.Trim());


                //               var basepricelist = from tbl_KAbaseprice in db.tbl_KAbaseprices
                //                    where tbl_KAbaseprice.PriceList.Trim() == pricelist
                //                    && tbl_KAbaseprice.Valid_From <= dateprice
                //                    && tbl_KAbaseprice.Valid_to >= dateprice
                //                    select new {
                //                        tbl_KAbaseprice.Material,
                //                        tbl_KAbaseprice.MaterialNAme,
                //                        tbl_KAbaseprice.Amount,
                //                        tbl_KAbaseprice.Valid_From,
                //                        tbl_KAbaseprice.Valid_to,
                //                        tbl_KAbaseprice.Unit,
                //                        tbl_KAbaseprice.UoM

                //                    };

                //dataGridView2.DataSource = basepricelist;
                //this.rs2 = basepricelist;



                // ---- tinh
                string connection_string = Utils.getConnectionstr();
                string username = Utils.getusername();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    newcontract.Channel = (cb_channel.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                //string product = txtproduct.Text.Trim();
                string product = (txtproduct.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                dc.ExecuteCommand("DELETE FROM tbl_kaPrcingreportsTem where tbl_kaPrcingreportsTem.UserName ='" + username + "'");
                //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                dc.CommandTimeout = 0;
                dc.SubmitChanges();


                //DateTime dateprice = datePrice.Value;
                //string pricelist = cbcplist.Text.Trim();
                //string region = cbregion4.Text.Trim();
                //string salesdic = cbsalesdic.Text.Trim();
                // username = Utils.getusername();

                //double Cust = double.Parse(cbcust2.Text.Trim());
                //double keyaccount = double.Parse(keyaccountcb.Text.Trim());

                Thread t1 = new Thread(PricemakeOftbl_kaPrcingreportsTem);
                t1.IsBackground = true;
                t1.Start(new datainportPriceF() { customer = Cust, region = region, dateprice = dateprice, keyaccount = keyaccount, pricelistid = pricelist, saledistrict = salesdic, username = username, product = product });

                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1999);
                    t2.Abort();
                }



                // check price liss neeu skhacs khoong file base price
                var promotion = from tbl_KApromotinpriceTMP in db.tbl_KApromotinpriceTMPs
                                where tbl_KApromotinpriceTMP.UserName == username
                                select tbl_KApromotinpriceTMP;

                dataGridView1.DataSource = promotion;

                this.rs = promotion;

                var basepricelist = from tbl_KAbaseprice in db.tbl_KAbaseprices
                                    where tbl_KAbaseprice.PriceList== pricelist
                                    && tbl_KAbaseprice.Valid_From <= dateprice
                                    && tbl_KAbaseprice.Valid_to >= dateprice
                                    &&   tbl_KAbaseprice.Material == product 
                                
                                    select new {
                                    
                                        tbl_KAbaseprice.PriceList,
                                        tbl_KAbaseprice.Material,
                                        tbl_KAbaseprice.MaterialNAme,
                                        tbl_KAbaseprice.Amount,
                                        tbl_KAbaseprice.Valid_From,
                                        tbl_KAbaseprice.Valid_to,
                                        tbl_KAbaseprice.Unit,
                                        tbl_KAbaseprice.UoM

                                    };

                dataGridView2.DataSource = basepricelist;
                this.rs2 = basepricelist;



            }
            else
            {
                if (txtproduct.Text == "")
                {
                    MessageBox.Show("Please select product condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbcplist.Text == "")
                {
                    MessageBox.Show("Please select code or price list condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //  keyaccountcb.Text != ""

                if (keyaccountcb.Text == "")
                {
                    MessageBox.Show("Please select keyaccount code condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbregion4.Text =="")
                {
                    MessageBox.Show("Please select Region code condition !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = rs;

            Control_ac ctrex = new Control_ac();
            ctrex.exportExceldatagridtofile(this.rs2, this.db, this.Text);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbcust2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string valueinput = cbcust2.Text;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                             where ((int)tbl_ka_prCustomer.Customer).ToString().Contains(valueinput)
                             select new
                             {
                                 Region = tbl_ka_prCustomer.SalesOrg,
                                 tbl_ka_prCustomer.Customer,
                                 tbl_ka_prCustomer.Name,
                                 tbl_ka_prCustomer.PriceList,
                                 tbl_ka_prCustomer.KeyAccount,
                                 tbl_ka_prCustomer.Salesdistrict,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                string region = viewtb.region;
                double codetempid = double.Parse(codetemp);

                if (codetemp != "0" && codetemp != null)
                {
                    cbcust2.Text = codetemp;

                    var cus = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                               where tbl_ka_prCustomer.Customer == codetempid && tbl_ka_prCustomer.SalesOrg == region
                               select tbl_ka_prCustomer).FirstOrDefault();

                    cbregion4.Text = region;

                    cbcplist.Text = cus.PriceList;
                    keyaccountcb.Text = cus.KeyAccount.ToString();
                    cbsalesdic.Text = cus.Salesdistrict;


                }
                else
                {


                }



            }


        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            View.valueinput inputval = new valueinput("Input some text in Name to seach code","");

            inputval.ShowDialog();

            bool chon = inputval.kq;
            string valueinput = inputval.valuetext;
            if (valueinput == null)
            {
                valueinput = "";
            }
            if (chon)
            {



                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rscode = from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                             where tbl_ka_prCustomer.Name.Contains(valueinput)
                             select new
                             {
                                 Region = tbl_ka_prCustomer.SalesOrg,
                                 tbl_ka_prCustomer.Customer,
                                 tbl_ka_prCustomer.Name,
                                 tbl_ka_prCustomer.PriceList,
                                 tbl_ka_prCustomer.KeyAccount,
                                 tbl_ka_prCustomer.Salesdistrict,

                             };




                Utils ut = new Utils();
                var tblcustomer = ut.ToDataTable(dc, rscode);

                Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,cChoose one code !");
                viewtb.ShowDialog();
                string codetemp = viewtb.valuecode;
                double codetempid = double.Parse(codetemp);
                if (codetemp != "0" && chon == true && codetemp != null)
                {
                    cbcust2.Text = codetemp;

                    //cbregion1.SelectedItem = c


                    var cus = (from tbl_ka_prCustomer in dc.tbl_ka_prCustomers
                               where tbl_ka_prCustomer.Customer == double.Parse(codetemp)
                               select tbl_ka_prCustomer).FirstOrDefault();

                    cbregion4.Text = cus.SalesOrg;

                    cbcplist.Text = cus.PriceList;
                    keyaccountcb.Text = cus.KeyAccount.ToString();
                    cbsalesdic.Text = cus.Salesdistrict;


                }

            }




            //----




        }

        private void cbcust2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
