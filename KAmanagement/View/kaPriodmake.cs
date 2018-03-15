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
    public partial class kaPriodmake : Form
    {

        public string priod { get; set; }
        public kaPriodmake()
        {
            InitializeComponent();

            cb_year.SelectedIndex = 1;
            cb_month.SelectedIndex = 0;
            bl_priod.Text = StringExtensions.Right(cb_year.Text, 2) + cb_month.Text;
            priod = null;
        }

        private void cb_year_SelectedValueChanged(object sender, EventArgs e)
        {
            bl_priod.Text = StringExtensions.Right(cb_year.Text,2) + cb_month.Text ;
        }

        private void cb_month_SelectedValueChanged(object sender, EventArgs e)
        {
            bl_priod.Text = StringExtensions.Right(cb_year.Text, 2) + cb_month.Text;
        }

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
            priod = bl_priod.Text;

            // check xem trong region da có chua, có thì hỏi repleace và update
         //   priodtb.fromdate = pkfromdate.Value;

       //     priodtb.todate = pk_todate.Value;

            //kiểm tra nếu fromdate nhỏ hơn to date
            if (pkfromdate.Value > pk_todate.Value)
            {
                MessageBox.Show("Please, Fromdate phải nhỏ hơn hoặc bằng Todate !");
                return;
            }


            //

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_Kapriod in dc.tbl_Kapriods
                     where tbl_Kapriod.Priod == priod
                     select tbl_Kapriod;


       
            if (rs.Count() >0)
            {
                // đã có bảng đó rồi

                DialogResult kq1 = MessageBox.Show(" Priod : "+ priod + " đã tồn tại, xóa thay bằng bản mới ?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // bool kq;
                switch (kq1)
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:


                        //   this.updateNewAllToolStripMenuItem.Enabled = false;
                        //   this.reportsToolStripMenuItem.Enabled = false;

                        foreach (var item in rs)
                        {


                            item.Priod = priod;
                            item.fromdate = pkfromdate.Value;

                            item.todate = pk_todate.Value;
                            item.block = false;
                            dc.SubmitChanges();

                        }
                      

                        this.Close();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
                

            }
            else
            {
                // update vào rồi đóng
                tbl_Kapriod priodtb = new tbl_Kapriod();
                priodtb.Priod = priod;
                priodtb.fromdate = pkfromdate.Value;
                priodtb.block = false;
                priodtb.todate = pk_todate.Value;

                dc.tbl_Kapriods.InsertOnSubmit(priodtb);
                dc.SubmitChanges();

                this.Close();
            }
            //check

            
        }

        private void bl_priod_Click(object sender, EventArgs e)
        {

        }

        private void pkfromdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
