using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierArchTestProject.CoreLayer.Options;
using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using NTierArchTestProject.DataAccessLayer.Repositories;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using System.Reflection;

namespace NTierArchTestProject.DataAccessLayer.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection AddDalCustomService(this IServiceCollection services,IConfiguration configuration) 
        {
            //AppDbContext Registirations
            services.AddDbContext<AppDbContext>(opt =>
            {
                //Configuration.binding->Get() metodu için 
                var connectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                opt.UseSqlServer(connectionString!.SqlServer, optAct =>
                {
                    optAct.MigrationsAssembly(typeof(DalAssembly).Assembly.FullName);
                });
            });
            //IdentityDbContext Registirations
            services.AddIdentityCore<AppUser>(act =>
            {
                act.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();
            //IoC Life Time Registirations
            services.AddScoped(typeof(GenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IUserRoleRepository,UserRoleRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            return services;
        }
    }
}
