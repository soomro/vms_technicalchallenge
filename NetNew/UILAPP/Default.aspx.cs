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

        Logger.Info("deneme");

        if (!IsPostBack)
        {
            Master.PageTitle = "Starting page for test purposes";
        }
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var str = DAL.Container.Instance.Connection.ConnectionString;
        
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        int id= Convert.ToInt32(TextBox1.Text);
        var row = DAL.Container.Instance.Crises.SingleOrDefault(r => r.Id == id);
        MainCrisis = row;
        Response.Redirect(Constants.PageCrisis + "?action=Edit");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CurrentManager = null;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
