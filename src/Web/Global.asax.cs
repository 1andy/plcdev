using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap;

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

            // all URLs used in the PlexCommerce are lowercase
            routes.MapLowercaseRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            InitializeNHibernate();

            // set factory for controllers that supports IoC
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_EndRequest()
        {
            // dispose NHibernate session if created during this request
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        private static void InitializeNHibernate()
        {
            var databaseConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(
                c => c.FromConnectionStringWithKey("PlexCommerceConnection"));

            // function to create NHibernate's session factory
            Func<ISessionFactory> createSessionFactory = () => Fluently.Configure().Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .BuildSessionFactory();

            // initialize IoC support for NHibernate's ISessionFactory and ISession
            ObjectFactory.Initialize(
                x =>
                {
                    // ISessionFactory is created once per application
                    x.For<ISessionFactory>().Singleton().Use(createSessionFactory);

                    // ISession has scope of HTTP request
                    x.For<ISession>().HttpContextScoped().Use(context => context.GetInstance<ISessionFactory>().OpenSession());
                });
        }
    }
}