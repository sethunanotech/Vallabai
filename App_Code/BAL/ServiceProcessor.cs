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
}