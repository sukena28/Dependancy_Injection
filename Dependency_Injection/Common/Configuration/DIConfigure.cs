using Dependency_Injection.Repositories;
using Dependency_Injection.Service;
using Dependency_Injection.Service.Notification.Concrete;
using Dependency_Injection.Services;

namespace Dependency_Injection.Configuration
{
    public static class DIConfigure
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Register services
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            //Register List
            services.AddScoped<INotificationService, EmailNotificationService>();
            services.AddScoped<INotificationService, TextNotificationService>();
            services.AddScoped<INotificationService, CloudNotificationService>();


            return services;
        }
    }
}
