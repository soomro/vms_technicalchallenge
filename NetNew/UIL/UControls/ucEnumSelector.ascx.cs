using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_ucEnumSelector : System.Web.UI.UserControl
{
    public Type EnumType { get; set; }
    public object DefaultSelection { get; set; }

    public EnumSelectionTypes SelectionType
    {
        get
        {
            if (rdlOptions.Visible)
            {
                return EnumSelectionTypes.RadioButtonList;
            }
            else if (ddlOptions.Visible)
            {
                return EnumSelectionTypes.DropDownList;
            }
            else
            {
                return EnumSelectionTypes.None;
            }
        }
        set
        {
            if (value== EnumSelectionTypes.DropDownList)
            {
                ddlOptions.Visible = true;
                rdlOptions.Visible = false;
            }
            if (value== EnumSelectionTypes.RadioButtonList)
            {
                ddlOptions.Visible = false;
                rdlOptions.Visible = true;
            }
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    public  void Bind()
    {
        var selVal = "";
        if (SelectionType==EnumSelectionTypes.DropDownList && ddlOptions.SelectedValue!=null)
            selVal = ddlOptions.SelectedValue;
        if (SelectionType==EnumSelectionTypes.RadioButtonList && rdlOptions.SelectedValue!=null)
            selVal = rdlOptions.SelectedValue;

        rdlOptions.Items.Clear();
        ddlOptions.Items.Clear();

        if (EnumType==null) return;

        var names = Enum.GetNames(EnumType);
        foreach (Enum item in Enum.GetValues(EnumType))
        {
            var li = new ListItem(Utils.Reflection.GetEnumDescription(item),item.ToString());
            rdlOptions.Items.Add(li);
            ddlOptions.Items.Add(li);

            if (string.IsNullOrEmpty(selVal) 
                && item.ToString() == DefaultSelection+"")
            {
                li.Selected = true;
            }
            if (!string.IsNullOrEmpty(selVal) && item.ToString()==selVal)
            {
                li.Selected = true;
            }

        }

        //foreach (var name in names)
        //{
            
        //    var li = new ListItem(name);
        //    if (string.IsNullOrEmpty(selVal) 
        //        && (Enum.Parse(EnumType, name)).ToString() == DefaultSelection+"")
        //    {
        //        li.Selected = true;
        //    }
        //    if (!string.IsNullOrEmpty(selVal) && name==selVal)
        //    {
        //        li.Selected = true;
        //    }
        //    rdlOptions.Items.Add(li);
        //    ddlOptions.Items.Add(li);
        //}
    }

    public string CssClass
    {
        get { return rdlOptions.CssClass; }
        set { rdlOptions.CssClass = value; }
    }

    public T SelectedValue<T>()
    {
        try
        {
            if (SelectionType==EnumSelectionTypes.RadioButtonList)
            {
                var selObj = (T)Enum.Parse(typeof(T), rdlOptions.SelectedValue);
                return selObj;
            }
            else if (SelectionType==EnumSelectionTypes.DropDownList)
            {
                var selObj = (T)Enum.Parse(typeof(T), ddlOptions.SelectedValue);
                return selObj;
            }
            else
            {
                return default(T);
            }
        }
        catch (Exception)
        {
            return default(T);
        }

    }
}