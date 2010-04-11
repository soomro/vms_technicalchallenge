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

    public PageAction PageAction
    {
        get
        {
            PageAction robj = PageAction.None;
            var paction = Request[Utils.Constants.GlobalIds.Action];
            if (Enum.TryParse(paction, out robj))
                return robj;
            else return PageAction.None;
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
            return HttpContext.Current.Application[Utils.Constants.GlobalIds.MainCrisis] as Crisis;
        }
        set
        {
            HttpContext.Current.Application[Utils.Constants.GlobalIds.MainCrisis] = value;
        }
    }

}

