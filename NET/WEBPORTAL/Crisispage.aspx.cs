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

public partial class Crisispage : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            MultiView1.ActiveViewIndex=-1;
            ucEnumSelector1.EnumType = typeof(EnumCrisisType);
            ucEnumSelector1.DefaultSelection = EnumCrisisType.Earthquake;
            
            if (PageAction==EnumPageAction.Create)
            {                
                MultiView1.ActiveViewIndex=0;
                Master.PageTitle = "Create New Crisis";
                UCCreateCrisisMap1.Width = new Unit("650px" );
                
                UCCreateCrisisMap1.Radious = 80;
                ddlRadious.SelectedValue = "80";
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

        try
        {
            var c = CrisisOperations.CreateCrisis(name, explanation, ctype, EnumLocationType.Circle, coords);
            Master.ShowMessage(EnumMessageType.Info, "A new crisis is created");

            RedirectAfter(4, string.Format("Crisispage.aspx?cid={0}&action=View", c.Id));
            // TODO: forward crisis main page.
        }
        catch (VMSException ex)
        {
            // TODO: Show error messages.
        }

        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Master.ShowMessage(EnumMessageType.Info, "test message");
        RedirectAfter(4, "http://www.google.com");
    }
}