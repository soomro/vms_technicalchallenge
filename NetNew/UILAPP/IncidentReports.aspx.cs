using System;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils;

public partial class IncidentReports : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();
        GridStyleUtil gs = new GridStyleUtil(gvReports, GridStyleEnum.Niko);
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
        Utils.GridUtil gu = new GridUtil(e.Row);
        
        var ni = e.Row.DataItem as IncidentReport;
        gu.SetControlText("lbMessage",ni.Description,30);
        if (ni.ReportDate != null) gu.SetControlText("lbSent",ni.ReportDate.Value.ToString("dd MM yyyy, hh:MM"));
        gu.SetControlText("lbLocation",ni.Location);
        gu.SetControlText("lbType", Utils.Reflection.GetEnumDescription(ni.IncidentType));
        var hl = gu.GetControl("hlReporter") as HyperLink;
        hl.Text = ni.Volunteer.NameLastName;
        hl.NavigateUrl = Constants.PageVolunteerProfile + "?vid=" + ni.Volunteer_Id;
      
    }
}