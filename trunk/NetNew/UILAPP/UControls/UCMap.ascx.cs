using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using System.Drawing;
using DAL;

public partial class UCMap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set default location 57.7070820644457, lon:11.9915771484375 

            GoogleMap1.Latitude= 57.7070820644457f;;
            GoogleMap1.Longitude = 11.9915771484375f;
            GoogleMap1.Zoom = 8;

        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        GoogleMap1.Markers.Clear();
        foreach (var m in Incidents.Select(BuildMarker))
        {
            GoogleMap1.Markers.Add(m);
        }

        GoogleMap1.Latitude= Latitude; ;
        GoogleMap1.Longitude = Longitude;

        base.OnPreRender(e);
    }

    public double Latitude
    {
        get
        {
            var lat = Utils.Convert.ToDouble(ViewState["Latitude"]+"", 57.7070820644457);
            return lat;
        }
        set
        {
            ViewState["Latitude"] = value;
        }
    } 
  
    public double Longitude
    {
        get
        {
            var lon = Utils.Convert.ToDouble(ViewState["Longitude"]+"", 11.9915771484375);
            return lon;
        }
        set
        {
            ViewState["Longitude"] = value;
            GoogleMap1.Longitude = value;
        }
    } 

    private GoogleMarker BuildMarker(DAL.Incident inc)
    {
        GoogleMarker m = new GoogleMarker();
        m.Clickable = true;
        m.Draggable = false;
        m.IconSize = new GoogleSize(30, 30);
        
        string iconName = inc.IncidentType.ToString();
        iconName += ""+ //((short)inc.Severity)+
            "_";

        if (inc.Severity==Utils.Enumerations.Severities.Low)
            m.IconSize = new GoogleSize(20, 20);
        if (inc.Severity==Utils.Enumerations.Severities.Medium)
            m.IconSize = new GoogleSize(28, 28);
        if (inc.Severity==Utils.Enumerations.Severities.High)
            m.IconSize = new GoogleSize(35, 35);
        if (inc.Severity==Utils.Enumerations.Severities.Critical)
            m.IconSize = new GoogleSize(43, 43);



        if (inc.IncidentStatus==Utils.Enumerations.IncidentStatuses.Complete)
            iconName += "completed";
        if (inc.IncidentStatus==Utils.Enumerations.IncidentStatuses.Created)
            iconName += "created";
        if (inc.IncidentStatus==Utils.Enumerations.IncidentStatuses.ResourceGathering)
            iconName += "resource";
        if (inc.IncidentStatus==Utils.Enumerations.IncidentStatuses.Working)
            iconName += "working";
        iconName+=".gif";
        iconName = iconName.ToLower();


        //Response.Write(iconName+"  ");
        m.IconUrl = "~/images/"+iconName;

        m.Latitude = Utils.Convert.ToDouble(inc.LocationCoordinates[0], 0);
        m.Longitude = Utils.Convert.ToDouble(inc.LocationCoordinates[1], 0);
        var incInfo  = incContent.Replace("[INCTYPE]", Utils.Reflection.GetEnumDescription(inc.IncidentType));
        incInfo  = incInfo.Replace("[INCTITLE]", inc.ShortDescription);

        incInfo  = incInfo.Replace("[INCSEVERITY]", inc.Severity.ToString());
        var style = "";
        if (inc.Severity == Utils.Enumerations.Severities.Critical) style = "opacity:1; filter:alpha(opacity=100); background-color: #FF0000; color: #FFFFFF;padding: 5px;";
        if (inc.Severity == Utils.Enumerations.Severities.High) style = "opacity:0.8; filter:alpha(opacity=80); background-color: #FF0000; color: #FFFFFF;padding: 5px;";
        if (inc.Severity == Utils.Enumerations.Severities.Medium) style = "opacity:0.6; filter:alpha(opacity=70); background-color: #FF0000; color: #FFFFFF;padding: 5px;";
        if (inc.Severity == Utils.Enumerations.Severities.Low) style = "opacity:0.4; filter:alpha(opacity=40); background-color: #FF0000; color: #FFFFFF;padding: 5px;";

        incInfo = incInfo.Replace("[sevTypeStyle]", style);

        incInfo  = incInfo.Replace("[INCSTATUS]", inc.IncidentStatus.ToString());
        
        incInfo  = incInfo.Replace("[EDITURL]", 
            string.Format(Request.ApplicationPath+"/Incident.aspx?{0}={1}&iid={2}",Constants.IdAction,PageActions.Edit.ToString(),inc.Id)
            );
        incInfo = incInfo.Replace("[RESURL]",
            string.Format(Request.ApplicationPath + "/ResourceGathering.aspx?iid={0}", inc.Id)
            );
        incInfo = incInfo.Replace("[REPORTSURL]",
            string.Format(Request.ApplicationPath + "/ProgressReports.aspx?iid={0}", inc.Id)
            );
        incInfo = incInfo.Replace("[IMG]",ResolveUrl( m.IconUrl));

        m.Text = incInfo;
        m.Bouncy = true;
        m.Title = inc.ShortDescription;
 
        m.Show();
        return m;
    }

    string incContent = @"<div class='dvIncInfo' width='250px'>
         <img src='[IMG]' width='25px' heigth='25px' /><span class='header'> [INCTITLE]</span>
        <table class='gmapincInfo' >
            <tr>
                <td>Severity-Type: </td> <td  style='[sevTypeStyle]' >[INCSEVERITY]-[INCTYPE]</td>
            </tr>
            <tr >
                <td>Status:</td> <td> [INCSTATUS]</td>
            </tr>
        </table>
        <table class='menu'>
            <tr>
                <td><a href='[RESURL]'>Resource<br /> Gathering</a></td> 
                <td><a href='[EDITURL]'>Edit Incident</a><br />
                    <a href='[REPORTSURL]'>Progress Reports</a>    </td>
            </tr>
             
        </table>
    </div>
    ";

    public List<DAL.Incident> Incidents
    {
        get
        {
            var incs = Session["incidents"] as List<DAL.Incident>;
            if (incs==null)
            {
                return new List<DAL.Incident>();
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