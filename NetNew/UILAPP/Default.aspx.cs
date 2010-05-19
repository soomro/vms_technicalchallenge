using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;

public partial class _Default :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentManager!=null)
        {
            Response.Redirect(Constants.PageCrisisBoard);
            return;
        }

        if (CurrentVolunteer!=null)
        {
            Response.Redirect(Constants.PageVolunteerProfile);
            return;
        }

        Response.Redirect(Constants.PageLogin);
         
    }
   
}
