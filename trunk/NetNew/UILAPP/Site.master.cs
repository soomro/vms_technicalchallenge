using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Utils.Enumerations;
//TODO: add code comments for this file
public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        int id = Utils.Convert.ToInt(Session["CurrentManager"] + "", 0);
        var man = (from v in Container.Instance.Managers
                   where v.Id == id
                   select v).FirstOrDefault();

        id = Utils.Convert.ToInt(Session["CurrentVolunteer"] + "", 0);
        var vol= (from v in Container.Instance.Volunteers
                  where v.Id == id
                  select v).FirstOrDefault();
        if (man!=null || vol != null)
        {
            lbtLogout.Visible = false;
        }

        base.OnInit(e);
    }
    protected override void OnLoad(EventArgs e)
    {
       
        base.OnLoad(e);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vals">text-URL pairs</param>
    public void SetSiteMap(params string[][] vals)
    {
        navlist.Items.Clear();
        ListItem lastitem = null;
        foreach (var pair in vals)
        {
            var text = pair[0];
            var url = pair[1]==""?"javascript:void()":pair[1];
            lastitem = new ListItem(text, url);
            navlist.Items.Add(lastitem);
        }
        if (lastitem!=null)
        {
            lastitem.Selected = true;
            lastitem.Attributes["class"] = "active";
        }
    }

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
            massagePart.Visible = true;
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

    protected void lbtLogout_Command(object sender, CommandEventArgs e)
    {
        Session.Clear();
        Response.Redirect(Constants.PageLogin);
    }

     
}
