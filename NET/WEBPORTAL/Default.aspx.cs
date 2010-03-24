using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE.EntityClasses;
using System.Collections.ObjectModel;
using VMSCORE.Operations;
using Subgurim.Controles;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl));
            GMap1.addControl(new GControl(GControl.preBuilt.MapTypeControl));
        }
    }

    protected string GMap1_Click(object s, GAjaxServerEventArgs e)
    {
        GMarker marker = new GMarker(e.point);

        GInfoWindow window = new GInfoWindow(marker,
            string.Format(@"
        <b>GLatLngBounds</b><br />
        SW = {0}<br/>
        NE = {1}
        ",
            e.bounds.getSouthWest().ToString(),
            e.bounds.getNorthEast().ToString())
        , true);

        return window.ToString(e.map);
    }

    protected string GMap1_MarkerClick(object s, GAjaxServerEventArgs e)
    {
        return string.Format("alert('MarkerClick: {0} - {1}')", e.point.ToString(), DateTime.Now);
    }

    protected string GMap1_MoveStart(object s, GAjaxServerEventArgs e)
    {
        return "document.getElementById('messages1').innerHTML= 'MoveStart at " + e.point.ToString() + " - " + DateTime.Now.ToString() + "';";
    }

    protected string GMap1_MoveEnd(object s, GAjaxServerEventArgs e)
    {
        return "document.getElementById('messages2').innerHTML= 'MoveEnd at " + e.point.ToString() + " - " + DateTime.Now.ToString() + "';";
    }

    protected string GMap1_DragStart(object s, GAjaxServerEventArgs e)
    {
        GMarker marker = new GMarker(e.point);
        GInfoWindow window = new GInfoWindow(marker, "DragStart - " + DateTime.Now.ToString(), false);
        return window.ToString(e.map);
    }

    protected string GMap1_DragEnd(object s, GAjaxServerEventArgs e)
    {
        GMarker marker = new GMarker(e.point);
        GInfoWindow window = new GInfoWindow(marker, "DragEnd - " + DateTime.Now.ToString(), false);
        return window.ToString(e.map);
    }

    protected string GMap1_ZoomEnd(object s, GAjaxServerEventZoomArgs e)
    {
        return string.Format("alert('oldLevel/newLevel: {0}/{1} - {2}')", e.oldLevel, e.newLevel, DateTime.Now);
    }

    protected string GMap1_MapTypeChanged(object s, GAjaxServerEventMapArgs e)
    {
        return string.Format("alert('{0}')", e.mapType.ToString());
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

        EntityModelContainer cont = Container.Instance;
        var cr = cont.Crises.Single(c => c.Id == crisisId);
        cr.LocationCoordinates.Add("this is addition");
        cont.SaveChanges();
        TextBox3.Text = cr.Name;
    }
    
}