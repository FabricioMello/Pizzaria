using Catalogo.Application.Interfaces;
using Catalogo.Application.Mappings;
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Catalogo.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                 new MySqlServerVersion(new Version(8, 0, 29))));

        services.AddScoped<IDeliveryDetailsRepository, DeliveryDetailsRepository>();
        services.AddScoped<IDeliveryDetailsService, DeliveryDetailsService>();
        services.AddScoped<IFlavorRepository, FlavorRepository>();
        services.AddScoped<IFlavorService, FlavorService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPizzaFlavorRepository, PizzaFlavorRepository>();
        services.AddScoped<IPizzaFlavorService, PizzaFlavorService>();
        services.AddScoped<IPizzaRepository, PizzaRepository>();
        services.AddScoped<IPizzaService, PizzaService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
