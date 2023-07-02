using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZigitHub.Domain.Core.Bus;
using ZigitHub.Infra.Bus;
using ZigitHub.Infra.Data.Context;

namespace ZigitHub.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, IHttpContextAccessor contextAccessor = null)
        {
            services.RegisterContextAccessor(contextAccessor);
            services.AddMemoryCache();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddHttpClient();

            // Application Layer

            // Infra Data Layer

            services.AddScoped<ApplicationContext>();

            return services;
        }

        private static void RegisterContextAccessor(this IServiceCollection services, IHttpContextAccessor contextAccessor = null)
        {
            if (contextAccessor == null)
            {
                services.AddHttpContextAccessor();
            }
            else
            {
                services.AddTransient<IHttpContextAccessor>(x => contextAccessor);
            }
        }
    }
}
