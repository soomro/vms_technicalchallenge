using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;

public partial class Crisis : PageBase
{
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

    }
    protected void btSave_Click(object sender, EventArgs e)
    {

    }
}