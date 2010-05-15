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


     
    public DAL.Crisis MainCrisis
    {
        get
        {
            if ( ! System.Web.HttpContext.Current.Items.Contains(Constants.IdMainCrisis) )
            {
                //Mohsen: I couldn't find the reason for this line. Maybe should be removed in final version
                var obj = (from cr in DAL.Container.Instance.Crises
                                                                  where cr.StatusVal == (short)Utils.Enumerations.CrisisStatuses.Active
                                                                  select cr).FirstOrDefault();
                if (obj != null)
                    System.Web.HttpContext.Current.Items.Add(Constants.IdMainCrisis, obj);
            }

            return System.Web.HttpContext.Current.Session[Constants.IdMainCrisis] as DAL.Crisis;


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

    public NLog.Logger Logger
    {
        get
        {
            return NLog.LogManager.GetLogger("WEB");
        }
    }


}

