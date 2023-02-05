using GameHost.Api.Mapping;
using MediatR;

namespace GameHost.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();

            return services;
        }

    }
}
