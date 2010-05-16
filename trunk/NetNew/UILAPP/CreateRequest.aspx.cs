using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils;
using Utils.Enumerations;
using Utils.Exceptions;
using Convert = Utils.Convert;

public partial class CreateRequest : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        if (!IsPostBack)
        {
            if (PageAction == PageActions.Create)
            {
                BindPage(GetIncident());
            }
            else if (PageAction == PageActions.Edit)
            {
                BindPageForEdit(GetRequest());
            }
        }
    }

    private void BindPageForEdit(Request request)
    {
        rblStatus.SelectedValue = request.IsActive ? "Active" : "Suspended";

        BindPage(request.Incident);

        txMessage.Text = request.Message;
        txRequestName.Text = request.Name;

        foreach (ListItem li in cblNeedlist.Items)
        {
            bool found = false;
            foreach (NeedItem ni in request.NeedItems)
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
        Master.SetSiteMap(new[]
                              {
                                  new[] {"Crisis Board", "CrisisBoard.aspx"},
                                  new[]
                                      {
                                          "Incident:" + GetIncident().ShortDescription,
                                          "Incident.aspx?iid=" + GetIncident().Id + "&action=Edit"
                                      },
                                  new[] {"Resource Gathering", "ResourceGathering.aspx?iid=" + GetIncident().Id},
                                  new[] {"Edit Request", ""},
                              });
    }

    private void BindPage(DAL.Incident inc)
    {
        Master.PageTitle = "Create Request";
        Master.SetSiteMap(new[]
                              {
                                  new[] {"Crisis Board", "CrisisBoard.aspx"},
                                  new[]
                                      {
                                          "Incident:" + inc.ShortDescription,
                                          "Incident.aspx?iid=" + inc.Id + "&action=Edit"
                                      },
                                  new[] {"Resource Gathering", "ResourceGathering.aspx?iid=" + inc.Id},
                                  new[] {"Create Request", ""},
                              });

        dvStatus.Visible = false;
        cblNeedlist.Items.Clear();
        foreach (NeedItem item in inc.NeedItems)
        {
            var li = new ListItem();
            li.Text = item.ItemType + string.Format(" ({1} {0})",
                                                    Reflection.GetEnumDescription(item.MetricType), item.ItemAmount);
            li.Value = item.Id + "";
            cblNeedlist.Items.Add(li);
        }
    }

    /// <summary>
    ///<para> Retrieves the incident with the id in url, stores it in the session for further calls.</para>
    ///<para>if refresh=true then the incident re-read from DB. Otherwise it is returned from session</para>
    /// </summary>
    ///<returns>Incident object that is specified in the URL</returns>
    private DAL.Incident GetIncident()
    {
        int incId = Convert.ToInt(Request[Constants.IdIncidentId], 0);
        if (incId == 0)
        {
            throw new VMSException("Incident is not specified");
        }


        DAL.Incident incObj = Container.Instance.Incidents.SingleOrDefault(inc => inc.Id == incId);
        Session[Constants.IdIncident] = incObj;
        return incObj;
    }

    private Request GetRequest()
    {
        int id = Convert.ToInt(Request[Constants.IdRequestId], 0);
        if (id == 0)
        {
            throw new VMSException("Request is not specified");
        }

        Request obj = Container.Instance.Requests.SingleOrDefault(inc => inc.Id == id);
        Session[Constants.IdRequestId] = obj;
        return obj;
    }


    protected void btSaveRequest_Click(object sender, EventArgs e)
    {
        Request req;
        if (PageAction == PageActions.Create)
        {
            req = Container.Instance.Requests.CreateObject();
            GetIncident().Requests.Add(req);
        }
        else
            req = GetRequest();


        string reqName = Convert.SafeString(txRequestName.Text);
        string reqMessage = Convert.SafeString(txMessage.Text);

        req.Name = reqName;
        req.Message = reqMessage;
        req.IsActive = true;
        req.Incident = GetIncident();
        req.IsActive = rblStatus.SelectedValue == "Active" ? true : false;
        foreach (ListItem li in cblNeedlist.Items)
        {
            int liid = System.Convert.ToInt32(li.Value);

            // check if list item is already in req.NeedItems
            bool found = false;
            NeedItem reqniToRemove = null;
            foreach (NeedItem reqni in req.NeedItems)
            {
                if (li.Text.StartsWith(reqni.ItemType))
                {
                    found = true;
                    reqniToRemove = reqni;
                    break;
                }
            }

            if (!found && li.Selected) // if it is not already in req.NeedItems and listitem is selected, add it
            {
                NeedItem ni = Container.Instance.NeedItems.SingleOrDefault(n => n.Id == liid);
                NeedItem nitemToBeAdded = Container.Instance.NeedItems.CreateObject();
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

        req.SearchAreaCoordinatesStr = "";

        IList<string> msg = req.Validate();
        if (msg.Count > 0)
        {
            Master.ShowMessage(MessageTypes.Error, msg.ToArray());
            return;
        }

        if (PageAction == PageActions.Create)
            Container.Instance.Requests.AddObject(req);
        Container.Instance.SaveChanges();

        RedirectToResourceGathering();
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        RedirectToResourceGathering();
    }

    private void RedirectToResourceGathering()
    {
        string iid = "";
        if (PageAction == PageActions.Create)
            iid = GetIncident().Id + "";
        else if (PageAction == PageActions.Edit)
            iid = GetRequest().Incident.Id + "";

        Response.Redirect("~/ResourceGathering.aspx?iid=" + iid);
    }
}