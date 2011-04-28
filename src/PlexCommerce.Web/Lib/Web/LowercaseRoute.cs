using System.Text.RegularExpressions;
using System.Web.Routing;

namespace PlexCommerce.Web
{
    /// <summary>
    /// This is a helper Route implementation that produces lower case urls.
    /// </summary>
    public class LowercaseRoute : Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public LowercaseRoute(
            string url,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        public LowercaseRoute(
            string url,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            RouteValueDictionary dataTokens,
            IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                // try to not replace parameter values
                path.VirtualPath = Regex.Replace(path.VirtualPath, @"(?<=[/?&]|^)[^/?&=]+(?=[/?&=]|$)", match => match.Value.ToLowerInvariant());
            }

            return path;
        }
    }
}