using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Exceptions;

public partial class CreateRequest : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        if (!IsPostBack)
        {
            if (PageAction==PageActions.Create)
            {
                BindPage(GetIncident(true));
            }
            else if (PageAction==PageActions.Edit)
            {
                BindPageForEdit(GetRequest());
            }
        }
    }

    private void BindPageForEdit(DAL.Request request)
    {
        
        
        rblStatus.SelectedValue = request.IsActive ? "Active" : "Suspended";

        BindPage(request.Incident);

        txMessage.Text = request.Message;
        txRequestName.Text = request.Name;

        foreach (ListItem li in cblNeedlist.Items)
        {
            bool found = false;
            foreach (DAL.NeedItem ni in request.NeedItems)
            {

                if (li.Text.StartsWith(ni.ItemType))
                {
                    found = true;
                    break;
                }
            }
            if (found) li.Selected = true;

        } 
        dvStatus.Visible = true;
        Master.PageTitle = "Edit Request";
        Master.SetSiteMap(new[] { 
                new[] { "Crisis Board", "CrisisBoard.aspx" },
                new[] { "Incident:"+GetIncident().ShortDescription, "Incident.aspx?iid="+GetIncident().Id+"&action=Edit" },
                new[] { "Resource Gathering", "ResourceGathering.aspx?iid="+GetIncident().Id  },
                new[] { "Edit Request", "" },
            });
    }

    private void BindPage(DAL.Incident inc)
    {
        Master.PageTitle = "Create Request";
        Master.SetSiteMap(new[] { 
                new[] { "Crisis Board", "CrisisBoard.aspx" },
                new[] { "Incident:"+inc.ShortDescription, "Incident.aspx?iid="+inc.Id+"&action=Edit" },
                new[] { "Resource Gathering", "ResourceGathering.aspx?iid="+inc.Id  },
                new[] { "Create Request", "" },
            });

        dvStatus.Visible = false;
        cblNeedlist.Items.Clear();
        foreach (DAL.NeedItem item in inc.NeedItems)
        {
            ListItem li = new ListItem();
            li.Text = item.ItemType + string.Format(" ({1} {0})",
                Utils.Reflection.GetEnumDescription(item.MetricType), item.ItemAmount);
            li.Value = item.Id + "";
            cblNeedlist.Items.Add(li);
        }
    }

    /// <summary>
    ///<para> Retrieves the incident with the id in url, stores it in the session for further calls.</para>
    ///<para>if refresh=true then the incident re-read from DB. Otherwise it is returned from session</para>
    /// </summary>
    /// <param name="refresh">If true, incident is re-read from DB</param>
    /// <returns>Incident object that is specified in the URL</returns>
    DAL.Incident GetIncident(bool refresh = false)
    {
        var incId = Utils.Convert.ToInt(Request[Constants.IdIncidentId], 0);
        if (incId == 0)
        {
            throw new VMSException("Incident is not specified");
        }
        


         var incObj = DAL.Container.Instance.Incidents.SingleOrDefault(inc => inc.Id == incId);
        Session[Constants.IdIncident] = incObj;
        return incObj;
    }

    DAL.Request GetRequest(bool refresh = false)
    {
        var id = Utils.Convert.ToInt(Request[Constants.IdRequestId], 0);
        if (id == 0)
        {
            throw new VMSException("Request is not specified");
        }
        
        var obj = DAL.Container.Instance.Requests.SingleOrDefault(inc => inc.Id == id);
        Session[Constants.IdRequestId] = obj;
        return obj;
    }


    protected void btSaveRequest_Click(object sender, EventArgs e)
    {
        DAL.Request req = null;
        if (PageAction == PageActions.Create)
        {
            req = DAL.Container.Instance.Requests.CreateObject();
            GetIncident().Requests.Add(req);
        }
        else
            req = GetRequest();

        

        var reqName = Utils.Convert.SafeString(txRequestName.Text);
        var reqMessage = Utils.Convert.SafeString(txMessage.Text);

        req.Name = reqName;
        req.Message = reqMessage;
        req.IsActive = true;
        req.Incident = GetIncident();
        req.IsActive = rblStatus.SelectedValue == "Active" ? true : false;
        foreach (ListItem li in cblNeedlist.Items)
        {
            int liid = Convert.ToInt32(li.Value);

            // check if list item is already in req.NeedItems
            bool found = false;
            DAL.NeedItem reqniToRemove = null;
            foreach (DAL.NeedItem reqni in req.NeedItems)
            {
                if (li.Text.StartsWith(reqni.ItemType)) { found = true; reqniToRemove = reqni; break; }
            }

            if (!found && li.Selected) // if it is not already in req.NeedItems and listitem is selected, add it
            {
                var ni = DAL.Container.Instance.NeedItems.SingleOrDefault(n => n.Id == liid);
                var nitemToBeAdded = DAL.Container.Instance.NeedItems.CreateObject();
                nitemToBeAdded.ItemAmount = ni.ItemAmount;
                nitemToBeAdded.ItemType = ni.ItemType;
                nitemToBeAdded.MetricType = ni.MetricType;
                req.NeedItems.Add(nitemToBeAdded);
            }
            else if (found && !li.Selected) // if it is in req.NeedItems but li is not selected, remove it
            {
                req.NeedItems.Remove(reqniToRemove);
            }

        }

        req.SearchAreaCoordinatesStr = "test";
        if(PageAction== PageActions.Create)
            DAL.Container.Instance.Requests.AddObject(req);
        DAL.Container.Instance.SaveChanges();

        RedirectToResourceGathering();
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        RedirectToResourceGathering();
    }

    private void RedirectToResourceGathering()
    {
        var iid = "";
        if (PageAction == PageActions.Create)
            iid = GetIncident().Id + "";
        else if (PageAction == PageActions.Edit)
            iid = GetRequest().Incident.Id + "";

        Response.Redirect("~/ResourceGathering.aspx?iid=" + iid);
    }
}