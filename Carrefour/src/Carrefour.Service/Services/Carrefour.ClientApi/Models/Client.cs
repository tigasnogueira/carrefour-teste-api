using Carrefour.ClientApi.Models.Enums;
using Carrefour.Domain.Model;

namespace Carrefour.ClientApi.Models;

public class ClientModel : EntityModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public Gender Gender { get; set; }
    public CivilState CivilState { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Profession { get; set; }
    public string MotherName { get; set; }
    public Nationality Nationality { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public Address Address { get; set; }
    public Contact Contact { get; set; }
}
