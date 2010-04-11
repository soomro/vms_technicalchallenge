using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.PageTitle = "Starting page for test purposes";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var str = DAL.Container.Instance.Connection.ConnectionString;
        
    }
}
