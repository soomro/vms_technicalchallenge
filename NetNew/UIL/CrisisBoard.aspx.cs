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
        MainCrisis = DAL.Container.Instance.Crises.SingleOrDefault(c => c.Id==46);
        UCMap1.Incidents = MainCrisis.Incidents ;

        hlIncidentlist.HRef = Constants.PageIncidents + "?cid=" + MainCrisis.Id;
    }
}