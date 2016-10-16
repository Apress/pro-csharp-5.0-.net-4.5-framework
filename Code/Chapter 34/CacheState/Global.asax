<%@ Application Language="C#" %>
<%@ Import Namespace = "System.Data.SqlClient" %>
<%@ Import Namespace = "System.Data" %>

<script runat="server">
    
    // Define a static level Cache member variable. 
    static Cache theCache;
    
    void Application_Start(Object sender, EventArgs e) {
        // First assign the static 'theCache' variable.
        theCache = Context.Cache;
 
        // When the application starts up,
        // read the current records in the
        // Inventory table of the Cars DB.
        SqlConnection cn = new SqlConnection
         (@"Data Source=(local)\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;Pooling=False;");
        SqlDataAdapter dAdapt =
             new SqlDataAdapter("Select * From Inventory", cn);
        DataSet theCars = new DataSet();
        dAdapt.Fill(theCars, "Inventory");

        // Now store DataSet in the cache.
        theCache.Insert("AppDataSet",
             theCars, null,
             DateTime.Now.AddSeconds(15),
             Cache.NoSlidingExpiration,
             CacheItemPriority.Default,
             new CacheItemRemovedCallback(UpdateCarInventory));
    }

    // The target for the CacheItemRemovedCallback delegate.
    static void UpdateCarInventory(string key, object item,
         CacheItemRemovedReason reason)
    {
        // Populate the DataSet.
        SqlConnection cn = new SqlConnection
        (@"Data Source=(local)\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True;Pooling=False;");
        SqlDataAdapter dAdapt =
             new SqlDataAdapter("Select * From Inventory", cn);
        DataSet theCars = new DataSet();
        dAdapt.Fill(theCars, "Inventory");
        // Now store in the cache.
        theCache.Insert("AppDataSet",
             theCars, null,
             DateTime.Now.AddSeconds(15),
             Cache.NoSlidingExpiration,
             CacheItemPriority.Default,
             new CacheItemRemovedCallback(UpdateCarInventory));
    }

    void Application_End(Object sender, EventArgs e) {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(Object sender, EventArgs e) { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(Object sender, EventArgs e) {
        // Code that runs when a new session is started

    }

    void Session_End(Object sender, EventArgs e) {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
