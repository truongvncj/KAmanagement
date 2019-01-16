using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using KAmanagement.shared;
using KAmanagement.View;
using System.Threading;

using System.Net;
using System.Data.SqlClient;
using System.Data;

//KAmanagement.LinqtoSQLDataContext

namespace KAmanagement.Control
{
    class Control_ac
    {


        //  public bool checkVATnameanddtodata()
        //  {



        //      // kiểm tra xem khachs hangf trong vat out da co trong master data ?? da co trong data chua, neu chua co thi add
        //      //   tblVat vat = new tblVat();
        //      //  tblCustomer cust = new tblCustomer();
        //      //        updateVATstatinmaster


        //      #region  updateVATstatinmaster ra TREN SQL da  viet ok
        //      SqlConnection conn2 = null;
        //      SqlDataReader rdr1 = null;

        //      string destConnString = Utils.getConnectionstr();
        //      try
        //      {

        //          conn2 = new SqlConnection(destConnString);
        //          conn2.Open();
        //          SqlCommand cmd1 = new SqlCommand("updateVATstatinmaster", conn2);
        //          cmd1.CommandType = CommandType.StoredProcedure;
        //          //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //          rdr1 = cmd1.ExecuteReader();



        //          //       rdr1 = cmd1.ExecuteReader();

        //      }
        //      finally
        //      {
        //          if (conn2 != null)
        //          {
        //              conn2.Close();
        //          }
        //          if (rdr1 != null)
        //          {
        //              rdr1.Close();
        //          }
        //      }
        //      //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //      #endregion

        //      string connection_string = Utils.getConnectionstr();
        //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //      db.ExecuteCommand("DELETE FROM tblCustomerTmp");
        //      //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //      db.SubmitChanges();

        //      LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



        //      #region  insert into  tblCustomerTmp tempcust = new tblCustomerTmp(); where      where tblVat.Statuscheck == false// true// false
        //     // SqlConnection conn2 = null;
        //   //   SqlDataReader rdr1 = null;

        ////      string destConnString = Utils.getConnectionstr();
        //      try
        //      {

        //          conn2 = new SqlConnection(destConnString);
        //          conn2.Open();
        //          SqlCommand cmd1 = new SqlCommand("inserttblvatstatusfalseintblCustomerTmp", conn2);
        //          cmd1.CommandType = CommandType.StoredProcedure;
        //          //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //          rdr1 = cmd1.ExecuteReader();



        //      }
        //      finally
        //      {
        //          if (conn2 != null)
        //          {
        //              conn2.Close();
        //          }
        //          if (rdr1 != null)
        //          {
        //              rdr1.Close();
        //          }
        //      }
        //      //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //      #endregion





        //      var q = from tblCustomerTmp in dc.tbl_KaCustomertemps
        //              select tblCustomerTmp;

        //      if (q.Count()>0)
        //      {



        //         var typeffmain = typeof(tbl_KaCustomer);
        //          var typeffsub = typeof(tbl_KaCustomertemp);
        //          //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //          View.VInputchange inputcdata = new View.VInputchange("MASTER DATA CUSTOMER ", "LIST CUST IN VATOUT BUT NOT IN CUST MASTER", db, "tbl_KaCustomer", "tblCustomerTmp", typeffmain, typeffsub,"id", "id","");
        //          inputcdata.Visible = false;
        //          inputcdata.ShowDialog();
        //          //   Viewtable viewtbl = new Viewtable(q, dc, "List customer có trong VAT out không có trong master customer data !");

        //          return false;

        //      }
        //      else
        //      {
        //          return true;

        //      }


        //  }


        //public bool checkVATandFBL5n()
        //{

        //    tblFBL5N fb5 = new tblFBL5N();
        //    tblVat vat = new tblVat();
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //    //     updatetblFBL5NnewthisperiodFromOM


        //    #region  updatetblFBL5NnewthisperiodFromOM ra TREN SQL dang viet 
        //    SqlConnection conn2 = null;
        //    SqlDataReader rdr1 = null;

        //    string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updatetblFBL5NnewthisperiodFromOM", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }

        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion




        //    //#region q4 List các document có trong FBL5n đã update data

        //    //var q4 = from tblFBL5N in dc.tblFBL5Ns
        //    //         from tblFBL5Nnew in dc.tblFBL5Nnews
        //    //         where (tblFBL5N.Document_Number == tblFBL5Nnew.Document_Number)
        //    //         select tblFBL5N;

        //    //if (q4.Count() != 0)
        //    //{


        //    //    Viewtable viewtbl = new Viewtable(q4, dc, "List các document có trong FBL5n đã update data ! Please check !");

        //    //    return false;
        //    //}
        //    //#endregion List các document có trong FBL5n đã update data



        //    //#region q List các document có trong bảng VAT không có trong bảng FBL5N !
        //    ////---
        //    //var q = from tblVat in dc.tblVats
        //    //        where !(from tblFBL5N in dc.tblFBL5Ns
        //    //                select tblFBL5N.Document_Number).Contains(tblVat.SAP_Invoice_Number)
        //    //        //Tương đương từ khóa NOT IN trong SQL
        //    //        select tblVat;



        //    //if (q.Count() != 0)
        //    //{

        //    //    Viewtable viewtbl = new Viewtable(q, dc, "List các document có trong bảng VAT không có trong bảng FBL5N ! Please check ");
        //    //    return false;
        //    //}

        //    //#endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !


        //    //#region  q5 List các document có trong bảng EDLP không có trong bảng FBL5n 
        //    //var q5 = from tblEDLP in dc.tblEDLPs
        //    //         where !(from tblFBL5N in dc.tblFBL5Ns
        //    //                 where tblFBL5N.Document_Type == "RV"
        //    //                 select tblFBL5N.Document_Number).Contains(tblEDLP.Invoice_Doc_Nr)
        //    //         //Tương đương từ khóa NOT IN trong SQL
        //    //         select tblEDLP;

        //    //if (q5.Count() != 0)
        //    //{
        //    //    // fbl5n_ctrl md = new fbl5n_ctrl();
        //    //    //var rs = md.product_select_all();
        //    //    Viewtable viewtbl = new Viewtable(q5, dc, "List các document có trong bảng EDLP không có trong bảng FBL5n ! Please check ");
        //    //    return false;
        //    //}


        //    //#endregion

        //    //#region q2 List các document có trong bảng FBL5N không có trong bảng VAT 

        //    //var q2 = from tblFBL5N in dc.tblFBL5Ns
        //    //         where !(from tblVat in dc.tblVats
        //    //                 select tblVat.SAP_Invoice_Number).Contains(tblFBL5N.Document_Number) && (tblFBL5N.Document_Type == "RV")
        //    //         //Tương đương từ khóa NOT IN trong SQL
        //    //         select tblFBL5N;

        //    //if (q2.Count() != 0)
        //    //{
        //    //    // fbl5n_ctrl md = new fbl5n_ctrl();
        //    //    //var rs = md.product_select_all();

        //    //    Viewtable viewtbl = new Viewtable(q2, dc, "List các document có trong bảng FBL5N không có trong bảng VAT ! Please check ");
        //    //    return false;
        //    //}

        //    //#endregion List các document có trong bảng FBL5N không có trong bảng VAT 


        //    //#region q3 List các document có trong tblEDLP không có trong VAT

        //    //var q3 = (from tblEDLP in dc.tblEDLPs
        //    //          group tblEDLP by tblEDLP.Invoice_Doc_Nr into OD//Tương đương GROUP BY trong SQL
        //    //          orderby OD.Key
        //    //          where !(from tblVat in dc.tblVats
        //    //                  select tblVat.SAP_Invoice_Number).Contains(OD.Key)

        //    //          select new
        //    //          {
        //    //              Document_Number = OD.Key,
        //    //              Name = OD.Select(m => m.Cust_Name).FirstOrDefault(),
        //    //              Value_Count = OD.Sum(m => m.Cond_Value)




        //    //          });

        //    //if (q3.Count() != 0)
        //    //{

        //    //    Viewtable viewtbl = new Viewtable(q3, dc, "List các document có trong tblEDLP không có trong VAT ! Please check !");
        //    //    return false;
        //    //}

        //    //#endregion List các document có trong tblEDLP không có trong VAT




        //    //#region Q6  // list cac customer có trong fbl5n khoogn có trogm master custoemr addd



        //    ////var q6 = from tblCustomerTmp in dc.tblCustomerTmps
        //    ////        select tblCustomerTmp;

        //    //var q6 = from tblFBL5N in dc.tblFBL5Ns
        //    //         where !(from tblCustomer in dc.tblCustomers
        //    //                 select tblCustomer.Customer).Contains(Convert.ToDouble(tblFBL5N.Account))
        //    //         //Tương đương từ khóa NOT IN trong SQL
        //    //         select tblFBL5N;




        //    //if (q6.Count() > 0)
        //    //{

        //    //    // InsertKeyMode vào tblCustomerTmp từ fbl5n
        //    //    // insertfromfbl5ntocustomerTemp


        //    //    Viewtable viewtbl = new Viewtable(q6, dc, "List các Customer có trong FBL5n không có master customer data ! Please check !");
        //    //    return false;

        //    //    //   Viewtable viewtbl = new Viewtable(q, dc, "List customer có trong VAT out không có trong master customer data !");

        //    //    //   return false;

        //    //}


        //    //#endregion




        //    //#region q7 product co trong edlp khong co trong product list


        //    //dc.ExecuteCommand("DELETE FROM tbl_kaProductlistTMP");

        //    //dc.SubmitChanges();


        //    //var q7 = from tblEDLP in dc.tblEDLPs
        //    //         where !(from tbl_kaProductlist in dc.tbl_kaProductlists
        //    //                 select tbl_kaProductlist.Mat_Number).Contains(tblEDLP.Mat_Number)
        //    //         group tblEDLP by tblEDLP.Mat_Number into gbg
        //    //         select new

