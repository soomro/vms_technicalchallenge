using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.Enumerations;
using DAL;

public partial class Incident : System.Web.UI.Page
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

    private void BindData()
    {
        gvNeedList.DataSource = NeedList;
        gvNeedList.DataBind();
    }



    protected void btAddNew_Click(object sender, EventArgs e)
    {
        NeedList.Add(new NeedItem());
        PersistNeedList();
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
            var ucType = row.FindControl("ucType") as UC_ucEnumSelector;
            var ucUnit = row.FindControl("ucUnit") as UC_ucEnumSelector;
            var txAmount = row.FindControl("txAmount") as TextBox;
            var txCollected = row.FindControl("txCollected") as TextBox;

            NeedList[count].MetricType = ucUnit.SelectedValue<MetricTypes>();
            Response.Write(NeedList[count].MetricType+"-");
            NeedList[count].ItemAmount = Utils.Convert.ToDouble(txAmount.Text, 0);
            NeedList[count].SuppliedAmount =  Utils.Convert.ToDouble(txCollected.Text, 0);

            count++;
        }
    }
    protected void gvNeedList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType!=DataControlRowType.DataRow)
        {
            return;
        }

        var ni = e.Row.DataItem as NeedItem;

        var ucType = e.Row.FindControl("ucType") as UC_ucEnumSelector;
        var ucUnit = e.Row.FindControl("ucUnit") as UC_ucEnumSelector;
        var txAmount = e.Row.FindControl("txAmount") as TextBox;
        var txCollected = e.Row.FindControl("txCollected") as TextBox;

        ucUnit.EnumType = typeof(MetricTypes);
        ucUnit.SelectionType = EnumSelectionTypes.DropDownList;
        ucUnit.DefaultSelection = ni.MetricType;
        ucUnit.Bind();

        txAmount.Text = ni.ItemAmount + "";
        txCollected.Text = ni.SuppliedAmount + "";
    }
}