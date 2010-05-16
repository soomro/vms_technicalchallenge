using System;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils;
using Utils.Enumerations;
using Convert = Utils.Convert;

public partial class ProgressReports : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        var gs = new GridStyleUtil(gvProgressReports, GridStyleEnum.Niko);

        if (!IsPostBack)
        {
            DAL.Incident i = GetIncidentFromIid();
            if (i == null)
            {
                Master.ShowMessage(MessageTypes.Error, "Invalid parameter");
                return;
            }

            gvProgressReports.DataSource = i.ProgressReports;
            gvProgressReports.DataBind();
            Master.PageTitle = "Progress Reports";

            Master.SetSiteMap(new[]
                                  {
                                      new[] {"Crisis Board", "CrisisBoard.aspx"},
                                      new[] {"Incident:" + i.ShortDescription, "Incident.aspx?action=Edit&iid=" + i.Id},
                                      new[] {"Progress Reports", ""},
                                  });
        }
    }

    private DAL.Incident GetIncidentFromIid()
    {
        int iid = Convert.ToInt(Request["iid"], 0);
        if (iid == 0)
        {
            return null;
        }
        DAL.Incident obj = (from i in Container.Instance.Incidents
                            where i.Id == iid
                            select i).FirstOrDefault();
        return obj;
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProgressReports.PageIndex = e.NewPageIndex;
        gvProgressReports.DataSource = GetIncidentFromIid().ProgressReports;
        gvProgressReports.DataBind();
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        var p = e.Row.DataItem as ProgressReport;

        var g = new GridUtil(e.Row);
        //g.SetControlText("hlName", inc.ShortDescription, 20);
        //(g.GetControl("hlName") as HyperLink).NavigateUrl = Constants.PageIncident + "?iid=" + inc.Id + "&Action=Edit";
        g.SetControlText("lbDateSent", p.DateSent.ToString("dd MMM yy, hh:mm"));
        g.SetControlText("lbVolunteer", p.Volunteer.NameLastName);
        g.SetControlText("lbReportText", p.ReportText, 20);
        g.SetControlText("lbStatus", Reflection.GetEnumDescription(p.IncidentStatus));
        //g.SetControlText("lbIncidentType", Utils.Reflection.GetEnumDescription(inc.IncidentType));


        //var cell = e.Row.Cells[4];
        //cell.BackColor = Color.FromArgb(255, 252, 3, 15);
        //if (inc.Severity == Utils.Enumerations.Severities.Critical) { cell.Style["opacity"] = "1"; cell.Style["filter"] = "alpha(opacity=100)"; }
        //if (inc.Severity == Utils.Enumerations.Severities.High) { cell.Style["opacity"] = "0.8"; cell.Style["filter"] = "alpha(opacity=80)"; }
        //if (inc.Severity == Utils.Enumerations.Severities.Medium) { cell.Style["opacity"] = "0.7"; cell.Style["filter"] = "alpha(opacity=70)"; }
        //if (inc.Severity == Utils.Enumerations.Severities.Low) { cell.Style["opacity"] = "0.4"; cell.Style["filter"] = "alpha(opacity=40)"; }
        //cell.ForeColor = Color.White;

        //g.SetControlText("lbShortAddress", inc.ShortAddress, 10);
    }
}