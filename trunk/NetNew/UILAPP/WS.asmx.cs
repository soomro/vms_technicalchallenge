using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using DAL;
using Utils;
using Utils.Enumerations;
using Convert = Utils.Convert;

namespace UILAPP
{
    /// <summary>
    /// Summary description for WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS : WebService
    {
        char sep = Collection.SeparatorChar;

        [WebMethod(Description = "Validates the username and password and returns true if it is correct.")]
        public bool Login(string username, string password)
        {
            Log.WSLogger.Trace("Login: Username:{0}, Password:{1}", username, password);

            Volunteer q =
                DAL.Container.WSInstance.Volunteers.SingleOrDefault(
                    v => v.Username == username && v.Password == password);
            if (q == null)
            {
                Log.WSLogger.Trace("Login returned false");
                return false;
            }
            else
            {
                Log.WSLogger.Trace("Login returned true");
                return true;
            }
        }

        [WebMethod]
        public string CheckUpdate(string username, string password, float lat, float lon)
        {
            Log.WSLogger.Trace("Check Update: username:{0}, password={1}, lat:{2}, lon:{3}", username, password, lat, lon);

           
            string res = "";
            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                Log.WSLogger.Trace("Check Update:Volunteer can not be found.");
                return "";
            }

            vol.Coordinates.Clear();
            vol.Coordinates.Add(lat + "");
            vol.Coordinates.Add(lon + "");
            vol.CoordinateLastUpdateTime = DateTime.Now;

            RequestRespons rrs = (from rr in DAL.Container.WSInstance.RequestResponses
                                  where rr.Volunteer_Id == vol.Id &&
                                        rr.Request.IsActive &&
                                        (rr.StatusVal == 0 || (rr.StatusVal == 1 && rr.Answer == true))
                                  select rr).FirstOrDefault();
            if (rrs != null)
            {
                res = sep + "R" + sep + rrs.Id + sep + rrs.Request.Incident.ShortDescription + sep;
                rrs.DateShowed = DateTime.Now;
            }

            List<AlertsVolunteer> alerts = (from av in DAL.Container.WSInstance.AlertsVolunteers
                                            where av.Volunteer_Id == vol.Id && av.DateShowed == null
                                            select av).Take(5).ToList();
            foreach (AlertsVolunteer alert in alerts)
            {
                res += "A" + sep + alert.Id + sep + alert.Alert.Message + sep;
                alert.DateShowed = DateTime.Now;
            }
            vol.LastAccessTime = DateTime.Now;

            DAL.Container.WSInstance.SaveChanges();
            return res;
        }

        [WebMethod(Description = "Returns the request information of requestresponseid")]
        public string GetRequest(string requestresponseID, string username, string password, out string msg)
        {
            //try
            //{
            Log.WSLogger.Trace("username:{0}, password={1}, requestresponseID:{2} ", username, password,
                                 requestresponseID);

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect.";
                Log.WSLogger.Error("Get Request: "+msg);
                return "";
            }
            int reqidd = Convert.ToInt(requestresponseID, 0);
            RequestRespons rr = (from r in DAL.Container.WSInstance.RequestResponses
                                 where r.Volunteer_Id == vol.Id && r.Id == reqidd
                                 select r).SingleOrDefault();
            Request request = rr.Request;

            if (request == null)
            {
                msg = "Request could not be found";
                Log.WSLogger.Error("Get Request: "+msg);
                return "";
            }

            string res = sep + request.Name + sep
                         + request.Incident.ShortAddress + sep
                         + request.Message;

