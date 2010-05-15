using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Utils
{
    public static class Errors
    {
        public static void FireAuthenticationError(string message)
        {
            ErrorInfo inf = new ErrorInfo(message);
            inf.ErType = ErrorType.Authentication;
            inf.ReturnUrl = HttpContext.Current.Request.Path;

            HttpContext.Current.Session["_Error"] = inf;
            HttpContext.Current.Server.Transfer("~/Error.aspx");
            
        }
        public static void FireAuthenticationError(string message, string link)
        {
            ErrorInfo inf = new ErrorInfo(message,link);
            inf.ReturnUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            inf.ErType = ErrorType.Authentication;
            HttpContext.Current.Session["_Error"] = inf;
            HttpContext.Current.Server.Transfer("~/Error.aspx");
        }

        public static void FireError(string message)
        {
            ErrorInfo inf = new ErrorInfo(message);
            inf.ReturnUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            HttpContext.Current.Session["_Error"] = inf;
            HttpContext.Current.Server.Transfer("~/Error.aspx");

        }
        public static void FireError(string message,Exception ex)
        {
            ErrorInfo inf = new ErrorInfo(message);
            inf.Exception = ex;
            inf.ReturnUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            HttpContext.Current.Session["_Error"] = inf;
            HttpContext.Current.Server.Transfer("~/Error.aspx");

        }
        
    }

    public class ErrorInfo
    {
        public string ErrorMessage;
        public string Link;
        public ErrorType ErType;
        public string ReturnUrl;
        public Exception Exception;

        public ErrorInfo(string message)
        {
            ErrorMessage = message;
            ErType = ErrorType.None;
        }

        public ErrorInfo(string message, string link)
        {
            this.ErrorMessage = message;
            this.Link = link;

        }
        public ErrorInfo(string message, ErrorType type)
        {
            this.ErrorMessage = message;
            this.ErType = type;
        }

    }
    public enum ErrorType
    {
        None = 0,
        Authentication=1,
        SqlException=2,
        ArgumentException=3
    }
}
