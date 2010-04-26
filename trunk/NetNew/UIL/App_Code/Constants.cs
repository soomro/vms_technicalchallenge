using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
//    public const string APPROOT = System.IO.Path.Combine(HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Authority),
//HttpContext.Current.Request.ApplicationPath.TrimEnd(new char[] { '/' }));

    //Global IDs will begin with "Id" in begining
    public const string IdAction = "Action";
    public const string IdMainCrisis = "MainCrisis";
    public const string IdCrisisArea = "CrisisArea";
    public const string IdUserName = "UserName";
    public const string IdUserType = "IdUserType";
    public const string IdIncidentId = "iid";
    //Constants for pages will begin with "Page" in identifier
    public const string PageCrisisBoard = "CrisisBoard.aspx";
    public const string PageCrisis = "Crisis.aspx";
    public const string PageVolunteerProfile = "VolReg.aspx";
    public const string PageManagerProfile = "Manreg.aspx";
    public const string PageIncident = "Incident.aspx";
    public const string PageLogin = "Login.aspx";

    public const string ImgFire1 = "~/Images/fire1.gif";
    public const string ImgFire2 = "~/Images/fire2.gif";

    public const string ImgBomb1 = "~/Images/bomb1.gif";

    public const string ImgAccident1 = "~/Images/accident1.gif";

}