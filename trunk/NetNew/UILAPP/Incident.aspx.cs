using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using BLL.BWorkflows;
using DAL;
using Utils;
using Utils.Enumerations;
using Utils.Exceptions;
using Convert = Utils.Convert;

public partial class Incident : PageBase
{
    private int needItemOrder;

    public List<NeedItem> NeedList
    {
        get
        {
            if (Session["_NeedList"] == null)
            {
                Session["_NeedList"] = new List<NeedItem>();
            }
            return Session["_NeedList"] as List<NeedItem>;
        }
        set { Session["_NeedList"] = value; }
    }

    protected override void OnPreRender(EventArgs e)
    {
        txShortAddress.Text = HttpContext.Current.Items["adrName"] as string;
        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        if (!IsPostBack)
        {
            ucIncidentType.EnumType = typeof (IncidentTypes);
            ucSeverity.EnumType = typeof (Severities);

            if (PageAction == PageActions.Create)
            {
                if (MainCrisis == null)
                {
                    Master.ShowMessage(MessageTypes.Error, "There is no active crisis to create incident");
                    pgTable.Visible = false;
                    return;
                }

                NeedList = null; // clear if it contains any.
                NeedList.Add(new NeedItem()); // add an empty line for starting
                BindData();
                UCIncidentMap1.Incident = null;
                Master.PageTitle = "Create Incident";
                Master.SetSiteMap(new[]
                                      {
                                          new[] {"Crisis Board", "CrisisBoard.aspx"},
                                          new[] {"Create Incident", ""},
                                      });
            }
            else if (PageAction == PageActions.Edit)
            {
                DAL.Incident inc = GetIncident();
                if (inc == null)
                {
                    Master.ShowMessage(MessageTypes.Error, "Invalid paramater");
                    return;
                }
                BindDataForEdit(inc);
                Master.PageTitle = "Edit Incident";
            }
            else
            {
                Response.Redirect(Constants.PageIncident + "?Action=Create", true);
            }
        }
    }


    private void BindDataForEdit(DAL.Incident inc)
    {
        Master.PageTitle = "info";
        ucIncidentType.DefaultSelection = inc.IncidentType;
        ucSeverity.DefaultSelection = inc.Severity;

        txShortDesc.Text = inc.ShortDescription;
        txExplanation.Text = inc.Explanation;
        txShortAddress.Text = inc.ShortAddress;
        lbStatus.Text = Reflection.GetEnumDescription(inc.IncidentStatus);
        NeedList = null;
        foreach (NeedItem ni in inc.NeedItems)
        {
            NeedList.Add(ni);
        }

        gvNeedList.DataSource = NeedList;
        gvNeedList.DataBind();
        UCIncidentMap1.Incident = new GoogleMarker(
            Convert.ToDouble(inc.LocationCoordinates[0], 0),
            Convert.ToDouble(inc.LocationCoordinates[1], 0));
        if (inc.LocationCoordinates.Count > 2)
            UCIncidentMap1.Zoom = Convert.ToInt(inc.LocationCoordinates[2], 8);

        btClose.Visible = true;
        dvMenu.Visible = true;
        hlResourceGathering.NavigateUrl = Constants.PageResourceGathering + "?iid=" + inc.Id;
        hlProgressReports.NavigateUrl = Constants.PageProgressReports + "?iid=" + inc.Id;

        bool boolVal = true;
        if (inc.Crisis.Status == CrisisStatuses.Closed)
            boolVal = false;

        if (boolVal)
        {
            Master.SetSiteMap(new[]
                                  {
                                      new[] {"Crisis Board", "CrisisBoard.aspx"},
                                      new[] {"Edit Incident", ""},
                                  });
        }
        else
        {
            Master.SetSiteMap(new[]
                                  {
                                      new[]
                                          {
                                              "Crisis:" + inc.Crisis.Name,
                                              "Crisis.aspx?cid=" + inc.Crisis.Id + "&action=Edit"
                                          },
                                      new[] {"Incident:" + inc.ShortDescription, ""},
                                  });
            Master.PageTitle = "View Incident";
        }
        txShortDesc.Enabled = boolVal;
        txShortAddress.Enabled = boolVal;
        txExplanation.Enabled = boolVal;
        ucSeverity.Enabled = boolVal;
        ucIncidentType.Enabled = boolVal;
        UCIncidentMap1.Enabled = boolVal;
        btAddNew.Visible = boolVal;
        btClose.Visible = boolVal;
        btSave.Visible = boolVal;
        btReactivate.Visible = !boolVal;
        rowStatus.Visible = true;

        Master.PageTitle = boolVal + "";
    }

