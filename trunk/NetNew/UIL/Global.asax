﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(AutoRequesting));

        System.Timers.Timer t = new System.Timers.Timer(5000);

        t.Elapsed += new System.Timers.ElapsedEventHandler(ProcessRequests);
        t.Enabled = true;
        t.Start();
    }

    void AutoRequesting(object o)
    {
        
    }

    void ProcessRequests(object sender, System.Timers.ElapsedEventArgs e)
    {
        DAL.ApolloEntities c = new DAL.ApolloEntities();
        c.ExecuteStoreCommand("TEST");
    }

    //void ProcessRequests(object sender, EventArgs e)
    //{
    //    DAL.Container.Instance.ExecuteStoreCommand("TEST");
    //}
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
