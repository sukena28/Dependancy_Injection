using Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifactionController : ControllerBase
    {
        private readonly IEnumerable<INotificationService> _notificationServices;

        public NotifactionController(IEnumerable<INotificationService> notificationServiceervices)
        {
            _notificationServices = notificationServiceervices;
        }

        [HttpPost]
        public IEnumerable<string> Notify(string message)
        {
            List<string> notifications = new List<string>();

            foreach (var messageSender in _notificationServices)
            {
                notifications.Add(messageSender.SenMessage(message));
            }

            return notifications;

        }
    }
}