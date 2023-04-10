using Carrefour.ClientApi.Models;
using Carrefour.Domain.Interfaces;

namespace Carrefour.ClientApi.Interfaces;

public interface IClientRepository : IRepository<ClientModel>
{
    Task<ClientModel> GetClientAddress(Guid id);
    Task<ClientModel> GetClienteContactAddress(Guid id);
    Task<ClientModel> GetContactAddress(Guid id);
}
