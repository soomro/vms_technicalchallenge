using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.Operations;
using VMSCORE.Util;
using Artem.Web.UI.Controls;
using System.Collections.ObjectModel;

/// <summary>
/// Crisispage is used to create crisis.
/// It contains a UC 
/// </summary>
public partial class Crisispage : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            CrisisArea = null;

            ucEnumSelector1.EnumType = typeof(EnumCrisisType);
            ucEnumSelector1.DefaultSelection = EnumCrisisType.Earthquake;
            UCCreateCrisisMap1.Width = new Unit("650px");
            UCCreateCrisisMap1.Heigth = new Unit("600px");

            if (PageAction==EnumPageAction.Edit)
            {
                if (MainCrisis==null)
                {
                    Master.ShowMessage(EnumMessageType.Error, "Crisis is not defined yet");
                    RedirectAfter(4, "Crisispage.aspx?action=Create");
                    return;
                }

                txCrisisName.Text = MainCrisis.Name;
                txExplanation.Text = MainCrisis.Explanation;

                double latitude = 0, longitude=0, radious=0;
                double.TryParse(MainCrisis.LocationCoordinates[0], out latitude);
                double.TryParse(MainCrisis.LocationCoordinates[1], out longitude);
                double.TryParse(MainCrisis.LocationCoordinates[2], out radious);
                ddlRadious.SelectedValue = radious+"";
                CrisisArea = UC_UCCreateCrisisMap.GetDefaultCirclePolygon(latitude, longitude, radious);
                Master.PageTitle = "Edit Crisis";
            }

            else if (PageAction == EnumPageAction.Create)// Create crisis 
            {

                Master.PageTitle = "Create New Crisis";

                UCCreateCrisisMap1.Radious = 20;
                ddlRadious.SelectedValue = "20";
            }
            else
            {
                Response.Redirect("Crisispage.aspx?action=Create");
            }


        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {

        var ctype = ucEnumSelector1.SelectedValue<EnumCrisisType>();
        var name = txCrisisName.Text;
        var explanation = txExplanation.Text;
        if (CrisisArea==null)
        {
            Master.ShowMessage(EnumMessageType.Error, "Define crisis area!");
            return;
        }
        var coords = new ObservableCollection<string>();
        coords.Add(CrisisArea.Latitude+"");
        coords.Add(CrisisArea.Longitude+"");
        coords.Add(CrisisArea.Radius+"");


        if (PageAction==EnumPageAction.Create)
        {
            try
            {
                var c = CrisisOperations.CreateCrisis(name, explanation, ctype, EnumLocationType.Circle, coords);
                MainCrisis = c;
                Master.ShowMessage(EnumMessageType.Info, "A new crisis is created");

                RedirectAfter(4, string.Format(VMSCORE.Util.Constants.Pages.CrisisBoard+"?cid={0}&action=View", c.Id));

            }
            catch (VMSException ex)
            {
                Master.ShowMessage(EnumMessageType.Error, "Following error is occured:"+ex.Message);
                return;
            }
        }
        else if (PageAction == EnumPageAction.Edit)
        {
            // Update
            CrisisOperations.UpdateCrisis(MainCrisis.Id, name, explanation, ctype, EnumLocationType.Circle, coords);
        }

    }

    protected void ddlRadious_SelectedIndexChanged(object sender, EventArgs e)
    {
        UCCreateCrisisMap1.Radious = 
            double.Parse(ddlRadious.SelectedValue);
    }

    public GoogleCirclePolygon CrisisArea
    {
        get
        {
            return Session["crisisarea"] as GoogleCirclePolygon;
        }
        set
        {
            Session["crisisarea"] = value;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Master.ShowMessage(EnumMessageType.Info, "test message");
        RedirectAfter(4, VMSCORE.Util.Constants.Pages.CrisisBoard);
    }
}