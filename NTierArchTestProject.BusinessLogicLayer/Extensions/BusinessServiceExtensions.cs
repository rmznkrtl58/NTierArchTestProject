using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NTierArchTestProject.BusinessLogicLayer.Extensions
{
    public static class BusinessServiceExtensions
    {
        public static IServiceCollection AddBllCustomService(this IServiceCollection services,IConfiguration configuration)
        {
            //MediatR Configuration
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(BllAssembly).Assembly);
            });
            //Fluent Validation Configuration
            services.AddValidatorsFromAssembly(typeof(BllAssembly).Assembly);
            //AutoMapper Configuration
            services.AddAutoMapper(typeof(BllAssembly).Assembly);

            return services;
        }
    }
}
