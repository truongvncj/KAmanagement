using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KAmanagement.shared;

namespace KAmanagement.View
{
    public partial class KaconvertProductdetail : Form
    {

          public string ContractNo { get; set; }
        public int contractitem { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public KaconvertProductdetail(string ContractNo, int contractitem)
        {
            InitializeComponent();
            this.ContractNo = ContractNo;
            this.contractitem = contractitem;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region load cb currency

            var rs2 = from tbl_kaProductlist in dc.tbl_kaProductlists


                      select tbl_kaProductlist;

          //  string drowdownshow = "";

            foreach (var item in rs2)
            {

                ////       List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                //var rs6 = from tbl_kaChannel in dc.tbl_kaChannels
                //              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                //          select tbl_kaChannel;

                //foreach (var item in rs6)
                //{
                    ComboboxItem cb = new ComboboxItem();
                    cb.Value = item.MatNumber;
                    cb.Text = item.MatNumber + " : " + item.MatText;
               //     this.cb_channel.Items.Add(cb); // CombomCollection.Add(cb);

             //   }


             




         //       drowdownshow = item;
                this.cbproduct.Items.Add(cb);
           //     this.cbproduct.Items.Add(drowdownshow);



                this.cbconvertproduct.Items.Add(cb);
             //   this.cbconvertproduct.Items.Add(drowdownshow);


            }
            this.cbproduct.SelectedIndex = 0;
            this.cbconvertproduct.SelectedIndex = 0;
            this.cbproduct.DropDownWidth = 430;
            this.cbconvertproduct.DropDownWidth = 430;
            #endregion

            // view detail datagview

            var contractproductconvert = from tbl_kaConvertProductlist in dc.tbl_kaConvertProductlists
                                         where tbl_kaConvertProductlist.ContractNo == ContractNo
                                         && tbl_kaConvertProductlist.PayID == contractitem
                                         select tbl_kaConvertProductlist;


            this.dataGridView1.DataSource = contractproductconvert;






            //viewdetail datagview


        }

        private void bt_add_Click(object sender, EventArgs e)
        {
        //    (cb_delivery.SelectedItem as ComboboxItem).Value.ToString()
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            tbl_kaConvertProductlist convertbetail = new tbl_kaConvertProductlist();


            if (Utils.IsValidnumber(this.textbrate.Text) == true)
            {

                if (this.cbproduct.SelectedItem != null)
                {
                    //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                    convertbetail.MatNumber = (cbproduct.SelectedItem as ComboboxItem).Value.ToString();// cbproduct.SelectedItem.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                }
                else
                {
                    MessageBox.Show("Please select a product ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     tbl_kacontractsdatadetaillist = null;
                    //     newcontract = null;
                    return;
                }


                if (this.cbconvertproduct.SelectedItem != null)
                {
                    //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                    convertbetail.ConverttoMatNumber = (cbconvertproduct.SelectedItem as ComboboxItem).Value.ToString();// cbconvertproduct.SelectedItem.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                }
                else
                {
                    MessageBox.Show("Please select a product ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     tbl_kacontractsdatadetaillist = null;
                    //     newcontract = null;
                    return;
                }


                //

                var contractproductconvert3 = from tbl_kaConvertProductlist in dc.tbl_kaConvertProductlists
                                             where tbl_kaConvertProductlist.ContractNo == ContractNo
                                             && tbl_kaConvertProductlist.PayID == contractitem
                                             && tbl_kaConvertProductlist.MatNumber == cbproduct.SelectedItem.ToString()
                                              select tbl_kaConvertProductlist.MatNumber;

                if (contractproductconvert3.Count() >0)
                {
                    MessageBox.Show("Duplicate product, Please check product !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     tbl_kacontractsdatadetaillist = null;
                    //     newcontract = null;
                    return;
                }

                ///



                convertbetail.Remark = textremark.Text;
                convertbetail.ContractNo = ContractNo;
                convertbetail.PayID = contractitem;

                convertbetail.ConvertRate = double.Parse(this.textbrate.Text.ToString());



                dc.tbl_kaConvertProductlists.InsertOnSubmit(convertbetail);
                dc.SubmitChanges();


                // view detail datagview

                var contractproductconvert = from tbl_kaConvertProductlist in dc.tbl_kaConvertProductlists
                                             where tbl_kaConvertProductlist.ContractNo == ContractNo
                                             && tbl_kaConvertProductlist.PayID == contractitem
                                             select tbl_kaConvertProductlist;


                this.dataGridView1.DataSource = contractproductconvert;






                //viewdetail datagview


                this.textbrate.Text = "";

                this.textremark.Text = "";






            }
            else
            {
                MessageBox.Show("please check rate to convert ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //     tbl_kacontractsdatadetaillist = null;
                //     newcontract = null;
                return;
            }







        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var contractproductconvert = from tbl_kaConvertProductlist in dc.tbl_kaConvertProductlists
                                         where tbl_kaConvertProductlist.ContractNo == ContractNo
                                         && tbl_kaConvertProductlist.PayID == contractitem
                                         select tbl_kaConvertProductlist;
            
            dc.tbl_kaConvertProductlists.DeleteAllOnSubmit(contractproductconvert);
            dc.SubmitChanges();

            // view detail datagview

            var contractproductconvert2 = from tbl_kaConvertProductlist in dc.tbl_kaConvertProductlists
                                         where tbl_kaConvertProductlist.ContractNo == ContractNo
                                         && tbl_kaConvertProductlist.PayID == contractitem
                                         select tbl_kaConvertProductlist;


            this.dataGridView1.DataSource = contractproductconvert2;






            //viewdetail datagview


        }
    }
}
