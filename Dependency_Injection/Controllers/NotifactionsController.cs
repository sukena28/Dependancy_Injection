using Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotifactionsController : ControllerBase
    {
        private readonly IEnumerable<INotificationService> _notificationServices;

        public NotifactionsController(IEnumerable<INotificationService> notificationServiceervices)
        {
            _notificationServices = notificationServiceervices;
        }

        [HttpPost]
        public IActionResult Notify(string message)
        {
            List<string> notifications = new List<string>();

            foreach (var messageSender in _notificationServices)
            {
                notifications.Add(messageSender.SenMessage(message));
            }

            return Ok(notifications);

        }
    }
}