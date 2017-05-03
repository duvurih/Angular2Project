using Hk.Application1.Core.Interfaces;

namespace Hk.Application1.Core.Common
{
    public class SubscriberService<T>
    {
        public IPublisherService<T> Publisher { get; private set; }
        public SubscriberService(IPublisherService<T> publisher)
        {
            Publisher = publisher;
        }
    }
}
