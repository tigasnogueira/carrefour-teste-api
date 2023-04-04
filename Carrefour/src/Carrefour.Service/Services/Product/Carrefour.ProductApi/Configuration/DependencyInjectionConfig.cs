using Carrefour.Domain.Interfaces;
using Carrefour.Domain.Notifications;
using Carrefour.ProductApi.Context;
using Carrefour.ProductApi.Interfaces;
using Carrefour.ProductApi.Repository;
using Carrefour.ProductApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carrefour.ProductApi.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<MyDbContext>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<INotifier, Notifier>();


        return services;
    }
}
