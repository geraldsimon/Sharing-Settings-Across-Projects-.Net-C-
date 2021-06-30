using Bussiness.Extensions;
using Bussiness.Intefaces;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerServiceSample.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationExtension, ConfigurationExtension>();

            return services;
        }
    }
}
