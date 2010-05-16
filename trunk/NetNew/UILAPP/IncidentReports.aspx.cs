using System;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;

public partial class IncidentReports : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();
        if (!IsPostBack)
        {
            Master.PageTitle = "Incident Reports";
            IOrderedQueryable<IncidentReport> q = from report in Container.Instance.IncidentReports
                                                  //where crisisid=maincrisis.id
                                                  orderby report.ReportDate
                                                  select report;
            gvReports.DataSource = q;
            gvReports.DataBind();
        }
    }

    protected void gvReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as IncidentReport;
        var lblSent = e.Row.FindControl("lblSent") as Label;
        var lblLocation = e.Row.FindControl("lblLocation") as Label;
        var lblType = e.Row.FindControl("lblType") as Label;
        var txtMessage = e.Row.FindControl("txtMessage") as TextBox;

// ReSharper disable PossibleNullReferenceException
        lblSent.Text = (ni.ReportDate.HasValue) ? ni.ReportDate.Value.ToString() : string.Empty;
        lblLocation.Text = ni.Location;
        txtMessage.Text = ni.Description;
        lblType.Text = ni.IncidentType.ToString();
// ReSharper restore PossibleNullReferenceException
    }
}