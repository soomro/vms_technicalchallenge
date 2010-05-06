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
            lstVolunteers.DataSource = DAL.Container.Instance.Volunteers;
            lstVolunteers.DataTextField = "NameLastName";
            lstVolunteers.DataValueField = "Id";
            lstVolunteers.DataBind();
        }
    }
    public List<int> SelectedVolunteers
    {
        get
        {
            var list = new List<int>();
            foreach (ListItem item in lstVolunteers.Items)
            {
                if (item.Selected == true)
                    list.Add(Convert.ToInt32(item.Value));
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
}