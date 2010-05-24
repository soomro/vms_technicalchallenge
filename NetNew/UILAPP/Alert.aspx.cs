using System;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils.Enumerations;

public partial class Alert : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        if (!IsPostBack)
        {
            //for test purpose uncomment line below
            //MainCrisis = DAL.Container.Instance.Crises.Single(r => r.Id==22);
            if (PageAction == PageActions.View)
            {
                Master.PageTitle = "Alert List Page";
                Master.SetSiteMap(new[]{
                                 new[] {"Crisis Board", "CrisisBoard.aspx"},
                                  new[]{"Alert List Page","" }
                              });

                pnlAlertList.Visible = true;
                pnlDivForm.Visible = false;
                //filling up alerts
                IOrderedQueryable<DAL.Alert> q = from alert in Container.Instance.Alerts
                                                 where alert.Crisis_Id == MainCrisis.Id
                                                 orderby alert.DateSent descending 
                                                 select alert;
                gvAlerts.DataSource = q;
                gvAlerts.DataBind();
            }
            else
            {
                Master.PageTitle = "Create New Alert";
                Master.SetSiteMap(new[]{
                                 new[] {"Crisis Board", "CrisisBoard.aspx"},
                                  new[]{"Alert List Page:","Alert.aspx?Action=View" },
                                  new[]{"Create New Alert","" }                        
                              });
                pnlAlertList.Visible = false;
                pnlDivForm.Visible = true;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.PageCrisisBoard);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtMessage.Text.Trim()==string.Empty)
        {
            Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Message field should not be empty.");
            return;
        }
        if (ucSearchVolunteer.SearchCriteriaString.Trim() == string.Empty)
        {
            Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Search criteria field should not be empty.");
            return;
        }

        var alert = new DAL.Alert();
        alert.Message = txtMessage.Text;
        alert.SearchCriteriaStr = ucSearchVolunteer.SearchCriteriaString;
        alert.DateSent = DateTime.Now;
        alert.Crisis_Id = MainCrisis.Id;
        Container.Instance.Alerts.AddObject(alert);
        Container.Instance.SaveChanges();
        if (ucSearchVolunteer.SelectedVolunteers.Count < 1)
        {
            Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "No volunteers have been selected.");
            return;
        }
        bool sent = false;
        foreach (int item in ucSearchVolunteer.SelectedVolunteers)
        {
            var temp = new AlertsVolunteer();
            temp.Alert_Id = alert.Id;
            temp.Volunteer_Id = item;
            Container.Instance.AlertsVolunteers.AddObject(temp);
            sent = true;
        }
        Container.Instance.SaveChanges();
        if (sent)
        {
            Master.ShowMessage(MessageTypes.Info,"Messages have been sent, now navigating to the crisis board...");
            RedirectAfter(3,Constants.PageCrisisBoard);
        }
    }

    protected void gvAlerts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as DAL.Alert;
        var lblSent = e.Row.FindControl("lblSent") as Label;
        var lblSearch = e.Row.FindControl("lblSearch") as Label;
        var lbMessage = e.Row.FindControl("lbMessage") as Label;

        lblSent.Text = (ni.DateSent.HasValue) ? ni.DateSent.Value.ToString() : string.Empty;
        lblSearch.Text = ni.SearchCriteriaStr;
        lbMessage.Text = ni.Message;
    }
}