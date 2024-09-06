using MediatR;
using System.Diagnostics;

namespace MediatRSample.Notification
{
    public class WritePostNotificationDebuggerHandler : INotificationHandler<WritePostNotification>
    {
        public Task Handle(WritePostNotification notification,
            CancellationToken cancellationToken)
        {
            Debugger.Log(1, "Info",  notification.WhatToWrite);

            return Task.CompletedTask;
        }
    }
}
