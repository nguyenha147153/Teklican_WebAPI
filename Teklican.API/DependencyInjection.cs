using Teklican.API.Common.Mapping;
using Teklican.API.Middleware;

namespace Teklican.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMappings();

            return services;
        }
    }
}
