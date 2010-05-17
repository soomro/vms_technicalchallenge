using System;
using System.Linq;
using Utils.Enumerations;

public partial class CrisisBoard : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

       
        if(MainCrisis==null)
        {
            Master.PageTitle = "Main Page";
            cbxShowClosed.Visible = false;
            pn2.Visible = false;
            pn3.Visible = false;
            pn4.Visible = false;
            hlEditCrisis.Visible = false;
            UCMap1.Visible = false;

        }else
        {
            Master.PageTitle = "Crisis Dashboard: " + MainCrisis.Name;

            // this will automatically set the data source.
            cbxShowClosed_CheckedChanged(null, null);

            hlIncidentlist.HRef = Constants.PageIncidents + "?cid=" + MainCrisis.Id;
           
        }
        hlProfile.NavigateUrl = Constants.PageManagerProfile+"?Action=Edit";
        Master.SetSiteMap(new[] {new[] {"Crisis Board", "CrisisBoard.aspx"}});
        
    }

    protected void cbxShowClosed_CheckedChanged(object sender, EventArgs e)
    {
        if (!cbxShowClosed.Checked)
        {
            UCMap1.Incidents =
                MainCrisis.Incidents.Where(c => c.IncidentStatusVal != (short) IncidentStatuses.Complete).ToList();
        }
        else
        {
            UCMap1.Incidents = MainCrisis.Incidents.ToList();
        }
    }
}