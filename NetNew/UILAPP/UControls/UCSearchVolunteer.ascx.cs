using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Utils;
using Convert = System.Convert;

public partial class UControls_UCSearchVolunteer : UserControl
{
    public List<int> SelectedVolunteers
    {
        get
        {
            var list = new List<int>();
            foreach (GridViewRow row in gvVolList.Rows)
            {
                var chk = row.FindControl("chkSelected") as CheckBox;
                if (chk.Checked)
                    list.Add(Convert.ToInt32(gvVolList.DataKeys[row.RowIndex].Value.ToString()));
            }
            return list;
        }
    }

    public string SelectedVolunteersString
    {
        get { return Collection.ToString(SelectedVolunteers); }
    }

    public string SearchCriteriaString
    {
        get { return txtCriteria.Text; }
        set { txtCriteria.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void gvVolList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as Volunteer;
        //var chkSent = e.Row.FindControl("chkSelected") as CheckBox;
        var lblVolName = e.Row.FindControl("lblVolName") as Label;

        lblVolName.Text = ni.NameLastName;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string[] array = txtCriteria.Text.Split(' ');
        var vols = new List<Volunteer>();
        foreach (string item in array)
        {
            IQueryable<Volunteer> q = from vol in Container.Instance.Volunteers
                                      where vol.EduAndTrainings.Contains(item)
                                      select vol;
            vols.AddRange(q);
        }
        gvVolList.DataSource = vols;
        gvVolList.DataBind();
    }
}