using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase : System.Web.UI.Page
{
    public PageBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public PageActions PageAction
    {
        get
        {
            PageActions robj = PageActions.None;
            var paction = Request[Constants.IdAction];
            if (paction==null)
            {
                return PageActions.None;
            }
            //paction = paction.ToLower();
            Enum.TryParse(paction, out robj);
            return robj;
        }
    }

    public void RedirectAfter(int second, string url)
    {
        string js=string.Format(
            "<SCRIPT LANGUAGE=\"JavaScript\">"
           // + " function redireccionar() {"
            + "     setTimeout(\"location.href='{0}'\", {1});"
            + "  </SCRIPT>"
            ,url,second*1000);
        ClientScript.RegisterStartupScript(typeof(string),Guid.NewGuid().ToString(), js);
        
    }

    /// <summary>
    /// Persisted to the session.
    /// The reason for storing in session is: EF container can only work with object that are retrieved by same object.
    /// That means: the crisis object that retrieved by one container instance can not be updated by another container instance.
    /// So both the container and crisis should have same lifetime.
    /// </summary>
    public static DAL.Crisis MainCrisis
    {
        get
        {
            var c = HttpContext.Current.Session[Constants.IdMainCrisis] as DAL.Crisis;
#if DEBUG
            //if (c==null)
            //    c =   Container.Instance.Crises.SingleOrDefault(cr => cr.Id == 46);
#endif
            return c;
 
        }
        set
        {
            HttpContext.Current.Session[Constants.IdMainCrisis] = value;
        }
    }

    public Manager CurrentUser
    {
        get
        {
            return Session["currentuser"] as Manager;
        }
        set
        {
            Session["currentuser"] = value;
        }
    }
    public Volunteer CurrentVolunteer
    {
        get
        {
            return Session["CurrentVolunteer"] as Volunteer;
        }
        set
        {
            Session["CurrentVolunteer"] = value;
        }
    }
}

