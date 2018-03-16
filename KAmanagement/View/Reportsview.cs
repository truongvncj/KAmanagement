//using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
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
    public partial class Reportsview : Form
    {
        public DataTable tbl1 { get; set; }
        public int BatchNo { get; set; }

        public int subid { get; set; }
        public string contractno { get; set; }
        public View.CreatenewContract formcreatCtract { get; set; }
        //    formcreatCtract
        public Reportsview(DataTable tbl1, DataTable tbl2, string rptname , int BatchNo,  string contractno, View.CreatenewContract formcreatCtract) //IQueryable rs
        {
            InitializeComponent();

            this.tbl1 = tbl1;

            this.BatchNo = BatchNo;
        //    this.subid = subid;
            this.contractno = contractno;
            this.formcreatCtract = formcreatCtract;


            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KAmanagement.Reports."+ rptname + "";
            // chọn báo cáo hiển thị

            // chọn data hiển thị


           ReportDataSource datasource = new ReportDataSource("DataSet1", tbl1);
           ReportDataSource datasource2 = new ReportDataSource("DataSet2", tbl2);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(datasource);
          this.reportViewer1.LocalReport.DataSources.Add(datasource2);

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing );

            // chọn data hiển thị

            // chọn kiểu hiển thị
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

           // this.reportViewer1.ZoomMode = ZoomMode.Percent;
           // this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowPageNavigationControls = false;


            #region kiểm tra printed  OK

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rschangepritcheck = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                     where tbl_kacontractsdetailpayment.BatchNo == BatchNo// && tbl_kacontractsdatadetail.SubID == subid && tbl_kacontractsdatadetail.ContractNo == contractno
                                     select tbl_kacontractsdetailpayment).FirstOrDefault();



            if (rschangepritcheck != null && rschangepritcheck.PrintChk == true)
            {

                this.reportViewer1.ShowPrintButton = false;
          
              ///  return;
            }

            #endregion kiểm tra printed
            // this.reportViewer1.ShowPageNavigationControls
            //  this.reportViewer1.ShowExportButto = false;
            //if (rptname == "ARletter.rdlc")
            //{

            ////    tbl_ArletterRpt rptdata = new tbl_ArletterRpt();

            ////    ReportParameter rp0 = new ReportParameter("NO", rptdata.No.ToString());
            //////    ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            ////    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0 });
            //////    this.reportViewer1.LocalReport.Refresh();




            //}
            ////ReportParameter rp0 = new ReportParameter("Report_Parameter_UserName", tbl_ArletterRpt.);
            //ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0, rp1 });
            //ReportViewer1.LocalReport.Refresh();

            // chọn kiểu hiển thị

            this.reportViewer1.RefreshReport();




        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

           var custGroupid = double.Parse(e.Parameters["custGroupid"].Values.First());
         //   var subSource = ((List<Cus>)mainSource.Value).Single(o => o.OrderID == orderId).Suppliers;

            e.DataSources.Add(new ReportDataSource("DataSet1", tbl1));



            //  throw new NotImplementedException();
        }

        private void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {




        }

        private void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            // MessageBox.Show("In payment request !");

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rschangepritcheck = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                    where tbl_kacontractsdetailpayment.BatchNo == BatchNo// &&  tbl_kacontractsdatadetail.ContractNo == contractno
                                    select tbl_kacontractsdetailpayment;


            if (rschangepritcheck != null)
            {
                foreach (var item in rschangepritcheck)
                {
                    item.PrintChk = true;
                    item.PrintDate = DateTime.Today;
              //      item.
                    dc.SubmitChanges();

                    if (formcreatCtract != null)
                    {
                        this.formcreatCtract.loadDetailContractView(contractno);
                    }
                    
                }
            }


      //      this.Close();



        }
    }



}
