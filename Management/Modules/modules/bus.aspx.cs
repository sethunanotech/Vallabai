using DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_modules_bus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSaveBusDetails_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var PayanamID = Convert.ToInt32(Request.QueryString["pID"]);
            var BusType = ddlVehicleType.SelectedValue;
            var RegistrationNumber = txtRegistrationNumber.Text;
            var BusNumber = Convert.ToInt32(txtBusNumber.Text);
            var TotalSeats = Convert.ToInt32(txtTotalSeats.Text);
            var DriverName = txtDriverName.Text;
            var DriverMobileNumber = txtDriverMobileNumber.Text;

            using (VallabaiDataContext db = new VallabaiDataContext())
            {
                try
                {
                    tab_VA_PAYANAM_BUS_DETAIL detail = new tab_VA_PAYANAM_BUS_DETAIL();
                    detail.bus_PAYANAM_NUMBER = PayanamID;
                    detail.vehicle_TYPE = BusType;
                    detail.bus_REGISTRATION_NUMBER = RegistrationNumber;
                    detail.bus_NUMBER = BusNumber;
                    detail.bus_TOTAL_SEATS = TotalSeats;
                    detail.bus_DRIVER_NAME = DriverName;
                    detail.bus_DRIVER_MOBILE_NUMBER = DriverMobileNumber;

                    db.tab_VA_PAYANAM_BUS_DETAILs.InsertOnSubmit(detail);
                    db.SubmitChanges();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('User Details updated successfully')});", true);
                }
                catch(Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('"+ ex.Message.ToString() +"')});", true);
                }
            }

        }
        else
        {
            Response.Write("Sethu");
                }
    }
}