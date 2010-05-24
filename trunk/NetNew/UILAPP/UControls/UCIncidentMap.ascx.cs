using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using Utils;
using Convert = Utils.Convert;

public partial class UControls_UCIncidentMap : UserControl
{
    public bool Enabled
    {
        get { return GoogleMap1.Enabled; }
        set { GoogleMap1.Enabled = value; }
    }

    public bool ReadOnly
    {
        get
        {
            try
            {
                var r = (bool) ViewState["readonly"];
                return r;
            }
            catch (Exception ex)
            {
                return false;
            }

            
        }
        set
        {
            ViewState["readonly"] = value;
            if (value)
            {
                GoogleMap1.Click -= GoogleMap1_Click;
                GoogleMap1.EnableGoogleBar = false;
                GoogleMap1.EnableInfoWindow = false;
            }
            else
            {
                GoogleMap1.Click += GoogleMap1_Click;
            }
        }
    }

    public GoogleMarker Incident
    {
        get { return Session["_Incident"] as GoogleMarker; }
        set { Session["_Incident"] = value; }
    }

    public Unit Width
    {
        get
        {
            if (ViewState["mapWidth"] == null)
            {
                ViewState["mapWidth"] = new Unit(300);
            }

            return (int) ViewState["mapWidth"];
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
            if (ViewState["mapHeigth"] == null)
            {
                ViewState["mapHeigth"] = new Unit(300);
            }

            return (int) ViewState["mapHeigth"];
        }
        set
        {
            ViewState["mapHeigth"] = value;
            GoogleMap1.Height = value;
        }
    }

    public int Zoom
    {
        get { return Convert.ToInt(ViewState["Zoom"] + "", 8); }
        set
        {
            ViewState["Zoom"] = value;
            GoogleMap1.Zoom = value;
        }
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

    protected override void OnPreRender(EventArgs e)
    {
        GoogleMap1.Polygons.Clear();
        GoogleMap1.Markers.Clear();

        if (Incident != null)
        {
            GoogleMap1.Markers.Add(Incident);
            GoogleMap1.Latitude = Incident.Latitude;
            GoogleMap1.Longitude = Incident.Longitude;
            GoogleMap1.Zoom = Zoom;
        }
        else
        {
            GoogleMap1.Latitude = Latitude;
            GoogleMap1.Longitude = Longitude;
            GoogleMap1.Zoom = Zoom;
        }
        base.OnPreRender(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set default location 57.7070820644457, lon:11.9915771484375 

            GoogleMap1.Latitude = 57.7070820644457;
            GoogleMap1.Longitude = 11.9915771484375;
            //GoogleMap1.Zoom = 8;
        }
    }

    protected void GoogleMap1_Click(object sender, GoogleLocationEventArgs e)
    {
        Label1.Text = string.Format("lat:{0}, lon:{1}", e.Location.Latitude, e.Location.Longitude);

        if (e.Location.Longitude == 0 || e.Location.Latitude == 0)
        {
            return;
        }

        var inc = new GoogleMarker(e.Location.Latitude, e.Location.Longitude);
        inc.Clickable = false;
        inc.Draggable = true;
        Incident = inc;

        string name = GeoUtil.GetAddressName(e.Location.Latitude + "", e.Location.Longitude + "");
        
        ClickedLocationName = name;

        Zoom = GoogleMap1.Zoom;
    }
    public string ClickedLocationName
    {
        get
        {
            return hdLocationName.Value;
        }
        set
        {
            hdLocationName.Value = value;
        }
    }
}