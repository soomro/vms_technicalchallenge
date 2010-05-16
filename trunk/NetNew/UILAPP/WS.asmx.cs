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
        [WebMethod(Description = "Validates the username and password and returns true if it is correct.")]
        public bool Login(string username, string password)
        {
            Log.WSLogger.Info("Login Callsed. Username:{0}, Password:{1}", username, password);

            Volunteer q =
                DAL.Container.WSInstance.Volunteers.SingleOrDefault(
                    v => v.Username == username && v.Password == password);
            if (q == null)
            {
                Log.WSLogger.Info("Login returned false");
                return false;
            }
            else
            {
                Log.WSLogger.Info("Login returned true");
                return true;
            }
        }

        [WebMethod]
        public string CheckUpdate(string username, string password, float lat, float lon)
        {
            Log.WSLogger.Info("username:{0}, password={1}, lat:{2}, lon:{3}", username, password, lat, lon);

            const char sep = Collection.SeparatorChar;

            string res = "";
            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
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
            DAL.Container.WSInstance.SaveChanges();
            return res;
        }

        [WebMethod(Description = "Returns the request information of requestresponseid")]
        public string GetRequest(string requestresponseID, string username, string password, out string msg)
        {
            Log.WSLogger.Info("username:{0}, password={1}, requestresponseID:{2} ", username, password,
                              requestresponseID);

            char sep = Collection.SeparatorChar;

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect.";
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
                double amSupp = nSupplied.SuppliedAmount;

                res += sep + ni.ItemType + sep + ni.MetricType + sep + (ni.ItemAmount - ni.SuppliedAmount)
                       + sep + amSupp;
            }
            msg = "";
            return res + sep;
        }

        [WebMethod]
        public bool RespondToRequest(string requestresponseID, string username, string password, string amountProvided,
                                     out string msg)
        {
            amountProvided = amountProvided.Replace("??", ((char) 254) + "");

            Log.WSLogger.Info("username:{0}, password={1}, requestresponseID:{2},amountProvided:{3} ", username,
                              password, requestresponseID, amountProvided);

            char sep = Collection.SeparatorChar;

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                return false;
            }
            int reqId = Convert.ToInt(requestresponseID, 0);

            RequestRespons requestres = (from r in DAL.Container.WSInstance.RequestResponses
                                         where r.Volunteer_Id == vol.Id && r.Id == reqId
                                         select r).SingleOrDefault();

            if (requestres == null)
            {
                msg = "Request cannot be found";
                return false;
            }

            requestres.DateResponded = DateTime.Now;

            bool accepted = false;
            string[] parts = amountProvided.Split(new[] {sep}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i += 2)
            {
                string itype = parts[i];
                string iamount = parts[i + 1];
                NeedItem ni = requestres.Request.NeedItems.SingleOrDefault(n => n.ItemType == itype);
                if (ni != null)
                {
                    // we are sure that itype is requested. now add a new needitem record to save the supp amount.

                    ni.SuppliedAmount = Convert.ToDouble(iamount, 0);
                    if (ni.SuppliedAmount > 0)
                    {
                        accepted = true; // if any need is supplied then it means it is accepted.
                        NeedItem dubCheckobj = (from niDub in requestres.NeedItems
                                                where niDub.ItemType == itype
                                                select niDub).FirstOrDefault();
                        if (dubCheckobj != null)
                            dubCheckobj.SuppliedAmount = Convert.ToDouble(iamount, dubCheckobj.SuppliedAmount);
                        else
                        {
                            requestres.NeedItems.Add(new NeedItem
                                                         {
                                                             SuppliedAmount = Convert.ToDouble(iamount, 0),
                                                             ItemType = itype,
                                                             MetricType = ni.MetricType
                                                         });
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
            Log.WSLogger.Info("username:{0}, password={1}, alertID:{2}  ", username, password, alertID);

            int aid = Convert.ToInt(alertID, 0);
            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                return "";
                ;
            }

            AlertsVolunteer alert = (from a in DAL.Container.WSInstance.AlertsVolunteers
                                     where a.Id == aid
                                     select a).SingleOrDefault();
            if (alert == null)
            {
                msg = "Alert can not be found";
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

            char sep = Collection.SeparatorChar;

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                Log.WSLogger.Error(msg);
                return;
            }
            int rrId = Convert.ToInt(requestresponseID, 0);

            Request request = (from r in DAL.Container.WSInstance.RequestResponses
                               where r.Volunteer_Id == vol.Id && r.Id == rrId
                               select r.Request).SingleOrDefault();

            if (request == null)
            {
                msg = "Request could not be found";
                Log.WSLogger.Error(msg);
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
                pr.IncidentStatus = (IncidentStatuses) status;
            }
            catch (Exception)
            {
                msg = "Status value is wrong";
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
            }
        }

        [WebMethod(Description = "Used to report new incidents")]
        public void IncidentReport(string message, string location, int typeOfIncident, string username, string password,
                                   out string msg)
        {
            Log.WSLogger.Trace("Progress Report: username:{0}, password={1}, location:{2}, message:{3} ", username,
                               password, location, message);

            char sep = Collection.SeparatorChar;

            Volunteer vol = (from v in DAL.Container.WSInstance.Volunteers
                             where v.Username == username && v.Password == password
                             select v).SingleOrDefault();
            if (vol == null)
            {
                msg = "Username or password is incorrect";
                Log.WSLogger.Error(msg);
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
                ir.IncidentType = (IncidentTypes) typeOfIncident;
            }
            catch (Exception)
            {
                msg = "Incident type value is wrong";
                return;
            }
            ir.LocationCoordinatesStr = "";

            DAL.Container.Instance.SaveChanges();

            msg = "";
        }
    }
}