using Carrefour.Domain.Model;

namespace Carrefour.TransactionApi.Model;

public class Account : EntityModel
{
    public string? AccountNumber { get; set; }
    public string? AccountType { get; set; }
    public decimal Balance { get; set; }
    //public int CustomerId { get; set; }
    //public Customer Customer { get; set; }
    public List<TransactionModel>? Transactions { get; set; }
}
