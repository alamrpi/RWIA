using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RWIA.Persistence.StartupExtensions;
using RWIA.Service.IServices;

namespace RWIA.Service.StartupExtensions
{
    public static class StartupPersistenceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddPersistence(configuration);

            services.AddScoped<IShortLinkService, ShortLinkService>();
            return services;
        }
    }
}
