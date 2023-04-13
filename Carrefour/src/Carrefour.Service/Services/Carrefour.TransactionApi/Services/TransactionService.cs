using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;

namespace Carrefour.PostingApi.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<TransactionModel>> GetTransactionsAsync()
    {
        return await _transactionRepository.GetTransactionsAsync();
    }

    public async Task<IEnumerable<Debit>> GetDebitsAsync()
    {
        return await _transactionRepository.GetDebitsAsync();
    }

    public async Task<IEnumerable<Credit>> GetCreditsAsync()
    {
        return await _transactionRepository.GetCreditsAsync();
    }

    public async Task AddTransactionAsync(TransactionModel transaction)
    {
        await _transactionRepository.AddTransactionAsync(transaction);
    }
}
