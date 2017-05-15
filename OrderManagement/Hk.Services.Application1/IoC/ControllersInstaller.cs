using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.ModelsHk.Application1.Services.Products;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.Application1.Services.Categories;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;
using Hk.Utilities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace Hk.Services.Application1.IoC
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());

            //Registering Repositories
            container.Register(Component.For<DatabaseContext>().LifeStyle.PerWebRequest);
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest());
            container.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>().LifestylePerWebRequest());
            container.Register(Component.For<ICategoryRepository>().ImplementedBy<CategoryRepository>().LifestylePerWebRequest());

            container.Register(Component.For<ISerializer>().ImplementedBy<JSONSerializer>().LifestylePerWebRequest());
            container.Register(Component.For<IServiceManager>().ImplementedBy<ServiceManager>().LifestylePerWebRequest());
            container.Register(Component.For<ICrypto>().ImplementedBy<CryptoService>().LifestylePerWebRequest());

            //Registering Services
            container.Register(Component.For<IProductService>().ImplementedBy<ProductService>().LifestylePerWebRequest());
            container.Register(Component.For<ICategoryService>().ImplementedBy<CategoryService>().LifestylePerWebRequest());
            //container.Register(Component.For<ISubscriberService>().ImplementedBy<eMailConnectorEventService>().LifestylePerWebRequest());
            //container.Register(Component.For<ISubscriberService>().ImplementedBy<SmsConnectorEventService>().LifestylePerWebRequest());

        }
    }

    #region Helper classes

    public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!_container.Kernel.HasComponent(serviceType))
            {
                return new object[0];
            }

            return _container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }

    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            _container = container;
            _scope = container.BeginScope();
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }

    public class ApiControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
        }
    }

    #endregion
}