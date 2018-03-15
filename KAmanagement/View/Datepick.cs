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
    public partial class Datepick : Form
    {

        public DateTime accrualdate { get; set; }

        public bool chon { get; set; }
        public Datepick(string label)
        {
            InitializeComponent();
            fromdatePicker.Value = DateTime.Today;
            accrualdate = fromdatePicker.Value;
            chon = false;
            this.Text = label;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {


            accrualdate = fromdatePicker.Value;
            

          //  if (accrualdate >= DateTime.Today)
           // {
                chon = true;
                this.Hide();
            //}


        }

        private void Datepick_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            chon = false;
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