        //    //         {
        //    //             Mat_Number = gbg.Key,
        //    //             Mat_Group = gbg.Select(gg => gg.Mat_Group).FirstOrDefault(),

        //    //             Mat_Text = gbg.Select(gg => gg.Mat_Text).FirstOrDefault(),

        //    //             Mat_Group_Text = gbg.Select(gg => gg.Mat_Group_Text).FirstOrDefault()


        //    //         };



        //    //if (q7.Count() != 0)
        //    //{

        //    //    foreach (var item in q7)
        //    //    {
        //    //        tbl_kaProductlistTMP prdtemp = new tbl_kaProductlistTMP();


        //    //        prdtemp.Mat_Number = item.Mat_Number;//.key;
        //    //        prdtemp.Mat_Group = float.Parse(item.Mat_Group);
        //    //        prdtemp.Mat_Text = item.Mat_Text;
        //    //        prdtemp.Mat_Group_Text = item.Mat_Group_Text;
        //    //        //  prdtemp.Empty_Group = 1;
        //    //        // prdtemp. = item.Mat_Number;
        //    //        //prdtemp.Mat_Number = item.Mat_Number;
        //    //        //prdtemp.Mat_Number = item.Mat_Number;
        //    //        //prdtemp.Mat_Number = item.Mat_Number;
        //    //        dc.tbl_kaProductlistTMPs.InsertOnSubmit(prdtemp);
        //    //        dc.SubmitChanges();



        //    //    }





        //    //    var typeff = typeof(tbl_kaProductlistTMP);

        //    //    VInputchange inputcdata = new VInputchange("PRODUCTS CODE MASTER DATA ", "LIST CUST NOT IN PRODUCT CODE MASTER DATA", dc, "tbl_kaProductlist", "tbl_kaProductlistTMP", typeff, "id", "id");
        //    //    inputcdata.Show();
        //    //    inputcdata.Focus();
        //    //    return false;
        //    //}



        //    //#endregion q7 product co trong edlp khong co trong product list


        //    //#region    q9// kiểm tra xem có số dư đầu kỳ không nếu không có bật ra bản thêm vào và kết thúc
        //    //dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
        //    ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    //dc.SubmitChanges();

        //    //var q9 = from tblFBL5N in dc.tblFBL5Ns
        //    //         where !(from tblFBL5beginbalace in dc.tblFBL5beginbalaces
        //    //                 select tblFBL5beginbalace.Account.ToString()+ tblFBL5beginbalace.Business_Area).Contains(tblFBL5N.Account+ tblFBL5N.Business_Area)
        //    //         //Tương đương từ khóa NOT IN trong SQL
        //    //         select tblFBL5N;



        //    //if (q9.Count() > 0)

        //    //{


        //    //    #region mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky nếu không có bắn ra bàng không có
        //    //    foreach (var tblFBL5Nd in q9)
        //    //    {

        //    //        tblFBL5beginbalaceTemp ntemp = new tblFBL5beginbalaceTemp();

        //    //      //  ntemp.codeGroup = tblFBL5Nd.Account;
        //    //        ntemp.Business_Area = tblFBL5Nd.Business_Area;
        //    //        ntemp.Account = double.Parse(tblFBL5Nd.Account);
        //    //        ntemp.Amount_in_local_currency = 0;
        //    //        ntemp.Binhpmicc02 = 0;
        //    //        ntemp.binhpmix9l = 0;
        //    //        ntemp.Chaivo1lit = 0;

        //    //        ntemp.Chaivothuong = 0;
        //    //        ntemp.Deposit_amount = 0;
        //    //        ntemp.Adjusted_amount = 0;
        //    //        ntemp.Empty_Amount = 0;
        //    //        ntemp.Empty_Amount_Notmach = 0;
        //    //        ntemp.Fullgood_amount = 0;
        //    //        ntemp.joy20l = 0;


        //    //        ntemp.Ketnhua1lit = 0;
        //    //        ntemp.Ketnhuathuong = 0;
        //    //        ntemp.Ketvolit = 0;
        //    //        ntemp.Ketvothuong = 0;

        //    //        ntemp.paletnhua = 0;
        //    //        ntemp.palletgo = 0;
        //    //        ntemp.Payment_amount = 0;





        //    //        dc.tblFBL5beginbalaceTemps.InsertOnSubmit(ntemp);
        //    //        dc.SubmitChanges();

        //    //    }



        //    //    var typeff = typeof(tblFBL5beginbalaceTemp);

        //    //    LinqtoSQLDataContext dbx = new LinqtoSQLDataContext(connection_string);


        //    //    View.VInputchange inputcdata = new View.VInputchange("MASTER BEGIN BALACE ", "LIST CUST NOT HAVE BEGIN BALACE, PLEASE CHECK ! ", dbx, "tblFBL5beginbalace", "tblFBL5beginbalaceTemp", typeff, "id", "id");
        //    //    inputcdata.Show();

        //    //    return false;
        //    //    #endregion mở update số dư dầu kỳ khi codegroupkhoong co trong so du dau ky



        //    //}

        //    ////  MessageBox.Show("ok");

        //    //#endregion  // kiểm tra xem có so du dau ky không



        //    //if (q.Count() + q2.Count() + q3.Count() + q4.Count() + q5.Count()  == 0) //+ q6.Count()  + q9.Count()  + q7.Count()
        //    //{
        //    //    //  MessageBox.Show("Great!, Data Ready for AR Confirmation reports !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}




        //}


        //class datatoExporterr
        //{
        //    public LinqtoSQLDataContext dc { get; set; }
        //    public IQueryable rs { get; set; }

        //}

        //void ThreadProc()
        //{
        //    //  myForm form = new myForm();

        //    Viewtable viewtbl = new Viewtable(q, dc, "Dữ liệu không up vào được do có các list doc sau đã updated ! ");

        //    globalForm.Invoke((MethodInvoker)delegate () {
        //        form.Text = "my text";
        //        form.Show();
        //    });
        //}
        //public void errorEXport(object objextoEl)
        //{


        //    //datatoExporterr dat = (datatoExporterr)objextoEl;
        //    //var q = dat.rs;
        //    //var dc = dat.dc;

        //    ////   MessageBox.Show("Dũ liệu không update được  ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    //Viewtable viewtbl = new Viewtable(q, dc, "Dữ liệu không up vào được do có các list doc sau đã updated ! ");

        //    //globalForm.Invoke((MethodInvoker)delegate () {
        //    //    viewtbl.Text = "Dữ liệu không up vào được do có các list doc sau đã updated !";
        //    //    viewtbl.Show();


        //}




        //public void ARlettermakebyGroupcodeRegionOld(LinqtoSQLDataContext db, DateTime fromdate, DateTime todate, DateTime returndate)
        //{
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    List<tbl_ColdetailRpt> tbl_ColdetailRptlist = new List<tbl_ColdetailRpt>();
        //    List<tbl_ArletterdetailRpt> tbl_ArletterdetailRptlist = new List<tbl_ArletterdetailRpt>();
        //    List<tbl_ARdetalheaderRpt> tbl_ARdetalheaderRptlist = new List<tbl_ARdetalheaderRpt>();

        //    List<tbl_ArletterRpt> tbl_ArletterRptlist = new List<tbl_ArletterRpt>();




        //    #region  updateCustgoupinListcustmakeRptregion ra TREN SQL dang viet 
        //    SqlConnection conn2 = null;
        //    SqlDataReader rdr1 = null;

        //    string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateCustgoupinListcustmakeRptRegion", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion



        //    #region // xóa ar belance begine temp cu để chuẩn bị cái mới
        //    //var betmp = from tblFBL5beginbalaceTemp in db.tblFBL5beginbalaceTemps
        //    //            select tblFBL5beginbalaceTemp;

        //    //if (betmp.Count() > 0)
        //    //{
        //    //    db.tblFBL5beginbalaceTemps.DeleteAllOnSubmit(betmp);
        //    //    db.SubmitChanges();
        //    //}

        //    #region // XÓA toàn bộ tblFBL5Nnewthisperiod
        //    dc.ExecuteCommand("DELETE FROM tblFBL5beginbalaceTemp");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();
        //    #endregion


        //    #endregion


        //    #region // xóa data AR letter data reports cũ



        //    //var rs2 = from tbl_ArletterRpt in db.tbl_ArletterRpts
        //    //          select tbl_ArletterRpt;


        //    //db.tbl_ArletterRpts.DeleteAllOnSubmit(rs2);

        //    //db.SubmitChanges();




        //    #region // XÓA toàn bộ tblFBL5Nnewthisperiod
        //    dc.ExecuteCommand("DELETE FROM tbl_ArletterRpt");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();
        //    #endregion

        //    #endregion        //   xóa data AR letter


        //    #region // xóa ar header cdata reports cũ
        //    //var rs6 = from tbl_ARdetalheaderRpt in db.tbl_ARdetalheaderRpts
        //    //          select tbl_ARdetalheaderRpt;
        //    //db.tbl_ARdetalheaderRpts.DeleteAllOnSubmit(rs6);
        //    //db.SubmitChanges();





        //    #region // XÓA toàn bộ tblFBL5Nnewthisperiod
        //    dc.ExecuteCommand("DELETE FROM tbl_ARdetalheaderRpt");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();
        //    #endregion


        //    #endregion// xóa ddataa cũ sau do update data mới


        //    #region // xóa col cũ data reports cũ
        //    //var rs7 = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
        //    //          select tbl_ColdetailRpt;
        //    //db.tbl_ColdetailRpts.DeleteAllOnSubmit(rs7);
        //    //db.SubmitChanges();




        //    #region // XÓA toàn bộ tblFBL5Nnewthisperiod
        //    dc.ExecuteCommand("DELETE FROM tbl_ColdetailRpt");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();
        //    #endregion
        //    #endregion// xóa ddataa cũ sau do update data mới


