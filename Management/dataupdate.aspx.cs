using DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dataupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        var fileName           = flData.FileName;
        var fileContentType    = flData.PostedFile.ContentType;
        var pathUploaded       = Uploader.FileUploader(flData.PostedFile);
        var connectionString   = Uploader.GetExcelConnectionString(fileContentType, pathUploaded);
        OleDbConnection OleCon = new OleDbConnection(connectionString);
        DataTable tbl          = new DataTable("MyTable");
        OleCon.Open();
        var tableName = OleCon.GetSchema("Tables").Rows[0]["TABLE_NAME"];
        OleDbCommand OleCmd = new OleDbCommand(string.Format("Select * from [{0}]", tableName), OleCon);
        OleDbDataAdapter adp = new OleDbDataAdapter(OleCmd);
        adp.Fill(tbl);

        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            foreach (DataRow row in tbl.Rows)
            {
                var OldRegID     = Convert.ToString(row.ItemArray[0]);
                var Code         = OldRegID;
                var Name         = Convert.ToString(row.ItemArray[1]);
                var FatherName   = Convert.ToString(row.ItemArray[2]);
                var Address      = Convert.ToString(row.ItemArray[3]);
                var Age          = Convert.ToString(row.ItemArray[4]);
                var MalaiDetail  = Convert.ToString(row.ItemArray[5]);
                var MalaiCount = 0;
                if (MalaiDetail != "")
                    MalaiCount = 0;
                else if (MalaiDetail == "KANNI")
                    MalaiCount = 1;
                else MalaiCount = Convert.ToInt32(MalaiDetail);

                var MobileNumber = Convert.ToString(row.ItemArray[6]);
                var Membership   = Convert.ToString(row.ItemArray[10]);
                var IsMember     = false;
                if (Membership  != "")
                    IsMember     = true;

                tab_VA_SWAMY_REGISTRATION reg = new tab_VA_SWAMY_REGISTRATION();
                try
                {
                    reg.swamy_CODE = Code;
                    reg.swamy_OLD_REG_NUMBER = OldRegID;
                    reg.swamy_NAME = Name;
                    reg.swamy_FATHER_SPOUSE_NAME = FatherName;
                    reg.swamy_GENDER = "Male";
                    reg.swamy_IS_MEMBER = IsMember;
                    reg.swamy_PLACE = Address;
                    reg.swamy_ADDRESS = Address;
                    reg.swamy_MOBILE_NUMBER = MobileNumber;
                    reg.swamy_DISTRICT = "Ramanathapuram";
                    reg.swamy_MALAI_VISIT = MalaiCount;
                    reg.swamy_MEMBERSHIP_TYPE = Membership;

                    db.tab_VA_SWAMY_REGISTRATIONs.InsertOnSubmit(reg);
                    db.SubmitChanges();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            Response.Write("Upload Completed");
        }
    }
}