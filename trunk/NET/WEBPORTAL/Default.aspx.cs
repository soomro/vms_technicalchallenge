using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.EntityClasses;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var name = TextBox1.Text;
        int birtDate = Convert.ToInt32(TextBox2.Text);
        WSREF.WS ws = new WSREF.WS();
        Label1.Text = ws.CalculateMyAge(birtDate, name);


        EntityModelContainer cont = new EntityModelContainer();

        var ccc = new Crisis();

        var c = new Crisis
        {
            Name = "Earthquake",
            DateCreated = DateTime.Now,
            Explanation = "This is explanation2222222",
            LocationCoordinatesStr = "2222222",
            
        };

        var inc = new Incident()
        {
            Explanation="this is expla",
            DateCreated = DateTime.Now,
            ShortDescription = "this is short desc test test",
            LocationCoordinatesStr = "222test test",
            ShortAddress = "goteborgtest test",
            LocationType = EnumLocationType.Freeform
        };
        
        c.Alerts.Add(
            new Alert()
            {
                Message = "ruuuuuuntest testtest test",
                Incident = inc           ,
                SearchCriteriaStr = "name=abdullah"
            }
        );

        cont.Crises.AddObject(c);
        cont.SaveChanges();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int crisisId = Convert.ToInt32(TextBox4.Text);

        EntityModelContainer cont = new EntityModelContainer();
        var cr = cont.Crises.Single(c => c.Id == crisisId);

        cr.Name = TextBox3.Text;

        cont.SaveChanges();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int crisisId = Convert.ToInt32(TextBox4.Text);

        EntityModelContainer cont = new EntityModelContainer();
        var cr = cont.Crises.Single(c => c.Id == crisisId);

        TextBox3.Text = cr.Name;
    }
}