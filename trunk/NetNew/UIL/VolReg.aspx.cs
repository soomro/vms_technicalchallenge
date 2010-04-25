using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Enumerations;
//TODO: Code commenting
//TODO: User input checking
//TODO: Showing messages according to use-case if somewhere is needed
public partial class VolReg : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Volunteer registration";
            ucEnumGender1.EnumType = typeof(Utils.Enumerations.Gender);
            ucEnumGender1.DefaultSelection = Utils.Enumerations.Gender.Man;
            if (PageAction == PageActions.Edit)
            {
                //for test
                CurrentVolunteer = DAL.Container.Instance.Volunteers.SingleOrDefault(row => row.NameLastName == "text");
                if (CurrentVolunteer == null)
                    Response.Redirect("~/" + Constants.PageVolunteerProfile + "?Action=Create");
                else
                    FillUiWithVolunteer(CurrentVolunteer);
                btnRegister.Text = "Update";
            }
            else if (PageAction == PageActions.Create)
            {
                btnRegister.Text = "Register";
            }
            else
            {
                Response.Redirect("~/" + Constants.PageVolunteerProfile + "?Action=Create");
            }
        }
    }

    private void FillUiWithVolunteer(DAL.Volunteer vol)
    {
        txtBirthDate.Text = vol.BirthDate.Value.ToShortDateString();
        txtCity.Text = vol.Address.City;
        txtCountry.Text = vol.Address.Country;
        txtEmailAddress.Text = vol.EmailAddr;
        txtName.Text = vol.NameLastName;
        txtOccupation.Text = vol.Occupation;
        txtUserName.Text=vol.Username;
        txtUserName.Enabled = false;
        txtPhone.Text = vol.Phone;
        txtPostalCode.Text = vol.Address.PostalCode;
        txtSpecialTraining.Text = vol.EduAndTrainings;
        txtStreet.Text = vol.Address.Street;
        txtWeight.Text = vol.Weight.ToString();
        txtFlatNo.Text = vol.Address.FlatNumber;
        txtHealthProblem.Text = vol.HealthProb;
        txtHeight.Text = vol.Height.ToString();
        txtHouseNo.Text = vol.Address.HouseNumber;
        ucEnumGender1.DefaultSelection = vol.Gender;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //TODO: Check user inputs for format and data
        if (PageAction==PageActions.Create)
        {
            // make sure there is no such a user with this username
            var q = DAL.Container.Instance.Volunteers.SingleOrDefault(row => row.Username == txtUserName.Text);
            if (q != null)
            {
                Master.ShowMessage(MessageTypes.Error, "There is already such a user in the system. Change the username.");
                return;
            }
            //make object and fill according to user inputs
            DAL.Volunteer vol = new DAL.Volunteer();
            
            //Validation of inputs
            var messages = vol.Validate(); // check the fields and return error messages if any

            if (messages.Count > 0) // there are error messages
            {
                Master.ShowMessage(MessageTypes.Error, messages.ToArray<string>()); // show them
                return; // cancel operation
            }

            FillVolunteer(vol);
            //save the object in db
            DAL.Container.Instance.Volunteers.AddObject(vol);
            DAL.Container.Instance.SaveChanges();
            this.CurrentVolunteer = vol;
            //show message of successfull completion
            Master.ShowMessage(MessageTypes.Info, "Volunteer registered successfully");
        }
        else if (PageAction == PageActions.Edit)
        {

        }
    }

    /// <summary>
    /// Fills a volunteer object accoridng to user inputs
    /// </summary>
    /// <param name="vol">volunteer instance</param>
    private void FillVolunteer(DAL.Volunteer vol)
    {
        // creating address instance and assigning values into 
        vol.Address = new DAL.Address();
        vol.NameLastName = Utils.Convert.SafeString(txtName.Text);
        vol.BirthDate = Convert.ToDateTime(Utils.Convert.SafeString(txtBirthDate.Text));
        vol.Address.City = Utils.Convert.SafeString(txtCity.Text);
        vol.Address.Country = Utils.Convert.SafeString(txtCountry.Text);
        vol.Address.FlatNumber = Utils.Convert.SafeString(txtFlatNo.Text);
        vol.Address.HouseNumber = Utils.Convert.SafeString(txtHouseNo.Text);
        vol.Address.PostalCode = Utils.Convert.SafeString(txtPostalCode.Text);
        vol.Address.Street = Utils.Convert.SafeString(txtStreet.Text);
        vol.Gender = ucEnumGender1.SelectedValue<Utils.Enumerations.Gender>();
        vol.Occupation = Utils.Convert.SafeString(txtOccupation.Text);
        vol.Address.Street = Utils.Convert.SafeString(txtStreet.Text);
        vol.CoordinatesStr = string.Empty;
        vol.CoordinateLastUpdateTime = DateTime.Now;
        vol.LastAccessTime = DateTime.Now;
        vol.EduAndTrainings = txtSpecialTraining.Text;
        vol.EmailAddr = txtEmailAddress.Text;
        vol.Username = txtUserName.Text;
        vol.Password = txtPassword.Text;
        vol.Weight = Convert.ToDecimal(txtWeight.Text);
        vol.Height = Convert.ToDecimal(txtHeight.Text);
        vol.HealthProb = txtHealthProblem.Text;
        vol.Phone = txtPhone.Text;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}