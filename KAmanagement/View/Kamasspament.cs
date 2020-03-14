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
    public partial class Kamasspament : Form
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

        public Boolean kqcheck { get; set; }




        public DataGridView Dtgridview;
        public List<ComboboxItem> dataCollectionaccount;

        public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
                                                      //1. Định nghĩa 1 delegate


        class datatoExport
        {
            public DataGridView dataGrid1 { get; set; }

        }

        public Kamasspament()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.kqcheck = false;




            if (this.gridviewmasspayment.Columns["ContractNo"] != null)
            {
                this.gridviewmasspayment.Columns["ContractNo"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                this.gridviewmasspayment.Columns["ContractNo"].DefaultCellStyle.BackColor = Color.LightYellow;


            }




        }


        void Control_KeyPress(object sender, KeyEventArgs e)
        {







        }






        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statusview_Click(object sender, EventArgs e)
        {

        }

        private void cbcontracttypefil_SelectedValueChanged(object sender, EventArgs e)
        {


            //          ReloadKASeachcontractype("", "", "", contractype);



        }





        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.kqcheck = false;

            Model.Contract ctrtemp = new Model.Contract();

            ctrtemp.inputempmasspayment();

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var masterlist = from p in dc.tbl_tempmasspayments
                             where p.Username == username
                             select p;


            gridviewmasspayment.DataSource = masterlist;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.kqcheck = true;

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

          
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var listbeffore = from p in dc.tbl_tempmasspayments
                                  where p.Username == username
                         //    && p.StatusNote != ""
                                  select p;

            foreach (var item in listbeffore)
            {
                item.StatusNote = "";
                dc.SubmitChanges();
            }

            #region  kiểm tra hợp đồng đã đúng chưa 
         
            #region Kiểm tra tten hop dong

            var q1 = from tempayment in dc.tbl_tempmasspayments
                     where tempayment.Username == username && !(from kadata in dc.tbl_kacontractdatas
                                                                select kadata.ContractNo
                                       ).Contains(tempayment.ContractNo)

                     select tempayment;


            if (q1.Count() != 0)
            {
                foreach (var item in q1)
                {
                    item.StatusNote = "Contract no sai, không có !";
                    dc.SubmitChanges();
                }

                this.kqcheck = false;
            }

            #endregion List các document có trong tblEDLP không có trong VAT


            #region Kiểm tra payid

            var q2 = from tempayment in dc.tbl_tempmasspayments
                     where tempayment.Username == username && !(from kadata in dc.tbl_kacontractsdatadetails
                                                                select kadata.PayID
                                       ).Contains(tempayment.PayID)

                     select tempayment;


            if (q2.Count() != 0)
            {

                foreach (var item in q2)
                {
                    item.StatusNote = "Payment Id không có !";
                    dc.SubmitChanges();
                }
                this.kqcheck = false;
            }

            #endregion List các document có trong tblEDLP không có trong VAT


            #region Kiểm tra payment có con tracn no mà payid thiếu hay thiếu số tiền reques

            var q3 = from tempayment in dc.tbl_tempmasspayments
                     where tempayment.Username == username &&
                     (tempayment.PaymentRequest == null || tempayment.PayID == null)
                     select tempayment;


            if (q3.Count() != 0)
            {

                foreach (var item in q3)
                {
                    item.StatusNote = "Payment request thiếu thông tin!";
                    dc.SubmitChanges();
                }
                this.kqcheck = false;
            }

            #endregion update hợp đồng về trạng thái mới nhất trước khi tính payment

     

            #endregion
            if (this.kqcheck == false)
            {
                var detaillisterror = from p in dc.tbl_tempmasspayments
                                      where p.Username == username
                                         && p.StatusNote != ""
                                      select p;

                if (detaillisterror.Count()>0)
                {

                    GridViewdetail.DataSource = detaillisterror;


                }
                else
                {
                    GridViewdetail.DataSource = null;
                }
            }

            if (this.kqcheck == true)
            {
                
                #region tính toán hợp đồng

                var q4 = (from tempayment in dc.tbl_tempmasspayments
                          where tempayment.Username == username


                          select tempayment.ContractNo).Distinct();

                foreach (var item in q4)
                {

                    Control.Control_ac.CaculationContractinSQLmaster(item);

                    Control_ac.CaculationContract(item); // tinhs toasn contract truo c khi view





                }


                #endregion


              
            }



        }

        private void button3_Click_3(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region  tính số tiền payment avaiable amount với các hợp đồng status note = ""
            var listbeffore = from p in dc.tbl_tempmasspayments
                              where p.Username == username
                                && p.StatusNote != ""
                              select p;

            foreach (var item in listbeffore)
            {
                //                item.StatusNote = "";
                //              dc.SubmitChanges();





            }

            #endregion
            #region tạo payment amount





            #endregion




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var listupdate1 = from p in dc.tbl_tempmastercontractmasscreates
                              where p.Username == username
                              select p;

            ctrex.exportExceldatagridtofile(listupdate1, dc, "DANH SÁCH HỢP ĐỒNG ");
        }
    }
}
