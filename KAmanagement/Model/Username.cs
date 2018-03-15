using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAmanagement.Model
{





    class Username
    {

        public string Name { get; set; }
        public Boolean right { get; set; }
        public int Version { get; set; }
        public Boolean inputcontract { get; set; }
        public Boolean inputcontractconfirm { get; set; }
        public Boolean paymentdisplay { get; set; }
        public Boolean paymentcreate { get; set; }
        public Boolean saleupdate { get; set; }
        public Boolean saleview { get; set; }
        public Boolean saledeleted { get; set; }
        public Boolean salechange { get; set; }
        public Boolean reports { get; set; }
        public Boolean masterdata { get; set; }
        public Boolean masterbegin { get; set; }

        public Boolean userssetup { get; set; }
        public Boolean pricingcheckview { get; set; }

        public Boolean pricingcheckupdate { get; set; }

        public Boolean inputcontractfinalcontrol { get; set; }

        public Boolean masterdatafuction { get; set; }

        public Boolean changeitem { get; set; }

        public Boolean btaddnewItem { get; set; }
        public Username()
        {

            string Name = Utils.getusername();



            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_Temp in dc.tbl_Temps
                      where tbl_Temp.username == Name

                      select tbl_Temp).FirstOrDefault();
            if (rs != null)
            {
                right = true;

                Version = (int)rs.Version;
                inputcontract = rs.inputcontract;
                inputcontractconfirm = rs.inputcontractconfirm;
                paymentdisplay = rs.paymentdisplay;
                paymentcreate = rs.paymentcreate;
                saleupdate = rs.saleupdate;
                saleview = rs.saleview;

                saledeleted = rs.saledeleted;
                salechange = rs.salechange;

                reports = rs.reports;
                masterdata = rs.masterdata;

                masterbegin = rs.masterbegin;

                userssetup = rs.userssetup;
                pricingcheckview = rs.pricingcheckview;

                pricingcheckupdate = rs.pricingcheckupdate;
                //    inputcontract =

                inputcontractfinalcontrol = rs.inputcontractfinalcontrol;



                masterdatafuction = rs.masterdatafuction;

                changeitem = rs.changeitem;
                btaddnewItem = rs.btaddnewItem;
            }
            else
            {

                right = false;
            }



        }

    }















}
