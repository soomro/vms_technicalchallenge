using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.EntityClasses;
using System.Collections.ObjectModel;
using VMSCORE.Operations; 

public partial class _Default : PageBase 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // throw new Exception();
        }
    }
    

     
    protected void Button1_Click(object sender, EventArgs e)
    {
        //var name = TextBox1.Text;
        //int birtDate = Convert.ToInt32(TextBox2.Text);
        //WSREF.WS ws = new WSREF.WS();
        //Label1.Text = ws.CalculateMyAge(birtDate, name);


        

        //var ccc = CrisisOperations.CreateCrisis("test crisis", "test explanation", EnumCrisisType.Earthquake, EnumLocationType.Rectangle
        //    , new List<string>() { "23231", "33333", "4556", "9999" });


        //var c = new Crisis
        //{
        //    Name = "Earthquake",
        //    DateCreated = DateTime.Now,
        //    Explanation = "This is explanation2222222",
                       
        //}; 
        //c.LocationCoordinates.Add("36.45");
        //c.LocationCoordinates.Add("46.45");

        //var inc = new Incident()
        //{
        //    Explanation="this is expla",
        //    DateCreated = DateTime.Now,
        //    ShortDescription = "this is short desc test test",
        //    ShortAddress = "goteborgtest test",
        //    LocationType = EnumLocationType.Freeform
        //};
        //inc.LocationCoordinates.Add("this is new coordinate");
        //inc.LocationCoordinates.Add("this is another coordinate");
        //var aa = new Alert()
        //    {
        //        Message = "ruuuuuuntest testtest test",
        //        Incident = inc
        //    };
        //aa.SearchCriteria.Add("name=abdullah");
        //aa.SearchCriteria.Add("lastname=nooo");
        //aa.SearchCriteria.Add("surname=testing");
        //c.Alerts.Add(aa);
            


        //Container.Instance.Crises.AddObject(c);
        //Container.Instance.SaveChanges();
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

        MainCrisis = Container.Instance.Crises.FirstOrDefault(cr => cr.Id == crisisId);

        /*cr.LocationCoordinates.Add("this is addition");
        cont.SaveChanges();
        TextBox3.Text = cr.Name;*/
        
    }
    
}