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
        // DEMONSTRATION
        if (MainCrisis==null)
        {
            var row = DAL.Container.Instance.Crises.SingleOrDefault(r => r.Id == 46);
            MainCrisis = row;
        }
        // DEMONSTRATION

        Master.PageTitle = "Crisis Dashboard: " + MainCrisis.Name;
        MainCrisis = DAL.Container.Instance.Crises.SingleOrDefault(c => c.Id==46);
        UCMap1.Incidents = MainCrisis.Incidents ;
         
        
    }
}