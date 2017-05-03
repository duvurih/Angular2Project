using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Hk.Services.Application1.Installer;
using Hk.Services.Application1.Plumbing;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml;

namespace Hk.Services.Application1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        public WebApiApplication()
        {
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            container = new WindsorContainer();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //HttpConfiguration config = GlobalConfiguration.Configuration;

            //config.Formatters.JsonFormatter
            //            .SerializerSettings
            //            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            ConfigureWindsor(GlobalConfiguration.Configuration);

            ConfigureSerialization(GlobalConfiguration.Configuration);

        }
        protected void Application_End()
        {
            container.Dispose();
        }

        private static void ConfigureWindsor(HttpConfiguration configuration)
        {
            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }

        private static void ConfigureSerialization(HttpConfiguration configuration)
        {
            #region JSON Settings

            configuration.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                TypeNameHandling = TypeNameHandling.Objects,
                ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            
            #endregion

            #region XML Settings

            configuration.Formatters.XmlFormatter.Indent = true;
            configuration.Formatters.XmlFormatter.WriterSettings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            configuration.Formatters.XmlFormatter.WriterSettings.NewLineHandling = NewLineHandling.Entitize;
            configuration.Formatters.XmlFormatter.WriterSettings.OmitXmlDeclaration = true;

            #endregion
        }
    }
}
