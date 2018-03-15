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
    public partial class KafromtoSelect : Form
    {

        //  public string priod { get; set; }
        public   Boolean choose { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }

        public KafromtoSelect()
        {
            InitializeComponent();
            fromdate = pkfromdate.Value;
            todate = pk_todate.Value;
            choose = false;
        }

      
        private void bt_thuchien_Click(object sender, EventArgs e)
        {
       


            if (pkfromdate.Value > pk_todate.Value)
            {
                MessageBox.Show("Please, Fromdate phải nhỏ hơn hoặc bằng Todate !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                fromdate = pkfromdate.Value;
                todate = pk_todate.Value;
                choose = true;
                this.Close();
            }

          

            
        }

        private void bl_priod_Click(object sender, EventArgs e)
        {

        }

        private void pkfromdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
