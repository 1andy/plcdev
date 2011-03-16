using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlexCommerce.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add(new LowercaseRoute("{controller}/{action}/{id}",
            //    new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
            //    new MvcRouteHandler()));

            routes.MapLowercaseRoute("Default",
                            "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            // initialize NHibernate

            // bootstrap StructureMap

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}