using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Exceptions; 

public partial class ResourceGathering : PageBase
{
    DAL.Request SelectedRequest
    {
        get{
            return Session["SelectedRequest"] as DAL.Request;
        }
        set { Session["SelectedRequest"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SelectedRequest = null;
            DisablePage();
            Master.PageTitle = "Resource Gathering";
            // get the object upon first call to this page. (get id from url, load it)
            // save object to session for further usage
            DAL.Incident inc = null;
            try
            {
                inc = GetIncident(true);
            }
            catch (VMSException ex)
            {
                Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, ex.Messages.ToArray());
                DisablePage();
                return;
            }

            if (inc==null)
            {
                Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Specified incident could not be found");
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
        lbSeverity.Text = Utils.Reflection.GetEnumDescription(inc.Severity);
        lbIncType.Text = Utils.Reflection.GetEnumDescription(inc.IncidentType);
        lbStatus.Text =  Utils.Reflection.GetEnumDescription(inc.IncidentStatus);
        UCIncidentMap1.Incident = new Artem.Web.UI.Controls.GoogleMarker(
            Utils.Convert.ToDouble(inc.LocationCoordinates[0], 0),
            Utils.Convert.ToDouble(inc.LocationCoordinates[1], 0));
        if (inc.LocationCoordinates.Count>2)
            UCIncidentMap1.Zoom = Utils.Convert.ToInt(inc.LocationCoordinates[2], 8);
        UCIncidentMap1.ReadOnly = true;
        
        DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, DAL.Container.Instance.Requests);
        DAL.Container.Instance.DetectChanges();
        // Request List
        var list = inc.Requests.ToList();
        gvReqList.DataSource = list;
        gvReqList.DataBind();

        hlNewRequest.NavigateUrl = string.Format("~/CreateRequest.aspx?{0}={1}&Action={2}",Constants.IdIncidentId,inc.Id,PageActions.Create);

      
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
    DAL.Incident GetIncident(bool refresh=false)
    {
        var incId = Utils.Convert.ToInt(Request[Constants.IdIncidentId], 0);
        if (incId == 0)
        {
            throw new VMSException("Incident is not specified");
        }
        var incObj = Session[Constants.IdIncident] as DAL.Incident;

        if (refresh==false && incObj!=null && incObj.Id==incId) // return it from session
        {
            return incObj;
        }

        
        incObj = DAL.Container.Instance.Incidents.SingleOrDefault(inc => inc.Id==incId);
        Session[Constants.IdIncident] = incObj;
        return incObj;
    }

    int rowindex = 0;
    protected void gvReqList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var req = e.Row.DataItem as DAL.Request;

        var lbtRequest = e.Row.FindControl("lbtRequest") as LinkButton;
        var ltStatus = e.Row.FindControl("ltStatus") as Literal;
        var hlEditRequest = e.Row.FindControl("hlEditRequest") as HyperLink;
        
        lbtRequest.Text = req.Name;
        lbtRequest.CommandArgument = req.Id+"|"+rowindex++;
        hlEditRequest.NavigateUrl = string.Format("~/CreateRequest.aspx?{0}={1}&Action={2}&{3}={4}", Constants.IdIncidentId, GetIncident().Id, PageActions.Edit,Constants.IdRequestId,req.Id);
        ltStatus.Text = req.IsActive ? "Active" : "Not active";


    }
    protected void lbtRequest_Command(object sender, CommandEventArgs e)
    {
        

        var reqidstr = (e.CommandArgument as string).Split('|')[0];
        var rowindex = Utils.Convert.ToInt( (e.CommandArgument as string).Split('|')[1],-1);

        int reqId = Utils.Convert.ToInt(reqidstr,0);
        var req = DAL.Container.Instance.Requests.SingleOrDefault(r => r.Id == reqId);
        //DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, req);
        DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, req.NeedItems);
        
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

        var ni = e.Row.DataItem as DAL.NeedItem;

        var ltType = e.Row.FindControl("ltType") as Literal;
        var ltUnit = e.Row.FindControl("ltUnit") as Literal;
        var ltAmt = e.Row.FindControl("ltAmt") as Literal;
        var ltCollected = e.Row.FindControl("ltCollected") as Literal;

        var ibtRemove = e.Row.FindControl("ibtRemove") as ImageButton;

        
        ltType.Text = ni.ItemType;
        ltAmt.Text = ni.ItemAmount + "";
        ltCollected.Text = ni.SuppliedAmount + "";
        ltUnit.Text = Utils.Reflection.GetEnumDescription( ni.MetricType);

        ibtRemove.CommandArgument = ni.Id + "";
         


    }

    protected void ibtRemove_Command(object sender, CommandEventArgs e)
    { 
        int niid = Utils.Convert.ToInt(e.CommandArgument as string, 0);
        var niToDel = DAL.Container.Instance.NeedItems.SingleOrDefault(ni => ni.Id == niid);
        DAL.Container.Instance.NeedItems.DeleteObject(niToDel);
        DAL.Container.Instance.SaveChanges();
        DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, SelectedRequest);

        gvNeedList.DataSource = SelectedRequest.NeedItems;
        gvNeedList.DataBind();

        
    }


    protected void gvVolunteers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var res = e.Row.DataItem as DAL.RequestRespons;
        DAL.Container.Instance.Refresh(System.Data.Objects.RefreshMode.StoreWins, res.NeedItems);

        var hlVolName = e.Row.FindControl("hlVolName") as HyperLink;
        var lbResponse = e.Row.FindControl("lbResponse") as Label;
        var lbSupplied = e.Row.FindControl("lbSupplied") as Label;

        hlVolName.Text = res.Volunteer.NameLastName;

        hlVolName.NavigateUrl = "#";
        if (res.Answer.HasValue && res.Answer.Value == true)
            lbResponse.Text = "Accepted";
        if (res.Answer.HasValue && res.Answer.Value == false)
            lbResponse.Text = "Rejected";
        if (!res.Answer.HasValue)
            lbResponse.Text = "Waiting";

        var supplied = "-";
        foreach (DAL.NeedItem ni in res.NeedItems)
        {
            string s = ni.SuppliedAmount + " ";
            if (ni.MetricType != Utils.Enumerations.MetricTypes.Item)
                s += Utils.Reflection.GetEnumDescription(ni.MetricType)+" ";
            s += ni.ItemType+ ", ";

            supplied += s;
        }
        if (supplied != "-")
            supplied = supplied.Substring(0, supplied.Length - 2).Replace("-","");

        lbSupplied.Text = supplied;

        
        
    }
}