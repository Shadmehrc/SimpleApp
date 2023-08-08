using Application.Interfaces;
using Application.Services;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUsersDataAccess, UsersDataAccess>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}