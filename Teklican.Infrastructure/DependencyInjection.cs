﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Teklican.Application.Common.Interfaces.Authentication;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Common.Interfaces.Services;
using Teklican.Infrastructure.Authentication;
using Teklican.Infrastructure.Persistence;
using Teklican.Infrastructure.Persistence.Repositories;
using Teklican.Infrastructure.Services;

namespace Teklican.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {


            services
                .AddAuth(configuration)
                .AddPersistance(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddDbContext<TeklicanDbContext>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ILineItemsRepository, LineItemsRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }


        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName,jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}
