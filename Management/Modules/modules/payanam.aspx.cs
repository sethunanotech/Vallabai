using DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_modules_payanam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPayanam();
        }
    }

    private void    BindPayanam()
    {
        using (VallabaiDataContext db = new VallabaiDataContext())
        {
            var payanam = from p in db.tab_VA_PAYANAMs
                          orderby p.year descending
                          select new { p.payanam_ID, p.year, p.payanam_TITLE, p.payanam_STARTDATE, p.payanam_ENDATE };
            if (payanam.Count() > 0)
            {
                gvPayanam.DataSource = payanam;
                gvPayanam.DataBind();
            }
        }
    }
}