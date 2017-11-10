using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBContext;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Net;

public partial class Modules_modules_Regis : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegistration();
        }
    }

    private void BindRegistration()
    {
        using (VallabaiDataContext db=new VallabaiDataContext())
        {
            var regis = from r in db.tab_VA_SWAMY_REGISTRATIONs
                        orderby r.swamy_ID descending
                        select r;
            if (regis.Count() > 0)
            {
                gvSwamies.DataSource = regis;
                gvSwamies.DataBind();
            }
        }
    }

    protected string GetSwamyType(int Visit)
    {
        var Result = string.Empty;
        switch (Visit)
        {
            case 1:
                Result = "Kanni";
                break;
            case 3:
                Result = "Manikandan";
                break;
            default:
                Result = "";
                break;
        }
        return Result;
    }

    protected void gvEdit_Click(object sender, EventArgs e)
    {
        int SwamyID = Convert.ToInt32(((Button)sender).CommandArgument);
        Response.Redirect("registration.aspx?sid=" + Ciphering.Encrypt(Convert.ToString(SwamyID)));
    }

    protected void btnNewRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("registration.aspx");
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        var fileName = "Users.xlsx";
        var outputDirectory = Server.MapPath("~/management/resources/reports/");
        var outFileName = outputDirectory + fileName;
        if (File.Exists(outFileName))
            File.Delete(outFileName);
        var file = new FileInfo(outFileName);

        using (var package = new ExcelPackage(file))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Users");

            ExcelRange rHeader;

            worksheet.Cells[1, 1, 1, 8].Merge = true;
            rHeader = worksheet.Cells[1, 1];
            rHeader.Value = "Sree Vallabai Ayyappan - Complete Swamy Lists";
            rHeader.Style.Font.Size = 18;
            rHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            rHeader.Style.Font.Bold = true;
            rHeader.Style.Font.Name = "Calibri";
            rHeader.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            rHeader.Style.Border.Right.Color.SetColor(Color.Gray);

            AddSecondHeaderTitle(worksheet, 2, 1, "S No");
            AddSecondHeaderTitle(worksheet, 2, 2, "Code");
            AddSecondHeaderTitle(worksheet, 2, 3, "Name");
            AddSecondHeaderTitle(worksheet, 2, 4, "Father/Spouse");
            AddSecondHeaderTitle(worksheet, 2, 5, "Gender");
            AddSecondHeaderTitle(worksheet, 2, 6, "Blood Group");
            AddSecondHeaderTitle(worksheet, 2, 7, "Place");
            AddSecondHeaderTitle(worksheet, 2, 8, "Address");
            AddSecondHeaderTitle(worksheet, 2, 9, "District");
            AddSecondHeaderTitle(worksheet, 2, 10, "Mobile Number");
            AddSecondHeaderTitle(worksheet, 2, 11, "Alternate Mobile Number");
            AddSecondHeaderTitle(worksheet, 2, 12, "Membership");

            var RowIndex = 3;

            using (VallabaiDataContext db = new VallabaiDataContext())
            {
                var reg = from r in db.tab_VA_SWAMY_REGISTRATIONs
                          orderby r.swamy_CODE
                          select r;

                if (reg.Count() > 0)
                {
                    var Index = 1;
                    foreach (var item in reg)
                    {
                        ExcelRange range;
                        range = worksheet.Cells[RowIndex, 1];
                        range.Value = Index;
                        AddDataRow(worksheet, RowIndex, 1, "S No", false);

                        range = worksheet.Cells[RowIndex, 2];
                        range.Value = item.swamy_CODE;
                        AddDataRow(worksheet, RowIndex, 2, "Code", false);
                        range = worksheet.Cells[RowIndex, 3];
                        range.Value = item.swamy_NAME;
                        AddDataRow(worksheet, RowIndex, 3, "Name", false);

                        range = worksheet.Cells[RowIndex, 4];
                        range.Value = item.swamy_FATHER_SPOUSE_NAME;
                        AddDataRow(worksheet, RowIndex, 4, "Name", false);

                        range = worksheet.Cells[RowIndex, 5];
                        range.Value = item.swamy_GENDER;
                        AddDataRow(worksheet, RowIndex, 5, "Name", false);

                        range = worksheet.Cells[RowIndex, 6];
                        range.Value = item.swamy_BLOOD_GROUP;
                        AddDataRow(worksheet, RowIndex, 6, "Name", false);

                        range = worksheet.Cells[RowIndex, 7];
                        range.Value = item.swamy_PLACE;
                        AddDataRow(worksheet, RowIndex, 7, "Name", false);

                        range = worksheet.Cells[RowIndex, 8];
                        range.Value = item.swamy_ADDRESS;
                        AddDataRow(worksheet, RowIndex, 8, "Name", false);

                        range = worksheet.Cells[RowIndex, 9];
                        range.Value = item.swamy_DISTRICT;
                        AddDataRow(worksheet, RowIndex, 9, "Name", false);

                        range = worksheet.Cells[RowIndex, 10];
                        range.Value = item.swamy_MOBILE_NUMBER;
                        AddDataRow(worksheet, RowIndex, 10, "Name", false);

                        range = worksheet.Cells[RowIndex, 11];
                        range.Value = item.swamy_ALTERNATE_MOBILE;
                        AddDataRow(worksheet, RowIndex, 11, "Name", false);

                        range = worksheet.Cells[RowIndex, 12];
                        range.Value = item.swamy_MEMBERSHIP_TYPE;
                        AddDataRow(worksheet, RowIndex, 12, "Name", false);
                        Index++;
                        RowIndex++;
                    }
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
                displayFileName = "UsersList.xlsx";
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

    private void AddDataRow(ExcelWorksheet worksheet, int rowIndex, int columnIndex, string columnName, bool isNumberFormatRequired)
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

    private void AddSecondHeaderTitle(ExcelWorksheet worksheet, int rowIndex, int columnIndex, string value)
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