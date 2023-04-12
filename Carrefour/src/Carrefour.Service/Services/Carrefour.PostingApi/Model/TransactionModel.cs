using Carrefour.Domain.Model;

namespace Carrefour.TransactionApi.Model;

public class TransactionModel : EntityModel
{
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public int AccountId { get; set; }
    public Account? Account { get; set; }
}


public enum TransactionType
{
    Renda,
    Despesa,
    Transferência
}