    /// <summary>
    /// Gets the incidentid from url and retrieves the object from db.
    /// </summary>
    /// <returns></returns>
    private DAL.Incident GetIncident()
    {
        int iid = Convert.ToInt(Request[Constants.IdIncidentId], 0);
        if (iid == 0)
            return null;
        DAL.Incident incObj = Container.Instance.Incidents.SingleOrDefault(inc => inc.Id == iid);
        return incObj;
    }

    protected override void OnPreLoad(EventArgs e)
    {
        PersistNeedList();

        base.OnPreLoad(e);
    }

    private void BindData()
    {
        gvNeedList.DataSource = NeedList;
        gvNeedList.DataBind();
        btClose.Visible = false;
        dvMenu.Visible = false;
        rowStatus.Visible = false;
        btReactivate.Visible = false;
    }


    protected void btAddNew_Click(object sender, EventArgs e)
    {
        NeedList.Add(new NeedItem());
        //PersistNeedList();
        BindData();
    }

    private void PersistNeedList()
    {
        // since the need items doesnt have IDs initialy, we can only match values by order.
        int count = 0;

        foreach (GridViewRow row in gvNeedList.Rows)
        {
            if (count > NeedList.Count - 1)
            {
                break;
            }
            var txItemType = row.FindControl("txItemType") as TextBox;
            var ucUnit = row.FindControl("ucUnit") as UC_ucEnumSelector;
            var txAmount = row.FindControl("txAmount") as TextBox;
            var txCollected = row.FindControl("txCollected") as TextBox;

            NeedList[count].MetricType = ucUnit.SelectedValue<MetricTypes>();

            NeedList[count].ItemAmount = Convert.ToDouble(txAmount.Text, 0);
            NeedList[count].SuppliedAmount = Convert.ToDouble(txCollected.Text, 0);
            NeedList[count].ItemType = txItemType.Text;

            count++;
        }
    }

    protected void gvNeedList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as NeedItem;

        var txType = e.Row.FindControl("txItemType") as TextBox;
        var ucUnit = e.Row.FindControl("ucUnit") as UC_ucEnumSelector;
        var txAmount = e.Row.FindControl("txAmount") as TextBox;
        var txCollected = e.Row.FindControl("txCollected") as TextBox;
        var ibtRemove = e.Row.FindControl("ibtRemove") as ImageButton;

        ucUnit.EnumType = typeof (MetricTypes);
        ucUnit.SelectionType = EnumSelectionTypes.DropDownList;
        ucUnit.DefaultSelection = ni.MetricType;
        ucUnit.Bind();

        txType.Text = ni.ItemType;
        txAmount.Text = ni.ItemAmount + "";
        txCollected.Text = ni.SuppliedAmount + "";

        ibtRemove.CommandArgument = needItemOrder + "";

