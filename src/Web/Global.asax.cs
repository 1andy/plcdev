using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using StructureMap;

namespace PlexCommerce.Web
{
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
            // we need this for NHibernate to write its logs
            RedirectConsoleOutputToFile();

            InitializeNHibernate();

            // set factory for controllers that supports IoC
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            CleanupConsoleOurputRedirect();
        }

        protected void Application_BeginRequest()
        {
        }

        protected void Application_EndRequest()
        {
            // dispose NHibernate session if created during this request
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        #region NHibernate Initialization

        private static void InitializeNHibernate()
        {
            var databaseConfiguration = MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(
                c => c.FromConnectionStringWithKey("PlexCommerceConnection"));

            // function to create NHibernate's session factory
            Func<ISessionFactory> createSessionFactory = () => Fluently.Configure().Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .ExposeConfiguration(SaveSchemaToFile)
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

        private static void SaveSchemaToFile(Configuration config)
        {
            var schema = new SchemaExport(config);

            // set output file
            string schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Schema.sql");
            schema.SetOutputFile(schemaPath);

            // write schema.sql and drop and recreate tables if schema file is missing
            schema.Create(true, !File.Exists(schemaPath));
        }

        #endregion

        #region Console Out Redirect (primarily for NHibernate)

        [Conditional("DEBUG")]
        private static void RedirectConsoleOutputToFile()
        {
            const string logFile = @"d:\pc.log";

            if (File.Exists(logFile))
            {
                var consoleOutWriter = new StreamWriter(logFile, true) { AutoFlush = true };
                Console.SetOut(consoleOutWriter);
            }
        }

        [Conditional("DEBUG")]
        private static void CleanupConsoleOurputRedirect()
        {
            if (Console.Out != null)
            {
                Console.Out.Dispose();
            }
        }

        #endregion
    }
}