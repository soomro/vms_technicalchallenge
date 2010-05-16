using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using DAL;
using Utils;
using Utils.Enumerations;
using Utils.Exceptions;
using Convert = Utils.Convert;

public partial class ResourceGathering : PageBase
{
    private int rowindex;

    private Request SelectedRequest
    {
        get
        {
            int rid = Convert.ToInt(Session["SelectedRequest"] + "", 0);
            return (from r in Container.Instance.Requests
                    where r.Id == rid
                    select r).FirstOrDefault();
        }
        set
        {
            int rid = value == null ? 0 : value.Id;
            Session["SelectedRequest"] = rid;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();


        if (!IsPostBack)
        {
            SelectedRequest = null;
            DisablePage();
            Master.PageTitle = "Resource Gathering";

            DAL.Incident inc = null;
            try
            {
                inc = GetIncident(true);
            }
            catch (VMSException ex)
            {
                Master.ShowMessage(MessageTypes.Error, ex.Messages.ToArray());
                DisablePage();
                return;
            }

            if (inc == null)
            {
                Master.ShowMessage(MessageTypes.Error, "Specified incident could not be found");
                return;
            }

            BindPage(inc);
        }
    }

    private void BindPage(DAL.Incident inc)
    {
        // TODO: enable panels.
        pnIncident.Visible = true;
        pnRequestList.Visible = true;

        lbIncName.Text = inc.ShortDescription;
        lbSeverity.Text = Reflection.GetEnumDescription(inc.Severity);
        lbIncType.Text = Reflection.GetEnumDescription(inc.IncidentType);
        lbStatus.Text = Reflection.GetEnumDescription(inc.IncidentStatus);
        UCIncidentMap1.Incident = new GoogleMarker(
            Convert.ToDouble(inc.LocationCoordinates[0], 0),
            Convert.ToDouble(inc.LocationCoordinates[1], 0));
        if (inc.LocationCoordinates.Count > 2)
            UCIncidentMap1.Zoom = Convert.ToInt(inc.LocationCoordinates[2], 8);
        UCIncidentMap1.ReadOnly = true;

        Container.Instance.Refresh(RefreshMode.StoreWins, Container.Instance.Requests);
        Container.Instance.DetectChanges();
        // Request List
        List<Request> list = inc.Requests.ToList();
        gvReqList.DataSource = list;
        gvReqList.DataBind();

        gvIncidentNeeds.DataSource = inc.NeedItems;
        gvIncidentNeeds.DataBind();

        hlNewRequest.HRef = string.Format("./CreateRequest.aspx?{0}={1}&Action={2}", Constants.IdIncidentId, inc.Id,
                                          PageActions.Create);


        Master.SetSiteMap(new[]
                              {
                                  new[] {"Crisis Board", "CrisisBoard.aspx"},
                                  new[]
                                      {
                                          "Incident:" + inc.ShortDescription,
                                          "Incident.aspx?iid=" + inc.Id + "&action=Edit"
                                      },
                                  new[] {"Resource Gathering", ""},
                              });
    }

    private void DisablePage()
    {
        pnIncident.Visible = false;
        pnNeedListStatus.Visible = false;
        pnRequestList.Visible = false;
    }

    /// <summary>
    ///<para> Retrieves the incident with the id in url, stores it in the session for further calls.</para>
    ///<para>if refresh=true then the incident re-read from DB. Otherwise it is returned from session</para>
    /// </summary>
    /// <param name="refresh">If true, incident is re-read from DB</param>
    /// <returns>Incident object that is specified in the URL</returns>
    private DAL.Incident GetIncident(bool refresh = false)
    {
        int incId = Convert.ToInt(Request[Constants.IdIncidentId], 0);
        if (incId == 0)
        {
            throw new VMSException("Incident is not specified");
        }
        var incObj = Session[Constants.IdIncident] as DAL.Incident;

        if (refresh == false && incObj != null && incObj.Id == incId) // return it from session
        {
            return incObj;
        }


        incObj = Container.Instance.Incidents.SingleOrDefault(inc => inc.Id == incId);
        Session[Constants.IdIncident] = incObj;
        return incObj;
    }

    protected void gvReqList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var req = e.Row.DataItem as Request;

        var lbtRequest = e.Row.FindControl("lbtRequest") as LinkButton;
        var ltStatus = e.Row.FindControl("ltStatus") as Literal;
        var hlEditRequest = e.Row.FindControl("hlEditRequest") as HyperLink;

        lbtRequest.Text = req.Name;
        lbtRequest.CommandArgument = req.Id + "|" + rowindex++;
        hlEditRequest.NavigateUrl = string.Format("~/CreateRequest.aspx?{0}={1}&Action={2}&{3}={4}",
                                                  Constants.IdIncidentId, GetIncident().Id, PageActions.Edit,
                                                  Constants.IdRequestId, req.Id);
        ltStatus.Text = req.IsActive ? "Active" : "Not active";
    }

