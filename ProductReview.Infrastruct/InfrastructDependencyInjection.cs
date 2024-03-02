using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Infrastruct.Persistance;
using ProductReview.Infrastruct.Repositories;

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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepos, RolePermissionRepos>();

            return services;
        }
    }
}
