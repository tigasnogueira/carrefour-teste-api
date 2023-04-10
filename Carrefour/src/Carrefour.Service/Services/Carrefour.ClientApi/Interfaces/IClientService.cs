using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Interfaces;

public interface IClientService : IDisposable
{
    Task Add(ClientModel client);
    Task Update(ClientModel client);
    Task Delete(Guid id);
}
