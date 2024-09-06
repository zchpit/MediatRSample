using MediatR;

namespace MediatRSample.Notification
{
    public class WritePostNotificationConsoleHandler : INotificationHandler<WritePostNotification>
    {
        public Task Handle(WritePostNotification notification,
            CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.WhatToWrite);

            return Task.CompletedTask;
        }
    }
}
