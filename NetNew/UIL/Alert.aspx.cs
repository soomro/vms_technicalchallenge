using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alert : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //for test purpose, remove it
            MainCrisis = DAL.Container.Instance.Crises.First();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        var alert = new DAL.Alert();
        alert.Message = txtMessage.Text;
        alert.SearchCriteriaStr = ucSearchVolunteer.SelectedVolunteersString;
        alert.DateSent = DateTime.Now;
        alert.Crisis_Id = MainCrisis.Id;
        DAL.Container.Instance.Alerts.AddObject(alert);
        DAL.Container.Instance.SaveChanges();

    }
}