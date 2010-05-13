using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrisisBoard : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (MainCrisis==null)
        {
            Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "There is no active crisis!"
                ,"You will directed to crisis page to create one.");
            RedirectAfter(4, Constants.PageCrisis);
        }

        Master.PageTitle = "Crisis Dashboard: " + MainCrisis.Name;
        
        UCMap1.Incidents = MainCrisis.Incidents.ToList() ;

        hlIncidentlist.HRef = Constants.PageIncidents + "?cid=" + MainCrisis.Id;
        
        Master.SetSiteMap(new[] { new[] { "Crisis Board", "CrisisBoard.aspx" } });
    }

    protected void cbxShowClosed_CheckedChanged(object sender, EventArgs e)
    {
        if (!cbxShowClosed.Checked)
        {
            UCMap1.Incidents = MainCrisis.Incidents.Where(c => c.IncidentStatusVal!= (short)Utils.Enumerations.IncidentStatuses.Complete).ToList();
        }
        else
        {
            UCMap1.Incidents = MainCrisis.Incidents.ToList();
        }
    }
}