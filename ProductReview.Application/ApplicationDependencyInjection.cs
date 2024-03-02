using Microsoft.Extensions.DependencyInjection;
using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Application.Services.CommentServices;
using ProductReview.Application.Services.PasswordHasher;
using ProductReview.Application.Services.PermissionServices;
using ProductReview.Application.Services.ProductServices;
using ProductReview.Application.Services.RoleServices;
using ProductReview.Application.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICommentService, CommentService>();
            return services;
        }
    }
}
