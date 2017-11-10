using System;
using DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Modules_modules_Registration : System.Web.UI.Page
{
    protected   void Page_Load          (object sender, EventArgs e)    
    {
        txtName.Focus();
        if (!IsPostBack)
        {
            if (Request.QueryString["sid"] != null)
            {
                var SwamyID = Ciphering.Decrypt(Convert.ToString(Request.QueryString["sid"]));
                DisplayDetails(Convert.ToInt32(SwamyID));
            }
        }
    }
    protected   void btnSave_Click      (object sender, EventArgs e)    
    {
        if (Page.IsValid)
        {
            var SwamyName       = txtName.Text;
            var SwamyFatherName = txtFatherName.Text;
            var SwamyGender     = string.Empty;
            if (rdlSwamy.Checked)
                SwamyGender = rdlSwamy.Value;
            else
                SwamyGender          = rdlMaaligaipuram.Value;
            var SwamyDOB             = string.Empty;
            if (Utilities.isValidDate(txtDOB.Text))
                SwamyDOB = txtDOB.Text;

            var SwamyMobileNumber    = txtMobileNumber.Text;
            var SwamyAlternateMobile = txtAlternateMobile.Text;
            var SwamyPlace           = txtPlace.Text;
            var SwamyAddress         = txtAddress.Text;
            var SwamyDistrict        = ddlDistrict.SelectedValue;
            var SwamyBloodGroup      = ddlBloodGroup.SelectedValue;
            var SwamyMalaiVisit      = 0;
            if (Utilities.isNumber(txtMalai.Text))
                SwamyMalaiVisit      = Convert.ToInt32(txtMalai.Text);
            var SwamyKanniPoojaiDate = string.Empty;
            if (Utilities.isValidDate(txtKanniPoojaiDate.Text))
                SwamyKanniPoojaiDate = txtKanniPoojaiDate.Text;
            var SwamyMemebershipExpiry = string.Empty;
            if (Utilities.isValidDate(txtMembershipExpiry.Text))
                SwamyMemebershipExpiry = txtMembershipExpiry.Text;

            var SwamyMembership      = string.Empty;
            if (rdlNonMeber.Checked)
                SwamyMembership = rdlNonMeber.Value;
            else if (rdlLifetime.Checked)
                SwamyMembership = rdlLifetime.Value;
            else
                SwamyMembership = rdlShortTermMember.Value;

            //Get Swamy Code

            
            if (btnSave.Text == "Save")
            {
                var SwamyCode = Utilities.GetSwamyCode();

                using (VallabaiDataContext db = new VallabaiDataContext())
                {
                    tab_VA_SWAMY_REGISTRATION regis = new tab_VA_SWAMY_REGISTRATION();
                    regis.swamy_CODE                = SwamyCode;
                    regis.swamy_NAME                = SwamyName;
                    regis.swamy_FATHER_SPOUSE_NAME  = SwamyFatherName;
                    regis.swamy_GENDER              = SwamyGender;
                    if (!string.IsNullOrEmpty(SwamyDOB))
                        regis.swamy_DOB          = Convert.ToDateTime(SwamyDOB);
                    regis.swamy_PLACE            = SwamyPlace;
                    regis.swamy_ADDRESS          = SwamyAddress;
                    regis.swamy_MOBILE_NUMBER    = SwamyMobileNumber;
                    regis.swamy_ALTERNATE_MOBILE = SwamyAlternateMobile;
                    regis.swamy_DISTRICT         = SwamyDistrict;
                    regis.swamy_BLOOD_GROUP      = SwamyBloodGroup;
                    regis.swamy_MALAI_VISIT      = SwamyMalaiVisit;
                    if (!string.IsNullOrEmpty(SwamyKanniPoojaiDate))
                        regis.swamy_KANNI_POOJAI_DATE = Convert.ToDateTime(SwamyKanniPoojaiDate);
                    //regis.swamy_IS_MEMBER = 
                    regis.swamy_MEMBERSHIP_TYPE = SwamyMembership;
                    if (!string.IsNullOrEmpty(SwamyMemebershipExpiry))
                        regis.swamy_MEMBERSHIP_EXPIRY_DATE = Convert.ToDateTime(SwamyMemebershipExpiry);

                    db.tab_VA_SWAMY_REGISTRATIONs.InsertOnSubmit(regis);
                    db.SubmitChanges();

                    var SwamyID = Utilities.GetLatestRegisterID();
                    //Save The Photo against the Swamy
                    if (flPhoto.PostedFiles != null)
                    {
                        if (flPhoto.PostedFile.ContentLength > 0)
                            flPhoto.PostedFile.SaveAs(Server.MapPath("~/management/Resources/temp/" + SwamyID + ".jpg"));
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('User Details updated successfully')});", true);
                    ClearFields();
                }
            }
            else
            {
                if (Request.QueryString["sid"] != null)
                {
                    var SwamyID =Convert.ToInt32(Ciphering.Decrypt(Convert.ToString(Request.QueryString["sid"])));

                    using (VallabaiDataContext db = new VallabaiDataContext())
                    {
                        var swamy = from s in db.tab_VA_SWAMY_REGISTRATIONs
                                    where s.swamy_ID == SwamyID
                                    select s;
                        if (swamy.Count() > 0)
                        {
                            foreach (var regis in swamy)
                            {
                                regis.swamy_NAME = SwamyName;
                                regis.swamy_FATHER_SPOUSE_NAME = SwamyFatherName;
                                if (!string.IsNullOrEmpty(SwamyDOB))
                                    regis.swamy_DOB = Convert.ToDateTime(SwamyDOB);
                                regis.swamy_MOBILE_NUMBER = SwamyMobileNumber;
                                regis.swamy_ALTERNATE_MOBILE = SwamyAlternateMobile;
                                regis.swamy_PLACE = SwamyPlace;
                                regis.swamy_ADDRESS = SwamyAddress;
                                regis.swamy_DISTRICT = SwamyDistrict;
                                regis.swamy_BLOOD_GROUP = SwamyBloodGroup;
                                regis.swamy_MALAI_VISIT = SwamyMalaiVisit;
                                regis.swamy_MEMBERSHIP_TYPE = SwamyMembership;
                                if (!string.IsNullOrEmpty(SwamyMemebershipExpiry))
                                    regis.swamy_MEMBERSHIP_EXPIRY_DATE = Convert.ToDateTime(SwamyMemebershipExpiry);
                                if (flPhoto.PostedFiles != null)
                                {
                                    if (flPhoto.PostedFile.ContentLength > 0)
                                        flPhoto.PostedFile.SaveAs(Server.MapPath("~/management/Resources/temp/" + SwamyID + ".jpg"));
                                }

                                db.SubmitChanges();

                                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowStatus", "$(function() { funShowMessage('User Details updated successfully')});", true);
                                ClearFields();
                            }
                        }
                    }
                }
            }

        }
    }
    private     void DisplayDetails     (int SwamyID)                   
    {
        if (SwamyID> 0)
        {
            using (VallabaiDataContext db = new VallabaiDataContext())
            {
                var swamy = from s in db.tab_VA_SWAMY_REGISTRATIONs
                            where s.swamy_ID == SwamyID
                            select s;
                if (swamy.Count()> 0)
                {
                    foreach (var item in swamy)
                    {
                        txtName.Text                      = item.swamy_NAME;
                        txtFatherName.Text                = item.swamy_FATHER_SPOUSE_NAME;
                        if (item.swamy_GENDER             == "Maaligaipuram")
                            rdlMaaligaipuram.Checked      = true;
                        if (item.swamy_DOB               != null)
                            txtDOB.Text                   =  string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(item.swamy_DOB));
                        txtMobileNumber.Text              = item.swamy_MOBILE_NUMBER;
                        txtAlternateMobile.Text           = item.swamy_ALTERNATE_MOBILE;
                        txtPlace.Text                     = item.swamy_PLACE;
                        txtAddress.Text                   = item.swamy_ADDRESS;
                        ddlDistrict.SelectedValue         = item.swamy_DISTRICT;
                        ddlBloodGroup.SelectedValue       = item.swamy_BLOOD_GROUP;
                        txtMalai.Text                     = Convert.ToString(item.swamy_MALAI_VISIT);
                        if (item.swamy_KANNI_POOJAI_DATE != null)
                            txtKanniPoojaiDate.Text       = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(item.swamy_KANNI_POOJAI_DATE));

                        if (item.swamy_MEMBERSHIP_TYPE      == "Non Member")
                            rdlNonMeber.Checked             = true;
                        else if (item.swamy_MEMBERSHIP_TYPE == "Lifetime")
                            rdlLifetime.Checked             = true;
                        else
                            rdlShortTermMember.Checked = true;

                        if (item.swamy_MEMBERSHIP_EXPIRY_DATE != null)
                        {
                            txtMembershipExpiry.Text = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(item.swamy_MEMBERSHIP_EXPIRY_DATE));
                        }

                        if (File.Exists(Server.MapPath("~/management/resources/temp/" + SwamyID + ".jpg")))
                            imgPreviewPhoto.ImageUrl = Server.MapPath("~/management/resources/temp/" + SwamyID + ".jpg");
                        else
                            imgPreviewPhoto.ImageUrl = Server.MapPath("~/management/resources/temp/noimage.png");
                        btnSave.Text = "Update";
                        break;
                    }
                }
            }
        }
    }
    private     void ClearFields        ()                              
    {
        txtName.Text            = string.Empty;
        txtFatherName.Text      = string.Empty;
        txtDOB.Text             = string.Empty;
        txtMobileNumber.Text    = string.Empty;
        txtAlternateMobile.Text = string.Empty;
        txtPlace.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtMalai.Text = string.Empty;
        txtKanniPoojaiDate.Text = string.Empty;
        txtMembershipExpiry.Text = string.Empty;
        btnSave.Text = "Save";
    }
    protected   void btnBack_Click      (object sender, EventArgs e)    
    {
        Response.Redirect("~/management/modules/modules/regis.aspx");
    }
}