using Application.Decorator;
using Application.FacadeServices;
using Application.IFacade;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<OrderDecorator, ConcreateOrderDecorator>();
            return services;
        }
    }
}