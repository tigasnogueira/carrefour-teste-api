using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;

namespace Carrefour.ClientApi.Services;

public class AddressService : IAddressService
{
    private readonly IAddressService _addressService;

    public Task Add(Address address)
    {
        return _addressService.Add(address);
    }

    public Task Update(Address address)
    {
        return _addressService.Update(address);
    }

    public Task Delete(Guid id)
    {
        return _addressService.Delete(id);
    }

    public void Dispose()
    {
        _addressService.Dispose();
    }
}
