using System;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;

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
                pnlAlertList.Visible = true;
                pnlDivForm.Visible = false;
                //filling up alerts
                IOrderedQueryable<DAL.Alert> q = from alert in Container.Instance.Alerts
                                                 where alert.Crisis_Id == MainCrisis.Id
                                                 orderby alert.DateSent
                                                 select alert;
                gvAlerts.DataSource = q;
                gvAlerts.DataBind();
            }
            else
            {
                Master.PageTitle = "Create New Alert";
                pnlAlertList.Visible = false;
                pnlDivForm.Visible = true;
            }
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        var alert = new DAL.Alert();
        alert.Message = txtMessage.Text;
        alert.SearchCriteriaStr = ucSearchVolunteer.SearchCriteriaString;
        alert.DateSent = DateTime.Now;
        alert.Crisis_Id = MainCrisis.Id;
        Container.Instance.Alerts.AddObject(alert);
        Container.Instance.SaveChanges();
        foreach (int item in ucSearchVolunteer.SelectedVolunteers)
        {
            var temp = new AlertsVolunteer();
            temp.Alert_Id = alert.Id;
            temp.Volunteer_Id = item;
            Container.Instance.AlertsVolunteers.AddObject(temp);
        }
        Container.Instance.SaveChanges();
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
        var txtMessage = e.Row.FindControl("txtMessage") as TextBox;

        lblSent.Text = (ni.DateSent.HasValue) ? ni.DateSent.Value.ToString() : string.Empty;
        lblSearch.Text = ni.SearchCriteriaStr;
        txtMessage.Text = ni.Message;
    }
}