using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Cache;
using Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers;
using Teleperformance.Bootcamp.Application.Interfaces.Token;
using Teleperformance.Bootcamp.Infrastructure.Services.Cache;
using Teleperformance.Bootcamp.Infrastructure.Services.MessageBrokers;
using Teleperformance.Bootcamp.Infrastructure.Services.Token;

namespace Teleperformance.Bootcamp.Infrastructure
{
    public static class ServisRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Redis configuration
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
            

            //Add Ioc
            services.AddScoped<ITokenGenerator,TokenGenerator>();

            services.AddSingleton<IRedisDistrubutedCache, RedisDistrubutedCacheService>();

            services.AddScoped<IRabbitmqConnection, RabbitmqConnection>();
            services.AddScoped<IRabbitmqService, RabbitmqService>();



            //Auth configuration
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
             options.SaveToken = true;
             options.RequireHttpsMetadata = false;
             options.TokenValidationParameters = new TokenValidationParameters()
             {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
              };
              });


            return services;
        }


    }
}
