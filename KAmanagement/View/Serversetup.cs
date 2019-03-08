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


            //      string s = textBox1.Text + ";" + textBox3.Text + ";" + textBox2.Text;
            
            //using (StreamWriter sw = new StreamWriter(fileName))
            //{

            //        try
            //        {
            //            sw.WriteLine(s);
            //        }
            //        catch (Exception)
            //        {

            //            MessageBox.Show("Không ghi được, file server lost !","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
                   
            //}


                #region ghi vao data pass, user, connectstring

                string s1 = textBox1.Text + ";" + textBox3.Text + ";" + textBox2.Text;

             //   string s1 = st1 + ";" + st2 + ";" + st3 + ";" + textBox1.Text;

                //   string s1 = st1 + ";" + st2 + ";" + st3 + ";" + st4 + ";" + textBox1.Text;

                Model.SercurityFucntion bm = new Model.SercurityFucntion();
                string s2 = bm.Encryption(s1);

                bm.WritestringtoFile(fileName, s2);

                #endregion






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
