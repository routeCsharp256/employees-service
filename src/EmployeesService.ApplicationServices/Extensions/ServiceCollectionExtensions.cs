using EmployeesService.ApplicationServices.Mapper;
using EmployeesService.ApplicationServices.Models.Commands;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeesApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateEmployeeCommand).Assembly);
            services.AddAutoMapper(typeof(ApplicationServicesMapperProfile).Assembly);

            return services;
        }
    }
}
