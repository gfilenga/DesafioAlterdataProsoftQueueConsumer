using DevListSyncQueueWorker.Interfaces;
using DevListSyncQueueWorker.Services;
using DevListSyncQueueWorker.Settings;
using Refit;

namespace DevListSyncQueueWorker.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDevListSyncService, DevListSyncService>();

            services.AddRefitClient<IExternalApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://61a170e06c3b400017e69d00.mockapi.io/");
            });

            services.AddHostedService<DevListConsumerService>();
        }
    }
}
