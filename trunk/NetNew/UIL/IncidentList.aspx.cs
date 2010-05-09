using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class IncidentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.GridStyleUtil gs = new Utils.GridStyleUtil(gvIncidents, Utils.GridStyleEnum.Niko);

        if (!IsPostBack)
        {
            DAL.Crisis cr = GetCrisisFromCid();
            if (cr==null)
            {
                Master.ShowMessage(Utils.Enumerations.MessageTypes.Error, "Invalid parameter");
                return;
            }
            gvIncidents.DataSource = cr.Incidents;
            gvIncidents.DataBind();
            Master.PageTitle = "Incident List";
            hlCrisis.Text = cr.Name;
            hlCrisis.NavigateUrl = Constants.PageCrisis + "?cid=" + cr.Id+"&action=Edit";

        }
    }

    private DAL.Crisis GetCrisisFromCid()
    {
        var cid = Utils.Convert.ToInt(Request["cid"], 0);
        if (cid == 0)
        {
            return null;
        }
        var crlist = (from c in DAL.Container.Instance.Crises
                      where c.Id == cid
                      select c).Take(1).ToList();
        if (crlist.Count > 0)
        {
            return crlist[0];
        }
        else
        {
            return null;
        }
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

        Utils.GridUtil g = new Utils.GridUtil(e.Row);
        g.SetControlText("hlName", inc.ShortDescription, 20);
        (g.GetControl("hlName") as HyperLink).NavigateUrl = Constants.PageIncident+"?iid="+inc.Id;
        g.SetControlText("lbDateCreated", inc.DateCreated.ToString("dd MMM yy, hh:mm"));
        g.SetControlText("lbDateClosed", inc.DateClosed.HasValue?inc.DateClosed.Value.ToString("dd MMM yy, hh:mm"):"-");
        g.SetControlText("lbStatus",Utils.Reflection.GetEnumDescription(inc.IncidentStatus));
        g.SetControlText("lbSeverity", Utils.Reflection.GetEnumDescription(inc.Severity));
        g.SetControlText("lbIncidentType", Utils.Reflection.GetEnumDescription(inc.IncidentType));
       

        var cell = e.Row.Cells[4];
        cell.BackColor = Color.FromArgb(255, 252, 3, 15);
        if (inc.Severity == Utils.Enumerations.Severities.Critical) cell.Style["opacity"] = "1";
        if (inc.Severity == Utils.Enumerations.Severities.High) cell.Style["opacity"] = "0.8";
        if (inc.Severity == Utils.Enumerations.Severities.Medium) cell.Style["opacity"] = "0.7";
        if (inc.Severity == Utils.Enumerations.Severities.Low) cell.Style["opacity"] = "0.4";
        cell.ForeColor = Color.White;

        g.SetControlText("lbShortAddress", inc.ShortAddress, 10);
    }
}