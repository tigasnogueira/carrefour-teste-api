using Carrefour.Domain.Interfaces;
using Carrefour.Domain.Notifications;
using Carrefour.PostingApi.Services;
using Carrefour.TransactionApi.Context;
using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Repository;

namespace Carrefour.TransactionApi.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<INotifier, Notifier>();


        return services;
    }
}
