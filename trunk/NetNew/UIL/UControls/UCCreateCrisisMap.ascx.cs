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

public partial class UC_UCCreateCrisisMap : System.Web.UI.UserControl
{
    public bool Enabled
    {
        get
        {
            return GoogleMap1.Enabled;
        }
        set { GoogleMap1.Enabled = value; }
    }
    protected override void OnPreRender(EventArgs e)
    {
        GoogleMap1.Polygons.Clear();

        if (CrisisArea!=null)
        {            
            GoogleMap1.Polygons.Add(CrisisArea);
            GoogleMap1.Latitude = CrisisArea.Latitude;
            GoogleMap1.Longitude = CrisisArea.Longitude;
            Label1.Text = string.Format("lat:{0}, lon:{1}", CrisisArea.Latitude, CrisisArea.Longitude);

        }
        base.OnPreRender(e);
    }
     

    public GoogleCirclePolygon CrisisArea
    {
        get
        {
            return Session[Constants.IdCrisisArea] as GoogleCirclePolygon;
        }
        set
        {
            Session[Constants.IdCrisisArea] = value;
        }
    } 

    public double Radious
    {
        get
        {
            double r = 0;
            var res = double.TryParse(ViewState["Radious"]+"", out r);
            if (res) return r;
            else return 20;
        }
        set
        {
            ViewState["Radious"]=value;
            if (CrisisArea!=null)
            {
                CrisisArea.Radius = value;
            }
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
        
        if (e.Location.Longitude==0 || e.Location.Latitude==0)
        {
            return;
        }


        GoogleCirclePolygon area = GetDefaultCirclePolygon(e.Location.Latitude,e.Location.Longitude,Radious);

        CrisisArea = area;
         
    }

    public static GoogleCirclePolygon GetDefaultCirclePolygon(double latitude, double longitude, double radious)
    {
        GoogleCirclePolygon area = new GoogleCirclePolygon();
        area.Latitude = latitude;
        area.Longitude = longitude;
        area.FillColor = Color.Blue;
        area.FillOpacity = 0.3F;
        area.Radius = radious;

        area.IsClickable=true;
        return area;
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