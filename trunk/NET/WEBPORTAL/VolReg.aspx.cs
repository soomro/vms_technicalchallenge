using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.Util;

public partial class VolReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Volunteer registration";
            ucEnumSelectorGender.EnumType = typeof(VMSCORE.Util.Enums.Gender);
            ucEnumSelectorGender.DefaultSelection = VMSCORE.Util.Enums.Gender.Man;
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //make object and fill according to user inputs
        VMSCORE.EntityClasses.Volunteer vol = new VMSCORE.EntityClasses.Volunteer();
        vol.Address = new VMSCORE.EntityClasses.Address();
        vol.DateBirth = Convert.ToDateTime(VMSCORE.Util.ConvertUtil.SafeString(txtBirthDate.Text));
        vol.Address.City = ConvertUtil.SafeString(txtCity.Text);
        vol.Address.Country = ConvertUtil.SafeString(txtCountry.Text);
        vol.Address.FlatNumber = ConvertUtil.SafeString(txtFlatNo.Text);
        vol.Address.HouseNumber = ConvertUtil.SafeString(txtHouseNo.Text);
        vol.Address.PostalCode = ConvertUtil.SafeString(txtPostalCode.Text);
        vol.Address.Street = ConvertUtil.SafeString(txtStreet.Text);
        vol.NameLastName = ConvertUtil.SafeString(txtFirstName.Text)+" "+ConvertUtil.SafeString(txtLastName.Text);
        vol.GenderVal = (short)ucEnumSelectorGender.SelectedValue<VMSCORE.Util.Enums.Gender>();
        vol.Occupation = ConvertUtil.SafeString(txtOccupation.Text);
        vol.Address.Street = ConvertUtil.SafeString(txtStreet.Text);
        vol.CoordinatesStr = string.Empty;
        vol.CoordinateLastUpdateTime = DateTime.Now;
        vol.LastAccessTime = DateTime.Now;
        vol.Specifications = new System.Collections.ObjectModel.ObservableCollection<string>();
        vol.Specifications.Add(txtSpecialTraining.Text);

        //save the object in db
        VMSCORE.EntityClasses.Container.Instance.Volunteers.AddObject(vol);
        VMSCORE.EntityClasses.Container.Instance.SaveChanges();

        //redirecting to volunteer's profile page
        Response.Redirect("~/volProfile.aspx");

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
            
    }
}