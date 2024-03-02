using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }
    }
}
