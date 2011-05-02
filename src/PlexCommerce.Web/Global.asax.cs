using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using Configuration = NHibernate.Cfg.Configuration;

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
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "PlexCommerce.Web.Controllers" });
        }

        protected void Application_Start()
        {
            // we need this for NHibernate to write its logs
            RedirectConsoleOutputToFile();

            InitializeNHibernate();

            // create initial data (countries, etc.) if required
            ObjectFactory.GetInstance<InitialDataCreator>().CreateInitialDataIfMissing();

            // set factory for controllers that supports IoC
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            // register payment methods
            ObjectFactory.Configure(x => x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.AddAllTypesOf<IPaymentModuleInfo>();
            }));
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

        #region NHibernate and Data Initialization

        private static void InitializeNHibernate()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PlexCommerceConnection"];
            if (connectionString == null)
            {
                throw new InvalidOperationException("PlexCommerceConnection connection string is not defined in Web.config");
            }

            var databaseConfiguration = MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(connectionString.ConnectionString);
            var fluentConfiguration = Fluently.Configure().Database(databaseConfiguration).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>());

            fluentConfiguration.ExposeConfiguration(SaveDatabaseSchemaToFile);
            fluentConfiguration.ExposeConfiguration(SetupDatabase);

            // initialize IoC support for NHibernate's ISessionFactory and ISession
            ObjectFactory.Configure(
                x =>
                {
                    // ISessionFactory is created once per application
                    x.For<ISessionFactory>().Singleton().Use(fluentConfiguration.BuildSessionFactory);

                    // ISession has scope of HTTP request
                    x.For<ISession>().HttpContextScoped().Use(context => context.GetInstance<ISessionFactory>().OpenSession());
                });
        }

        private static void SaveDatabaseSchemaToFile(Configuration configuration)
        {
            // save schema to file if SaveShemaToFile variable is defined in <appSettings> section
            var saveSchemaFile = ConfigurationManager.AppSettings["SaveSchemaToFile"];
            if (!string.IsNullOrWhiteSpace(saveSchemaFile))
            {
                var schema = new SchemaExport(configuration);
                schema.SetOutputFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveSchemaFile));
                schema.Create(true, false);
            }
        }

        private static void SetupDatabase(Configuration configuration)
        {
            try
            {
                var validator = new SchemaValidator(configuration);
                validator.Validate();
            }
            catch (HibernateException)
            {
                var update = new SchemaUpdate(configuration);
                update.Execute(true, true);

                if (update.Exceptions.Count != 0)
                {
                    throw new HibernateException("The following errors occurred when trying to setup database:\n"
                        + string.Join(Environment.NewLine, update.Exceptions.Select(e => e.Message)));
                }
            }
        }

        #endregion

        #region Console Out Redirect (for NHibernate logging)

        [Conditional("DEBUG")]
        private static void RedirectConsoleOutputToFile()
        {
            const string LogFile = @"d:\pc.log";

            // we log into this file only if it exists
            if (File.Exists(LogFile))
            {
                var consoleOutWriter = new StreamWriter(LogFile, true) { AutoFlush = true };
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