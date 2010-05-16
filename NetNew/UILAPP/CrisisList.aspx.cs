using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DAL;
using Utils;
using Utils.Enumerations;

public partial class CrisisList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequireManager();

        var gs = new GridStyleUtil(gvCrisisList, GridStyleEnum.Niko);
        if (!IsPostBack)
        {
            List<DAL.Crisis> clist = (from c in Container.Instance.Crises
                                      where c.StatusVal == (short) CrisisStatuses.Closed
                                      select c).OrderBy(c1 => c1.Name).ToList();
            gvCrisisList.DataSource = clist;
            gvCrisisList.DataBind();
            Master.PageTitle = "Closed Crises";

            Master.SetSiteMap(new[]
                                  {
                                      new[] {"Closed Crises", ""}
                                  });
        }
    }

    protected void gvCrisisList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var hdId = gvCrisisList.SelectedRow.FindControl("hdId") as HiddenField;
        Response.Redirect(Constants.PageCrisis + string.Format("?Action={0}&cid={1}", PageActions.Edit, hdId.Value));
    }

    protected void gvCrisisList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var cr = e.Row.DataItem as DAL.Crisis;
        var lbCrisisType = e.Row.FindControl("lbCrisisType") as Label;
        var lbDateCreated = e.Row.FindControl("lbDateCreated") as Label;
        var lbDateClosed = e.Row.FindControl("lbDateClosed") as Label;

        lbCrisisType.Text = Reflection.GetEnumDescription(cr.CrisisType);
        lbDateCreated.Text = cr.DateCreated.ToString("dd MMM yyyy");
        lbDateClosed.Text = cr.DateClosed.HasValue ? cr.DateClosed.Value.ToString("dd MMM yyyy") : "-";
        lbCrisisType.Text = Reflection.GetEnumDescription(cr.CrisisType);
    }

    protected void gvCrisisList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCrisisList.PageIndex = e.NewPageIndex;
        List<DAL.Crisis> clist = (from c in Container.Instance.Crises
                                  where c.StatusVal == (short) CrisisStatuses.Closed
                                  select c).OrderBy(c1 => c1.Name).ToList();
        gvCrisisList.DataSource = clist;
        gvCrisisList.DataBind();
    }
}