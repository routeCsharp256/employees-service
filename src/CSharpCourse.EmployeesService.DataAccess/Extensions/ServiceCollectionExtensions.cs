using CSharpCourse.EmployeesService.Core.Contracts.Repositories;
using CSharpCourse.EmployeesService.DataAccess.Configurations;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="IServiceCollection" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeesServiceDb(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DbConfiguration>(configuration);

            var dbConf = configuration.Get<DbConfiguration>();
            services.AddDbContext<EmployeesDbContext>(opt => { opt.UseNpgsql(dbConf.ConnectionString); });

            return services;
        }

        public static IServiceCollection AddEmployeesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();

            return services;
        }
    }
}
