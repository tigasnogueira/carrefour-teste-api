using Carrefour.TransactionApi.Context;
using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.TransactionApi.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TransactionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TransactionModel>> GetTransactionsAsync()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public async Task<IEnumerable<Debit>> GetDebitsAsync()
    {
        return await _dbContext.Transactions.OfType<Debit>().ToListAsync();
    }

    public async Task<IEnumerable<Credit>> GetCreditsAsync()
    {
        return await _dbContext.Transactions.OfType<Credit>().ToListAsync();
    }

    public async Task AddTransactionAsync(TransactionModel transaction)
    {
        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
    }
}
