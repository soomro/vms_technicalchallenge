using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_ucEnumSelector: System.Web.UI.UserControl
{
    public Type EnumType { get;  set; }
    public object DefaultSelection { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rdlOptions.Items.Clear();
            var names = Enum.GetNames(EnumType);
            foreach (var name in names)
            {
                var li = new ListItem(name);
                if (li.ToString()==DefaultSelection.ToString())
                {
                    li.Selected = true;
                }
                rdlOptions.Items.Add(li);
            }
        }
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
            var selObj = (T)Enum.Parse(typeof(T), rdlOptions.SelectedValue);
            return selObj;
        }
        catch (Exception)
        {
            return default(T);
        }
        
    }
}