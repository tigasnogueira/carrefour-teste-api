using Carrefour.ClientApi.Context;
using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.ClientApi.Repository;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ClientDbContext context) : base(context) { }

    public async Task<Address> GetAddressByClient(Guid clientId)
    {
        return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(f => f.ClientId == clientId);
    }
}
