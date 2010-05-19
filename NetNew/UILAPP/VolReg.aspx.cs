using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Utils.Enumerations;
using Convert = Utils.Convert;

//TODO: Code commenting
//TODO: User input checking
//TODO: Showing messages according to use-case if somewhere is needed
public partial class VolReg : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucEnumGender1.EnumType = typeof (Gender);
            ucEnumGender1.DefaultSelection = Gender.Man;
            DAL.Volunteer vol = GetVolunteer();
            if (vol!=null)
            {
                Master.PageTitle = "View Volunteer's Profile";
                FillUiWithVolunteer(vol);
                Disablepage();
            }
            else if (PageAction == PageActions.Edit)
            {
                Master.PageTitle = "Edit Volunteer's Profile";
                if (CurrentVolunteer == null)
                    Response.Redirect(Constants.PageVolunteerProfile + "?Action=Create");
                else
                    FillUiWithVolunteer(CurrentVolunteer);
                btnRegister.Text = "Update";
                btnDeleteProfile.Visible = true;
            }
            else if (PageAction == PageActions.Create)
            {
                Master.PageTitle = "Volunteer Registration";
                btnRegister.Text = "Register";
                btnDeleteProfile.Visible = false;
                CurrentVolunteer = null;
                CurrentManager = null;
            }
            else
            {
                Response.Redirect(Constants.PageVolunteerProfile + "?Action=Create");
            }
        }
    }

    private void Disablepage()
    {
        btnRegister.Enabled = false;
        btnConfirm.Enabled = false;
        btnDeleteProfile.Enabled = false;
    }

    private Volunteer GetVolunteer()
    {
        int vid = Utils.Convert.ToInt(Request["vid"] + "", 0);
        return (from v in DAL.Container.Instance.Volunteers
                where v.Id == vid
                select v).FirstOrDefault();
    }

    private void FillUiWithVolunteer(Volunteer vol)
    {
        if (vol.BirthDate != null) txtBirthDate.Text = vol.BirthDate.Value.ToString("yyyy-MM-dd");
        txtCity.Text = vol.Address.City;
        txtCountry.Text = vol.Address.Country;
        txtEmailAddress.Text = vol.EmailAddr;
        txtName.Text = vol.NameLastName;
        txtOccupation.Text = vol.Occupation;
        txtUserName.Text = vol.Username;
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
        txtPassword.Text = "";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (PageAction == PageActions.Create)
        {
            // make sure there is no such a user with this username
            Volunteer q = Container.Instance.Volunteers.SingleOrDefault(row => row.Username == txtUserName.Text);
            if (q != null)
            {
                Master.ShowMessage(MessageTypes.Error, "Another user with this username already exists in the system.");
                return;
            }
            //Check for validity of date entered
            var tempDate = new DateTime();
            bool succeed = DateTime.TryParse(Convert.SafeString(txtBirthDate.Text), out tempDate);
            if (!succeed)
            {
                Master.ShowMessage(MessageTypes.Error, "Birth date is not correct");
                return;
            }

            //make object and fill according to user inputs
            var vol = new Volunteer();
            if (!FillVolunteer(vol))
                return;

            //Validation of inputs
            IList<string> messages = vol.Validate(); // check the fields and return error messages if any

            if (messages.Count > 0) // there are error messages
            {
                Master.ShowMessage(MessageTypes.Error, messages.ToArray()); // show them
                return; // cancel operation
            }
            //save the object in db
            Container.Instance.Volunteers.AddObject(vol);
            Container.Instance.SaveChanges();
            CurrentVolunteer = vol;
            //show message of successfull completion
            Master.ShowMessage(MessageTypes.Info, "Volunteer registered successfully.");
            btnRegister.Visible = false;
            RedirectAfter(4, Constants.PageVolunteerProfile + "?Action=Edit");
        }
        else if (PageAction == PageActions.Edit)
        {
            //make object and fill according to user inputs
            Volunteer vol = CurrentVolunteer;
            var curPass = vol.Password;

            if (!FillVolunteer(vol))
                return;
            if (vol.Password!=curPass)
            {
                Master.ShowMessage(MessageTypes.Error, "Passwords doesn't match! ");
                return;
            }
            //Validation of inputs
            IList<string> messages = vol.Validate(); // check the fields and return error messages if any

            if (messages.Count > 0) // there are error messages
            {
                Master.ShowMessage(MessageTypes.Error, messages.ToArray()); // show them
                return; // cancel operation
            }

            //Make changes presistent
            Container.Instance.SaveChanges();
            Master.ShowMessage(MessageTypes.Info, "Changes sumbited to system successfully.");
        }
    }

    /// <summary>
    /// Fills a volunteer object accoridng to user inputs
    /// </summary>
    /// <param name="vol">volunteer instance</param>
    private bool FillVolunteer(Volunteer vol)
    {
        
        List<string> messages = new List<string>();

        vol.Address = new Address();
        vol.NameLastName = Convert.SafeString(txtName.Text);
        vol.BirthDate = Utils.Convert.ToDateTime(txtBirthDate.Text);
        vol.Address.City = Convert.SafeString(txtCity.Text);
        vol.Address.Country = Convert.SafeString(txtCountry.Text);
        vol.Address.FlatNumber = Convert.SafeString(txtFlatNo.Text);
        vol.Address.HouseNumber = Convert.SafeString(txtHouseNo.Text);
        vol.Address.PostalCode = Convert.SafeString(txtPostalCode.Text);
        vol.Address.Street = Convert.SafeString(txtStreet.Text);
        vol.Gender = ucEnumGender1.SelectedValue<Gender>();
        vol.Occupation = Convert.SafeString(txtOccupation.Text);
        vol.Address.Street = Convert.SafeString(txtStreet.Text);
        vol.CoordinatesStr = string.Empty;
        vol.CoordinateLastUpdateTime = DateTime.Now;
        vol.LastAccessTime = DateTime.Now.AddYears(-10);
        vol.EduAndTrainings = txtSpecialTraining.Text;
        vol.EmailAddr = txtEmailAddress.Text;
        vol.Username = txtUserName.Text;
        vol.Password = txtPassword.Text;
        decimal tmpDecimal;
        if (!decimal.TryParse(txtWeight.Text, out tmpDecimal) || tmpDecimal >= 1000L)
        {
            Master.ShowMessage(MessageTypes.Error, "Weight should be a floating point number less than 1000");
            return false;
        }

        vol.Weight = tmpDecimal;
        if (!decimal.TryParse(txtHeight.Text, out tmpDecimal) || tmpDecimal >= 1000L)
        {
            Master.ShowMessage(MessageTypes.Error, "Height should be a number less than 1000");
            return false;
        }
        vol.Height = tmpDecimal;
        vol.HealthProb = txtHealthProblem.Text;
        vol.Phone = txtPhone.Text;

        
        return true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CurrentVolunteer = null;
        Response.Redirect(Constants.PageCrisisBoard);
    }

    protected void btnDeleteProfile_Click(object sender, EventArgs e)
    {
        pnlDeleteConfirm.Visible = true;
        btnDeleteProfile.Visible = false;
        btnRegister.Visible = false;
        btnCancel.Visible = false;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (rdlDeleteConfirm.SelectedValue == "Yes")
        {

            bool canremove;
            foreach (var rr in CurrentVolunteer.RequestResponses)
            {
                var r = rr.Request;
                var i = r.Incident;
                var c = i.Crisis;
                if (c.Status!=CrisisStatuses.Closed && i.IncidentStatus!= IncidentStatuses.Complete
                    && rr.Status!=RequestResponseStatuses.Canceled && rr.Answer == true)
                {
                    rr.Status = RequestResponseStatuses.Canceled;
                    rr.Answer = false;
                }
            }
            
            Container.Instance.Volunteers.DeleteObject(CurrentVolunteer);
            Container.Instance.SaveChanges();
            CurrentVolunteer = null;
            Response.Redirect(Constants.PageLogin);
        }
        else
        {
            pnlDeleteConfirm.Visible = false;
            btnDeleteProfile.Visible = true;
            btnRegister.Visible = true;
            btnCancel.Visible = true;
        }
    }
}