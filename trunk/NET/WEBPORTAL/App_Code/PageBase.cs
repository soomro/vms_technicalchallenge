using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            EnumPageAction robj = EnumPageAction.View;
            var paction = Request["action"];
            if (Enum.TryParse(paction, out robj))
                return robj;
            else return EnumPageAction.View;
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

}

