using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Volunteer.ToString())
        {
            Response.Redirect("~/VolReg.aspx");

        }
        else if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Manager.ToString())
        {
            Response.Redirect("~/ManReg.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

    }
}