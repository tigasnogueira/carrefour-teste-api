using Carrefour.ClientApi.Models;
using Carrefour.Domain.Interfaces;

namespace Carrefour.ClientApi.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address> GetAddressByClient(Guid clientId);
}