    protected void lbtRequest_Command(object sender, CommandEventArgs e)
    {
        string reqidstr = (e.CommandArgument as string).Split('|')[0];
        int rowindex = Convert.ToInt((e.CommandArgument as string).Split('|')[1], -1);

        int reqId = Convert.ToInt(reqidstr, 0);

        Container.Instance.Requests.MergeOption = MergeOption.OverwriteChanges;
        Request req = Container.Instance.Requests.SingleOrDefault(r => r.Id == reqId);
        //DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, req);
        //DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, req.NeedItems);
        //DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, req.RequestResponses);
        //DAL.Container.Instance.RequestResponses.MergeOption = System.Data.Objects.MergeOption.NoTracking;


        SelectedRequest = req;

        gvNeedList.DataSource = req.NeedItems;
        gvNeedList.DataBind();

        pnNeedListStatus.Visible = true;

        foreach (GridViewRow row in gvReqList.Rows)
        {
            //row.Style.Remove("background-color");
            row.CssClass = "";
        }
        //gvReqList.Rows[rowindex].Style["background-color"] = "green";
        gvReqList.Rows[rowindex].CssClass = "selectedrow";

        gvVolunteers.DataSource = req.RequestResponses;
        gvVolunteers.DataBind();
    }

    protected void gvNeedList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as NeedItem;

        var ltType = e.Row.FindControl("ltType") as Literal;
        var ltUnit = e.Row.FindControl("ltUnit") as Literal;
        var ltAmt = e.Row.FindControl("ltAmt") as Literal;
        var ltCollected = e.Row.FindControl("ltCollected") as Literal;

        var ibtRemove = e.Row.FindControl("ibtRemove") as ImageButton;


        ltType.Text = ni.ItemType;
        ltAmt.Text = ni.ItemAmount + "";
        ltCollected.Text = ni.SuppliedAmount + "";
        ltUnit.Text = Reflection.GetEnumDescription(ni.MetricType);

        ibtRemove.CommandArgument = ni.Id + "";
    }

    protected void ibtRemove_Command(object sender, CommandEventArgs e)
    {
        int niid = Convert.ToInt(e.CommandArgument as string, 0);
        NeedItem niToDel = Container.Instance.NeedItems.SingleOrDefault(ni => ni.Id == niid);
        Container.Instance.NeedItems.DeleteObject(niToDel);
        Container.Instance.SaveChanges();
        Container.Instance.Refresh(RefreshMode.StoreWins, SelectedRequest);

        gvNeedList.DataSource = SelectedRequest.NeedItems;
        gvNeedList.DataBind();
    }


    protected void gvVolunteers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var res = e.Row.DataItem as RequestRespons;

        Container.Instance.Refresh(RefreshMode.StoreWins, res.Volunteer);
        Container.Instance.Refresh(RefreshMode.StoreWins, res.NeedItems);

        var hlVolName = e.Row.FindControl("hlVolName") as HyperLink;
        var lbResponse = e.Row.FindControl("lbResponse") as Label;
        var lbSupplied = e.Row.FindControl("lbSupplied") as Label;

        hlVolName.Text = res.Volunteer.NameLastName;

        hlVolName.NavigateUrl = "#";
        if (res.Answer.HasValue && res.Answer.Value)
            lbResponse.Text = "Accepted";
        if (res.Answer.HasValue && res.Answer.Value == false)
            lbResponse.Text = "Rejected";
        if (!res.Answer.HasValue)
            lbResponse.Text = "Waiting";

        string supplied = "-";
        foreach (NeedItem ni in res.NeedItems)
        {
            Container.Instance.Refresh(RefreshMode.StoreWins, ni);
            string s = ni.SuppliedAmount + " ";
            if (ni.MetricType != MetricTypes.Item)
                s += Reflection.GetEnumDescription(ni.MetricType) + " ";
            s += ni.ItemType + ", ";

            supplied += s;
        }
        if (supplied != "-")
            supplied = supplied.Substring(0, supplied.Length - 2).Replace("-", "");

        lbSupplied.Text = supplied;
    }

    protected void gvIncidentNeeds_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        var ni = e.Row.DataItem as NeedItem;

        var g = new GridUtil(e.Row);
        g.SetControlText("lbType", ni.ItemType);
        g.SetControlText("lbMetric", Reflection.GetEnumDescription(ni.MetricType));
        g.SetControlText("lbAmount", ni.ItemAmount + "");
        g.SetControlText("lbSupplied", ni.SuppliedAmount + "");
    }
}