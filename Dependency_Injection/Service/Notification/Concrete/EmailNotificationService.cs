namespace Dependency_Injection.Services
{
    public class EmailNotificationService : INotificationService
    {
        public string SenMessage(string message)
        {
            return $"This message ({message}) send by Email";
        }
    }
}
