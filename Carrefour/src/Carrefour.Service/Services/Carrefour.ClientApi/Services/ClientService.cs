using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Services;

public class ClientService : IClientService
{
    public readonly IClientRepository clientRepository;

    public Task Add(ClientModel client)
    {
        return clientRepository.Add(client);
    }

    public Task Update(ClientModel client)
    {
        return clientRepository.Update(client);
    }

    public Task Delete(Guid id)
    {
        return clientRepository.Delete(id);
    }

    public void Dispose()
    {
        clientRepository?.Dispose();
    }
}
