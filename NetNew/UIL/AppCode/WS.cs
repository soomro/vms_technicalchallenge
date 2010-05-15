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
     

    [WebMethod(Description="Validates the username and password and returns true if it is correct.")]
    public bool Login(string username, string password)
    {
        var q=DAL.Container.WSInstance.Volunteers.SingleOrDefault(v => v.Username == username && v.Password == password);
        if (q == null)
            return false;
        else
            return true;
    }
     
    [WebMethod]
    public string CheckUpdate(string username, string password, float lat, float lon)
    {
        char sep = Utils.Collection.SeparatorChar;

        var res = "";
         var vol = (from v in DAL.Container.WSInstance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
    	{
                return "";
    	}

        var rrs =( from rr in DAL.Container.WSInstance.RequestResponses
                  where rr.Volunteer_Id == vol.Id && 
                  rr.Request.IsActive && (rr.StatusVal == 0 || (rr.StatusVal==1 && rr.Answer==true) )                
                      select rr).Take(1).ToList();
        if (rrs.Count>0)
        {
            res = sep + "R" + sep + rrs[0].Request_Id + sep;
            rrs[0].DateShowed = DateTime.Now;
        }

        var alerts = (from av in DAL.Container.WSInstance.AlertsVolunteers
                     where av.Volunteer_Id == vol.Id && av.DateShowed == null
                     select av).Take(5).ToList();
        foreach (var alert in alerts)
        {
            res += "A" + sep + alert.Alert.Message + sep;
            alert.DateShowed = DateTime.Now;
        }
        DAL.Container.WSInstance.SaveChanges();
        return res;

    }

    [WebMethod(Description = "Returns the request information of requestresponseid")]
    public string GetRequest(string requestresponseID, string username, string password, out string msg)
    {
        char sep = Utils.Collection.SeparatorChar;

        var vol = (from v in DAL.Container.WSInstance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
        {
            msg = "Username or password is incorrect.";
            return "";
        }

        var request = (from r in DAL.Container.WSInstance.RequestResponses
                       where r.Volunteer_Id == vol.Id && r.Id == Utils.Convert.ToInt(requestresponseID, 0)
                       select r.Request).SingleOrDefault();
        if (request==null)
        {
            msg = "Request could not be found";
            return "";
        }

        var res = sep + request.Name + sep
            + request.Incident.ShortAddress + sep
            + request.Message ;

        foreach (DAL.NeedItem ni in request.NeedItems)
        {
            res += sep + ni.ItemType + sep + ni.MetricType + sep + (ni.ItemAmount-ni.SuppliedAmount);
        }
        msg = "";
        return res + sep;

    }

    [WebMethod]
    public bool RespondToRequest(string requestresponseID, string username, string password, string amountProvided,out string msg)
    { 
        char sep = Utils.Collection.SeparatorChar;

        var vol = (from v in DAL.Container.WSInstance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
        {
            msg = "Username or password is incorrect";
            return false;
        }
        int reqId = Utils.Convert.ToInt(requestresponseID, 0);

        var requestres = (from r in DAL.Container.WSInstance.RequestResponses
                       where r.Volunteer_Id == vol.Id && r.Id == reqId
                       select r).SingleOrDefault();

        if (requestres == null)
        {
            msg = "Request cannot be found";
            return false;
        }

        requestres.DateResponded = DateTime.Now;
        
        bool accepted = false;
        var parts = amountProvided.Split(new char[]{sep}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i+=2)
        {
            var itype = parts[i];
            var iamount = parts[i + 1];
            var ni = requestres.Request.NeedItems.SingleOrDefault(n => n.ItemType == itype);
            if (ni!=null)
            { // we are sure that itype is requested. now add a new needitem record to save the supp amount.

                ni.SuppliedAmount = Utils.Convert.ToDouble(iamount, 0);
                if (ni.SuppliedAmount > 0)
                {
                    accepted = true; // if any need is supplied then it means it is accepted.
                    var dubCheckobj = (from niDub in requestres.NeedItems
                                       where niDub.ItemType == itype
                                       select niDub).FirstOrDefault();
                    if (dubCheckobj != null) 
                        dubCheckobj.SuppliedAmount = Utils.Convert.ToDouble(iamount,dubCheckobj.SuppliedAmount);
                    else
                    {
                        requestres.NeedItems.Add(new DAL.NeedItem(){
                         SuppliedAmount=Utils.Convert.ToDouble(iamount,0), ItemType=itype, MetricType=ni.MetricType});
                        ni.ItemAmount += Utils.Convert.ToDouble(iamount, 0);
                    }
                }
            }
        } 
        requestres.Answer = accepted;
        requestres.DateResponded = DateTime.Now;

        DAL.Container.WSInstance.SaveChanges();
        msg = "";
        return true;
    }

    [WebMethod]
    public string GetAlert(string alertID, string username, string password, out string msg)
    {
        var aid = Utils.Convert.ToInt(alertID,0);
        var vol = (from v in DAL.Container.WSInstance.Volunteers
                   where v.Username == username && v.Password == password
                   select v).SingleOrDefault();
        if (vol == null)
        {
            msg = "Username or password is incorrect";
            return ""; ;
        }

        var alert = (from a in DAL.Container.WSInstance.AlertsVolunteers
                     where a.Id == aid
                     select a).SingleOrDefault();
        if (alert==null)
        {
            msg = "Alert can not be found";
            return "";
        }
        msg = "";
        return alert.Alert.Message;
    }

   
}


