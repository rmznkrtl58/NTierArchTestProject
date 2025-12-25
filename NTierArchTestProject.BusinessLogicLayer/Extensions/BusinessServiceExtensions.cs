using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NTierArchTestProject.BusinessLogicLayer.Extensions
{
    public static class BusinessServiceExtensions
    {
        public static IServiceCollection AddBllCustomService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(BllAssembly).Assembly);
            });
            return services;
        }
    }
}
