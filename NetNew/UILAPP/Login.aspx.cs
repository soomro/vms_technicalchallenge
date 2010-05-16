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
        if (!IsPostBack)
        {
            Master.PageTitle = "Login Page";
        }
        CurrentManager = null;
        CurrentVolunteer = null;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Volunteer.ToString())
        {
            Response.Redirect(Constants.PageVolunteerProfile+"?Action=Create");

        }
        else if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Manager.ToString())
        {
            Response.Redirect(Constants.PageManagerProfile+"?Action=Create");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Volunteer.ToString())
        {
            var user =DAL.Container.Instance.Volunteers.SingleOrDefault(row => row.Username == txtUserName.Text);
            if (user != null && user.Password == txtPassword.Text)
            {
                CurrentVolunteer = user;
                Response.Redirect(Constants.PageVolunteerProfile+"?Action=Edit");
            }
            else
            {
                Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Username or password is wrong!");
            }
        }
        if (ddlUserType.SelectedValue == Utils.Enumerations.UserTypes.Manager.ToString())
        {
            var user = DAL.Container.Instance.Managers.SingleOrDefault(row => row.UserName == txtUserName.Text);
            if (user != null && user.Password == txtPassword.Text)
            {
                CurrentManager = user;
                if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    Response.Redirect(Server.UrlDecode(Request["ReturnUrl"]));
                }
                Response.Redirect(Constants.PageManagerProfile+"?Action=Edit");
            }
            else
            {
                Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Username or password is wrong!");
            }
        }
    }
}