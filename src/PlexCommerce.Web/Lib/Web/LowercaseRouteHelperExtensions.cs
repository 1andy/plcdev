using System.Web.Mvc;
using System.Web.Routing;

namespace PlexCommerce.Web
{
    public static class LowercaseRouteHelperExtensions
    {
        public static void MapLowercaseRoute(this AreaRegistrationContext context, string name, string url, object defaults, object constraints = null)
        {
            var route = new LowercaseRoute(
                url,
                new RouteValueDictionary(defaults),
                constraints == null ? null : new RouteValueDictionary(constraints),
                new RouteValueDictionary(new { context.Namespaces, area = context.AreaName, UseNamespaceFallback = false }),
                new MvcRouteHandler());

            context.Routes.Add(name, route);
        }

        public static void MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces = null)
        {
            var route = new LowercaseRoute(
                url,
                new RouteValueDictionary(defaults),
                null,
                new RouteValueDictionary(new { Namespaces = namespaces }),
                new MvcRouteHandler());

            routes.Add(name, route);
        }
    }
}