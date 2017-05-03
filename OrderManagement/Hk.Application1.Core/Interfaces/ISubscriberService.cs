using Hk.Application1.Core.Common;

namespace Hk.Application1.Core.Interfaces
{
    public interface ISubscriberService<T>
    {
        void OnDataPublisher(MessageEventArgs<T> e);
    }
}
