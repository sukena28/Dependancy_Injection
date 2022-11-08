using Dependency_Injection.Services;

namespace Dependency_Injection.Service.Notification.Concrete
{
    public class CloudNotificationService : INotificationService
    {
        public string SenMessage(string message)
        {
            return $"This message ({message}) send by Cloud";
        }
    }
}
