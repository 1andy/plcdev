using System.Web.Mvc;
using System.Web.Routing;

namespace PlexCommerce.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Admin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            ////            var route = new LowercaseRoute("Admin/{controller}/{action}/{id}",
            //                                           new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
            //                                           null,
            //                                           new RouteValueDictionary(new
            //                                           {
            //                                               Namespaces = new[] { "PlexCommerce.Web.Areas.Admin.*" },
            //                                               area = "Admin",
            //                                               UseNamespaceFallback = false
            //                                           }),
            //                                           new MvcRouteHandler());
            ////            context.Routes.Add("Admin_default", route);

            context.MapLowercaseRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}