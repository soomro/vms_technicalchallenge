using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace DAL
{
    /// <summary>
    /// This class provides a singleton mechanizm for EntityModelContainer.
    /// It creates an instance upon first call and then stores it in the httpcontext. 
    /// Note that httpcontext exists only for the request. It is destroyed after the response is sent.
    /// </summary>
    public class Container
    {
        public static ApolloEntities Instance
        {
            get
            {
                if (System.Web.HttpContext.Current.Items.Contains(Utils.Constants.GlobalIds.Container)==false)
                {
                    System.Web.HttpContext.Current.Items.Add(Utils.Constants.GlobalIds.Container, new ApolloEntities());
                }
                return (ApolloEntities)System.Web.HttpContext.Current.Items[Utils.Constants.GlobalIds.Container];
            }
        }

        public static ApolloEntities WSInstance
        {
            get
            {
                if (System.Web.HttpContext.Current.Items[Utils.Constants.GlobalIds.Container] == null)
                {
                    System.Web.HttpContext.Current.Items[Utils.Constants.GlobalIds.Container] = new ApolloEntities();
                }
                return (ApolloEntities)System.Web.HttpContext.Current.Items[Utils.Constants.GlobalIds.Container];
            }
        }


    }
}
