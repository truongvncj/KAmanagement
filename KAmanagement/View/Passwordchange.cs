using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class Passwordchange : Form
    {
        public Passwordchange()
        {
            InitializeComponent();

            txtusername.Text = Utils.getusername();
            txtusername.Enabled = false;
        }

        private void tbchangepass_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            //  string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
         

            var pasonsr = (from tbl_Temp in dc.tbl_Temps
                             where tbl_Temp.username.Trim() == txtusername.Text && tbl_Temp.password.Trim() == txtoldpass.Text
                           select tbl_Temp);

            if (pasonsr.Count() >0)
            {

                foreach (var item in pasonsr)
                {

              
                    if (txtoldpass.Text == item.password.Trim() && item.username.Trim() == txtusername.Text)
                    {

                        if (txtnewpass.Text == txtnewconfpass.Text)
                        {
                            item.password = txtnewconfpass.Text;
                            dc.SubmitChanges();
                            MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Please check new Password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }



                    }

                }
             //   MessageBox.Show(txtusername.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                MessageBox.Show("Please check Old Password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }

      
    }
}
