using System.Collections.Generic;

namespace SMTC.Core.Notification
{
    public interface IDomainNotificationContext
    {
        bool HasErrorNotifications { get; }
        void NotifyError(string message);
        void NotifySuccess(string message);
        List<DomainNotification> GetErrorNotifications();
        string GetErrorNotificationsString();
    }
}
