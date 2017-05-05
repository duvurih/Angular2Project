namespace MultiProjectSample.IoC
{
    //public class WindsorControllerFactory : IHttpControllerActivator
    //{
    //    #region Members

    //    private readonly IWindsorContainer container;

    //    #endregion

    //    #region Constructors

    //    public WindsorControllerFactory(IWindsorContainer container)
    //    {
    //        this.container = container;
    //    }

    //    #endregion

    //    #region Methods

    //    public IHttpController Create(
    //        HttpRequestMessage request,
    //        HttpControllerDescriptor controllerDescriptor,
    //        Type controllerType)
    //    {
    //        var controller = (IHttpController)container.Resolve(controllerType);

    //        request.RegisterForDispose(new Release(() => container.Release(controller)));

    //        return controller;
    //    }

    //    #endregion

    //    #region Helper classes

    //    private class Release : IDisposable
    //    {
    //        private readonly Action release;

    //        public Release(Action release)
    //        {
    //            this.release = release;
    //        }

    //        public void Dispose()
    //        {
    //            release();
    //        }
    //    }

    //    #endregion
    //}
}