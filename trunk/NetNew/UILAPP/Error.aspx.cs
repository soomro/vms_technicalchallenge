using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Utils;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorInfo einf = Session[Constants.Error] as ErrorInfo;
        if (einf != null)
        { 
            if (einf.ErType == ErrorType.Authentication)
            {
                Response.Redirect("~/Login.aspx", true);
                return;// aslında gerek yok buna.
            }
            
            //Session[SKeys.ReturnUrl] = einf.ReturnUrl;

            mesaj.Text = einf.ErrorMessage;
            if (einf.Exception != null)
            {
                mesaj.Text += "<br />" + einf.Exception.Message;
                mesaj.Text += "<br />" + einf.Exception.StackTrace;
                if (einf.Exception.InnerException != null)
                {
                    mesaj.Text += "<br /><br />Inner Exception:" + einf.Exception.InnerException.Message;
                    mesaj.Text += "<br />" + einf.Exception.InnerException.StackTrace;
                }
            }
                HyperLink1.NavigateUrl = einf.ReturnUrl; ;
                HyperLink1.Visible = true;
                HyperLink1.Text = "Click here to go back to your previous page.";
            
        }
    }
}
