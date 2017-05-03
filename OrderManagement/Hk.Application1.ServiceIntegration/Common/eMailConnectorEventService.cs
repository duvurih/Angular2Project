using Hk.Application1.Core.Common;
using Hk.Application1.Core.Interfaces;
using Hk.Utilities.Interfaces;
using System.Threading.Tasks;

namespace Hk.Application1.Services.Common
{
    public class eMailConnectorEventService<T> : ISubscriberService<T>
    {
        IApiManager _iApiManager;
        public IPublisherService<T> _iPublisherService;

        public eMailConnectorEventService(IApiManager iApiManager, IPublisherService<T> iPublisherService)
        {
            _iApiManager = iApiManager;
            _iPublisherService = iPublisherService;
        }

        public void OnDataPublisher(MessageEventArgs<T> e)
        {
            var status = Task.Run(() =>
                    SendEmail(e.Message)
                );
            status.Wait();
        }
        private async Task<bool> SendEmail(T smsContent)
        {
            var responseResult = await _iApiManager.PostAsync<T>("smsapi", "sendSms", smsContent);
            return responseResult == null ? true : false;
        }
    }
}
