using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Web.UI.Controls;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public partial class UControls_UCIncidentMap : System.Web.UI.UserControl
{
     
    protected override void OnPreRender(EventArgs e)
    {
        GoogleMap1.Polygons.Clear();
        GoogleMap1.Markers.Clear();

        if (Incident!=null)
        {
            GoogleMap1.Markers.Add(Incident);
            GoogleMap1.Latitude = Incident.Latitude;
            GoogleMap1.Longitude = Incident.Longitude;
        }
        base.OnPreRender(e);
    }
     

    public GoogleMarker Incident
    {
        get
        {
            return Session["_Incident"] as GoogleMarker;
        }
        set
        {
            Session["_Incident"] = value;
        }
    } 
     
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

     
    protected void GoogleMap1_Click(object sender, Artem.Web.UI.Controls.GoogleLocationEventArgs e)
    {
        Label1.Text = string.Format("lat:{0}, lon:{1}", e.Location.Latitude, e.Location.Longitude);

        if (e.Location.Longitude==0 || e.Location.Latitude==0)
        {
            return;
        }
         
        GoogleMarker inc = new GoogleMarker(e.Location.Latitude, e.Location.Longitude);
        inc.Clickable=false;
        inc.Draggable = true;
        Incident = inc;

        var name = Utils.GeoUtil.GetAddressName(e.Location.Latitude+"", e.Location.Longitude+"");
        HttpContext.Current.Items["adrName"] = name;
    }
     

     
}