        //    #region // xóa ddataadetail data reports cũ
        //    //var rs3 = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
        //    //          select tbl_ArletterdetailRpt;
        //    //db.tbl_ArletterdetailRpts.DeleteAllOnSubmit(rs3);
        //    //db.SubmitChanges();


        //    #region // XÓA toàn bộ tblFBL5Nnewthisperiod
        //    dc.ExecuteCommand("DELETE FROM tbl_ArletterdetailRpt");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    dc.SubmitChanges();
        //    #endregion
        //    #endregion// xóa ddataa cũ sau do update data mới





        //    #region update beginbalece  customer group region để lọc ra TREN SQL dang viet 
        //    //   SqlConnection conn2 = null;
        //    //   SqlDataReader rdr1 = null;

        //    //  string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updatebeginBalacegruopRegion", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion





        //    #region update update Fbl5nnew  customer group để lọc ra để lọc ra TREN SQL dang viet 
        //    //   SqlConnection conn2 = null;
        //    //   SqlDataReader rdr1 = null;


        //    // Create the connection.
        //    using (SqlConnection connection = new SqlConnection(destConnString))
        //    {
        //        // Open the connection.
        //        connection.Open();

        //        // Create the command.
        //        using (SqlCommand command = new SqlCommand("updaFBL5nreportsBalacegroupRegion", connection))
        //        {
        //            // Set the command type.
        //            command.CommandType = System.Data.CommandType.StoredProcedure;

        //            // Add the parameter.
        //            SqlParameter parameter = command.Parameters.Add("@todate",
        //                System.Data.SqlDbType.DateTime);

        //            // Set the value.
        //            parameter.Value = todate;

        //            // Make the call.
        //            command.ExecuteNonQuery();
        //        }
        //    }





        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion




        //    #region update  update Freglasess  customer group để lọc ra trên sql
        //    //    SqlConnection conn2 = null;
        //    //   SqlDataReader rdr1 = null;

        //    //   string destConnString = Utils.getConnectionstr();
        //    try
        //    {

        //        conn2 = new SqlConnection(destConnString);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("updateFreglasessgroupREgion", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //        rdr1 = cmd1.ExecuteReader();



        //        //       rdr1 = cmd1.ExecuteReader();

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    #endregion




        ////    #region   // tính bàng tbl_ArletterRpt


        ////    var rsmain = from tblCustomer in dc.tblCustomers
        ////                 where tblCustomer.Reportsend == true
        ////                 select tblCustomer;

        ////   int stt = 0;
        ////    foreach (var tblCustomerv in rsmain)
        ////    {
        ////        tbl_ArletterRpt rptleter = new tbl_ArletterRpt();
        ////      //  stt = stt + 1;
        ////     //   rptleter.No = stt;
        ////        rptleter.address = tblCustomerv.Address;
        ////        rptleter.code = tblCustomerv.Customer;
        ////        //DateTime returndate;
        ////        rptleter.returndate = returndate;
        ////        rptleter.custcodegRoup = tblCustomerv.Cusromergroup;

        ////        rptleter.customername = tblCustomerv.Name_1;
        ////        rptleter.fromdate = fromdate;
        ////        rptleter.toDate = todate;
        ////        rptleter.phone = tblCustomerv.Telephone_1;
        ////        rptleter.region = tblCustomerv.SOrg;



        ////        rptleter.StringAmountEmpty = "";// tính tiếp ở dưới  strign stringemty;
        ////        int vothuong = 0;
        ////        int Chaivothuong = 0;
        ////        int Chaivo1lit = 0;
        ////        int Ketvolit = 0;
        ////        int Ketnhuathuong = 0;
        ////        int Ketnhua1lit = 0;
        ////        int joy20l = 0;
        ////        int Binhpmicc02 = 0;
        ////        int binhpmix9l = 0;
        ////        int palletgo = 0;
        ////        int paletnhua = 0;

        ////        rptleter.sumAmountfull = 0; //tính tblCustomerv.
        ////        rptleter.sumEmptydeposit = 0;  // tính em ty
        ////        rptleter.sumoffreeclass = 0;  // tính fress glasesse

        ////        #region //tính freeglasses vào 

        ////        var rsgl = from tbl_FreGlass in dc.tbl_FreGlasses
        ////                   where tbl_FreGlass.CUSTOMERgroupcode == tblCustomerv.Cusromergroup
        ////                   group tbl_FreGlass by tbl_FreGlass.CUSTOMERgroupcode into gr
        ////                   select gr;

        ////        foreach (var item in rsgl)
        ////        {
        ////            rptleter.sumoffreeclass = item.Sum(gr => gr.COLAMT);
        ////        }



        ////        #endregion // tính freeglasses vào


        ////        #region //tính sumEmptydeposit ps cộng đầu kỳ + số dư đầu vào 

        ////        var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                    where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
        ////                    group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
        ////                    select gr;
        ////        double sumAmountfulldkps = 0;
        ////        double sumEmptydepositdkps = 0;
        ////        double sumAmountfulldkbg = 0;
        ////        double sumEmptydepositdkbg = 0;

        ////        foreach (var item in rsemp)
        ////        {




        ////            sumAmountfulldkps = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
        ////            sumEmptydepositdkps = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ


        ////            vothuong = (int)item.Sum(m => m.Ketvothuong);
        ////            Chaivothuong = (int)item.Sum(m => m.Chaivothuong);
        ////            Chaivo1lit = (int)item.Sum(m => m.Chaivo1lit);
        ////            Ketvolit = (int)item.Sum(m => m.Ketvolit);
        ////            Ketnhuathuong = (int)item.Sum(m => m.Ketnhuathuong);
        ////            Ketnhua1lit = (int)item.Sum(m => m.Ketnhua1lit);
        ////            joy20l = (int)item.Sum(m => m.joy20l);
        ////            Binhpmicc02 = (int)item.Sum(m => m.Binhpmicc02);
        ////            binhpmix9l = (int)item.Sum(m => m.binhpmix9l);
        ////            palletgo = (int)item.Sum(m => m.palletgo);
        ////            paletnhua = (int)item.Sum(m => m.paletnhua);


        ////        }

        ////        // tính số dư đầu nữa




        ////        var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
        ////                   where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
        ////                   group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
        ////                   select gr;

        ////        foreach (var item in rsdk)
        ////        {

        ////            sumAmountfulldkbg =  (double)item.Sum(gr => gr.Fullgood_amount.GetValueOrDefault(0)); // phát sinh trong kỳ
        ////            sumEmptydepositdkbg = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ



        ////            vothuong = vothuong + (int)item.Sum(m => m.Ketvothuong);
        ////            Chaivothuong = Chaivothuong + (int)item.Sum(m => m.Chaivothuong);
        ////            Chaivo1lit = Chaivo1lit + (int)item.Sum(m => m.Chaivo1lit);
        ////            Ketvolit = Ketvolit + (int)item.Sum(m => m.Ketvolit);
        ////            Ketnhuathuong = Ketnhuathuong + (int)item.Sum(m => m.Ketnhuathuong);
        ////            Ketnhua1lit = Ketnhua1lit + (int)item.Sum(m => m.Ketnhua1lit);
        ////            joy20l = joy20l + (int)item.Sum(m => m.joy20l);
        ////            Binhpmicc02 = Binhpmicc02 + (int)item.Sum(m => m.Binhpmicc02);
        ////            binhpmix9l = binhpmix9l + (int)item.Sum(m => m.binhpmix9l);
        ////            palletgo = palletgo + (int)item.Sum(m => m.palletgo);
        ////            paletnhua = paletnhua + (int)item.Sum(m => m.paletnhua);



        ////        }


        ////        rptleter.sumAmountfull = sumAmountfulldkbg + sumAmountfulldkps; // phát sinh trong kỳ
        ////        rptleter.sumEmptydeposit = sumEmptydepositdkbg + sumEmptydepositdkps;

        ////        // tính số dư đầu nữa


        ////        String str = "";
        ////        if (vothuong != 0)
        ////        {

        ////            str = str + String.Format(vothuong.ToString(), "#,###") + " két vỏ thường; ";

        ////        }
        ////        if (Chaivothuong != 0)
        ////        {

        ////            str = str + String.Format(Chaivothuong.ToString(), "#,###")  + " chai vỏ thường; ";

        ////        }
        ////        if (Chaivo1lit != 0)
        ////        {

        ////            str = str + String.Format(Chaivo1lit.ToString(), "#,###")   + " chai vỏ 1 lít; ";

        ////        }
        ////        if (Ketvolit != 0)
        ////        {

        ////            str = str + String.Format(Ketvolit.ToString(), "#,###") + " Két vỏ 1 lít; ";

        ////        }
        ////        if (Ketnhuathuong != 0)
        ////        {

        ////            str = str + String.Format(Ketnhuathuong.ToString(), "#,###")  + " Két nhựa; ";

        ////        }
        ////        if (Ketnhua1lit != 0)
        ////        {

        ////            str = str + String.Format(Ketnhua1lit.ToString(), "#,###")  + " Két nhựa 1 lít; ";

        ////        }
        ////        if (joy20l != 0)
        ////        {

        ////            str = str + String.Format(joy20l.ToString(), "#,###")  + " Bình joy 20l; ";

        ////        }
        ////        if (Binhpmicc02 != 0)
        ////        {

        ////            str = str + String.Format(Binhpmicc02.ToString(), "#,###")  + " Bình postmix/CO2; ";

        ////        }
        ////        if (binhpmix9l != 0)
        ////        {

        ////            str = str + String.Format(binhpmix9l.ToString(), "#,###")  + " Bình Postmix9l; ";

        ////        }
        ////        if (palletgo != 0)
        ////        {

        ////            str = str + String.Format(palletgo.ToString(), "#,###")  + " Pallet gỗ; ";

