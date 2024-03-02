using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductReview.Infrastruct.Persistance;

namespace ProductReview.Infrastruct
{
    public static class InfrastructDependencyInjection
    {
        public static IServiceCollection AddInfraStruct(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(ops =>
            {
                ops.UseNpgsql(config.GetConnectionString("Postgress"));
            });

            return services;
        }
    }
}
