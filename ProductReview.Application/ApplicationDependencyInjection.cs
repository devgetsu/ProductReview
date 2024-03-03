using Microsoft.Extensions.DependencyInjection;
using ProductReview.Application.Services.AuthServices;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Application.Services.ProductServices;
using ProductReview.Application.Services.UserServices;

namespace ProductReview.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
