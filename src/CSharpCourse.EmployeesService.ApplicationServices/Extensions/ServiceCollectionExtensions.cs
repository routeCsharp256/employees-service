using CSharpCourse.EmployeesService.ApplicationServices.Configurations;
using CSharpCourse.EmployeesService.ApplicationServices.Mapper;
using CSharpCourse.EmployeesService.ApplicationServices.MessageBroker;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class with extensions for <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeesApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateEmployeeCommand).Assembly);
            services.AddAutoMapper(typeof(ApplicationServicesMapperProfile).Assembly);
            services.AddKafkaServices(configuration);

            return services;
        }

        private static IServiceCollection AddKafkaServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<KafkaConfiguration>(configuration);
            services.AddSingleton<IProducerBuilderWrapper, ProducerBuilderWrapper>();

            return services;
        }
    }
}
