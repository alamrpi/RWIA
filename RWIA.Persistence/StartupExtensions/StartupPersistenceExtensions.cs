using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RWIA.Persistence.Context;
using RWIA.Persistence.IRepositories;
using RWIA.Persistence.Repositories;

namespace RWIA.Persistence.StartupExtensions
{
    public static class StartupPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("db_rwia"); // Same name as in OnConfiguring
            });

            // Add services to the container.
            services.AddScoped<IShortLinkRepository, ShortLinkRepository>();

            return services;
        }
    }
}
