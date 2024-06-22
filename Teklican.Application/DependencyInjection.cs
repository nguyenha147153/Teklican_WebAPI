using Microsoft.Extensions.DependencyInjection;
using Teklican.Application.Services.Authentication;

namespace Teklican.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
