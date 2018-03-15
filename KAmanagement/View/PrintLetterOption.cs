using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class PrintLetterOption : Form
    {
        //public int choice { get; set; }
        //public double onlycode { get; set; }
        //public double fromcode { get; set; }
        //public double tocode { get; set; }

        //public string groupsending { get; set; }
        //public List<Viewtable.ComboboxItem> Getcomboudata()
        //{




        //    List<Viewtable.ComboboxItem> dataCollection = new List<Viewtable.ComboboxItem>();
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //  //  #region lấy tên từ tbl customerr
    
        //  //  var rs = from tblCustomer in dc.tblCustomers
        //  //         //  from tbl_CustomerGroup in dc.tbl_CustomerGroups
        //  //           where tblCustomer.Reportsend == true && !(from tbl_CustomerGroup in dc.tbl_CustomerGroups
        //  //                                                     select tbl_CustomerGroup.Customercode).Contains(tblCustomer.Customer)
        //  //           group tblCustomer by tblCustomer.Customer into g
        //  //           select new
        //  //           {
        //  //               Customer = g.Key,
        //  //               Name_1 = g.Select(gg => gg.Name_1).FirstOrDefault()

        //  //           };



        //  //  if (rs.Count() > 0)
        //  //  {


        //  //      foreach (var item in rs)
        //  //      {
        //  //          string drowdowvalue = "";

        //  //          drowdowvalue = item.Customer.ToString() + " " + item.Name_1;


        //  //          Viewtable.ComboboxItem itemcb = new Viewtable.ComboboxItem();
        //  //          itemcb.Text = drowdowvalue;
        //  //          itemcb.Value = item.Customer.ToString();



        //  //          dataCollection.Add(itemcb);

        //  //      }

               
        //  //  }
        //  //  #endregion

        //  //  #region lấy tên từ customer grop
        //  //  var rs2 = from tbl_CustomerGroup in dc.tbl_CustomerGroups
        //  //    //  from tbl_CustomerGroup in dc.tbl_CustomerGroups
        //  //where (from tblCustomer in dc.tblCustomers
        //  //       where tblCustomer.Reportsend ==true
        //  //       select tblCustomer.Customer).Contains(tbl_CustomerGroup.Customercode) 
        //  //group tbl_CustomerGroup by tbl_CustomerGroup.Customergropcode into g2
        //  //select new
        //  //{
        //  //    Customer = g2.Key,
        //  //    Name_1 = g2.Select(gg => gg.Group_Name).FirstOrDefault()

        //  //};



        //  //      if (rs2.Count() > 0)
        //  //      {


        //  //          foreach (var item in rs2)
        //  //          {
        //  //              string drowdowvalue = "";

        //  //              drowdowvalue = item.Customer.ToString() + " " + item.Name_1;


        //  //              Viewtable.ComboboxItem itemcb = new Viewtable.ComboboxItem();
        //  //              itemcb.Text = drowdowvalue;
        //  //              itemcb.Value = item.Customer.ToString();
        //  //              dataCollection.Add(itemcb);

        //  //          }
        //  //          #endregion

        //   return dataCollection;
        //    }
        //    return null;

        //}

        //public PrintLetterOption()
        //{
        //    InitializeComponent();
        //    this.choice = 0;
        //    this.cb_printall.CheckState = CheckState.Checked;
        //    this.cb_groupprit.CheckState = CheckState.Unchecked;
        //    this.cb_onlycode.CheckState = CheckState.Unchecked;
        //    this.cb_fromcodetocode.CheckState = CheckState.Unchecked;
          

        //    #region tạo datafileter cho code group

        //    //  List<Viewtable.ComboboxItem> dataCollection = new List<Viewtable.ComboboxItem>();
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //    var rs = from tblCustomer in dc.tblCustomers
        //        //     where tblCustomer.Reportsend == true
        //             group tblCustomer by tblCustomer.SendingGroup into g
        //             select new {
        //                 SendingGroup = g.Key,
        //               //  Customer = g.Select(gg => gg.Customer).FirstOrDefault(),





        //             };


        // //   string drowdowvalue = "";
        //    if (rs.Count() > 0)
        //    {


        //        foreach (var item in rs)
        //        {


        //            if (item.SendingGroup != null)
        //            {
        //                this.input_groupcode.Items.Add(item.SendingGroup.Trim());
        //            }

                
        //           // dataCollection.Add(itemcb);

        //        }

        //      //  return dataCollection;
        //    }
        //    //    return null;



        //    #endregion


        //    #region  add to only customer fill

        //    List<Viewtable.ComboboxItem> lisdat = Getcomboudata();
        //    if (lisdat != null)
        //    {
        //        this.input_onlycode.DropDownStyle = ComboBoxStyle.DropDown;

        //        //      int i = -1;
        //        foreach (var item in lisdat)
        //        {

        //            this.input_onlycode.Items.Add(item);
        //            //i = i + 1;
        //            //if (item.Value.ToString() == cb_cust.Text)
        //            //{
        //            //    cb_cust.SelectedIndex = i;

        //            //}
        //        }




        //    }

        //    #endregion


        //}

        //private void cb_groupprit_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.cb_groupprit.CheckState == CheckState.Checked)
        //    {
        //        this.cb_onlycode.CheckState = CheckState.Unchecked;
        //        this.cb_fromcodetocode.CheckState = CheckState.Unchecked;
        //        this.cb_printall.CheckState = CheckState.Unchecked;
        //    }
          



        //}

        //private void cb_fromcodetocode_CheckedChanged(object sender, EventArgs e)
        //{
        
        //}

        //private void cb_onlycode_CheckedChanged(object sender, EventArgs e)
        //{
           
        //    if (this.cb_onlycode.CheckState == CheckState.Checked)
        //    {
        //        this.cb_groupprit.CheckState = CheckState.Unchecked;
        //        this.cb_fromcodetocode.CheckState = CheckState.Unchecked;
        //        this.cb_printall.CheckState = CheckState.Unchecked;
        //    }



        //}

        //private void cb_fromcodetocode_CheckStateChanged(object sender, EventArgs e)
        //{
          
        //    if (this.cb_fromcodetocode.CheckState == CheckState.Checked)
        //    {
        //        this.cb_onlycode.CheckState = CheckState.Unchecked;
        //        this.cb_groupprit.CheckState = CheckState.Unchecked;
        //        this.cb_printall.CheckState = CheckState.Unchecked;
        //    }
          



        //}

        //private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
          
        //        this.cb_groupprit.CheckState = CheckState.Checked;
           

        //}

        //private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        //{
           
        //        this.cb_fromcodetocode.CheckState = CheckState.Checked;
          

        //}

        //private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    this.cb_fromcodetocode.CheckState = CheckState.Checked;

        //}

        //private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    this.cb_onlycode.CheckState = CheckState.Checked;

        //}

        //private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    this.cb_groupprit.CheckState = CheckState.Checked;

        //}

        //private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    this.cb_onlycode.CheckState = CheckState.Checked;

        //}

        //private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    this.cb_fromcodetocode.CheckState = CheckState.Checked;

        //}

        //private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    this.cb_fromcodetocode.CheckState = CheckState.Checked;
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //public int choice { get; set; }
        //    //     public float onlycode { get; set; }
        //    //     public float fromcode { get; set; }
        //    //     public float tocode { get; set; }
        //    if (cb_printall.CheckState == CheckState.Checked)
        //    {
        //        this.choice = 4;

        //        this.Close();

        //        //       MessageBox.Show(this.groupsending);
        //    }


        //    if (cb_groupprit.CheckState == CheckState.Checked)
        //    {
        //        this.choice = 1;

        //        if (this.input_groupcode.SelectedItem != null)
        //        {
        //            this.groupsending = this.input_groupcode.Text;


        //            this.Close();
        //        }
        //        else
        //        {

        //            MessageBox.Show("Please choose one Group to print !", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }


            
        //        //       MessageBox.Show(this.groupsending);
        //    }

        //    //   this.Close();
        //    if (cb_onlycode.CheckState == CheckState.Checked)
        //    {
        //        this.choice = 3;

        //        if (this.input_onlycode.SelectedItem != null)
        //        {
        //            this.onlycode = double.Parse((this.input_onlycode.SelectedItem as Viewtable.ComboboxItem).Value.ToString());
        //            this.Close();
        //        } 
        //        else
        //        {

        //            MessageBox.Show("Please choose one customer code !", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
          

        //        //    MessageBox.Show(this.onlycode.ToString());

               



        //    }
        //    if (cb_fromcodetocode.CheckState == CheckState.Checked)
        //    {
        //        this.choice = 0;

        //        if (Utils.IsValidnumber(this.input_fromcode.Text.Trim())&& Utils.IsValidnumber(this.input_tocode.Text.Trim()))
        //        {
        //            this.fromcode = double.Parse(this.input_fromcode.Text.Trim());
        //            this.tocode = double.Parse(this.input_tocode.Text.Trim());
        //            this.choice = 2;
        //        }
        //        else
        //        {

        //            MessageBox.Show("Code must be Number !", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }

        //        if (this.choice == 2)
        //        {

        //            if (this.fromcode <= this.tocode)
        //            {
        //                this.Close();
        //            }
        //            else
        //            {

        //                MessageBox.Show("Fromcode phải nhỏ hơn hoặc bằng tocode !", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }





                  
        //        }

              



        //    }



        //}

        //private void cb_printall_CheckStateChanged(object sender, EventArgs e)
        //{
        //    if (this.cb_printall.CheckState == CheckState.Checked)
        //    {
        //        this.cb_onlycode.CheckState = CheckState.Unchecked;
        //        this.cb_groupprit.CheckState = CheckState.Unchecked;
        //        //    this.cb_printall.CheckState = CheckState.Unchecked;
        //        this.cb_fromcodetocode.CheckState = CheckState.Unchecked;
        //    }
        //}
    }
}