        needItemOrder++;
    }

    [WebMethod, ScriptMethod]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        // TODO: change this method so that return from database

        var needItemTypes = new[]
                                {
                                    "Car", "Water", "Tire", "Clothe", "Rope", "Knife", "Shoe", "Radio", "TV", "Computer"
                                };

        return
            needItemTypes.Where(m => m.StartsWith(prefixText, true, CultureInfo.CurrentCulture)).Select(m => m).ToArray();
    }

    protected void ibtRemove_Command(object sender, CommandEventArgs e)
    {
        //PersistNeedList();

        int order = 0;
        if (!Int32.TryParse(e.CommandArgument.ToString(), out order))
            order = -1;

        if (order != -1)
        {
            NeedList.RemoveAt(order);
        }
        BindData();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        DAL.Incident inc = null;
        if (PageAction == PageActions.Create)
        {
            inc = new DAL.Incident();
        }
        else
        {
            inc = GetIncident();
        }
        inc.Crisis = MainCrisis;

        inc.IncidentType = ucIncidentType.SelectedValue<IncidentTypes>();
        inc.Severity = ucSeverity.SelectedValue<Severities>();

        if (UCIncidentMap1.Incident == null)
        {
            Master.ShowMessage(MessageTypes.Error, "Define incident location on the map.");
            return;
        }
        inc.LocationCoordinates.Clear();
        inc.LocationCoordinates.Add(UCIncidentMap1.Incident.Latitude + "");
        inc.LocationCoordinates.Add(UCIncidentMap1.Incident.Longitude + "");
        foreach (NeedItem ni in NeedList)
        {
            NeedItem orjni = inc.NeedItems.SingleOrDefault(nii => nii.Id == ni.Id);
            if (orjni != null)
            {
// this need item was there before. just update values.

                orjni.ItemAmount = ni.ItemAmount;
                orjni.ItemType = ni.ItemType;
                orjni.MetricType = ni.MetricType;
                orjni.SuppliedAmount = ni.SuppliedAmount;
            }
            else
            {
                if (ni.EntityState != EntityState.Detached)
                    inc.NeedItems.Add(new NeedItem
                                          {
                                              ItemAmount = ni.ItemAmount,
                                              ItemType = ni.ItemType,
                                              MetricType = ni.MetricType,
                                              SuppliedAmount = ni.SuppliedAmount
                                          });
                else
                    inc.NeedItems.Add(ni);
            }
        }
        var removeList = new List<NeedItem>();
        foreach (NeedItem ni in inc.NeedItems)
        {
            NeedItem obj = NeedList.Where(n => n.Id == ni.Id).FirstOrDefault();
            if (obj == null) removeList.Add(ni);
        }
        while (removeList.Count > 0)
        {
            NeedItem o = removeList[0];
            Container.Instance.NeedItems.DeleteObject(o);
            removeList.Remove(o);
        }
        inc.DateCreated = DateTime.Now;
        inc.ShortDescription = Utils.Convert.SafeString(txShortDesc.Text);
        inc.Explanation = Utils.Convert.SafeString(txExplanation.Text);
        inc.ShortAddress = Utils.Convert.SafeString(txShortAddress.Text);
        inc.LocationCoordinates.Add(UCIncidentMap1.Zoom + "");

        IList<string> msgs = inc.Validate();
        if (msgs.Count > 0)
        {
            Master.ShowMessage(MessageTypes.Error, msgs.ToArray());
            return;
        }
        if (PageAction == PageActions.Create)
            Container.Instance.Incidents.AddObject(inc);

        Container.Instance.SaveChanges();

        if (PageAction == PageActions.Create)
        {
            Master.ShowMessage(MessageTypes.Info, "Successfully saved. Now navigating to crisis board");
            RedirectAfter(3, Constants.PageCrisisBoard);
        }
        else if (PageAction == PageActions.Edit)
        {
            Master.ShowMessage(MessageTypes.Info, "Successfully updated.");
        }
    }

    protected void btClose_Click(object sender, EventArgs e)
    {
        DAL.Incident inc = GetIncident();
        if (inc == null)
        {
            Master.ShowMessage(MessageTypes.Error, "Invalid paramater");
            return;
        }
        try
        {
            IncidentOperations.CloseIncident(inc.Id);
            Master.ShowMessage(MessageTypes.Info, "Incident set to \"Completed\"");
            Container.Instance.Refresh(RefreshMode.StoreWins, inc);
            BindDataForEdit(inc);
        }
        catch (VMSException ex)
        {
            Master.ShowMessage(MessageTypes.Error, ex.Messages.ToArray());
            return;
        }
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.PageCrisisBoard);
    }

    protected void btReactivate_Click(object sender, EventArgs e)
    {
        DAL.Incident inc = GetIncident();
        if (inc == null)
        {
            Master.ShowMessage(MessageTypes.Error, "Incident could not be found!");
            return;
        }
        inc.IncidentStatus = IncidentStatuses.ResourceGathering;
        Container.Instance.SaveChanges();
        Master.ShowMessage(MessageTypes.Info, "Incident reactivated!");
        RedirectAfter(4, Request.RawUrl);
    }
}