        ////        }
        ////        if (paletnhua != 0)
        ////        {

        ////            str = str + String.Format(paletnhua.ToString(), "#,###")   + " Pallet nhựa; ";

        ////        }

        ////        if (str == "")
        ////        {
        ////            str = "Không nợ vỏ";
        ////        }
        ////        rptleter.StringAmountEmpty = str;// dòng chữ thể hiện số vỏ nợ


        ////        #endregion // tính freeglasses vào



        ////        if (rptleter.custcodegRoup != null)
        ////        {
        ////            // tbl_ArletterRptlist.Add(rptleter);
        ////            //
        ////            stt = stt + 1;
        ////            rptleter.No = stt;
        ////            tbl_ArletterRptlist.Add(rptleter);

        ////            //   db.tbl_ArletterRpts.InsertOnSubmit(rptleter);
        ////            //      db.SubmitChanges();



        ////        }




        ////    }

        ////    db.tbl_ArletterRpts.InsertAllOnSubmit(tbl_ArletterRptlist);
        ////    db.SubmitChanges();
        ////    #endregion   // tính bàng tbl_ArletterRpt



        ////    #region   //tính bảng detail reports     tbl_ArletterdetailRpt rpldetail = new tbl_ArletterdetailRpt();


        ////    var rsdETAIL2 = from tblCustomer in dc.tblCustomers
        ////                    where tblCustomer.Reportsend == true
        ////                    select tblCustomer;


        ////    foreach (var tblCustomerv in rsdETAIL2)
        ////    {

        ////        var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                    where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate && tblFBL5Nnew.Posting_Date >= fromdate
        ////                    // group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
        ////                    select tblFBL5Nnew;

        ////        foreach (var item in rsemp)
        ////        {




        ////            tbl_ArletterdetailRpt rpldetail = new tbl_ArletterdetailRpt();

        ////            //      rpldetail.amountinloca = item.Fullgood_amount; // full amount
        ////            rpldetail.customergroup = item.codeGroup;

        ////            rpldetail.Depositamount = 0;// depossit amount
        ////            rpldetail.Adjamount = 0;//
        ////            rpldetail.InvoiceAmount = 0;//
        ////            rpldetail.Paymentamount = 0;//


        ////            if (item.Deposit_amount != null)
        ////            {
        ////                rpldetail.Depositamount = item.Deposit_amount;   // depossit amount
        ////            }
        ////            if (item.Adjusted_amount != null)
        ////            {
        ////                rpldetail.Adjamount = item.Adjusted_amount;
        ////            }

        ////            if (item.Invoice_Amount != null)
        ////            {
        ////                rpldetail.InvoiceAmount = item.Invoice_Amount;
        ////            }

        ////            if (item.Payment_amount != null)
        ////            {
        ////                rpldetail.Paymentamount = item.Payment_amount;
        ////            }







        ////            rpldetail.PostingDate = item.Posting_Date;

        ////            double kq2 = (double)rpldetail.Depositamount + (double)rpldetail.Adjamount + (double)rpldetail.InvoiceAmount + (double)rpldetail.Paymentamount;

        ////            //if (rpldetail.InvoiceAmount == null && item.Document_Type == "RV")
        ////            //{
        ////            //    rpldetail.InvoiceAmount = item.Amount_in_local_currency - item.Empty_Amount;

        ////            //}
        ////            if (item.Document_Type == "RV")
        ////            {
        ////                rpldetail.DocNumber = item.Invoice;

        ////                if (rpldetail.DocNumber == null)
        ////                {
        ////                    rpldetail.DocNumber = item.SoDelivery.ToString();
        ////                }

        ////            }




        ////            if (item.Document_Type != "RV")
        ////            {
        ////                rpldetail.DocNumber = item.Assignment;
        ////                if (rpldetail.DocNumber == null)
        ////                {
        ////                    rpldetail.DocNumber = item.Document_Number.ToString();
        ////                }


        ////            }






        ////            if (rpldetail.customergroup != null && kq2 != 0)
        ////            {




        ////                tbl_ArletterdetailRptlist.Add(rpldetail);

        ////                // db.tbl_ArletterdetailRpts.InsertOnSubmit(tbl_ArletterdetailRptlist);
        ////                //  db.SubmitChanges();

        ////            }
        ////        }


        ////    }

        ////    db.tbl_ArletterdetailRpts.InsertAllOnSubmit(tbl_ArletterdetailRptlist);
        ////    db.SubmitChanges();
        ////    #endregion   //tính bảng detail reports




        ////    #region   // tính bảng        tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();
        ////  //  int stt = 0;

        ////    var rsdETAIL = from tblCustomer in dc.tblCustomers
        ////                   where tblCustomer.Reportsend == true
        ////                   select tblCustomer;


        ////    foreach (var tblCustomerv in rsdETAIL)
        ////    {



        ////        tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();


        ////        headerrpt.custcodeGRoup = tblCustomerv.Cusromergroup;
        ////        headerrpt.customername = tblCustomerv.Name_1;
        ////        headerrpt.address = tblCustomerv.Address;
        ////        headerrpt.Fromdate = fromdate;
        ////        headerrpt.Todate = todate;
        ////        headerrpt.region = tblCustomerv.SOrg;// "VN"; // TAM THOI LA CHUNG vn
        ////        headerrpt.phone = tblCustomerv.Telephone_1;
        ////        headerrpt.code = tblCustomerv.Customer;

        ////        #region đầu kỳ  tinh toán số đầu kỳ
        ////        headerrpt.dknuoc = 0; // full good amiunt
        ////        headerrpt.dkvo = 0; // depossit amount

        ////       // headerrpt.No = from tbl_ArletterRpt in dc.tbl_ArletterRpts
        ////       //                where tbl_ArletterRpt.custcodegRoup == 
        ////        //headerrpt.psnuoc = 0;
        ////        //headerrpt.psvo = 0;

        ////        double dknuocps = 0;
        ////        double dkvocps = 0;
        ////        double dkbeginnuoc = 0;
        ////        double dkbeginvo = 0;
        ////        // tính đầu kỳ trên fbl5nnew

        ////        var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                    where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date < fromdate // && tblFBL5Nnew.Posting_Date >= fromdate
        ////                    group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
        ////                    select gr;

        ////        foreach (var item in rsemp)
        ////        {

        ////            dknuocps = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
        ////            dkvocps = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // đầu kỳ

        ////        }

        ////        // cộng thêm số dư dầu nữa;
        ////        var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
        ////                   where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
        ////                   group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
        ////                   select gr;

        ////        foreach (var item in rsdk)
        ////        {

        ////            dkbeginnuoc = (double)item.Sum(gr => gr.Fullgood_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// chính là amount on local
        ////            dkbeginvo = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh trong kỳ

        ////        }

        ////        headerrpt.dknuoc = dknuocps + dkbeginnuoc; // full good amiunt
        ////        headerrpt.dkvo = dkvocps + dkbeginvo; // depossit amount


        ////        //double dknuocps = 0;
        ////        //double dkvocps = 0;
        ////        //double dkbeginnuoc = 0;
        ////        //double dkbeginvo = 0;


        ////        #endregion đầu kỳ
        ////        //headerrpt.psnuoc
        ////        //headerrpt.psvo
        ////        #region phát sinh
        ////        headerrpt.psnuoc = 0;
        ////        headerrpt.psvo = 0;
        ////        var rsps = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                   where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
        ////                   group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
        ////                   select gr;

        ////        foreach (var item in rsps)
        ////        {

        ////            headerrpt.psnuoc = (double)item.Sum(gr => gr.Invoice_Amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Payment_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Adjusted_amount.GetValueOrDefault(0)) + (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0));// (double)item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
        ////            headerrpt.psvo = (double)item.Sum(gr => gr.Deposit_amount.GetValueOrDefault(0)); // phát sinh

        ////        }

        ////        #endregion phát sinh


        ////        //headerrpt.cknuoc
        ////        //headerrpt.ckvo

        ////        #region cuối kỳ

        ////        headerrpt.cknuoc = headerrpt.dknuoc + headerrpt.psnuoc;
        ////        headerrpt.ckvo = headerrpt.dkvo + headerrpt.psvo;

        ////        #endregion cuối kỳ





        ////        if (headerrpt.custcodeGRoup != null)
        ////        {
        ////            //stt = stt + 1;
        ////            //headerrpt.No = stt.ToString();

        ////            //     tbl_ArletterRpt

        ////            headerrpt.No = (from tbl_ArletterRpt in dc.tbl_ArletterRpts
        ////                            where tbl_ArletterRpt.custcodegRoup == headerrpt.custcodeGRoup
        ////                            select tbl_ArletterRpt.No).First();

        ////            tbl_ARdetalheaderRptlist.Add(headerrpt);

        ////            //  db.tbl_ARdetalheaderRpts.InsertOnSubmit(headerrpt);
        ////            //   db.SubmitChanges();

        ////        }


        ////    }
        ////    db.tbl_ARdetalheaderRpts.InsertAllOnSubmit(tbl_ARdetalheaderRptlist);
        ////    db.SubmitChanges();

        ////    #endregion //tính bảng a      tbl_ARdetalheaderRpt headerrpt = new tbl_ARdetalheaderRpt();





        ////    #region//tính bàng col vỏ detail  tbl_ColdetailRpt rptCol = new tbl_ColdetailRpt();


        ////    var rscol2 = from tblCustomer in dc.tblCustomers
        ////                 where tblCustomer.Reportsend == true
        ////                 select tblCustomer;


        ////    foreach (var tblCustomerv in rscol2)
        ////    {



        ////        #region // tính số đầu kỳ
        ////        tbl_ColdetailRpt rptColdk = new tbl_ColdetailRpt();

