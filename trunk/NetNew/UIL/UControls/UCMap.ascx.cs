using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using System.Drawing;

public partial class UCMap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set default location 57.7070820644457, lon:11.9915771484375 

            GoogleMap1.Latitude= 57.7070820644457;
            GoogleMap1.Longitude = 11.9915771484375;
            GoogleMap1.Zoom = 8;
            

        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        GoogleMap1.Markers.Clear();
        foreach (var inc in Incidents)
        {
            GoogleMarker m = new GoogleMarker();
            m.Clickable = true;
            m.Draggable = false;
            m.IconSize = new GoogleSize(30, 30);
            switch (inc.IncidentType)
            {
                case Utils.Enumerations.IncidentTypes.Fire:
                    m.IconUrl = Constants.ImgFire2; 
                    break;
                case Utils.Enumerations.IncidentTypes.CollapsedBuilding:
                    break;
                case Utils.Enumerations.IncidentTypes.Bomb:
                    m.IconUrl = Constants.ImgBomb1; 
                    break;
                case Utils.Enumerations.IncidentTypes.Accident:
                    m.IconUrl = Constants.ImgAccident1; 
                    break;
                default:
                    break;
            }
            Response.Write(inc.IncidentType.ToString()); 
            m.Latitude = Utils.Convert.ToDouble(inc.LocationCoordinates[0],0);
            m.Longitude = Utils.Convert.ToDouble(inc.LocationCoordinates[1],0);

            m.Text = inc.ShortDescription+"nnn<b>aaaa</b>";
            m.Bouncy = true;
            m.Title = inc.ShortDescription ;
            m.Show();
            
            GoogleMap1.Markers.Add(m);
        }
        base.OnPreRender(e);
    }


    public System.Data.Objects.DataClasses.EntityCollection<DAL.Incident> Incidents
    {
        get
        {
            var incs = Session["incidents"] as System.Data.Objects.DataClasses.EntityCollection<DAL.Incident>;
            if (incs==null)
            {
                return new System.Data.Objects.DataClasses.EntityCollection<DAL.Incident>();
            }
            return incs;
        }
        set
        {
            Session["incidents"] = value;
        }
    }

    public Unit Width
    {
        get
        {
            if (ViewState["mapWidth"]==null)
            {
                ViewState["mapWidth"] = new Unit(300);
            }

            return (int)ViewState["mapWidth"];
        }
        set
        {
            ViewState["mapWidth"] = value;
            GoogleMap1.Width = value;
        }
    }

    public Unit Heigth
    {
        get
        {
            if (ViewState["mapHeigth"]==null)
            {
                ViewState["mapHeigth"] = new Unit(300); ;
            }

            return (int)ViewState["mapHeigth"];
        }
        set
        {
            ViewState["mapHeigth"] = value;
            GoogleMap1.Height = value;
        }
    }

    public MapModes MapMode
    {
        get
        {
            if (ViewState["mapmode"]==null)
            {
                ViewState["mapmode"] = MapModes.DefineCrisis;
            }

            return (MapModes)ViewState["mapmode"];
        }
        set
        {
            ViewState["mapmode"] = value;
        }
    }
    protected void GoogleMap1_Click(object sender, Artem.Web.UI.Controls.GoogleLocationEventArgs e)
    {
        Label1.Text = string.Format("lat:{0}, lon:{1}", e.Location.Latitude, e.Location.Longitude);
        
        if (e.Location.Longitude==0 || e.Location.Latitude==0)
        {
            return ;
        }

        if (MapMode==MapModes.DefineCrisis)
        {
            GoogleCirclePolygon area = new GoogleCirclePolygon();
            area.Latitude = e.Location.Latitude;
            area.Longitude = e.Location.Longitude;
            area.FillColor = Color.Blue;
            area.FillOpacity = 0.3F;
            area.Radius = 20;
            //area.EnableDrawing=true;
            //area.EnableEditing=true;
            
            area.IsClickable=true;
            GoogleMap1.Polygons.Add(area);
        }
        //GoogleMap1.Markers.Add(new Artem.Web.UI.Controls.GoogleMarker()
        //    {
        //        Latitude = e.Location.Latitude,
        //        Longitude = e.Location.Longitude,
        //        Draggable=true,
        //        Text = "this is textt"
        //    }
        //);
    }
    protected void GoogleMap1_ZoomEnd(object sender, GoogleZoomEventArgs e)
    {
        if (GoogleMap1.Polygons.Count >0)
        {
            var gc = GoogleMap1.Polygons[0] as GoogleCirclePolygon;
            if (gc!=null)
            {
                gc.Radius = e.NewLevel*10;
            }
        }
    }
     
}