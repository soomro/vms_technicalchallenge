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
    public string CheckUpdate(string usename, string guid)
    {
        return "R?0001:Help needed#A?1101:Run away";
    }

}


