using System;
using System.Linq;
using DAL;
using Utils.Enumerations;

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
        if (ddlUserType.SelectedValue == UserTypes.Volunteer.ToString())
        {
            Response.Redirect(Constants.PageVolunteerProfile + "?Action=Create");
        }
        else if (ddlUserType.SelectedValue == UserTypes.Manager.ToString())
        {
            Response.Redirect(Constants.PageManagerProfile + "?Action=Create");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue == UserTypes.Volunteer.ToString())
        {
            Volunteer user = Container.Instance.Volunteers.SingleOrDefault(row => row.Username == txtUserName.Text);
            if (user != null && user.Password == txtPassword.Text)
            {
                CurrentVolunteer = user;
                Response.Redirect(Constants.PageVolunteerProfile + "?Action=Edit");
            }
            else
            {
                Master.ShowMessage(MessageTypes.Error, "Username or password is wrong!");
            }
        }
        if (ddlUserType.SelectedValue == UserTypes.Manager.ToString())
        {
            Manager user = Container.Instance.Managers.SingleOrDefault(row => row.UserName == txtUserName.Text);
            if (user != null && user.Password == txtPassword.Text)
            {
                CurrentManager = user;
                if (!string.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    Response.Redirect(Server.UrlDecode(Request["ReturnUrl"]));
                }
                Response.Redirect(Constants.PageManagerProfile + "?Action=Edit");
            }
            else
            {
                Master.ShowMessage(MessageTypes.Error, "Username or password is wrong!");
            }
        }
    }
}