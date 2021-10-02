using EmployeesService.ApplicationServices.Configurations;
using EmployeesService.DataAccess.Configurations;
using EmployeesService.Hosting.Mapper;
using EmployeesService.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="IServiceCollection" />
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddCustomOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }

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

        internal static IServiceCollection AddCustomServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEmployeesServiceDb(configuration);
            services.AddEmployeesRepositories();
            services.AddEmployeesApplicationServices(configuration);

            return services;
        }

        internal static IServiceCollection AddCustomDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        internal static IServiceCollection AddCustomMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(HostingMapperProfile).Assembly);

            return services;
        }

        internal static IServiceCollection AddCustomLogging(this IServiceCollection services)
        {
            services.AddLogging(lb =>
            {
                lb.AddConsole();
                lb.AddFluentMigratorConsole();
            });

            return services;
        }

        internal static IServiceCollection AddCustomFluentMigrator(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                    rb.AddPostgres11_0()
                        .WithGlobalConnectionString(configuration.GetSection(nameof(DbConfiguration))
                            .Get<DbConfiguration>().ConnectionString)
                        .ScanIn(typeof(InitialMigration).Assembly).For.Migrations()
                );

            return services;
        }
    }
}
