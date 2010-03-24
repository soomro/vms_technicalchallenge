using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageMaster : System.Web.UI.MasterPage
{
    public string PageTitle
    {
        get { return ltPageTitle.Text; }
        set
        {
            ltPageTitle.Text = value;
            Page.Title = value;
        }
    }
    public void ShowMessage(EnumMessageType mtype,params string[] messages )
    {
        if (mtype==EnumMessageType.Error)
    	{
            blMessages.CssClass = "errorlist";
    	}
        else if (mtype==EnumMessageType.Warning)
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
    protected void Page_Load(object sender, EventArgs e)
    {
        blMessages.Items.Clear();
    }
}