        ////        //   rptColdk.Account = tblCustomerv.Customer;
        ////        rptColdk.codeGroup = tblCustomerv.Cusromergroup;
        ////        rptColdk.SoDelivery = "x";

        ////        rptColdk.dkBinhpmicc02 = 0;
        ////        rptColdk.dkbinhpmix9l = 0;
        ////        rptColdk.dkChaivo1lit = 0;
        ////        rptColdk.dkChaivothuong = 0;
        ////        rptColdk.dkjoy20 = 0;
        ////        rptColdk.dkKetnhua1lit = 0;
        ////        rptColdk.dkKetnhuathuong = 0;
        ////        rptColdk.dkKetvolit = 0;
        ////        rptColdk.dkKetvothuong = 0;
        ////        rptColdk.dkpaletnhua = 0;
        ////        rptColdk.dkpalletgo = 0;

        ////        // đầu kỳ begine

        ////        int dkBinhpmicc02bg = 0;// dkBinhpmicc02 + item3.Sum(gr => gr.Binhpmicc02);
        ////        int dkbinhpmix9lbg = 0;// dkbinhpmix9l + item3.Sum(gr => gr.binhpmix9l);
        ////        int dkChaivo1litbg = 0;// dkChaivo1lit + item3.Sum(gr => gr.Chaivo1lit);
        ////        int dkChaivothuongbg = 0;// dkChaivothuong + item3.Sum(gr => gr.Chaivothuong);
        ////        int dkjoy20bg = 0;// dkjoy20 + item3.Sum(gr => gr.joy20l);
        ////        int dkKetnhua1litbg = 0;//  dkKetnhua1lit + item3.Sum(gr => gr.Ketnhua1lit);
        ////        int dkKetnhuathuongbg = 0;// dkKetnhuathuong + item3.Sum(gr => gr.Ketnhuathuong);
        ////        int dkKetvolitbg = 0;// dkKetvolit + item3.Sum(gr => gr.Ketvolit);
        ////        int dkKetvothuongbg = 0;// dkKetvothuong + item3.Sum(gr => gr.Ketvothuong);
        ////        int dkpaletnhuabg = 0;// dkpaletnhua + item3.Sum(gr => gr.paletnhua);
        ////        int dkpalletgobg = 0;// dkpalletgo + item3.Sum(gr => gr.palletgo);




        ////        var rsdk = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
        ////                   where tblFBL5beginbalace.codeGroup == tblCustomerv.Cusromergroup // && tblFBL5Nnew.Posting_Date <= todate // && tblFBL5Nnew.Posting_Date >= fromdate
        ////                   group tblFBL5beginbalace by tblFBL5beginbalace.codeGroup into gr
        ////                   select gr;

        ////        foreach (var item3 in rsdk)
        ////        {

        ////            //  headerrpt.dknuoc = headerrpt.dknuoc + item3.Sum(gr => gr.Fullgood_amount); // phát sinh trong kỳ
        ////            // headerrpt.dkvo = headerrpt.dknuoc + item3.Sum(gr => gr.Deposit_amount); // phát sinh trong kỳ

        ////            dkBinhpmicc02bg = (int)item3.Sum(gr => gr.Binhpmicc02);
        ////            dkbinhpmix9lbg = (int)item3.Sum(gr => gr.binhpmix9l);
        ////            dkChaivo1litbg = (int)item3.Sum(gr => gr.Chaivo1lit);
        ////            dkChaivothuongbg = (int)item3.Sum(gr => gr.Chaivothuong);
        ////            dkjoy20bg = (int)item3.Sum(gr => gr.joy20l);
        ////            dkKetnhua1litbg = (int)item3.Sum(gr => gr.Ketnhua1lit);
        ////            dkKetnhuathuongbg = (int)item3.Sum(gr => gr.Ketnhuathuong);
        ////            dkKetvolitbg = (int)item3.Sum(gr => gr.Ketvolit);
        ////            dkKetvothuongbg = (int)item3.Sum(gr => gr.Ketvothuong);
        ////            dkpaletnhuabg = (int)item3.Sum(gr => gr.paletnhua);
        ////            dkpalletgobg = (int)item3.Sum(gr => gr.palletgo);



        ////        }


        ////        int dkBinhpmicc02ps = 0;// dkBinhpmicc02 + item3.Sum(gr => gr.Binhpmicc02);
        ////        int dkbinhpmix9lps = 0;// dkbinhpmix9l + item3.Sum(gr => gr.binhpmix9l);
        ////        int dkChaivo1litps = 0;// dkChaivo1lit + item3.Sum(gr => gr.Chaivo1lit);
        ////        int dkChaivothuongps = 0;// dkChaivothuong + item3.Sum(gr => gr.Chaivothuong);
        ////        int dkjoy20ps = 0;// dkjoy20 + item3.Sum(gr => gr.joy20l);
        ////        int dkKetnhua1litps = 0;//  dkKetnhua1lit + item3.Sum(gr => gr.Ketnhua1lit);
        ////        int dkKetnhuathuongps = 0;// dkKetnhuathuong + item3.Sum(gr => gr.Ketnhuathuong);
        ////        int dkKetvolitps = 0;// dkKetvolit + item3.Sum(gr => gr.Ketvolit);
        ////        int dkKetvothuongps = 0;// dkKetvothuong + item3.Sum(gr => gr.Ketvothuong);
        ////        int dkpaletnhuaps = 0;// dkpaletnhua + item3.Sum(gr => gr.paletnhua);
        ////        int dkpalletgops = 0;// dkpalletgo + item3.Sum(gr => gr.palletgo);



        ////        var rsdk2 = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                    where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date < fromdate //= todate && tblFBL5Nnew.Posting_Date >= fromdate
        ////                    group tblFBL5Nnew by tblFBL5Nnew.codeGroup into gr
        ////                    select gr;

        ////        foreach (var item2 in rsdk2)
        ////        {

        ////            //    headerrpt.dknuoc = item.Sum(gr => gr.Fullgood_amount); // đầu kỳ
        ////            //    headerrpt.dkvo = item.Sum(gr => gr.Deposit_amount); // đầu kỳ


        ////            dkBinhpmicc02ps = (int)item2.Sum(gr => gr.Binhpmicc02); // đầu kỳ
        ////            dkbinhpmix9lps = (int)item2.Sum(gr => gr.binhpmix9l); // đầu kỳ
        ////            dkChaivo1litps = (int)item2.Sum(gr => gr.Chaivo1lit); // đầu kỳ
        ////            dkChaivothuongps = (int)item2.Sum(gr => gr.Chaivothuong); // đầu kỳ
        ////            dkjoy20ps = (int)item2.Sum(gr => gr.joy20l); // đầu kỳ
        ////            dkKetnhua1litps = (int)item2.Sum(gr => gr.Ketnhua1lit); // đầu kỳ
        ////            dkKetnhuathuongps = (int)item2.Sum(gr => gr.Ketnhuathuong); // đầu kỳ
        ////            dkKetvolitps = (int)item2.Sum(gr => gr.Ketvolit); // đầu kỳ
        ////            dkKetvothuongps = (int)item2.Sum(gr => gr.Ketvothuong); // đầu kỳ
        ////            dkpaletnhuaps = (int)item2.Sum(gr => gr.paletnhua); // đầu kỳ 
        ////            dkpalletgops = (int)item2.Sum(gr => gr.palletgo); // đầu kỳ 


        ////        }

        ////        rptColdk.dkBinhpmicc02 = dkBinhpmicc02bg + dkBinhpmicc02ps;
        ////        rptColdk.dkbinhpmix9l = dkbinhpmix9lbg + dkbinhpmix9lps;
        ////        rptColdk.dkChaivo1lit = dkChaivo1litbg + dkChaivo1litps;
        ////        rptColdk.dkChaivothuong = dkChaivothuongbg + dkChaivothuongps;
        ////        rptColdk.dkjoy20 = dkjoy20bg + dkjoy20ps;
        ////        rptColdk.dkKetnhua1lit = dkKetnhua1litbg + dkKetnhua1litps;
        ////        rptColdk.dkKetnhuathuong = dkKetnhuathuongbg + dkKetnhuathuongps;
        ////        rptColdk.dkKetvolit = dkKetvolitbg + dkKetvolitps;
        ////        rptColdk.dkKetvothuong = dkKetvothuongbg + dkKetvothuongps;
        ////        rptColdk.dkpaletnhua = dkpaletnhuabg + dkpaletnhuaps;
        ////        rptColdk.dkpalletgo = dkpalletgobg + dkpalletgops;





        ////        if (rptColdk.codeGroup != 0)
        ////        {
        ////            dc.tbl_ColdetailRpts.InsertOnSubmit(rptColdk);
        ////            dc.SubmitChanges();

        ////        }





        ////        #endregion // tính số đầu kỳ




        ////        var rsemp = from tblFBL5Nnew in dc.tblFBL5Nnews
        ////                    where tblFBL5Nnew.codeGroup == tblCustomerv.Cusromergroup && tblFBL5Nnew.Posting_Date <= todate && tblFBL5Nnew.Posting_Date >= fromdate
        ////                     && tblFBL5Nnew.Document_Type == "RV"
        ////                    select tblFBL5Nnew;

        ////        //   MessageBox.Show(rsemp.Count().ToString());
        ////        foreach (var item in rsemp)
        ////        {
        ////            tbl_ColdetailRpt rptCol = new tbl_ColdetailRpt();
        ////            rptCol.codeGroup = tblCustomerv.Cusromergroup;
        ////            rptCol.Account = item.Account;
        ////            rptCol.SoDelivery = "";
        ////            rptCol.Binhpmicc02 = 0;
        ////            rptCol.binhpmix9l = 0;// item.binhpmix9l;

