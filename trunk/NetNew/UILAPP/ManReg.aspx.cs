using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils.Constants;
using Utils.Enumerations;
using Convert = Utils.Convert;

public partial class ManReg : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Manager Registration";
            ucEnumSelectorGender.EnumType = typeof (Gender);
            ucEnumSelectorGender.DefaultSelection = Gender.Man;


            btnRegister.Visible = true;
            btnCancel.Visible = true;

            pnlDivForm.Enabled = true;

            if (PageAction == PageActions.Edit)
            {
                // initialize page for editing

                // each manager can edit his own profile. check session for user info
                if (CurrentManager == null)
                {
                    Master.ShowMessage(MessageTypes.Error, "You must login to see your profile");
                    btnRegister.Enabled = false;
                    return;
                }

                txtFullName.Text = CurrentManager.NameLastName;
                txtBirthDate.Text = CurrentManager.DateBirth.ToString("yyyy-MM-dd");
                ucEnumSelectorGender.DefaultSelection = CurrentManager.Gender;
                foreach (string item in CurrentManager.ExpertiseCrisisTypes)
                {
                    txtExpertiseCrisisTypes.Text += item + Environment.NewLine;
                }
              

                if (CurrentManager.Address != null)
                {
                    txtCountry.Text = CurrentManager.Address.Country;
                    txtCity.Text = CurrentManager.Address.City;
                    txtStreet.Text = CurrentManager.Address.Street;
                    txtHouseNo.Text = CurrentManager.Address.HouseNumber;
                    txtFlatNo.Text = CurrentManager.Address.FlatNumber;
                    txtPostalCode.Text = CurrentManager.Address.PostalCode;
                    txtHouseNo.Text = CurrentManager.Address.HouseNumber;
                }
                txtUserName.Text = CurrentManager.UserName;
                txtUserName.Enabled = false;

                btnRegister.Text = "Update";
            }

            else if (PageAction == PageActions.Create) // Create crisis 
            {
// initialize page for creating 
                CurrentManager = null;
                txtFullName.Text = "";
                txtBirthDate.Text = "";
                txtExpertiseCrisisTypes.Text = "";
                txtCountry.Text = "";
                txtCity.Text = "";
                txtStreet.Text = "";
                txtHouseNo.Text = "";
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
                if (CurrentManager == null)
                {
                    Master.ShowMessage(MessageTypes.Error, "You must login to see your profile");
                    btnRegister.Enabled = false;
                    return;
                }

                txtFullName.Text = CurrentManager.NameLastName;
                txtBirthDate.Text = CurrentManager.DateBirth.ToString("yyyy-MM-dd");
                ucEnumSelectorGender.DefaultSelection = CurrentManager.GenderVal;
                foreach (string item in CurrentManager.ExpertiseCrisisTypes)
                {
                    txtExpertiseCrisisTypes.Text += item + Environment.NewLine;
                }
                txtCountry.Text = CurrentManager.Address.Country;
                txtCity.Text = CurrentManager.Address.City;
                txtStreet.Text = CurrentManager.Address.Street;
                txtHouseNo.Text = CurrentManager.Address.HouseNumber;
                txtFlatNo.Text = CurrentManager.Address.FlatNumber;
                txtPostalCode.Text = CurrentManager.Address.PostalCode;
                txtHouseNo.Text = CurrentManager.Address.HouseNumber;
                txtUserName.Text = CurrentManager.UserName;
                txtUserName.Enabled = false;

                btnRegister.Visible = false;
                btnCancel.Visible = false;
                pnlDivForm.Enabled = false;
            }
            else if (PageAction == PageActions.Admin)
            {
                pnlAdmin.Visible = true;
                pnlDivForm.Visible = false;
                IQueryable<Manager> q = from man in Container.Instance.Managers
                                        where man.UserName != GlobalIds.AdminUserName
                                        select man;
                gvuManagers.DataSource = q;
                gvuManagers.DataBind();
            }

            else
            {
                Response.Redirect(Constants.PageManagerProfile + "?" + Constants.IdAction + "=Create");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CurrentManager = null;
        Response.Redirect("~/Login.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Manager Man;
        if (PageAction == PageActions.Create)
        {
            Man = new Manager();
        }
        else if (CurrentManager != null && PageAction == PageActions.Edit)
        {
            Man = CurrentManager;
        }
        else
        {
            Master.ShowMessage(MessageTypes.Error, "Login first");
            pnlDivForm.Enabled = false;
            return;
        }
        Man.Address = new Address
                          {
                              City = Convert.SafeString(txtCity.Text),
                              Country = Convert.SafeString(txtCountry.Text),
                              FlatNumber = Convert.SafeString(txtFlatNo.Text),
                              HouseNumber = Convert.SafeString(txtHouseNo.Text),
                              PostalCode = Convert.SafeString(txtPostalCode.Text),
                              Street = Convert.SafeString(txtStreet.Text)
                          };

        var tempDate = new DateTime();

        bool succeed = DateTime.TryParse(Convert.SafeString(txtBirthDate.Text), out tempDate);
        if (!succeed)
        {
            Master.ShowMessage(MessageTypes.Error, "Birth date is not correct");
            return;
        }
        Man.DateBirth = tempDate;

        Man.NameLastName = Convert.SafeString(txtFullName.Text);
        Man.GenderVal = (short) ucEnumSelectorGender.SelectedValue<Gender>();


        string[] lines = txtExpertiseCrisisTypes.Text.Split(new[] {Environment.NewLine},
                                                            StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string et = Convert.SafeString(line);
            if (et != "")
                Man.ExpertiseCrisisTypes.Add(et);
        }

        Man.UserName = Convert.SafeString(txtUserName.Text);
        Man.Password = Convert.SafeString(txtPassword.Text);

        if (PageAction == PageActions.Create &&
            // if we are creating new profile and there is already someone with that username
            Container.Instance.Managers.Count(man => man.UserName == Man.UserName) > 0)
        {
            Master.ShowMessage(MessageTypes.Error,
                               string.Format("'{0}' is not available. Please select another username", Man.UserName));
            return; // show error message and cancel operation
        }

        IList<string> messages = Man.Validate(); // check the fields and return error messages if any
        if (messages.Count > 0) // there are error messages
        {
            Master.ShowMessage(MessageTypes.Error, messages.ToArray()); // show them
            return; // cancel operation
        }


        /* TODO: Login/Password functionality needs to be added later*/

        //save the object in db
        if (PageAction == PageActions.Create)
            Container.Instance.Managers.AddObject(Man);

        Container.Instance.SaveChanges();

        CurrentManager = Man;
        if (PageAction == PageActions.Create)
        {
            Master.ShowMessage(MessageTypes.Info, "Successfully saved.");
            RedirectAfter(4, Constants.PageManagerProfile + "?Action=Edit");
        }
        else if (PageAction == PageActions.Edit)
        {
            //redirecting to Managers's profile page
            Master.ShowMessage(MessageTypes.Info, "Successfully updated.");
        }
    }

    protected void ibtRemove_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt(e.CommandArgument as string, 0);
        Manager rec = Container.Instance.Managers.SingleOrDefault(ni => ni.Id == id);
        Container.Instance.Managers.DeleteObject(rec);
        Container.Instance.SaveChanges();

        gvuManagers.DataSource = Container.Instance.Managers;
        gvuManagers.DataBind();
    }

    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
    }

    protected void gvuManagers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as Manager;
        var chkApproved = e.Row.FindControl("chkApproved") as CheckBox;
        var lblFullName = e.Row.FindControl("lblFullName") as Label;
        var lblUserName = e.Row.FindControl("lblUserName") as Label;
        var ibtRemove = e.Row.FindControl("ibtRemove") as ImageButton;

        lblFullName.Text = ni.NameLastName;
        lblUserName.Text = ni.UserName;
        chkApproved.Checked = (ni.Approved == null) ? false : (bool) ni.Approved;
        ibtRemove.CommandArgument = ni.Id.ToString();
    }

    protected void chkApproved_CheckedChanged(object sender, EventArgs e)
    {
        var chk = sender as CheckBox;
        var row = chk.NamingContainer as GridViewRow;
        int id = System.Convert.ToInt32(gvuManagers.DataKeys[row.RowIndex].Value.ToString());
        Manager rec = Container.Instance.Managers.SingleOrDefault(ni => ni.Id == id);
        rec.Approved = chk.Checked;
        Container.Instance.SaveChanges();

        gvuManagers.DataSource = Container.Instance.Managers;
        gvuManagers.DataBind();
        Master.ShowMessage(MessageTypes.Info, "Manager " + rec.NameLastName + " approve status changed");
    }
}