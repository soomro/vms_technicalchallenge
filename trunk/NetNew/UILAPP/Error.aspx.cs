using System;
using System.Web.UI;
using Utils;

public partial class Error : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var einf = Session[Constants.Error] as ErrorInfo;
        if (einf != null)
        {
            if (einf.ErType == ErrorType.Authentication)
            {
                Response.Redirect("~/Login.aspx", true);
                return; // aslında gerek yok buna.
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
            HyperLink1.NavigateUrl = einf.ReturnUrl;
            ;
            HyperLink1.Visible = true;
            HyperLink1.Text = "Click here to go back to your previous page.";
        }
    }
}