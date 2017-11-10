using DBContext;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
    public static bool isNumber(object Expression)
    {
        double retNum;
        bool isNum = Double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    public static bool isDecimal(object Expression)
    {
        decimal retNum;
        bool isNum = Decimal.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    public static bool isValidDate(object Expression)
    {
        DateTime retDate;
        bool isDate = DateTime.TryParse(Convert.ToString(Expression), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out retDate);
        return isDate;
    }

    public static string GetErrorMessge(String ErrCode)
    {
        string errStr = string.Empty;
        switch (ErrCode)
        {
            case "AUT404":
                errStr = "You are not authorized user, Check your username and password";
                break;
            default:
                break;
        }
        return errStr;
    }

    public static string GetSwamyCode()
    {
        var Result       = string.Empty;
        var CurrentYear  = DateTime.Now.Year.ToString();
        CurrentYear      = CurrentYear.Substring(2);
        var TotalSwamies = 0;
        var Temp         = string.Empty;

        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var regi = from r in db.tab_VA_SWAMY_REGISTRATIONs
                       select r;
            TotalSwamies = regi.Count() + 1;
            Temp = TotalSwamies.ToString().PadLeft(4, '0');
        }
        Result = "VA" + CurrentYear + "" + Temp;
        return Result;
    }

    public static int GetLatestRegisterID()
    {
        var ID = 0;
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var reg = from r in db.tab_VA_SWAMY_REGISTRATIONs
                      orderby r.swamy_ID descending
                      select r;
            if (reg.Count() > 0)
            {
                foreach (var item in reg)
                {
                    ID = item.swamy_ID;
                    break;
                }
            }
        }
        return ID;
    }
}