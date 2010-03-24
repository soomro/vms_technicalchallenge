using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.Operations;
using VMSCORE.Util;

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
            }
            
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        var ctype = ucEnumSelector1.SelectedValue<EnumCrisisType>();
        var name = txCrisisName.Text;
        var explanation = txExplanation.Text;

        try
        {
            var c = CrisisOperations.CreateCrisis(name, explanation, ctype, EnumLocationType.Rectangle, new System.Collections.ObjectModel.ObservableCollection<string>());
            Master.ShowMessage(EnumMessageType.Info, "A new crisis is created");
            // TODO: forward crisis main page.
        }
        catch (VMSException ex)
        {
            // TODO: Show error messages.
        }

        
    }
}