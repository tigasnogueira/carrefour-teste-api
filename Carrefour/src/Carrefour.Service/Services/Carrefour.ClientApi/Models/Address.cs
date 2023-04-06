using Carrefour.Domain.Model;

namespace Carrefour.ClientApi.Models;

public class Address : EntityModel
{
    public Guid ClientId { get; set; }
    public string CEP { get; set; }
    public string AddressType { get; set; }
    public string AddressName { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string UF { get; set; }


    // EF Relation 
    public ClientModel Client { get; set; }
}
