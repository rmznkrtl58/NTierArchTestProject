using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NTierArchTestProject.CoreLayer.Options;
using NTierArchTestProject.WebAPI.Middleware;
using System.Text;

namespace NTierArchTestProject.WebAPI.Extensions
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddCustomApiService(this IServiceCollection services,IConfiguration configuration)
        {

            //JWT "OptionPattern"
            services.Configure<JwtOption>(configuration.GetSection("Jwt"));
            var serviceProvider=services.BuildServiceProvider();
            var jwtConfiguration=serviceProvider.GetRequiredService<IOptions<JwtOption>>().Value;
            //Jwt Authentication
            services.AddAuthentication().AddJwtBearer(cfr =>
            {
                cfr.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey))
                };
            });
            //Authorization
            services.AddAuthorization();
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                //Swaggerda Jwt ile authorization kontrolü yapma işlemi
                var jwtSecuritySheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
            });

            //Middleware class configuration
            services.AddTransient<ExceptionMiddleware>();//her çağrıldığında bir instance oluştur.

            return services;
        }
    }
}
