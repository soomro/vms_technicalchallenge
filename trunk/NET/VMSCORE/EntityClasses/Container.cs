using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMSCORE.EntityClasses
{
    /// <summary>
    /// This class provides a singleton mechanizm for EntityModelContainer.
    /// It creates an instance upon first call and then stores it in the httpcontext. 
    /// Note that httpcontext exists only for the request. It is destroyed after the response is sent.
    /// </summary>
    public class Container
    {

        public static EntityModelContainer Instance
        {
            get
            {
                if (System.Web.HttpContext.Current.Items["Cont"] ==null)
                {
                    System.Web.HttpContext.Current.Items["Cont"]=new EntityModelContainer();
                }
                return (EntityModelContainer)System.Web.HttpContext.Current.Items["Cont"];
            }
        }
    }
}
