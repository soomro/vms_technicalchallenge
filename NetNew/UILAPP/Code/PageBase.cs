using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using DAL;
using Utils;
using Utils.Enumerations;
using Utils.Exceptions;
using Convert = Utils.Convert;

/// <summary>
/// The base class for all of the pages. Contains common attributes and methods.
/// </summary>
public class PageBase : Page
{
    /// <summary>
    /// The action for the page defined in the url.
    /// </summary>
    public PageActions PageAction
    {
        get
        {
            PageActions robj = PageActions.None;
            string paction = Request[Constants.IdAction];
            if (paction == null)
            {
                return PageActions.None;
            }

            Enum.TryParse(paction, out robj);
            return robj;
        }
    }

    /// <summary>
    /// The active crisis is get bu this property.
    /// If there is no active crisis, an exception is thrown.
    /// Only the id of the active crisis is stored in the session for further calls.
    /// </summary>
    public DAL.Crisis MainCrisis
    {
        get
        {
            if (!HttpContext.Current.Items.Contains(Constants.IdMainCrisis))
            {
                DAL.Crisis obj = (from cr in Container.Instance.Crises
                                  where cr.StatusVal == (short) CrisisStatuses.Active
                                  select cr).FirstOrDefault();
                if (obj != null)
                    HttpContext.Current.Items.Add(Constants.IdMainCrisis, obj);
            }

            var m = HttpContext.Current.Items[Constants.IdMainCrisis] as DAL.Crisis;
     

            return m;
        }
        set { HttpContext.Current.Items[Constants.IdMainCrisis] = value; }
    }

    public Manager CurrentManager
    {
        get
        {
            int id = Convert.ToInt(Session["CurrentManager"] + "", 0);
            return (from v in Container.Instance.Managers
                    where v.Id == id
                    select v).FirstOrDefault();
        }
        set
        {
            if (value != null)
                Session["CurrentManager"] = value.Id;
            else
                Session["CurrentManager"] = 0;
        }
    }

    public Volunteer CurrentVolunteer
    {
        get
        {
            int id = Convert.ToInt(Session["CurrentVolunteer"] + "", 0);
            return (from v in Container.Instance.Volunteers
                    where v.Id == id
                    select v).FirstOrDefault();
        }
        set
        {
            if (value != null)
                Session["CurrentVolunteer"] = value.Id;
            else
                Session["CurrentVolunteer"] = 0;
        }
    }

    ///// <summary>
    ///// The logger for web pages.
    ///// </summary>
    //public Logger Logger
    //{
    //    get { return LogManager.GetLogger("WEB"); }
    //}

    /// <summary>
    /// If the user is not logged in as manager, this methods forwards the user to the login page.
    /// </summary>
    protected void RequireManager()
    {
        if (CurrentManager == null || !CurrentManager.Approved.HasValue || CurrentManager.Approved==false)
        {
            Utils.Log.WEBLogger.Info("Authentication failed. Navigating to the login...");
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
    }

    /// <summary>
    /// Used to redirect the user to the specified url after specified amount of seconds.
    /// </summary>
    public void RedirectAfter(int second, string url)
    {
        if (url == null)
        {
            Log.WEBLogger.Error("RedirectAfter method is called with null url");
            return;
        }
        if (second < 0 || second > 600)
        {
            Log.WEBLogger.Error("RedirectAfter method is called with invalid time value:" + second);
            return;
        }
        string js = string.Format(
            "<SCRIPT LANGUAGE=\"JavaScript\">"
            // + " function redireccionar() {"
            + "     setTimeout(\"location.href='{0}'\", {1});"
            + "  </SCRIPT>"
            , url, second*1000);
        ClientScript.RegisterStartupScript(typeof (string), Guid.NewGuid().ToString(), js);
    }
}