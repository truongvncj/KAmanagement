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


    public partial class CreatnewCust : Form
    {
        public View.CreatenewContract contractnew;
        public CreatnewCust(View.CreatenewContract contractnew)
        {
            InitializeComponent();
            this.contractnew = contractnew;
            //   txtcode.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            tbl_KaCustomer newcUST = new tbl_KaCustomer();


            #region cbsapcode.Checked
            if (cbsapcode.Checked == true)
            {


                if (txtcode.Text != "")
                {

                    if (Utils.IsValidnumber(txtcode.Text))
                    {
                        string username = Utils.getusername();
                        var regioncode = (from tbl_Temp in dc.tbl_Temps
                                          where tbl_Temp.username == username
                                          select tbl_Temp.RegionCode).FirstOrDefault();


                        var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                                  where tbl_KaCustomer.Customer == double.Parse(txtcode.Text) && tbl_KaCustomer.SapCode == true
                                  && (from Tka_RegionRight in dc.Tka_RegionRights
                                      where Tka_RegionRight.RegionCode == regioncode
                                      select Tka_RegionRight.Region
                                              ).Contains(tbl_KaCustomer.SalesOrg)

                                  select tbl_KaCustomer).FirstOrDefault();
                        if (rs == null)
                        {
                            newcUST.Customer = double.Parse(txtcode.Text);
                            newcUST.SapCode = true;
                            newcUST.indirectCode = false;
                        }
                        else
                        {
                            txtcode.Focus();
                            MessageBox.Show("Customer code existed, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }


                    }
                    else
                    {
                        txtcode.Focus();
                        MessageBox.Show("Please check Customer Code Number  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }




                }
                else
                {

                    // var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                    //           where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SapCode == true
                    //           select tbl_KaCustomer.Customer).Max();
                    // if (rs == null)
                    // {
                    //     rs = 0;
                    // }

                    //     newcUST.Customer = rs + 1;
                    ////     newcUST.SapCode = true;
                    ////     newcUST.indirectCode = true;


                    txtcode.Focus();
                    MessageBox.Show("Please check Customer Code must be difference blank  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                //    newcUST.Grpcode = false;
                //  newcUST.SFAcode = false;
                //  newcUST.SapCode = true;
                // newcUST.indirectCode = true;

            }

            #endregion


            #region if SFA code
            if (cbsfa.Checked == true)
            {


                if (txtcode.Text != "")
                {

                    if (Utils.IsValidnumber(txtcode.Text))
                    {

                        var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                                  where tbl_KaCustomer.Customer == double.Parse(txtcode.Text) && tbl_KaCustomer.SFAcode == true

                                  select tbl_KaCustomer).FirstOrDefault();

                        if (rs == null)
                        {
                            newcUST.Customer = double.Parse(txtcode.Text);

                        }
                        else
                        {
                            txtcode.Focus();
                            MessageBox.Show("Customer code existed, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }


                    }




                    newcUST.SFAcode = true;
                    newcUST.SapCode = false;
                    newcUST.indirectCode = true;


                    //newcUST.Grpcode = false;
                    //      newcUST.SFAcode = true;
                    //       newcUST.SapCode = false;
                    //      newcUST.indirectCode = false;
                    //

                }
                else
                {

                    //var rs = (from tbl_KaCustomer in dc.tbl_KaCustomers
                    //          where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SFAcode == true
                    //          select tbl_KaCustomer.Customer).Min();
                    //if (rs == null)
                    //{
                    //    rs = 0;
                    //}
                    //  rs = 1300;

                    var rs1 = (from tbl_KaCustomer in dc.tbl_KaCustomers
                               where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SFAcode == true
                                   && tbl_KaCustomer.Customer != null
                               select tbl_KaCustomer.Customer).FirstOrDefault();

                    if (rs1 == null)
                    {
                        rs1 = 13000000;
                    }
                    // double rs1 = 13000000;
                    Boolean kq = true;
                    do
                    {
                        rs1 = rs1 + 1;

                        var rs2 = from tbl_KaCustomer in dc.tbl_KaCustomers
                                  where tbl_KaCustomer.indirectCode == true && tbl_KaCustomer.SFAcode == true && tbl_KaCustomer.Customer == rs1
                                  select tbl_KaCustomer.Customer;

                        //    MessageBox.Show("rs2" +  rs2.Count(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);





                        if (rs2.Count() == 0)
                        {
                            kq = false;
                        }
                        rs2 = null;

                    } while (kq);





                    newcUST.Customer = rs1;

                    newcUST.SFAcode = true;
                    newcUST.SapCode = false;
                    newcUST.indirectCode = true;


                    //   txtCustcode.Focus();
                    //  MessageBox.Show("Please check Customer Code  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //  return;
                }
                //    newcUST.Grpcode = false;




            }
            #endregion



            newcUST.SALORG_CTR = Utils.getfirstusersalescontrolregion();
            newcUST.VATregistrationNo = vatno.Text;
            newcUST.CreatedOn = DateTime.Today;
            newcUST.Createdby = Utils.getusername();
            //if (txtregion.Text != null)
            //{
            //    newcUST.Vendor = txtregion.Text;
            //}
            //else
            //{
            //    txtregion.Focus();
            //    MessageBox.Show("Please check region  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (txt_provicen.Text != null && txt_provicen.Text != "")
            {
                newcUST.City = txt_provicen.Text;
            }
            else
            {
                txt_provicen.Focus();
                MessageBox.Show("Please check City/ Provice  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            newcUST.CTDescription = txt_description.Text;

            if (txt_district.Text != null && txt_district.Text != "")
            {
                newcUST.District = txt_district.Text;
            }
            else
            {
                txt_district.Focus();
                MessageBox.Show("Please check District !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_chananame.Text != null && txt_chananame.Text != "")
            {
                newcUST.FullNameN = txt_chananame.Text;
            }
            else
            {
                txt_chananame.Focus();
                MessageBox.Show("Please check Name !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txt_represennt.Text != null && txt_represennt.Text != "")
            {
                newcUST.Representative = txt_represennt.Text;
            }
            else
            {
                txt_represennt.Focus();
                MessageBox.Show("Please check Representative !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_houseno.Text != null && txt_houseno.Text != "")
            {

                newcUST.Street = txt_houseno.Text;
            }
            else
            {
                txt_houseno.Focus();
                MessageBox.Show("Please check Home street !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (txt_provicen.Text != null)
            //{

            //    newcUST.City = txt_provicen.Text;
            //}
            //else
            //{
            //    txt_provicen.Focus();
            //    MessageBox.Show("Please check City/ Province !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}



            dc.tbl_KaCustomers.InsertOnSubmit(newcUST);
            dc.SubmitChanges();

            contractnew.Uploadcutomercode(newcUST.Customer.ToString(), newcUST.FullNameN, newcUST.SFAcode);

            MessageBox.Show("Customer :" + newcUST.Customer + " create ok !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //var typeffmain = typeof(tbl_KaCustomer);
            //var typeffsub = typeof(tbl_KaCustomer);
            //VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA CUSTOMER ", dc, "tbl_KaCustomer", "tbl_KaCustomer", typeffmain, typeffsub, "id", "id", "");
            //inputcdata.Show();

            this.Close();


        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_represennt.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_represennt.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_chananame.Focus();


            }
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_houseno.Focus();


            }
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_district.Focus();


            }
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_provicen.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_description.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                vatno.Focus();
                //txtcode.Focus();


            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)///groupced
        {


        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)// safcdeo
        //{

        //    if (cbsfa.Checked == true)

        //    {

        //        cbsfa.Checked = false;


        //    }
        //    else
        //    {
        //        cbsfa.Checked = true;
        //    }


        //}

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)// scapcode
        {


        }

        private void vatno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                // vatno.Focus();
                txtcode.Focus();


            }
        }

        private void cbsapcode_CheckedChanged(object sender, EventArgs e)
        {

            if (cbsapcode.Checked == true)

            {

                cbsfa.Checked = false;


            }
            else
            {
                cbsfa.Checked = true;
            }



        }

        private void cbsfa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsfa.Checked == true)

            {

                cbsapcode.Checked = false;
                txtcode.Text = "";
                txtcode.Enabled = true;

            }
            else
            {
                cbsapcode.Checked = true;
                txtcode.Text = "";
                txtcode.Enabled = true;
            }


        }
    }


}