            foreach (NeedItem ni in request.NeedItems)
            {
                NeedItem nSupplied = (from n in DAL.Container.Instance.NeedItems
                                      where n.RequestResponseId == rr.Id && n.ItemType == ni.ItemType
                                      select n).FirstOrDefault();
                double amSupp = 0;
                if (nSupplied!=null)
                    amSupp  = nSupplied.SuppliedAmount;

                res += sep + ni.ItemType + sep + ni.MetricType + sep + (ni.ItemAmount - ni.SuppliedAmount)
                       + sep + amSupp;
            }
            msg = "";
            return res + sep;
            //  }
            //catch (Exception ex)
            //{
            //    Utils.Log.WSLogger.ErrorException("Get request throwed exception:"+ex.InnerException!=null?ex.InnerException.Message:"",ex);
            //    throw;
            //}
        }

        [WebMethod]
        public bool RespondToRequest(string requestresponseID, string username, string password, string amountProvided,
                                     out string msg)
        {
            amountProvided = amountProvided.Replace("??", ((char)254) + "");
            amountProvided = amountProvided.Replace("?", ((char)254) + "");

            Log.WSLogger.Trace("RespondToRequest: username:{0}, password={1}, requestresponseID:{2},amountProvided:{3} ", username,
                              password, requestresponseID, amountProvided);


            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();


            if (vol == null)
            { 
                msg = "Username or password is incorrect";
                Log.WSLogger.Error("RespondToRequest:"+msg);
                return false;
            } 
            int reqId = Convert.ToInt(requestresponseID, 0); 

            RequestRespons requestres = (from r in DAL.Container.WSInstance.RequestResponses
                                         where r.Volunteer_Id == vol.Id && r.Id == reqId
                                         select r).SingleOrDefault();
    
            if (requestres == null)
            { 
                msg = "Request cannot be found"+ reqId;
                Log.WSLogger.Error("RespondToRequest:"+msg);
                return false;
            } 
            requestres.DateResponded = DateTime.Now;
            requestres.Status =  RequestResponseStatuses.Responded; 
            bool accepted = false;
            string[] parts = amountProvided.Split(new[] { sep }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i += 2)
            { 
                string itype = parts[i];
                string iamount = parts[i + 1];
                
                NeedItem ni = requestres.Request.NeedItems.SingleOrDefault(n => n.ItemType == itype);
    
                if (ni != null)
                {
                    // we are sure that itype is requested. now add a new needitem record to save the supp amount.
                    
                    var supAm = Utils.Convert.ToDouble(iamount, 0);
                    // can only supply needed amount at most
                    supAm = ni.ItemAmount < supAm ? ni.ItemAmount : supAm;

                    if (supAm> 0)
                    {
            
                        accepted = true; // if any need is supplied then it means it is accepted.
                        NeedItem dubCheckobj = (from niDub in requestres.NeedItems
                                                where niDub.ItemType == itype
                                                select niDub).FirstOrDefault();
                        if (dubCheckobj != null)
                        { // updating previously accepted one
                            dubCheckobj.SuppliedAmount = supAm;
                        }
                        else
                        { 
                            requestres.NeedItems.Add(new NeedItem
                                                         {
                                                             SuppliedAmount =supAm,
                                                             ItemType = itype,
                                                             MetricType = ni.MetricType
                                                         });
                        } 
                    } 
                }
                else
                {
                    Log.WSLogger.Error("RespondToRequest: Request need item is not found");
                }
            } 

            requestres.Answer = accepted;
            requestres.DateResponded = DateTime.Now;
             

            DAL.Container.WSInstance.SaveChanges();
            Log.WSLogger.Trace("RespondToRequest succeed-> ReqId:{0}, Answer:{1},"
                , requestres.Request_Id, requestres.Answer);
            msg = "";
            return true;
        }

        [WebMethod]
        public string GetAlert(string alertID, string username, string password, out string msg)
        {
            Log.WSLogger.Info("GetAlert:username:{0}, password={1}, alertID:{2}  ", username, password, alertID);

            int aid = Convert.ToInt(alertID, 0);
            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                Log.WSLogger.Error("GetAlert: "+msg);
                return ""; 
            }

            AlertsVolunteer alert = (from a in DAL.Container.WSInstance.AlertsVolunteers
                                     where a.Id == aid
                                     select a).SingleOrDefault();
            if (alert == null)
            {
                msg = "Alert can not be found";
                Log.WSLogger.Error("GetAlert:" + msg);
                return "";
            }
            msg = "";
            return alert.Alert.Message;
        }

        [WebMethod(Description = "Used to report the progress of incidents")]
        public void ProgressReport(string requestresponseID, string message, int status, string username,
                                   string password, out string msg)
        {
            Log.WSLogger.Trace(
                "Progress Report: username:{0}, password={1}, requestresponseID:{2}, message:{3}, status:{4} ", username,
                password, requestresponseID, message, status);

            

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                Log.WSLogger.Error("ProgressReport:" + msg);
          
                return;
            }
            int rrId = Convert.ToInt(requestresponseID, 0);

            Request request = (from r in DAL.Container.WSInstance.RequestResponses
                               where r.Volunteer_Id == vol.Id && r.Id == rrId
                               select r.Request).SingleOrDefault();

            if (request == null)
            {
                msg = "Request could not be found";
                Log.WSLogger.Error("ProgressReport:" + msg);
                return;
            }
            ProgressReport pr = DAL.Container.Instance.ProgressReports.CreateObject();
            pr.ReportText = message;
            pr.DateSent = DateTime.Now;
            pr.ImageFile = "";
            pr.VideoFile = "";
            pr.Incident = request.Incident;
            try
            {
                pr.IncidentStatus = (IncidentStatuses)status;
            }
            catch (Exception)
            {
                msg = "Status value is wrong";
                Log.WSLogger.Error("ProgressReport:" + msg);
                return;
            }
            pr.Volunteer = vol;


            msg = "";

            try
            {
                DAL.Container.Instance.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message + ":" + ex.InnerException.Message;
                Log.WSLogger.Error("ProgressReport:" + msg);
            }
        }

        [WebMethod(Description = "Used to report new incidents")]
        public void IncidentReport(string message, string location, int typeOfIncident, string username, string password,
                                   out string msg)
        {
            Log.WSLogger.Trace("Incident Report: username:{0}, password={1}, location:{2}, message:{3} ", username,
                               password, location, message);
            
            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                Log.WSLogger.Error("IncidentReport:" + msg);
                return;
            }

            IncidentReport ir = DAL.Container.Instance.IncidentReports.CreateObject();

            ir.Description = message;
            ir.ImageFile = "";
            ir.VideoFile = "";
            ir.Location = location;
            ir.VideoFile = "";
            ir.Volunteer = vol;
            ir.ReportDate = DateTime.Now;
            ir.Crisis = (from cr in DAL.Container.Instance.Crises
                         where cr.StatusVal == (short)CrisisStatuses.Active
                         select cr).FirstOrDefault();
            ir.ReportDate = DateTime.Now;

            try
            {
                ir.IncidentType = (IncidentTypes)typeOfIncident;
            }
            catch (Exception)
            {
                msg = "Incident type value is wrong";
                Log.WSLogger.Error("IncidentReport:" + msg);
                return;
            }
            ir.LocationCoordinatesStr = "";

            DAL.Container.Instance.SaveChanges();

            msg = "";
        }

        [WebMethod]
        public string CheckUpdateTest()
        {
            return CheckUpdate("aaa", "aaa", 0, 0);
        }
    }
}