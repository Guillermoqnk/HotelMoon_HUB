using HotelMoonHUB.Application.Services.Contracts;
using HotelMoonHUB.Application.Services.Implementations;
using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HotelMoonHUB.Application.Services.Configuration
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IHotelLegsService, HotelLegsService>();
            services.AddTransient<IHotelLegsConnection>

            return services;
        }
    }
}