        ////            rptCol.Chaivo1lit = 0;// item.Chaivo1lit;
        ////            rptCol.Chaivothuong = 0;// item.Chaivothuong;
        ////            rptCol.joy20l = 0;// item.joy20l;
        ////            rptCol.Ketnhua1lit = 0;// item.Ketnhua1lit;
        ////            rptCol.Ketnhuathuong = 0;// item.Ketnhuathuong;
        ////            rptCol.Ketvolit = 0;// item.Ketvolit;
        ////            rptCol.Ketvothuong = 0;// item.Ketvothuong;
        ////            rptCol.paletnhua = 0;// item.paletnhua;
        ////            rptCol.palletgo = 0;// item.palletgo;


        ////            #region // tính số phát sinh
        ////         //   rptColdk.codeGroup = tblCustomerv.Cusromergroup;



        ////            rptCol.Postingdate = (DateTime)item.Posting_Date;
        ////            rptCol.SoDelivery = item.SoDelivery;


        ////            if (rptCol.SoDelivery == null || rptCol.SoDelivery == "")
        ////            {
        ////                rptCol.SoDelivery = item.Assignment;

        ////            }
        ////            rptCol.InvoiceNumber = item.Invoice;// + " " + item.Invoice_Number;
        ////            //if (rptCol.InvoiceNumber == null || rptCol.InvoiceNumber == "")
        ////            //{
        ////            //    rptCol.InvoiceNumber = item.Assignment;
        ////            //}




        ////            if (item.Binhpmicc02 != null)
        ////            {
        ////                rptCol.Binhpmicc02 = item.Binhpmicc02;
        ////            }

        ////            if (item.binhpmix9l != null)
        ////            {
        ////                rptCol.binhpmix9l = item.binhpmix9l;
        ////            }

        ////            if (item.Chaivo1lit != null)
        ////            {
        ////                rptCol.Chaivo1lit = item.Chaivo1lit;
        ////            }

        ////            if (item.Chaivothuong != null)
        ////            {
        ////                rptCol.Chaivothuong = item.Chaivothuong;
        ////            }

        ////            if (item.joy20l != null)
        ////            {
        ////                rptCol.joy20l = item.joy20l;
        ////            }

        ////            if (item.Ketnhua1lit != null)
        ////            {
        ////                rptCol.Ketnhua1lit = item.Ketnhua1lit;
        ////            }

        ////            if (item.Ketnhuathuong != null)
        ////            {
        ////                rptCol.Ketnhuathuong = item.Ketnhuathuong;
        ////            }

        ////            if (item.Ketvolit != null)
        ////            {
        ////                rptCol.Ketvolit = item.Ketvolit;
        ////            }

        ////            if (item.Ketvothuong != null)
        ////            {
        ////                rptCol.Ketvothuong = item.Ketvothuong;
        ////            }

        ////            if (item.paletnhua != null)
        ////            {
        ////                rptCol.paletnhua = item.paletnhua;
        ////            }

        ////            if (item.palletgo != null)
        ////            {
        ////                rptCol.palletgo = item.palletgo;
        ////            }






        ////            #endregion // tính số phát sinh


        ////            int kq = (int)rptCol.Binhpmicc02 + (int)rptCol.binhpmix9l + (int)rptCol.Chaivo1lit + (int)rptCol.Chaivothuong + (int)rptCol.joy20l + (int)rptCol.Ketnhua1lit + (int)rptCol.Ketnhuathuong + (int)rptCol.Ketvolit + (int)rptCol.Ketvothuong + (int)rptCol.paletnhua + (int)rptCol.palletgo;

        ////            if (rptCol.codeGroup != 0 && kq != 0)
        ////            {


        ////           //     tbl_ColdetailRptlist.Add(rptCol);

        ////                 dc.tbl_ColdetailRpts.InsertOnSubmit(rptCol);
        ////          dc.SubmitChanges();

        ////            }
        ////        }

        ////    }

        ////  //  dc.tbl_ColdetailRpts.InsertAllOnSubmit(tbl_ColdetailRptlist);
        //////    dc.SubmitChanges();



        ////    #endregion //tính bảng col vỏ



        //}

        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        // ARlettermakebyGroupcodeRegion
        public static void VolumeupdateperContract(string Contractno)
        {

            string ContractNo = Contractno.Trim();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            #region    //   xoa datavolume conytrac
            dc.ExecuteCommand("DELETE FROM tbl_kacontractsvolume Where  tbl_kacontractsvolume.ContractNo = '" + ContractNo + "'");

            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            #endregion//   xoa datavolume conytrac


            var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                            where tbl_kacontractdata.ContractNo.Equals(ContractNo)
                            select tbl_kacontractdata).FirstOrDefault();

            if (contract != null)
            {
                #region calulationvoluecontractdetail insql
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("calulationvoluecontractdetail", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                    cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = contract.ExtDate;
                    cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = contract.EffDate;

                    cmd1.CommandTimeout = 0;
                    rdr1 = cmd1.ExecuteReader();



                    //       rdr1 = cmd1.ExecuteReader();

                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }
                //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion

            }




            //var subquery = (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
            //                where tbl_kacontractCustcode.ContractNo == ContractNo
            //                select tbl_kacontractCustcode.CustomerCode).ToList();


            //MessageBox.Show(subquery.Count().ToString());


            //var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                where tbl_kacontractdata.ContractNo.Equals(ContractNo)
            //                select tbl_kacontractdata).FirstOrDefault();


            //if (contract != null)
            //{
            //    var achivementrs = from tbl_kasale in dc.tbl_kasales
            //                       where tbl_kasale.Invoice_Date <= contract.ExtDate && tbl_kasale.Invoice_Date >= contract.EffDate &&
            //                       (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
            //                        where tbl_kacontractCustcode.ContractNo == ContractNo
            //                        select tbl_kacontractCustcode.CustomerCode).Contains(tbl_kasale.Sold_to)

            //                 //      tbl_kasale.Sold_to == contract.Customer
            //                       group tbl_kasale by tbl_kasale.Priod into g

            //                       select new
            //                       {

            //                           priod = g.Key,
            //                           EC = g.Sum(gg => gg.EC).GetValueOrDefault(0),
            //                           PC = g.Sum(gg => gg.PC).GetValueOrDefault(0),
            //                           UC = g.Sum(gg => gg.UC).GetValueOrDefault(0),
            //                           Litter = g.Sum(gg => gg.Litter).GetValueOrDefault(0),
            //                           GSR = g.Sum(gg => gg.GSR).GetValueOrDefault(0),
            //                           NSR = g.Sum(gg => gg.NSR).GetValueOrDefault(0),
            //                           //    PrdGrp = HandledMouseEventArgs.ke

            //                       };



            //    foreach (var item in achivementrs)
            //    {
            //        tbl_kacontractsvolume contractvolume = new tbl_kacontractsvolume();
            //        contractvolume.ContractNo = contract.ContractNo;
            //        contractvolume.Priod = item.priod;
            //        contractvolume.EC = item.EC;
            //        contractvolume.NSR = item.NSR;
            //        contractvolume.Litter = item.Litter;
            //        contractvolume.GSR = item.GSR;
            //        contractvolume.PC = item.PC;
            //        contractvolume.UC = item.UC;

            //        dc.CommandTimeout = 0;
            //        dc.tbl_kacontractsvolumes.InsertOnSubmit(contractvolume);
            //        dc.SubmitChanges();

            //    }




            //}// nue khac nunl tuc la co con tract do thi thuc hienj





        }

