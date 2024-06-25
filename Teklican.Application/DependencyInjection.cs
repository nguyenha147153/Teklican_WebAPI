﻿using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Teklican.Application.Authentication.Commands.Register;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;

namespace Teklican.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
