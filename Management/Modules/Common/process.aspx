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
