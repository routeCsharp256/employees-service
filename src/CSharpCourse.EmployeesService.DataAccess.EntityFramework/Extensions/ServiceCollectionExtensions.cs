using CSharpCourse.EmployeesService.DataAccess.Configurations;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base;
using CSharpCourse.EmployeesService.DataAccess.Repositories;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="IServiceCollection" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeesServiceEntityFrameworkDb(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DbConfiguration>(configuration);

            var dbConf = configuration.Get<DbConfiguration>();
            services.AddDbContext<EmployeesDbContext>(opt => { opt.UseNpgsql(dbConf.ConnectionString); });

            return services;
        }

        public static IServiceCollection AddEmployeesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();

            services.AddEmployeePredicateBuilders();

            return services;
        }

        private static IServiceCollection AddEmployeePredicateBuilders(this IServiceCollection services)
        {
            services.AddScoped<IFactory<IEmployeeFilterPredicateBuilder>, EmployeeFilterPredicateBuilderFactory>();

            return services;
        }
    }
}
