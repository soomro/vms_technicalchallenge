using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using System.Collections.ObjectModel;
using Utils.Enumerations;
using DAL;
using BLL.BWorkflows;
using Utils.Exceptions;

public partial class Crisis : PageBase
{

    //TODO: check user inputs
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CrisisArea = null;

            ucEnumSelector1.EnumType = typeof(Utils.Enumerations.CrisisTypes);
            ucEnumSelector1.DefaultSelection = Utils.Enumerations.CrisisTypes.Earthquake;
            UCCreateCrisisMap1.Width = new Unit("650px");
            UCCreateCrisisMap1.Heigth = new Unit("550px");

            if (PageAction == PageActions.Edit)
            {
                // check cid first then edit current crisis if no cid is given
                DAL.Crisis cr = GetCrisisFromCid();

                if (cr !=null)
                {
                    BindPage(cr);
                }
                else if (MainCrisis != null)
                {
                    BindPage(MainCrisis);                   
                }
                else
                {
                    Master.ShowMessage(MessageTypes.Error, "Crisis is not defined yet");
                    RedirectAfter(4, Constants.PageCrisis + "?action=Create");
                    return;
                }

               
            }

            else if (PageAction == PageActions.Create)// Create crisis 
            {
                if (MainCrisis!=null && MainCrisis.Status!= CrisisStatuses.Closed)
                {
                    Master.ShowMessage(MessageTypes.Error,"The current crisis is not closed yet! You must close it first.");
                    RedirectAfter(5, Constants.PageCrisis + "?action=" + PageActions.Edit);
                }
                BindPageForCreate();
            }
            else
            {
                Response.Redirect(Constants.PageCrisis+"?action=Create");
            }
        }
    }

    private void BindPageForCreate()
    {
        Master.PageTitle = "Create New Crisis";

        UCCreateCrisisMap1.Radious = 20;
        ddlRadious.SelectedValue = "20";
        CrisisArea = null;
        btnClose.Visible = false;
        rowDateclosed.Visible = false;
        rowDatecreated.Visible = false;
        rowStatus.Visible = false;
        hlIncidents.Visible = false;
    }

    private DAL.Crisis GetCrisisFromCid()
    {
        var cid = Utils.Convert.ToInt(Request["cid"], 0);
        if (cid==0)
        {
            return null;
        }
        var crlist = (from c in DAL.Container.Instance.Crises
                  where c.Id == cid
                  select c).Take(1).ToList();
        if (crlist.Count>0)
        {
            return crlist[0];
        }
        else
        {
            return null;
        }
    }

    private void BindPage(DAL.Crisis cr)
    {
        bool enabledDisabled = true;
        if (cr.Status== CrisisStatuses.Closed)
        {
            enabledDisabled = false;
            Master.PageTitle = "View Crisis";
            
        }
        else 
        {
            enabledDisabled = true;
            Master.PageTitle = "Edit Crisis";
        }

        rowStatus.Visible = !enabledDisabled;
        rowDatecreated.Visible = true;
        rowDateclosed.Visible = !enabledDisabled;
        txtCrisisName.Enabled = enabledDisabled;
        txtExplanation.Enabled = enabledDisabled;
        ucEnumSelector1.Enabled = enabledDisabled;
        ddlRadious.Enabled = enabledDisabled;
        UCCreateCrisisMap1.Enabled = enabledDisabled;
        btnClose.Visible = enabledDisabled;
        btnCancel.Visible = enabledDisabled;
        btnSave.Visible = enabledDisabled;

        ltStatus.Text = Utils.Reflection.GetEnumDescription(cr.Status);
        ltDatecreated.Text = cr.DateCreated.ToString("dd MMM yy, hh:mm");
        ltDateclosed.Text = cr.DateClosed.HasValue ? cr.DateClosed.Value.ToString("dd MMM yy, hh:mm") : "";
        txtCrisisName.Text = cr.Name;
        txtExplanation.Text = cr.Explanation;
        ucEnumSelector1.DefaultSelection = cr.CrisisType;
        double latitude = 0, longitude = 0, radious = 0;
        double.TryParse(cr.LocationCoordinates[0], out latitude);
        double.TryParse(cr.LocationCoordinates[1], out longitude);
        double.TryParse(cr.LocationCoordinates[2], out radious);
        ddlRadious.SelectedValue = radious + "";
        CrisisArea = UC_UCCreateCrisisMap.GetDefaultCirclePolygon(latitude, longitude, radious);
        hlIncidents.NavigateUrl = Constants.PageIncidents + string.Format("?cid={0}", cr.Id);
        
    }
    public GoogleCirclePolygon CrisisArea
    {
        get
        {
            return Session[Constants.IdCrisisArea] as GoogleCirclePolygon;
        }
        set
        {
            Session[Constants.IdCrisisArea] = value;
        }

    }
    protected void ddlRadious_SelectedIndexChanged(object sender, EventArgs e)
    {
        UCCreateCrisisMap1.Radious =  double.Parse(ddlRadious.SelectedValue);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        var ctype = ucEnumSelector1.SelectedValue<Utils.Enumerations.CrisisTypes>();
        var name = txtCrisisName.Text;
        var explanation = txtExplanation.Text;
        if (CrisisArea == null)
        {
            Master.ShowMessage(MessageTypes.Error, "Define crisis area!");
            return;
        }
        var coords = new ObservableCollection<string>();

        coords.Add(UCCreateCrisisMap1.CrisisArea.Latitude + "");
        coords.Add(UCCreateCrisisMap1.CrisisArea.Longitude + "");
        coords.Add(UCCreateCrisisMap1.CrisisArea.Radius + "");

        if (PageAction == PageActions.Create)
        {
            try
            {
                var c = BLL.BWorkflows.CrisisOperations.CreateCrisis(name, explanation, ctype, Utils.Enumerations.LocationTypes.Circle, coords);
                MainCrisis = c;
                Master.ShowMessage(MessageTypes.Info, "A new crisis is created");
                RedirectAfter(4, string.Format(Constants.PageCrisisBoard + "?cid={0}&action=View", c.Id));

            }
            catch (Utils.Exceptions.VMSException ex)
            {
                Master.ShowMessage(MessageTypes.Error, "Following error is occured:" + ex.Message);
                return;
            }
        }
        else if (PageAction == PageActions.Edit)
        {
            // Update
            var c = BLL.BWorkflows.CrisisOperations.UpdateCrisis(MainCrisis.Id, name, explanation, ctype, Utils.Enumerations.LocationTypes.Circle, coords);
            MainCrisis = c;
            Master.ShowMessage(MessageTypes.Info, "Crisis information is updated");
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constants.PageCrisisBoard);
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        if (MainCrisis.Status==CrisisStatuses.Active)
        {
            // TODO : Check for active incidents. All incidents should be closed.
            try
            {
                bool res = CrisisOperations.CloseCrisis(MainCrisis.Id);
                if (res)
                {
                    Master.ShowMessage(MessageTypes.Info,"Crisis status changed to Closed");
                }
                else
                {
                    Master.ShowMessage(MessageTypes.Info, "Operation is unsuccessfull");
                }
            }
            catch (VMSException ex)
            {
                Master.ShowMessage(MessageTypes.Error, ex.Messages.ToArray());
            }
        }
    }
}