using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.Util;

public partial class ManReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Manager Registration";
            ucEnumSelectorGender.EnumType = typeof(VMSCORE.Util.Enums.Gender);
            ucEnumSelectorGender.DefaultSelection = VMSCORE.Util.Enums.Gender.Man;
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {   // creating manager instance and assigning values into it
        VMSCORE.EntityClasses.Manager Man = new VMSCORE.EntityClasses.Manager();
        Man.Address = new VMSCORE.EntityClasses.Address();
        Man.Address.City = ConvertUtil.SafeString(txtCity.Text);
        Man.Address.Country = ConvertUtil.SafeString(txtCountry.Text);
        Man.Address.FlatNumber = ConvertUtil.SafeString(txtFlatNo.Text);
        Man.Address.HouseNumber = ConvertUtil.SafeString(txtHouseNo.Text);
        Man.Address.PostalCode = ConvertUtil.SafeString(txtPostalCode.Text);
        Man.Address.Street = ConvertUtil.SafeString(txtStreet.Text);

        Man.NameLastName = ConvertUtil.SafeString(txtFirstName.Text) + " " + ConvertUtil.SafeString(txtLastName.Text);
        Man.GenderVal = (short)ucEnumSelectorGender.SelectedValue<VMSCORE.Util.Enums.Gender>();
        Man.ExpertiseCrisisTypes.Add(ConvertUtil.SafeString(txtExpertiseCrisisTypes.Text));

        /* Login/Password functionality needs to be added later*/

        //save the object in db
        VMSCORE.EntityClasses.Container.Instance.Managers.AddObject(Man);
        VMSCORE.EntityClasses.Container.Instance.SaveChanges();

        //redirecting to Managers's profile page
        //Response.Redirect("~/ManProfile.aspx"); //functionality is not implemented
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}   