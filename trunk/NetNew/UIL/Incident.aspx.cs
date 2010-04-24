using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Enumerations;
using DAL;

public partial class Incident : PageBase
{
    public List<NeedItem> NeedList
    {
        get
        {
            if (Session["_NeedList"] == null)
            {
                Session["_NeedList"] = new List<NeedItem>();
            }
            return Session["_NeedList"] as List<NeedItem>;
        }
        set
        {
            Session["_NeedList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            ucIncidentType.EnumType = typeof(Utils.Enumerations.IncidentTypes);
            //ucIncidentType.DefaultSelection = IncidentTypes.Bomb;

            ucSeverity.EnumType = typeof(Severities);
            NeedList = null; // clear if it contains any.

            BindData();
        }
        

        

    }
    protected override void OnPreLoad(EventArgs e)
    {
        PersistNeedList();

        base.OnPreLoad(e);
    }
    private void BindData()
    {
        gvNeedList.DataSource = NeedList;
        gvNeedList.DataBind();
    }



    protected void btAddNew_Click(object sender, EventArgs e)
    {
        NeedList.Add(new NeedItem());
        //PersistNeedList();
        BindData();
    }

    private void PersistNeedList()
    {
        // since the need items doesnt have IDs initialy, we can only match values by order.
        int count =0;
        
        foreach (GridViewRow row in gvNeedList.Rows)
        {
            if (count>NeedList.Count-1)
            {
                break;
            }
            var txItemType = row.FindControl("txItemType") as TextBox;
            var ucUnit = row.FindControl("ucUnit") as UC_ucEnumSelector;
            var txAmount = row.FindControl("txAmount") as TextBox;
            var txCollected = row.FindControl("txCollected") as TextBox;

            NeedList[count].MetricType = ucUnit.SelectedValue<MetricTypes>();
            
            NeedList[count].ItemAmount = Utils.Convert.ToDouble(txAmount.Text, 0);
            NeedList[count].SuppliedAmount =  Utils.Convert.ToDouble(txCollected.Text, 0);
            NeedList[count].ItemType = txItemType.Text;
     
            count++;
        }
    }

    int needItemOrder = 0;
    protected void gvNeedList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType!=DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as NeedItem;

        var txType = e.Row.FindControl("txItemType") as TextBox;
        var ucUnit = e.Row.FindControl("ucUnit") as UC_ucEnumSelector;
        var txAmount = e.Row.FindControl("txAmount") as TextBox;
        var txCollected = e.Row.FindControl("txCollected") as TextBox;
        var ibtRemove = e.Row.FindControl("ibtRemove") as ImageButton;

        ucUnit.EnumType = typeof(MetricTypes);
        ucUnit.SelectionType = EnumSelectionTypes.DropDownList;
        ucUnit.DefaultSelection = ni.MetricType;
        ucUnit.Bind();

        txType.Text = ni.ItemType;
        txAmount.Text = ni.ItemAmount + "";
        txCollected.Text = ni.SuppliedAmount + "";

        ibtRemove.CommandArgument = needItemOrder+"";
        
        needItemOrder++;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        // TODO: change this method so that return from database

        string[] needItemTypes = new string[]
        { "Car","Water","Tire","Clothe","Rope","Knife","Shoe","Radio","TV","Computer"
        };
         
        return needItemTypes.Where(m => m.StartsWith(prefixText,true,System.Globalization.CultureInfo.CurrentCulture)).Select(m => m).ToArray();
       
    }
    
    protected void ibtRemove_Command(object sender, CommandEventArgs e)
    {
        //PersistNeedList();

        int order = 0;
        if (!Int32.TryParse(e.CommandArgument.ToString(), out order))
            order = -1;

        if (order!=-1)
        {
            NeedList.RemoveAt(order);
        }
        BindData();

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        //PersistNeedList();

        DAL.Incident inc = new DAL.Incident();
        inc.Crisis = MainCrisis;

        inc.IncidentType = ucIncidentType.SelectedValue<IncidentTypes>();

        inc.LocationCoordinates.Add(UCIncidentMap1.Incident.Latitude+"");
        inc.LocationCoordinates.Add(UCIncidentMap1.Incident.Longitude+"");
        foreach (var ni in NeedList)
        {
            inc.NeedItems.Add(ni);
        }
        inc.DateCreated = DateTime.Now;
        inc.ShortDescription = txShortDesc.Text;
        inc.Explanation = txExplanation.Text;
        inc.ShortAddress = txShortAddress.Text;

        Container.Instance.Incidents.AddObject(inc);
        Container.Instance.SaveChanges();

        Master.ShowMessage(MessageTypes.Info, "Successfully saved. Now navigating to crisis board");
        RedirectAfter(3, Constants.PageCrisisBoard);

    }
}