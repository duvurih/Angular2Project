using Castle.MicroKernel;
using Castle.Windsor;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace MultiProjectSample.Plubming
{
    public class WindsorControllerFactory : IHttpControllerActivator
    {
        #region Members

        private readonly IWindsorContainer container;

        #endregion

        #region Constructors

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Methods

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = (IHttpController)container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() => container.Release(controller)));

            return controller;
        }

        #endregion

        #region Helper classes

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                release();
            }
        }

        #endregion
    }
}