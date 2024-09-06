using MediatR;

namespace MediatRSample.Notification
{
    public class WritePostNotification : INotification
    {
        public string WhatToWrite { get; set; }
    }
}
