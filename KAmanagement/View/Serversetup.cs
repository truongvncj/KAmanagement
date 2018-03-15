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
    public partial class Serversetup : Form
    {
        public Serversetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\Connectstring.txt";

            if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {


                //   string[] names = new string[] { "Zara Ali", "Nuha Ali" };
                string s = textBox1.Text + ";" + textBox3.Text + ";" + textBox2.Text;
            
            using (StreamWriter sw = new StreamWriter(fileName))
            {

                    try
                    {
                        sw.WriteLine(s);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Không ghi được, file server lost !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
            }
                this.Close();  
            //  MessageBox.Show(s);
            }
        }

        private void Serversetup_Deactivate(object sender, EventArgs e)
        {
        //    this.Close();
        }
    }
}
