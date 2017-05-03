using Hk.Application1.Core.Interfaces;
using System;

namespace Hk.Application1.Core.Common
{
    public class PublisherService<T> : IPublisherService<T>
    {
        public event EventHandler<MessageEventArgs<T>> DataPublisher;

        public void OnDataPublisher(MessageEventArgs<T> e)
        {
            var handler = DataPublisher;
            if (handler != null)
                handler(this, e);
        }

        public void PublishData(T data)
        {
            MessageEventArgs<T> message = (MessageEventArgs<T>)Activator.CreateInstance(typeof(MessageEventArgs<T>), new object[] { data });
            OnDataPublisher(message);
        }
    }
}
