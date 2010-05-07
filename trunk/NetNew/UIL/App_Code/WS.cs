using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WS : System.Web.Services.WebService
{

    public WS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public bool Login(string username, string password)
    {
        var q=DAL.Container.Instance.Volunteers.SingleOrDefault(v => v.Username == username && v.Password == password);
        if (q == null)
            return false;
        else
            return true;
    }

    [WebMethod]
    public string GetRequest(int requestID, string userID)
    {
        return string.Format("Dear {0}, here is your info request for {1}", userID, requestID);
    }

    [WebMethod]
    public string CheckUpdate(string username, string password, float lat, float lon)
    {
        char sep = Utils.Collection.SeparatorChar;

        var res = "";
         var vol = (from v in DAL.Container.Instance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
    	{
                return "";
    	}

        var rrs =( from rr in DAL.Container.Instance.RequestResponses
                  where rr.Volunteer_Id == vol.Id && 
                  rr.Request.IsActive && (rr.StatusVal == 0 || (rr.StatusVal==1 && rr.Answer==true) )                
                      select rr).Take(1).ToList();
        if (rrs.Count>0)
        {
            res = sep + "R" + sep + rrs[0].Request_Id + sep;
            rrs[0].DateShowed = DateTime.Now;
        }

        var alerts = (from av in DAL.Container.Instance.AlertsVolunteers
                     where av.Volunteer_Id == vol.Id && av.DateShowed == null
                     select av).Take(5).ToList();
        foreach (var alert in alerts)
        {
            res += "A" + sep + alert.Alert.Message + sep;
            alert.DateShowed = DateTime.Now;
        }
        DAL.Container.Instance.SaveChanges();
        return res;

    }
    [WebMethod]
    public string GetRequest(string requestresponseID, string username, string password)
    {
        char sep = Utils.Collection.SeparatorChar;

        var vol = (from v in DAL.Container.Instance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
        {
            return "";
        }

        var request = (from r in DAL.Container.Instance.RequestResponses
                       where r.Volunteer_Id == vol.Id && r.Id == Utils.Convert.ToInt(requestresponseID, 0)
                       select r.Request).SingleOrDefault();
        if (request==null)
        {
            return "";
        }

        var res = sep + request.Name + sep
            + request.Incident.ShortAddress + sep
            + request.Message ;

        foreach (DAL.NeedItem ni in request.NeedItems)
        {
            res += sep + ni.ItemType + sep + ni.MetricType + sep + (ni.ItemAmount-ni.SuppliedAmount);
        }
        return res + sep;

    }
}


