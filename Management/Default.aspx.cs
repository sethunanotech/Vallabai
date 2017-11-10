using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {    
           if (!Page.IsPostBack)
           {
                txtAccessCode.Focus();
                lblErrMsg.Text = "";
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["err"] != null)
                    {
                        lblErrMsg.Text = Utilities.GetErrorMessge(Convert.ToString(Request.QueryString["err"]));
                    }
                    else lblErrMsg.Text = "";
                }
            }
       }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var UserName = Server.HtmlEncode(txtAccessCode.Text);
        var Password = Server.HtmlEncode(txtPassword.Text);
        var IsValid = Authentication.AuthenticateUser(UserName, Password);
        if (IsValid)
            Response.Redirect("~/management/modules/modules/regis.aspx");
        else Response.Redirect("default.aspx?err=AUT404");
    }
}