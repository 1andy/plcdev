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
            // map /admin/products/123
            context.MapLowercaseRoute(
                "Admin_view",
                "Admin/{controller}/{id}",
                new { controller = "Home", action = "View" },
                new { id = @"\d+" });

            // map /admin/products/edit/123
            context.MapLowercaseRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { action = @"^\D.*" });
        }
    }
}