using Dependency_Injection.Common.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Dependency_Injection.Configuration
{
    public static class ConfigureFilters
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddControllers(opts => { opts.Filters.Add<ApiActionFilter>(); });
            return services;
        }
    }
}