using DBContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ServiceProcessor
/// </summary>
public static class ServiceProcessor
{
    public static string GetRecentBirthdays()
    {
        string Response     = string.Empty;
        var CurrentMonth    = DateTime.Now.Month;
        var CurrentYear     = DateTime.Now.Year;
        StringBuilder builder = new StringBuilder();
        using (VallabaiDataContext db=new VallabaiDataContext())
        {
            var swamies = from s in db.tab_VA_SWAMY_REGISTRATIONs
                          where s.swamy_DOB.Value.Month == CurrentMonth && s.swamy_DOB.HasValue == true
                          select s;
            if (swamies != null)
            {
                if (swamies.Count() > 0)
                {
                    foreach (var item in swamies)
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath("~/management/Resources/user/") + item.swamy_ID + ".jpg"))
                            builder.Append(@"<a href='#'><div class='inbox-item'><div class='inbox-item-img'><img src='../../Resources/user/"+ item.swamy_ID +".jpg' class='img-circle' alt=''></div>");
                        else
                            builder.Append(@"<a href='#'><div class='inbox-item'><div class='inbox-item-img'><img src='../../Resources/user/noimage.jpg' class='img-circle' alt=''></div>");

                        builder.Append(@"<p class='inbox-item-author'>"+ item.swamy_NAME +"</p>");
                        builder.Append(@"<p class='inbox-item-text'>"+ item.swamy_PLACE + ',' + item.swamy_DISTRICT +"</p>");
                        builder.Append(@"<p class='inbox-item-date'>"+ string.Format("{0:dd-MMM}", item.swamy_DOB) +"</p></div></a>");
                    }
                }
            }
        }
        Response = builder.ToString();
        return Response;
    }

    public static string SeatBooking(int PayanamID, int BusID, int UserID, int SeatNumber)
    {
        string Response = string.Empty;
        using (VallabaiDataContext db=new VallabaiDataContext())
        {
            try
            {
                var seat = from s in db.tab_VA_BUS_BOOKINGs
                           where s.payanam_ID == PayanamID && s.bus_NUMBER == BusID && s.seat_NUMBER == SeatNumber
                           select s;
                if (seat.Count() == 0)
                {
                    tab_VA_BUS_BOOKING booking = new tab_VA_BUS_BOOKING();
                    booking.payanam_ID = PayanamID;
                    booking.bus_NUMBER = BusID;
                    booking.user_ID = UserID;
                    booking.seat_NUMBER = SeatNumber;

                    db.tab_VA_BUS_BOOKINGs.InsertOnSubmit(booking);
                    db.SubmitChanges();
                    Response = "Seat is Alloted";
                }
                else
                {
                    Response = "Selected Seat is not available";
                }
            }
            catch(Exception ex)
            {
                Response = "Some error occured : " + ex.Message;
            }
        }
        return Response;
    }

    public static string LoadSeats(int PayanamID, int BusID)
    {
        string Response         = string.Empty;
        StringBuilder Builder   = new StringBuilder();

        var VehicleType = "";
        var TotalSeats  = 0;

        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var busdetails = from bd in db.tab_VA_PAYANAM_BUS_DETAILs
                             where bd.bus_ID == BusID
                             select new { bd.bus_TOTAL_SEATS, bd.vehicle_TYPE };
            if (busdetails.Count() > 0)
            {
                foreach (var item in busdetails)
                {
                    VehicleType = item.vehicle_TYPE;
                    TotalSeats  = item.bus_TOTAL_SEATS;
                    break;
                }
            }
            if (TotalSeats > 0)
            {
                Builder.Append(@"<ul class='seat_ul'>");
                for (int i = 1; i <= 24; i++)
                {
                    Builder.Append(@"<li class='seat' id='"+ i +"' onclick='_SelectSeat("+ i +")'>"+ i +"</li>");
                }
                Builder.Append(@"</ul>");
                Builder.Append(@"<ul class='seat_ul'>");
                for (int i = 25; i <= 55; i++)
                {
                    Builder.Append(@"<li class='seat' id='" + i + "' onclick='_SelectSeat(" + i + ")'>" + i + "</li>");
                }
                Builder.Append(@"</ul>");
            }
        }
        Response = Builder.ToString();
        return Response;
    }
}