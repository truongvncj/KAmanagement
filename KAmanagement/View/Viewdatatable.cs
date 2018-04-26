using KAmanagement.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KAmanagement.View
{
    public partial class Viewdatatable : Form
    {

        public string valuecode { get; set; }
        public string region { get; set; }
        public bool chon { get; set; }
        public Viewdatatable(System.Data.DataTable tbl, string fornname)
        {
            InitializeComponent();

            label7.Text = fornname;

            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt = tbl;
            this.dataGridView1.DataSource = tbl;

            valuecode = "0";
            chon = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {




                if (this.dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    valuecode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Customer"].Value.ToString();


                    region = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Region"].Value.ToString();

                    chon = true;

                    this.Close();
                }



            }
            else
            {
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
