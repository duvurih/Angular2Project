using System;

namespace Hk.Application1.Core.Common
{
    //1- Define a delegate
    //2- Define an event based on that delegate
    //3- Raise and event
    //public delegate void SendMessageEventHandler(object source, MessageEventArgs args);
    //public delegate void SendMessageEventHandler<T>(object source, MessageEventArgs<T> args);

    public class MessageEventArgs<T> : EventArgs
    {
        public T Message { get; private set; }
        public MessageEventArgs(T message)
        {
            Message = message;
        }
    }
}
