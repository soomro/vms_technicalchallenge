using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrisisList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var clist = (from c in DAL.Container.Instance.Crises
                        where c.StatusVal == (short)Utils.Enumerations.CrisisStatuses.Closed
                        select c).OrderBy(c1 => c1.Name).ToList();
            gvCrisisList.DataSource = clist;
            gvCrisisList.DataBind();
            Master.PageTitle = "Closed Crises";
        }
    }
    protected void gvCrisisList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var hdId  = gvCrisisList.SelectedRow.FindControl("hdId") as HiddenField;
        Response.Redirect(Constants.PageCrisis+string.Format("?Action={0}&cid={1}",PageActions.Edit,hdId.Value));
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

        lbCrisisType.Text = Utils.Reflection.GetEnumDescription(cr.CrisisType);
        lbDateCreated.Text = cr.DateCreated.ToString("dd MMM yyyy");
        lbDateClosed.Text = cr.DateClosed.HasValue?cr.DateClosed.Value.ToString("dd MMM yyyy"):"-";
        lbCrisisType.Text = Utils.Reflection.GetEnumDescription(cr.CrisisType);
    }
    protected void gvCrisisList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var clist = (from c in DAL.Container.Instance.Crises
                     where c.StatusVal == (short)Utils.Enumerations.CrisisStatuses.Closed
                     select c).OrderBy(c1 => c1.Name).Skip((e.NewPageIndex ) * gvCrisisList.PageCount).ToList();
        gvCrisisList.DataSource = clist;

        gvCrisisList.PageIndex = e.NewPageIndex;
        
        gvCrisisList.DataBind();

       

    }
}