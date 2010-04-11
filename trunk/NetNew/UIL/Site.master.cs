using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string PageTitle
    {
        get
        {
            return lblPageTitle.Text;
        }
        set
        {
            lblPageTitle.Text = value;
            Page.Title = value;
        }
        
    }
    public void ShowMessage(MessageTypes mtype, params string[] messages)
    {
        if (mtype == MessageTypes.Error)
        {
            blMessages.CssClass = "errorMessage";
        }
        else if (mtype == MessageTypes.Warning)
        {
            blMessages.CssClass = "warninglist";
        }
        else
        {
            blMessages.CssClass = "infolist";
        }

        foreach (var message in messages)
        {
            blMessages.Items.Add(message);
        }

    }
}
