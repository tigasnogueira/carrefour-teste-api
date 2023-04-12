using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;

namespace Carrefour.PostingApi.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly IAccountService _accountService;

    public TransactionService(ITransactionRepository repository, IAccountService accountService)
    {
        _repository = repository;
        _accountService = accountService;
    }

    public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
    {
        return await _repository.GetAll();
    }

    public async Task<TransactionModel> GetTransactionById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task<TransactionModel> CreateTransaction(TransactionModel transaction)
    {
        var account = await _accountService.GetAccountById(transaction.AccountId);
        if (account == null)
        {
            throw new ArgumentException("Invalid account ID");
        }

        if (transaction.Type == TransactionType.Despesa && transaction.Amount > account.Balance)
        {
            throw new ArgumentException("Insufficient funds");
        }

        await _repository.Create(transaction);

        if (transaction.Type == TransactionType.Renda || transaction.Type == TransactionType.Transferência)
        {
            account.Balance += transaction.Amount;
        }
        else
        {
            account.Balance -= transaction.Amount;
        }

        await _accountService.UpdateAccount(account);

        return transaction;
    }

    public async Task UpdateTransaction(TransactionModel transaction)
    {
        var existingTransaction = await _repository.GetById(transaction.Id);

        if (existingTransaction == null)
        {
            throw new ArgumentException("Invalid transaction ID");
        }

        var account = await _accountService.GetAccountById(transaction.AccountId);
        if (account == null)
        {
            throw new ArgumentException("Invalid account ID");
        }

        if (transaction.Type == TransactionType.Despesa && transaction.Amount > account.Balance + existingTransaction.Amount)
        {
            throw new ArgumentException("Insufficient funds");
        }

        existingTransaction.Date = transaction.Date;
        existingTransaction.Description = transaction.Description;
        existingTransaction.Amount = transaction.Amount;
        existingTransaction.Type = transaction.Type;

        await _repository.Update(existingTransaction);

        if (existingTransaction.Type == TransactionType.Renda || existingTransaction.Type == TransactionType.Transferência)
        {
            account.Balance -= existingTransaction.Amount;
            account.Balance += existingTransaction.Amount;
        }
        else
        {
            account.Balance += existingTransaction.Amount;
            account.Balance -= existingTransaction.Amount;
        }

        await _accountService.UpdateAccount(account);
    }

    public async Task DeleteTransaction(Guid id)
    {
        var existingTransaction = await _repository.GetById(id);

        if (existingTransaction == null)
        {
            throw new ArgumentException("Invalid transaction ID");
        }

        var account = await _accountService.GetAccountById(existingTransaction.AccountId);
        if (account == null)
        {
            throw new ArgumentException("Invalid account ID");
        }

        if (existingTransaction.Type == TransactionType.Renda || existingTransaction.Type == TransactionType.Transferência)
        {
            account.Balance -= existingTransaction.Amount;
        }
        else
        {
            account.Balance += existingTransaction.Amount;
        }

        await _accountService.UpdateAccount(account);

        await _repository.Delete(existingTransaction);
    }
}
