using Carrefour.TransactionApi.Model;

namespace Carrefour.TransactionApi.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<TransactionModel>> GetTransactionsAsync();
    Task<IEnumerable<Debit>> GetDebitsAsync();
    Task<IEnumerable<Credit>> GetCreditsAsync();
    Task AddTransactionAsync(TransactionModel transaction);
}
