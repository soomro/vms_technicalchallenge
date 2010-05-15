using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UControls_UCSearchVolunteer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvVolList.DataSource = DAL.Container.Instance.Volunteers;
            gvVolList.DataBind();
        }
    }
    public List<int> SelectedVolunteers
    {
        get
        {
            var list = new List<int>();
            foreach (GridViewRow row in gvVolList.Rows)
            {
                var chk = row.FindControl("chkSelected") as CheckBox;
                if(chk.Checked)
                    list.Add(Convert.ToInt32(this.gvVolList.DataKeys[row.RowIndex].Value.ToString()));
            }
            return list;
        }
    }
    public string SelectedVolunteersString
    {
        get
        {
            return Utils.Collection.ToString<int>(SelectedVolunteers);
        }
    }
    public string SearchCriteriaString
    {
        get
        {
            return txtCriteria.Text;
        }
        set
        {
            txtCriteria.Text = value;
        }
    }

    protected void gvVolList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as DAL.Volunteer;
        //var chkSent = e.Row.FindControl("chkSelected") as CheckBox;
        var lblVolName = e.Row.FindControl("lblVolName") as Label;

        lblVolName.Text = ni.NameLastName;
    }
   
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var array = txtCriteria.Text.Split(' ');
        List<DAL.Volunteer> vols = new List<DAL.Volunteer>();
        foreach (var item in array)
        {
            var q = from vol in DAL.Container.Instance.Volunteers
                    where vol.EduAndTrainings.Contains(item)
                    select vol;
            vols.AddRange(q);
        }
        gvVolList.DataSource = vols;
        gvVolList.DataBind();
    }
}