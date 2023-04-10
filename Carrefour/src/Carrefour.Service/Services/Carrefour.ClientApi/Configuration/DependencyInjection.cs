using Carrefour.ClientApi.Context;
using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Repository;
using Carrefour.ClientApi.Services;
using Carrefour.Domain.Interfaces;
using Carrefour.Domain.Notifications;

namespace Carrefour.ClientApi.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ClientDbContext>();
        services.AddScoped<INotifier, Notifier>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IContactService, ContactService>();

        return services;
    }
}
