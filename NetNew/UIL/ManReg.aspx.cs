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
            Master.PageTitle = "Manager Registration";
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
            
        
        DAL.Manager Man = new DAL.Manager();
        Man.Address = new DAL.Address();
        Man.Address.City =  Utils.Convert.SafeString(txtCity.Text);
        Man.Address.Country = Utils.Convert.SafeString(txtCountry.Text);
        Man.Address.FlatNumber = Utils.Convert.SafeString(txtFlatNo.Text);
        Man.Address.HouseNumber = Utils.Convert.SafeString(txtHouseNo.Text);
        Man.Address.PostalCode = Utils.Convert.SafeString(txtPostalCode.Text);
        Man.Address.Street = Utils.Convert.SafeString(txtStreet.Text);

        DateTime tempDate = new DateTime();

        var succeed = DateTime.TryParse(Utils.Convert.SafeString(txtBirthDate.Text),out tempDate);
        if (!succeed)
        {
            Master.ShowMessage(MessageTypes.Error, "Birth date is not correct");
            return;
        }
        Man.DateBirth = tempDate;
        
        Man.NameLastName = Utils.Convert.SafeString(txtFirstName.Text) + " " + Utils.Convert.SafeString(txtLastName.Text);
        Man.GenderVal = (short)ucEnumSelectorGender.SelectedValue<Utils.Enumerations.Gender>();
         

        var lines = txtExpertiseCrisisTypes.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var et = Utils.Convert.SafeString(line);
            if (et!="") 
                Man.ExpertiseCrisisTypes.Add(et);
        }

        Man.UserName = Utils.Convert.SafeString(txtUserName.Text);
        Man.Password = Utils.Convert.SafeString(txtPassword.Text);

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