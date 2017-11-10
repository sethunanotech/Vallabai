using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uploader
/// </summary>
public static class Uploader
{
    public static string GetExcelConnectionString(string ExcelType, string FilePath)
    {
        var Result = string.Empty;
        switch (ExcelType)
        {
            case "application/vnd.ms-excel":
            case "application/octet-stream":
                Result = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                break;
            case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                Result = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
                break;
        }
        return Result;
    }

    public static string FileUploader(HttpPostedFile File)
    {
        var Result = string.Empty;
        var extension = string.Empty;
        var fileName = string.Empty;
        var pathtoUpload = string.Empty;
        var rand = Guid.NewGuid().ToString();
        var DirectoryToUpload = "\\Resources\\Temp";

        try
        {
            fileName = File.FileName;
            extension = fileName.Split('.')[1];
            fileName = rand.Split('-')[1] + "." + extension;
            DirectoryToUpload = HttpContext.Current.Server.MapPath(DirectoryToUpload);

            pathtoUpload = string.Format("{0}\\{1}", DirectoryToUpload, fileName);
            bool isExists = Directory.Exists(DirectoryToUpload);
            if (!isExists)
                Directory.CreateDirectory(DirectoryToUpload);

            if (File != null && File.ContentLength > 0)
            {
                File.SaveAs(pathtoUpload);
            }
            Result = pathtoUpload;
        }
        catch (Exception ex)
        {
            Result = "500 - " + ex.Message.ToString();
        }
        return Result;
    }
}