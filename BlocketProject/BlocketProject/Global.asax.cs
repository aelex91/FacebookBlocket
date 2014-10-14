using System;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Web.Routing;

namespace BlocketProject
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)

        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            //Call base.RegisterRoutes so default CMS routes are registered
            base.RegisterRoutes(routes);



            routes.MapRoute(
                "Logout",
                "Account/{action}",
                new { controller = "Account", action = "Logout" });

            routes.MapRoute(
                "Ads",
                "AdsPage/{action}",
                new { controller = "AdsPage" });

            routes.MapRoute(
                "search",
                "{action}",
                new { controller = "SearchPage" });

            routes.MapRoute(
              "Default",                                              // Route name
              "{controller}/{action}/{id}",                           // URL with parameters
              new { controller = "Home", action = "Index", id = "" });

        }






    }
}