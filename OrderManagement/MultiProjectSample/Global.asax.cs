using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MultiProjectSample.App_Start;
using MultiProjectSample.IoC;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MultiProjectSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        public MvcApplication()
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
            ConfigureWindsor(GlobalConfiguration.Configuration);
            AutoMapperConfiguration.Configuration();
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
            //ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
