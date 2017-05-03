using Hk.Application1.Core.Common;
using System;

namespace Hk.Application1.Core.Interfaces
{
    public interface IPublisherService<T>
    {
        event EventHandler<MessageEventArgs<T>> DataPublisher;
        //void OnDataPublisher(MessageArgument<T> args);
        //void PublishData(T data);
        void OnDataPublisher(MessageEventArgs<T> e);
    }
}
