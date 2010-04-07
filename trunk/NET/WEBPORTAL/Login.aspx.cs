using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue==VMSCORE.Util.Enums.UserType.Volunteer.ToString())
        {
            Response.Redirect("~/VolReg.aspx");
           
        }
        else if (ddlUserType.SelectedValue == VMSCORE.Util.Enums.UserType.Manager.ToString())
        {
            Response.Redirect("~/ManReg.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

    }
}