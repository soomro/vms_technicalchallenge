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
    /// Persisted to the application
    /// </summary>
    public static DAL.Crisis MainCrisis
    {
        get
        {
            return HttpContext.Current.Application[Constants.IdMainCrisis] as DAL.Crisis;
        }
        set
        {
            HttpContext.Current.Application[Constants.IdMainCrisis] = value;
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
            return Session["currentuser"] as Manager;
        }
        set
        {
            Session["currentuser"] = value;
        }
    }
}

