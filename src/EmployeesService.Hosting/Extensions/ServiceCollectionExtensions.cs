using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="IServiceCollection" />
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employees Service",
                    Description = "Service that manages company employees"
                });
            });

            return services;
        }

        internal static IServiceCollection AddCustomApplicationSevices(this IServiceCollection services)
        {
            return services;
        }

        internal static IServiceCollection AddCustomDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}