<%@ Page Language="C#" AutoEventWireup="true" CodeFile="process.aspx.cs" Inherits="Management_Modules_Common_process" %>

<%
    String ResponseString = string.Empty;
    if (Request.QueryString.HasKeys())
    {
        var ProcessString = Convert.ToString(Request.QueryString["pid"]);
        switch (ProcessString)
        {
            case "REBD": // Process Recent Birthdays
                ResponseString = ServiceProcessor.GetRecentBirthdays();
                break;
            case "SB": // Seat Booking
                var PayanamID   = Convert.ToInt32(Request.QueryString["paID"]);
                var BusID       = Convert.ToInt32(Request.QueryString["bID"]);
                var UserID      = Convert.ToInt32(Request.QueryString["uID"]);
                var SeatNumber  = Convert.ToInt32(Request.QueryString["sID"]);
                ResponseString  = ServiceProcessor.SeatBooking(PayanamID, BusID, UserID, SeatNumber);
                break;
            case "LS": // Load Seats
                var PayanamIDLS = Convert.ToInt32(Request.QueryString["paID"]);
                var BusIDLS     = Convert.ToInt32(Request.QueryString["bID"]);
                ResponseString  = ServiceProcessor.LoadSeats(PayanamIDLS, BusIDLS);
                break;
            default:
                break;
        }
    }
    else
    {
        ResponseString = "Authorization failed";
    }
    Response.Write(ResponseString);
%>
