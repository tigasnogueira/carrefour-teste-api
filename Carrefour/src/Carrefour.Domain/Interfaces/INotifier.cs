using Carrefour.Domain.Notifications;

namespace Carrefour.Domain.Interfaces;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
