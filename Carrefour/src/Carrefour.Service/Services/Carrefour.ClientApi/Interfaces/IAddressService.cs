using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Interfaces;

public interface IAddressService : IDisposable
{
    Task Add(Address address);
    Task Update(Address address);
    Task Delete(Guid id);
}
