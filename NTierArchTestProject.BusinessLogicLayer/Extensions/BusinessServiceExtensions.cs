using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierArchTestProject.BusinessLogicLayer.Abstractions;
using NTierArchTestProject.BusinessLogicLayer.Behaviors;
using NTierArchTestProject.BusinessLogicLayer.Services;

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
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            //Fluent Validation Configuration
            services.AddValidatorsFromAssembly(typeof(BllAssembly).Assembly);
            //AutoMapper Configuration
            services.AddAutoMapper(typeof(BllAssembly).Assembly);
            //Registirations
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
