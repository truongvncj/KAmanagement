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
    public partial class kAselectregiontodelete : Form
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


        public kAselectregiontodelete()
        {
            InitializeComponent();

            this.cbfuctionchoice.DropDownWidth = 230;
            cbfuctionchoice.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            var typeff = typeof(Tka_RightContracttypeview);
            VInputchange inputcdata = new VInputchange("", "LIST CONTRACT TYPE VIEW RIGHT", db, "Tka_RightContracttypeview", "Tka_RightContracttypeview", typeff, typeff, "id", "id", "");
            inputcdata.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            var typeff = typeof(Tka_RegionRight);
            VInputchange inputcdata = new VInputchange("", "LIST EDIT REGION VIEW RIGHT", db, "Tka_RegionRight", "Tka_RegionRight", typeff, typeff, "id", "id", "");
            inputcdata.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kAuserRightsetup_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cbfuctionchoice_SelectedIndexChanged(object sender, EventArgs e)
        {

            //  String prdgroup = (cb_prductGRp.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //     MessageBox.Show(prdgroup);
            // cbfuctionchoice  =0 la contract  =1 la region
       
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            if (cbfuctionchoice.SelectedIndex == 0 ) // contracttype
            {
                this.userchoice.Items.Clear();// = null;
                var rs6 = from tbl_Temp in dc.tbl_Temps
                              //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
                          select tbl_Temp.username;
                foreach (var item in rs6)
                {
                    this.userchoice.Items.Add(item);
                }

                this.userchoice.DropDownWidth = 230;

                //   cbfuctionchoice.SelectedIndex = 0;
                  userchoice.SelectedIndex = 0;
                ////  this.dataGridView1.DataSource = rs;
                string username = userchoice.Text;

                var rs = from tbl_kacontracttype in dc.tbl_kacontracttypes
                         select tbl_kacontracttype.Contractype;

                System.Data.DataTable dt = new System.Data.DataTable();
                Utils ut = new Utils();

                dt = ut.ToDataTable(dc, rs);
                dt.Columns.Add(new DataColumn("Authourise", typeof(Boolean)));

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dataGridView1.DataSource = dt;

                dataGridView1.Columns["Contractype"].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                //    dataGridView1

                for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
                {
                    #region kiem tra neu có trong data grivew bang cguyen qua true
                    string Contracttype = dataGridView1.Rows[idrow].Cells["Contractype"].Value.ToString();

                    var rs2 = (from Tka_RightContracttypeview in dc.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username && Tka_RightContracttypeview.Contracttype == Contracttype
                               select Tka_RightContracttypeview.Contracttype).FirstOrDefault();


                    if (rs2 != null)
                    {
                        dataGridView1.Rows[idrow].Cells["Authourise"].Value = true;
                    }

                    #endregion
                }



            }

            if (cbfuctionchoice.SelectedIndex ==1  ) // là region
            {
                this.userchoice.Items.Clear();// = null;
                var rs6 = from tbTka_RegionRight in dc.Tka_RegionRights
                           group tbTka_RegionRight by tbTka_RegionRight.RegionCode into g
                          select g.Key;
                foreach (var item in rs6)
                {
                    this.userchoice.Items.Add(item);
                }

                this.userchoice.DropDownWidth = 230;

                //     cbfuctionchoice.SelectedIndex = 0;
                //   userchoice.SelectedIndex = 0;
                userchoice.SelectedIndex = 0;
                ////  this.dataGridView1.DataSource = rs;
                string regioncode = userchoice.Text;

                var rs = from tbl_karegion in dc.tbl_karegions
                         select tbl_karegion.Region;

                System.Data.DataTable dt = new System.Data.DataTable();
                Utils ut = new Utils();

                dt = ut.ToDataTable(dc, rs);
                dt.Columns.Add(new DataColumn("Authourise", typeof(Boolean)));

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dataGridView1.DataSource = dt;

                dataGridView1.Columns["Region"].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                //    dataGridView1

                for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
                {
                    #region kiem tra neu có trong data grivew bang cguyen qua true
                    string Region = dataGridView1.Rows[idrow].Cells["Region"].Value.ToString();

                    var rs2 = (from tbTka_RegionRight in dc.Tka_RegionRights
                               where tbTka_RegionRight.RegionCode == regioncode && tbTka_RegionRight.Region == Region
                               select tbTka_RegionRight.Region).FirstOrDefault();
                    if (rs2 != null)
                    {
                        dataGridView1.Rows[idrow].Cells["Authourise"].Value = true;
                    }

                    #endregion
                }




            }


            //var rs = from tbl_kaProductlist in dc.tbl_kaProductlists
            //             //      join tbl_kaProductGRDetail in dc.tbl_kaProductGRDetails on tbl_kaProductlist.MatNumber equals tbl_kaProductGRDetail.MatNumber

            //         select new

            //         {
            //             tbl_kaProductlist.MatNumber,
            //             tbl_kaProductlist.MatText,


            //             //  InGroup = false,




            //         };
            ////  this.dataGridView1.DataSource = rs;
            //System.Data.DataTable dt = new System.Data.DataTable();
            //Utils ut = new Utils();



            //dt = ut.ToDataTable(dc, rs);

            //dt.Columns.Add(new DataColumn("Authourise", typeof(Boolean)));


            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //this.dataGridView1.DataSource = dt;

            //dataGridView1.Columns["MatNumber"].ReadOnly = true;
            //dataGridView1.Columns["MatText"].ReadOnly = true;



            //for (int idrow = 0; idrow < dataGridView1.RowCount - 1; idrow++)
            //{
            //    #region kiem tra neu có trong data grivew bang cguyen qua true
            //    string MatNumber = dataGridView1.Rows[idrow].Cells["MatNumber"].Value.ToString();

            //    var rs2 = (from tbl_kaProductGRDetail in dc.tbl_kaProductGRDetails
            //               where tbl_kaProductGRDetail.PrdGrp == prdgroup && tbl_kaProductGRDetail.MatNumber == MatNumber
            //               select tbl_kaProductGRDetail.MatNumber).FirstOrDefault();
            //    if (rs2 != null)
            //    {
            //        dataGridView1.Rows[idrow].Cells["InGroup"].Value = true;
            //    }

            //    #endregion
            //}




        }

        private void userchoice_SelectedValueChanged(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            if (cbfuctionchoice.SelectedIndex == 0) // contracttype
            {
                #region
                string username = userchoice.Text;

                var rs = from tbl_kacontracttype in dc.tbl_kacontracttypes
                         select tbl_kacontracttype.Contractype;

                System.Data.DataTable dt = new System.Data.DataTable();
                Utils ut = new Utils();

                dt = ut.ToDataTable(dc, rs);
                dt.Columns.Add(new DataColumn("Authourise", typeof(Boolean)));

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dataGridView1.DataSource = dt;

                dataGridView1.Columns["Contractype"].ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;

                //    dataGridView1

                for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
                {
                    #region kiem tra neu có trong data grivew bang cguyen qua true
                    string Contracttype = dataGridView1.Rows[idrow].Cells["Contractype"].Value.ToString();

                    var rs2 = (from Tka_RightContracttypeview in dc.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username && Tka_RightContracttypeview.Contracttype == Contracttype
                               select Tka_RightContracttypeview.Contracttype).FirstOrDefault();
                    if (rs2 != null)
                    {
                        dataGridView1.Rows[idrow].Cells["Authourise"].Value = true;
                    }

                    #endregion
                }


                #endregion

            }

            if (cbfuctionchoice.SelectedIndex == 1) // contracttype
            {
                #region
                string regioncode = userchoice.Text;

            var rs = from tbl_karegion in dc.tbl_karegions
                     select tbl_karegion.Region;

            System.Data.DataTable dt = new System.Data.DataTable();
            Utils ut = new Utils();

            dt = ut.ToDataTable(dc, rs);
            dt.Columns.Add(new DataColumn("Authourise", typeof(Boolean)));

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.DataSource = dt;

            dataGridView1.Columns["Region"].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            //    dataGridView1

            for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
            {
                #region kiem tra neu có trong data grivew bang cguyen qua true
                string Region = dataGridView1.Rows[idrow].Cells["Region"].Value.ToString();

                var rs2 = (from tbTka_RegionRight in dc.Tka_RegionRights
                           where tbTka_RegionRight.RegionCode == regioncode && tbTka_RegionRight.Region == Region
                           select tbTka_RegionRight.Region).FirstOrDefault();
                if (rs2 != null)
                {
                    dataGridView1.Rows[idrow].Cells["Authourise"].Value = true;
                }

                #endregion
            }



                #endregion
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            if (cbfuctionchoice.SelectedIndex == 0) // contracttype
            {

                string username = userchoice.Text;

                var rs = from Tka_RightContracttypeview in dc.Tka_RightContracttypeviews
                         where Tka_RightContracttypeview.UserName == username
                           select Tka_RightContracttypeview;
                dc.Tka_RightContracttypeviews.DeleteAllOnSubmit(rs);
                dc.SubmitChanges();

                for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
                {
                    #region kiem tra neu có trong data grivew bang cguyen qua true
                    string Contracttype = dataGridView1.Rows[idrow].Cells["Contractype"].Value.ToString();
                    //Boolean Authourise = (Boolean)dataGridView1.Rows[idrow].Cells["Authourise"].Value;

                    if (dataGridView1.Rows[idrow].Cells["Authourise"].Value.ToString() == "True")
                    {
                        Tka_RightContracttypeview item = new Tka_RightContracttypeview();
                        item.UserName = username;
                        item.Contracttype = Contracttype;
                        dc.Tka_RightContracttypeviews.InsertOnSubmit(item);
                        dc.SubmitChanges();



                    }


              
                    #endregion
                }


                MessageBox.Show("Update right done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }



            if (cbfuctionchoice.SelectedIndex == 1) // region
            {
                string regioncode = userchoice.Text;

                var rs = from Tka_RegionRight in dc.Tka_RegionRights
                         where Tka_RegionRight.RegionCode == regioncode
                         select Tka_RegionRight;
                dc.Tka_RegionRights.DeleteAllOnSubmit(rs);
                dc.SubmitChanges();

                for (int idrow = 0; idrow < dataGridView1.RowCount ; idrow++)
                {
                    #region kiem tra neu có trong data grivew bang cguyen qua true
                    string Region = dataGridView1.Rows[idrow].Cells["Region"].Value.ToString();
                    
                    if (dataGridView1.Rows[idrow].Cells["Authourise"].Value.ToString() == "True")
                    {
                        Tka_RegionRight item = new Tka_RegionRight();
                        item.RegionCode = regioncode;
                        item.Region = Region;
                        dc.Tka_RegionRights.InsertOnSubmit(item);
                        dc.SubmitChanges();



                    }



                    #endregion
                }


                MessageBox.Show("Update right done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }




        }
    }
}
