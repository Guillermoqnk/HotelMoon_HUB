using HotelMoonHUB.Infrastructure.SvcAgents;
using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HotelMoonHUB.Application.Services.Configuration
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IHotelLegsConnection, HotelLegsConnection>();

            return services;
        }
    }
}
