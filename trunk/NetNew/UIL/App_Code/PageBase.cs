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
                var obj = (from cr in DAL.Container.Instance.Crises
                                                                  where cr.StatusVal == (short)Utils.Enumerations.CrisisStatuses.Active
                                                                  select cr).FirstOrDefault();
                if (obj != null)
                    System.Web.HttpContext.Current.Items.Add(Constants.IdMainCrisis, obj);
            }

            return System.Web.HttpContext.Current.Items[Constants.IdMainCrisis] as DAL.Crisis;


        }
        set
        {
            System.Web.HttpContext.Current.Items[Constants.IdMainCrisis] = value;
        }
    }

    public Manager CurrentUser
    {
        get
        {
            int id = Utils.Convert.ToInt(Session["currentuser"] + "", 0);
            return (from v in DAL.Container.Instance.Managers
                    where v.Id == id
                    select v).FirstOrDefault();
        }
        set
        {
            if(value != null )
                Session["currentuser"] = value.Id;
        }
    }
    public Volunteer CurrentVolunteer
    {
        get
        {
            int id = Utils.Convert.ToInt(Session["CurrentVolunteer"] + "", 0);
            return (from v in DAL.Container.Instance.Volunteers
                    where v.Id == id
                    select v).FirstOrDefault();
        }
        set
        {
            if (value != null)
                Session["CurrentVolunteer"] = value.Id;
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

