using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Enumerations;
//TODO: add code comments for this file
public partial class SiteMaster : System.Web.UI.MasterPage
{

    List<Utils.UIMessage> Messages
    {
        get
        {
            if (Session["_Messages"] as List<Utils.UIMessage>  == null)
            {
                Session["_Messages"] = new List<Utils.UIMessage>();
            }
            return Session["_Messages"] as List<Utils.UIMessage>;
        }
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        blMessages.Items.Clear();

        foreach (var msg in Messages)
        { /*
                 
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
                 */
            var li = new ListItem(msg.MessageText);
            if (msg.MessageType==Utils.Enumerations.MessageTypes.Error)
            {
                li.Attributes.Add("Style", "color: red;");
            }
            else if (msg.MessageType==Utils.Enumerations.MessageTypes.Warning)
            {
                li.Attributes.Add("Style", "color: yellow;");
            }
            else if (msg.MessageType==Utils.Enumerations.MessageTypes.Info)
            {
                li.Attributes.Add("Style", "color: blue;");
            }
        
            blMessages.Items.Add(li);
        }

        Messages.Clear();

        base.OnPreRender(e);
    }
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
    public void ShowMessage(Utils.Enumerations.MessageTypes mtype, params string[] messages)
    {
        foreach (var message in messages)
        {
            Messages.Add(new Utils.UIMessage() { MessageText=message, MessageType=mtype });
        }

    }

     
}
