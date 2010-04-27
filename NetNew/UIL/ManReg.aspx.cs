﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Enumerations;


public partial class ManReg : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Manager Registration";
            ucEnumSelectorGender.EnumType = typeof(Utils.Enumerations.Gender);
            ucEnumSelectorGender.DefaultSelection = Utils.Enumerations.Gender.Man;


            btnRegister.Visible = true;
            btnCancel.Visible=true;

            divForm.Enabled =true;

            if (PageAction == PageActions.Edit)
            { // initialize page for editing

                // each manager can edit his own profile. check session for user info
                if (CurrentUser==null)
                {
                    Master.ShowMessage(MessageTypes.Error, "You must login to see your profile");
                    btnRegister.Enabled = false;
                    return;
                }

                txtFullName.Text = CurrentUser.NameLastName;
                txtBirthDate.Text = CurrentUser.DateBirth.ToString("yyyy-MM-dd");
                ucEnumSelectorGender.DefaultSelection = CurrentUser.GenderVal;
                foreach (var item in CurrentUser.ExpertiseCrisisTypes)
                {
                    txtExpertiseCrisisTypes.Text += item + Environment.NewLine;
                }
                txtCountry.Text = CurrentUser.Address.Country;
                txtCity.Text= CurrentUser.Address.City;
                txtStreet.Text = CurrentUser.Address.Street;
                txtHouseNo.Text = CurrentUser.Address.HouseNumber;
                txtFlatNo.Text = CurrentUser.Address.FlatNumber;
                txtPostalCode.Text = CurrentUser.Address.PostalCode;
                txtHouseNo.Text = CurrentUser.Address.HouseNumber;
                txtUserName.Text = CurrentUser.UserName;
                txtUserName.Enabled = false;

                btnRegister.Text = "Update";
            }

            else if (PageAction == PageActions.Create)// Create crisis 
            {// initialize page for creating 
                CurrentUser = null;
                txtFullName.Text = "";
                txtBirthDate.Text = "";
                txtExpertiseCrisisTypes.Text  = "";
                txtCountry.Text = "";
                txtCity.Text="";
                txtStreet.Text = "";
                txtHouseNo.Text ="";
                txtFlatNo.Text = "";
                txtPostalCode.Text = "";
                txtHouseNo.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                btnRegister.Text = "Register";

            }
            else if (PageAction == PageActions.View)
            {
                // each manager can view his own profile. check session for user info
                if (CurrentUser==null)
                {
                    Master.ShowMessage(MessageTypes.Error, "You must login to see your profile");
                    btnRegister.Enabled = false;
                    return;
                }

                txtFullName.Text = CurrentUser.NameLastName;
                txtBirthDate.Text = CurrentUser.DateBirth.ToString("yyyy-MM-dd");
                ucEnumSelectorGender.DefaultSelection = CurrentUser.GenderVal;
                foreach (var item in CurrentUser.ExpertiseCrisisTypes)
                {
                    txtExpertiseCrisisTypes.Text += item + Environment.NewLine;
                }
                txtCountry.Text = CurrentUser.Address.Country;
                txtCity.Text= CurrentUser.Address.City;
                txtStreet.Text = CurrentUser.Address.Street;
                txtHouseNo.Text = CurrentUser.Address.HouseNumber;
                txtFlatNo.Text = CurrentUser.Address.FlatNumber;
                txtPostalCode.Text = CurrentUser.Address.PostalCode;
                txtHouseNo.Text = CurrentUser.Address.HouseNumber;
                txtUserName.Text = CurrentUser.UserName;
                txtUserName.Enabled = false;

                btnRegister.Visible = false;
                btnCancel.Visible=false;
                divForm.Enabled =false;
                
            }

            else
            {
                Response.Redirect(Constants.PageManagerProfile+"?"+Constants.IdAction+"=Create");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CurrentUser = null;
        Response.Redirect("~/Login.aspx");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {


        DAL.Manager Man = null;
        if (PageAction ==PageActions.Create)
        {
            Man = new DAL.Manager();
        }
        else if (CurrentUser!=null && PageAction == PageActions.Edit)
        {
            Man = CurrentUser;
        }
        else
        {
            Master.ShowMessage(MessageTypes.Error, "Login first");
            divForm.Enabled = false;
        }
        Man.Address = new DAL.Address();
        Man.Address.City =  Utils.Convert.SafeString(txtCity.Text);
        Man.Address.Country = Utils.Convert.SafeString(txtCountry.Text);
        Man.Address.FlatNumber = Utils.Convert.SafeString(txtFlatNo.Text);
        Man.Address.HouseNumber = Utils.Convert.SafeString(txtHouseNo.Text);
        Man.Address.PostalCode = Utils.Convert.SafeString(txtPostalCode.Text);
        Man.Address.Street = Utils.Convert.SafeString(txtStreet.Text);

        DateTime tempDate = new DateTime();

        var succeed = DateTime.TryParse(Utils.Convert.SafeString(txtBirthDate.Text), out tempDate);
        if (!succeed)
        {
            Master.ShowMessage(MessageTypes.Error, "Birth date is not correct");
            return;
        }
        Man.DateBirth = tempDate;

        Man.NameLastName = Utils.Convert.SafeString(txtFullName.Text);
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

        if (PageAction == PageActions.Create && // if we are creating new profile and there is already someone with that username
                DAL.Container.Instance.Managers.Count(man => man.UserName == Man.UserName) > 0)
        {
            Master.ShowMessage(MessageTypes.Error, string.Format("'{0}' is not available. Please select another username", Man.UserName));
            return; // show error message and cancel operation
        }

        var messages = Man.Validate(); // check the fields and return error messages if any
        if (messages.Count>0) // there are error messages
        {
            Master.ShowMessage(MessageTypes.Error, messages.ToArray<string>()); // show them
            return; // cancel operation
        }


        /* TODO: Login/Password functionality needs to be added later*/

        //save the object in db
        if(PageAction==PageActions.Create)
            DAL.Container.Instance.Managers.AddObject(Man);

        DAL.Container.Instance.SaveChanges();

        CurrentUser = Man;
        if (PageAction==PageActions.Create)
        {
            Master.ShowMessage(MessageTypes.Info, "Successfully saved.");
            RedirectAfter(4, Constants.PageManagerProfile+"?Action=Edit");
            
        }
        else if (PageAction==PageActions.Edit)
        {
            //redirecting to Managers's profile page
            Master.ShowMessage(MessageTypes.Info, "Successfully updated."); 
        }
        
        


    }
}