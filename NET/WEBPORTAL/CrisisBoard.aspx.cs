using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.EntityClasses;
public partial class CrisisBoard : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int crisisId = Convert.ToInt32(TextBox1.Text);

        MainCrisis = Container.Instance.Crises.FirstOrDefault(cr => cr.Id == crisisId);
    }
}