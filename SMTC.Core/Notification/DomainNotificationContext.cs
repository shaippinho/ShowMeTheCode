﻿using System.Collections.Generic;
using System.Linq;

namespace SMTC.Core.Notification
{
    public class DomainNotificationContext : IDomainNotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationContext()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool HasErrorNotifications
            => _notifications.Any(x => x.Type == DomainNotificationType.Error);

        public void NotifySuccess(string message)
            => Notify(message, DomainNotificationType.Success);

        public void NotifyError(string message)
            => Notify(message, DomainNotificationType.Error);

        private void Notify(string message, DomainNotificationType type)
            => _notifications.Add(new DomainNotification(type, message));

        public List<DomainNotification> GetErrorNotifications()
            => _notifications.Where(x => x.Type == DomainNotificationType.Error).ToList();

        public string GetErrorNotificationsString()
            => string.Join(", ", GetErrorNotifications().Select(x => x.Value));

    }
}
