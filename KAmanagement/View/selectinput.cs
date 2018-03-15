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
    public partial class selectinput : Form
    {

        public string valuetext ;
        public bool kq;
        public string field;
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }



        public selectinput(String headcolumname, List<ComboboxItem> CombomCollection)
        {
            InitializeComponent();

            this.label1.Text = headcolumname;

            //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
            //         where tbl_Kafuctionlist.Code != "DIS"
            //         orderby tbl_Kafuctionlist.Code
            //         select tbl_Kafuctionlist;
            //foreach (var item2 in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item2.Code.Trim();
            //    cb.Text = item2.Code.Trim() + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
            //    CombomCollection.Add(cb);
            //}


            cbselect.DataSource = CombomCollection;
            this.kq = false;

        }

        private void valueinput_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //     item.PayType = (cb_program.SelectedItem as ComboboxItem).Value.ToString();

            if (cbselect != null && cbselect.SelectedValue != null)  // update prograne -- cai nay 
            {
                this.valuetext = (cbselect.SelectedItem as ComboboxItem).Value.ToString();
                this.field = this.label1.Text;
                this.kq = true;
                this.Hide();

            }
            else
            {
                MessageBox.Show("Please select a value !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }

           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }
    }
}