        // ARlettermakebyGroupcodeRegion
        public static void VolumeupdateperContractbyPRdgrp(string Contractno)
        {

            string ContractNo = Contractno.Trim();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region    //   xoa datavolume conytrac
            dc.CommandTimeout = 0;
            dc.ExecuteCommand("DELETE FROM tbl_kacontractsvolumePrductGRP Where  tbl_kacontractsvolumePrductGRP.ContractNo = '" + ContractNo + "'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.SubmitChanges();

            #endregion//   xoa datavolume conytrac

            #region // example

            var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
                            where tbl_kacontractdata.ContractNo.Equals(ContractNo)
                            select tbl_kacontractdata).FirstOrDefault();

            if (contract != null)
            {

                #region calulationvoluecontractdetailbyGR insql
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("calulationvoluecontractdetailbyGR", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                    cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = contract.ExtDate;
                    cmd1.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = contract.EffDate;

                    cmd1.CommandTimeout = 0;
                    rdr1 = cmd1.ExecuteReader();



                    //       rdr1 = cmd1.ExecuteReader();

                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }
                //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion
            }

            //  tbl_kacontractsvolumePrductGRP

            // var q9 = from tblCustomer in db.tblCustomers
            //          where !(from tblFBL5beginbalace in db.tblFBL5beginbalaces
            //                  select tblFBL5beginbalace.Account.ToString() + tblFBL5beginbalace.Business_Area).Contains(tblCustomer.Customer.ToString() + tblCustomer.SOrg) && (tblCustomer.Reportsend == true)
            //          orderby tblCustomer.Customer
            //          group tblCustomer by new
            //          {
            //         tblCustomer.Customer,
            //         tblCustomer.SOrg,
            //          }
            //          into g
            //          select g;

            //var results = from c in db.Companies
            //              join cn in db.Countries on c.CountryID equals cn.ID
            //              join ct in db.Cities on c.CityID equals ct.ID
            //              join sect in db.Sectors on c.SectorID equals sect.ID
            //              where (c.CountryID == cn.ID) && (c.CityID == ct.ID) && (c.SectorID == company.SectorID) && (company.SectorID == sect.ID)
            //              select new { country = cn.Name, city = ct.Name, c.ID, c.Name, c.Address1, c.Address2, c.Address3, c.CountryID, c.CityID, c.Region, c.PostCode, c.Telephone, c.Website, c.SectorID, Status = (ContactStatus)c.StatusID, sector = sect.Name };


            //return results.ToList();
            #endregion example



            //var contract = (from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                where tbl_kacontractdata.ContractNo.Equals( ContractNo)
            //                select tbl_kacontractdata).FirstOrDefault();


            //if (contract != null)
            //{
            //    var achivementrs = from tbl_kasale in dc.tbl_kasales

            //                       join tbl_kaProductGRDetail in dc.tbl_kaProductGRDetails on tbl_kasale.Mat_Number equals tbl_kaProductGRDetail.MatNumber
            //                       select new
            //                       {
            //                           Invoice_Date = tbl_kasale.Invoice_Date,
            //                           Sold_to = tbl_kasale.Sold_to,
            //                           priod = tbl_kasale.Priod,
            //                           PrdGrp = tbl_kaProductGRDetail.PrdGrp,
            //                           EC = tbl_kasale.EC,
            //                           PC = tbl_kasale.PC,
            //                           UC = tbl_kasale.UC,
            //                           Litter = tbl_kasale.Litter,
            //                           GSR = tbl_kasale.GSR,
            //                           NSR = tbl_kasale.NSR,
            //                           //    PrdGrp = HandledMouseEventArgs.ke

            //                       } into cc
            //                       where (cc.Invoice_Date <= contract.ExtDate && cc.Invoice_Date >= contract.EffDate) &&
            //                         (from tbl_kacontractCustcode in dc.tbl_kacontractCustcodes
            //                          where tbl_kacontractCustcode.ContractNo == ContractNo
            //                          select tbl_kacontractCustcode.CustomerCode).Contains(cc.Sold_to)


            //                       //cc.Sold_to == contract.Customer // && 
            //                       //    select cc.Sold_to;

            //                       //View.Viewtable viewtbl = new View.Viewtable(achivementrs, dc, "test!",3);
            //                       //viewtbl.Show();

            //                       group cc by new
            //                       {
            //                           cc.priod,
            //                           cc.PrdGrp
            //                       } into g


            //                       select new

            //                       {

            //                           priod = g.Key.priod,
            //                           PrdGrp = g.Key.PrdGrp,//.PrdGrp,
            //                           EC = g.Sum(gg => gg.EC).GetValueOrDefault(0),
            //                           PC = g.Sum(gg => gg.PC).GetValueOrDefault(0),
            //                           UC = g.Sum(gg => gg.UC).GetValueOrDefault(0),
            //                           Litter = g.Sum(gg => gg.Litter).GetValueOrDefault(0),
            //                           GSR = g.Sum(gg => gg.GSR).GetValueOrDefault(0),
            //                           NSR = g.Sum(gg => gg.NSR).GetValueOrDefault(0),


            //                       };



            //    foreach (var item in achivementrs)
            //    {
            //        tbl_kacontractsvolumePrductGRP contractvolume = new tbl_kacontractsvolumePrductGRP();
            //        contractvolume.ContractNo = contract.ContractNo;
            //        contractvolume.Priod = item.priod;
            //        contractvolume.ProductGRP = item.PrdGrp;
            //        contractvolume.EC = item.EC;
            //        contractvolume.NSR = item.NSR;
            //        contractvolume.Litter = item.Litter;
            //        contractvolume.GSR = item.GSR;
            //        contractvolume.PC = item.PC;
            //        contractvolume.UC = item.UC;

            //        dc.tbl_kacontractsvolumePrductGRPs.InsertOnSubmit(contractvolume);
            //        dc.SubmitChanges();

            //    }





            //}// nue khac nunl tuc la co con tract do thi thuc hienj





        }


        public static void DeleteALLConvertContract()
        {
            // string ContractNo = Contractno;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;
            //#region    //   xoa datavolume conytrac
            //dc.ExecuteCommand("DELETE FROM tbl_kacontractdata Where  tbl_kacontractdata.SystemCont = 'THI'");
            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.CommandTimeout = 0;
            //dc.SubmitChanges();

            //dc.ExecuteCommand("DELETE FROM tbl_kacontractsdatadetail Where  tbl_kacontractsdatadetail.SystemCont = 'THI'");
            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.CommandTimeout = 0;
            //dc.SubmitChanges();

            //dc.ExecuteCommand("DELETE FROM tbl_kacontractsdetailpayment Where  tbl_kacontractsdetailpayment.SystemCont = 'THI'");
            ////    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            //dc.CommandTimeout = 0;
            //dc.SubmitChanges();

            //#endregion//   xoa datavolume conytrac


        }


