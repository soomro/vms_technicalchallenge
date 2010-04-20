using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using System.Collections.ObjectModel;

public partial class Crisis : PageBase
{
    //TODO: commenting this class
    //TODO: check user inputs
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CrisisArea = null;

            ucEnumSelector1.EnumType = typeof(Utils.Enumerations.CrisisTypes);
            ucEnumSelector1.DefaultSelection = Utils.Enumerations.CrisisTypes.Earthquake;
            UCCreateCrisisMap1.Width = new Unit("650px");
            UCCreateCrisisMap1.Heigth = new Unit("600px");

            if (PageAction == PageActions.Edit)
            {
                if (MainCrisis == null)
                {
                    Master.ShowMessage(MessageTypes.Error, "Crisis is not defined yet");
                    RedirectAfter(4, Constants.PageCrisis+"?action=Create");
                    return;
                }

                txtCrisisName.Text = MainCrisis.Name;
                txtExplanation.Text = MainCrisis.Explanation;
                ucEnumSelector1.DefaultSelection = MainCrisis.CrisisType;
                double latitude = 0, longitude = 0, radious = 0;
                double.TryParse(MainCrisis.LocationCoordinates[0], out latitude);
                double.TryParse(MainCrisis.LocationCoordinates[1], out longitude);
                double.TryParse(MainCrisis.LocationCoordinates[2], out radious);
                ddlRadious.SelectedValue = radious + "";
                CrisisArea = UC_UCCreateCrisisMap.GetDefaultCirclePolygon(latitude, longitude, radious);
                Master.PageTitle = "Edit Crisis";
            }

            else if (PageAction == PageActions.Create)// Create crisis 
            {
                Master.PageTitle = "Create New Crisis";
                UCCreateCrisisMap1.Radious = 20;
                ddlRadious.SelectedValue = "20";
            }
            else
            {
                Response.Redirect(Constants.PageCrisis+"?action=Create");
            }
        }
    }
    public GoogleCirclePolygon CrisisArea
    {
        get
        {
            return Session[Constants.IdCrisisArea] as GoogleCirclePolygon;
        }
        set
        {
            Session[Constants.IdCrisisArea] = value;
        }

    }
    protected void ddlRadious_SelectedIndexChanged(object sender, EventArgs e)
    {
        UCCreateCrisisMap1.Radious =  double.Parse(ddlRadious.SelectedValue);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        var ctype = ucEnumSelector1.SelectedValue<Utils.Enumerations.CrisisTypes>();
        var name = txtCrisisName.Text;
        var explanation = txtExplanation.Text;
        if (CrisisArea == null)
        {
            Master.ShowMessage(MessageTypes.Error, "Define crisis area!");
            return;
        }
        var coords = new ObservableCollection<string>();
        coords.Add(CrisisArea.Latitude + "");
        coords.Add(CrisisArea.Longitude + "");
        coords.Add(CrisisArea.Radius + "");

        if (PageAction == PageActions.Create)
        {
            try
            {
                var c = BLL.BWorkflows.CrisisOperations.CreateCrisis(name, explanation, ctype, Utils.Enumerations.LocationTypes.Circle, coords);
                MainCrisis = c;
                Master.ShowMessage(MessageTypes.Info, "A new crisis is created");
                RedirectAfter(4, string.Format(Constants.PageCrisisBoard + "?cid={0}&action=View", c.Id));

            }
            catch (Utils.Exceptions.VMSException ex)
            {
                Master.ShowMessage(MessageTypes.Error, "Following error is occured:" + ex.Message);
                return;
            }
        }
        else if (PageAction == PageActions.Edit)
        {
            // Update
            var c = BLL.BWorkflows.CrisisOperations.UpdateCrisis(MainCrisis.Id, name, explanation, ctype, Utils.Enumerations.LocationTypes.Circle, coords);
            MainCrisis = c;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.PageCrisisBoard);
    }
}