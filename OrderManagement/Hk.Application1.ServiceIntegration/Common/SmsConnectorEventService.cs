using Hk.Application1.Core.Common;
using Hk.Application1.Core.Interfaces;
using Hk.Utilities.Interfaces;
using System.Threading.Tasks;

namespace Hk.Application1.Services.Common
{
    public class SmsConnectorEventService<T> : ISubscriberService<T>
    {
        IApiManager _iApiManager;
        public IPublisherService<T> _iPublisherService;

        public SmsConnectorEventService(IApiManager iApiManager, IPublisherService<T> iPublisherService)
        {
            _iApiManager = iApiManager;
            _iPublisherService = iPublisherService;
        }

        public void OnDataPublisher(MessageEventArgs<T> e)
        {
            var status = Task.Run(() =>
                    SendSms(e.Message)
                );
            status.Wait();
        }
        private async Task<bool> SendSms(T smsContent)
        {
            var responseResult = await _iApiManager.PostAsync<T>("smsapi", "sendSms", smsContent);
            return responseResult == null ? true : false;
        }
    }
}