        public static IQueryable getViewcontractMaster(LinqtoSQLDataContext db)
        {


            string username = Utils.getusername();

            var regioncode = (from tbl_Temp in db.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();


           

            var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                               where Tka_RightContracttypeview.UserName == username
                               select Tka_RightContracttypeview.Contracttype;

            var rs = from tbl_kacontractdata in db.tbl_kacontractdatas
                     where (from Tka_RegionRight in db.Tka_RegionRights
                            where Tka_RegionRight.RegionCode == regioncode
                            select Tka_RegionRight.Region
                            ).Contains(tbl_kacontractdata.SalesOrg) && tbl_kacontractdata.Consts == "ALV"
                            && typecontract.Contains(tbl_kacontractdata.ConType)
                     orderby tbl_kacontractdata.ConType, tbl_kacontractdata.ContractNo

                     select new
                     {
                         tbl_kacontractdata.ContractNo,
                         tbl_kacontractdata.SalesOrg,
                         tbl_kacontractdata.ConType,//contract type
                         tbl_kacontractdata.Consts, //contract status
                         tbl_kacontractdata.Currency,
                         Validfrom = tbl_kacontractdata.EffDate,
                         Validto = tbl_kacontractdata.EftDate,
                         extDate = tbl_kacontractdata.ExtDate,

                         tbl_kacontractdata.Customer,
                         tbl_kacontractdata.Fullname,
                         Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
                         tbl_kacontractdata.Province,

                         tbl_kacontractdata.Channel,
                         FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                         tbl_kacontractdata.PCVolAched,
                         tbl_kacontractdata.NSRAched,
                         tbl_kacontractdata.COGS_ached,
                        
                         tbl_kacontractdata.UCVolAched,
                         tbl_kacontractdata.Revenue,

                         tbl_kacontractdata.Cash,
                         tbl_kacontractdata.FreeGood,
                         tbl_kacontractdata.POS,

                         tbl_kacontractdata.Promotion,
                         tbl_kacontractdata.MKTFun,

                         AchivedCommitment = tbl_kacontractdata.TotDeal,
                         tbl_kacontractdata.Tot_paid,
                         tbl_kacontractdata.Cash_paid,
                         tbl_kacontractdata.FreeGood_paid,
                         tbl_kacontractdata.POS_paid,

                         tbl_kacontractdata.Promotion_paid,
                         tbl_kacontractdata.MKTFun_paid,

                         Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,

                         PosBalance = tbl_kacontractdata.POS_Ached - tbl_kacontractdata.POS_paid, //achived

                         OthersBalance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid - tbl_kacontractdata.POS_Ached + tbl_kacontractdata.POS_paid, /// achived pos


                         VolumeCommit = tbl_kacontractdata.VolComm,
                        
                         tbl_kacontractdata.NSRComm,

                         tbl_kacontractdata.Remarks,
                         tbl_kacontractdata.DeliveredBy,
                         tbl_kacontractdata.Representative,
                         tbl_kacontractdata.VATregistrationNo,
                         tbl_kacontractdata.CRDDAT,
                         tbl_kacontractdata.CRDUSR,
                         //      tbl_kacontractdata.VolComm,


                     };

            return rs;

        }

        public static void FormatViewcontractmaster(DataGridView dataGridView1)
        {

            #region  format


            //tbl_kacontractdata.ContractNo,
            //dataGridView1.Columns["ContractNo"].DisplayIndex = 0;
            ////             tbl_kacontractdata.SalesOrg,
            //dataGridView1.Columns["SalesOrg"].DisplayIndex = 1;
            ////             tbl_kacontractdata.ConType,//contract type
            //dataGridView1.Columns["ConType"].DisplayIndex = 2;
            ////             tbl_kacontractdata.Consts, //contract status
            //dataGridView1.Columns["Consts"].DisplayIndex = 3;
            ////             tbl_kacontractdata.Currency,
            //dataGridView1.Columns["Currency"].DisplayIndex = 4;
            ////             Validfrom = tbl_kacontractdata.EffDate,
            //dataGridView1.Columns["Validfrom"].DisplayIndex = 5;
            ////             Validto = tbl_kacontractdata.EftDate,
            //dataGridView1.Columns["Validto"].DisplayIndex = 6;
            ////  extDate
            //dataGridView1.Columns["extDate"].DisplayIndex = 7;

            ////             tbl_kacontractdata.Customer,
            //dataGridView1.Columns["Customer"].DisplayIndex = 8;
            ////             tbl_kacontractdata.Fullname,
            //dataGridView1.Columns["Fullname"].DisplayIndex = 9;
            ////    Address = tbl_kacontractdata.HouseNo + " " + tbl_kacontractdata.District + " " + tbl_kacontractdata.Province,
            ////             tbl_kacontractdata.Channel,
            //dataGridView1.Columns["Address"].DisplayIndex = 10;
            //dataGridView1.Columns["Channel"].DisplayIndex = 11;
            ////             FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
            //dataGridView1.Columns["FullCommitment"].DisplayIndex = 12;
            dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                          //             tbl_kacontractdata.Cash,
                                                                                                                          //    dataGridView1.Columns["Cash"].DisplayIndex = 13;
            dataGridView1.Columns["Cash"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Cash"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                //             tbl_kacontractdata.FreeGood,
                                                                                                                //        dataGridView1.Columns["FreeGood"].DisplayIndex = 14;
            dataGridView1.Columns["FreeGood"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FreeGood"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                    //             tbl_kacontractdata.POS,
                                                                                                                    //                dataGridView1.Columns["POS"].DisplayIndex = 15;
            dataGridView1.Columns["POS"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["POS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                               //             tbl_kacontractdata.MKTFun,
                                                                                                               //                    dataGridView1.Columns["MKTFun"].DisplayIndex = 16;
            dataGridView1.Columns["MKTFun"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["MKTFun"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             AchivedCommitment = tbl_kacontractdata.TotDeal,
            //       dataGridView1.Columns["AchivedCommitment"].DisplayIndex = 17;
            dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                             //             tbl_kacontractdata.Tot_paid,
                                                                                                                             //          dataGridView1.Columns["Tot_paid"].DisplayIndex = 18;
            dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                    //             tbl_kacontractdata.Cash_paid,
                                                                                                                    //                   dataGridView1.Columns["Cash_paid"].DisplayIndex = 19;
            dataGridView1.Columns["Cash_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Cash_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.FreeGood_paid,

            //        dataGridView1.Columns["FreeGood_paid"].DisplayIndex = 20;
            dataGridView1.Columns["FreeGood_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["FreeGood_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.POS_paid,

            //     dataGridView1.Columns["POS_paid"].DisplayIndex = 21;
            dataGridView1.Columns["POS_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["POS_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.MKTFun_paid,

            //       dataGridView1.Columns["MKTFun_paid"].DisplayIndex = 22;
            dataGridView1.Columns["MKTFun_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["MKTFun_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,

            dataGridView1.Columns["Balance"].DisplayIndex = 23;
            dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



            dataGridView1.Columns["PosBalance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["PosBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            dataGridView1.Columns["OthersBalance"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["OthersBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             VolumeCommit = tbl_kacontractdata.VolComm,



            //  dataGridView1.Columns["VolumeCommit"].DisplayIndex = 24;
            dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //     tbl_kacontractdata.NSRComm,
            dataGridView1.Columns["NSRComm"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["NSRComm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //             tbl_kacontractdata.PCVolAched,

            //    dataGridView1.Columns["PCVolAched"].DisplayIndex = 25;
            dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.NSRAched,
            //   dataGridView1.Columns["NSRAched"].DisplayIndex = 26;
            dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.UCVolAched,
            //   dataGridView1.Columns["UCVolAched"].DisplayIndex = 27;
            dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //     dataGridView1.Columns["Revenue"].DisplayIndex = 28;
            dataGridView1.Columns["Revenue"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //
            dataGridView1.Columns["Promotion"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Promotion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            dataGridView1.Columns["Promotion_paid"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Promotion_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //             tbl_kacontractdata.CRDDAT,
            //        dataGridView1.Columns["CRDDAT"].DisplayIndex = 29;

            //             tbl_kacontractdata.CRDUSR,
            //        dataGridView1.Columns["CRDUSR"].DisplayIndex = 30;





            #endregion

            // return null;

        }
        public static void ConvertALLBeginMasterCont()
        {



            #region convert masterContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConverMasterContract", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


            #region convert DetailContract begin to 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConvertDetailContract", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


            #region convert PaymentinforContract begin to 
            //SqlConnection conn2 = null;
            //SqlDataReader rdr1 = null;

            //string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaInsertConvertPaymentContract", conn2);
                cmd1.CommandTimeout = 0;
                cmd1.CommandType = CommandType.StoredProcedure;
                //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
                //  cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


        }// end frunction



        public static void AccrualContractinSQL(DateTime Accrualdate)
        {
            if (Accrualdate != null)
            {

                #region tính tren sa

                //  Control.Control_ac.CaculationALLContractinSQLbySQL();

                SqlConnection conn2 = null;

                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("AccrualContractinSQLbySQL", conn2);
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Accrualdate", SqlDbType.DateTime).Value = Accrualdate;

                    rdr1 = cmd1.ExecuteReader();



                    //       rdr1 = cmd1.ExecuteReader();

                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }
                //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //     #endregion


                #endregion


            }



        }

        public static void CaculationALLContractinSQL()
        {
            #region tính tren sa

            //  Control.Control_ac.CaculationALLContractinSQLbySQL();

            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("CaculationALLContractinSQLbySQL", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                //  cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //     #endregion


            #endregion


            //#region // tính  hợp đồng trên phương thức 1



            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var contractrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                 where tbl_kacontractdata.Consts == "ALV"
            //                 select tbl_kacontractdata.ContractNo;

            //if (contractrs.Count() > 0)
            //{
            //    foreach (var item in contractrs)
            //    {
            //   //     CaculationContractinSQLmaster(item);


            //        Control_ac.CaculationContract(item); // tinhs toasn contract truo c khi view

            //        Control.Control_ac.CaculationContractinSQLmaster(item);


            //    }




            //}
            //#endregion    

        }
        public static void CaculationContractinSQLmaster(string Contractno)
        {

            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaCaculationContractinSQLmaster", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


        }


        public static void CaculationContract(string Contractno)
        {


            #region convert PaymentinforContract begin to 
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("kaCaculationContractinSQLdetail", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@Contractno", SqlDbType.VarChar).Value = Contractno;
                cmd1.CommandTimeout = 0;
                rdr1 = cmd1.ExecuteReader();



                //       rdr1 = cmd1.ExecuteReader();

            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion






        }
        public IQueryable KArptdataset2(LinqtoSQLDataContext db)
        {

            string usrname = Utils.getusername();
            //    var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_KAdetailprogrRpt in db.tbl_KAdetailprogrRpts
                     where tbl_KAdetailprogrRpt.Username == usrname
                     select tbl_KAdetailprogrRpt;

            return rs;




            //  throw new NotImplementedException();
        }

        public IQueryable KArptdataset1(LinqtoSQLDataContext db)
        {



            #region lấy dữ liệu bảng ar letter reports ra
            string usrname = Utils.getusername();

            var rs = from tbl_KapaymentrequestRpt in db.tbl_KapaymentrequestRpts
                     where tbl_KapaymentrequestRpt.Username == usrname
                     select tbl_KapaymentrequestRpt;

            return rs;

            #endregion lấy dữ liệu bảng ar letter reports ra


        }


        class datatoExport
        {
            public System.Data.DataTable dataGrid1 { get; set; }
            public string filename { get; set; }
            public string tittle { get; set; }
        }

        public static void caculationAllContract()
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var contractrs = from tbl_kacontractbegindata in dc.tbl_kacontractbegindatas
                             select tbl_kacontractbegindata.ContractNo;

            if (contractrs.Count() > 0)
            {
                foreach (var item in contractrs)
                {
                    CaculationContract(item);
                }




            }





        }

        public static void exportsexcel(object objextoEl)
        {

            datatoExport dat = (datatoExport)objextoEl;

            //    DataTable dataTble = new DataTable();
            //   DataSet dataSet, string outputPath

            // Create the Excel Application object
            cExcel.ApplicationClass excelApp = new cExcel.ApplicationClass();

            // Create a new Excel Workbook
            cExcel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

            int sheetIndex = 0;
            System.Data.DataTable dt = dat.dataGrid1;
            var tittle = dat.tittle;
            var filename = dat.filename;

            // Copy the DataTable to an object array
            object[,] rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

            // Copy the column names to the first row of the object array
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                rawData[0, col] = dt.Columns[col].ColumnName;
            }

            // Copy the values to the object array
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                }
            }

            // Calculate the final column letter
            string finalColLetter = string.Empty;
            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;

            if (dt.Columns.Count > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                    (dt.Columns.Count - 1) % colCharsetLen, 1);

            // Create a new Sheet
            cExcel.Worksheet excelSheet = (cExcel.Worksheet)excelWorkbook.Sheets.Add(
                excelWorkbook.Sheets.get_Item(++sheetIndex),
                Type.Missing, 1, cExcel.XlSheetType.xlWorksheet);

            //         excelSheet.Name = dt.TableName;

            // Fast data export to Excel
            string excelRange = string.Format("A1:{0}{1}",
                finalColLetter, dt.Rows.Count + 1);

            excelSheet.get_Range(excelRange, Type.Missing).Value2 = rawData;

            // Mark the first row as BOLD
            ((cExcel.Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;


            // Save and Close the Workbook


            excelWorkbook.SaveAs(filename, cExcel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, cExcel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            //   xlApp.Quit();



            //excelWorkbook.SaveAs(outputPath, cExcel.XlFileFormat.xlWorkbookNormal, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, cExcel.XlSaveAsAccessMode.xlExclusive,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //excelWorkbook.Close(true, Type.Missing, Type.Missing);
            //excelWorkbook = null;

            // Release the Application object
            excelApp.Quit();
            excelApp = null;

            // Collect the unreferenced objects
            GC.Collect();
            GC.WaitForPendingFinalizers();



            MessageBox.Show(filename + " exported !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void exportExceldatagridtofile(IQueryable IQuery, LinqtoSQLDataContext db, string tittle)
        {


            System.Data.DataTable datatable1 = new System.Data.DataTable();
            //

            Utils ul = new Utils();

            datatable1 = ul.ToDataTable(db, IQuery);


            foreach (var c in datatable1.Columns)
            {
                DataColumn clm = (DataColumn)c;
                clm.ColumnName = clm.ColumnName.Replace("_", " ");
            }


            //  this.dataGridView2.DataSource =  dataGridView1.DataSource;
            //
            #region // connect to excel
            SaveFileDialog theDialog = new SaveFileDialog();
            //


            //   DataGridView dataGridView1 = new DataGridView();
            //   dataGridView1.DataSource = dataGrid.DataSource;

            theDialog.Title = "Export to Excel file";
            theDialog.Filter = "Excel files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";

            #endregion
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = theDialog.FileName.ToString();

                //   DataGridView datagr1 = new DataGridView();
                //  datagr1 = dataGrid1;

                Thread t1 = new Thread(exportsexcel);
                t1.IsBackground = true;
                t1.Start(new datatoExport() { dataGrid1 = datatable1, filename = filename, tittle = tittle });
                // t1.Join();
            }



        }




    }

}