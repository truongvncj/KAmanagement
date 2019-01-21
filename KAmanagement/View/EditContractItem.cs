using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KAmanagement.Control;

namespace KAmanagement.View
{


    public partial class EditContractItem : Form
    {
        public string contractno { get; set; }
        public string programe { get; set; }
        public int payiD { get; set; }

        public View.CreatenewContract formcreatCtract { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public string unitvalue { get; set; }

        public EditContractItem(View.CreatenewContract formcreatCtract, string contractno, string formtype, string programe, int payid)
        {

            // contractno = contractno;
            this.programe = programe;
            this.payiD = payid;
            this.formcreatCtract = formcreatCtract;
            InitializeComponent();

            lbcontractno.Text = contractno;
            this.contractno = contractno;
            formlabelED.Text = formtype;

            if (formtype == "EDIT ITEM TERM OF CONTRACT")  // edit loadcontract to edit
            {

                cb_program.Enabled = true;


                #region  //LOAD  and edit



                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                addnewitem.Visible = false;
                //      #region load combound program

                //       cb_program

                var contractitem = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                   where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payid
                                   && tbl_kacontractsdatadetail.PayType == programe
                                   select tbl_kacontractsdatadetail;
                if (contractitem.Count() == 1)
                {
                    foreach (var item in contractitem)
                    {

                        cb_program.Text = item.PayType;
                        //            cb_program.Enabled = false;

                        #region programe
                        //  cb_paycontrol.Enabled = false;  load paycontrol to change
                        //    string connection_string = Utils.getConnectionstr();

                        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                        //  CombomCollection = null;
                        List<ComboboxItem> CombomCollection1 = new List<ComboboxItem>();
                        var rs22 = from tbl_kaprogramlist in db.tbl_kaprogramlists
                                       //  where tbl_Kafuctionlist.Code != "DIS"
                                   orderby tbl_kaprogramlist.Code
                                   select tbl_kaprogramlist;
                        foreach (var item2 in rs22)
                        {
                            ComboboxItem cb2 = new ComboboxItem();
                            cb2.Value = item2.Code.Trim();
                            cb2.Text = item2.Code.Trim() + ": " + item2.Name;
                            CombomCollection1.Add(cb2);
                        }


                        cb_program.DataSource = CombomCollection1;
                        cb_program.ValueMember = "Value";
                        cb_program.DisplayMember = "Text";
                        cb_program.DropDownWidth = 300;


                        //     int j = 0;
                        foreach (var i in CombomCollection1)
                        {


                            if (i.Value.ToString().Trim() == item.PayType.Trim())
                            {


                                cb_program.SelectedItem = i;

                                //  MessageBox.Show(j.ToString());
                            }

                            //  j++;
                        }
                        #endregion




                        #region paycontrong
                        //  cb_paycontrol.Enabled = false;  load paycontrol to change
                        //    string connection_string = Utils.getConnectionstr();

                        //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                        //  CombomCollection = null;
                        List<ComboboxItem> CombomCollection3 = new List<ComboboxItem>();
                        var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
                                 where tbl_Kafuctionlist.Code != "DIS"
                                 orderby tbl_Kafuctionlist.Code
                                 select tbl_Kafuctionlist;
                        foreach (var item2 in rs)
                        {
                            ComboboxItem cb = new ComboboxItem();
                            cb.Value = item2.Code.Trim();
                            cb.Text = item2.Code.Trim() + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
                            CombomCollection3.Add(cb);
                        }
                        //     cb_paycontrol

                        cb_paycontrolchge.DataSource = CombomCollection3;
                        cb_paycontrolchge.ValueMember = "Value";
                        cb_paycontrolchge.DisplayMember = "Text";
                        cb_paycontrolchge.DropDownWidth = 600;


                        //     int j1 = 0;
                        foreach (var i in CombomCollection3)
                        {


                            if (i.Value.ToString().Trim() == item.PayControl.Trim())
                            {

                                cb_paycontrolchge.SelectedItem = i;
                                //  MessageBox.Show(j.ToString());
                            }

                            // j1++;
                        }
                        #endregion


                        //  cbProductGR


                        #region PRODUCT GROUP

                        List<ComboboxItem> CombomCollection2 = new List<ComboboxItem>();
                        var rs2 = from tbl_kaPrdgrp in db.tbl_kaPrdgrps
                                  orderby tbl_kaPrdgrp.PrdGrp
                                  select tbl_kaPrdgrp;
                        foreach (var item2 in rs2)
                        {
                            ComboboxItem cb = new ComboboxItem();
                            cb.Value = item2.PrdGrp;
                            cb.Text = item2.PrdGrp.Trim() + ": " + item2.ProductGroup;// + "- Exp : " + item.Example;
                            CombomCollection2.Add(cb);
                        }


                        cbProductGR.DataSource = CombomCollection2;
                        cbProductGR.ValueMember = "Value";
                        cbProductGR.DisplayMember = "Text";
                        cbProductGR.DropDownWidth = 350;


                        //      int k = 0;
                        foreach (var i in CombomCollection2)
                        {


                            //    if ((string)i.Value == item.PayControl)
                            if (i.Value.ToString().Trim() == item.PrdGrp.Trim())
                            {

                                cbProductGR.SelectedItem = i;
                                //  MessageBox.Show(j.ToString());
                            }

                            // k++;
                        }
                        #endregion



                        status.Text = item.Constatus;
                        unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();

                        cbIDprg.Text = item.PayID.ToString();
                        cbIDprg.Enabled = false;


                        //       cbProductGR.Text = item.PrdGrp;
                        if (item.EffFrm != null)
                        {
                            fromdatep.Value = item.EffFrm.Value;
                        }
                        if (item.EffTo != null)
                        {

                            todatep.Value = item.EffTo.Value;
                        }

                        cbDescristion.Text = item.Remark;
                        if (item.CommittedDate != null)
                        {
                            paymentdatep.Value = item.CommittedDate.Value;

                        }
                        else
                        {

                            paymentdatep.Visible = false;
                            lbdatepaid.Visible = false;


                        }
                        if (item.FundPercentage != null)
                        {
                            spercent.Text = item.FundPercentage.ToString();
                        }
                        else
                        {
                            spercent.Enabled = false;
                        }

                        if (item.SponsoredAmtperPC != null)
                        {
                            ucpcsponsor.Text = item.SponsoredAmtperPC.ToString();
                        }
                        else
                        {
                            ucpcsponsor.Enabled = false;
                        }

                        if (item.SponsoredAmt != null)
                        {
                            amountsponsor.Text = item.SponsoredAmt.ToString();
                        }
                        else
                        {
                            amountsponsor.Enabled = false;
                        }

                        if (item.SponsorUnit != null)
                        {
                            sunit.Text = item.SponsorUnit.ToString();
                        }
                        else
                        {
                            sunit.Enabled = false;
                        }

                        if (item.TagetPercentage != null)
                        {
                            tprcent.Text = item.TagetPercentage.ToString();
                        }
                        else
                        {
                            tprcent.Enabled = false;
                        }

                        if (item.TagetAchivement != null)
                        {
                            tachive.Text = item.TagetAchivement.ToString();
                        }
                        else
                        {
                            tachive.Enabled = false;
                        }


                        if (item.TargetUnit != null)
                        {
                            tunit.Text = item.TargetUnit.ToString();
                        }
                        else
                        {
                            tunit.Enabled = false;
                        }

                        if (item.ExtCondition == true)
                        {

                            exConditionCbox.Checked = true;
                        }
                        else
                        {
                            exConditionCbox.Checked = false;
                        }

                        if (item.ExtNote != null)
                        {
                            extnote.Text = item.ExtNote.ToString();
                        }
                        else
                        {
                            extnote.Text = "";
                        }

                        if (item.CombineType != null)
                        {


                            cobinetype.SelectedText = item.CombineType;

                        }

                        if (item.CombineItem != null)
                        {


                            combineitem.SelectedText = item.CombineItem.ToString();

                        }




                    }


                }









                #endregion

            }



            if (formtype == "CREATE NEW ITEM TERM")  // create newcontract iteam
            {
                #region  load new to create
                lbprogramid.Visible = false;

                cbIDprg.Visible = false;


                btchangecontractitem.Visible = false;
                deletebt.Visible = false;
                btactive.Visible = false;
                btchange.Visible = false;
                status.Text = "CRT";

                //unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();
                #region paycontrong
                //  cb_paycontrol.Enabled = false;  load paycontrol to change
                //    string connection_string = Utils.getConnectionstr();


                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
                unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();
                //  CombomCollection = null;
                List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
                             //    where tbl_Kafuctionlist.Code != "DIS"
                         orderby tbl_Kafuctionlist.Code
                         select tbl_Kafuctionlist;
                foreach (var item2 in rs)
                {
                    ComboboxItem cb = new ComboboxItem();
                    cb.Value = item2.Code;
                    cb.Text = item2.Code + ": " + item2.Description + "    || Example: " + item2.Example;
                    CombomCollection.Add(cb);
                }


                cb_paycontrolchge.DataSource = CombomCollection;
                cb_paycontrolchge.ValueMember = "Value";
                cb_paycontrolchge.DisplayMember = "Text";
                cb_paycontrolchge.DropDownWidth = 600;
                cb_paycontrolchge.DropDownStyle = ComboBoxStyle.DropDownList;

                #endregion


                //  cbProductGR


                #region PRODUCT GROUP

                List<ComboboxItem> CombomCollection2 = new List<ComboboxItem>();
                var rs2 = from tbl_kaPrdgrp in db.tbl_kaPrdgrps
                          orderby tbl_kaPrdgrp.PrdGrp
                          select tbl_kaPrdgrp;
                foreach (var item2 in rs2)
                {
                    ComboboxItem cb = new ComboboxItem();
                    cb.Value = item2.PrdGrp;
                    cb.Text = item2.PrdGrp.Trim() + ": " + item2.ProductGroup;// + "- Exp : " + item.Example;
                    CombomCollection2.Add(cb);
                }


                cbProductGR.DataSource = CombomCollection2;
                cbProductGR.ValueMember = "Value";
                cbProductGR.DisplayMember = "Text";
                cbProductGR.DropDownWidth = 350;
                cbProductGR.DropDownStyle = ComboBoxStyle.DropDownList;

                //
                #endregion




                #region PROGRAME

                List<ComboboxItem> CombomCollection3 = new List<ComboboxItem>();
                var rs3 = from tbl_kaprogramlist in db.tbl_kaprogramlists
                          orderby tbl_kaprogramlist.Code
                          select tbl_kaprogramlist;
                foreach (var item3 in rs3)
                {
                    ComboboxItem cb = new ComboboxItem();
                    cb.Value = item3.Code;
                    cb.Text = item3.Code.Trim() + ": " + item3.Name;// + "- Exp : " + item.Example;
                    CombomCollection3.Add(cb);
                }


                cb_program.DataSource = CombomCollection3;

                cb_program.ValueMember = "Value";
                cb_program.DisplayMember = "Text";
                cb_program.DropDownWidth = 350;
                cb_program.DropDownStyle = ComboBoxStyle.DropDownList;

                //
                #endregion






                #endregion


            }

        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_paycontrolchge.Focus();


            }




        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //      cb_subid.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_sponsoramt.Focus();


            }
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                // txt_paidamt.Focus();


            }
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balance.Focus();


            }
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_paymentamount.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balancenew.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_contractno.Focus();


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);

            //if (this.txt_batchno.Text == "" )
            //{
            //    this.txt_batchno.Text = "0";
            //}

            //if ( Utils.IsValidnumber(this.txt_batchno.Text) == false)
            //{
            //    MessageBox.Show("Please check Batch No !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            //int Batchno = int.Parse(this.txt_batchno.Text);


            #region delete  DETAIL AND GRUOP RPT BY USER


            string username = Utils.getusername();
            //  string connection_string = Utils.getConnectionstr();
            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string sqltext = "DELETE FROM tbl_KAdetailprogrRpt WHERE tbl_KAdetailprogrRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();


            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            #endregion



        }


        private void txt_paymentamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_paymentamount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                //txt_note.Focus();
            }








        }


        private void cb_payid_SelectedValueChanged(object sender, EventArgs e)
        {

            String paycontrol = (cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            if (paycontrol == "DIS")
            {
                #region

                gruopCtractdate.Visible = true;
                //  cb_program.SelectedItem = "DIS";
                foreach (var item in cb_program.Items)
                {

                    if ((item as ComboboxItem).Value.ToString().Trim().Equals("DIS"))
                    {
                        //    MessageBox.Show((item as ComboboxItem).Value.ToString());
                        cb_program.SelectedItem = item;
                        cb_program.Text = (item as ComboboxItem).Text.ToString();
                        // cb_program.DisplayMember = item;
                    }

                }

                //cb_program.Text = "DIS";

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                spercent.Text = "0";


                ucpcsponsor.Enabled = true;
                ucpcsponsor.Text = "0";

                amountsponsor.Enabled = false;
                //    amountsponsor.Text = "0";

                sunit.Text = "%";

                sunit.Enabled = true;

                tprcent.Enabled = false;
                //   tprcent.Text = "";

                tachive.Enabled = false;
                // tachive.Text = "";

                tunit.Enabled = false;
                //   sunit.Enabled = false;

                tunit.Text = "";

                #endregion



            }




            if (paycontrol == "C00")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                //fromdatep.Enabled = false;
                //todatep.Enabled = false;

                gruopCtractdate.Visible = false;

                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //    spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //   amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //   tprcent.Text = "";

                tachive.Enabled = false;
                // tachive.Text = "";

                tunit.Enabled = false;
                sunit.Enabled = false;
                tunit.Text = "";

                #endregion



            }

            if (paycontrol == "C01")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                gruopCtractdate.Visible = false;

                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;
                //fromdatep.Enabled = false;
                //todatep.Enabled = false;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = false;
                // ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = false;
                //  tachive.Text = "";

                //   tunit.Enabled = false;
                tunit.Enabled = false;
                sunit.Enabled = false;
                tunit.Text = "";
                #endregion

            }

            if (paycontrol == "C02")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //      amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = true;
                //     tprcent.Text = "";

                tachive.Enabled = true;
                //   tachive.Text = "";

                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "C03")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                // amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //    tachive.Text = "";

                //   tunit.Enabled = true;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "C04")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //     spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = true;
                // tachive.Text = "";

                //  tunit.Enabled = true;
                tunit.Text = unitvalue;
                tunit.Enabled = false;
                sunit.Enabled = false;

                #endregion

            }
            if (paycontrol == "C05")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //    spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //      ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //     amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //     tprcent.Text = "";

                tachive.Enabled = false;
                //     tachive.Text = "";

                //   tunit.Enabled = false;
                tunit.Text = "";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }
            if (paycontrol == "C06")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //       amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = true;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //        tachive.Text = "";

                //tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;

                #endregion

            }


            if (paycontrol == "C07")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
              
                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //       amountsponsor.Text = "0";

                sunit.Text = unitvalue;

        //        tprcent.Enabled = true;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //        tachive.Text = "";

                //tunit.Enabled = false;
                tunit.Text = "NSR";
                tunit.Enabled = false;
                sunit.Enabled = false;

                #endregion

            }
            if (paycontrol == "D01")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                tprcent.Text = "";

                tachive.Enabled = false;
                tachive.Text = "";

                //    tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "D02")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //     ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //      amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                ///    tprcent.Text = "";

                tachive.Enabled = false;
                //     tachive.Text = "";

                //  tunit.Enabled = false;
                tunit.Text = "Litter";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }
            if (paycontrol == "D03")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                // spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = false;
                //   tachive.Text = "";

                //       tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }
            if (paycontrol == "P00")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "%";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Enabled = false;
                //tprcent.Text = "";

                tachive.Enabled = false;
                //     tachive.Text = "";

                //     tunit.Enabled = false;
                tunit.Text = unitvalue;
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }
            if (paycontrol == "P01")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = false;
                //    tachive.Text = "";

                //      tunit.Enabled = false;
                //tunit.Text = "";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }

            if (paycontrol == "P02")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Text = "";
                tprcent.Enabled = false;
                 

                tachive.Enabled = true;
                //    tachive.Text = "";

                //      tunit.Enabled = false;
                //tunit.Text = "";
                tunit.Text = "VND";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }


            if (paycontrol == "P03")
            {
                #region
                gruopCtractdate.Visible = true;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //    tachive.Text = "";

                //      tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }






            if (paycontrol == "NT1")
            {
                #region
                gruopCtractdate.Visible = false;
                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Enabled = false;

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = false;
                //    tachive.Text = "";

                //      tunit.Enabled = false;
                //tunit.Text = "";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();



            var maxbatcno = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments

                             select tbl_kacontractsdetailpayment.BatchNo).Max();



            var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                      where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.BatchNo == 0 && tbl_kacontractsdetailpayment.CRDUSR == Utils.getusername()
                                      select tbl_kacontractsdetailpayment;

            if (newrequestpaymentRS != null && newrequestpaymentRS.Count() > 0)
            {
                foreach (var item in newrequestpaymentRS)
                {

                    item.BatchNo = maxbatcno + 1;
                    item.CRDDAT = DateTime.Today;
                    dc.SubmitChanges();
                }




            }







        }

        private void Createpayment_Load(object sender, EventArgs e)
        {

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cb_paycontrol_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cb_paycontrol_Leave(object sender, EventArgs e)
        {
            // cb_paycontrol.Text = (cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();
        }

        private void EditContractItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {




            #region     // update change itermcontract



            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var item = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails

                        where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payiD
                        && tbl_kacontractsdatadetail.PayType == programe
                        select tbl_kacontractsdatadetail).FirstOrDefault();

            if (item != null)
            {

                item.PayID = payiD;
                item.ContractNo = contractno;
                item.Remark = cbDescristion.Text;


                if (cb_program != null && cb_program.SelectedValue != null)  // update prograne -- cai nay 
                {
                    item.PayType = (cb_program.SelectedItem as ComboboxItem).Value.ToString();
                    string PayTypex = (cb_program.SelectedItem as ComboboxItem).Value.ToString();

                    /// đổng thời check trong payment và sửa luôn
                    LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);
                    var payeche = from tbl_kacontractsdetailpayment in da.tbl_kacontractsdetailpayments
                                  where tbl_kacontractsdetailpayment.PayType == programe && tbl_kacontractsdetailpayment.PayID == payiD
                                  select tbl_kacontractsdetailpayment;


                    if (payeche.Count() > 0)
                    {
                        foreach (var item2 in payeche)
                        {
                            item2.PayType = PayTypex;
                        }
                        da.SubmitChanges();
                    }

                    /// 





                }
                else
                {
                    MessageBox.Show("Please select a programe ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item = null;
                    return;
                }





                //    item.PayType = programe;//(cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString();  ???/

                //    item.PayControl = (cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString();
                //    string paycontrol = (cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString();
                ///---


                if (cb_paycontrolchge != null && cb_paycontrolchge.SelectedValue != null)
                {
                    item.PayControl = (cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString();
                    string paycontrol = (cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString();


                    string[] parts = cb_paycontrolchge.Text.Split('|');

                    string[] st1 = parts[0].Split(':');
                    //  st2 = parts[1].Trim();
                    //    st3 = parts[2].Trim();

                    try
                    {
                        item.Description = paycontrol + ": " + st1[1];

                    }
                    catch (Exception)
                    {

                        item.Description = "";
                    }


                }
                else
                {
                    MessageBox.Show("Please select a Paycontrol", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item = null;
                    return;
                }


                item.ExtCondition = exConditionCbox.Checked;
                if (item.ExtCondition)
                {
                    item.ExtNote = extnote.Text;
                }
                else
                {
                    item.ExtNote = "";
                }


                if (combineitem.SelectedValue != null)
                {

                    if ((combineitem.SelectedItem as ComboboxItem).Value.ToString() != "")
                    {



                        item.CombineItem = int.Parse((combineitem.SelectedItem as ComboboxItem).Value.ToString());



                        if (cobinetype.SelectedItem != null)
                        {
                            item.CombineType = (cobinetype.SelectedItem as ComboboxItem).Value.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please select a cobinetype", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item = null;
                            return;
                        }
                    }
                    else
                    {
                        item.CombineItem = 0;
                        item.CombineType = "";



                    }


                }
                //else
                //{
                //    //MessageBox.Show("Please select a combineitemItem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //item = null;
                //    //return;
                //}




                /// 



                item.PrdGrp = (cbProductGR.SelectedItem as ComboboxItem).Value.ToString();
                item.EffFrm = fromdatep.Value;
                item.EffTo = todatep.Value;

                #region  datepadi
                // paymentdatep != null &&

                if (paymentdatep.Visible == true)
                {


                    if (paymentdatep.Value != null)
                    {
                        item.CommittedDate = paymentdatep.Value;
                    }
                    else
                    {

                        MessageBox.Show("Please check committed date !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        item = null;
                        return;
                    }

                    //     item.CommittedDate = null;
                }
                else
                {
                    item.CommittedDate = null;
                    //MessageBox.Show("Please check ok date !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                #endregion


                #region update value theo enable

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                //    paymentdatep.Visible = false;
                //     lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                #region sporsorpercent
                if (spercent.Enabled == true)
                {
                    if (Utils.IsValidnumber(spercent.Text) && spercent.Text != "")
                    {

                        if (double.Parse(spercent.Text.ToString()) >= 0 && double.Parse(spercent.Text.ToString()) <= 100)
                        {

                            item.FundPercentage = double.Parse(spercent.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Please check FundPercentage must be  from 0 to 100 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            item = null;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please check TagetPercentage must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        item = null;
                        return;
                    }


                    //     = "";

                }
                else
                {
                    item.FundPercentage = null;
                    //    spercent.Text = "";

                }



                #endregion


                #region amount sponsor perr pc
                //   ucpcsponsor.Enabled = false;
                if (ucpcsponsor.Enabled == true)
                {

                    if (ucpcsponsor != null && Utils.IsValidnumber(ucpcsponsor.Text) && ucpcsponsor.Text != "")
                    {

                        if (double.Parse(ucpcsponsor.Text.ToString()) >= 0)
                        {
                            item.SponsoredAmtperPC = double.Parse(ucpcsponsor.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Please check SponsoredAmtperPC must be geater or equal 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            item = null;
                            return;
                        }



                    }
                    else
                    {
                        MessageBox.Show("Please check Sponsoror by PC/UC !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        item = null;
                        return;
                    }


                }
                else
                {
                    item.SponsoredAmtperPC = null;
                }


                #endregion

                //  ucpcsponsor.Text = "";

                //   amountsponsor.Enabled = true;

                #region so[ponsor amount

                if (amountsponsor.Enabled == true)
                    if (amountsponsor != null && Utils.IsValidnumber(amountsponsor.Text) && amountsponsor.Text != "")
                    {
                        if (double.Parse(amountsponsor.Text.ToString()) >= 0)
                        {
                            item.SponsoredAmt = double.Parse(amountsponsor.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Please check amountsponsor must be geater or equal 0 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            item = null;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please check Amount sponsor date !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        item = null;
                        return;
                    }
                else
                {
                    item.SponsoredAmt = null;
                }

                #endregion


                //   amountsponsor.Text = "0";

                //    sunit.Text = unitvalue;
                item.SponsorUnit = sunit.Text;


                #region targetpercent
                if (tprcent.Enabled == true)
                {



                    if (Utils.IsValidnumber(tprcent.Text) && tprcent.Text != "")
                    {


                        if (double.Parse(tprcent.Text.ToString()) >= 0 && double.Parse(tprcent.Text.ToString()) <= 100)
                        {

                            item.TagetPercentage = double.Parse(tprcent.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Please check TagetPercentage must be from 0 to 100 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            item = null;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please check TagetPercentage must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        item = null;
                        return;
                    }



                }
                else
                {
                    //                        tprcent.Enabled = false;
                    item.TagetPercentage = null;

                }
                #endregion


                //   tprcent.Text = "";

                #region target achived
                if (tachive.Enabled == true)
                {



                    if (Utils.IsValidnumber(tachive.Text) && tachive.Text != "")
                    {




                        if (double.Parse(tachive.Text.ToString()) >= 0)
                        {

                            item.TagetAchivement = double.Parse(tachive.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Please check TagetAchivement must be from 0 to 100 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            item = null;
                            return;
                        }



                    }
                    else
                    {
                        MessageBox.Show("Please check t achive must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        item = null;
                        return;
                    }



                }
                else
                {
                    //                        tprcent.Enabled = false;
                    item.TagetAchivement = null;

                }
                #endregion


                //  tachive.Enabled = false;
                //      item.TagetAchivement = null;
                // tachive.Text = "";

                tunit.Enabled = false;
                item.TargetUnit = tunit.Text;
                // tunit.Text = "";

                #endregion

                //    var 



                item.UPDUSR = Utils.getusername();
                item.UPDDAT = DateTime.Today;




                dc.SubmitChanges();


                MessageBox.Show("Item contract updated !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.Control_ac.CaculationContract(contractno);
                formcreatCtract.loadDetailContractView(contractno);
                formcreatCtract.loadtotaldContractView(contractno);
                this.Close();

            }
            #endregion



        }

        private void btchangecontractitem_Click(object sender, EventArgs e)
        {

            // active

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails

                     where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payiD
                     && tbl_kacontractsdatadetail.PayType == programe
                     select tbl_kacontractsdatadetail;

            if (rs.Count() == 1)
            {

                status.Text = "CLS";
                foreach (var item in rs)
                {
                    item.Constatus = "CLS";
                }
                dc.SubmitChanges();
            }
            Control.Control_ac.CaculationContract(contractno);
            formcreatCtract.loadDetailContractView(contractno);
            formcreatCtract.loadtotaldContractView(contractno);
            MessageBox.Show("Item contract close !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // active
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails

                     where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payiD
                        && tbl_kacontractsdatadetail.PayType == programe
                     select tbl_kacontractsdatadetail;

            if (rs.Count() == 1)
            {

                status.Text = "ALV";
                foreach (var item in rs)
                {
                    item.Constatus = "ALV";
                }
                dc.SubmitChanges();
            }

            Control.Control_ac.CaculationContract(contractno);
            formcreatCtract.loadDetailContractView(contractno);
            formcreatCtract.loadtotaldContractView(contractno);

            MessageBox.Show("Item contract actived !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //  this.close();


        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addnewitem_Click(object sender, EventArgs e)
        {

            #region     // update creTE NEW



            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            tbl_kacontractsdatadetail item = new tbl_kacontractsdatadetail();

            if (item != null)
            {

                //  item.PayID = payiD;
                //if ((item as ComboboxItem).Value.ToString().Trim().Equals("DIS"))
                //{


                if ((cb_program.SelectedItem as ComboboxItem).Value.ToString().Trim().Equals("DIS"))
                {
                    //   (cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString()    ;

                    if (!(cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString().Trim().Equals("DIS"))
                    {
                        MessageBox.Show("Program DIS must have Paycontrol DIS", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item = null;
                        return;
                    }

                }



                item.ContractNo = contractno;
                item.Remark = cbDescristion.Text;

                if (cb_program != null && cb_program.SelectedValue != null)
                {
                    item.PayType = (cb_program.SelectedItem as ComboboxItem).Value.ToString();
                }
                else
                {
                    MessageBox.Show("Please select a Programe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item = null;
                    return;
                }

                if (cb_paycontrolchge != null && cb_paycontrolchge.SelectedValue != null)
                {
                    item.PayControl = (cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString();
                    string paycontrol = (cb_paycontrolchge.SelectedItem as ComboboxItem).Value.ToString();


                    string[] parts = cb_paycontrolchge.Text.Split('|');

                    string[] st1 = parts[0].Split(':');
                    //  st2 = parts[1].Trim();
                    //    st3 = parts[2].Trim();

                    try
                    {
                        item.Description = st1[1];

                    }
                    catch (Exception)
                    {

                        item.Description = "";
                    }


                }
                else
                {
                    MessageBox.Show("Please select a Paycontrol", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item = null;
                    return;
                }

                if (cbProductGR != null && cb_program.SelectedValue != null)
                {
                    item.PrdGrp = (cbProductGR.SelectedItem as ComboboxItem).Value.ToString();
                }
                else
                {
                    MessageBox.Show("Please select a Product group", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item = null;
                    return;
                }

                if (fromdatep.Visible == true && todatep.Visible == true)
                {
                    if (fromdatep.Value < todatep.Value)
                    {
                        item.EffFrm = fromdatep.Value;
                        item.EffTo = todatep.Value;


                    }
                    else
                    {
                        MessageBox.Show("Fromdate must be less than to date, please check", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item = null;
                        return;
                    }

                }


                #region  datepadi
                if (paymentdatep.Visible == true)
                {


                    if (paymentdatep.Value != null)
                    {
                        item.CommittedDate = paymentdatep.Value;
                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check committed date !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //     item.CommittedDate = null;
                }
                else
                {
                    item.CommittedDate = null;
                }


                #endregion


                #region update value theo enable

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                //    paymentdatep.Visible = false;
                //     lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                #region sporsorpercent
                if (spercent.Enabled == true)
                {
                    if (Utils.IsValidnumber(spercent.Text) && spercent.Text != "")
                    {

                        if (double.Parse(spercent.Text.ToString()) >= 0 && double.Parse(spercent.Text.ToString()) <= 100)
                        {

                            item.FundPercentage = double.Parse(spercent.Text.ToString());
                        }
                        else
                        {
                            item = null;
                            MessageBox.Show("Please check FundPercentage must be from 0 to 100 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;

                        }

                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check TagetPercentage must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    //     = "";

                }
                else
                {

                    item.FundPercentage = null;
                    //    spercent.Text = "";

                }



                #endregion


                #region amount sponsor perr pc
                //   ucpcsponsor.Enabled = false;
                if (ucpcsponsor.Enabled == true)
                {

                    if (ucpcsponsor != null && Utils.IsValidnumber(ucpcsponsor.Text) && ucpcsponsor.Text != "")
                    {
                        item.SponsoredAmtperPC = double.Parse(ucpcsponsor.Text.ToString());
                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check Sponsoror by PC/UC !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }


                }
                else
                {
                    item.SponsoredAmtperPC = null;
                }


                #endregion

                //  ucpcsponsor.Text = "";

                //   amountsponsor.Enabled = true;

                #region so[ponsor amount

                if (amountsponsor.Enabled == true)
                {
                    if (amountsponsor != null && Utils.IsValidnumber(amountsponsor.Text) && amountsponsor.Text != "")
                    {
                        item.SponsoredAmt = double.Parse(amountsponsor.Text.ToString());
                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check Amount sponsor!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }
                }
                else
                {
                    item.SponsoredAmt = null;
                }

                #endregion


                //   amountsponsor.Text = "0";

                //    sunit.Text = unitvalue;
                item.SponsorUnit = sunit.Text;


                #region targetpercent
                if (tprcent.Enabled == true)
                {



                    if (Utils.IsValidnumber(tprcent.Text) && tprcent.Text != "")
                    {


                        if (double.Parse(tprcent.Text.ToString()) > 0 && double.Parse(tprcent.Text.ToString()) <= 100)
                        {

                            item.TagetPercentage = double.Parse(tprcent.Text.ToString());
                        }
                        else
                        {
                            item = null;
                            MessageBox.Show("Please check TagetPercentage must be greater than 0 and less than 100 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check TagetPercentage must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }



                }
                else
                {
                    //                        tprcent.Enabled = false;
                    item.TagetPercentage = null;

                }
                #endregion


                //   tprcent.Text = "";

                #region target achived
                if (tachive.Enabled == true)
                {



                    if (Utils.IsValidnumber(tachive.Text) && tachive.Text != "")
                    {


                        item.TagetAchivement = double.Parse(tachive.Text.ToString());

                    }
                    else
                    {
                        item = null;
                        MessageBox.Show("Please check Achived must be a number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }



                }
                else
                {
                    //                        tprcent.Enabled = false;
                    item.TagetAchivement = null;

                }
                #endregion


                //  tachive.Enabled = false;
                //      item.TagetAchivement = null;
                // tachive.Text = "";

                tunit.Enabled = false;
                item.TargetUnit = tunit.Text;
                // tunit.Text = "";

                #endregion



                if (item != null)
                {
                    item.Constatus = "CRT";
                    var kw = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                              where tbl_kacontractdata.ContractNo == contractno
                              select tbl_kacontractdata).FirstOrDefault();
                    if (kw != null)
                    {

                        item.ConType = kw.ConType;
                        item.Customercode = kw.Customer;
                        item.Fullname = kw.Fullname;
                        item.SALORG_CTR = kw.SALORG_CTR;
                        item.SalesOrg = kw.SalesOrg;





                    }


                    item.CRDUSR = Utils.getusername();
                    item.CRDDAT = DateTime.Today;

                    dc.tbl_kacontractsdatadetails.InsertOnSubmit(item);
                    dc.SubmitChanges();

                    MessageBox.Show("Item contract created !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Control.Control_ac.CaculationContract(contractno);
                    formcreatCtract.loadDetailContractView(contractno);
                    formcreatCtract.loadtotaldContractView(contractno);
                    this.Close();
                }




            }
            #endregion


        }

        private void ucpcsponsor_SelectedValueChanged(object sender, EventArgs e)
        {





        }

        private void spercent_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void spercent_TextChanged(object sender, EventArgs e)
        {
            if (Utils.IsValidnumber(spercent.Text) && spercent.Text != "")
            {


                if (double.Parse(spercent.Text.ToString()) > 0)
                {
                    sunit.Text = "%";
                    ucpcsponsor.Text = "0";


                };

            }
        }

        private void ucpcsponsor_TextChanged(object sender, EventArgs e)
        {
            if (Utils.IsValidnumber(ucpcsponsor.Text) && ucpcsponsor.Text != "")
            {


                if (double.Parse(ucpcsponsor.Text.ToString()) > 0)
                {
                    sunit.Text = unitvalue;
                    spercent.Text = "0";

                };

            }

        }

        private void deletebt_Click(object sender, EventArgs e)
        {
            // active

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                       where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayID == payiD
                 && tbl_kacontractsdetailpayment.PayType == programe
                       select tbl_kacontractsdetailpayment).FirstOrDefault();

            var rs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails

                     where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payiD
                     && tbl_kacontractsdatadetail.PayType == programe
                     select tbl_kacontractsdatadetail;

            if (rs.Count() == 1 && rs1 == null)
            {

                //      status.Text = "CLS";
                foreach (var item in rs)
                {
                    dc.tbl_kacontractsdatadetails.DeleteOnSubmit(item);
                }
                dc.SubmitChanges();


                Control.Control_ac.CaculationContract(contractno);
                formcreatCtract.loadDetailContractView(contractno);
                formcreatCtract.loadtotaldContractView(contractno);
                MessageBox.Show("Item contract deleted !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Can not delete, this have paid doc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btproductchange_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //  var typeff = typeof(tbl_kaProductlist);
            // VInputchange inputcdata = new VInputchange("", "LIST CONVERTPRODUCTS ", dc, "tbl_kaConvertProductlist", "tbl_kaConvertProductlist", typeff, typeff, "id", "id", "");

            KaconvertProductdetail detailproduct = new KaconvertProductdetail(contractno, payiD);


            detailproduct.ShowDialog();

        }
    }


}
