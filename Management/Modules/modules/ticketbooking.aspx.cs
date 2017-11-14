using System;
using DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Net;

public partial class Modules_modules_ticketbooking : System.Web.UI.Page
{
    const String STR_ACCOUNTING_FORMAT = @"_(#,##0_);_(\(#,##0\);_(""-""??_);_(@_)";
    public static void makeAccessible(GridView grid)
    {
        if (grid.Rows.Count <= 0) return;
        grid.UseAccessibleHeader = true;
        grid.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (grid.ShowFooter)
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        makeAccessible(gvSwamies);
    }

    protected   void Page_Load                  (object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBusNumbers();
            //LoadSeatNumbers();
            BindBookedSeats();
        }
    }

    protected   void btnSearch_Click            (object sender,EventArgs e)
    {
        var SearchCode = txtCode.Text;
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var user = from u in db.tab_VA_SWAMY_REGISTRATIONs
                       where (u.swamy_CODE == SearchCode || u.swamy_NAME.Contains(SearchCode))
                       select new { u.swamy_NAME, u.swamy_ID, u.swamy_PLACE, u.swamy_FATHER_SPOUSE_NAME };
            if (user.Count() > 0)
            {
                ddlNames.Items.Clear();
                foreach (var item in user)
                {
                    ddlNames.Items.Add(item.swamy_NAME + " - " + item.swamy_FATHER_SPOUSE_NAME + " [" + item.swamy_PLACE + "]");
                    ddlNames.Items[ddlNames.Items.Count - 1].Value = Convert.ToString(item.swamy_ID);
                }
            }
        }
    }

    //protected   void btnBookNow_Click           (object sender, EventArgs e)
    //{
    //    var UserID = Convert.ToInt32(ddlNames.SelectedValue);
    //    var BusNumber = Convert.ToInt32(ddlBusNumber.SelectedValue);
    //    var SeatNumber = Convert.ToInt32(ddlSeatNumber.SelectedValue);
    //    var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);

    //    using (VallabaiDataContext db = new VallabaiDataContext())
    //    {
    //        var check = from c in db.tab_VA_BUS_BOOKINGs
    //                    where c.payanam_ID == PayanamID && c.user_ID == UserID
    //                    select c;
    //        if (check.Count() == 0)
    //        {

    //            tab_VA_BUS_BOOKING book = new tab_VA_BUS_BOOKING();
    //            book.payanam_ID = PayanamID;
    //            book.user_ID = UserID;
    //            book.bus_NUMBER = BusNumber;
    //            book.seat_NUMBER = SeatNumber;

    //            db.tab_VA_BUS_BOOKINGs.InsertOnSubmit(book);
    //            db.SubmitChanges();
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('Seat Booked')});", true);
    //            BindBookedSeats();
    //        }
    //        else
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('Seat is already alloted to this Swamy')});", true);
    //        }
    //    }

    //}

    protected   void gvCancel_Click             (object sender, EventArgs e)
    {
        var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);
        string CommandArgument = Convert.ToString(((Button)sender).CommandArgument);

        if (CommandArgument.Contains(","))
        {
            var Values = CommandArgument.Split(',');
            var SeatNumber = Convert.ToInt32(Values[0]);
            var BusNumber = Convert.ToInt32(Values[1]);

            using (VallabaiDataContext db = new VallabaiDataContext())
            {
                var seat = from s in db.tab_VA_BUS_BOOKINGs
                           where s.payanam_ID == PayanamID && s.seat_NUMBER == SeatNumber && s.bus_NUMBER == BusNumber
                           select s;
                if (seat.Count() > 0)
                {
                    foreach (var item in seat)
                    {
                        db.tab_VA_BUS_BOOKINGs.DeleteOnSubmit(item);
                        db.SubmitChanges();

                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('Cancelled selected seat')});", true);
                    BindBookedSeats();
                    //LoadSeatNumbers();
                    ClearFields();
                }
            }
        }
    }

    protected   void ddlBus_SelectedIndexChanged(object sender, EventArgs e)
    {
        var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);
        var BusID = Convert.ToInt32(ddlBus.SelectedValue);

        BindBookedSeats(PayanamID, BusID);
    }

    protected   void ddlBusNumber_IndexChanged  (object sender, EventArgs e)
    {
        //LoadSeatNumbers();
    }

    private     void GetBusNumbers              ()      
    {
        var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);
        ddlBusNumber.Items.Clear();
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var bus = from b in db.tab_VA_PAYANAM_BUS_DETAILs
                      join p in db.tab_VA_PAYANAMs on b.bus_PAYANAM_NUMBER equals p.payanam_ID
                      where b.bus_PAYANAM_NUMBER == PayanamID
                      select new { b.bus_ID, b.bus_NUMBER, p.payanam_TITLE, b.vehicle_TYPE };
            if (bus.Count() > 0)
            {
                foreach (var item in bus)
                {
                    ddlBus.Items.Add(Convert.ToString(item.vehicle_TYPE + "- " + item.bus_NUMBER));
                    ddlBus.Items[ddlBus.Items.Count - 1].Value = Convert.ToString(item.bus_ID);
                    ddlBusNumber.Items.Add(Convert.ToString(item.vehicle_TYPE + " - " + item.bus_NUMBER + " [" + item.payanam_TITLE + "]"));
                    ddlBusNumber.Items[ddlBusNumber.Items.Count - 1].Value = Convert.ToString(item.bus_ID);
                }
            }
        }
    }

    //private     void LoadSeatNumbers            ()      
    //{
    //    var BusNumber                 = Convert.ToInt32(ddlBusNumber.SelectedValue);
    //    var PayanamID                 = Convert.ToInt32(Request.QueryString["pid"]);
    //    //ddlSeatNumber.Items.Clear();
    //    using (VallabaiDataContext db = new VallabaiDataContext())
    //    {
    //        var seat = from pd in db.tab_VA_PAYANAM_BUS_DETAILs
    //                   where pd.bus_ID == BusNumber
    //                   select new { pd.bus_TOTAL_SEATS };
    //        var TotalSeats = 0;
    //        if (seat.Count() > 0)
    //        {
    //            foreach (var item in seat)
    //            {
    //                TotalSeats = item.bus_TOTAL_SEATS;
    //                break;
    //            }
    //        }
            
    //        if (TotalSeats> 0)
    //        {
    //            for (int i = 1; i <= TotalSeats; i++)
    //            {
    //                if (!CheckSeatAvaialbility(i, BusNumber, PayanamID))
    //                {
    //                    ddlSeatNumber.Items.Add("Seat - " + i.ToString());
    //                    ddlSeatNumber.Items[ddlSeatNumber.Items.Count - 1].Value = Convert.ToString(i);
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //            }
    //        }
    //    }
    //}

    private     bool CheckSeatAvaialbility      (int SeatNumber, int BusNumber, int PayanamID)
    {
        var Result = false;
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var seat = from s in db.tab_VA_BUS_BOOKINGs
                       where s.seat_NUMBER == SeatNumber && s.payanam_ID == PayanamID && s.bus_NUMBER == BusNumber
                       select s;
            if (seat.Count() > 0)
            {
                Result = true;
            }
        }
        return Result;
    }

    private     void ClearFields                ()      
    {
        txtCode.Text = "";
        ddlNames.ClearSelection();
        //LoadSeatNumbers();
    }

    private     void BindBookedSeats            ()      
    {
        var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);

        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var seats = from s in db.tab_VA_BUS_BOOKINGs
                        join r in db.tab_VA_SWAMY_REGISTRATIONs on s.user_ID equals r.swamy_ID
                        join p in db.tab_VA_PAYANAMs on s.payanam_ID equals p.payanam_ID
                        join bd in db.tab_VA_PAYANAM_BUS_DETAILs on s.bus_NUMBER equals bd.bus_ID
                        where s.payanam_ID == PayanamID
                        orderby s.seat_NUMBER
                        select new { r.swamy_CODE, r.swamy_NAME, r.swamy_FATHER_SPOUSE_NAME, r.swamy_PLACE, r.swamy_MOBILE_NUMBER, bd.vehicle_TYPE, bd.bus_NUMBER, s.seat_NUMBER, p.payanam_TITLE };

            if (seats.Count() > 0)
            {
                gvSwamies.DataSource = seats;
                gvSwamies.DataBind();
            }
        }
    }

    private     void BindBookedSeats            (int PayanamID, int BusID)
    {
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var seats = from s in db.tab_VA_BUS_BOOKINGs
                        join r in db.tab_VA_SWAMY_REGISTRATIONs on s.user_ID equals r.swamy_ID
                        join p in db.tab_VA_PAYANAMs on s.payanam_ID equals p.payanam_ID
                        where s.payanam_ID == PayanamID && s.bus_NUMBER == BusID
                        join bd in db.tab_VA_PAYANAM_BUS_DETAILs on s.bus_NUMBER equals bd.bus_NUMBER
                        orderby s.seat_NUMBER
                        select new { r.swamy_CODE, r.swamy_NAME, r.swamy_FATHER_SPOUSE_NAME, r.swamy_PLACE, bd.vehicle_TYPE, r.swamy_MOBILE_NUMBER ,s.bus_NUMBER, s.seat_NUMBER, p.payanam_TITLE };

            if (seats.Count() > 0)
            {
                gvSwamies.DataSource = seats;
                gvSwamies.DataBind();
            }
            else
            {
                gvSwamies.DataSource = null;
                gvSwamies.DataBind();
            }
        }
    }

    protected   void btnExport_Click            (object sender, EventArgs e)
    {
        var BusID     = Convert.ToInt32(ddlBus.SelectedValue);
        var PayanamID = Convert.ToInt32(Request.QueryString["pid"]);

        if (BusID > 0)
        {
            var fileName = "Bus_Seat_Allotment.xlsx";
            var outputDirectory = Server.MapPath("~/management/resources/reports/");
            var outFileName = outputDirectory + fileName;
            if (File.Exists(outFileName))
                File.Delete(outFileName);
            var file = new FileInfo(outFileName);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Bus Allotment");

                ExcelRange rHeader;

                worksheet.Cells[1, 1, 1, 8].Merge = true;
                rHeader = worksheet.Cells[1, 1];
                rHeader.Value = "Sree Vallabai Ayyappan - Sabari Yatra Bus Booking Seat Allotment";
                rHeader.Style.Font.Size = 18;
                rHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rHeader.Style.Font.Bold = true;
                rHeader.Style.Font.Name = "Calibri";
                rHeader.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                rHeader.Style.Border.Right.Color.SetColor(Color.Gray);

                AddSecondHeaderTitle(worksheet, 2, 1, "S No");
                AddSecondHeaderTitle(worksheet, 2, 2, "Code");
                AddSecondHeaderTitle(worksheet, 2, 3, "Name");
                AddSecondHeaderTitle(worksheet, 2, 4, "Father");
                AddSecondHeaderTitle(worksheet, 2, 5, "Place");
                AddSecondHeaderTitle(worksheet, 2, 6, "Bus Number");
                AddSecondHeaderTitle(worksheet, 2, 7, "Seat Number");
                AddSecondHeaderTitle(worksheet, 2, 8, "Mobile Number");
                var rowIndex = 3;
                using (VallabaiDataContext db = new VallabaiDataContext())
                {
                    var seats = from s in db.tab_VA_BUS_BOOKINGs
                                join r in db.tab_VA_SWAMY_REGISTRATIONs on s.user_ID equals r.swamy_ID
                                join p in db.tab_VA_PAYANAMs on s.payanam_ID equals p.payanam_ID
                                join bd in db.tab_VA_PAYANAM_BUS_DETAILs on s.bus_NUMBER equals bd.bus_ID
                                where s.payanam_ID == PayanamID && s.bus_NUMBER == BusID
                                
                                orderby s.seat_NUMBER
                                select new { r.swamy_CODE, r.swamy_NAME, r.swamy_FATHER_SPOUSE_NAME, r.swamy_PLACE, r.swamy_MOBILE_NUMBER,
                                    bd.vehicle_TYPE,
                                    bd.bus_NUMBER,
                                    s.seat_NUMBER, 
                                    p.payanam_TITLE };

                    if (seats.Count() > 0)
                    {
                        var Index = 1;
                        foreach (var item in seats)
                        {
                            ExcelRange range;
                            range = worksheet.Cells[rowIndex, 1];
                            range.Value = Index;
                            AddDataRow(worksheet, rowIndex, 1, "S No", false);

                            range = worksheet.Cells[rowIndex, 2];
                            range.Value = item.swamy_CODE;
                            AddDataRow(worksheet, rowIndex, 2, "Code", false);

                            range = worksheet.Cells[rowIndex, 3];
                            range.Value = item.swamy_NAME;
                            AddDataRow(worksheet, rowIndex, 3, "Name", false);

                            range = worksheet.Cells[rowIndex, 4];
                            range.Value = item.swamy_FATHER_SPOUSE_NAME;
                            AddDataRow(worksheet, rowIndex, 4, "Name", false);

                            range = worksheet.Cells[rowIndex, 5];
                            range.Value = item.swamy_PLACE;
                            AddDataRow(worksheet, rowIndex, 5, "Place", false);

                            range = worksheet.Cells[rowIndex, 6];
                            range.Value = item.vehicle_TYPE + " - " + item.bus_NUMBER;
                            AddDataRow(worksheet, rowIndex, 6, "Bus Number", false);

                            range = worksheet.Cells[rowIndex, 7];
                            range.Value = item.seat_NUMBER;
                            AddDataRow(worksheet, rowIndex, 7, "Seat Number", false);

                            range = worksheet.Cells[rowIndex, 8];
                            range.Value = item.swamy_MOBILE_NUMBER;
                            AddDataRow(worksheet, rowIndex, 8, "Mobile", false);

                            Index++;
                            rowIndex++;
                        }
                    }
                    else
                    {
                        
                    }
                }
                package.Save();

                try
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    var displayFileName = string.Empty;
                    displayFileName = "Bus_SeatAllotment.xlsx";
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + displayFileName + "\"");
                    byte[] data = req.DownloadData(outFileName);
                    response.BinaryWrite(data);
                    response.End();
                }
                catch (Exception ex)
                {
                    if (!(ex is System.Threading.ThreadAbortException))
                        Response.Write(ex.Message.ToString());
                }
            }
        }
    }

    private     void AddDataRow                 (ExcelWorksheet worksheet, int rowIndex, int columnIndex, string columnName, bool isNumberFormatRequired)
    {
        ExcelRange range = worksheet.Cells[rowIndex, columnIndex];
        range.Style.Font.Name = "Calibri";
        range.Style.Font.Size = 10;
        if (isNumberFormatRequired)
            range.Style.Numberformat.Format = STR_ACCOUNTING_FORMAT;

        range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
        switch (columnName)
        {
            case "Name":
                worksheet.Column(columnIndex).Width = 18.75;
                break;
            case "S No":
                worksheet.Column(columnIndex).Width = 6.75;
                break;
            case "Code":
                worksheet.Column(columnIndex).Width = 10.75;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(252, 213, 180));
                break;
            
            default:
                range.Style.Border.Right.Style = ExcelBorderStyle.Hair;
                worksheet.Column(columnIndex).Width = 13;
                break;
        }
    }

    private     void AddSecondHeaderTitle       (ExcelWorksheet worksheet, int rowIndex, int columnIndex, string value)
    {
        ExcelRange range = worksheet.Cells[rowIndex, columnIndex];
        range.Value = value;
        range.Style.Font.Name = "Calibri";
        range.Style.Font.Size = 10;
        range.Style.Font.Bold = true;
        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        range.Style.Border.Top.Color.SetColor(Color.Black);
        range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
        switch (value)
        {
            case "Code":
                worksheet.Column(columnIndex).Width = 11.50;
                break;
            case "Father":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "Name":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "Mobile Number":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "Place":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "Bus Number":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "Seat Number":
                worksheet.Column(columnIndex).Width = 24.50;
                break;
            case "S No":
                worksheet.Column(columnIndex).Width = 4.56;
                break;
        }
    }
}