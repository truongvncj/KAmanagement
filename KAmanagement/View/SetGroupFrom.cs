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
    public partial class SetGroupFrom : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public System.Type Typeofftable { get; set; }
        public BindingSource source1;
        public List<ComboboxItem> GetcomboudataPRDGr()
        {




            List<ComboboxItem> dataCollection = new List<ComboboxItem>();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region lấy tên từ tbl tbl_kaPrdgrp

            var rs = from tbl_kaPrdgrp in dc.tbl_kaPrdgrps
                         //  where tbl_kaPrdgrp.PrdGrp != "ALL"
                     select tbl_kaPrdgrp;
            //{
            //    Customer = g.Key,
            //    Name_1 = g.Select(gg => gg.Name_1).FirstOrDefault()

            //};



            if (rs.Count() > 0)
            {


                foreach (var item in rs)
                {
                    string drowdowvalue = "";

                    drowdowvalue = item.PrdGrp.ToString() + " : " + item.ProductGroup + " " + item.WStatement;


                    ComboboxItem itemcb = new ComboboxItem();
                    itemcb.Text = drowdowvalue;
                    itemcb.Value = item.PrdGrp.ToString();



                    dataCollection.Add(itemcb);

                }


            }
            #endregion



            return dataCollection;
        }



        public string formname { get; set; }
        public SetGroupFrom(string fornname)
        {
            InitializeComponent();
            this.formname = fornname;


            this.Text = fornname;
            #region "PRODUCT GROUP MEMBER")


            if (this.formname == "PRODUCT GROUP MEMBER")
            {

                #region  adn procutc group vào combound

                //    cb_prductGRp
                #region  add to only customer fill

                List<ComboboxItem> lisdat = GetcomboudataPRDGr();
                if (lisdat != null)
                {
                    this.cb_prductGRp.DropDownStyle = ComboBoxStyle.DropDown;

                    foreach (var item in lisdat)
                    {

                        this.cb_prductGRp.Items.Add(item);

                    }




                }

                #endregion



                #endregion




            }
            // if (fornname == "PRODUCT GROUP MEMBER")
            #endregion

        }




        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cb_prductGRp_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cb_prductGRp_SelectedValueChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("OK");
            //  dataGridView1



            String prdgroup = (cb_prductGRp.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //     MessageBox.Show(prdgroup);
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = from tbl_kaProductlist in dc.tbl_kaProductlists
                         //      join tbl_kaProductGRDetail in dc.tbl_kaProductGRDetails on tbl_kaProductlist.MatNumber equals tbl_kaProductGRDetail.MatNumber

                     select new

                     {
                         tbl_kaProductlist.MatNumber,
                         tbl_kaProductlist.MatText,


                         //  InGroup = false,




                     };
            //  this.dataGridView1.DataSource = rs;
            System.Data.DataTable dt = new System.Data.DataTable();
            Utils ut = new Utils();



            dt = ut.ToDataTable(dc, rs);

            dt.Columns.Add(new DataColumn("InGroup", typeof(Boolean)));


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.DataSource = dt;

            dataGridView1.Columns["MatNumber"].ReadOnly = true;
            dataGridView1.Columns["MatText"].ReadOnly = true;



            for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
            {
                #region kiem tra neu có trong data grivew bang cguyen qua true
                string MatNumber = dataGridView1.Rows[idrow].Cells["MatNumber"].Value.ToString();

                var rs2 = (from tbl_kaProductGRDetail in dc.tbl_kaProductGRDetails
                           where tbl_kaProductGRDetail.PrdGrp == prdgroup && tbl_kaProductGRDetail.MatNumber == MatNumber
                           select tbl_kaProductGRDetail.MatNumber).FirstOrDefault();
                if (rs2 != null)
                {
                    dataGridView1.Rows[idrow].Cells["InGroup"].Value = true;
                }

                #endregion
            }













        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            //  string ContractNo = Contractno;
            string prdgroup = (cb_prductGRp.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region    //   xoa datavolume conytrac
            dc.ExecuteCommand("DELETE FROM tbl_kaProductGRDetail Where  tbl_kaProductGRDetail.PrdGrp = '" + prdgroup + "'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            #endregion//   xoa datavolume conytrac


            for (int idrow = 0; idrow < dataGridView1.RowCount; idrow++)
            {
                #region kiem tra neu có trong data grivew bang cguyen qua true
        //    MessageBox.Show(dataGridView1.Rows[idrow].Cells["InGroup"].Value.ToString());
                if (dataGridView1.Rows[idrow].Cells["InGroup"].Value != null)
                {


                    if ((dataGridView1.Rows[idrow].Cells["InGroup"].Value.Equals(true)))
                    {
                        tbl_kaProductGRDetail items = new tbl_kaProductGRDetail();

                        items.MatNumber = dataGridView1.Rows[idrow].Cells["MatNumber"].Value.ToString();
                        items.MatText = dataGridView1.Rows[idrow].Cells["MatText"].Value.ToString();
                        items.PrdGrp = prdgroup;
                        dc.tbl_kaProductGRDetails.InsertOnSubmit(items);
                        dc.SubmitChanges();



                    }

                }
                #endregion
            }

            MessageBox.Show("Group update !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }
    }
}
