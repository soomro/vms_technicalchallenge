using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils;
using Utils.Enumerations;
using Convert = Utils.Convert;

public partial class IncidentList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();


        var gs = new GridStyleUtil(gvIncidents, GridStyleEnum.Niko);

        if (!IsPostBack)
        {
            DAL.Crisis cr = GetCrisisFromCid();
            if (cr == null)
            {
                Master.ShowMessage(MessageTypes.Error, "Invalid parameter");
                return;
            }

            gvIncidents.DataSource = cr.Incidents;
            gvIncidents.DataBind();
            Master.PageTitle = "Incident List";
            hlCrisis.Text = cr.Name;
            hlCrisis.NavigateUrl = Constants.PageCrisis + "?cid=" + cr.Id + "&action=Edit";

            Master.SetSiteMap(new[]
                                  {
                                      new[] {"Crisis Board", "CrisisBoard.aspx"},
                                      new[] {"Incident List", ""},
                                  });
        }
    }

    private DAL.Crisis GetCrisisFromCid()
    {
        int cid = Convert.ToInt(Request["cid"], 0);
        if (cid == 0)
        {
            return null;
        }
        DAL.Crisis res = (from c in Container.Instance.Crises
                          where c.Id == cid
                          select c).FirstOrDefault();
        return res;
    }

    protected void gvIncidents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIncidents.PageIndex = e.NewPageIndex;
        gvIncidents.DataSource = GetCrisisFromCid().Incidents;
        gvIncidents.DataBind();
    }

    protected void gvIncidents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        var inc = e.Row.DataItem as DAL.Incident;

        var g = new GridUtil(e.Row);
        g.SetControlText("hlName", inc.ShortDescription, 20);
        (g.GetControl("hlName") as HyperLink).NavigateUrl = Constants.PageIncident + "?iid=" + inc.Id + "&Action=Edit";
        g.SetControlText("lbDateCreated", inc.DateCreated.ToString("dd MMM yy, hh:mm"));
        g.SetControlText("lbDateClosed",
                         inc.DateClosed.HasValue ? inc.DateClosed.Value.ToString("dd MMM yy, hh:mm") : "-");
        g.SetControlText("lbStatus", Reflection.GetEnumDescription(inc.IncidentStatus));
        g.SetControlText("lbSeverity", Reflection.GetEnumDescription(inc.Severity));
        g.SetControlText("lbIncidentType", Reflection.GetEnumDescription(inc.IncidentType));


        TableCell cell = e.Row.Cells[4];
        cell.BackColor = Color.FromArgb(255, 252, 3, 15);
        if (inc.Severity == Severities.Critical)
        {
            cell.Style["opacity"] = "1";
            cell.Style["filter"] = "alpha(opacity=100)";
        }
        if (inc.Severity == Severities.High)
        {
            cell.Style["opacity"] = "0.8";
            cell.Style["filter"] = "alpha(opacity=80)";
        }
        if (inc.Severity == Severities.Medium)
        {
            cell.Style["opacity"] = "0.7";
            cell.Style["filter"] = "alpha(opacity=70)";
        }
        if (inc.Severity == Severities.Low)
        {
            cell.Style["opacity"] = "0.4";
            cell.Style["filter"] = "alpha(opacity=40)";
        }
        cell.ForeColor = Color.White;

        g.SetControlText("lbShortAddress", inc.ShortAddress, 10);
    }
}