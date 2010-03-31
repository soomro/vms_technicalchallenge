using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VMSCORE.EntityClasses;

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

    public EnumPageAction PageAction
    {
        get
        {
            EnumPageAction robj = EnumPageAction.None;
            var paction = Request["action"];
            if (Enum.TryParse(paction, out robj))
                return robj;
            else return EnumPageAction.None;
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
        ClientScript.RegisterStartupScript(typeof(string),"rd", js);
        
    }

    /// <summary>
    /// Persisted to the application
    /// </summary>
    public static Crisis MainCrisis
    {
        get
        {
            return HttpContext.Current.Application["MainCrisis"] as Crisis;
        }
        set
        {
            HttpContext.Current.Application["MainCrisis"] = value;
        }
    }

}

