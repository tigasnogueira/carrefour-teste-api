using Carrefour.TransactionApi.Interfaces;
using Carrefour.TransactionApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.TransactionApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionController(ITransactionService transactionService, ITransactionRepository transactionRepository)
    {
        _transactionService = transactionService;
        _transactionRepository = transactionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var transactions = await _transactionService.GetAllTransactions();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var transaction = await _transactionService.GetTransactionById(id);
        if (transaction == null)
        {
            return NotFound();
        }
        return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TransactionModel transaction)
    {
        await _transactionService.CreateTransaction(transaction);
        return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TransactionModel transaction)
    {
        if (id != transaction.Id)
        {
            return BadRequest();
        }
        await _transactionService.UpdateTransaction(transaction);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var transaction = await _transactionRepository.GetById(id);
        if (transaction == null)
        {
            return NotFound();
        }
        await _transactionRepository.Delete(transaction);
        return NoContent();
    }
}
