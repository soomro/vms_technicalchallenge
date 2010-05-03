using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Exceptions;

public partial class ResourceGathering : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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

        cblNeedlist.Items.Clear();
        foreach (DAL.NeedItem item in inc.NeedItems)
        {
            ListItem li = new ListItem();
            li.Text = item.ItemType + string.Format(" ({1} {0})",
                Utils.Reflection.GetEnumDescription(item.MetricType), item.ItemAmount);
            li.Value = item.Id+"";
            cblNeedlist.Items.Add(li);
        }
    }

    private void DisablePage()
    {
        //throw new NotImplementedException();
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
    protected void btSaveRequest_Click(object sender, EventArgs e)
    {
        var req = DAL.Container.Instance.Requests.CreateObject();
        GetIncident().Requests.Add(req);

        var reqName = Utils.Convert.SafeString(txRequestName.Text);
        var reqMessage = Utils.Convert.SafeString(txMessage.Text);
        
        req.Name = reqName;
        req.Message = reqMessage;
        req.IsActive = true;
        req.Incident = GetIncident();

        foreach (ListItem li in cblNeedlist.Items)
        {
            int liid = Convert.ToInt32(li.Value);
            if (li.Selected)
            {
                var ni = DAL.Container.Instance.NeedItems.SingleOrDefault(n => n.Id == liid);
                var nitemToBeAdded = DAL.Container.Instance.NeedItems.CreateObject();
                nitemToBeAdded.ItemAmount = ni.ItemAmount;
                nitemToBeAdded.ItemType = ni.ItemType;
                nitemToBeAdded.MetricType = ni.MetricType;

                req.NeedItems.Add(nitemToBeAdded);
            }
        }

        req.SearchAreaCoordinatesStr = "test";
        DAL.Container.Instance.Requests.AddObject(req);
        DAL.Container.Instance.SaveChanges();
        BindPage(GetIncident());
    }
    protected void gvReqList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var req = e.Row.DataItem as DAL.Request;

        var lbtRequest = e.Row.FindControl("lbtRequest") as LinkButton;
        var ltStatus = e.Row.FindControl("ltStatus") as Literal;

        lbtRequest.Text = req.Name;
        lbtRequest.CommandArgument = req.Id+"";

        ltStatus.Text = req.IsActive ? "Active" : "Not active";


    }
    protected void lbtRequest_Command(object sender, CommandEventArgs e)
    {
        int reqId = Utils.Convert.ToInt(e.CommandArgument as string,0);
        var req = DAL.Container.Instance.Requests.SingleOrDefault(r => r.Id == reqId);
        gvNeedList.DataSource = req.NeedItems;
        gvNeedList.DataBind();

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
        //PersistNeedList();

        //int order = 0;
        //if (!Int32.TryParse(e.CommandArgument.ToString(), out order))
        //    order = -1;

        //if (order != -1)
        //{
        //    NeedList.RemoveAt(order);
        //}
        //BindData();

    }
}