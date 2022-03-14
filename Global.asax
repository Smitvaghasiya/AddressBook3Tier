<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }

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

    public static void RegisterRoutes(System.Web.Routing.RouteCollection Routes)
    {
        Routes.Ignore("{resource}.axd/{*pathInfo}");

        Routes.Ignore("{resource}.axd/{*pathInfo}");
        
        Routes.MapPageRoute("AdminPannelCountryList", "AdminPannel/Country/CountryList", "~/AdminPannel/Country/CountryList.aspx");
        Routes.MapPageRoute("AdminPannelCountryAdd", "AdminPannel/Country/{OperationName}", "~/AdminPannel/Country/CountryAddEdit.aspx");
        Routes.MapPageRoute("AdminPannelCountryEdit", "AdminPannel/Country/{OperationName}/{CountryID}", "~/AdminPannel/Country/CountryAddEdit.aspx");
        

        Routes.MapPageRoute("AdminPannelStateList", "AdminPannel/State/StateList", "~/AdminPannel/State/StateList.aspx");
        Routes.MapPageRoute("AdminPannelStateAdd",  "AdminPannel/State/{OperationName}", "~/AdminPannel/State/StateAddEditList.aspx");
        Routes.MapPageRoute("AdminPannelStateEdit", "AdminPannel/State/{OperationName}/{StateID}", "~/AdminPannel/State/StateAddEditList.aspx");
        

        Routes.MapPageRoute("AdminPannelCityList", "AdminPannel/City/CityList", "~/AdminPannel/City/CityList.aspx");
        Routes.MapPageRoute("AdminPannelCityAdd", "AdminPannel/City/{OperationName}", "~/AdminPannel/City/CityAddEditList.aspx");
        Routes.MapPageRoute("AdminPannelCityEdit", "AdminPannel/City/{OperationName}/{CityID}", "~/AdminPannel/City/CityAddEditList.aspx");
        

        Routes.MapPageRoute("AdminPannelContactCategoryList", "AdminPannel/ContactCategory/ContactCategoryList", "~/AdminPannel/ContactCategory/ContactCategoryList.aspx");
        Routes.MapPageRoute("AdminPannelContactCategoryAdd", "AdminPannel/ContactCategory/{OperationName}", "~/AdminPannel/ContactCategory/ContactCategoryAddEditList.aspx");
        Routes.MapPageRoute("AdminPannelContactCategoryEdit", "AdminPannel/ContactCategory/{OperationName}/{ContactCategoryID}", "~/AdminPannel/ContactCategory/ContactCategoryAddEditList.aspx");

        
        Routes.MapPageRoute("AdminPannelContactList", "AdminPannel/Contact/ContactList", "~/AdminPannel/Contact/ContactList.aspx");
        Routes.MapPageRoute("AdminPannelContactAdd", "AdminPannel/Contact/{OperationName}", "~/AdminPannel/Contact/ContactAddEditList.aspx");
        Routes.MapPageRoute("AdminPannelContactEdit", "AdminPannel/Contact/{OperationName}/{ContactID}", "~/AdminPannel/Contact/ContactAddEditList.aspx");

    }

</script>
