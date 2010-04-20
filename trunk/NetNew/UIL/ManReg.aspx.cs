using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ManReg : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.Page.Title = "Volunteer registration";
            ucEnumSelectorGender.EnumType = typeof(Utils.Enumerations.Gender);
            ucEnumSelectorGender.DefaultSelection = Utils.Enumerations.Gender.Man;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // creating manager instance and assigning values into it
        //BLL.BEntities.Manager Man = new BLL.BEntities.Manager();
            
        
        DAL.Manager Man = new DAL.Manager();
        Man.Address = new DAL.Address();
        Man.Address.City =  Utils.Convert.SafeString(txtCity.Text);
        Man.Address.Country = Utils.Convert.SafeString(txtCountry.Text);
        Man.Address.FlatNumber = Utils.Convert.SafeString(txtFlatNo.Text);
        Man.Address.HouseNumber = Utils.Convert.SafeString(txtHouseNo.Text);
        Man.Address.PostalCode = Utils.Convert.SafeString(txtPostalCode.Text);
        Man.Address.Street = Utils.Convert.SafeString(txtStreet.Text);
        Man.DateBirth = Convert.ToDateTime(Utils.Convert.SafeString(txtBirthDate.Text));
        Man.NameLastName = Utils.Convert.SafeString(txtFirstName.Text) + " " + Utils.Convert.SafeString(txtLastName.Text);
        Man.GenderVal = (short)ucEnumSelectorGender.SelectedValue<Utils.Enumerations.Gender>();
         

        var lines = txtExpertiseCrisisTypes.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var et = Utils.Convert.SafeString(line);
            if (et!="") 
                Man.ExpertiseCrisisTypes.Add(et);
        }

        var messages = Man.Validate();
        if (messages.Count>0)
        {
            Master.ShowMessage(MessageTypes.Error, messages.ToArray<string>());
            return;
        }


        /* TODO: Login/Password functionality needs to be added later*/

        //save the object in db
        
        DAL.Container.Instance.Managers.AddObject( Man );
        DAL.Container.Instance.SaveChanges();

        //redirecting to Managers's profile page
        Master.ShowMessage(MessageTypes.Info, "Successfully saved. Now you are being redirected to your profile page...");
        RedirectAfter (4,"ManProfile.aspx");
    }
}