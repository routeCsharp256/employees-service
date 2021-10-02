

using EmployeesService.ApplicationServices.Configurations;
using EmployeesService.ApplicationServices.Mapper;
using EmployeesService.ApplicationServices.MessageBroker;
using EmployeesService.ApplicationServices.Models.Commands;
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
            services.Configure<KafkaConfiguration>(opt =>
                configuration.GetSection(nameof(KafkaConfiguration)).Bind(opt));
            services.AddScoped<IProducerBuilderWrapper, ProducerBuilderWrapper>();

            return services;
        }
    }
}
