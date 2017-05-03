using Hk.Application1.Core.Common;
using Hk.Application1.Core.Interfaces;
using Hk.Utilities.Interfaces;
using System.Threading.Tasks;

namespace Hk.Application1.Services.Common
{
    public class eMailConnectorEventService<T> : ISubscriberService<T>
    {
        IServiceManager _iServiceApiManager;
        public IPublisherService<T> _iPublisherService;

        public eMailConnectorEventService(IServiceManager iServiceApiManager, IPublisherService<T> iPublisherService)
        {
            _iServiceApiManager = iServiceApiManager;
            _iPublisherService = iPublisherService;
        }

        public void OnDataPublisher(MessageEventArgs<T> e)
        {
            var status = Task.Run(() =>
                    SendEmail(e.Message)
                );
            status.Wait();
        }
        private bool SendEmail(T smsContent)
        {
            var responseResult = _iServiceApiManager.PostAsync<T>("smsapi", "sendSms", smsContent);
            return responseResult == null ? true : false;
        }
    }
}
